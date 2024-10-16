using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Data.Linq;
using System.IO;
using System.Threading;
using TRANE_GAS_MANIFOLD;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.Data;
using VTIWindowsControlLibrary;

namespace TRANE_GAS_MANIFOLD.Data
{
  partial class VtiDataContext
  {
    /// <summary>
    /// CheckConnStatus
    /// </summary>
    /// <returns>True if connection to database can be established.</returns>
    public Boolean CheckConnStatus()
    {
      try {
        if (VTIWindowsControlLibrary.VtiLib.Data.Connection.State != ConnectionState.Open)
          VtiLib.Data.Connection.Open();
        return (VtiLib.Data.Connection.State == ConnectionState.Open);
      }
      catch (Exception e) {
        return false;
      }
    }

    /// <summary>
    /// CheckGroupCommand
    /// </summary>
    /// <param name="GroupID">Group</param>
    /// <param name="CommandID">Command</param>
    /// <returns>True if the group has permission to execute the command.</returns>
    public Boolean CheckGroupCommand(String GroupID, String CommandID)
    {
      return (VtiLib.Data.GroupCommands.Count(gc => gc.GroupID == GroupID && gc.CommandID == CommandID) > 0);
    }

    /// <summary>
    /// CheckCommand
    /// </summary>
    /// <param name="OpID">Operator ID</param>
    /// <param name="CommandID">Command</param>
    /// <returns>True if operator has permission to execute the command.</returns>
    public Boolean CheckCommand(String OpID, String CommandID)
    {
      User user = VtiLib.Data.Users.Single(u => u.OpID == OpID);
      if (user.GroupID == "GROUP10") return true;
      if (VtiLib.Data.GroupCommands.Count(gc => gc.GroupID == user.GroupID && gc.CommandID == CommandID) > 0)
        return true;
      else {
        VtiEvent.Log.WriteWarning("The current user '" + OpID +
               "' does not have permission to execute the command '" + CommandID + "'.",
               VTIWindowsControlLibrary.Enums.VtiEventCatType.Manual_Command);
        return false;
      }
    }

    /// <summary>
    /// CheckCommand
    /// 
    /// Checks if the current operator has permission to execyte a command, and displays a warning if not.
    /// </summary>
    /// <param name="OpID">Operator ID</param>
    /// <param name="CommandID">Command</param>
    /// <param name="WarnIfNoPermission">Display a warning if permission not granted</param>
    /// <returns>True if operator has permission to execute the command.</returns>
    public Boolean CheckCommand(String OpID, String CommandID, Boolean WarnIfNoPermission)
    {
      if (string.IsNullOrEmpty(OpID)) {
        MessageBox.Show(VtiLib.Localization.GetString("PleaseLogIn"), Application.ProductName);
        return false;
      } else {
        if (CheckCommand(OpID, CommandID))
          return true;
        else {
          MessageBox.Show(VtiLib.Localization.GetString("User") + " '" + OpID + "' " + VtiLib.Localization.GetString("DoesNotHavePermission") + " '" + CommandID + "'.", Application.ProductName);
          return false;
        }
      }
    }

    /// <summary>
    /// GroupIDFromOpID
    /// </summary>
    /// <param name="OpID">OpID</param>
    /// <returns>Group ID if valid OpID, or empty string if invalid</returns>
    public String GroupIDFromOpID(String OpID)
    {
      User user = VtiLib.Data.Users.Single(u => u.OpID == OpID);
      return user.GroupID;
    }

    /// <summary>
    /// OpIDfromPassword
    /// </summary>
    /// <param name="Password">Password</param>
    /// <returns>Operator ID if valid password, or empty string if invalid</returns>
    public String OpIDfromPassword(String Password)
    {
      if (VtiLib.Data.Users.Count(u => u.Password == Password) > 0)
        return VtiLib.Data.Users.First(u => u.Password == Password).OpID;
      else
        return string.Empty;
    }

    /// <summary>
    /// Gets the current revision of the database from the <see cref="SchemaChanges">SchemaChanges</see> table
    /// </summary>
    public SchemaRevision CurrentRevision
    {
      get
      {
        SchemaChange schemaChange = null;
        SchemaRevision revision = null;
        try {
          schemaChange = this.SchemaChanges.Single(sc =>
              sc.Id == this.SchemaChanges.Max(sc2 => sc2.Id));
        }
        catch { }
        if (schemaChange != null) {
          revision = new SchemaRevision(
              (int)schemaChange.Major,
              (int)schemaChange.Minor,
              (int)schemaChange.Release);
        }
        //else
        //{
        //    revision = new SchemaRevision(1, 0, 0);
        //}
        return revision;
      }
    }

    /// <summary>
    /// Updates the database schema.
    /// </summary>
    /// <remarks>
    /// <para>The database will always exist in the <see cref="Application.StartupPath">Application.StartupPath</see>
    /// in the "Data" sub-folder.  It will always have the name VtiData.mdf</para>
    /// <para>There will be a Data\VtiDataSchema folder which will contain a schema.ddl file,
    /// and a Data\VtiDataSchema\Updates folder which can contain update scripts.  Update
    /// scripts must have filenames in the format of "update.MAJ.MIN.REL.ddl"
    /// where MAJ, MIN, and REL are numerical values.
    /// (i.e. update-001.000.001.ddl, update-001.000.002.ddl, etc.)</para>
    /// <para>If the database doesn't exist, UpdateSchema will attempt to create it.</para>
    /// <para>After verifying that the database exists (or creating it), UpdateSchema will
    /// then search for update scrips in the Data\VtiDataSchema\Updates folder.
    /// If any scripts are found, it will check in the
    /// <see cref="SchemaChanges">SchemaChanges</see> table for a record to indicate
    /// if the script has already been applied.  If there is no record to indicate that
    /// the script has been applied, UpdateSchema will apply the script and add a 
    /// <see cref="SchemaChange">SchemaChange</see> record to the database</para>
    /// </remarks>
    public void UpdateSchema()
    {
      SchemaRevision revision;

      try {
        VtiEvent.Log.WriteInfo("Checking schema for Database 'VtiData'.", VTIWindowsControlLibrary.Enums.VtiEventCatType.Database);

        // Create the database if it doesn't exist
        if (!DatabaseExists()) {
          VtiEvent.Log.WriteInfo("Database 'VtiData' doesn't exist. Creating database.", VTIWindowsControlLibrary.Enums.VtiEventCatType.Database);
          try {
            //CreateDatabase();

            // Log into the master db and create an empty VtiData database
            // This will allow the schema script to build the database and
            // the update scripts to apply the updates.
            // If I left it with the CreateDatabase above, it would create
            // to the current version, and then the update scripts would attempt
            // to duplicate the changes, which might break.
            DataContext db = new DataContext(VtiLib.ConnectionString.Replace("VtiData", "master"));
            db.ExecuteCommand("CREATE DATABASE VtiData");
            db.Connection.Close();
            db.Dispose();

            // Make several attempts to connect to the database
            for (int i = 0; i < 5; i++) {
              try {
                if (this.Connection.State == ConnectionState.Open)
                  this.Connection.Close();
                this.Connection.Open();
                Thread.Sleep(2000);
              }
              catch (Exception e) { }
              if (this.Connection.State == ConnectionState.Open) break;
            }
          }
          catch (Exception e) {
            VtiEvent.Log.WriteError(
                String.Format("An error occurred creating the 'VtiData' database."),
                VTIWindowsControlLibrary.Enums.VtiEventCatType.Database,
                e.ToString());
            return;
          }
        }

        // Get the database revision
        revision = this.CurrentRevision;

        // If there is no revision, the primary schema script has not yet been applied
        if (revision == null) {
          // Execute the primary schema script
          Script schema = new Script(AppDomain.CurrentDomain.BaseDirectory + @"\Data\VtiDataSchema\schema.ddl");
          if (!schema.Apply(this)) return;
        }

        // Get the database revision
        revision = this.CurrentRevision;

        // Create a list of update scripts
        //List<Script> updateScripts = new List<Script>();

        // Retrieve all scripts in the Updates directory
        System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data\VtiDataSchema\Updates");
        //foreach (var fileinfo in directoryInfo.GetFiles("update-???.???.???.ddl"))
        //    updateScripts.Add(new Script(fileinfo.FullName));
        //directoryInfo.GetFiles("update-???.???.???.ddl").ToList().ForEach(F =>
        //    updateScripts.Add(new Script(F.FullName)));

        //// Sort the list
        //updateScripts.Sort();

        var updateScripts = directoryInfo.GetFiles("update-???.???.???.ddl").Select(F =>
            new Script(F.FullName)).OrderBy(S => S.Name).ToList();

        VtiEvent.Log.WriteVerbose(
            "Installing Update Scripts", VTIWindowsControlLibrary.Enums.VtiEventCatType.Database,
            String.Format("{0} Update Script(s) to be processed.", updateScripts.Count));


        // Find each schema update that doesn't exist in the database and execute it
        foreach (var script in updateScripts) {
          if (this.SchemaChanges.Count(sc => sc.Script_name.Equals(script.Name)) == 0) {
            if (script.Revision.Major > revision.Major) {
              VtiEvent.Log.WriteWarning(
                  String.Format("Update Script '{0}' applies to a more recent version of the database schema.", script.Name),
                  VTIWindowsControlLibrary.Enums.VtiEventCatType.Database,
                  String.Format("Database Revision is {0}.{1}.{2}", revision.Major, revision.Minor, revision.Release),
                  String.Format("Script Revision is {0}.{1}.{2}", script.Revision.Major, script.Revision.Minor, script.Revision.Release));
              break;
            } else {
              if (!script.Apply(this)) break;
            }
          } else
            VtiEvent.Log.WriteVerbose(
                String.Format("Script '{0}' has already been applied.", script.Name),
                VTIWindowsControlLibrary.Enums.VtiEventCatType.Database);
        }

        this.SubmitChanges();
      }
      catch (Exception e) {
        VtiEvent.Log.WriteError(
            "An error occurred updating the schema for the 'VtiData' database.",
            VTIWindowsControlLibrary.Enums.VtiEventCatType.Database,
            e.ToString());
      }
    }
  }
}
