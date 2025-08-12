using System;
//using MccDaq;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes;
//using VTI_EVAC_AND_DUAL_CHARGE.Data;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTI_EVAC_AND_SINGLE_CHARGE.Forms;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Database;
using VTIWindowsControlLibrary;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Components;
using VTIWindowsControlLibrary.Enums;
using VTIWindowsControlLibrary.Forms;
using VTIWindowsControlLibrary.Interfaces;
using VTIWindowsControlLibrary.Classes.ClientForms;
using VTIWindowsControlLibrary.Classes.ManualCommands;
using VTIWindowsControlLibrary.Components.Graphing;
using VTIWindowsControlLibrary.Classes.Util;
using Microsoft.VisualBasic.Devices;

namespace VTI_EVAC_AND_SINGLE_CHARGE
{
  public class Machine : GenericSingleton<Machine>, IMachine
  {
    protected Machine() { }

    public static void Initialize()
    {
      Instance = new Machine();
    }
        private bool useReadExistingForScanner;
        protected OperatorFormDualNested2 _OpFormDual;
        //protected OperatorFormSingleNested2 _OpFormSingle;
        protected OperatorFormSingleNested _OpFormSingle;

    protected RichTextPrompt[] _Prompt;

    protected RichTextBox _RichTextBox;

    protected SequenceStepsControl.SequenceStepList[] _Sequences;
    protected DataPlotControl[] _DataPlot;
    protected DataPlotDockControl[] _DataPlotDockControl;
    protected TestHistoryControl[] _TestHistory;
    protected ValvesPanelControl[] _ValvesPanel;
    protected SystemSignalsControl[] _SystemSignals;

    protected ResourceManager _LocalizationResource;
    protected ResourceManager _Resources;
    protected CultureInfo _EnglishCulture;
    protected CultureInfo _FrenchCulture;
    protected CultureInfo _SpanishCulture;
    protected ManualCommands _ManualCommands;
    protected CycleSteps[] _Cycle;
    protected TestInfo[] _Test;
    protected SchematicFormBase _Schematic;
    private string scannerText;
    protected SerialPort _ZM400;
    protected SerialPort _Scale;
    private string zm400Text;
    protected MainForm _MainForm;
    protected BadgeForm _BadgeForm;
    protected MessageForm _MessageForm;
    protected FlowmeterCalibrate _FlowmeterCalibrate;
        protected SleepDiagnosticsForm _SleepDiagnosticsForm;
        protected CycleStepsActiveForm _CycleStepsActiveForm;

    public static CycleStepsActiveForm CycleStepsForm { get { return Instance._CycleStepsActiveForm; } }
    public static Int32 InitializeCounter{ get { return Instance.InitializeCounterBoard(); } }

    public static OperatorFormDualNested2 OpFormDual { get { return Instance._OpFormDual; } }
    //public static OperatorFormSingleNested2 OpFormSingle { get { return Instance._OpFormSingle; } }
        public static OperatorFormSingleNested OpFormSingle { get { return Instance._OpFormSingle; } }

        public static RichTextPrompt[] Prompt { get { return Instance._Prompt; } }

    public static RichTextBox RichTextBox
    {
      get
      {
        return Instance._RichTextBox;
      }
    }

    public static SequenceStepsControl.SequenceStepList[] Sequences { get { return Instance._Sequences; } }
    public static DataPlotControl[] DataPlot { get { return Instance._DataPlot; } }
    public static DataPlotDockControl[] DataPlotDockControl { get { return Instance._DataPlotDockControl; } }
    public static TestHistoryControl[] TestHistory { get { return Instance._TestHistory; } }
    public static ValvesPanelControl[] ValvesPanel { get { return Instance._ValvesPanel; } }
    public static SystemSignalsControl[] SystemSignals { get { return Instance._SystemSignals; } }

    public static ResourceManager LocalizationResource { get { return Instance._LocalizationResource; } }
    public static ResourceManager Resources { get { return Instance._Resources; } }
    public static CultureInfo EnglishCulture { get { return Instance._EnglishCulture; } }
    public static CultureInfo FrenchCulture { get { return Instance._FrenchCulture; } }
    public static CultureInfo SpanishCulture { get { return Instance._SpanishCulture; } }
    public static ManualCommands ManualCommands { get { return Instance._ManualCommands; } }
    public static CycleSteps[] Cycle { get { return Instance._Cycle; } }
    public static TestInfo[] Test { get { return Instance._Test; } }
    public static SchematicFormBase Schematic { get { return Instance._Schematic; } }
    public static SerialPort Scale { get { return Instance._Scale; } }
    public static SerialPort ZM400 { get { return Instance._ZM400; } }
    public static BadgeForm Badge { get { return Instance._BadgeForm; } }
    public static MessageForm Message { get { return Instance._MessageForm; } }
    public static FlowmeterCalibrate FlowmeterCalibrate { get { return Instance._FlowmeterCalibrate; } }
        public static SleepDiagnosticsForm SleepDiagnosticsForm { get { return Instance._SleepDiagnosticsForm; } }
        public static MainForm MainForm { get { return Instance._MainForm; } }
    
    public ResourceManager LocalizationInstance { get { return _LocalizationResource; } }
    public IManualCommands ManualCommandsInstance { get { return _ManualCommands; } }

    protected override void InitializeInstance()
    {
      SplashScreen.Show(Application.ProductName, Application.ProductVersion, VtiLib.AssemblyCopyright + "  " + Application.CompanyName);
      VtiEvent.Log.WriteInfo("Initializing System");

      _MainForm = Program.MainForm;

      InitializeResources();
      InitializeConfiguration();
      InitializeParameters();
      InitializeEventLog();
      InitializeManualCommands();
      InitializeLibrary();
      
      InitializeMainForm();
      InitializeOperatorForm(false);
      InitializeTestInfo();
      InitializeSchematic();
      InitializeBadgeForm();
      InitializeMessageForm();
      InitializeFlowmeterCalibrate();
            InitializeSleepDiagnosticsForm();
            InitializeDatabase();
      InitializeIoInterface();
      InitializeDataPlot();
      InitializeSystemSignals();
      InitializeValvesPanel();
      InitializeBarcodeScanner();
      InitializeScale();
      //InitializeZM400();
      InitializeCycleSteps();
      ShowHideCommands();

      Machine.ManualCommands.ViewManualCommands();

      // Initial mode is "logged off"
      Config.TestMode = TestModes.Logoff;
      Config.OpID = string.Empty;

      VtiEvent.Log.WriteVerbose("Done Initializing Machine...");

      //if (!MyStaticVariables.USBCounterError)
      {
          SplashScreen.Hide();
      }
      //else
      //{
      //    Thread.Sleep(10000);
      //    Environment.Exit(-1);
      //}

    }

    protected virtual void InitializeResources()
    {
      SplashScreen.Message = "Initializing Machine...";
      VtiEvent.Log.WriteVerbose("Initializing Machine...");
      // Need to initialize the Resource Manager early on, since other things use it
      _LocalizationResource =
          new ChainableResourceManager(VtiLib.StandardMessages, "VTI_EVAC_AND_SINGLE_CHARGE.Localization", System.Reflection.Assembly.GetExecutingAssembly());
      _Resources = new ResourceManager("VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());

      _EnglishCulture = new CultureInfo("en-US");
      _FrenchCulture = new CultureInfo("fr-FR");
      _SpanishCulture = new CultureInfo("es-ES");
    }

    protected virtual void InitializeConfiguration()
    {
      // Initialize the Configuration
      SplashScreen.Message = "Initializing Configuration...";
      Config.Initialize();

      // Set the current language culture
      if (Config.Control.Language.ProcessValue == Languages.English)
        System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.EnglishCulture;
      else
        System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.SpanishCulture;

    }

    protected virtual Int32 InitializeCounterBoard()
    {
      //Initialize the counter board
      SplashScreen.Message = Localization.InitializingCounterBoard;

      ////MessageBox.Show("This message box was called from Initialize Counter.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

      //_ULSTAT = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.DontPrint, MccDaq.ErrorHandling.StopAll);
      //int Boardnum = 2;
      //_CounterBoard = new MccDaq.MccBoard(Boardnum);

      //if (_CounterBoard.BoardName.Contains("USB-CTR"))
      //{
          
      //}
      //else
      //{
          
      //    //SplashScreen.Message = "USB Counter not Set Up";
      //    MyStaticVariables.USBCounterError = true;
      //    MyStaticVariables.USBErrorTime = DateTime.Now;
      //    //MessageBox.Show("USB Counter not set as Board Number 2 in Measurement Computing InstaCal program.  Program halting.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //    MessageBox.Show("USB Counter not set as Board Number 2 in Measurement Computing InstaCal Program.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //    return -2;
      //    //Thread.Sleep(10000);
      //    //Environment.Exit(-1);
      //}

      ////Counter 0
      ////set up registers
      //_LoadRegister = MccDaq.CounterRegister.LoadReg0;
      //_MaxLimitRegister = MccDaq.CounterRegister.MaxLimitReg0;
      //_MinLimitRegister = MccDaq.CounterRegister.MinLimitReg0;
      //_OutputRegister0 = MccDaq.CounterRegister.OutputVal0Reg0;
      //_OutputRegister1 = MccDaq.CounterRegister.OutputVal1Reg0;
      ////set counter number
      //_NumCounter = 0;
      ////set counter mode;
      //_Mode = MccDaq.CounterMode.Totalize;
      //_Mode = _Mode | MccDaq.CounterMode.CountDownOn;      
      //_Mode = _Mode | MccDaq.CounterMode.RangeLimitOff;
      //_Mode = _Mode | MccDaq.CounterMode.NoRecycleOff;
      //_Mode = _Mode | MccDaq.CounterMode.OutputInitialStateHigh;
      //_Mode = _Mode | MccDaq.CounterMode.OutputOn;

      //int LoadVal = 20000;

      ////load max and min limit registers
      //_ULSTAT = _CounterBoard.CLoad32(_MaxLimitRegister, 25000);
      //if (ULSTAT.Value == ErrorInfo.ErrorCode.NoUsbBoard)
      //{
          
      //    MyStaticVariables.USBCounterError = true;
      //    MyStaticVariables.ShowUSBCounterNoDetectedError = true;
      //    MyStaticVariables.USBErrorTime = DateTime.Now;
          
      //    //try
      //    //{
      //    //    //SplashScreen.Message = "USB Counter Not Detected";
      //    //    //MessageBox.Show("USB Counter not detected.  Program halting.", "USB Counter Errror", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //        MessageBox.Show("USB Counter not detected.  Program will halt.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //        //return -1;
      //    //}
      //    //catch (Exception ex)
      //    //{
      //    //    Console.WriteLine(ex.ToString());
      //    //}
      //    //return;
      //}

      //_ULSTAT = _CounterBoard.CLoad32(_MinLimitRegister, -25000);

      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, 0); //goes high at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, Machine.Test[1].CounterStopValueLowSide); //goes high at this count
      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 25000); //goes low at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 500); //goes low at this count

      ////configure scan
      //_CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
      //_CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
      //_CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
      //_myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
      //_MappedChannel = 0;
      //_ULSTAT = CounterBoard.CConfigScan(_NumCounter, _Mode, _CounterDebounceTime, _CounterDebounceMode, _CounterEdgeDetection, _myCounterTickSize, _MappedChannel);

      ////load the register to count down      
      //_ULSTAT = _CounterBoard.CLoad32(_LoadRegister, LoadVal);

      ////Counter 1
      ////set up registers
      //_LoadRegister = MccDaq.CounterRegister.LoadReg1;
      //_MaxLimitRegister = MccDaq.CounterRegister.MaxLimitReg1;
      //_MinLimitRegister = MccDaq.CounterRegister.MinLimitReg1;
      //_OutputRegister0 = MccDaq.CounterRegister.OutputVal0Reg1;
      //_OutputRegister1 = MccDaq.CounterRegister.OutputVal1Reg1;
      ////set counter number
      //_NumCounter = 1;
      ////set counter mode;
      //_Mode = MccDaq.CounterMode.Totalize;
      //_Mode = _Mode | MccDaq.CounterMode.CountDownOn;
      //_Mode = _Mode | MccDaq.CounterMode.RangeLimitOff;
      //_Mode = _Mode | MccDaq.CounterMode.NoRecycleOff;
      //_Mode = _Mode | MccDaq.CounterMode.OutputInitialStateHigh;
      //_Mode = _Mode | MccDaq.CounterMode.OutputOn;

      //LoadVal = 20000;

      ////load max and min limit registers
      //_ULSTAT = _CounterBoard.CLoad32(_MaxLimitRegister, 25000);
      //_ULSTAT = _CounterBoard.CLoad32(_MinLimitRegister, -25000);

      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, 0); //goes high at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, Machine.Test[1].CounterStopValueHiSide); //goes high at this count
      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 25000); //goes low at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 500); //goes low at this count

      ////configure scan
      //_CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
      //_CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
      //_CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
      //_myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
      //_MappedChannel = 0;
      //_ULSTAT = _CounterBoard.CConfigScan(_NumCounter, _Mode, _CounterDebounceTime, _CounterDebounceMode, _CounterEdgeDetection, _myCounterTickSize, _MappedChannel);

      ////load the register to count down      
      //_ULSTAT = _CounterBoard.CLoad32(_LoadRegister, LoadVal);

      ////Counter 2
      ////set up registers
      //_LoadRegister = MccDaq.CounterRegister.LoadReg2;
      //_MaxLimitRegister = MccDaq.CounterRegister.MaxLimitReg2;
      //_MinLimitRegister = MccDaq.CounterRegister.MinLimitReg2;
      //_OutputRegister0 = MccDaq.CounterRegister.OutputVal0Reg2;
      //_OutputRegister1 = MccDaq.CounterRegister.OutputVal1Reg2;
      ////set counter number
      //_NumCounter = 2;
      ////set counter mode;
      //_Mode = MccDaq.CounterMode.Totalize;
      //_Mode = _Mode | MccDaq.CounterMode.CountDownOn;
      //_Mode = _Mode | MccDaq.CounterMode.RangeLimitOff;
      //_Mode = _Mode | MccDaq.CounterMode.NoRecycleOff;
      //_Mode = _Mode | MccDaq.CounterMode.OutputInitialStateHigh;
      //_Mode = _Mode | MccDaq.CounterMode.OutputOn;

      //LoadVal = 20000;

      ////load max and min limit registers
      //_ULSTAT = _CounterBoard.CLoad32(_MaxLimitRegister, 25000);
      //_ULSTAT = _CounterBoard.CLoad32(_MinLimitRegister, -25000);

      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, 0); //goes high at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, Machine.Test[0].CounterStopValueLowSide); //goes high at this count
      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 25000); //goes low at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 500); //goes low at this count

      ////configure scan
      //_CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
      //_CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
      //_CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
      //_myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
      //_MappedChannel = 0;
      //_ULSTAT = _CounterBoard.CConfigScan(_NumCounter, _Mode, _CounterDebounceTime, _CounterDebounceMode, _CounterEdgeDetection, _myCounterTickSize, _MappedChannel);

      ////load the register to count down      
      //_ULSTAT = _CounterBoard.CLoad32(_LoadRegister, LoadVal);

      ////Counter 3
      ////set up registers
      //_LoadRegister = MccDaq.CounterRegister.LoadReg3;
      //_MaxLimitRegister = MccDaq.CounterRegister.MaxLimitReg3;
      //_MinLimitRegister = MccDaq.CounterRegister.MinLimitReg3;
      //_OutputRegister0 = MccDaq.CounterRegister.OutputVal0Reg3;
      //_OutputRegister1 = MccDaq.CounterRegister.OutputVal1Reg3;
      ////set counter number
      //_NumCounter = 3;
      ////set counter mode;
      //_Mode = MccDaq.CounterMode.Totalize;
      //_Mode = _Mode | MccDaq.CounterMode.CountDownOn;
      //_Mode = _Mode | MccDaq.CounterMode.RangeLimitOff;
      //_Mode = _Mode | MccDaq.CounterMode.NoRecycleOff;
      //_Mode = _Mode | MccDaq.CounterMode.OutputInitialStateHigh;
      //_Mode = _Mode | MccDaq.CounterMode.OutputOn;

      //LoadVal = 20000;

      ////load max and min limit registers
      //_ULSTAT = _CounterBoard.CLoad32(_MaxLimitRegister, 25000);
      //_ULSTAT = _CounterBoard.CLoad32(_MinLimitRegister, -25000);

      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, 0); //goes high at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister0, Machine.Test[0].CounterStopValueHiSide); //goes high at this count
      ////_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 25000); //goes low at this count
      //_ULSTAT = _CounterBoard.CLoad(_OutputRegister1, 500); //goes low at this count

      ////configure scan
      //_CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
      //_CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
      //_CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
      //_myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
      //_MappedChannel = 0;
      //_ULSTAT = _CounterBoard.CConfigScan(_NumCounter, _Mode, _CounterDebounceTime, _CounterDebounceMode, _CounterEdgeDetection, _myCounterTickSize, _MappedChannel);

      ////load the register to count down      
      //_ULSTAT = _CounterBoard.CLoad32(_LoadRegister, LoadVal);

      //if (!MyStaticVariables.USBCounterError)
      //{
      //    Machine.Test[0].CountersInitialized = true;
      //    Machine.Test[1].CountersInitialized = true;
      //}

      return 1;
    }

    protected virtual void InitializeParameters()
    {
      //if (!Properties.Settings.Default.DualPortSystem) {

        //if (Config.Mode.PrechargeSystem == false)
        //{
        //    Config.Flow.BackgroundZeroCorrectPercentage.Visible = false;
        //    Config.Flow.MinChamberFlowReading.Visible = false;

        //    Config.Mode.BluePortEnabled.Visible = true;
        //    Config.Mode.WhitePortEnabled.Visible = true;

        //}
        //else
        //{

        //}

        // if the safety latch is installed show the latch delay under common time
        //Config.Time.ChamberDoorSafetyLatchDelay.Visible = Config.Mode.ChamberDoorSafetyLatchInstalled.ProcessValue;

          Config.Control.SerialNumberLocationIn2DBarcode.Visible = false;
          Config.Control.BarcodeDelimiterCode.Visible = false;

            Config.Mode.A2LRefrigerantMode.ProcessValue = true;
            Config.Mode.A2LRefrigerantMode.Visible = false;

          Config.Control.WhiteRefrigerantName.Visible = false;
          Config.Control.WhiteRefrigerantType.Visible = false;
          Config.Control.ModelDataConnectionString.Visible = false;
          Config.Control.ModelDataSelectString.Visible = false;
          Config.Control.ModelDataFromTableNameString.Visible = false;
          Config.Control.ModelDataWhereString.Visible = false;
          Config.Control.StoredProcedureConnectionString.Visible = false;
          Config.Control.RemoteConnectionString_LennoxKeywords.Visible = false;
          Config.Control.TestResultConnectionString.Visible = false;
            Config.Mode.CDGInstalled.ProcessValue = false;
            Config.Mode.CDGInstalled.Visible = false;
            Config.Mode.AdjustOffsetCountsUsingFlowEnabled.Visible = false;
            Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue = false;
            Config.Mode.InsertValveCoresAfterChargeEnabled.Visible = false;
            Config.Mode.RecoverToServiceValvePartialStart.ProcessValue = false;
            Config.Mode.RecoverToServiceValvePartialStart.Visible = false;
            Config.Mode.ToolEvacEnabled.Visible = false;
          Config.Mode.AutoDemoCycleEnable.Visible = false;
          Config.Mode.BarCodeScannerMode.Visible = false;
          Config.Mode.ModelScanMode.Visible = true;
          Config.Mode.DigitalOutputInterlocks.Visible = false;
          Config.Mode.Trace_Level.Visible = false;

          Config.Mode.WhiteCircuit1PortEnabled.Visible = false;
          Config.Mode.WhiteCircuit1HiSideEnabled.Visible = false;
          Config.Mode.WhiteCircuit1LowSideEnabled.Visible = false;
          Config.Mode.ModelScanMode.Visible = false;

          Config.Mode.UseCDGForTest.Visible= false;
          Config.Mode.RecoveryEnabled.Visible= false;

        // Changes made for Rheem Dual Charger Oct 2016
          Config.Control.ScaleCommPort.Visible = false;
          Config.Control.BlueCircuit2FlowmeterPort.Visible = false;
          Config.Control.BlueCircuit2FlowmeterID.Visible = false;
          Config.Control.WhiteCircuit1FlowmeterPort.Visible = false;
          Config.Control.WhiteCircuit1FlowmeterID.Visible = false;
          Config.Control.WhiteCircuit1EvacPressurePort.Visible = false;
          Config.Control.ScaleWeightOffset.Visible = false;

          Config.Mode.HiSideConnectorCheckEnabled.ProcessValue = false;
          Config.Mode.HiSideConnectorCheckEnabled.Visible = false;
          Config.Mode.LowSideConnectorCheckEnabled.ProcessValue = false;
          Config.Mode.LowSideConnectorCheckEnabled.Visible = false;
          Config.Mode.ScaleEnabled.ProcessValue =   false;
          Config.Mode.ScaleEnabled.Visible = false;
          Config.Mode.UseHardyScale.Visible = false;
          Config.Mode.WhiteRecoveryTankFloatSwitchEnabled.Visible = false;
          Config.Mode.WhiteRecoveryTankFloatSwitchEnabled.ProcessValue = false;
          Config.Mode.RecoveryTankFloatSwitchEnabled.Visible = false;
          Config.Mode.RecoveryTankFloatSwitchEnabled.ProcessValue = false;
          Config.Mode.AutoSetScaleOffsetEnable.Visible = false;
          Config.Mode.CheckStoredProcedureEnabled.Visible = false;
          Config.Mode.CheckModelDatabase.Visible = false;

          Config.Pressure.Connector_Check_Pressure_SetPoint.Visible = false;
            Config.Pressure.CDG_High_Pressure_Limit.Visible = false;
            Config.Pressure.DiagBasePressureStpnt.Visible = false;
            Config.Pressure.DiagEvacSetpoint.Visible = false;
            Config.Pressure.DiagRcvrSupplySetpoint.Visible = false;
            Config.Pressure.DiagRORSetpoint.Visible = false;
            Config.Pressure.DiagRORValvCheckSetpoint.Visible = false;
            Config.Pressure.DiagVentingSetpoint.Visible = false;

            Config.Pressure.Diag_Test_ROR_Pressure_SetPoint.Visible = false;
            Config.Pressure.Minimum_Convection_Pressure_Reading.Visible = false;
            Config.Pressure.Minimum_ROR_Pressure_Change_SetPoint.Visible = false;
            Config.Pressure.PartialChargeServiceValveEvacSetpoint.Visible = false;
            Config.Pressure.Vacuum_High_Pressure_Alarm_SetPoint.Visible = false;

            Config.Pressure.LateLeakCheckRORMaxSetPoint.Visible = false;
          Config.Pressure.White_Refrigerant_Low_Pressure_Alarm_SetPoint.Visible = false;
          Config.Pressure.WhiteCircuit1SupplyTransducerFullScale.Visible = false;
          Config.Pressure.WhiteCircuit1SupplyTransducerOffset.Visible = false;
          Config.Pressure.WhiteCircuit1ToolCheckTransducerFullScale.Visible = false;
          Config.Pressure.WhiteCircuit1ToolCheckTransducerOffset.Visible = false;
          Config.Pressure.Diag_Test_ROR_Pressure_SetPoint.Visible = false;

          Config.Time.Connector_Check_Timeout.Visible = false;
          Config.Time.Diag_Test_Evac_Delay.Visible=false;
          Config.Time.Diag_Test_ROR_Delay.Visible=false;
          Config.Time.Late_Leak_Check_ROR_Delay.Visible=false;
          Config.Time.LateLeakCheckEvacDelay.Visible=false;
            Config.Time.DiagRORDelay.Visible = false;
            Config.Time.DiagBasePressChckDly.Visible = false;
            Config.Time.DiagEvacMaxTime.Visible = false;
            Config.Time.DiagInitialEvacDelay.Visible = false;
            Config.Time.DiagMaxRcvrSupplyDly.Visible = false;
            Config.Time.DiagRORDelay.Visible = false;
            Config.Time.DiagRORValveChckDelay.Visible = false;
            Config.Time.DiagVentingDelay.Visible = false;
            Config.Time.Diag_Test_Evac_Delay.Visible = false;
            Config.Time.Diag_Test_ROR_Delay.Visible = false;
            Config.Time.Hose_Pre_Fill_Delay.Visible = false;
            Config.Time.Pump_Before_Connector_Check_Delay.Visible = false;
            Config.Time.Tool_Evac_Delay.Visible = false;
            Config.Time.Tool_Open_Evac_Valve_Delay.Visible = false;


            Config.Flow.Blue_Flowmeter_Flow_Factor.Visible = false;
          Config.Flow.White_Flowmeter_Flow_Factor.Visible = false;
          Config.Flow.MinimumChargeWeightErrorFromScale.Visible = false;
          Config.Flow.MaximumChargeWeightErrorFromScale.Visible = false;
          Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.Visible = false;
          Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.Visible = false;
          Config.Flow.White_Flowmeter_Calibration_Flow.Visible = false;
          Config.Flow.White_Flowmeter_Flow_Factor.Visible = false;
          Config.Flow.Flowmeter_Zero_Warning_SetPoint.Visible = false;

          Config.DefaultModel.ScaleWeightCorrection.Visible = false;
          Config.Mode.RecoveryTankFloatSwitchEnabled.Visible = false;


      //}
    }

    protected virtual void InitializeEventLog()
    {
      // Set the log level
      SplashScreen.Message = Localization.InitializingEventLog;
     // VtiEvent.Log.WriteToSimpleTextFile = true;
     // VtiEvent.Log.DaysToKeepOldVtiEventLogTextFiles = 0;
      VtiEvent.Log.Level = Config.Mode.Trace_Level; // first place we can safely set this
      VtiEvent.Log.WriteVerbose("Event Viewer Trace Level set to '" + VtiEvent.Log.Level.ToString() + "'.");
    }

    protected virtual void InitializeLibrary()
    {
      // Initialize the Library
      SplashScreen.Message = Localization.InitializingLibrary;
      VtiLib.Initialize<Machine, Config, ManualCommands, ModelSettings, IOSettings>
          (Machine.Instance, Config.Instance, Properties.Settings.Default.VtiDataConnectionString);
    }

    protected virtual void InitializeTestInfo()
    {
      _Test = new TestInfo[2];
      _Test[0] = new TestInfo();
      _Test[1] = new TestInfo();

      _Test[0].CountersInitialized = false;
      _Test[1].CountersInitialized = false;
      _Test[0].LoadHiSideCounter = 20000;
      _Test[0].LoadLowSideCounter = 20000;
      _Test[1].LoadHiSideCounter = 20000;
      _Test[1].LoadLowSideCounter = 20000;

      _Test[0].LastFlowValue = 3.0;
      _Test[1].LastFlowValue = 3.0;

      _Test[0].CounterStopValueHiSide = 500;
      _Test[1].CounterStopValueHiSide = 500;
      _Test[0].CounterStopValueLowSide = 500;
      _Test[1].CounterStopValueLowSide = 500;

      _Test[0].Result = "";
      _Test[1].Result = "";
      _Test[0].SerialNumber = "";
      _Test[1].SerialNumber = "";
      _Test[0].PartChargeByCounterStart = 0;
      _Test[1].PartChargeByCounterStart = 0;
      _Test[0].MessageBoxFlag = false;
      _Test[1].MessageBoxFlag = false;
    }

    protected virtual void InitializeManualCommands()
    {
      SplashScreen.Message = Localization.InitializingManualCommands;
      _ManualCommands = new ManualCommands();

    }

    protected virtual void ShowHideCommands()
    {
      //if (Properties.Settings.Default.DualPortSystem)
      //{
      //    _ManualCommands.ShowCommand("BluePort");
      //    _ManualCommands.ShowCommand("WhitePort");
      //    _ManualCommands.ShowCommand("ResetBlue");
      //    _ManualCommands.ShowCommand("ResetWhite");
      //    _ManualCommands.ShowCommand("EnableBlue");
      //    _ManualCommands.ShowCommand("EnableWhite");
      //    _ManualCommands.ShowCommand("DisableBlue");
      //    _ManualCommands.ShowCommand("DisableWhite");
      //}
      //else
      //{
      //    _ManualCommands.ShowCommand("ATESTSTEP");
      //    _ManualCommands.HideCommand("BluePort");
      //    _ManualCommands.HideCommand("WhitePort");
      //    _ManualCommands.HideCommand("ResetBlue");
      //    _ManualCommands.HideCommand("ResetWhite");
      //    _ManualCommands.HideCommand("EnableBlue");
      //    _ManualCommands.HideCommand("EnableWhite");
      //    _ManualCommands.HideCommand("DisableBlue");
      //    _ManualCommands.HideCommand("DisableWhite");
      //}
    }

    protected virtual void InitializeSchematic()
    {
      SplashScreen.Message = Localization.InitializingSchematic;
        _CycleStepsActiveForm = new CycleStepsActiveForm();
        if (Properties.Settings.Default.DualPortSystem)
            _Schematic = new SchematicFormDual();
          else
            _Schematic = new SchematicForm();
    }

    protected virtual void InitializeDatabase()
    {

      // Check Database Status
      SplashScreen.Message = Localization.InitializingDataBase;
      if (!VtiLib.Data.CheckConnStatus()) {
        VtiEvent.Log.WriteError("Error initializing database", VtiEventCatType.Application_Error, Properties.Settings.Default.VtiDataConnectionString);
      }
     
    }

    protected virtual void InitializeIoInterface()
    {
      SplashScreen.Message = Localization.InitializingIOInterface;
      Config.IO.Interface.Start();
      IO.Initialize();
      //IO.DOut.CompHi.Enable();
    }

    protected virtual void InitializeDataPlot()
    {
      // Add analog inputs to the data plot
      SplashScreen.Message = Localization.InitializingDataPlot;
      try {
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueSetPoint);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueSupplyPressure);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueHiSideToolPressure);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueLoSideToolPressure);
        _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartFlow);
        //_DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartCharge);
        //_DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartChargeByCounter);
        _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartChargeInPounds);
        _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartVacuum);
        _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BluePartVacuummTorr);
                

                          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueHiSideCounter);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueLowSideCounter);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueHiSideCounterLimitSignal);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueLowSideCounterLimitSignal);
          _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.CounterOutputs);

          if (Config.Mode.ScaleEnabled.ProcessValue)
          {
              _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.ScaleWeight);
              _DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.BlueNetWeight);
          }
        //_DataPlot[Port.Blue].Traces.AddAnalogSignal(IO.Signals.PartFlow);
      }
      catch {
      }

      _DataPlot[Port.Blue].Settings.LegendVisible = true;
      _DataPlot[Port.Blue].AutoRun1Visible = true;
      _DataPlot[Port.Blue].AutoRun2Visible = false;
      _DataPlot[Port.Blue].Settings.DrawPlotCursorCallouts = true;
      _DataPlot[Port.Blue].LocalDropDownMenus = true;
      if (Properties.Settings.Default.DualPortSystem) {
        _DataPlot[Port.White].AutoRun1Visible = true;
        _DataPlot[Port.White].AutoRun2Visible = false;
        _DataPlot[Port.White].Settings.DrawPlotCursorCallouts = true;
        _DataPlot[Port.White].LocalDropDownMenus = true;

        try {
            _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhiteSupplyPressure);
            _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhiteHiSideToolPressure);

          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhitePartFlow);
          //_DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhitePartCharge);
          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhitePartChargeByCounter);
          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhitePartVacuum);
          //_DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.PartFlow);

          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhiteHiSideCounter);
          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhiteLowSideCounter);
          _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.CounterOutputs);
          if (Config.Mode.ScaleEnabled.ProcessValue)
          {
              _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.ScaleWeight);
              _DataPlot[Port.White].Traces.AddAnalogSignal(IO.Signals.WhiteNetWeight);
          }
        }
        catch {
        }

      }
      VtiEvent.Log.WriteInfo("DataPlot initialization complete", VtiEventCatType.None);
      //// Upgrade the dataplot settings only once after the application has been upgraded
      //if (Properties.Settings.Default.CallUpgradeDataplot)
      //{
      //    DataPlot[Port.Blue].Settings.Upgrade();
      //    if (Properties.Settings.Default.DualPortSystem)
      //        DataPlot[Port.White].Settings.Upgrade();
      //    Properties.Settings.Default.CallUpgradeDataplot = false;
      //    Properties.Settings.Default.Save();
      //}
    }

    protected virtual void InitializeValvesPanel()
    {
      //_ValvesPanel[Port.Blue].AddDigitalSignal(IO.DOut.ChamberTestFine);
      //_ValvesPanel[Port.Blue].AddDigitalSignal(IO.DOut.ChamberRoughIso);
      //_ValvesPanel[Port.Blue].AddDigitalSignal(IO.DOut.ChamberLeak);
      //ValvesPanel[Port.Blue].UpdateValvesPanel();
    }

    protected virtual void InitializeSystemSignals()
    {

      //_SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.PartPressure);
      //_SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.PartFlow);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueSupplyPressure);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueHiSideToolPressure);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueLoSideToolPressure);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartFlow);
      //_SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartCharge);
      //_SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartChargeByCounter);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartChargeInPounds);

      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueHiSideCounter);
      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueLowSideCounter);

        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartVacuummTorr);
        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BluePartVacuum);
            
        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueEvacPressureCDG10);
        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueEvacPressureCDG1000);

        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueHiSideCounterLimitSignal);
        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueLowSideCounterLimitSignal);

        _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.CounterOutputs);

      if (Config.Mode.ScaleEnabled.ProcessValue)
      {
          _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.ScaleWeight);
          _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueStartWeight);
          _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueNetWeight);
      }

      _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.BlueElapsedTime);
            _SystemSignals[Port.Blue].AddAnalogSignal(IO.Signals.RefrigerantPPM);

            _SystemSignals[Port.Blue].DataPlotControl = _DataPlot[Port.Blue];


      if (Properties.Settings.Default.DualPortSystem) {
        //_SystemSignals[Port.White].AddAnalogSignal(IO.Signals.PartPressure);
        //_SystemSignals[Port.White].AddAnalogSignal(IO.Signals.PartFlow);
        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteSupplyPressure);
        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteHiSideToolPressure);
        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhitePartFlow);
        //_SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhitePartCharge);
        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhitePartChargeByCounter);

        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteHiSideCounter);
        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteLowSideCounter);

        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhitePartVacuum);

        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.CounterOutputs);

        if (Config.Mode.ScaleEnabled.ProcessValue)
        {
            _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.ScaleWeight);
            _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteStartWeight);
            _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteNetWeight);
        }

        _SystemSignals[Port.White].AddAnalogSignal(IO.Signals.WhiteElapsedTime);

        _SystemSignals[Port.White].DataPlotControl = _DataPlot[Port.White];
      }
      MyStaticVariables.AnalogHasBeenInitialized = true;
      VtiEvent.Log.WriteInfo("Analog Signal initialization complete", VtiEventCatType.None);

    }

    protected virtual void InitializeBadgeForm()
    {
      SplashScreen.Message = Localization.InitializingBadgeForm;
      _BadgeForm = new BadgeForm();
    }

    protected virtual void InitializeMessageForm()
    {
        SplashScreen.Message = Localization.InitializingMessageForm;
        _MessageForm = new MessageForm();
    }

    protected virtual void InitializeFlowmeterCalibrate()
    {
      SplashScreen.Message = Localization.InitializingFlowmeterCalibrationForm;
      _FlowmeterCalibrate = new FlowmeterCalibrate();
        }
        protected virtual void InitializeSleepDiagnosticsForm()
        {
            SplashScreen.Message = "Loading Sleep Diagnostics Form";
            _SleepDiagnosticsForm = new SleepDiagnosticsForm();
            _SleepDiagnosticsForm.ClearForm();
            _SleepDiagnosticsForm.SetDate(0, "-");
        }

        protected virtual void InitializeZM400()
    {
      //// Initialize Barcode Scanner
      //SplashScreen.Message = "Initializing Zebra ZM400...";
      //try
      //{
      //    _ZM400 = new SerialPort();
      //    Config.Control.ZebraPrinterPort.ProcessValue.CopyTo(ZM400);
      //    zm400Text = string.Empty;
      //    //_ZM400.DataReceived += new SerialDataReceivedEventHandler(ZM400_DataReceived);
      //    if (Config.Mode.ZebraPrinterEnabled.ProcessValue)
      //        _ZM400.Open();
      //}
      //catch (Exception e)
      //{
      //    VtiEvent.Log.WriteError("Error initializing ZM400 printer", VtiEventCatType.Application_Error, e.ToString());
      //    MessageBox.Show("An error occurred initializing the ZM400 printer.  See event log for details.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      //}
      //if (Config.Mode.ZebraPrinterEnabled.ProcessValue)
      //{
      //    Thread.Sleep(500);
      //    if (ZM400.IsOpen == true)
      //    {
      //        // set up the ZM400 label
      //        //String TempFormatNumber = string.Format("{0:0}", Config.Control.SNLabelIntermecNumber.ProcessValue);
      //        ZM400.Write("<STX><ESC>C<ETX>");
      //        ZM400.Write("<STX><ESC>P<ETX>");
      //        //ZM400.Write("<STX>E" + TempFormatNumber + ";F" + TempFormatNumber + ";<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.SNLabelField0Format.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.SNLabelField1Format.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.SNLabelInter1Format.ProcessValue + "<ETX>");
      //        ZM400.Write("<STX>R;<ETX>");
      //        Thread.Sleep(400);
      //        //set up pass label
      //        //TempFormatNumber = string.Format("{0:0}", Config.Control.PassIntermecNumber.ProcessValue);
      //        ZM400.Write("<STX><ESC>C<ETX>");
      //        ZM400.Write("<STX><ESC>P<ETX>");
      //        //ZM400.Write("<STX>E" + TempFormatNumber + ";F" + TempFormatNumber + ";<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.PassSNFieldFormat.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.PassModelFieldFormat.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.PassHeatSealFieldFormat.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.PassWeldNumberFieldFormat.ProcessValue + "<ETX>");
      //        //ZM400.Write("<STX>" + Config.Control.PassPassFieldFormat.ProcessValue + "<ETX>");
      //        ZM400.Write("<STX>R;<ETX>");
      //    }
      //}
    }

    protected virtual void InitializeBarcodeScanner()
    {
            SplashScreen.Message = "Initializing Barcode Scanner...";
            IO.SerialIn.Scanner.SerialPort.DataReceived += BarcodeScanner_DataReceived;

        }

    protected virtual void InitializeScale()
    {
        if (Config.Mode.ScaleEnabled.ProcessValue)
        {
            //Initialize Scale
            SplashScreen.Message = Localization.InitializeScaleComPort;
            try
            {
                _Scale = new SerialPort();
                Config.Control.ScaleCommPort.ProcessValue.CopyTo(Scale);
                _Scale.Open();
            }
            catch (Exception ex)
            {
                VtiEvent.Log.WriteError("Error initializing scale RS 232", VtiEventCatType.Application_Error, ex.ToString());
                MessageBox.Show("An error occurred initializing the scale RS 232.  See event log for details.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }

    protected virtual void InitializeCycleSteps()
    {
      _Cycle = new CycleSteps[2];
      _Cycle[Port.Blue] = new CycleSteps(Port.Blue);
      _Cycle[Port.Blue].Start();
      _Sequences[0][0].BackColor = Properties.Settings.Default.SequenceGoodColor;

      if (Properties.Settings.Default.DualPortSystem) {
        _Cycle[Port.White] = new CycleSteps(Port.White);
        _Cycle[Port.White].Start();
        _Sequences[1][0].BackColor = Properties.Settings.Default.SequenceGoodColor;

        _Cycle[Port.Blue].NewlineAfterPrompt = true;
        _Cycle[Port.White].NewlineAfterPrompt = true;
      }
      MainForm.timerSlidePanels.Interval = 100;
      MainForm.timerSlidePanels.Enabled = true;
    }

    protected virtual void BarcodeScanner_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
            if (useReadExistingForScanner)
            {
                scannerText = IO.SerialIn.Scanner.SerialPort.ReadExisting();
            }
            else
            {
                try
                {
                    scannerText = IO.SerialIn.Scanner.SerialPort.ReadLine();
                    useReadExistingForScanner = false;
                }
                catch
                {
                    scannerText = IO.SerialIn.Scanner.SerialPort.ReadExisting();
                    useReadExistingForScanner = true;
                }
            }
            IO.SerialIn.Scanner.SerialPort.DiscardInBuffer();
            if (!String.IsNullOrEmpty(scannerText) && scannerText != "") {
        // throw away any leading CR or LF
        try {
          while (scannerText.Substring(0, 1) == "\r" || scannerText.Substring(0, 1) == "\n")
            scannerText = scannerText.Substring(1);
        }
        catch (Exception ex) {
          Console.WriteLine(ex.Message);
        }
        // if scannerText contains a CR, process it
        if (scannerText.Contains("\r")) {
          ParseScannerText(scannerText.Substring(0, scannerText.IndexOf("\r")));
          scannerText = string.Empty;
        }
      }
    }

    protected virtual void InitializeMainForm()
    {
      SplashScreen.Message = Localization.InitializingMainForm;

      _RichTextBox = MainForm.ScannerText;
      _RichTextBox.TextChanged += _RichTextBox_TextChanged;

    }

    void _RichTextBox_TextChanged(object sender, EventArgs e)
    {
      String TempText = _RichTextBox.Text.ToUpper();
      if (TempText.Contains("\n")) {
        _RichTextBox.Text = "";
        ParseScannerText(TempText);
      }
    }
    /*
            protected virtual void ZM400_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                zm400Text += _ZM400.ReadExisting();
                if (!String.IsNullOrEmpty(zm400Text))
                {
                    // throw away any leading CR or LF
                    while (zm400Text.Substring(0, 1) == "\r" || zm400Text.Substring(0, 1) == "\n")
                        zm400Text = zm400Text.Substring(1);
                    // if zm400Text contains a CR, process it
                    if (zm400Text.Contains("\r"))
                    {
                        ParseScannerText(zm400Text.Substring(0, zm400Text.IndexOf("\r")));
                        zm400Text = string.Empty;
                    }
                }
            }
    */
    protected virtual void InitializeOperatorForm(bool ShowForm)
    {
        SplashScreen.Message = Localization.InitializingOperatorForm;
        if (Properties.Settings.Default.DualPortSystem) {
            _OpFormDual = new OperatorFormDualNested2(Properties.Settings.Default.PortNames, Properties.Settings.Default.PortColors, _MainForm);
            _OpFormDual.CommandWindowsVisible = false;

            _Prompt = _OpFormDual.Prompt;
            _Sequences = _OpFormDual.Sequences;
            _DataPlot = _OpFormDual.DataPlot;
            _DataPlotDockControl = _OpFormDual.DataPlotDockControl;
            _TestHistory = _OpFormDual.TestHistory;
            _ValvesPanel = _OpFormDual.ValvesPanel;
                    _SystemSignals = _OpFormDual.SystemSignals;


                    if (_OpFormSingle != null) {
                _OpFormSingle.Hide();
                _OpFormSingle.Dispose();
            }

            _Prompt[Port.Blue].DefaultFont = new Font("Arial", 14, FontStyle.Regular);
            _Prompt[Port.White].DefaultFont = new Font("Arial", 14, FontStyle.Regular);

            if (ShowForm) _OpFormDual.Show();
        }
        else 
        {
                //_OpFormSingle = new OperatorFormSingleNested2(Properties.Settings.Default.PortNames[0], Properties.Settings.Default.PortColors[0], _MainForm);
            _OpFormSingle = new OperatorFormSingleNested(Properties.Settings.Default.PortNames[0], Properties.Settings.Default.PortColors[0], _MainForm);
            _OpFormSingle.CommandWindowVisible = false;
            _OpFormSingle.FlowRateVisible = false;
            _OpFormSingle.SignalIndicator.Visible = false;
            _OpFormSingle.SignalIndicator.SemiLog = true;
            _OpFormSingle.SignalIndicator.LinMax = 0.001F;
            _OpFormSingle.SignalIndicator.LinMin = 0.000001F;
            _OpFormSingle.SignalIndicator.LogMinExp = -6;
            _OpFormSingle.SignalIndicator.LogMaxExp = -3;
            _OpFormSingle.SignalIndicator.Caption = "H2 RAW SIGNAL CC/S";
            _OpFormSingle.PortNameVisible = false;

            _Prompt = new RichTextPrompt[1];
            _Prompt[0] = _OpFormSingle.Prompt;
                _Prompt[0].DefaultColor = Color.Black;
                _Prompt[0].BackColor = Color.White;



                _Sequences = new SequenceStepsControl.SequenceStepList[1];
            _Sequences[0] = _OpFormSingle.Sequences;


            _DataPlot = new DataPlotControl[1];
            _DataPlot[0] = _OpFormSingle.DataPlot;

            _DataPlotDockControl = new DataPlotDockControl[1];
            _DataPlotDockControl[0] = _OpFormSingle.DataPlotDockControl;

            _TestHistory = new TestHistoryControl[1];
            _TestHistory[0] = _OpFormSingle.TestHistory;
            _OpFormSingle.TestHistoryDockControl.Show();
               
            _ValvesPanel = new ValvesPanelControl[1];
            _ValvesPanel[0] = _OpFormSingle.ValvesPanel;

            _SystemSignals = new SystemSignalsControl[1];
            _SystemSignals[0] = _OpFormSingle.SystemSignals;

            _SystemSignals[0].SignalCaptionFont = new Font("Arial", 14);//Properties.Settings.Default.SystemSignalCaptionFont;
            _SystemSignals[0].SignalValueFont = new Font("Arial", 14);//Properties.Settings.Default.SystemSignalValueFont;
            _SystemSignals[0].SignalCaptionWidth = 250;//Properties.Settings.Default.SystemSignalPanelWidth;
            _OpFormSingle.SystemSignalPanelWidth = 250;//Properties.Settings.Default.SystemSignalPanelWidth;
            _OpFormSingle.TestHistory.LabelSize = new Size(250, 15);
                _OpFormSingle.TestHistoryColumnCountUndocked = 3;
                _OpFormSingle.TestHistoryRowCountUndocked = 10;
            if (_OpFormDual != null) {
              _OpFormDual.Hide();
              _OpFormDual.Dispose();
            }

            _Prompt[Port.Blue].DefaultFont = new Font("Arial", 14, FontStyle.Regular);

            if (ShowForm) _OpFormSingle.Show();
      }
    }

    /// <summary>
    /// ParseScannerText
    /// Executes the ScannerText if it is a manual command, or takes other action as necessary
    /// </summary>
    /// <param name="ScannerText"></param>
    public virtual void ParseScannerText(string ScannerText)
    {


            #region Section for Manipulating what was scanned
            String TempScannerText;
            String[] TempStringArray;

            TempScannerText = ScannerText.Trim();

            VtiEvent.Log.WriteVerbose("ParseScannerText: " + TempScannerText);

            Boolean ItsA2DScan = TempScannerText.Contains(Microsoft.VisualBasic.Strings.Chr((int)Config.Control.BarcodeDelimiterCode.ProcessValue).ToString());
            //Boolean ItsA2DScan = TempScannerText.Contains("\x1D");
            if (ItsA2DScan)
            {
                //parse out the serial number
                //TempStringArray = TempScannerText.Split("\x1D".ToCharArray());
                TempStringArray = TempScannerText.Split(Microsoft.VisualBasic.Strings.Chr((int)Config.Control.BarcodeDelimiterCode.ProcessValue).ToString().ToCharArray());
                if ((TempStringArray.GetUpperBound(0)) >= (int)Config.Control.SerialNumberLocationIn2DBarcode.ProcessValue)
                {
                    TempScannerText = TempStringArray[((int)Config.Control.SerialNumberLocationIn2DBarcode.ProcessValue) - 1];
                }
                else
                {
                    TempScannerText = "INVALID SCAN";
                }
            }


            # endregion

            # region Section for Analyzing the Scan
            // Check to see if the ScannerText matches the SerialNumberPattern regex
            System.Text.RegularExpressions.Regex rSn = new System.Text.RegularExpressions.Regex(Config.Control.SerialNumberPattern.ProcessValue);
            System.Text.RegularExpressions.Match mSn = rSn.Match(TempScannerText);

            System.Text.RegularExpressions.Regex rMn = new System.Text.RegularExpressions.Regex(Config.Control.ModelNumberPattern.ProcessValue);
            System.Text.RegularExpressions.Match mMn = rMn.Match(TempScannerText);

            //// Check to see if the ScannerText matches the BadgeNumberPattern regex
            System.Text.RegularExpressions.Regex rBadge = new System.Text.RegularExpressions.Regex(Config.Control.BadgeNumberPattern.ProcessValue);
            System.Text.RegularExpressions.Match mBadge = rBadge.Match(TempScannerText);
            # endregion

            # region If its a Manual Command
            if (_ManualCommands.CheckForCommand(TempScannerText))
            {
                _ManualCommands.ExecuteCommand(TempScannerText);
            }
            # endregion
            else
            {
                switch (Config.TestMode)
                {
                    case TestModes.Logoff:
                        # region If Operator Logged Out
                        //Without being logged in, not much can be done. 
                        //This Section could be used if a customer wants to scan a badge to login
                        //When this is done, Remember to stop the login form from appearing on startup and...
                        //place a prompt when Logged off saying that the login can be scanned or login can be scanned
                        //Place Login code here. This was done for Lennox Evac Elevators in Central->Engineering->Lennox->VTI Order 14680
                        if (string.IsNullOrEmpty(Config.OpID))
                        {
                            String tempOpId;
                            String tempLogIn;


                            if (!mBadge.Success)
                            {
                                VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                                //MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                                Machine.Prompt[0].AppendText(Environment.NewLine + Localization.InvalidPassword + ScannerText);

                                return;
                            }

                            ////tempOpId = VtiLib.Data.OpIDfromPassword(KeyPad.Show(Localization.AskPassword, true, 80, 80, 1020, 460));  // tas 3/7/2013 added an overload for show
                            ////tempLogIn = KeyPad.Show(Localization.AskPassword, true, 80, 80, 1020, 460);  // tas 3/7/2013 added an overload for show

                            tempLogIn = TempScannerText;

                            tempOpId = VtiLib.Data.OpIDfromPassword(tempLogIn);

                            if (tempOpId != string.Empty)
                            {
                                Config.OpID = tempOpId;
                                Machine.Test[0].OpID = Config.OpID;
                                (Machine.MainForm.Controls["statusStrip1"] as StatusStrip).Items["OpID"].Text = Config.OpID;
                                VtiEvent.Log.WriteInfo("User '" + Config.OpID + "' logged in.", VtiEventCatType.Login);
                                Config.TestMode = TestModes.Autotest;
                            }
                            else
                            {
                                //check lennox login
                                string Tempsecuritylevel = "";
                                string Tempfirstname = "";
                                string Templastname = "";

                                //Lennox Data Storage
                                //Call Lennox Stored Procedure ProcessStatusUpdate if a coil
                                // Assemble connection string from parameters defined by Jason Hass 3/8/2016
                                // RemoteConnectionString build
                                string strConnectLennox = "";
                                if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                                    strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
                                if (strConnectLennox.Length > 0)
                                    if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
                                strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
                                strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
                                if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
                                if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

                                VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

                                strConnectLennox = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

                                if (strConnectLennox != "")
                                {
                                    try
                                    {

                                        SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                                        SqlCommand cmd = new SqlCommand();


                                        string sCommandText = string.Format("Select securitylevel, firstname, lastname from dbo.security_users where decryptbadgeid like '{0}'", tempLogIn);
                                        cmd.CommandText = sCommandText;
                                        cmd.CommandType = CommandType.Text;
                                        cmd.Connection = sqlConnection2;

                                        sqlConnection2.Open();
                                        SqlDataReader reader = cmd.ExecuteReader();


                                        if (reader.HasRows)
                                        {
                                            reader.Read();
                                            for (int i = 0; i < reader.FieldCount; i++)
                                            {
                                                string TempHeader = reader.GetName(i);
                                                string TempString = reader.GetValue(i).ToString();
                                                if (TempHeader == "securitylevel")
                                                {
                                                    Tempsecuritylevel = TempString;
                                                }
                                                if (TempHeader == "firstname")
                                                {
                                                    Tempfirstname = TempString;
                                                }
                                                if (TempHeader == "lastname")
                                                {
                                                    Templastname = TempString;
                                                }
                                            }

                                        }

                                        sqlConnection2.Close();

                                        if (Tempsecuritylevel != "")
                                        {
                                            Config.OpID = Tempsecuritylevel;
                                            Machine.Test[0].OpID = Tempfirstname + " " + Templastname;
                                            (Machine.MainForm.Controls["statusStrip1"] as StatusStrip).Items["OpID"].Text = Machine.Test[0].OpID;
                                            VtiEvent.Log.WriteInfo("User '" + Machine.Test[0].OpID + "' logged in.", VtiEventCatType.Login);
                                            Config.TestMode = TestModes.Autotest;
                                            IO.DOut.EvacPumpEnable.Enable();

                                        }
                                        else
                                        {

                                            VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                                            //MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                                            Machine.Prompt[0].AppendText(Environment.NewLine + Localization.InvalidPassword + ScannerText);
                                            //this.Login();   // make the user try again

                                        }

                                        //Machine.Test[port].UutRecordID = TempString;
                                    }
                                    catch (Exception ex)
                                    {

                                        Console.WriteLine(ex.Message);
                                        VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                                        //MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                                        Machine.Prompt[0].AppendText(Environment.NewLine + Localization.InvalidPassword + ScannerText);
                                        //MyStaticVariables.MessageBoxInvalidText = TempScannerText;
                                        //Machine.Cycle[0].bShowMessageInvalidPassword = true;
                                        //this.Login();   // make the user try again

                                    }
                                }
                            }
                        }
                        break;
                    #endregion

                    case TestModes.Inquire:
                        #region Allow Scanning Serial Number to Look up in inquire
                        //Does not have code for looking up in inquire Trane Order 14665BR02 Conversion to Quad PD has this code if you want it as a reference
                        Machine.Prompt[0].AppendText("In Inquire Mode, Scan AutoTest" + Environment.NewLine);
                        break;
                    #endregion

                    case TestModes.Autotest:
                        # region If in Autotest

                        if (MyStaticVariables.ReadyToTest) //If the system is starting a test
                        {
                            #region Explaination Of How This Section should be structured
                            //In Autotest, the system is waiting for information to begin the test
                            //Each Piece of information should be assinged a cycle step
                            //This section in parse scanner text should use statements like "else if(WaitingForSerialNumber.State == cyclestepstate.inprocess)" to quickly find out what the system is looking for
                            //In the if statement, the code will either accept the input or indicate via prompt what is is looking for if the input was invalid
                            //After it accepts the input, it will pass the current cyclestep and start the next one
                            //One benefit of doing it this way is the prompts of the cyclestep will handle letting the operator know what the system is looking for
                            //No code needs to be included in the cyclesteps
                            #endregion


                            if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                            {
                                if (!mMn.Success)
                                {
                                    Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID MODEL: " + ScannerText);
                                }
                                else
                                {
                                    if (TempScannerText.Substring(0, 2) == "1Y")
                                    {
                                        //strip the leading 1Y
                                        TempScannerText = TempScannerText.Substring(2);
                                    }

                                    try
                                    {
                                        // Assemble connection string from parameters defined by Jason Hass 3/8/2016
                                        MyStaticVariables.ModelDataResult ModelData = GetModelData(mMn.Value);
                                        TempScannerText = mMn.Value;


                                        if (ModelData.ModelDataIsGood)
                                        {
                                            if (Convert.ToInt32(ModelData.RefrigerantType) == Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue))
                                            {
                                                Machine.Test[0].ModelNumber = mMn.Value;
                                                LoadModelDataIntoEditCycle(ModelData, 0);
                                                Machine.Cycle[0].WaitForAcknowledgeToStart.Start();
                                                return;
                                            }
                                            else
                                            {
                                                Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + ScannerText);
                                            }
                                        }
                                        else
                                        {
                                            //model data is bad, load model name in 0
                                            Machine.Test[0].ModelNumber = TempScannerText;
                                            if (!Config.CurrentModel[0].Load(TempScannerText))
                                            {
                                                //if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                                {
                                                    Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + ScannerText);
                                                }
                                            }
                                            else
                                            {
                                                if (Convert.ToInt32(Config.CurrentModel[0].RefrigerantType.ProcessValue) == Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue))
                                                {
                                                    Machine.Cycle[0].WaitForAcknowledgeToStart.Start();
                                                }
                                                else
                                                {
                                                    Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + ScannerText);
                                                }
                                            }
                                        }
                                    }
                                    catch
                                    { }
                                }
                            }
                            else if (Machine.Cycle[0].WaitForSerialNumber.State == CycleStepState.InProcess)
                            {
                                if (!mSn.Success)
                                {
                                    Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID SERIAL NUMBER: " + ScannerText);
                                }
                                else
                                {
                                    string TempSerialNumber = mSn.Value;
                                    if (TempSerialNumber.Substring(0, 1) == "S")
                                    {
                                        //strip the starting S
                                        Machine.Test[0].SerialNumber = TempSerialNumber.Substring(1);
                                    }
                                    else
                                    {
                                        Machine.Test[0].SerialNumber = TempSerialNumber;
                                    }

                                    if (IO.Signals.BlueSupplyPressure.Value < Config.Pressure.Blue_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                                    {
                                        Machine.Prompt[0].AppendText(Environment.NewLine + "LOW PRESSURE FAULT, CHECK REFRIGERANT SUPPLY" + Environment.NewLine);
                                        return;
                                    }
                                    else
                                    {
                                        string CoilStatus, Message;
                                        float chargeWeight = -1;
                                        string refrigerantType = "";
										if(!Config.Mode.UseNewStatusCheckStoredProcedure.ProcessValue) {
											MyStaticVariables.ProcessSatusResult ProcessStatusResult = ProcessStatus(Machine.Test[0].SerialNumber);
                                            if (ProcessStatusResult.MTL_NBR == "")
                                            {
                                                Machine.Prompt[0].AppendText(Environment.NewLine + "Failed to get model number from serial number" + Environment.NewLine);
                                            }
											CoilStatus = ProcessStatusResult.CoilStatus;
											Message = ProcessStatusResult.Message;
											Machine.Test[0].MTL_NBR = ProcessStatusResult.MTL_NBR;
										} else {
											MyStaticVariables.ProcessSatusResult2 ProcessStatusResult2 = ProcessStatus2(Machine.Test[0].SerialNumber);
                                            if (ProcessStatusResult2.MTL_NBR == "")
                                            {
                                                Machine.Prompt[0].AppendText(Environment.NewLine + "Failed to get model number from serial number" + Environment.NewLine);
                                            }
                                            CoilStatus = ProcessStatusResult2.CoilStatus;
											Message = ProcessStatusResult2.Message;
                                            Machine.Test[0].MTL_NBR = ProcessStatusResult2.MTL_NBR;
                                            chargeWeight = ProcessStatusResult2.CHARGE_WEIGHT;
                                            refrigerantType = ProcessStatusResult2.Refrig_type;
										}


										bool readyToRun = CheckCoilStatusString(CoilStatus);

                                            if ((Config.OpID == "GROUP09") || readyToRun || CoilStatus.Trim() == Config.Control.StatusReadPassValue.ProcessValue.Trim() || CoilStatus.Trim() == Config.Control.StatusWriteFailValue.ProcessValue.Trim())
                                            {
                                                if (Config.Mode.SelectModelFromSerialNumber.ProcessValue || MyStaticVariables.SerialNumberByMessBoxFlag)
                                                {
                                                MyStaticVariables.SerialNumberByMessBoxFlag = false;

                                                    MyStaticVariables.ModelDataResult ModelData = GetModelData(Machine.Test[0].MTL_NBR.Trim());
                                                    Machine.Test[0].ModelNumber = Machine.Test[0].MTL_NBR.Trim();


                                                if(ModelData.ModelDataIsGood) {
                                                    if(Convert.ToInt32(ModelData.RefrigerantType) == Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue)) {
                                                        LoadModelDataIntoEditCycle(ModelData, 0);

                                                        Machine.Cycle[0].WaitForAcknowledgeToStart.Start();
                                                        return;
                                                    } else {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                    }
                                                } else {
                                                    if(!Config.Mode.UseNewStatusCheckStoredProcedure.ProcessValue) {


                                                        //model data is bad, load model name in 0
                                                        if(!Config.CurrentModel[0].Load(Machine.Test[0].ModelNumber)) {
                                                            Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                            if(Properties.Settings.Default.DualPortSystem) {
                                                                if(Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                    Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                                }
                                                            }
                                                        } else {
                                                            //check 0 ref type, match, reset 1
                                                            if(Convert.ToInt32(Config.CurrentModel[0].RefrigerantType.ProcessValue) == Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue)) 
                                                            {
                                                                if(Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                    Machine.Cycle[0].CycleStart();
                                                                }
                                                                if(Properties.Settings.Default.DualPortSystem) {
                                                                    if(Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                        Machine.Test[1].SerialNumber = "";
                                                                        Machine.Cycle[1].Reset.Start();
                                                                    }
                                                                }
                                                                return;
                                                            } 
                                                            else 
                                                            {
                                                                //no match, set 0 to default, check 1 for match
                                                                Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
                                                                if(Properties.Settings.Default.DualPortSystem) {
                                                                    if(Convert.ToInt32(Config.CurrentModel[1].RefrigerantType.ProcessValue) == Convert.ToInt32(Config.Control.WhiteRefrigerantType.ProcessValue)) {
                                                                        if(Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                            Machine.Cycle[1].CycleStart();
                                                                        }
                                                                        if(Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                            Machine.Test[0].SerialNumber = "";
                                                                            Machine.Cycle[0].Reset.Start();
                                                                        }
                                                                        return;
                                                                    } else {
                                                                        if(Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                            Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                                        }
                                                                        if(Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                            Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                                        }
                                                                        return;
                                                                    }
                                                                } else {
                                                                    if(Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess) {
                                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + ScannerText);
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    } else {
                                                        
                                                        if(Convert.ToDouble(refrigerantType) != Convert.ToDouble(Config.Control.BlueRefrigerantType.ProcessValue)) 
                                                        {
															Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + Machine.Test[0].MTL_NBR);
                                                        } 
                                                        else 
                                                        {
															Config.CurrentModel[0].LoadFrom(Config.DefaultModel);
															if(refrigerantType != "") {
																Config.CurrentModel[0].RefrigerantType.ProcessValue = Convert.ToDouble(refrigerantType);
															}
															if(chargeWeight != -1) {
																Config.CurrentModel[0].TotalCharge.ProcessValue = 16.0 * Convert.ToDouble(chargeWeight);
															}
															Machine.Cycle[0].WaitForAcknowledgeToStart.Start();
														}
                                                    }
                                                }
                                                    return;
                                                }
                                                else
                                                {
                                                    // all is good

                                                    Machine.Cycle[0].WaitForSerialNumber.Pass();
                                                    Machine.Cycle[0].WaitForModelSelection.Start();
                                                    return;
                                                }

                                            }
                                            else
                                            {
                                                // An error occured updating the status of the unit,  Call a cycle step to display to notify the operator
                                                if (Config.Control.Language == Languages.English)
                                                {
                                                    if (CoilStatus == Config.Control.StatusWritePassValue.ProcessValue)
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unit Not Ready to Run: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Unit Already Charged at this Station" + Environment.NewLine);
                                                    }
                                                    else if (CoilStatus.Trim() == "P1")
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unit Not Ready to Run: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Unit Must be Run in Evac Station" + Environment.NewLine);
                                                    }
                                                    else if (CoilStatus.Trim() == "F2")
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unit Not Ready to Run: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Unit Failed Evac Station" + Environment.NewLine);
                                                    }
                                                    else
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unit Not Ready to Run: " + Machine.Test[0].SerialNumber + Environment.NewLine + "STATUS: " + CoilStatus + " COMMENT: " + Message.Trim() + Environment.NewLine);

                                                    }
                                                }
                                                else
                                                {
                                                    if (CoilStatus == Config.Control.StatusWritePassValue.ProcessValue)
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unidad cargada: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Esta uniday ya Paso por esta estacion");
                                                    }
                                                    else if (CoilStatus.Trim() == "P1")
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unidad cargada: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Unida No pueda correr en setu estation" + Environment.NewLine + "Estudo:  Faltan datos estacion evacuacion");
                                                    }
                                                    else if (CoilStatus.Trim() == "F2")
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unidad cargada: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Unidad no puede Correr en esta estacion" + Environment.NewLine + "Estado:  Fallo en estacion evacuacian");
                                                    }
                                                    else
                                                    {
                                                        Machine.Prompt[0].AppendText(Environment.NewLine + "Unidad cargada: " + Machine.Test[0].SerialNumber + Environment.NewLine + "Estado: " + CoilStatus);
                                                    }
                                                }
                                                Machine.Test[0].SerialNumber = "";
                                                return;

                                            };

                                    }
                                }
                            }
                        }
                        else // if system is not starting a test - likely in the middle of a test
                        {
                            # region if its not ready to test
                            Machine.Prompt[0].AppendText("System not expecting a Scan" + Environment.NewLine);
                            # endregion
                        }
                        break;
                    #endregion

                    case TestModes.Manual:
                        # region If its in manual

                        Machine.Prompt[0].AppendText("In Manual Mode, Scan AutoTest to continue" + Environment.NewLine);

                        break;
                    #endregion
                    default:
                        break;
                }
            }

    }

        public bool CheckCoilStatusString(string CoilStatusString)
        {
            bool readyToRun = false;
            Char delimiter = ',';
            string[] StatusReadPassValues = Config.Control.StatusReadPassValue.ProcessValue.Split(delimiter);
            foreach (var StatusReadPassValue in StatusReadPassValues)
            {
                if (CoilStatusString.Trim() == StatusReadPassValue) readyToRun = true;
            }
            return readyToRun;
        }
        public static string buildConnectionString()
        {
            string strConnectLennox = "";
            if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            if (strConnectLennox.Length > 0)
                if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;
            return strConnectLennox;
        }

        public void LoadModelDataIntoEditCycle(MyStaticVariables.ModelDataResult ModelData, int port1)
        {
            Config.CurrentModel[port1].LowSideChargePressureCheckEnabled.ProcessValue = false;
            if (ModelData.RefrigerantType != "")
            {
                Config.CurrentModel[port1].RefrigerantType.ProcessValue = Convert.ToDouble(ModelData.RefrigerantType);
            }
            if (ModelData.TotalCharge != "")
            {
                Config.CurrentModel[port1].TotalCharge.ProcessValue = 16.0 * Convert.ToDouble(ModelData.TotalCharge);
            }
            if (ModelData.HiSideChargePercentage != "")
            {
                Config.CurrentModel[port1].HiSidePercentage.ProcessValue = Convert.ToDouble(ModelData.HiSideChargePercentage);
            }

            if (ModelData.RateOfRisePressureCheckSetpoint != "")
            {
                Config.CurrentModel[port1].ROR_Pressure_Check_Pressure_SetPointt.ProcessValue = Convert.ToDouble(ModelData.RateOfRisePressureCheckSetpoint);
            }
            if (ModelData.RORPressureCheckDelay != "")
            {
                Config.CurrentModel[port1].ROR_Pressure_Check_Delay.ProcessValue = Convert.ToDouble(ModelData.RORPressureCheckDelay);
            }

            if (ModelData.InitialEvacDelay != "")
            {
                Config.CurrentModel[port1].Initial_Evac_Delay.ProcessValue = Convert.ToDouble(ModelData.InitialEvacDelay);
            }
            if (ModelData.InitialEvacPressureSetpoint != "")
            {
                Config.CurrentModel[port1].Initial_Evac_Pressure_SetPointt.ProcessValue = Convert.ToDouble(ModelData.InitialEvacPressureSetpoint);
            }

            if (ModelData.FinalEvacPressureSetpoint != "")
            {
                Config.CurrentModel[port1].Final_Evac_Pressure_SetPointt.ProcessValue = Convert.ToDouble(ModelData.FinalEvacPressureSetpoint);
            }
            if (ModelData.FinalEvacDelay != "")
            {
                Config.CurrentModel[port1].Final_Evac_Delay.ProcessValue = Convert.ToDouble(ModelData.FinalEvacDelay);
            }

            if (ModelData.RepeatEvacDelay != "")
            {
                Config.CurrentModel[port1].Repeat_Evac_Delay.ProcessValue = Convert.ToDouble(ModelData.RepeatEvacDelay);
            }
            if (ModelData.MaximumEvacDelay != "")
            {
                Config.CurrentModel[port1].Maximum_Evac_Delay.ProcessValue = Convert.ToDouble(ModelData.MaximumEvacDelay);
            }

            if (ModelData.ToolDrainDelay != "")
            {
                Config.CurrentModel[port1].Tool_Drain_Delay.ProcessValue = Convert.ToDouble(ModelData.ToolDrainDelay);
            }
            if (ModelData.ToolRecoveryTimeout != "")
            {
                Config.CurrentModel[port1].Tool_Recovery_Timeout.ProcessValue = Convert.ToDouble(ModelData.ToolRecoveryTimeout);
            }
            if (ModelData.RecoveryPressureSetpoint != "")
            {
                Config.CurrentModel[port1].Recovery_Pressure_SetPoint.ProcessValue = Convert.ToDouble(ModelData.RecoveryPressureSetpoint);
            }

            if (ModelData.PrechargeUnitCheckPressureSetpoint != "")
            {
                Config.CurrentModel[port1].Precharge_Unit_Check_Pressure_SetPoint.ProcessValue = Convert.ToDouble(ModelData.PrechargeUnitCheckPressureSetpoint);
            }

            if (ModelData.MaximumChargeWeightError != "")
            {
                Config.CurrentModel[port1].MaximumChargeWeightError.ProcessValue = (Convert.ToDouble(ModelData.MaximumChargeWeightError));
            }
            if (ModelData.MinimumChargeWeightError != "")
            {
                Config.CurrentModel[port1].MinimumChargeWeightError.ProcessValue = (Convert.ToDouble(ModelData.MinimumChargeWeightError));
            }

            if (ModelData.LowSideChargePressureCheck != "")
            {
                Config.CurrentModel[port1].LowSideChargePressureCheckEnabled.ProcessValue = Convert.ToBoolean(ModelData.LowSideChargePressureCheck);
                Config.CurrentModel[port1].LowSideChargePressureCheckEnabled.ProcessValue = false;
            }
            if (ModelData.LowSideChargePressureLimit != "")
            {
                Config.CurrentModel[port1].Low_Side_Charge_Pressure_Check_SetPoint.ProcessValue = Convert.ToDouble(ModelData.LowSideChargePressureLimit);
            }

            if (ModelData.PartialChargePercent != "")
            {
                Config.CurrentModel[port1].PartialChargePercent.ProcessValue = Convert.ToDouble(ModelData.PartialChargePercent);
            }
            if (ModelData.UnitType != "")
            {
                Config.CurrentModel[port1].UnitType.ProcessValue = ModelData.UnitType.Trim();
            }
            if (ModelData.PartialChargePressTarget != "")
            {
                Config.CurrentModel[port1].PartialChargePressureTarget.ProcessValue = Convert.ToDouble(ModelData.PartialChargePressTarget);
            }
            //CoilTYpe
            Config.CurrentModel[port1].CoilType.ProcessValue = ModelData.CoilType;

        }

        public MyStaticVariables.ModelDataResult GetModelData(string Model1)
        {
            MyStaticVariables.ModelDataResult Result1 = new MyStaticVariables.ModelDataResult();
            Result1.ModelDataIsGood = false;
            try {
				string strConnectLennox = "";

				strConnectLennox = buildConnectionString();

				VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

				SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);

				SqlCommand cmd = new SqlCommand();

				String sCommandText;
				String TempHeader;
				String TempString;

				sCommandText = "Select RefrigerantType, TotalCharge, HiSideChargePercentage, RORPressureCheckDelay, RateOfRisePressureCheckSetpoint, InitialEvacDelay, InitialEvacPressureSetpoint," + " " +
								"FinalEvacDelay, FinalEvacPressureSetpoint, RepeatEvacDelay, MaximumEvacDelay, ToolDrainDelay, ToolRecoveryTimeout, RecoveryPressureSetpoint, PrechargeUnitCheckPressureSetpoint, MaximumChargeWeightError, MinimumChargeWeightError, LowSideChargePressureCheck, LowSideChargePressureLimit,PartialChargePercent,UnitType,PartialChargePressTarget,CoilType" + " " +
								"from dbo.ModelData" + " " +
							   string.Format("where ModelName = '{0}'", Model1);
				cmd.CommandText = sCommandText;
				cmd.CommandType = CommandType.Text;
				cmd.Connection = sqlConnection1;

				sqlConnection1.Open();

				SqlDataReader reader = cmd.ExecuteReader();

				if(reader.HasRows) {
					reader.Read();
					for(int i = 0; i < reader.FieldCount; i++) {
						TempHeader = reader.GetName(i);
						TempString = reader.GetValue(i).ToString();
						if(TempHeader == "ModelName") {
							Result1.ModelName = TempString;
						}
						if(TempHeader == "RefrigerantType") {
							Result1.RefrigerantType = TempString;
						}
						if(TempHeader == "TotalCharge") {
							Result1.TotalCharge = TempString;
						}
						if(TempHeader == "HiSideChargePercentage") {
							Result1.HiSideChargePercentage = TempString;
						}
						if(TempHeader == "RORPressureCheckDelay") {
							Result1.RORPressureCheckDelay = TempString;
						}
						if(TempHeader == "RateOfRisePressureCheckSetpoint") {
							Result1.RateOfRisePressureCheckSetpoint = TempString;
						}
						if(TempHeader == "InitialEvacDelay") {
							Result1.InitialEvacDelay = TempString;
						}
						if(TempHeader == "InitialEvacPressureSetpoint") {
							Result1.InitialEvacPressureSetpoint = TempString;
						}
						if(TempHeader == "FinalEvacDelay") {
							Result1.FinalEvacDelay = TempString;
						}
						if(TempHeader == "FinalEvacPressureSetpoint") {
							Result1.FinalEvacPressureSetpoint = TempString;
						}
						if(TempHeader == "RepeatEvacDelay") {
							Result1.RepeatEvacDelay = TempString;
						}
						if(TempHeader == "MaximumEvacDelay") {
							Result1.MaximumEvacDelay = TempString;
						}
						if(TempHeader == "ToolDrainDelay") {
							Result1.ToolDrainDelay = TempString;
						}
						if(TempHeader == "ToolRecoveryTimeout") {
							Result1.ToolRecoveryTimeout = TempString;
						}
						if(TempHeader == "RecoveryPressureSetpoint") {
							Result1.RecoveryPressureSetpoint = TempString;
						}
						if(TempHeader == "PrechargeUnitCheckPressureSetpoint") {
							Result1.PrechargeUnitCheckPressureSetpoint = TempString;
						}
						if(TempHeader == "MaximumChargeWeightError") {
							Result1.MaximumChargeWeightError = TempString;
						}
						if(TempHeader == "MinimumChargeWeightError") {
							Result1.MinimumChargeWeightError = TempString;
						}
						if(TempHeader == "LowSideChargePressureCheck") {
							Result1.LowSideChargePressureCheck = TempString;
						}
						if(TempHeader == "LowSideChargePressureLimit") {
							Result1.LowSideChargePressureLimit = TempString;
						}
						if(TempHeader == "PartialChargePercent") {
							Result1.PartialChargePercent = TempString;
						}
						if(TempHeader == "UnitType") {
							Result1.UnitType = TempString.Trim();
						}
						if(TempHeader == "PartialChargePressTarget") {
							Result1.PartialChargePressTarget = TempString;
						}
						if(TempHeader == "CoilType") {
							Result1.CoilType = TempString;
						}
					}
				}
				if(Result1.TotalCharge != "") {
					Result1.ModelDataIsGood = true;
				} else {
					Result1.ModelDataIsGood = false;
				}
				reader.Close();
			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
				// write the error message to the system log
				VtiEvent.Log.WriteError(
				  string.Format("An error reading from remote database (Lennox Model Data Table)"),
				  VtiEventCatType.Database, ex.ToString());
			}
            


            

            return Result1;
        }

		public MyStaticVariables.ProcessSatusResult ProcessStatus(string SN) {
			MyStaticVariables.ProcessSatusResult Result1 = new MyStaticVariables.ProcessSatusResult();
			// Assemble connection string from parameters defined by Jason Hass 3/8/2016

			string strConnectLennox = "";

			strConnectLennox = buildConnectionString();

			VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

			SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);

			// Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
			// "Machine.Test[port].TestResultToSendToRemoteSQLDatabase"
			// The appropriate status write pass value or status write fail value should be the string within the Machine.Test[port]. TestResultToSend ToRemoteSQLDatabase)

			try {
				SqlCommand cmd = new SqlCommand(Config.Control.RemoteConnectionString_LennoxStatusCheckSP.ProcessValue, sqlConnection1);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("SERIAL", SqlDbType.Char);
				cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
				cmd.Parameters["SERIAL"].Value = SN;
				cmd.Parameters["SERIAL"].Size = 18;

				cmd.Parameters.Add("RetCode", SqlDbType.Char);
				cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
				cmd.Parameters["RetCode"].Size = 10;

				cmd.Parameters.Add("RetCode_COMMENT", SqlDbType.Char);
				cmd.Parameters["RetCode_COMMENT"].Direction = ParameterDirection.Output;
				cmd.Parameters["RetCode_COMMENT"].Size = 100;

				cmd.Parameters.Add("MTL_NBR", SqlDbType.Char);
				cmd.Parameters["MTL_NBR"].Direction = ParameterDirection.Output;
				cmd.Parameters["MTL_NBR"].Size = 100;

				//SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
				//returnParameter.Direction = ParameterDirection.Output;

				cmd.Connection = sqlConnection1;

				sqlConnection1.Open();

				cmd.ExecuteNonQuery();

				// return value should match the process status sent if no error occured.
				Result1.CoilStatus = cmd.Parameters["RetCode"].Value.ToString().Trim();
				Result1.Message = cmd.Parameters["RetCode_COMMENT"].Value.ToString().Trim();
				Result1.MTL_NBR = cmd.Parameters["MTL_NBR"].Value.ToString().Trim();

			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
				// write the error message to the system log
				VtiEvent.Log.WriteError(
				  string.Format("An error reading from remote database (Lennox Status Table)"),
				  VtiEventCatType.Database, ex.ToString());

			} finally {
				try {
					// always close the connection
					sqlConnection1.Close();
					//int intCoilStatus = Convert.ToInt32(CoilStatus);
				} catch(Exception ex) {
					Console.WriteLine(ex.Message);
					// write the error message to the system log
				} finally {

				}

			}

			return Result1;
		}

		public static MyStaticVariables.ProcessSatusResult2 ProcessStatus2(string SN) {
			MyStaticVariables.ProcessSatusResult2 Result1 = new MyStaticVariables.ProcessSatusResult2();
			// Assemble connection string from parameters defined by Jason Hass 3/8/2016

			string strConnectLennox = "";

			strConnectLennox = Machine.buildConnectionString();

			VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

			SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);

			// Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
			// "Machine.Test[port].TestResultToSendToRemoteSQLDatabase"
			// The appropriate status write pass value or status write fail value should be the string within the Machine.Test[port]. TestResultToSend ToRemoteSQLDatabase)

			try {
				SqlCommand cmd = new SqlCommand(Config.Control.RemoteConnectionString_LennoxStatusCheckSP.ProcessValue, sqlConnection1);

				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("SERIAL", SqlDbType.Char);
				cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
				cmd.Parameters["SERIAL"].Value = SN;
				cmd.Parameters["SERIAL"].Size = 18;

				cmd.Parameters.Add("RetCode", SqlDbType.Char);
				cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
				cmd.Parameters["RetCode"].Size = 10;

				cmd.Parameters.Add("RetCode_COMMENT", SqlDbType.Char);
				cmd.Parameters["RetCode_COMMENT"].Direction = ParameterDirection.Output;
				cmd.Parameters["RetCode_COMMENT"].Size = 100;

				cmd.Parameters.Add("MTL_NBR", SqlDbType.Char);
				cmd.Parameters["MTL_NBR"].Direction = ParameterDirection.Output;
				cmd.Parameters["MTL_NBR"].Size = 100;

				cmd.Parameters.Add("Charge_Weight", SqlDbType.Float);
				cmd.Parameters["Charge_Weight"].Direction = ParameterDirection.Output;

				cmd.Parameters.Add("Refrig_type", SqlDbType.Char);
				cmd.Parameters["Refrig_type"].Direction = ParameterDirection.Output;
				cmd.Parameters["Refrig_type"].Size = 100;

				cmd.Connection = sqlConnection1;

				sqlConnection1.Open();

				cmd.ExecuteNonQuery();

				// return value should match the process status sent if no error occured.
				Result1.CoilStatus = cmd.Parameters["RetCode"].Value.ToString().Trim();
				Result1.Message = cmd.Parameters["RetCode_COMMENT"].Value.ToString().Trim();
				Result1.MTL_NBR = cmd.Parameters["MTL_NBR"].Value.ToString().Trim();
				float.TryParse(cmd.Parameters["Charge_Weight"].Value.ToString(), out Result1.CHARGE_WEIGHT);
				Result1.Refrig_type = cmd.Parameters["Refrig_type"].Value.ToString().Trim();

			} catch(Exception ex) {
				Console.WriteLine(ex.Message);
				// write the error message to the system log
				VtiEvent.Log.WriteError(
				  string.Format("An error reading from remote database (Lennox Status Table)"),
				  VtiEventCatType.Database, ex.ToString());

			} finally {
				try {
					// always close the connection
					sqlConnection1.Close();
					//int intCoilStatus = Convert.ToInt32(CoilStatus);
				} catch(Exception ex) {
					Console.WriteLine(ex.Message);
					// write the error message to the system log
				} finally {

				}

			}

			return Result1;
		}

		public virtual void ShowTheBadgeForm()
    {
      //DialogResult dr = DialogResult.OK;
      //if (Config.Mode.RequireBadgeNumber.ProcessValue)
      //{
      //    Machine.Badge.textBadge.Text = "";
      //    Machine.Badge.TopMost = true;
      //    Machine.Badge.ActiveControl = Machine.Badge.textBadge;


      //    dr = Machine.Badge.ShowDialog();
      //}
      //if (dr == DialogResult.OK)
      //{
      //    //Machine.Cycle[Port.Blue].SetControlPropertyValue(Machine.MainForm.textBoxOperatorID,
      //    //  "Text", Machine.Badge.textBadge.Text);
      //    //Machine.Cycle[Port.Blue].SetControlPropertyValue(Machine.MainForm.textBoxPrompt1,
      //    //  "Text", "");
      //    if (Machine.Badge.textBadge.Text.Length > 0)
      //    {
      //        MyStaticVariables.BadgeNumber = Machine.Badge.textBadge.Text;
      //    }
      //    else
      //    {
      //        MyStaticVariables.BadgeNumber = "";
      //        //Machine.Cycle[Port.Blue].Reset.Start();
      //    }
      //    //Machine.Cycle[Port.Blue].BlueStart.Start(); // enable barcode scan of serial number

      //    //if (Config.Mode.DisplaySelectModel.ProcessValue)
      //    //{
      //    //  Machine.Cycle[Port.Blue].bDisplaySelectModel = true;
      //    //}
      //    //Machine.Cycle[Port.Blue].CycleTimeUpdate.Start();
      //}
      //else if (dr == DialogResult.Cancel)
      //{
      //    MyStaticVariables.BadgeNumber = "X";
      //    //Machine.Cycle[Port.Blue].Reset.Start();
      //}
      ////if ((dr == DialogResult.OK) && (Machine.Test[Port.Blue].BadgeNumber == "")) 
      ////{
      ////  Machine.Cycle[Port.Blue].SendAudioAlert.Start();

      ////}

      ////

    }

        /// <summary>
        /// ConfigChanged
        /// Called when the user closes the Edit Cycle window to process any
        /// changes to the config that need to have an immediate effect.
        /// </summary>
        public virtual void ConfigChanged(bool serialParamsChanged)
        {
      (_MainForm.Controls["statusStrip1"] as StatusStrip).Items["SystemID"].Text =
          Config.Control.System_ID.ProcessValue.ToString();
      VtiEvent.Log.Level = Config.Mode.Trace_Level;

      //IO.SerialIn.TemperatureControl.SlaveID = (byte)Config.Control.TemperatureControlSlaveID;
      //IO.SerialIn.OverTempControl.SlaveID = (byte)Config.Control.OverTempControlSlaveID;

      //IO.SerialIn.OverTempControl.Alarm1 = VTIWindowsControlLibrary.Classes.IO.SerialIO.SoloTempController.AlarmCodes.AbsoluteValueUpperLimit;
      //IO.SerialIn.OverTempControl.Alarm1HighLimit = (short)(Config.Control.OverTemperatureLimit.ProcessValue * 10);





      if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Select_Model_Number_via_Touch_Screen)
        ManualCommands.ShowCommand("SELECT MODEL");
      else
        ManualCommands.HideCommand("SELECT MODEL");

      // Reload models on setting change
      for (int i = 0; i < (Properties.Settings.Default.DualPortSystem ? 2 : 1); i++) {
        if (Config.CurrentModel[i].Name == "Default")
          Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
        else
          Config.CurrentModel[i].Load(Config.CurrentModel[i].Name);
      }

            if (serialParamsChanged)
            {
                IO.Instance.RestartSerialInDevices();
            }
        }
  }
}
