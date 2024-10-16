using System;
using System.Reflection;
using System.Resources;
using VTIWindowsControlLibrary;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;
using TRANE_GAS_MANIFOLD;
using TRANE_GAS_MANIFOLD.Data;
using VTIWindowsControlLibrary.Data;
using VTIWindowsControlLibrary.Interfaces;
using VTIWindowsControlLibrary.Classes.ClientForms;

namespace TRANE_GAS_MANIFOLD
{
  /// <summary>
  /// Provides a bridge between the VTIWindowsControlLibrary and the client application.
  /// </summary>
  /// <remarks>
  /// Provides access within the VTIWindowsControlLibrary to the
  /// Machine, Config, and ManualCommands classes within the client application.
  /// Since nothing is known about these classes at compile time, all interaction
  /// with them must be done at run time through reflection.
  /// Provices access within the library to the IO configuration,
  /// the Localization Resource and other resources of the client application.
  /// </remarks>
  public class VtiLib2 : VtiLib
  {
    #region Fields (8)

    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// ConnectionString for the VtiData database.
    /// </summary>
    internal static String ConnectionString;
    /// <summary>
    /// Provides access within the client application to a
    /// static instance of the VtiData class.
    /// </summary>
    public static TRANE_GAS_MANIFOLD.Data.VtiDataContext Data { get; private set; }   
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// I/O configuration of the client application.
    /// </summary>
    //internal static IIOSettings IOSettings;
    internal static IIoConfig IO;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// string localization resource file of the client application.
    /// </summary>
    internal static ResourceManager Localization;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// ManualCommands class of the client application.
    /// </summary>
    internal static Type ManualCommandsType;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// resources file of the client application.
    /// </summary>
    internal static ResourceManager Resources;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// Machine class of the client application.
    /// </summary>
    internal static IMachine Machine;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// Config class of the client application.
    /// </summary>
    internal static IConfig Config;
    /// <summary>
    /// Provides access within the VTIWindowsControlLibrary to the 
    /// ManualCommands class of the client application.
    /// </summary>
    internal static IManualCommands ManualCommands;
    internal static Type ModelSettingsType;

    public static ResourceManager StandardMessages { get; private set; }

    #endregion Fields

    #region Properties (1)

    /// <summary>
    /// Gets the assembly copyright.
    /// </summary>
    /// <value>The assembly copyright.</value>
    public static string AssemblyCopyright
    {
      get
      {
        // Get all Copyright attributes on this assembly
        object[] attributes = Assembly.GetCallingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        // If there aren't any Copyright attributes, return an empty string
        if (attributes.Length == 0)
          return "";
        // If there is a Copyright attribute, return its value
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    public static string DBConnectionString { get { return ConnectionString; } }

    #endregion Properties

    #region Methods (1)

    static VtiLib2()
    {
      if (TRANE_GAS_MANIFOLD.Properties.Settings.Default.CallUpgrade) {
        TRANE_GAS_MANIFOLD.Properties.Settings.Default.Upgrade();
        TRANE_GAS_MANIFOLD.Properties.Settings.Default.CallUpgrade = false;
        TRANE_GAS_MANIFOLD.Properties.Settings.Default.Save();
      }

      StandardMessages = new ResourceManager(typeof(VtiStandardMessages));
    }

    /// <summary>
    /// Initializes the VTI Windows Control Library, allowing the library access to certain
    /// classes within the client application.
    /// </summary>
    /// <typeparam name="TMachine">Type of the Machine class of the client application.</typeparam>
    /// <typeparam name="TConfig">Type of the Config class of the client application.</typeparam>
    /// <typeparam name="TManualCommands">Type of the Manual Commands class of the client application.</typeparam>
    /// <typeparam name="TModelSettings">Type of the Model Settings of the client application.</typeparam>
    /// <typeparam name="TIOSettings">Type of the IO Settings of the client application.</typeparam>
    /// <param name="machine">Instance of the Machine class of the client application.</param>
    /// <param name="config">Instance of the Config class of the client application.</param>
    /// <param name="vtiDataConnectionString">ConnectionString for the VtiData database.</param>
    public static void Initialize<TMachine, TConfig, TManualCommands, TModelSettings, TIOSettings>
        (TMachine machine, TConfig config, string vtiDataConnectionString)
      where TMachine : class, IMachine
      where TConfig : class, IConfig
      where TManualCommands : IManualCommands
      where TModelSettings : ModelSettingsBase
      where TIOSettings : class, IIOSettings
    {
      TRANE_GAS_MANIFOLD.Properties.Settings.Default.Reload();
      VtiEvent.Log.WriteVerbose("Initializing VTI Control Library...");

      SplashScreen.Message = "Initializing Machine...";
      Machine = machine;

      SplashScreen.Message = "Initializing Config...";
      Config = config;

      ModelSettingsType = typeof(TModelSettings);

      SplashScreen.Message = "Initializing Manual Commands...";
      ManualCommands = Machine.ManualCommandsInstance;

      SplashScreen.Message = "Initializing IO...";
      IO = Config.IOInstance.Interface;

      SplashScreen.Message = "Initializing Resource Manager...";
      Localization = Machine.LocalizationInstance;

      SplashScreen.Message = "Initializing Database...";
      ConnectionString = vtiDataConnectionString;
      Data = new TRANE_GAS_MANIFOLD.Data.VtiDataContext(vtiDataConnectionString);
      Data.UpdateSchema();
      SplashScreen.Message = "";
    }

    #endregion Methods
  }
}
