using System;
using System.Windows.Forms;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Enums;
using VTIWindowsControlLibrary.Interfaces;
using VTIWindowsControlLibrary.Classes.ClientForms;
using System.IO;


namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration
{
    /// <summary>
    /// Contains all of the configuration parameters for the machine
    /// </summary>
    public class Config : GenericSingleton<Config>, IConfig
    {
        #region Fields (8)

        #region Protected Fields (7)

        protected ControlSettings _control;
        protected ModeSettings _mode;
        protected PressureSettings _pressure;
        protected TimeSettings _time;
        protected FlowSettings _flow;
        protected ModelSettings _defaultModel;
        protected ModelSettings[] _currentModel;
        protected IOSettings _IO;

        #endregion Protected Fields
        #region Private Fields (1)

        private static TestModes _TestMode;

        #endregion Private Fields

        #endregion Fields

        #region Constructors (1)

        protected Config() { }

        #endregion Constructors

        #region Properties (11)

        public string _OpID { get; set; }

        public static ControlSettings Control { get { return Instance._control; } }
        public static ModeSettings Mode { get { return Instance._mode; } }
        public static PressureSettings Pressure { get { return Instance._pressure; } }
        public static TimeSettings Time { get { return Instance._time; } }
        public static FlowSettings Flow { get { return Instance._flow; } }
        public static ModelSettings DefaultModel { get { return Instance._defaultModel; } }

        public static ModelSettings[] CurrentModel { get { return Instance._currentModel; } }

        public static IOSettings IO { get { return Instance._IO; } }

        public IIOSettings IOInstance { get { return _IO; } }

        public static string OpID
        {
            get { return Instance._OpID; }
            set { Instance._OpID = value; }
        }

        public static TestModes TestMode
        {
            get
            {
                return _TestMode;
            }
            set
            {
                int i=0;
                // set the current test mode
                for (i = 0; i < (Properties.Settings.Default.DualPortSystem ? 2 : 1); i++)
                {
                    //if ((i == 0 && Config.Mode.BluePortEnabled) ||
                    //    (i == 1 && Config.Mode.WhitePortEnabled))
                    {
                    switch (value)
                    {
                        case TestModes.Manual:
                            if (_TestMode != value)
                            {
                                //Machine.Cycle[i].CycleStop();

                                // Reset Prompt
                                Machine.Prompt[i].Clear();
                                Machine.Prompt[i].AppendText(Localization.CurrentTestMode + ": " + value.ToString() + Environment.NewLine + Environment.NewLine);
                            }
                            break;

                        case TestModes.Autotest:
                            _TestMode = value;
                            Machine.Cycle[i].Reset.Start();
                            break;

                        case TestModes.Logoff:
                            if (_TestMode != value)
                            {
                                // Reset Prompt
                                Machine.Prompt[i].Clear();
                                Machine.Prompt[i].AppendText(Localization.OpLoggedOff + Environment.NewLine + Environment.NewLine);
                                Machine.Prompt[i].AppendText(Localization.ScanLogin + Environment.NewLine);
                            }
                            break;

                        case TestModes.Inquire:
                            //if (_TestMode != value)
                            //{
                            //    // Reset Prompt
                            //    Machine.Prompt[i].Clear();
                            //    Machine.Prompt[i].AppendText(Localization.InquirePrompt + Environment.NewLine + Environment.NewLine);
                            //    Machine.Prompt[i].AppendText(Localization.Reset_Prompt + Environment.NewLine);
                            //}
                            break;
                    }
                }
                //    else
                //    {
                //        if (value == TestModes.Autotest)
                //        {
                //            Machine.Prompt[i].Clear();
                //            Machine.Cycle[i].Disabled.Start();
                //        }
                //    }
                //}
                _TestMode = value;

                }

                //for (int i = 0; i < 3; i++)
                //    Machine.Cycle[i].Reset.Start();

                //// create the new operator prompt
                //foreach (RichTextPrompt p in Machine.OpForm.Prompt)
                //{
                //    if (m_TestMode == TestModes.Logoff)
                //    {
                //        p.AppendText(Localization.GetString("OpLoggedOff") + "\n\n");
                //        p.AppendText(Localization.GetString("ScanLogin") + "\n");
                //    }
                //    else
                //        p.AppendText(Localization.GetString("CurrentTestMode") + ": " + m_TestMode.ToString() + "\n");
                //}
            }
        }

        #endregion Properties

        #region Methods (6)

        #region Public Methods (3)

        public virtual void _Save()
        {
            VtiEvent.Log.WriteVerbose("Saving Configuration...");
            _control.Save();
            _mode.Save();
            _pressure.Save();
            _time.Save();
            _flow.Save();
            _defaultModel.Save();


            BackupConfigFile();
        }

        public static void Initialize()
        {
            Instance = new Config();
        }

        public static void Save()
        {
            Instance._Save();
        }

        #endregion Public Methods
        #region Protected Methods (3)

        protected virtual void BlueModel_Loaded(object sender, EventArgs e)
        {
            ModelSettings model = sender as ModelSettings;
            if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Select_Model_Number_via_Touch_Screen)
            {
                Machine.Prompt[Port.Blue].ReplaceRegex(Localization.ModelNumberRegex, model.Name);
            }
            else
            {
                if (Machine.Cycle[Port.Blue].ScanModelNumber.Enabled)
                {
                    VtiEvent.Log.WriteInfo(
                        String.Format("Model Number '{0}' entered via touchscreen for the {1}.", model.Name, Properties.Settings.Default.PortNames[Port.Blue]),
                        VtiEventCatType.Test_Cycle);

                    Machine.Cycle[Port.Blue].ScanModelNumber.Stop();
                    Machine.Cycle[Port.Blue].CycleStart();
                    return;
                }
            }
        }

        
        protected virtual void WhiteModel_Loaded(object sender, EventArgs e)
        {
            ModelSettings model = sender as ModelSettings;
            if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Select_Model_Number_via_Touch_Screen)
            {
                Machine.Prompt[Port.White].ReplaceRegex(Localization.ModelNumberRegex, model.Name);
            }
            else
            {
                if (Machine.Cycle[Port.White].ScanModelNumber.Enabled)
                {
                    VtiEvent.Log.WriteInfo(
                        String.Format("Model Number '{0}' entered via touchscreen for the {1}.", model.Name, Properties.Settings.Default.PortNames[Port.White]),
                        VtiEventCatType.Test_Cycle);

                    Machine.Cycle[Port.White].ScanModelNumber.Stop();
                    Machine.Cycle[Port.White].CycleStart();
                    return;
                }
            }
        }

        protected override void InitializeInstance()
        {
            SplashScreen.Message = "Initializing Config...";
            VtiEvent.Log.WriteVerbose("Initializing Config...");

            _control = new ControlSettings();
            _mode = new ModeSettings();
            _pressure = new PressureSettings();
            _time = new TimeSettings();
            _flow = new FlowSettings();
            _defaultModel = new ModelSettings();
            _currentModel = new ModelSettings[2];

            for (int i = 0; i < (Properties.Settings.Default.DualPortSystem ? 2 : 1); i++)
            {
                _currentModel[i] = new ModelSettings();
            }
            _currentModel[Port.Blue].Loaded += new EventHandler(BlueModel_Loaded);
            if (Properties.Settings.Default.DualPortSystem)
            {
                _currentModel[Port.White].Loaded += new EventHandler(WhiteModel_Loaded);
            }
            _IO = new IOSettings();

            // Upgrade configuration settings only once after
            // a new version of the application has been installed
            if (Properties.Settings.Default.CallUpgrade)
            {
                _control.Upgrade();
                _mode.Upgrade();
                _pressure.Upgrade();
                _time.Upgrade();
                _defaultModel.Upgrade();
                _flow.Upgrade();
                Properties.Settings.Default.CallUpgrade = false;
                Properties.Settings.Default.Save();
            }

            VtiEvent.Log.WriteVerbose("Done Initializing Config...");
        }

        protected void BackupConfigFile()
        {

            _control.BackupEditCycleConfig();
        }

        #endregion Protected Methods

        #endregion Methods

        #region Nested Classes (2)


        /// <summary>
        /// configuration flags
        /// </summary>
        public static class Flags
        {
            //public static Boolean Testing;
        }
        /// <summary>
        /// Machine time parameters
        /// </summary>
        public static class MachineTime
        {
            #region Fields (1)

            #region Public Fields (1)

            public static Single[]
                MACHINE_START_TIME = new Single[2],
                MACHINE_END_TIME = new Single[2],
                TOTAL_TIME = new Single[2],
                MACHINE_TEST_TIME = new Single[2],
                IDLE_TIME = new Single[2];

            #endregion Public Fields

            #endregion Fields
        }
        #endregion Nested Classes
    }
}
