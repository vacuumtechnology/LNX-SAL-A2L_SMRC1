using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Enums;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Database
{
    public class SQLDataReader1
    {
        /*  From Rods notes all applies
            note: this function requires that SQL Server be running on the remote
            computer and that that computer be configured to allow remote access.
            To connect to a remote SQL Server
            On the remote computer run SQL Surface Area Configuration for Services and Connections tool.  
            Enable Local and Remote connections, using TCP/IP only. Start the SQL Server Browser.  
            Leave Windows Firewall enabled.  Allow a program or feature through Windows Firewall.  
            Allow another program... Add a program, Browse... 
            navigate to C:\Program Files\Microsoft SQL Server\90\Shared\sqlbrowser.exe and add it.  
            Navigate to C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Binn\sqlservr.exe and add it.
         */
        // Confirm computer you query from can access the other computer via Windows explorer.
        // Enter username and password that logs into Windows on both computers and allow remote access if Domain log not used
        // Add using TRANE_CNC.Classes.Database; to your cs file you are calling from CycleSteps.cs
        //  Create an instance in your CycleSteps.cs
        //SQLDataReader1 PretestPD = new SQLDataReader1();
        //        if (PretestPD.PretestPDCheck())
        //        {

        //        }

        public bool PretestPDCheck() // returns true if value is matched
        {
            try
            {
                SqlConnection myConnection = new SqlConnection("user id=sa;" +
                                       "password=VTIsa;server=toddxp32vm;" +
                                       "Trusted_Connection=yes;" +
                                       "database=VTI_DATA_UUT; " +
                                       "connection timeout=30");
                String SN = "123456789123456789";
                String QueryString = "select * from UUT_Records where serial_number = '" + SN + "'";
                String FieldToReturn = "Test_Result";
                SQLDataReader1 pretest = new SQLDataReader1();
                string TestResult = pretest.PretestPassCheck(myConnection, QueryString, FieldToReturn);
                if (TestResult.Contains("PASS"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                VtiEvent.Log.WriteInfo(ex.Message, VtiEventCatType.Test_Cycle);
                return false;

            }
        }

        public String PretestPassCheck(SqlConnection myConnection, String QueryString, String FieldToReturn)
        {
            // ** Return Values **
            //return "no record returned";
            //return ResultOfPretest; // success
            //return ResultOfPretest + ", error closing connection";
            //return "error reading record";
            //return "error executing query";
            //return "error connecting to database";

            try
            {
                myConnection.Open();
                try
                {
                    SqlDataReader myReader = null;
                    SqlCommand myCommand = new SqlCommand(QueryString,
                                                             myConnection);
                    myReader = myCommand.ExecuteReader();
                    if (myReader.HasRows == false)
                    {
                        try
                        {
                            myConnection.Close();
                        }
                        catch (Exception e)
                        {
                            //Console.WriteLine(e.ToString());
                            VtiEvent.Log.WriteWarning(
                            String.Format("An error occurred closing the connection."),
                            VtiEventCatType.Database,
                            e.ToString());
                        }
                        return "no record returned";
                    }
                    else
                    {
                        try
                        {
                            // while (myReader.Read()) { }  // Use to step through multiple records
                            myReader.Read();
                            string ResultOfPretest = myReader[FieldToReturn].ToString();
                            //Console.WriteLine(myReader["Test_Result"].ToString());
                            //Console.WriteLine(myReader["Date_Time"].ToString());

                            /* optional column at a time
                              Console.WriteLine(myReader["Column1"].ToString());
                                Console.WriteLine(myReader["Column2"].ToString());
                             */
                            try
                            {
                                myConnection.Close();
                                return ResultOfPretest; // success
                            }
                            catch (Exception e)
                            {
                                //Console.WriteLine(e.ToString());
                                VtiEvent.Log.WriteWarning(
                                String.Format("An error occurred closing the connection, no field data returned."),
                                VtiEventCatType.Database,
                                e.ToString());
                                return ResultOfPretest + ", error closing connection";
                            }
                        }
                        catch (Exception e)
                        {
                            VtiEvent.Log.WriteWarning(
                               String.Format("An error occurred reading the records."),
                               VtiEventCatType.Database,
                               e.ToString());
                            try
                            {
                                myConnection.Close();
                            }
                            catch (Exception e2)
                            {
                                //Console.WriteLine(e2.ToString());
                                VtiEvent.Log.WriteWarning(
                                String.Format("An error occurred closing the connection."),
                                VtiEventCatType.Database,
                                e2.ToString());
                            }
                            return "error reading record";
                        }
                    }
                }
                catch (Exception e)
                {
                    //  Console.WriteLine(e.ToString());
                    VtiEvent.Log.WriteWarning(
                       String.Format("An error executing query string."),
                       VtiEventCatType.Database,
                       e.ToString());
                    return "error executing query";
                }
            }
            catch (Exception e)
            {
                VtiEvent.Log.WriteWarning(
                                   String.Format("An error occured connecting to the Database. "),
                                   VtiEventCatType.Database,
                                   e.ToString());
                return "error connecting to database";
            }

        }
    }
}
