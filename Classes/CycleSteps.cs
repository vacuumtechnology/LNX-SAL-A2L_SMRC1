using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
//using VTI_EVAC_AND_DUAL_CHARGE.Data;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using Com.SharpZebra.Printing;
using VTIWindowsControlLibrary;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.Configuration;
using VTIWindowsControlLibrary.Classes.CycleSteps;
using VTIWindowsControlLibrary.Classes.Graphing.Util;
using VTIWindowsControlLibrary.Data;
using VTIWindowsControlLibrary.Enums;
using System.Collections;
using System.Reflection;
using Microsoft.VisualBasic;
using TRANE_Precharge.Enums;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes
{
    public partial class CycleSteps : CycleStepsBase
    {

        // Cycle Steps
        public CycleStep ScanSerialNumber, ScanSerialNumber2, ScanModelNumber,
          ReadyForSequence, Reset, ResetComplete, TestAborted,
          PurgeOffPrompt, AreaWarningPrompt, RefrigerantPPMLowWarning, RefrigerantPPMHighWarning,
            Idle, InvalidModelNumber, Disabled,
          SleepDiagnosticPromptToPlug, SleepDiagFirstBasePressCheck, SleepDiagnosticEvacTillTime, SleepDiagSecondBasePressureCheck, SleeptDiagRORtoHosesOnGuns, SleeptDiagRepeatEvac, SleeptDiagRORtoGuns, SleeptDiagRORWithoutGuns, SleepDiagPromptToEnd,
          WaitForSerialNumber,
          TurnOnReversingValve,
          WaitForModelSelection,
          ToolEvacuation,
          WaitToStartToolCheck,
          HiSideToolCheck,
          LowSideToolCheck,
          PrechargedUnitCheck,
          HiSideConnectorCheck,
          LowSideConnectorCheck,
          WaitToStartInitialEvac,
          InitialEvac,
          LateLeakCheckEvac,
          LateLeakCheckROR,
          FinalEvac,
          BasePressureCheck,
          RateOfRise,
          WaitForOtherROR,
          RepeatEvac,
          HoseFillDelay,
          HoseRecoveryDelay,
          HiSideCharge,
          LowSideCharge,
          ToolDrainDelay,
          InsertValveCores,
          WaitForAcknowledgePostCharge,
          ChargeHoseChargeToolRecovery,
          ChargeToolEvacuation,
          RecoverUnit,
          OperatorAcknowledge,
          WaitForPalmButtons,
          AutoDemoCycleStartUp,
          UpdateTime,
          WaitForAcknowledge,
          WeighDisconnectedUnit,
          CheckStoredProcedure,
          WaitForSTART,
          WaitForFINALWEIGHT,
          WeighChargedUnit,
          NotEnergized,
          LowOilWarning,
          HighSideLowOilWarning,
          LowSideLowOilWarning,
          LowRefPressureWarning,
          RecoveryTankFullWarning,
          CycleStartDelay,
          WaitForAcknowledgeToStart,
          SaveToDataBases,
          CloseLiquidServiceValveBeforeCharge,
          ThreeBeeps,
          ATestStep,
            //vvvvvvvvvvvvvvv
            //Diagnositc Sequence
        DiagPrmpt2Plug,
        DiagBasePressChk,
        DiagInitialEvac,
        DiagEvacBothGuns,
        DiagRORBothGuns,
        DiagPrompt2Unplug,
        DiagVenting,
        DiagRORValveChck,
        DiagEvacHoses,
        DiagRORHosing,
        DiagLookWithAlcohol,
        DiagEvacHighGun,
        DiagRORHighGun,
        DiagEvacLowGun,
        DiagRORLowGun,
        DiagPromtCloseSupply,
        DiagRecovSupplyLine,
        DiagPromtCloseRecov,
        DiagEvacAllLines,
        DiagRORLeakyGun,
        DiagOpenSupplyNRecov,
        DiagPromptOpenSupply,
        DiagEvacB4TstChargeValve,
        DiagRORTstChrgValve,
        DiagPrmptOpenRecov,
        DiagEvacB4TstRecovValve,
        DiagRORTstRecovValve;

          //^^^^^^^^^^^^^^^

        public Boolean TestInProgress { get; set; }


        // These local fields can be used in the case of a multi-port system, to
        // access the I/O in a non-port-specific manner.
        protected DigitalInputs.DigitalInputPort din;
        protected DigitalOutputs.DigitalOutputPort dout;
        protected AnalogSignals.AnalogSignalPort signal;
        protected TestInfo test;
        protected int port;
        protected ModelSettings model;

        public bool bUpdateDataPlotSettings, bDisplaySelectModel,bDisplayInquireForm, bDataPlotLegendVisible,bSerialNumberFromSNForm,bHideMessageBox;
        public bool bLoadHiSideCounter, bLoadLowSideCounter;
        public bool bLoadHiSideLimit, bLoadLowSideLimit;
        public bool bEnableHiSideCharge,bEnableLowSideCharge;
        public bool bDisableHiSideCharge,bDisableLowSideCharge;
        public bool bUpdateLanguage;
        public bool bDisplayFlowmeterCalibration;
        public bool bDisplaySleepDiagnosticsForm, bsleepDiagnosticinsertbasePressCheck1Data, bSleepDiagStartDataPlot, bsleepDiagnosticinsertSystemEvacData, bsleepDiagnosticinsertBasePressCheck2Data, bsleepDiagnosticinsertRORtoHosesOnGunsData, bsleepDiagnosticinsertRepeatEvac1Data, bsleepDiagnosticinsertRORtoGunsData, bsleepDiagnosticinsertRepeatEvac2Data, bsleepDiagnosticinsertRORwithoutGunsData, bsleepDiagnosticinsertResult, bsleepDiagnosticinsertDate, bsleepDiagnosticClearForm;
        public bool bHideSleepDiagnosticsForm;
        public bool bManualMode;
        public bool bShowMessageForm,bShowMessageCloseLiquidValve,bShowMessageFinalData,bStartDataPlot,bStopDataPlot,bFinalEvacLimitsForDataPlot,bRORLimitsForDataPlot,bChargeLimitsForDataPlot,bDockTheDataPlot;
        public bool bShowMessageCloseServiceValvesPatialCharge;
        public bool bShowMessageInvalidPassword, bShowMessageInvalidSerialNumber;
        public bool bSetHorizotalSplitter, bSetVerticalSplitter;
        public bool bScannerTextSetFocusOnce;
        public string sSerialNumberFromSNForm;

        public DateTime[] StartTime;
        public DateTime[] CrntTime;


        public CycleSteps(int Port)
            : base(Machine.Prompt[Port], Machine.DataPlot[Port], Machine.TestHistory[Port])
        {
            din = IO.DIn.Port[Port];
            dout = IO.DOut.Port[Port];
            signal = IO.Signals.Port[Port];
            port = Port;
            PortName = Properties.Settings.Default.PortNames[port];
            model = Config.CurrentModel[port];

            MyStaticVariables.thisIsGlobal = true;
            bUpdateDataPlotSettings = false;

            TestAborted = new CycleStep();

            ScanSerialNumber = new CycleStep();
            ScanSerialNumber.Started += new CycleStep.CycleStepEventHandler(ScanSerialNumber_Started);
            ScanSerialNumber.Tick += new CycleStep.CycleStepEventHandler(ScanSerialNumber_Tick);
            //Machine.ManualCommands.BlankTest();
            ScanSerialNumber2 = new CycleStep();
            ScanSerialNumber2.Started += new CycleStep.CycleStepEventHandler(ScanSerialNumber2_Started);
            ScanSerialNumber2.Tick += new CycleStep.CycleStepEventHandler(ScanSerialNumber2_Tick);
            ScanModelNumber = new CycleStep();

            ReadyForSequence = new CycleStep
            {
                TimeDelay = new TimeDelayParameter { ProcessValue = 0.1 }, // must be non-zero so will call OnElapsed()
                Sequence = new SequenceStep(Localization.SeqReadyForSequence)
            };
            
            //ReadyForSequence.Elapsed += new CycleStep.CycleStepEventHandler(ReadyForSequence_Elapsed);



            WaitForPalmButtons = new CycleStep
            {
                Sequence = new SequenceStep(Localization.WaitingForPalmButtons_Prompt),
                Prompt = Localization.WaitingForPalmButtons_Prompt,
            };
            //Machine.Sequences[port].Add(WaitForPalmButtons.Sequence);
            WaitForPalmButtons.Started += new CycleStep.CycleStepEventHandler(WaitForPalmButtons_Started);
            WaitForPalmButtons.Tick += new CycleStep.CycleStepEventHandler(WaitForPalmButtons_Tick);
            WaitForPalmButtons.Passed += new CycleStep.CycleStepEventHandler(WaitForPalmButtons_Passed);

            ATestStep = new CycleStep
            {
                //TimeDelay = new TimeDelayParameter { ProcessValue = 120f },
                //ProcessValue = IO.Signals.BlueManifoldTransducerPressure,
                //MaxSetpoint = new NumericParameter {DisplayName = "AMaxSetPoint", ProcessValue = 100D },
                //DisplayDetailsOnPassFail = true,

                //DisplayElapsedTime = true,
                //Sequence = new SequenceStep (Localization.seqATestStep)
            };
            //Machine.Sequences[0].Add(ATestStep.Sequence);
            ATestStep.Started += new CycleStep.CycleStepEventHandler(ATestStep_Started);
            ATestStep.Tick += new CycleStep.CycleStepEventHandler(ATestStep_Tick);
            ATestStep.Passed += new CycleStep.CycleStepEventHandler(ATestStep_Passed);

            #region Sleep Diagnostic
            SleepDiagnosticPromptToPlug = new CycleStep
            {
                Prompt = "SLEEP - Plug Hoses and Press Acknowledge",

            };
            SleepDiagnosticPromptToPlug.Tick += SleepDiagnosticPromptToPlug_Tick;
            SleepDiagnosticPromptToPlug.Passed += SleepDiagnosticPromptToPlug_Passed;

            SleepDiagFirstBasePressCheck = new CycleStep
            {
                Prompt = "SLEEP - First Base Pressure Check",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleepDiagFirstBasePressCheck.Started += SleepDiagFirstBasePressCheck_Started;
            SleepDiagFirstBasePressCheck.Tick += SleepDiagFirstBasePressCheck_Tick;
            SleepDiagFirstBasePressCheck.Passed += SleepDiagFirstBasePressCheck_Passed;

            SleepDiagnosticEvacTillTime = new CycleStep
            {
                Prompt = "SLEEP - Evac Until Chosen Time",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleepDiagnosticEvacTillTime.Started += SleepDiagnosticEvacTillTime_Started;
            SleepDiagnosticEvacTillTime.Passed += SleepDiagnosticEvacTillTime_Passed;
            SleepDiagnosticEvacTillTime.Tick += SleepDiagnosticEvacTillTime_Tick;
            SleepDiagnosticEvacTillTime.Failed += SleepDiagnosticEvacTillTime_Failed;

            SleepDiagSecondBasePressureCheck = new CycleStep
            {
                Prompt = "SLEEP - Second Base Pressure Check",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleepDiagSecondBasePressureCheck.Started += SleepDiagSecondBasePressureCheck_Started;
            SleepDiagSecondBasePressureCheck.Tick += SleepDiagSecondBasePressureCheck_Tick;
            SleepDiagSecondBasePressureCheck.Passed += SleepDiagSecondBasePressureCheck_Passed;

            SleeptDiagRORtoHosesOnGuns = new CycleStep
            {
                Prompt = "SLEEP - Rate of Rise",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleeptDiagRORtoHosesOnGuns.Started += SleeptDiagRORtoHosesOnGuns_Started;
            SleeptDiagRORtoHosesOnGuns.Tick += SleeptDiagRORtoHosesOnGuns_Tick;
            SleeptDiagRORtoHosesOnGuns.Passed += SleeptDiagRORtoHosesOnGuns_Passed;

            SleeptDiagRepeatEvac = new CycleStep
            {
                Prompt = "SLEEP - Repeat Evacaution",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleeptDiagRepeatEvac.Started += SleeptDiagRepeatEvac_Started;
            SleeptDiagRepeatEvac.Tick += SleeptDiagRepeatEvac_Tick;
            SleeptDiagRepeatEvac.Passed += SleeptDiagRepeatEvac_Passed;

            SleeptDiagRORtoGuns = new CycleStep
            {
                Prompt = "SLEEP - Rate of Rise",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleeptDiagRORtoGuns.Started += SleeptDiagRORtoGuns_Started;
            SleeptDiagRORtoGuns.Tick += SleeptDiagRORtoGuns_Tick;
            SleeptDiagRORtoGuns.Passed += SleeptDiagRORtoGuns_Passed;

            SleeptDiagRORWithoutGuns = new CycleStep
            {
                Prompt = "SLEEP - Rate of Rise",
                DisplayElapsedTime = true,
                WriteUutRecordDetail = false,
            };
            SleeptDiagRORWithoutGuns.Started += SleeptDiagRORWithoutGuns_Started;
            SleeptDiagRORWithoutGuns.Tick += SleeptDiagRORWithoutGuns_Tick;
            SleeptDiagRORWithoutGuns.Passed += SleeptDiagRORWithoutGuns_Passed;

            SleepDiagPromptToEnd = new CycleStep
            {
                Prompt = "Acknowledge to end Diagnostic",
                WriteUutRecordDetail = false,
            };
            SleepDiagPromptToEnd.Started += SleepDiagPromptToEnd_Started;
            SleepDiagPromptToEnd.Tick += SleepDiagPromptToEnd_Tick;
            SleepDiagPromptToEnd.Passed += SleepDiagPromptToEnd_Passed;
            #endregion

            TestAborted = new CycleStep();

            UpdateTime = new CycleStep { };
            UpdateTime.Tick+=UpdateTime_Tick;
            UpdateTime.Started+=UpdateTime_Started;

            InvalidModelNumber = new CycleStep
            {
                Color = Color.Red
            };

            Disabled = new CycleStep();

            AutoDemoCycleStartUp = new CycleStep
            {
                Prompt = Localization.AutoDemoActive_Prompt,
                ValveDelay = new TimeDelayParameter { ProcessValue = 60d },
                DisplayElapsedTime = true
            };
            //AutoDemoCycleStartUp.Started += new CycleStep.CycleStepEventHandler(AutoDemoCycleStartUp_Started);
            AutoDemoCycleStartUp.ValveDelayElapsed += new CycleStep.CycleStepEventHandler(AutoDemoCycleStartUp_ValveDelayElapsed);

            NotEnergized = new CycleStep
            {
                Color = Color.Red,
                Prompt = Localization.MCRPowerError,
            };
            NotEnergized.Started += NotEnergized_Started;
            NotEnergized.Tick += NotEnergized_Tick;

            WaitForAcknowledgePostCharge = new CycleStep
            {
                Color = Color.Red,
                Prompt = Config.Control.PostChargeOperatorInstruction.ProcessValue + " - " + Localization.WaitForAcknowledge_Prompt,
            };
            WaitForAcknowledgePostCharge.Started += WaitForAcknowledgePostCharge_Started;
            WaitForAcknowledgePostCharge.Tick += WaitForAcknowledgePostCharge_Tick;
            WaitForAcknowledgePostCharge.Passed += WaitForAcknowledgePostCharge_Passed;

            WaitForAcknowledge = new CycleStep
            {
                Color = Color.Red,
                Prompt = Localization.WaitForAcknowledge_Prompt,
            };
            WaitForAcknowledge.Started += WaitForAcknowledge_Started;
            WaitForAcknowledge.Tick += WaitForAcknowledge_Tick;
            WaitForAcknowledge.Passed += WaitForAcknowledge_Passed;

            OperatorAcknowledge = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt=Localization.OperatorAcknowledgePrompt,
            };
            OperatorAcknowledge.Started += OperatorAcknowledge_Started;
            OperatorAcknowledge.Tick += OperatorAcknowledge_Tick;
            OperatorAcknowledge.Passed += OperatorAcknowledge_Passed;
            OperatorAcknowledge.Failed += OperatorAcknowledge_Failed;

            ChargeToolEvacuation = new CycleStep
            { // used to evacuate upto the serviced valves on a partial charge TAS 10/15/2019
                Color= Color.DarkBlue,
                Prompt=Localization.ToolEvacuationPrompt,
                TimeDelay=Config.Time.Tool_Evac_Delay,
                
            };
            ChargeToolEvacuation.Started += ChargeToolEvacuation_Started;
            ChargeToolEvacuation.Tick += ChargeToolEvacuation_Tick;
            ChargeToolEvacuation.Elapsed += ChargeToolEvacuation_Elapsed;
            ChargeToolEvacuation.Passed += ChargeToolEvacuation_Passed;
            ChargeToolEvacuation.Failed += ChargeToolEvacuation_Failed;

            ChargeHoseChargeToolRecovery = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt=Localization.ToolRecoveryPrompt,
                TimeDelay=model.Tool_Recovery_Timeout,
                Sequence=new SequenceStep(Localization.SeqChargeHoseChargeToolRecovery),
            };
            ChargeHoseChargeToolRecovery.Started += ChargeHoseChargeToolRecovery_Started;
            ChargeHoseChargeToolRecovery.Tick += ChargeHoseChargeToolRecovery_Tick;
            ChargeHoseChargeToolRecovery.Elapsed += ChargeHoseChargeToolRecovery_Elapsed;
            ChargeHoseChargeToolRecovery.Passed += ChargeHoseChargeToolRecovery_Passed;
            ChargeHoseChargeToolRecovery.Failed += ChargeHoseChargeToolRecovery_Failed;

            TurnOnReversingValve = new CycleStep
            {
                Prompt = "Plug In Reversing Valve",
            };
            TurnOnReversingValve.Started += TurnOnReversingValve_Started;
            TurnOnReversingValve.Tick += TurnOnReversingValve_Tick;
            TurnOnReversingValve.Passed += TurnOnReversingValve_Passed;

            ToolDrainDelay = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt=Localization.ToolDrainPrompt,
                TimeDelay=model.Tool_Drain_Delay,
                Sequence=new SequenceStep(Localization.SeqToolDrain),
            };
            ToolDrainDelay.Started += ToolDrainDelay_Started;
            ToolDrainDelay.Tick += ToolDrainDelay_Tick;
            ToolDrainDelay.Elapsed += ToolDrainDelay_Elapsed;
            ToolDrainDelay.Passed += ToolDrainDelay_Passed;
            ToolDrainDelay.Failed += ToolDrainDelay_Failed;

            LowSideCharge = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt = Localization.LowSideChargePrompt,
                Sequence=new SequenceStep(Localization.SeqChargeLoSide),
                //TimeDelay = new TimeDelayParameter { ProcessValue = 900 },
            };
            LowSideCharge.Started += LowSideCharge_Started;
            LowSideCharge.Tick += LowSideCharge_Tick;
            LowSideCharge.Elapsed += LowSideCharge_Elapsed;
            LowSideCharge.Passed += LowSideCharge_Passed;
            LowSideCharge.Failed += LowSideCharge_Failed;

            HiSideCharge = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt=Localization.HiSideChargePrompt, 
                Sequence=new SequenceStep(Localization.SeqChargeHiSide),
            };
            HiSideCharge.Started += HiSideCharge_Started;
            HiSideCharge.Tick += HiSideCharge_Tick;
            HiSideCharge.Elapsed += HiSideCharge_Elapsed;
            HiSideCharge.Passed += HiSideCharge_Passed;
            HiSideCharge.Failed += HiSideCharge_Failed;

            HoseFillDelay = new CycleStep
            {
                Prompt=Localization.HoseFillPrompt,
                TimeDelay=Config.Time.Hose_Pre_Fill_Delay,
            };
            HoseFillDelay.Started += HoseFillDelay_Started;
            HoseFillDelay.Tick += HoseFillDelay_Tick;
            HoseFillDelay.Elapsed += HoseFillDelay_Elapsed;
            HoseFillDelay.Passed += HoseFillDelay_Passed;

            HoseRecoveryDelay = new CycleStep
            {
                Prompt = "Hose Recovery Delay"
            };
            HoseRecoveryDelay.Tick += HoseRecoveryDelay_Tick;
            HoseRecoveryDelay.Passed += HoseRecoveryDelay_Passed;

            RepeatEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.RepeatEvacPrompt,
                TimeDelay=model.Repeat_Evac_Delay,
            };
            RepeatEvac.Started += RepeatEvac_Started;
            RepeatEvac.Tick += RepeatEvac_Tick;
            RepeatEvac.Elapsed += RepeatEvac_Elapsed;
            RepeatEvac.Passed += RepeatEvac_Passed;
            RepeatEvac.Failed += RepeatEvac_Failed;

            RateOfRise = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.RateOfRiseCheckPrompt,
                TimeDelay=model.ROR_Pressure_Check_Delay,
                Sequence=new SequenceStep(Localization.SeqRORCheck),
            };
            RateOfRise.Started += RateOfRise_Started;
            RateOfRise.Tick += RateOfRise_Tick;
            RateOfRise.Elapsed += RateOfRise_Elapsed;
            RateOfRise.Passed += RateOfRise_Passed;
            RateOfRise.Failed += RateOfRise_Failed;

            BasePressureCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.BasePressureCheckPrompt,
                TimeDelay=Config.Time.Base_Pressure_Check_Delay,
            };
            BasePressureCheck.Started += BasePressureCheck_Started;
            BasePressureCheck.Tick += BasePressureCheck_Tick;
            BasePressureCheck.Elapsed += BasePressureCheck_Elapsed;
            BasePressureCheck.Passed += BasePressureCheck_Passed;
            BasePressureCheck.Failed += BasePressureCheck_Failed;

            FinalEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.FinalEvacPrompt,
                TimeDelay=model.Final_Evac_Delay,
                Sequence=new SequenceStep(Localization.SeqFinalEvac),
            };
            FinalEvac.Started += FinalEvac_Started;
            FinalEvac.Tick += FinalEvac_Tick;
            FinalEvac.Elapsed += FinalEvac_Elapsed;
            FinalEvac.Passed += FinalEvac_Passed;
            FinalEvac.Failed += FinalEvac_Failed;


            LateLeakCheckEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.FinalEvacPrompt,
                TimeDelay = Config.Time.LateLeakCheckEvacDelay,
                Sequence = new SequenceStep(Localization.SeqFinalEvac),
            };
            LateLeakCheckEvac.Started += LateLeakCheckEvac_Started; ;
            LateLeakCheckEvac.Tick += LateLeakCheckEvac_Tick;
            LateLeakCheckEvac.Elapsed += LateLeakCheckEvac_Elapsed;
            LateLeakCheckEvac.Passed += LateLeakCheckEvac_Passed;
            LateLeakCheckEvac.Failed += LateLeakCheckEvac_Failed;

            InitialEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.InitialEvacPrompt,
                //TimeDelay=model.Initial_Evac_Delay,
                TimeDelay=model.Maximum_Evac_Delay,
            };
            InitialEvac.Started += InitialEvac_Started;
            InitialEvac.Tick += InitialEvac_Tick;
            InitialEvac.Elapsed += InitialEvac_Elapsed;
            InitialEvac.Passed += InitialEvac_Passed;
            InitialEvac.Failed += InitialEvac_Failed;

            LowSideConnectorCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt=Localization.LoSideToolConnectorCheckPrompt,   
                TimeDelay=Config.Time.Connector_Check_Timeout,
            };
            LowSideConnectorCheck.Started += LowSideConnectorCheck_Started;
            LowSideConnectorCheck.Tick += LowSideConnectorCheck_Tick;
            LowSideConnectorCheck.Elapsed += LowSideConnectorCheck_Elapsed;
            LowSideConnectorCheck.Passed += LowSideConnectorCheck_Passed;
            LowSideConnectorCheck.Failed += LowSideConnectorCheck_Failed;

            HiSideConnectorCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.HiSideToolConnectorCheckPrompt,
                TimeDelay=Config.Time.Connector_Check_Timeout,
            };
            HiSideConnectorCheck.Started += HiSideConnectorCheck_Started;
            HiSideConnectorCheck.Tick += HiSideConnectorCheck_Tick;
            HiSideConnectorCheck.Elapsed += HiSideConnectorCheck_Elapsed;
            HiSideConnectorCheck.Passed += HiSideConnectorCheck_Passed;
            HiSideConnectorCheck.Failed += HiSideConnectorCheck_Failed;

            PrechargedUnitCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.PrechargedUnitCheckPrompt,
                TimeDelay=Config.Time.Precharged_Unit_Check_Valve_Delay,
            };
            PrechargedUnitCheck.Started += PrechargedUnitCheck_Started;
            PrechargedUnitCheck.Tick += PrechargedUnitCheck_Tick;
            PrechargedUnitCheck.Elapsed += PrechargedUnitCheck_Elapsed;
            PrechargedUnitCheck.Passed += PrechargedUnitCheck_Passed;
            PrechargedUnitCheck.Failed += PrechargedUnitCheck_Failed;

            LowSideToolCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt=Localization.LowSideToolCheckPrompt,
                TimeDelay=Config.Time.Tool_Check_Pressure_Timeout,
                Sequence=new SequenceStep(Localization.SeqLoSideToolCheck),
            };
            LowSideToolCheck.Started += LowSideToolCheck_Started;
            LowSideToolCheck.Tick += LowSideToolCheck_Tick;
            LowSideToolCheck.Elapsed += LowSideToolCheck_Elapsed;
            LowSideToolCheck.Passed += LowSideToolCheck_Passed;
            LowSideToolCheck.Failed += LowSideToolCheck_Failed;

            HiSideToolCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt=Localization.HiSideToolCheckPrompt,
                TimeDelay=Config.Time.Tool_Check_Pressure_Timeout,
                Sequence= new SequenceStep(Localization.SeqHiSideToolCheck),
            };
            HiSideToolCheck.Started += HiSideToolCheck_Started;
            HiSideToolCheck.Tick += HiSideToolCheck_Tick;
            HiSideToolCheck.Elapsed += HiSideToolCheck_Elapsed;
            HiSideToolCheck.Passed += HiSideToolCheck_Passed;
            HiSideToolCheck.Failed += HiSideToolCheck_Failed;

            ToolEvacuation = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.ToolEvacuationPrompt,
            };
            ToolEvacuation.Started += ToolEvacuation_Started;
            ToolEvacuation.Tick += ToolEvacuation_Tick;
            ToolEvacuation.Elapsed += ToolEvacuation_Elapsed;
            ToolEvacuation.Passed += ToolEvacuation_Passed;
            ToolEvacuation.Failed += ToolEvacuation_Failed;


            WaitToStartToolCheck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.WaitToStartToolCheckPrompt,
            };
            WaitToStartToolCheck.Started += WaitToStartToolCheck_Started;
            WaitToStartToolCheck.Tick += WaitToStartToolCheck_Tick;
            WaitToStartToolCheck.Passed += WaitToStartToolCheck_Passed;

            WaitToStartInitialEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),

                Prompt=Localization.WaitToStartInitialEvacPrompt,
            };
            WaitToStartInitialEvac.Started += WaitToStartInitialEvac_Started;
            WaitToStartInitialEvac.Tick += WaitToStartInitialEvac_Tick;
            WaitToStartInitialEvac.Passed += WaitToStartInitialEvac_Passed;

            InsertValveCores = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.InsertValvesCoresPrompt,
                Sequence=new SequenceStep(Localization.SeqInsertValveCores),
            };
            InsertValveCores.Started += InsertValveCores_Started;
            InsertValveCores.Tick += InsertValveCores_Tick;
            InsertValveCores.Passed += InsertValveCores_Passed;

            WaitForOtherROR = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.WaitForOtherRORPrompt,
            };
            WaitForOtherROR.Started += WaitForOtherROR_Started;
            WaitForOtherROR.Tick += WaitForOtherROR_Tick;
            WaitForOtherROR.Passed += WaitForOtherROR_Passed;
            WaitForOtherROR.Failed += WaitForOtherROR_Failed;

            RecoverUnit = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt =Localization.RecoverUnitPrompt,
                TimeDelay=Config.Time.Unit_Recovery_Timeout,
            };
            RecoverUnit.Started += RecoverUnit_Started;
            RecoverUnit.Tick += RecoverUnit_Tick;
            RecoverUnit.Elapsed += RecoverUnit_Elapsed;
            RecoverUnit.Passed += RecoverUnit_Passed;

            WaitForModelSelection = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),
                Prompt=Localization.WaitForModelSelectionPrompt,
            };
            WaitForModelSelection.Started += WaitForModelSelection_Started;
            WaitForModelSelection.Tick += WaitForModelSelection_Tick;
            WaitForModelSelection.Passed += WaitForModelSelection_Passed;
            WaitForModelSelection.Failed += WaitForModelSelection_Failed;

            WaitForSerialNumber = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),

                Prompt = Localization.WaitForSerialNumberTxt,
            };

            LowOilWarning = new CycleStep
            {
                Prompt=Localization.LowOilWarning_Prompt,
                Color=Color.Red,
            };

            HighSideLowOilWarning = new CycleStep
            {
                Prompt = Localization.HighSideLowOilWarning_Prompt,
                Color=Color.Red,
            };

            LowSideLowOilWarning = new CycleStep
            {
                Prompt=Localization.LowSideLowOilWarning_Prompt,
                Color=Color.Red,
            };

            LowRefPressureWarning = new CycleStep
            {
                Prompt=Localization.LowRefPressurePrompt,
                Color=Color.Red,
            };
            LowRefPressureWarning.Started += LowRefPressureWarning_Started;
            LowRefPressureWarning.Tick += LowRefPressureWarning_Tick;
            LowRefPressureWarning.Passed += LowRefPressureWarning_Passed;

            CycleStartDelay = new CycleStep
            {
                TimeDelay = new TimeDelayParameter { ProcessValue = 1 },
            };
            CycleStartDelay.Elapsed += CycleStartDelay_Elapsed;

            RecoveryTankFullWarning = new CycleStep
            {
                Prompt=Localization.RecoveryTankFullWarningPrompt,
                Color=Color.Red,
            };
            RecoveryTankFullWarning.Started += RecoveryTankFullWarning_Started;
            RecoveryTankFullWarning.Tick += RecoveryTankFullWarning_Tick;
            RecoveryTankFullWarning.Passed += RecoveryTankFullWarning_Passed;

            WeighDisconnectedUnit = new CycleStep
            {
                Prompt = Localization.WeighDisconnectedUnit_Prompt,
            };
            WeighDisconnectedUnit.Started += WeighDisconnectedUnit_Started;
            WeighDisconnectedUnit.Tick += WeighDisconnectedUnit_Tick;
            WeighDisconnectedUnit.Passed += WeighDisconnectedUnit_Passed;

            WaitForFINALWEIGHT = new CycleStep
            {
                Prompt = Localization.WaitForFINALWEIGHT_Prompt,
            };
            WaitForFINALWEIGHT.Started += WaitForFINALWEIGHT_Started;
            WaitForFINALWEIGHT.Tick += WaitForFINALWEIGHT_Tick;
            WaitForFINALWEIGHT.Passed += WaitForFINALWEIGHT_Passed;

            WeighChargedUnit = new CycleStep
            {
                Prompt = Localization.WeighChargedUnit_Prompt,
            };
            WeighChargedUnit.Started += WeighChargedUnit_Started;
            WeighChargedUnit.Tick += WeighChargedUnit_Tick;
            WeighChargedUnit.Passed += WeighChargedUnit_Passed;
            WeighChargedUnit.Failed += WeighChargedUnit_Failed;

            WaitForSTART = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.WaitForSTART_Prompt,
            };
            WaitForSTART.Started += WaitForSTART_Started;
            WaitForSTART.Tick += WaitForSTART_Tick;
            WaitForSTART.Passed += WaitForSTART_Passed;

            CheckStoredProcedure = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.CheckStoredProcedure_Prompt,
            };
            CheckStoredProcedure.Started += CheckStoredProcedure_Started;
            CheckStoredProcedure.Tick += CheckStoredProcedure_Tick;
            CheckStoredProcedure.Passed += CheckStoredProcedure_Passed;
            CheckStoredProcedure.Failed += CheckStoredProcedure_Failed;

            WaitForAcknowledgeToStart = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.WaitForAcknowledge_Prompt,
            };
            WaitForAcknowledgeToStart.Started += WaitForAcknowledgeToStart_Started;
            WaitForAcknowledgeToStart.Tick += WaitForAcknowledgeToStart_Tick;
            WaitForAcknowledgeToStart.Passed += WaitForAcknowledgeToStart_Passed;

            SaveToDataBases = new CycleStep
            {
            };
            SaveToDataBases.Started += SaveToDataBases_Started;

            CloseLiquidServiceValveBeforeCharge=new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)(0)),

                Prompt = "CLOSE SUCTION SIDE SERVICE VALVE, PRESS ACKNOWLEDGE TO START CHARGE",
            };
            CloseLiquidServiceValveBeforeCharge.Started+=CloseLiquidServiceValveBeforeCharge_Started;
            CloseLiquidServiceValveBeforeCharge.Tick+=CloseLiquidServiceValveBeforeCharge_Tick;
            CloseLiquidServiceValveBeforeCharge.Passed+=CloseLiquidServiceValveBeforeCharge_Passed;

            DiagPrmpt2Plug = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPrmpt2PlugPrompt,
            };
            DiagPrmpt2Plug.Started += DiagPrmpt2Plug_Started;
            DiagPrmpt2Plug.Tick += DiagPrmpt2Plug_Tick;
            DiagPrmpt2Plug.Passed += DiagPrmpt2Plug_Passed;

            DiagBasePressChk = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagBasePressChkPrompt,
                TimeDelay = Config.Time.DiagBasePressChckDly,
            };
            DiagBasePressChk.Started += DiagBasePressChk_Started;
            DiagBasePressChk.Elapsed +=DiagBasePressChk_Elapsed;
            DiagBasePressChk.Passed += DiagBasePressChk_Passed;
            DiagBasePressChk.Failed += DiagBasePressChk_Failed;

            DiagInitialEvac = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = "Initial Evacuation",
                TimeDelay = Config.Time.DiagInitialEvacDelay,
            };
            DiagInitialEvac.Started += DiagInitialEvac_Started;
            DiagInitialEvac.Elapsed += DiagInitialEvac_Elapsed;
            DiagInitialEvac.Passed += DiagInitialEvac_Passed;

            DiagEvacBothGuns = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacBothGunsPrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime
            };
            DiagEvacBothGuns.Started += DiagEvacBothGuns_Started;
            DiagEvacBothGuns.Tick += DiagEvacBothGuns_Tick;
            DiagEvacBothGuns.Elapsed += DiagEvacBothGuns_Elapsed;
            DiagEvacBothGuns.Passed += DiagEvacBothGuns_Passed;
            DiagEvacBothGuns.Failed += DiagEvacBothGuns_Failed;

            DiagRORBothGuns = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORBothGunsPrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORBothGuns.Started += DiagRORBothGuns_Started;
            DiagRORBothGuns.Elapsed += DiagRORBothGuns_Elapsed;
            DiagRORBothGuns.Passed += DiagRORBothGuns_Passed;
            DiagRORBothGuns.Failed += DiagRORBothGuns_Failed;

            DiagPrompt2Unplug = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPrompt2UnplugPrompt,
            };
            DiagPrompt2Unplug.Started += DiagPrompt2Unplug_Started;
            DiagPrompt2Unplug.Tick += DiagPrompt2Unplug_Tick;
            DiagPrompt2Unplug.Passed += DiagPrompt2Unplug_Passed;

            DiagVenting = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagVentingPrompt,
                TimeDelay = Config.Time.DiagVentingDelay,
            };
            DiagVenting.Elapsed += DiagVenting_Elapsed;
            DiagVenting.Passed += DiagVenting_Passed;
            DiagVenting.Failed += DiagVenting_Failed;

            DiagRORValveChck = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORValveChckPrompt,
                TimeDelay = Config.Time.DiagRORValveChckDelay,
            };
            DiagRORValveChck.Elapsed += DiagRORValveChck_Elapsed;
            DiagRORValveChck.Passed += DiagRORValveChck_Passed;
            DiagRORValveChck.Failed += DiagRORValveChck_Failed;

            DiagEvacHoses = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacHosesPrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacHoses.Started += DiagEvacHoses_Started;
            DiagEvacHoses.Tick += DiagEvacHoses_Tick;
            DiagEvacHoses.Elapsed += DiagEvacHoses_Elapsed;
            DiagEvacHoses.Passed += DiagEvacHoses_Passed;
            DiagEvacHoses.Failed += DiagEvacHoses_Failed;

            DiagRORHosing = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORHosingPrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORHosing.Started += DiagRORHosing_Started;
            DiagRORHosing.Elapsed += DiagRORHosing_Elapsed;
            DiagRORHosing.Passed += DiagRORHosing_Passed;
            DiagRORHosing.Failed += DiagRORHosing_Failed;

            DiagLookWithAlcohol = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagLookWithAlcoholPrompt,
            };
            DiagLookWithAlcohol.Started += DiagLookWithAlcohol_Started;
            DiagLookWithAlcohol.Tick += DiagLookWithAlcohol_Tick;
            DiagLookWithAlcohol.Failed += DiagLookWithAlcohol_Failed;

            DiagEvacHighGun = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacHighGunPrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacHighGun.Started += DiagEvacHighGun_Started;
            DiagEvacHighGun.Tick += DiagEvacHighGun_Tick;
            DiagEvacHighGun.Elapsed += DiagEvacHighGun_Elapsed;
            DiagEvacHighGun.Passed += DiagEvacHighGun_Passed;
            DiagEvacHighGun.Failed += DiagEvacHighGun_Failed;

            DiagRORHighGun = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORHighGunPrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORHighGun.Started += DiagRORHighGun_Started;
            DiagRORHighGun.Elapsed += DiagRORHighGun_Elapsed;
            DiagRORHighGun.Passed += DiagRORHighGun_Passed;
            DiagRORHighGun.Failed += DiagRORHighGun_Failed;

            DiagEvacLowGun = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacLowGunPrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacLowGun.Started += DiagEvacLowGun_Started;
            DiagEvacLowGun.Tick += DiagEvacLowGun_Tick;
            DiagEvacLowGun.Elapsed += DiagEvacLowGun_Elapsed;
            DiagEvacLowGun.Passed += DiagEvacLowGun_Passed;
            DiagEvacLowGun.Failed += DiagEvacLowGun_Failed;

            DiagRORLowGun = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORLowGunPrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORLowGun.Started += DiagRORLowGun_Started;
            DiagRORLowGun.Elapsed += DiagRORLowGun_Elapsed;
            DiagRORLowGun.Passed += DiagRORLowGun_Passed;
            DiagRORLowGun.Failed += DiagRORLowGun_Failed;

            DiagPromtCloseSupply = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPromtCloseSupplyPrompt,
            };
            DiagPromtCloseSupply.Started += DiagPromtCloseSupply_Started;
            DiagPromtCloseSupply.Tick += DiagPromtCloseSupply_Tick;
            DiagPromtCloseSupply.Passed += DiagPromtCloseSupply_Passed;

            DiagRecovSupplyLine = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRecovSupplyLinePrompt,
                TimeDelay = Config.Time.DiagMaxRcvrSupplyDly,
            };
            DiagRecovSupplyLine.Started += DiagRecovSupplyLine_Started;
            DiagRecovSupplyLine.Tick += DiagRecovSupplyLine_Tick;
            DiagRecovSupplyLine.Elapsed += DiagRecovSupplyLine_Elapsed;
            DiagRecovSupplyLine.Passed += DiagRecovSupplyLine_Passed;
            DiagRecovSupplyLine.Failed += DiagRecovSupplyLine_Failed;

            DiagPromtCloseRecov = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPromtCloseRecovPrompt,
            };
            DiagPromtCloseRecov.Started += DiagPromtCloseRecov_Started;
            DiagPromtCloseRecov.Tick += DiagPromtCloseRecov_Tick;
            DiagPromtCloseRecov.Passed += DiagPromtCloseRecov_Passed;

            DiagEvacAllLines = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacAllLinesPrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacAllLines.Started += DiagEvacAllLines_Started;
            DiagEvacAllLines.Tick += DiagEvacAllLines_Tick;
            DiagEvacAllLines.Elapsed += DiagEvacAllLines_Elapsed;
            DiagEvacAllLines.Passed += DiagEvacAllLines_Passed;
            DiagEvacAllLines.Failed += DiagEvacAllLines_Failed;

            DiagRORLeakyGun = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORLeakyGunPrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORLeakyGun.Started += DiagRORLeakyGun_Started;
            DiagRORLeakyGun.Elapsed += DiagRORLeakyGun_Elapsed;
            DiagRORLeakyGun.Passed += DiagRORLeakyGun_Passed;
            DiagRORLeakyGun.Failed += DiagRORLeakyGun_Failed;

            DiagOpenSupplyNRecov = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagOpenSupplyNRecovPrompt,
            };
            DiagOpenSupplyNRecov.Started += DiagOpenSupplyNRecov_Started;
            DiagOpenSupplyNRecov.Tick += DiagOpenSupplyNRecov_Tick;
            DiagOpenSupplyNRecov.Passed += DiagOpenSupplyNRecov_Passed;

            DiagPromptOpenSupply = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPromptOpenSupplyPrompt,
            };
            DiagPromptOpenSupply.Started += DiagPromptOpenSupply_Started;
            DiagPromptOpenSupply.Tick += DiagPromptOpenSupply_Tick;
            DiagPromptOpenSupply.Passed += DiagPromptOpenSupply_Passed;

            DiagEvacB4TstChargeValve = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacB4TstChargeValvePrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacB4TstChargeValve.Started += DiagEvacB4TstChargeValve_Started;
            DiagEvacB4TstChargeValve.Tick += DiagEvacB4TstChargeValve_Tick;
            DiagEvacB4TstChargeValve.Elapsed += DiagEvacB4TstChargeValve_Elapsed;
            DiagEvacB4TstChargeValve.Passed += DiagEvacB4TstChargeValve_Passed;
            DiagEvacB4TstChargeValve.Failed += DiagEvacB4TstChargeValve_Failed;

            DiagRORTstChrgValve = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORTstChrgValvePrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORTstChrgValve.Started += DiagRORTstChrgValve_Started;
            DiagRORTstChrgValve.Elapsed += DiagRORTstChrgValve_Elapsed;
            DiagRORTstChrgValve.Passed += DiagRORTstChrgValve_Passed;
            DiagRORTstChrgValve.Failed += DiagRORTstChrgValve_Failed;

            DiagPrmptOpenRecov = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagPrmptOpenRecovPrompt,
            };
            DiagPrmptOpenRecov.Started += DiagPrmptOpenRecov_Started;
            DiagPrmptOpenRecov.Tick += DiagPrmptOpenRecov_Tick;
            DiagPrmptOpenRecov.Passed += DiagPrmptOpenRecov_Passed;

            DiagEvacB4TstRecovValve = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagEvacB4TstRecovValvePrompt,
                TimeDelay = Config.Time.DiagEvacMaxTime,
            };
            DiagEvacB4TstRecovValve.Started += DiagEvacB4TstRecovValve_Started;
            DiagEvacB4TstRecovValve.Tick += DiagEvacB4TstRecovValve_Tick;
            DiagEvacB4TstRecovValve.Elapsed += DiagEvacB4TstRecovValve_Elapsed;
            DiagEvacB4TstRecovValve.Passed += DiagEvacB4TstRecovValve_Passed;
            DiagEvacB4TstRecovValve.Failed += DiagEvacB4TstRecovValve_Failed;

            DiagRORTstRecovValve = new CycleStep
            {
                Color = Color.DarkBlue,
                Prompt = Localization.DiagRORTstRecovValvePrompt,
                TimeDelay = Config.Time.DiagRORDelay,
            };
            DiagRORTstRecovValve.Started += DiagRORTstRecovValve_Started;
            DiagRORTstRecovValve.Elapsed += DiagRORTstRecovValve_Elapsed;
            DiagRORTstRecovValve.Passed += DiagRORTstRecovValve_Passed;
            DiagRORTstRecovValve.Failed += DiagRORTstRecovValve_Failed;

            ThreeBeeps = new CycleStep
            {

            };
            ThreeBeeps.Started += ThreeBeeps_Started;
            ThreeBeeps.Tick += ThreeBeeps_Tick;
            ThreeBeeps.Passed += ThreeBeeps_Passed;


            PurgeOffPrompt = new CycleStep
            {
                Prompt = "Purge OFF, Electrical Cabinets Unprotected",
                Color = Color.Red,
            };

            AreaWarningPrompt = new CycleStep
            {
                Prompt = "Area Warning!",
                Color = Color.Red,
            };
            RefrigerantPPMHighWarning = new CycleStep
            {
                Prompt = "ADVERTENCIA: La concentración de refrigerante supera el límite alto. Tome las medidas adecuadas - WARNING: Refrigerant Concentration Past High Limit. Take appropriate Action.",
                Color = Color.Red,
            };
            RefrigerantPPMLowWarning = new CycleStep
            {
                Prompt = "La concentración de refrigerante ha superado el límite bajo. Tome las medidas adecuad - Refrigerant Concentration Past Low Limit. Take appropriate Action",
                Color = Color.Red,
            };


            Machine.Sequences[port].Add(ReadyForSequence.Sequence);
            Machine.Sequences[port].Add(HiSideToolCheck.Sequence);
            Machine.Sequences[port].Add(LowSideToolCheck.Sequence);
            Machine.Sequences[port].Add(FinalEvac.Sequence);
            Machine.Sequences[port].Add(RateOfRise.Sequence);
            Machine.Sequences[port].Add(HiSideCharge.Sequence);
            Machine.Sequences[port].Add(LowSideCharge.Sequence);            
            Machine.Sequences[port].Add(ToolDrainDelay.Sequence);
            Machine.Sequences[port].Add(InsertValveCores.Sequence);
            Machine.Sequences[port].Add(ChargeHoseChargeToolRecovery.Sequence);

            #region Reset/Idle/Standby Steps Class Declarations

            Reset = new CycleStep();
            Reset.Started += new CycleStep.CycleStepEventHandler(Reset_Started);

            Idle = new CycleStep
            {
                Color = Color.DarkBlue,
                Font = new Font ("Microsoft Sans Serif", 20f, System.Drawing.FontStyle.Bold,System.Drawing.GraphicsUnit.Point,(byte)(0)),
            };
            Idle.Started += new CycleStep.CycleStepEventHandler(Idle_Started);
            Idle.Tick += new CycleStep.CycleStepEventHandler(Idle_Tick);

            ResetComplete = new CycleStep();
            ResetComplete.Started += new CycleStep.CycleStepEventHandler(ResetComplete_Started);

            
            #endregion


            StartTime = new DateTime[2];
            CrntTime = new DateTime[2];

            this.Init();
            // End 
        }

        private void SleepDiagPromptToEnd_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Reset.Start();
        }

        private void SleepDiagPromptToEnd_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.DIn.Acknowledge.Value)
            {
                step.Pass();
            }
        }

        private void SleepDiagPromptToEnd_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            if (Config.Mode.SleepDiagnosticCheckHoseWhips.ProcessValue)
            {
                dout.HiSideToolStem.Enable();
                dout.LoSideToolStem.Enable();
            }
            else
            {
                dout.HiSideToolStem.Disable();
                dout.LoSideToolStem.Disable();
            }

            dout.RateOfRiseValve.Enable();
            dout.UnitEvac.Enable();

            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }
        void WriteSleepResultsToDatabase(string TestResult)
        {
            string strConnectVTIToLennox = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;


            if (strConnectVTIToLennox != "")
            {
                try
                {
                    SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
                    SqlCommand cmd = new SqlCommand();

                    Config.Control.TestResultTableName.ProcessValue = "UutRecords";
                    // Set the test result and write the records
                    String strSqlCmd =
                    "insert into UutRecords " +
                    "(SerialNo, ModelNo, DateTime, SystemID, OpID, TestType, TestResult, TestPort) " +
                    "values('" + Machine.Test[port].SerialNumber + "', '" +
                     Machine.Test[port].ModelNumber + "', '" +
                     DateTime.Now.ToString() + "', '" +
                     Config.Control.System_ID.ProcessValue + "', '" +
                     Machine.Test[port].OpID + "', '" +
                     "Diagnostic" + "', '" +
                     Machine.Test[port].TestResult + "', '" +
                     "BLUE PORT" + "')";

                    Console.WriteLine(strSqlCmd);

                    //fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                    cmd.CommandText = strSqlCmd + " SELECT SCOPE_IDENTITY()";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection2;
                    sqlConnection2.Open();
                    //cmd.ExecuteNonQuery();
                    Machine.Test[port].UutRecordID = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
                    VtiEvent.Log.WriteInfo(
                            string.Format("UUTRecordID = " + Machine.Test[port].UutRecordID),
                                    VtiEventCatType.Database);

                    sqlConnection2.Close();

                    if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                    {
                        fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                    }
                }
                catch (Exception Ex)
                {
                    VtiEvent.Log.WriteError(Ex.Message);
                }


                foreach (MyStaticVariables.UUTRecordDetailToWrite record1 in MyStaticVariables.BlueUUTRecordsToWrite)
                {
                    try
                    {
                        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                        //SqlCommand cmd = new SqlCommand();
                        Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                        // Set the test result and write the records
                        String strSqlCmd =
                "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
                //"insert into dbo.TestResult "+
                "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
                "values('" + Machine.Test[port].UutRecordID + "', '" +
                 record1.DateTime1.ToString() + "', '" +
                 record1.Test1 + "', '" +
                 record1.Result1 + "', '" +
                 record1.ValueName1 + "', '" +
                 record1.value1 + "', '" +
                 record1.MinSetpointName1 + "', '" +
                 record1.MinSetpoint1 + "', '" +
                 record1.MaxSetpointName1 + "', '" +
                 record1.MaxSetpoint1 + "', '" +
                 record1.Units1 + "', '" +
                 record1.ElapsedTime1 + "')";
                        Console.WriteLine(strSqlCmd);

                        fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                        if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                        {
                            fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                        }


                        //cmd.CommandText = strSqlCmd;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Connection = sqlConnection2;

                        //sqlConnection2.Open();

                        //cmd.ExecuteNonQuery();


                        //sqlConnection2.Close();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                        VtiEvent.Log.WriteError(Ex.Message);
                    }
                }
            }
        }
        private void SleeptDiagRORWithoutGuns_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsCalcStartTime, "RORWithoutGuns", "Complete", "ROR Start Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR3InitialPressure, 0, "", 0, "", "mtorr", 105);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsCalcEndTime, "RORWithoutGuns", "Complete", "ROR End Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR3FinalPressure, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsCalcEndTime, "RORWithoutGuns", "Complete", "ROR", MyStaticVariables.SleepDiagnosticVar[port].ror3, 0, "", 0, "", "mtorr/min", step.ElapsedTime.TotalSeconds);

            if (MyStaticVariables.SleepDiagnosticVar[port].Passed)
            {
                MyStaticVariables.SleepDiagnosticVar[port].Result = "PASS";
                WriteSleepResultsToDatabase("PASS");

                Machine.TestHistory[port].AddEntry(Machine.Test[port].SerialNumber + ": " + "PASS", Color.Black, Color.LawnGreen);
            }
            else
            {
                MyStaticVariables.SleepDiagnosticVar[port].Result = "FAIL";

                WriteSleepResultsToDatabase("FAIL");
                Machine.TestHistory[port].AddEntry(Machine.Test[port].SerialNumber + ": " + "FAIL", Color.Yellow, Color.Red);
            }

            bsleepDiagnosticinsertRORwithoutGunsData = true;
            bsleepDiagnosticinsertResult = true;
            bsleepDiagnosticinsertDate = true;
            SleepDiagPromptToEnd.Start();

        }

        private void SleeptDiagRORWithoutGuns_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double settle = Config.Time.Diag_Test_Settle_Delay.ProcessValue;
            double rorDelay = Config.Time.Diag_Test_ROR_Delay.ProcessValue;
            if (step.ElapsedTime.TotalSeconds < settle)
            {
                MyStaticVariables.SleepDiagnosticVar[port].ROR3InitialPressure = signal.PartVacuummTorr.Value;
                MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsCalcStartTime = DateTime.Now;
            }
            else
            {
                if (step.ElapsedTime.TotalSeconds > rorDelay + settle)
                {
                    MyStaticVariables.SleepDiagnosticVar[port].ROR3FinalPressure = signal.PartVacuummTorr.Value;
                    MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsCalcEndTime = DateTime.Now;
                    step.Pass();
                }
            }
        }

        private void SleeptDiagRORWithoutGuns_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].RORWithoutGunsStarted = true;
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();
            dout.LoSideToolStem.Disable();

            dout.RateOfRiseValve.Disable();
            dout.UnitEvac.Enable();

            dout.HiSideEvac.Disable();
            dout.LoSideEvac.Disable();
        }

        private void SleeptDiagRORtoGuns_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            bsleepDiagnosticinsertRORtoGunsData = true;
            bsleepDiagnosticinsertDate = true;

            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToGunsCalcStartTime, "RORToGuns", "Complete", "ROR Start Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR2InitialPressure, 0, "", 0, "", "mtorr", 105);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToGunsCalcEndTime, "RORToToGuns", "Complete", "ROR End Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR2FinalPressure, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToGunsCalcEndTime, "RORToToGuns", "Complete", "ROR", MyStaticVariables.SleepDiagnosticVar[port].ror2, 0, "", 0, "", "mtorr/min", step.ElapsedTime.TotalSeconds);
            SleeptDiagRepeatEvac.Start();
        }

        private void SleeptDiagRORtoGuns_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double settle = Config.Time.Diag_Test_Settle_Delay.ProcessValue;
            double rorDelay = Config.Time.Diag_Test_ROR_Delay.ProcessValue;
            if (step.ElapsedTime.TotalSeconds < settle)
            {
                MyStaticVariables.SleepDiagnosticVar[port].ROR2InitialPressure = signal.PartVacuummTorr.Value;
                MyStaticVariables.SleepDiagnosticVar[port].RORToGunsCalcStartTime = DateTime.Now;
            }
            else
            {
                if (step.ElapsedTime.TotalSeconds > rorDelay + settle)
                {
                    MyStaticVariables.SleepDiagnosticVar[port].ROR2FinalPressure = signal.PartVacuummTorr.Value;
                    MyStaticVariables.SleepDiagnosticVar[port].RORToGunsCalcEndTime = DateTime.Now;
                    step.Pass();
                }
            }
        }

        private void SleeptDiagRORtoGuns_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            MyStaticVariables.SleepDiagnosticVar[port].RORToGunsStarted = true;
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();
            dout.LoSideToolStem.Disable();

            dout.RateOfRiseValve.Disable();
            dout.UnitEvac.Enable();

            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        private void SleeptDiagRepeatEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.SleepDiagnosticVar[port].RORToGunsStarted)
            {
                MyStaticVariables.SleepDiagnosticVar[port].RepeatEvac2Pressure = signal.PartVacuummTorr.Value;
                MyStaticVariables.SleepDiagnosticVar[port].RepeatEvac2Time = step.ElapsedTime.TotalSeconds;

                bsleepDiagnosticinsertRepeatEvac2Data = true;
                bsleepDiagnosticinsertDate = true;
                AddUutRecordDetail(DateTime.Now, "RepeatEvac1", "Complete", "Evac Pressure", signal.PartVacuummTorr.Value, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
                SleeptDiagRORWithoutGuns.Start();
            }
            else
            {
                MyStaticVariables.SleepDiagnosticVar[port].RepeatEvac1Pressure = signal.PartVacuummTorr.Value;
                MyStaticVariables.SleepDiagnosticVar[port].RepeatEvac1Time = step.ElapsedTime.TotalSeconds;
                bsleepDiagnosticinsertRepeatEvac1Data = true;
                bsleepDiagnosticinsertDate = true;
                AddUutRecordDetail(DateTime.Now, "RepeatEvac2", "Complete", "Evac Pressure", signal.PartVacuummTorr.Value, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
                SleeptDiagRORtoGuns.Start();
            }
        }

        private void SleeptDiagRepeatEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 120) step.Pass();
        }

        private void SleeptDiagRepeatEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();
            dout.LoSideToolStem.Disable();

            dout.RateOfRiseValve.Enable();
            dout.UnitEvac.Enable();

            if (!MyStaticVariables.SleepDiagnosticVar[port].RORToGunsStarted)
            {
                dout.HiSideEvac.Enable();
                dout.LoSideEvac.Enable();
            }
            else
            {
                dout.HiSideEvac.Disable();
                dout.LoSideEvac.Disable();
            }
        }

        private void SleeptDiagRORtoHosesOnGuns_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            SleeptDiagRepeatEvac.Start();

            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsCalcStartTime, "RORToHosesOnGuns", "Complete", "ROR Start Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR1InitialPressure, 0, "", 0, "", "mtorr", 60);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsCalcEndTime, "RORToHosesOnGuns", "Complete", "ROR End Pressure", MyStaticVariables.SleepDiagnosticVar[port].ROR1FinalPressure, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            AddUutRecordDetail(MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsCalcEndTime, "RORToHosesOnGuns", "Complete", "ROR", MyStaticVariables.SleepDiagnosticVar[port].ror1, 0, "", 0, "", "mtorr/min", step.ElapsedTime.TotalSeconds);
            bsleepDiagnosticinsertRORtoHosesOnGunsData = true;
            bsleepDiagnosticinsertDate = true;
        }

        private void SleeptDiagRORtoHosesOnGuns_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double settle = Config.Time.Diag_Test_Settle_Delay.ProcessValue;
            double rorDelay = Config.Time.Diag_Test_ROR_Delay.ProcessValue;
            if (step.ElapsedTime.TotalSeconds < settle)
            {
                MyStaticVariables.SleepDiagnosticVar[port].ROR1InitialPressure = signal.PartVacuummTorr.Value;
                MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsCalcStartTime = DateTime.Now;
            }
            else
            {
                if (step.ElapsedTime.TotalSeconds > rorDelay + settle)
                {
                    MyStaticVariables.SleepDiagnosticVar[port].ROR1FinalPressure = signal.PartVacuummTorr.Value;
                    MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsCalcEndTime = DateTime.Now;
                    step.Pass();
                }
            }
        }

        private void SleeptDiagRORtoHosesOnGuns_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].RORToHoseOnGunsStarted = true;
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Enable();
            dout.LoSideToolStem.Enable();

            dout.RateOfRiseValve.Disable();
            dout.UnitEvac.Enable();

            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        private void SleepDiagSecondBasePressureCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].FinalBasePressureCheckPressure = signal.PartVacuummTorr.Value;
            MyStaticVariables.SleepDiagnosticVar[port].FinalBasePressureCheckTime = step.ElapsedTime.TotalSeconds;
            bsleepDiagnosticinsertBasePressCheck2Data = true;
            bsleepDiagnosticinsertDate = true;

            AddUutRecordDetail(DateTime.Now, "FinalBasePressureCheck", "Complete", "Evac Pressure", signal.PartVacuummTorr.Value, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            if (Config.Mode.SleepDiagnosticCheckHoseWhips.ProcessValue)
            {
                SleeptDiagRORtoHosesOnGuns.Start();
            }
            else SleeptDiagRORtoGuns.Start();
        }

        private void SleepDiagSecondBasePressureCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 45)
            {
                step.Pass();
            }
        }

        private void SleepDiagSecondBasePressureCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.EvacPumpEnable.Enable();
            dout.UnitEvac.Disable();
            dout.RateOfRiseValve.Enable();
        }

        private void SleepDiagFirstBasePressCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].InitialBasePressureCheckPressure = signal.PartVacuummTorr.Value;
            MyStaticVariables.SleepDiagnosticVar[port].InitialBasePressureCheckTime = step.ElapsedTime.TotalSeconds;
            bsleepDiagnosticinsertbasePressCheck1Data = true;
            bsleepDiagnosticinsertDate = true;
            AddUutRecordDetail(DateTime.Now, "InitialBasePressureCheck", "Complete", "Evac Pressure", signal.PartVacuummTorr.Value, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            SleepDiagnosticEvacTillTime.Start();
        }

        private void SleepDiagFirstBasePressCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 45)
            {
                step.Pass();
            }
        }

        private void SleepDiagFirstBasePressCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.EvacPumpEnable.Enable();
            dout.UnitEvac.Disable();
            dout.RateOfRiseValve.Enable();
        }

        private void SleepDiagnosticEvacTillTime_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].SystemEvacuationPressure = signal.PartVacuummTorr.Value;
            MyStaticVariables.SleepDiagnosticVar[port].SystemEvacuationTimeInHr = step.ElapsedTime.TotalHours;
            MyStaticVariables.SleepDiagnosticVar[port].Result = "System Evacuation Failed";
            bsleepDiagnosticinsertSystemEvacData = true;
            bsleepDiagnosticinsertDate = true;
            bsleepDiagnosticinsertResult = true;

            WriteSleepResultsToDatabase("EVAC FAIL");
            dout.UnitEvac.Disable();
            CycleNoTest("Sleep Diagnostic Aborted", "Sleep Diagnostic Aborted");
            SleepDiagPromptToEnd.Start();
        }

        private void SleepDiagnosticEvacTillTime_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalMinutes > 20 && signal.PartVacuummTorr.Value > 25000) step.Fail();
            else
            {
                if (Machine.Test[port].SerialNumber == "VACUUM CHECK")
                {
                    if (step.ElapsedTime.TotalSeconds > Config.Time.Diag_Test_Evac_Delay.ProcessValue) step.Pass();
                }
                else
                {
                    if (DateTime.Now > MyStaticVariables.SleepDiagnosticVar[port].EvacEnd)
                    {
                        step.Pass();
                    }
                }
            }
        }

        private void SleepDiagnosticEvacTillTime_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.SleepDiagnosticVar[port].SystemEvacuationPressure = signal.PartVacuummTorr.Value;
            MyStaticVariables.SleepDiagnosticVar[port].SystemEvacuationTimeInHr = step.ElapsedTime.TotalHours;

            AddUutRecordDetail(DateTime.Now, "System Evacuation", "Complete", "Evac Pressure", signal.PartVacuummTorr.Value, 0, "", 0, "", "mtorr", step.ElapsedTime.TotalSeconds);
            bsleepDiagnosticinsertSystemEvacData = true;
            bsleepDiagnosticinsertDate = true;
            SleepDiagSecondBasePressureCheck.Start();
        }

        private void SleepDiagnosticEvacTillTime_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            #region Get Ending DateTime
            // Set the target time as a string in the format "x:xx"
            string targetTimeString = Config.Control.TimeToStartDianostic.ProcessValue;
            TimeSpan targetTime;

            // Parse the target time string
            if (!TimeSpan.TryParse(targetTimeString, out targetTime))
            {
                Console.WriteLine("Invalid time format. Please use the format 'x:xx'.");
                targetTime = TimeSpan.Parse("5:00");

            }

            DateTime now = DateTime.Now;
            DateTime nextTargetTime;

            // Create a DateTime object with today's date and the parsed target time
            DateTime targetDateTime = now.Date.Add(targetTime);

            if (now > targetDateTime)
            {
                // If it's past the target time today, get tomorrow's target time
                nextTargetTime = now.Date.AddDays(1).Add(targetTime);
            }
            else
            {
                // If it's before the target time today, get today's target time
                nextTargetTime = targetDateTime;
            }

            Console.WriteLine("Next target time: " + nextTargetTime);
            #endregion

            MyStaticVariables.SleepDiagnosticVar[port].EvacEnd = nextTargetTime;


            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            if (Config.Mode.SleepDiagnosticCheckHoseWhips.ProcessValue)
            {
                dout.HiSideToolStem.Enable();
                dout.LoSideToolStem.Enable();
            }
            else
            {
                dout.HiSideToolStem.Disable();
                dout.LoSideToolStem.Disable();
            }

            dout.RateOfRiseValve.Enable();
            dout.UnitEvac.Enable();

            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        private void SleepDiagnosticPromptToPlug_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.BlueUUTRecordsToWrite.Clear();
            bDisplaySleepDiagnosticsForm = true;
            SleepDiagFirstBasePressCheck.Start();
        }

        private void SleepDiagnosticPromptToPlug_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.DIn.Acknowledge.Value)
            {
                step.Pass();
            }
        }

        public void AddUutRecordDetail(DateTime DateTime1, String Test1, String Result1, String ValueName1, double value1, double MinSetpoint1, string MinSetpointName1, double MaxSetpoint1, string MaxSetpointName1, string Units1, double ElapsedTime1)
        {
            MyStaticVariables.UUTRecordDetailToWrite tempUUTRecordDetailToWrite = new MyStaticVariables.UUTRecordDetailToWrite(DateTime1, Test1, Result1, ValueName1, value1, MinSetpoint1, MinSetpointName1, MaxSetpoint1, MaxSetpointName1, Units1, ElapsedTime1);
            MyStaticVariables.BlueUUTRecordsToWrite.Add(tempUUTRecordDetailToWrite);
        }
        private void HoseRecoveryDelay_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            ChargeHoseChargeToolRecovery.Start();
        }

        private void HoseRecoveryDelay_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 1) step.Pass();
        }

        private void TurnOnReversingValve_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if(model.UnitType.ProcessValue.Contains("HP"))
            {
                if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                {
                    model.HiSidePercentage.ProcessValue = 100.0;
                }
            }

            //****mdb12/12/17



            MyStaticVariables.ChargeTargetWeight = Config.CurrentModel[port].TotalCharge.ProcessValue;

            IO.DOut.BlueCircuit2Alarm.Disable();

            Machine.Cycle[0].bHideMessageBox = true;
            if (Machine.OpFormSingle.DataPlot.Settings.AutoRun1)
            {
                Machine.Test[port].FinalEvacSetpoint = model.Final_Evac_Pressure_SetPointt.ProcessValue;
                Machine.Cycle[port].bStartDataPlot = true;
            }

            HiSideToolCheck.Start();
            //if (port == Port.Blue)
            //{
            //    if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
            //    {
            //        IO.DOut.WhiteCircuit1LightStackGreen.Disable();
            //        IO.DOut.WhiteCircuit1LightStackRed.Disable();
            //        IO.DOut.WhiteCircuit1LightStackYellow.Disable();
            //        Machine.Cycle[1].Reset.Start();
            //    }
            //}
            //else
            //{
            //    if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
            //    {
            //        IO.DOut.BlueCircuit2LightStackGreen.Disable();
            //        IO.DOut.BlueCircuit2LightStackRed.Disable();
            //        IO.DOut.BlueCircuit2LightStackYellow.Disable();
            //        Machine.Cycle[0].Reset.Start();
            //    }

            //}
        }

        private void TurnOnReversingValve_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.DIn.BlueHeatPumpControlInput.Value) step.Pass();
        }

        private void TurnOnReversingValve_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.ReversingValve.Enable();
        }

        void ThreeBeeps_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void ThreeBeeps_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.4)
            {
                IO.DOut.BlueCircuit2Alarm.Enable();
            }
            else if ((step.ElapsedTime.TotalSeconds > 0.4) && (step.ElapsedTime.TotalSeconds < 0.8))
            {
                IO.DOut.BlueCircuit2Alarm.Disable();
            }
            else if ((step.ElapsedTime.TotalSeconds > 0.8) && (step.ElapsedTime.TotalSeconds < 1.2))
            {
                IO.DOut.BlueCircuit2Alarm.Enable();
            }
            else if ((step.ElapsedTime.TotalSeconds > 1.2) && (step.ElapsedTime.TotalSeconds < 1.6))
            {
                IO.DOut.BlueCircuit2Alarm.Disable();
            }
            else if ((step.ElapsedTime.TotalSeconds > 1.6) && (step.ElapsedTime.TotalSeconds < 2.0))
            {
                IO.DOut.BlueCircuit2Alarm.Enable();
            }
            else if ((step.ElapsedTime.TotalSeconds > 2.4))
            {
                IO.DOut.BlueCircuit2Alarm.Disable();
                step.Pass();
            }

        }

        void ThreeBeeps_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Enable();
        }

        void DiagInitialEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagEvacBothGuns.Start();
        }

        void DiagInitialEvac_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Pass();
        }

        void DiagInitialEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BasePressureTestValve.Enable();
            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        void DiagRORTstRecovValve_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Rate of Rise Valve";
            CycleFail(string.Format(Localization.DiagRORTstRecovValve_failed, Machine.Test[0].LeakySide), string.Format(Localization.DiagRORTstRecovValve_TH, Machine.Test[0].LeakySide));
            Reset.Start();
        }

        void DiagRORTstRecovValve_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(Localization.DiagRORTstRecovValve_passed, Localization.DiagRORTstRecovValveP_TH);
        }

        void DiagRORTstRecovValve_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORTstRecovValve_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacB4TstRecovValve_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacB4TstRecovValve_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacB4TstRecovValve_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORTstRecovValve.Start();
        }

        void DiagEvacB4TstRecovValve_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacB4TstRecovValve_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacB4TstRecovValve_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagPrmptOpenRecov_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            if (!Machine.Test[0].OpenRecovB4Reset) DiagEvacB4TstRecovValve.Start();
            else
            {
                Machine.Test[port].Result = "Diagnostics Failed - Charge Valve";
                CycleFail(string.Format(Localization.DiagRORTstChrgValve_failed, Machine.Test[0].LeakySide), string.Format(Localization.DiagRORTstChrgValve_TH, Machine.Test[0].LeakySide));
                Reset.Start();
            }
        }

        void DiagPrmptOpenRecov_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPrmptOpenRecov_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
        }

        void DiagRORTstChrgValve_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[0].OpenRecovB4Reset = true;
            DiagPrmptOpenRecov.Start();
            
        }

        void DiagRORTstChrgValve_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagPrmptOpenRecov.Start();
        }

        void DiagRORTstChrgValve_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORTstChrgValve_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacB4TstChargeValve_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacB4TstChargeValve_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacB4TstChargeValve_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORTstChrgValve.Start();
        }

        void DiagEvacB4TstChargeValve_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacB4TstChargeValve_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacB4TstChargeValve_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagPromptOpenSupply_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            DiagEvacB4TstChargeValve.Start();
        }

        void DiagPromptOpenSupply_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPromptOpenSupply_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            dout.HiSideCharge.Disable();
            dout.LoSideCharge.Disable();
        }

        void DiagOpenSupplyNRecov_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            Machine.Test[port].Result = "Diagnostics Failed - Body of Gun";
            CycleFail(string.Format(Localization.DiagOpenSupplyNRecov_passed, Machine.Test[0].LeakySide), string.Format(Localization.DiagOpenSupplyNRecovP_TH, Machine.Test[0].LeakySide));
            Reset.Start();
        }

        void DiagOpenSupplyNRecov_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagOpenSupplyNRecov_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.LoSideRecovery.Disable();
            dout.HiSideRecovery.Disable();
        }

        void DiagRORLeakyGun_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagOpenSupplyNRecov.Start();
        }

        void DiagRORLeakyGun_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagPromptOpenSupply.Start();
        }

        void DiagRORLeakyGun_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORLeakyGun_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[0].LeakySide == "HighSide")
            {
                dout.HiSideCharge.Disable();
                dout.HiSideRecovery.Disable();
            }
            else
            {
                dout.LoSideCharge.Disable();
                dout.LoSideRecovery.Disable();
            }
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacAllLines_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed -Evac";
            CycleFail(Localization.DiagEvacAllLines_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacAllLines_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORLeakyGun.Start();
        }

        void DiagEvacAllLines_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacAllLines_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacAllLines_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[0].LeakySide == "HighSide")
            {
                dout.HiSideEvac.Enable();
                IO.DOut.HighSideRateOfRiseValve.Enable();
                IO.DOut.BasePressureTestValve.Enable();
                dout.HiSideRecovery.Enable();
            }
            else
            {
                dout.LoSideEvac.Enable();
                IO.DOut.HighSideRateOfRiseValve.Enable();
                IO.DOut.BasePressureTestValve.Enable();
                dout.LoSideRecovery.Enable();
            }
        }

        void DiagPromtCloseRecov_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            DiagEvacAllLines.Start();
        }

        void DiagPromtCloseRecov_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPromtCloseRecov_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            dout.HiSideRecovery.Disable();
            dout.LoSideRecovery.Disable();
        } 

        void DiagRecovSupplyLine_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed -Recovering Supply Line";
            CycleFail(Localization.DiagRecovSupplyLine_failed, Localization.DiagRecovSupplyLine_TH);
            Reset.Start();
        }

        void DiagRecovSupplyLine_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagPromtCloseRecov.Start();
        }

        void DiagRecovSupplyLine_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideCharge.Disable();
            step.Fail();
        }

        void DiagRecovSupplyLine_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BlueSupplyPressure.Value < Config.Pressure.DiagRcvrSupplySetpoint.ProcessValue)
            {
                step.Pass();
            }
        }

        void DiagRecovSupplyLine_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[0].LeakySide == "HighSide")
            {
                dout.HiSideRecovery.Enable();
                dout.HiSideCharge.Enable();
            }
            else
            {
                dout.LoSideRecovery.Enable();
                dout.LoSideCharge.Enable();
            }
        }

        void DiagPromtCloseSupply_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            DiagRecovSupplyLine.Start();
        }

        void DiagPromtCloseSupply_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPromtCloseSupply_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            dout.LoSideEvac.Disable();
            dout.HiSideEvac.Disable();
        }

        void DiagRORLowGun_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[0].LeakySide = "LowSide";
            DiagPromtCloseSupply.Start();
        }

        void DiagRORLowGun_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(Localization.DiagRORLowGun_passed, Localization.DiagRORLowGunP_TH);
        }

        void DiagRORLowGun_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORLowGun_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacLowGun_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacLowGun_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacLowGun_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORLowGun.Start();
        }

        void DiagEvacLowGun_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacLowGun_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacLowGun_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideEvac.Disable();
            dout.LoSideEvac.Enable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagRORHighGun_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[0].LeakySide = "HighSide";
            DiagPromtCloseSupply.Start();
        }

        void DiagRORHighGun_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagEvacLowGun.Start();
        }

        void DiagRORHighGun_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORHighGun_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacHighGun_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacHighGun_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacHighGun_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORHighGun.Start();
        }

        void DiagEvacHighGun_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }
        
        void DiagEvacHighGun_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacHighGun_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideEvac.Enable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagLookWithAlcohol_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Hosing";
            CycleFail(Localization.DiagLookWithAlcohol_failed, Localization.DiagLookWithAlcohol_TH);
            Reset.Start();
        }

        void DiagLookWithAlcohol_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Fail();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Fail();
                }
            }
        }

        void DiagLookWithAlcohol_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagRORHosing_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagLookWithAlcohol.Start();
        }

        void DiagRORHosing_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagEvacHighGun.Start();
        }

        void DiagRORHosing_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORHosing_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacHoses_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacHoses_failed, Localization.EvacFault);
            Reset.Start();
        }

        void DiagEvacHoses_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORHosing.Start();
        }

        void DiagEvacHoses_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacHoses_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacHoses_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideEvac.Disable();
            dout.LoSideEvac.Disable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void DiagRORValveChck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Rate of Rise Valve";
            CycleFail(Localization.DiagRORValveChck_failed, Localization.DiagRORValveChck_TH);
            Reset.Start();
        }

        void DiagRORValveChck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "DIAGNOSTICS PASSED";
            CyclePass(Localization.DiagRORValveChck_passed, Localization.DiagRORValveChckP_TH);
            Reset.Start();
        }

        void DiagRORValveChck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagRORValvCheckSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagVenting_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Venting";
            CycleFail(Localization.DiagVenting_failed, Localization.DiagVenting_TH);
            Reset.Start();
        }

        void DiagVenting_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORValveChck.Start();
        }

        void DiagVenting_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagVentingSetpoint.ProcessValue)
            {
                IO.DOut.BasePressureTestValve.Disable();
                step.Pass();
            }
            else step.Fail();
        }

        void DiagPrompt2Unplug_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            DiagVenting.Start();
        }

        void DiagPrompt2Unplug_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPrompt2Unplug_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            IO.DOut.HighSideRateOfRiseValve.Disable();
            IO.DOut.BasePressureTestValve.Enable();
        }

        void DiagRORBothGuns_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagEvacHoses.Start();
        }

        void DiagRORBothGuns_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagPrompt2Unplug.Start();
        }

        void DiagRORBothGuns_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value > Config.Pressure.DiagRORSetpoint)
            {
                step.Fail();
            }
            else step.Pass();
        }

        void DiagRORBothGuns_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.HighSideRateOfRiseValve.Disable();
        }

        void DiagEvacBothGuns_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Evac";
            CycleFail(Localization.DiagEvacBothGuns_failed, Localization.DiagEvacBothGuns_TH);
            Reset.Start();
        }

        void DiagEvacBothGuns_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagRORBothGuns.Start();
        }

        void DiagEvacBothGuns_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Fail();
        }

        void DiagEvacBothGuns_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.DiagEvacSetpoint && step.ElapsedTime.TotalSeconds > 2)
            {
                step.Pass();
            }
        }

        void DiagEvacBothGuns_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[0].OpenRecovB4Reset = false;
            IO.DOut.BasePressureTestValve.Enable();
            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        void DiagBasePressChk_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "Diagnostics Failed - Base Pressure";
            CycleFail(Localization.DiagBasePressChk_failed, Localization.DiagBasePressChk_TH);
            Reset.Start();
        }

        void DiagBasePressChk_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            DiagInitialEvac.Start();
        }

        void DiagBasePressChk_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }
            if (PartVacuum < Config.Pressure.DiagBasePressureStpnt.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                step.Fail();
            }
        }

        void DiagBasePressChk_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (!IO.DOut.EvacPumpEnable.Value)
            {
                IO.DOut.EvacPumpEnable.Enable();
                Thread.Sleep(250);
            }
            IO.DOut.BasePressureTestValve.Disable();
            IO.DOut.HighSideRateOfRiseValve.Enable();

        }

        void DiagPrmpt2Plug_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            DiagBasePressChk.Start();
        }

        void DiagPrmpt2Plug_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }
        }

        void DiagPrmpt2Plug_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
        }

        void CloseLiquidServiceValveBeforeCharge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Cycle[0].bHideMessageBox = true;
            IO.DOut.BlueCircuit2Alarm.Disable();

                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue > 0.5)
                    {
                        HiSideCharge.Start();
                    }
                    else
                    {
                        LowSideCharge.Start();
                    }
                }
                else
                {
                    LowSideCharge.Start();
                }
        }

        void CloseLiquidServiceValveBeforeCharge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
           

            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


 	        if(MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
            {
                step.Pass();
            }
        }

        void CloseLiquidServiceValveBeforeCharge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.WaitForAcknowledgeFlagBlue = false;

            //if (model.HiSidePercentage.ProcessValue < 0.5)
            if(model.UnitType.ProcessValue.Contains("HP"))
            {
                Machine.Test[port].MessageFormText = "CLOSE THE SERVICE VALVE, PRESS ACKNOWLEDGE TO START CHARGE";
            }
            else
            {
                Machine.Test[port].MessageFormText = "CLOSE SUCTION SIDE SERVICE VALVE, PRESS ACKNOWLEDGE TO START CHARGE";
            }

                Machine.Cycle[port].bShowMessageCloseLiquidValve = true;
            
        }

        void SaveToDataBases_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            VtiEvent.Log.WriteInfo("SAVE To Database Start", VtiEventCatType.Database);

            ForwardCycleResult(Machine.Test[port].Result);
        }

        void WaitForAcknowledgeToStart_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (model.UnitType.ProcessValue.Contains("HP") && (!Machine.Test[port].ForceHiSideChargeFlag) && (!Machine.Test[port].ForceChargeFlag) && (!Machine.Test[port].ForceLowSideChargeFlag))
            {
                TurnOnReversingValve.Start();
            }
            else
            {
                //if(model.UnitType.ProcessValue.Contains("HP"))
                {
                    if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                    {
                        //model.HiSidePercentage.ProcessValue = 100.0;
                    }
                }

                //****mdb12/12/17



                MyStaticVariables.ChargeTargetWeight = Config.CurrentModel[port].TotalCharge.ProcessValue;

                IO.DOut.BlueCircuit2Alarm.Disable();

                Machine.Cycle[0].bHideMessageBox = true;
                if (Machine.OpFormSingle.DataPlot.Settings.AutoRun1)
                {
                    Machine.Test[port].FinalEvacSetpoint = model.Final_Evac_Pressure_SetPointt.ProcessValue;
                    Machine.Cycle[port].bStartDataPlot = true;
                }

                HiSideToolCheck.Start();
                //if (port == Port.Blue)
                //{
                //    if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                //    {
                //        IO.DOut.WhiteCircuit1LightStackGreen.Disable();
                //        IO.DOut.WhiteCircuit1LightStackRed.Disable();
                //        IO.DOut.WhiteCircuit1LightStackYellow.Disable();
                //        Machine.Cycle[1].Reset.Start();
                //    }
                //}
                //else
                //{
                //    if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                //    {
                //        IO.DOut.BlueCircuit2LightStackGreen.Disable();
                //        IO.DOut.BlueCircuit2LightStackRed.Disable();
                //        IO.DOut.BlueCircuit2LightStackYellow.Disable();
                //        Machine.Cycle[0].Reset.Start();
                //    }

                //}
            }
        }

        void WaitForAcknowledgeToStart_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                    step.Pass();
                }
            }
            else
            {
                if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    step.Pass();
                }
            }

            //if (Machine.Test[0].PartialChargeStartFlag)
            //{
            //    step.Pass();
            //    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            //    return;
            //}
            //else if (Machine.Test[0].PartialChargeEndFlag)
            //{
            //    step.Pass();
            //    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            //    return;
            //}


        }

        void WaitForAcknowledgeToStart_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            SetControlPropertyValue(Machine.Prompt[port], "BackColor", Color.White); //This is a thread safe method
            SetControlPropertyValue(Machine.Prompt[port], "DefaultColor", Color.Black); //This is a thread safe method
            step.Color = Color.Black;
            step.ColorDetails = Color.Black;

            MyStaticVariables.ReadyToTest = false;

            IO.DOut.BlueCircuit2LightStackRed.Disable();
            IO.DOut.BlueCircuit2LightStackYellow.Disable();
            UpdateTime.Start();

            // Reset prompt
            Machine.Prompt[port].Clear();
            Machine.Prompt[port].AppendText(Localization.CurrentTestMode + ": " + Config.TestMode.ToString() + Environment.NewLine);
            Machine.Prompt[port].AppendText(Environment.NewLine);
            if (Machine.Test[port].ModelNumber == "")
            {
                Machine.Test[port].ModelNumber = model.Name;// Machine.Test[port].ModelNumber;
            }
            Machine.Prompt[port].AppendText(
                string.Format(Localization.ModelNumber, Machine.Test[port].ModelNumber) + Environment.NewLine);

            Machine.Prompt[port].AppendText(Environment.NewLine);
            if (!string.IsNullOrEmpty(Machine.Test[port].SerialNumber))
                Machine.Prompt[port].AppendText(
                    string.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber) + Environment.NewLine);

            Machine.Prompt[port].AppendText(Environment.NewLine);


            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            try
            {
                MyStaticVariables.MessageSerialNumber = Machine.Test[port].SerialNumber;
                if (Machine.Test[port].ModelNumber =="")
                {
                    Machine.Test[port].ModelNumber = model.Name;
                }
                MyStaticVariables.MessageModelNumber = Machine.Test[port].ModelNumber;
                MyStaticVariables.TotalCharge = Config.CurrentModel[port].TotalCharge.ProcessValue;
                if (port ==0)
                {
                    MyStaticVariables.MessageRefrigerantName = Config.Control.BlueRefrigerantName.ProcessValue;
                    MyStaticVariables.MessageRefrigerantType = ((int)Config.Control.BlueRefrigerantType.ProcessValue).ToString();
                }
                ////Machine.Message.textBox1.Text = string.Format("Serial Number = {0} , Model Number = {1} , Charge Weight = {2:0} oz", Machine.Test[port].SerialNumber, Machine.Test[port].ModelNumber, Config.CurrentModel[port].TotalCharge.ProcessValue);
                //if (Machine.Test[0].PartialChargeStartFlag)
                //{

                //}
                //else if (Machine.Test[0].PartialChargeEndFlag)
                //{

                //}
                //else
                {
                    Machine.Cycle[0].bShowMessageForm = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }


        void CheckStoredProcedure_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[Port.Blue].StoredProcedureCheck == 1)
            {
                CycleNoTest(Localization.CheckStoredProcedure_Failed1, Localization.CheckStoredProcedure_Failed1);
            }
            else if (Machine.Test[Port.Blue].StoredProcedureCheck == 2)
            {
                CycleNoTest(Localization.CheckStoredProcedure_Failed2, Localization.CheckStoredProcedure_Failed2);
            }
            else
            {
                CycleNoTest(Localization.CheckStoredProcedure_FailedConnect, Localization.CheckStoredProcedure_FailedConnect);
            }
        }

        void CheckStoredProcedure_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //force model selection
            if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) )
            {
                //if (Config.Mode.CheckStoredProcedureEnabled.ProcessValue)
                //{
                //    Machine.Cycle[0].CheckStoredProcedure.Start();
                //}
                //else
                {
                    Machine.Cycle[0].WaitForModelSelection.Start();
                }
            }
            if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue))
            {
                //if (Config.Mode.CheckStoredProcedureEnabled.ProcessValue)
                //{
                //    Machine.Cycle[1].CheckStoredProcedure.Start();
                //}
                //else
                {
                    Machine.Cycle[1].WaitForModelSelection.Start();
                }
            }
            
        }

        void CheckStoredProcedure_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void CheckStoredProcedure_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            try
            {
                SqlConnection sqlConnection1 = new SqlConnection(Config.Control.StoredProcedureConnectionString.ProcessValue);
                SqlCommand cmd = new SqlCommand("CheckCompressorState",sqlConnection1);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("serialnumber",SqlDbType.NVarChar);
                cmd.Parameters["serialnumber"].Direction = ParameterDirection.Input;
                cmd.Parameters["serialnumber"].Size = 25;
                cmd.Parameters.Add("Result", SqlDbType.Int);
                cmd.Parameters["Result"].Direction = ParameterDirection.Output;
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();

                cmd.ExecuteNonQuery();

                Machine.Test[Port.Blue].StoredProcedureCheck=Convert.ToInt32(cmd.Parameters["Result"].Value.ToString());
                if (Machine.Test[Port.Blue].StoredProcedureCheck == 0)
                {
                    //get model stored procedure here

                    string TempModelName="";
                    //read the model data

                            string TempRefType;
                            string TempTotalCharge;
                            string TempEvacPressSetPoint;
                            string TempEvacDelay;
                            string TempRORPressSetPoint;
                            string TempRORDelay;

                            

                            //use Model Number, read refrigerant type, charge weight, evac pressure, rate of rise target
                            bool ModelDataIsGood = false;
                            TempRefType = "";
                            TempTotalCharge = "";
                            TempEvacPressSetPoint = "";
                            TempEvacDelay = "";
                            TempRORPressSetPoint = "";
                            TempRORDelay = "";
                            try
                            {
                                SqlConnection sqlConnection2 = new SqlConnection(Config.Control.ModelDataConnectionString.ProcessValue);
                                SqlCommand cmd2 = new SqlCommand();
                                Object returnValue;

                                String sCommandText;
                                String TempString;
                                sCommandText = Config.Control.ModelDataSelectString.ProcessValue + " " +
                                               Config.Control.ModelDataFromTableNameString.ProcessValue + " " +
                                               string.Format(Config.Control.ModelDataWhereString.ProcessValue, TempModelName);
                                cmd2.CommandText = sCommandText;
                                cmd2.CommandType = CommandType.Text;
                                cmd2.Connection = sqlConnection1;

                                sqlConnection2.Open();

                                SqlDataReader reader2 = cmd2.ExecuteReader();

                                if (reader2.HasRows)
                                {
                                    reader2.Read();
                                    TempString = reader2.GetString(0);
                                    if (TempString != null)
                                    {
                                        TempRefType = TempString;
                                    }
                                    TempString = reader2.GetString(1);
                                    if (TempString != null)
                                    {
                                        TempTotalCharge = TempString;
                                    }
                                    TempString = reader2.GetString(2);
                                    if (TempString != null)
                                    {
                                        TempEvacPressSetPoint = TempString;
                                    }
                                    TempString = reader2.GetString(3);
                                    if (TempString != null)
                                    {
                                        TempEvacDelay = TempString;
                                    }
                                    TempString = reader2.GetString(4);
                                    if (TempString != null)
                                    {
                                        TempRORPressSetPoint = TempString;
                                    }
                                    TempString = reader2.GetString(5);
                                    if (TempString != null)
                                    {
                                        TempRORDelay = TempString;
                                    }
                                }
                                ModelDataIsGood = true;
                                reader2.Close();
                                
                                sqlConnection2.Close();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }

                            if (ModelDataIsGood)
                            {
                                //if model data is good, load the model on the correct port, reset the other
                                if (Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue) == Convert.ToInt32(TempRefType))
                                {
                                    if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                    {
                                        //select blue side, reset white
                                        Machine.Test[0].ModelNumber = TempModelName;
                                        if (!Config.CurrentModel[0].Load(TempModelName))
                                        {
                                            Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + TempModelName);
                                        }
                                        else
                                        {
                                            Config.CurrentModel[0].TotalCharge.ProcessValue = Convert.ToDouble(TempTotalCharge);
                                            Config.CurrentModel[0].Final_Evac_Pressure_SetPointt.ProcessValue = Convert.ToDouble(TempEvacPressSetPoint);
                                            Config.CurrentModel[0].Final_Evac_Delay.ProcessValue = Convert.ToDouble(TempEvacDelay);
                                            Config.CurrentModel[0].ROR_Pressure_Check_Pressure_SetPointt.ProcessValue = Convert.ToDouble(TempRORPressSetPoint);
                                            Config.CurrentModel[0].ROR_Pressure_Check_Delay.ProcessValue = Convert.ToDouble(TempRORDelay);

                                            //Machine.Cycle[0].CycleStart();
                                            if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                            {
                                                Machine.Test[1].SerialNumber = "";
                                                Machine.Cycle[1].Reset.Start();
                                            }
                                            step.Pass();
                                        }
                                    }
                                }
                                else if (Convert.ToInt32(Config.Control.WhiteRefrigerantType.ProcessValue) == Convert.ToInt32(TempRefType))
                                {
                    //                if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                    //                {
                    //                    //select white side, reset blue
                    //                    Machine.Test[1].ModelNumber = TempScannerText;
                    //                    if (!Config.CurrentModel[1].Load(TempScannerText))
                    //                    {
                    //                        Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + ScannerText);
                    //                    }
                    //                    else
                    //                    {
                    //                        Config.CurrentModel[1].TotalCharge.ProcessValue = Convert.ToDouble(TempTotalCharge);
                    //                        Config.CurrentModel[1].Final_Evac_Pressure_SetPoint.ProcessValue = Convert.ToDouble(TempEvacPressSetPoint);
                    //                        Config.CurrentModel[1].Final_Evac_Delay.ProcessValue = Convert.ToDouble(TempEvacDelay);
                    //                        Config.CurrentModel[1].ROR_Pressure_Check_Pressure_SetPoint.ProcessValue = Convert.ToDouble(TempRORPressSetPoint);
                    //                        Config.CurrentModel[1].ROR_Pressure_Check_Delay.ProcessValue = Convert.ToDouble(TempRORDelay);
                    //                        Machine.Cycle[1].CycleStart();
                    //                        if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                    //                        {
                    //                            Machine.Test[0].SerialNumber = "";
                    //                            Machine.Cycle[0].Reset.Start();
                    //                        }
                    //                        return;
                    //                    }
                    //                }
                                }
                                else
                                {
                                    if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                    {
                                        Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM DATABASE: " + TempModelName);
                                    }
                                    if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                    {
                                        Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID REF TYPE FROM DATABASE: " + TempModelName);
                                    }

                                    step.Fail();
                    //                return;
                                }
                            }
                            else
                            {
                                //model data is bad, load model name in 0
                                Machine.Test[0].ModelNumber = TempModelName;
                                if (!Config.CurrentModel[0].Load(TempModelName))
                                {
                                    if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                    {
                                        Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + TempModelName);
                                    }
                                    if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                    {
                                        Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID LOCAL MODEL: " + TempModelName);
                                    }
                                }
                                else
                                {
                                    //check 0 ref type, match, reset 1
                                    if (Convert.ToInt32(Config.CurrentModel[0].RefrigerantType.ProcessValue) == Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue))
                                    {
                                        if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                        {
                                            Machine.Cycle[0].CycleStart();
                                        }
                                        if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                        {
                                            Machine.Test[1].SerialNumber = "";
                                            Machine.Cycle[1].Reset.Start();
                                        }
                                        return;
                                    }
                                    else
                                    {
                                        //no match, set 0 to default, check 1 for match
                                        Config.CurrentModel[0].LoadFrom(Config.DefaultModel);
                                        if (Convert.ToInt32(Config.CurrentModel[1].RefrigerantType.ProcessValue) == Convert.ToInt32(Config.Control.WhiteRefrigerantType.ProcessValue))
                                        {
                                            if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                            {
                                                Machine.Cycle[1].CycleStart();
                                            }
                                            if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                            {
                                                Machine.Test[0].SerialNumber = "";
                                                Machine.Cycle[0].Reset.Start();
                                            }
                                            return;
                                        }
                                        else
                                        {
                                            if (Machine.Cycle[0].WaitForModelSelection.State == CycleStepState.InProcess)
                                            {
                                                Machine.Prompt[0].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + TempModelName);
                                            }
                                            if (Machine.Cycle[1].WaitForModelSelection.State == CycleStepState.InProcess)
                                            {
                                                Machine.Prompt[1].AppendText(Environment.NewLine + "INVALID REF TYPE FROM LOCAL MODEL: " + TempModelName);
                                            }
                                            return;
                                        }
                                    }
                                }
                            
                        
                    }







                    step.Pass();
                }
                else
                {
                    step.Fail();
                }

                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Machine.Test[Port.Blue].StoredProcedureCheck = 666;
                step.Fail();
            }

        }

        void WaitForSTART_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue > 0.5)
                    {
                        HiSideToolCheck.Start();
                    }
                    else
                    {
                        LowSideToolCheck.Start();
                    }
                }
                else
                {
                    LowSideToolCheck.Start();
                }
            }
            else
            {
                WaitToStartToolCheck.Start();
            }
        }

        void WaitForSTART_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.StartEvacAndChargeFlag)
            {
                step.Pass();
            }
        }

        void WaitForSTART_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.StartEvacAndChargeFlag = false;
        }

        void WeighChargedUnit_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if(Machine.Test[port].UnitNetWeight>(model.TotalCharge.ProcessValue+Config.Flow.MaximumChargeWeightErrorFromScale.ProcessValue))
            {
                        Machine.Test[port].PassedChargeFlag = false;
                        CycleFail(string.Format(Localization.OverChargeFailByScale, Machine.Test[port].UnitNetWeight), string.Format(Localization.OverChargeFailByScaleTH, Machine.Test[port].UnitNetWeight));
                
            }
            else if(Machine.Test[port].UnitNetWeight<(model.TotalCharge.ProcessValue-Config.Flow.MaximumChargeWeightErrorFromScale.ProcessValue))
            {
                        Machine.Test[port].PassedChargeFlag = false;
                        CycleFail(string.Format(Localization.UnderChargeFailByScale, Machine.Test[port].UnitNetWeight), string.Format(Localization.UnderChargeFailByScaleTH, Machine.Test[port].UnitNetWeight));
                
            }
            
        }

        void WeighChargedUnit_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Int32 Pounds;
            double Ounces;
            
                Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                if (Ounces > 15.95)
                {
                    Ounces = 0.0;
                    Pounds = Pounds + 1;
                }
            


            CyclePass(string.Format(Localization.PassedCharge, Pounds,Ounces), string.Format(Localization.PassedChargeTH, Pounds,Ounces));
            Reset.Start();
        }

        void WeighChargedUnit_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UnitEndWeight = IO.Signals.ScaleWeight.Value;
            Machine.Test[port].UnitNetWeight = (Machine.Test[port].UnitEndWeight - Machine.Test[port].UnitStartWeight)*16.0+model.ScaleWeightCorrection.ProcessValue;
            if (port == Port.Blue)
            {
                IO.Signals.BlueNetWeight.Value = Machine.Test[port].UnitNetWeight;
            }
            else
            {
                IO.Signals.WhiteNetWeight.Value = Machine.Test[port].UnitNetWeight;
            }
            if(Machine.Test[port].UnitNetWeight>(model.TotalCharge.ProcessValue+Config.Flow.MaximumChargeWeightErrorFromScale.ProcessValue))
            {
                step.Fail();
            }
            else if(Machine.Test[port].UnitNetWeight<(model.TotalCharge.ProcessValue-Config.Flow.MaximumChargeWeightErrorFromScale.ProcessValue))
            {
                step.Fail();
            }
            else
            {
                step.Pass();
            }
        }

        void WeighChargedUnit_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
           
        }

        void WaitForFINALWEIGHT_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            WeighChargedUnit.Start();
        }

        void WaitForFINALWEIGHT_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.ReadyForFinalWeightFlag)
            {
                step.Pass();
            }
        }

        void WaitForFINALWEIGHT_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.ReadyForFinalWeightFlag = false;
        }

        void WeighDisconnectedUnit_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UnitStartWeight = IO.Signals.ScaleWeight.Value;
            if (port == Port.Blue)
            {
                IO.Signals.BlueStartWeight.Value = Machine.Test[port].UnitStartWeight;
            }
            else
            {
                IO.Signals.WhiteStartWeight.Value = Machine.Test[port].UnitStartWeight;
            }
            WaitForSTART.Start();
        }

        void WeighDisconnectedUnit_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Pass();
        }

        void WeighDisconnectedUnit_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Config.Mode.AutoSetScaleOffsetEnable.ProcessValue)
            {
                Machine.ManualCommands.SetScaleOffset(); // 8/2/2016 aparrott
                Config.Mode.AutoSetScaleOffsetEnable.ProcessValue = false;
                Config.Save();
            }
        }

        void LowRefPressureWarning_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void LowRefPressureWarning_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            TimeSpan _RoughPumpOffTime = DateTime.Now - MyStaticVariables._RoughPumpStartTime;
            if ((_RoughPumpOffTime.TotalSeconds > Config.Time.RoughPumpIdlePowerOff.ProcessValue) && (Config.Time.RoughPumpIdlePowerOff.ProcessValue > 0.1) && (MyStaticVariables.ReadyToTest))//if not ready to test other side is running, do not switch off pump
            {
                if (Config.TestMode == TestModes.Autotest)
                {
                    //IO.DOut.VacuumPumpEnable.Disable(); // Rough pump power off idle timer
                    IO.DOut.EvacPumpEnable.Disable();
                    //IO.DOut.LowSideEvacPump.Disable();
                }
            }


            if (port == Port.Blue)
            {
                if (IO.Signals.BlueSupplyPressure.Value > Config.Pressure.Blue_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                {
                    step.Pass();
                }
            }
            else
            {
                if (IO.Signals.WhiteSupplyPressure.Value > Config.Pressure.White_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                {
                    step.Pass();
                }

            }
        }

        void LowRefPressureWarning_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void RecoveryTankFullWarning_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Idle.Start();
        }

        void RecoveryTankFullWarning_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (din.RecoveryTankFloatSwitch.Value)
            {
                step.Pass();
            }
        }

        void RecoveryTankFullWarning_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void WaitForModelSelection_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Reset.Start();
        }

        void CycleStartDelay_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[0].SerialNumber == "DIAGNOSTICS")
            {
                DiagPrmpt2Plug.Start();
            }
            //dout.BoosterDisable.Enable();//disable early to reduce noise
            else if (model.UnitType.ProcessValue.Contains("HP") && (!Machine.Test[port].ForceHiSideChargeFlag) && (!Machine.Test[port].ForceChargeFlag) && (!Machine.Test[port].ForceLowSideChargeFlag))
            {
                TurnOnReversingValve.Start();
            }
            else if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                {
                    if (((Machine.Test[port].ForceHiSideChargeFlag) || (Machine.Test[port].ForceChargeFlag)) && (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue))
                    {
                        if (model.HiSidePercentage.ProcessValue > 0.5)
                        {
                            //HiSideCharge.Start();
                            HiSideToolCheck.Start();
                        }
                        else
                        {
                            //LowSideCharge.Start();
                            LowSideToolCheck.Start();
                        }
                    }
                    else
                    {
                        if ((Machine.Test[port].ForceLowSideChargeFlag) && (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue))
                        {
                            //LowSideCharge.Start();
                            LowSideToolCheck.Start();
                        }
                        else
                        {
                            if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                            {
                                //HiSideToolCheck.Start();
                                if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag &&!Machine.Test[port].RecoverUnitFlag)
                                {
                                    WeighDisconnectedUnit.Start();
                                }
                                else
                                {
                                    HiSideToolCheck.Start();
                                }
                            }
                            else
                            {
                                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                                {
                                    //LowSideToolCheck.Start();
                                    if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag && !Machine.Test[port].RecoverUnitFlag)
                                    {
                                        WeighDisconnectedUnit.Start();
                                    }
                                    else
                                    {
                                        LowSideToolCheck.Start();
                                    }
                                }
                                else
                                {
                                    CycleFail(Localization.Circuit2NoToolEnabled, Localization.CircuitNoToolEnabledTH);
                                }
                            }
                        }
                    }
                }
            }
            else//white port
            {
                if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                {
                    if (((Machine.Test[port].ForceHiSideChargeFlag) || Machine.Test[port].ForceChargeFlag) && (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                    {
                        if (model.HiSidePercentage.ProcessValue > 0.5)
                        {
                            //HiSideCharge.Start();
                            //HiSideToolCheck.Start();
                            WaitToStartToolCheck.Start();
                        }
                        else
                        {
                            //LowSideCharge.Start();
                            //LowSideToolCheck.Start();
                            WaitToStartToolCheck.Start();
                        }
                    }
                    else
                    {
                        if ((Machine.Test[port].ForceLowSideChargeFlag) && (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue))
                        {
                            //LowSideCharge.Start();
                            //LowSideToolCheck.Start();
                            WaitToStartToolCheck.Start();
                        }
                        else
                        {
                            if ((!Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue) && (!Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                            {
                                CycleFail(Localization.Circuit1NoToolEnabled, Localization.CircuitNoToolEnabledTH);
                            }
                            else
                            {
                                if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag &&!Machine.Test[port].RecoverUnitFlag)
                                {
                                    WeighDisconnectedUnit.Start();
                                }
                                else
                                {
                                    WaitToStartToolCheck.Start();
                                }
                            }
                        }
                    }
                }
            }
        }

        void WaitForModelSelection_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //Machine.Cycle[port].CycleStart();
        }

        void WaitForModelSelection_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if ((Config.CurrentModel[port].Name.ToUpper() != "DEFAULT")||(Machine.Test[0].ModelNumber!=""))
            {
                if (port == Port.Blue)
                {
                    if (Convert.ToInt32(Config.Control.BlueRefrigerantType.ProcessValue) == Convert.ToInt32(model.RefrigerantType.ProcessValue))
                    {
                        step.Pass();
                    }
                    else
                    {
                        step.Fail();
                    }
                }
                else
                {
                    if (Convert.ToInt32(Config.Control.WhiteRefrigerantType.ProcessValue) == Convert.ToInt32(model.RefrigerantType.ProcessValue))
                    {
                        step.Pass();
                    }
                    else
                    {
                        step.Fail();
                    }

                }
                step.Pass();
            }
            //if (Config.CurrentModel[0].Name.ToUpper() != "DEFAULT")
            //{
            //    if ((Config.CurrentModel[1].Name != Config.CurrentModel[0].Name))
            //    {
            //        if (Config.CurrentModel[0].Name.ToUpper() == "DEFAULT")
            //        {
            //            Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
            //        }
            //        else
            //        {
            //            Config.CurrentModel[1].Load(Config.CurrentModel[0].Name);                      

            //        }
            //    }
            //    step.Pass();
            //}
        }

        void WaitForModelSelection_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //Machine.Cycle[Port.Blue].bDisplaySelectModel = true;
        }

        void RecoverUnit_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Pass();
        }


        void RecoverUnit_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].Result = "RECOVERY PASSED";
            if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();

        }

        void RecoverUnit_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if ((step.ElapsedTime.TotalSeconds > Config.Time.Unit_Recovery_Timeout.ProcessValue/4.0)||MyStaticVariables.WaitForAcknowledgeFlagBlue || MyStaticVariables.WaitForAcknowledgeFlagWhite)
            {
                if (port == Port.Blue)
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                        step.Pass();
                        
                    }
                    else
                    {
                        if (IO.Signals.BlueHiSideToolPressure.Value < model.Recovery_Pressure_SetPoint.ProcessValue)
                        {
                            if (step.ElapsedTime.TotalSeconds > 10.0)
                            {
                                step.Pass();
                            }
                        }
                    }
                }
                else
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                        step.Pass();
                        
                    }
                    else
                    {
                        if (IO.Signals.WhiteHiSideToolPressure.Value < model.Recovery_Pressure_SetPoint.ProcessValue)
                        {
                            if (step.ElapsedTime.TotalSeconds > 10.0)
                            {
                                step.Pass();
                            }
                        }
                    }
                }
            }
        }

        void RecoverUnit_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideEvac.Disable();
            dout.LoSideEvac.Disable();
            dout.HiSideRecovery.Disable();
            dout.LoSideRecovery.Disable();
            dout.RateOfRiseValve.Disable();
            dout.UnitEvac.Disable();

            //dout.RecoveryPumpEnable.Enable();

            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;

            Thread.Sleep(1000);
            //recover enabled guns
            if(port==Port.Blue)
            {
                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                {
                    dout.LoSideRecovery.Enable();
                    dout.LoSideToolStem.Enable();
                }
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    dout.HiSideRecovery.Enable();
                    dout.HiSideToolStem.Enable();
                }
            }
            else
            {
                if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                {
                    dout.LoSideRecovery.Enable();
                    dout.LoSideToolStem.Enable();
                }
                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                {
                    dout.HiSideRecovery.Enable();
                    dout.HiSideToolStem.Enable();
                }
            }            
        }

        void WaitForOtherROR_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleFail(Localization.TestAbortedFail, Localization.TestAbortedFailTH);
        }

        void WaitForOtherROR_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
                if (model.LowSideChargePressureCheckEnabled.ProcessValue && ((model.HiSidePercentage.ProcessValue > 99.5) || (model.HiSidePercentage.ProcessValue < 0.5)))
                {
                    //****mdb12/11/17
                    if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                    {
                        HiSideCharge.Start();
                    }
                    else//****mdb12/11/17
                    {
                        CloseLiquidServiceValveBeforeCharge.Start();
                    }
                }
                else
                {
                    if (port == Port.Blue)
                    {
                        if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                        {
                            HiSideCharge.Start();
                        }
                        else//****mdb12/11/17
                        {
                            if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                            {
                                if (model.HiSidePercentage.ProcessValue > 0.5)
                                {
                                    HiSideCharge.Start();
                                }
                                else
                                {
                                    LowSideCharge.Start();
                                }
                            }
                            else
                            {
                                LowSideCharge.Start();
                            }
                        }
                    }
                    else
                    {
                        if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                        {
                            if (model.HiSidePercentage.ProcessValue > 0.5)
                            {
                                HiSideCharge.Start();
                            }
                            else
                            {
                                LowSideCharge.Start();
                            }
                        }
                        else
                        {
                            LowSideCharge.Start();
                        }
                    }
                }
            
        }

        void WaitForOtherROR_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                if (Machine.Test[port].AbortTest)
                {
                    step.Fail();
                }
                else
                {
                    if ((!Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)||(Machine.Test[1].RateOfRisePassedFlag))
                    {
                        step.Pass();
                    }
                }
            }
            else
            {
                if (Machine.Test[port].AbortTest)
                {
                    step.Fail();
                }
                else
                {

                    if ((!Config.Mode.BlueCircuit2PortEnabled.ProcessValue)||(Machine.Test[0].RateOfRisePassedFlag))
                    {
                        step.Pass();
                    }
                }
            }

        }

        void WaitForOtherROR_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Pass();
        }

        void UpdateTime_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
 	        GreenLightOnTime=DateTime.Now;
            GreenLightOffTime=DateTime.Now;
        }

        void WaitForAcknowledge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.AlarmOutput.Disable();

            if (Machine.Test[port].FailToolRecoveryFlag)
            {
                if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
            }
            else
            {
                if ((Machine.Test[port].RecoverHiSideFlag) || (Machine.Test[port].RecoverLowSideFlag))
                {
                    if (Config.Mode.InsertValveCoresAfterChargeEnabled.ProcessValue)
                    {
                        InsertValveCores.Start();
                    }
                    else
                    {
                        if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
                    }
                    
                }
                else
                {
                    Reset.Start();
                }
            }
        }

        void InsertValveCores_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2Alarm.Disable();
            if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
        }

        void InsertValveCores_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 0.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.0)
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            else if (step.ElapsedTime.TotalSeconds < 1.5)
            {
                if (!IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Enable();
                }
            }
            else
            {
                if (IO.DOut.BlueCircuit2Alarm.Value)
                {
                    IO.DOut.BlueCircuit2Alarm.Disable();
                }
            }
            //if (IO.DIn.AcknowledgeButton1.Value)
            //{
            //    step.Pass();
            //}
            //else
            {
                if (port == Port.Blue)
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                        if (Machine.Test[0].MessageBoxFlag)
                        {
                            Machine.Cycle[0].bHideMessageBox = true;
                        }
                        step.Pass();
                        return;
                    }
                }
                else
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                        step.Pass();
                    }
                }
                if (IO.DIn.Acknowledge.Value)
                {
                    if (Machine.Test[0].MessageBoxFlag)
                    {
                        Machine.Cycle[0].bHideMessageBox = true;
                    }
                    step.Pass();
                    return;
                }
            }
        }

        void InsertValveCores_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }

            #region Make Message for MessageForm
            Int32 PoundsTotalCharge = Convert.ToInt32(MyStaticVariables.TotalCharge / 16.0 - 0.5);
            Int32 OuncesTotalCharge = Convert.ToInt32(MyStaticVariables.TotalCharge) - PoundsTotalCharge * 16;
            if (OuncesTotalCharge > 15)
            {
                OuncesTotalCharge = 0;
                PoundsTotalCharge = PoundsTotalCharge + 1;
            }

            Int32 PoundsActualCharge = Convert.ToInt32(MyStaticVariables.ActualCharge / 16.0 - 0.5);
            //Double OuncesActualCharge = Convert.ToInt32(MyStaticVariables.ActualCharge) - PoundsActualCharge * 16;
            Double OuncesActualCharge = MyStaticVariables.ActualCharge - Convert.ToDouble(PoundsActualCharge) * 16.0;

            if (OuncesActualCharge > 15.99)
            {
                OuncesActualCharge = 0.0;
                PoundsActualCharge = PoundsActualCharge + 1;
            }


            #endregion

            Machine.Cycle[0].bShowMessageFinalData = true;


        }

        void WaitToStartInitialEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            InitialEvac.Start();
        }

        void WaitToStartInitialEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 5.0)
            {
                if ((!Machine.Test[0].UsingRoughPumpForToolCheckFlag) && (!Machine.Test[1].UsingRoughPumpForToolCheckFlag))
                {
                    step.Pass();
                }
            }
        }

        void WaitToStartInitialEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;
        }

        void WaitToStartToolCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
            //{
            //    HiSideToolCheck.Start();
            //}
            //else
            //{
            //    if (Config.Mode.WhiteLowSideEnabled.ProcessValue)
            //    {
            //        LowSideToolCheck.Start();
            //    }
            //    else
            //    {
            //        CycleFail("WHITE No Tool is Enabled", "WHITE No Tool is Enabled");
            //    }
            //}
            if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue > 0.5)
                    {
                        HiSideToolCheck.Start();
                    }
                    else
                    {
                        LowSideToolCheck.Start();
                    }
                }
                else
                {
                    LowSideToolCheck.Start();
                }
            }
            else
            {
                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue > 0.5)
                    {
                        HiSideToolCheck.Start();
                    }
                    else
                    {
                        LowSideToolCheck.Start();
                    }
                }
                else
                {
                    LowSideToolCheck.Start();
                }
            }

        }

        void WaitToStartToolCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 2.0)
            {
                if ((!Machine.Test[0].UsingRoughPumpForToolCheckFlag) && (!Machine.Test[1].UsingRoughPumpForToolCheckFlag))
                {
                    step.Pass();
                }
            }            
        }

        void WaitToStartToolCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void RateOfRise_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuummTorr;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            double RORSetPoint;
            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))  // Late Leak Check 6/21/2016 TAS, per francisco
            {
                RORSetPoint = Config.Pressure.LateLeakCheckRORMaxSetPoint.ProcessValue;
            }
            else
            {
                RORSetPoint = model.ROR_Pressure_Check_Pressure_SetPointt.ProcessValue;
            }

            if (PartVacuum < RORSetPoint) // model.ROR_Pressure_Check_Pressure_SetPoint.ProcessValue)
            {
                AppendToToolTip($"ROR: {PartVacuum:0.0} < {RORSetPoint:0.0}");
                step.Pass();
            }
            else
            {
                AppendToToolTip($"ROR: {PartVacuum:0.0} > {RORSetPoint:0.0}");
                step.Fail();
            }
        }

        void ToolEvacuation_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ToolEvacuation_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ToolEvacuation_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ToolEvacuation_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void ToolEvacuation_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void HiSideToolCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            //****mdb 11/18/18
            //HiSideToolCheck_Failed
            string EventLogString;
            try
            {
                EventLogString = string.Format("Tool Check Pressure: {0:0} microns", IO.Signals.BluePartVacuum.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Tool Check Setpoint: {0:0} microns", Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18



            CycleNoTest(Localization.HiSideToolCheckFailed, Localization.HiSideToolCheckFailed);
            if (port == Port.Blue)
            {
                    Machine.Cycle[0].Reset.Start();
                
            }
            else
            {
                    Machine.Cycle[1].Reset.Start();
                
            }
        }

        void HiSideToolCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                if (Machine.Test[port].AbortTest)
                {
                    CycleFail(Localization.TestAborted, Localization.TestAbortedTH);
                }
                else
                {
                    if ((Machine.Test[port].ForceHiSideChargeFlag))
                    {
                        HiSideCharge.Start();
                    }
                    else
                    {
                        //if ((Config.Mode.BlueLowSideEnabled.ProcessValue)&&(model.BlueSideHiSidePercentage.ProcessValue<99.5))
                        if ((Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue))
                        {
                            LowSideToolCheck.Start();
                        }
                        else
                        {
                            if (Machine.Test[port].ForceChargeFlag)
                            {
                                //HiSideCharge.Start();
                                PrechargedUnitCheck.Start();
                            }
                            else
                            {
                                if (Machine.Test[port].RecoverUnitFlag)
                                {
                                    RecoverUnit.Start();
                                }
                                else
                                {
                                    PrechargedUnitCheck.Start();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (Machine.Test[port].AbortTest)
                {
                    CycleFail(Localization.TestAborted, Localization.TestAbortedTH);
                }
                else
                {
                    if (Machine.Test[port].ForceHiSideChargeFlag)
                    {
                        HiSideCharge.Start();
                    }
                    else
                    {
                        //if ((Config.Mode.WhiteLowSideEnabled.ProcessValue) && (model.HiSidePercentage.ProcessValue < 99.5))
                        if ((Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)&&(Config.Control.ChargeMode!=ChargeModes.PartialChargeEnd))
                        {
                            LowSideToolCheck.Start();
                        }
                        else
                        {
                            if (Machine.Test[port].ForceChargeFlag)
                            {
                                //HiSideCharge.Start();
                                PrechargedUnitCheck.Start();
                            }
                            else
                            {
                                if (Machine.Test[port].RecoverUnitFlag)
                                {
                                    RecoverUnit.Start();
                                }
                                else
                                {
                                    PrechargedUnitCheck.Start();
                                }
                            }
                        }
                    }
                }
            }
        }

        void HiSideToolCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if (PartVacuum < Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                AppendToToolTip($"Hi Side Tool Check: {PartVacuum:0.0} > {Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue:0.0}");
                step.Fail();
            }
        }

        void HiSideToolCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if ((PartVacuum > Config.Pressure.Tool_Quick_Check_Pressure_SetPoint.ProcessValue) && (step.ElapsedTime.TotalSeconds > Config.Time.Tool_Quick_Check_Pressure_Delay.ProcessValue))
            {
                //step.Fail();
            }
            else
            {
                if (step.ElapsedTime.TotalSeconds > 2.0)
                {
                    if (PartVacuum < Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue)
                    {
                        AppendToToolTip($"Hi Side Tool Check: {PartVacuum:0.0} < {Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue:0.0}");
                        step.Pass();
                    }
                }
            }            
        }

        void HiSideToolCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			MyStaticVariables.TimeTo50PsiBlue.Clear();
			MyStaticVariables.EndingRecoveryPressBlue.Clear();
            Machine.Test[port].Result = "";

			Machine.Test[port].UsingRoughPumpForToolCheckFlag = true;
            step.ParametersToDisplay.Add(Config.Pressure.Tool_Check_Pressure_SetPoint);
            step.SignalsToDisplay.Add(IO.Signals.BluePartVacuum);
            IO.DOut.EvacPumpEnable.Enable();

            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();

            dout.LoSideEvac.Disable();
            Thread.Sleep(500);
            dout.HiSideEvac.Enable();
                       
            //dout.UnitEvac.Enable();
            //IO.DOut.CrossOverValve.Enable();

            IO.DOut.BasePressureTestValve.Enable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
            //dout.RateOfRiseValve.Enable();
            //IO.DOut.VacuumPumpEnable.Enable();
            //IO.DOut.HighSideEvacPump.Enable();
        }

        void LowSideToolCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(Localization.LowSideToolCheckFailed, Localization.LowSideToolCheckFailed);
            if (port == Port.Blue)
            {
                if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                {
                    Machine.Cycle[1].Reset.Start();
                }
            }
            else
            {
                if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                {
                    Machine.Cycle[0].Reset.Start();
                }
            }

        }

        void LowSideToolCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
            if (Machine.Test[port].AbortTest)
            {
                CycleFail(Localization.TestAborted, Localization.TestAbortedTH);
            }
            else
            {
                
                    if (Machine.Test[port].ForceLowSideChargeFlag)
                    {
                        LowSideCharge.Start();
                    }
                    else
                    {
                        if (Machine.Test[port].ForceChargeFlag)
                        {
                            if (port == Port.Blue)
                            {
                                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                                {
                                    if (model.HiSidePercentage.ProcessValue > 0.5)
                                    {
                                        //HiSideCharge.Start();
                                        PrechargedUnitCheck.Start();
                                    }
                                    else
                                    {
                                        //LowSideCharge.Start();
                                        PrechargedUnitCheck.Start();
                                    }
                                }
                                else
                                {
                                    //LowSideCharge.Start();
                                    PrechargedUnitCheck.Start();
                                }
                            }
                            else
                            {
                                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                                {
                                    if (model.HiSidePercentage.ProcessValue > 0.5)
                                    {
                                        //HiSideCharge.Start();
                                        PrechargedUnitCheck.Start();
                                    }
                                    else
                                    {
                                        //LowSideCharge.Start();
                                        PrechargedUnitCheck.Start();
                                    }
                                }
                                else
                                {
                                    //LowSideCharge.Start();
                                    PrechargedUnitCheck.Start();
                                }
                            }

                        }
                        else
                        {
                            if (Machine.Test[port].RecoverUnitFlag)
                            {
                                RecoverUnit.Start();
                            }
                            else
                            {
                                PrechargedUnitCheck.Start();
                            }
                        }
                    }
                
            }
        }

        void LowSideToolCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if (PartVacuum < Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                AppendToToolTip($"Low Side Tool Check: {PartVacuum:0.0} > {Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue:0.0}");
                step.Fail();
            }            
        }

        void LowSideToolCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if ((PartVacuum > Config.Pressure.Tool_Quick_Check_Pressure_SetPoint.ProcessValue) && (step.ElapsedTime.TotalSeconds > Config.Time.Tool_Quick_Check_Pressure_Delay.ProcessValue))
            {
                //step.Fail();
            }
            else
            {
                if (step.ElapsedTime.TotalSeconds > 2.0)
                {
                    if (PartVacuum < Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue)
                    {
                        AppendToToolTip($"Low Side Tool Check: {PartVacuum:0.0} < {Config.Pressure.Tool_Check_Pressure_SetPoint.ProcessValue:0.0}");
                        step.Pass();
                    }
                }
            }            

        }

        void LowSideToolCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UsingRoughPumpForToolCheckFlag = true;
            step.SignalsToDisplay.Add(signal.PartVacuum);
            step.ParametersToDisplay.Add(Config.Pressure.Tool_Check_Pressure_SetPoint);

            IO.DOut.EvacPumpEnable.Enable();

            dout.LoSideCharge.Disable();
            dout.LoSideRecovery.Disable();
            dout.LoSideToolStem.Disable();

            dout.HiSideEvac.Disable();
            Thread.Sleep(500);
            dout.LoSideEvac.Enable();


            IO.DOut.BasePressureTestValve.Enable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
            //dout.UnitEvac.Enable();
            //dout.RateOfRiseValve.Enable();
            //IO.DOut.CrossOverValve.Enable();
            //IO.DOut.VacuumPumpEnable.Enable();
            //IO.DOut.LowSideEvacPump.Enable();

        }

        void PrechargedUnitCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].PreChargeUnitPressCheckResult = "Fail";

            //****mdb 11/18/18
            //PrechargedUnitCheck_Failed
            string EventLogString;
            try
            {
                EventLogString = string.Format("Precharge Check Pressure: {0:0} psig", IO.Signals.BlueHiSideToolPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);

                    EventLogString = string.Format("Precharge Check Setpoint: {0:0} psig", model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue);
                    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                


                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18


            CycleNoTest(Localization.PrechargedUnitCheckFailed, Localization.PrechargedUnitCheckFailed);
        }

        void PrechargedUnitCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].PreChargeUnitPressCheckResult = "Pass";
            if (port == Port.Blue)
            {
                    if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                    {
                        if (Config.Mode.HiSideConnectorCheckEnabled.ProcessValue)
                        {
                            HiSideConnectorCheck.Start();
                        }
                        else
                        {
                            WaitToStartInitialEvac.Start();
                        }
                    }
                    else
                    {
                        if (Config.Mode.LowSideConnectorCheckEnabled.ProcessValue)
                        {
                            LowSideConnectorCheck.Start();
                        }
                        else
                        {
                            WaitToStartInitialEvac.Start();
                        }
                    }
                
            }
            else//white port
            {
                    if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                    {
                        if (Config.Mode.HiSideConnectorCheckEnabled.ProcessValue)
                        {
                            HiSideConnectorCheck.Start();
                        }
                        else
                        {
                            InitialEvac.Start();
                        }
                    }
                    else
                    {
                        if (Config.Mode.LowSideConnectorCheckEnabled.ProcessValue)
                        {
                            LowSideConnectorCheck.Start();
                        }
                        else
                        {
                            InitialEvac.Start();
                        }
                    }
                
            }            
        }

        void PrechargedUnitCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].PreChargeUnitPressCheckPressure = IO.Signals.BlueHiSideToolPressure.Value;
            double PartPressure;
            if(port==Port.Blue)
            {
                PartPressure = IO.Signals.BlueHiSideToolPressure.Value;
            }
            else
            {
                PartPressure = IO.Signals.WhiteHiSideToolPressure.Value;
            }

            
                if (PartPressure > model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue)
            {
                AppendToToolTip($"Precharge Check: {PartPressure:0.0} > {model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue:0.0}");
                step.Fail();
                }
                else
            {
                AppendToToolTip($"Precharge Check: {PartPressure:0.0} < {model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue:0.0}");
                step.Pass();
                }
            
        }

        void PrechargedUnitCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].PreChargeUnitPressCheckPressure = IO.Signals.BlueHiSideToolPressure.Value;
            Machine.Test[port].PreChargeUnitPressCheckTime = step.ElapsedTime.TotalSeconds;
        }

        void PrechargedUnitCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.SignalsToDisplay.Add(signal.HiSideToolPressure);
            step.ParametersToDisplay.Add(model.Precharge_Unit_Check_Pressure_SetPoint);
            Machine.Test[port].PreChargeUnitPressCheckSetPoint = model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue;
            dout.LoSideEvac.Disable();
            dout.HiSideEvac.Disable();
            
            Thread.Sleep(500);
            dout.HiSideToolStem.Enable();
        }

        void HiSideConnectorCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(Localization.HiSideToolConnectorCheckFailed, Localization.HiSideToolConnectorCheckFailed);
            if (port == Port.Blue)
            {
                if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                {
                    Machine.Cycle[1].Reset.Start();
                }
            }
            else
            {
                if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                {
                    Machine.Cycle[0].Reset.Start();
                }
            }

        }

        void HiSideConnectorCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                {
                    LowSideConnectorCheck.Start();
                }
                else
                {
                    //InitialEvac.Start();
                    WaitToStartInitialEvac.Start();
                    
                }
            }
            else
            {
                if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                {
                    LowSideConnectorCheck.Start();
                }
                else
                {
                    InitialEvac.Start();
                }
            }
        }

        void HiSideConnectorCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if (PartVacuum > Config.Pressure.Connector_Check_Pressure_SetPoint.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                step.Fail();
            }            
        }

        void HiSideConnectorCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
        }

        void HiSideConnectorCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UsingRoughPumpForToolCheckFlag = true;

            dout.LoSideToolStem.Disable();
            dout.LoSideEvac.Disable();

            Thread.Sleep(500);
            dout.HiSideToolStem.Enable();
            dout.HiSideEvac.Enable();

            dout.RateOfRiseValve.Enable();
            dout.UnitEvac.Enable();
            //IO.DOut.VacuumPumpEnable.Enable();
            IO.DOut.EvacPumpEnable.Enable();

        }

        void LowSideConnectorCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(Localization.LoSideToolConnectorCheckFailed, Localization.LoSideToolConnectorCheckFailed);
            if (port == Port.Blue)
            {
                if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                {
                    Machine.Cycle[1].Reset.Start();
                }
            }
            else
            {
                if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                {
                    Machine.Cycle[0].Reset.Start();
                }
            }


        }

        void LowSideConnectorCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (port == Port.Blue)
            {
                WaitToStartInitialEvac.Start();
            }
            else
            {
                InitialEvac.Start();
            }
        }

        void LowSideConnectorCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuum;
            }
            else
            {
                PartVacuum = IO.Signals.WhitePartVacuum;
            }

            if (PartVacuum > Config.Pressure.Connector_Check_Pressure_SetPoint.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                step.Fail();
            }                        
        }

        void LowSideConnectorCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void LowSideConnectorCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].UsingRoughPumpForToolCheckFlag = true;

            dout.HiSideToolStem.Disable();
            dout.HiSideEvac.Disable();

            Thread.Sleep(500);
            dout.LoSideToolStem.Enable();
            dout.LoSideEvac.Enable();

            //dout.UnitEvac.Enable();
            dout.UnitEvac.Enable();

            IO.DOut.EvacPumpEnable.Enable();

        }



        void InitialEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].InitialEvacResult = "Pass";

            if (port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress)
            {

            }
            else if (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress)
            {

            }
            else
                FinalEvac.Start();
        }

        void InitialEvac_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].InitialEvacResult = "Fail";

            //****mdb 11/18/18
            //InitialEvac_Failed
            string EventLogString;
            try
            {
                EventLogString = string.Format("Initial Evac Pressure: {0:0} microns", IO.Signals.BluePartVacuummTorr.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Initial Evac Setpoint: {0:0} microns", model.Initial_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18


            CycleNoTest(Localization.IntialEvacFailed, Localization.IntialEvacFailed);
        }

        void InitialEvac_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuummTorr;
            }
            //else
            //{
            //    PartVacuum = IO.Signals.WhitePartVacuum;
            //}

            //if (PartVacuum < model.Initial_Evac_Pressure_SetPoint.ProcessValue)
            //{
            //    step.Pass();
            //}
            //else
            {
                AppendToToolTip($"Initial Evac: {IO.Signals.BluePartVacuummTorr.Value:0.0} > {model.Final_Evac_Pressure_SetPointt.ProcessValue}");

                step.Fail();
            }
        }

        bool firstTime;
        void InitialEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > 2)
            {
                if (firstTime)
                {
                    Machine.Test[port].StartInitialEvacPressure = IO.Signals.BluePartVacuum.Value;
                    firstTime = false;
                }
                Machine.Test[port].InitialEvacTime = step.ElapsedTime.TotalSeconds;
                Machine.Test[port].InitialEvacPressure = IO.Signals.BluePartVacuummTorr.Value;
                //fail on a high intial evac fault, quit early if the pressure goes low
                if (step.ElapsedTime.TotalSeconds > model.Initial_Evac_Delay.ProcessValue)
                {
                    if (IO.Signals.BluePartVacuummTorr.Value > model.Initial_Evac_Pressure_SetPointt.ProcessValue)
                    {
                        AppendToToolTip($"Initial Evac: After {step.ElapsedTime.TotalSeconds:0.0}s, {IO.Signals.BluePartVacuummTorr.Value:0.0} > {model.Initial_Evac_Pressure_SetPointt.ProcessValue:0.0}");
                        step.Fail();
                    }
                    else
                    {

                        if (IO.Signals.BluePartVacuummTorr.Value < model.Final_Evac_Pressure_SetPointt.ProcessValue)
                        {
                            AppendToToolTip($"Initial Evac: {IO.Signals.BluePartVacuummTorr.Value:0.0} < {model.Final_Evac_Pressure_SetPointt.ProcessValue}");
                            step.Pass();
                        }
                    }
                }
            }
        }

        void InitialEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            firstTime = true;
            step.SignalsToDisplay.Add(signal.PartVacuummTorr);
            step.ParametersToDisplay.Add(model.Final_Evac_Pressure_SetPointt);
            Machine.Test[port].InitialEvacSetpoint = model.Initial_Evac_Delay.ProcessValue;
            Machine.Test[port].FinalEvacSetpoint = model.Final_Evac_Pressure_SetPointt.ProcessValue;
            IO.Signals.BlueSetPoint.Value = model.Final_Evac_Pressure_SetPointt.ProcessValue;

            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;

            MyStaticVariables.EvacStartTime = DateTime.Now;

            if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    IO.DOut.HighSideRateOfRiseValve.Enable();
                    IO.DOut.BasePressureTestValve.Enable();
                }
                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                {
                    IO.DOut.HighSideRateOfRiseValve.Enable();
                    IO.DOut.BasePressureTestValve.Enable();
                }
                Machine.Test[port].EvacPressure = IO.Signals.BluePartVacuum.Value;
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    dout.HiSideToolStem.Enable();
                    dout.HiSideEvac.Enable();
                }
                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                {
                    dout.LoSideToolStem.Enable();
                    dout.LoSideEvac.Enable();
                }
            }
            else
            {
                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                {
                    //IO.DOut.CrossOverValve.Enable();
                    //IO.DOut.HighSideRateOfRiseValve.Enable();
                }
                if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                {
                    //IO.DOut.BasePressureTestValve.Enable();
                    //IO.DOut.LowSideRateOfRiseValve.Enable();
                }

                Machine.Test[port].EvacPressure = IO.Signals.WhitePartVacuum.Value;
                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                {
                    dout.HiSideToolStem.Enable();
                    dout.HiSideEvac.Enable();
                }
                if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                {
                    dout.LoSideToolStem.Enable();
                    dout.LoSideEvac.Enable();
                }
            }
        }

        void FinalEvac_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].FinalEvacResult = "Fail";
            Machine.Test[port].EvacTimeBeforeLastRORResult = "Fail";

            if (port == Port.Blue)
            {
                String EventLogString = string.Format("Evac Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.BluePartVacuum.Value, model.Final_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            else
            {
                String EventLogString = string.Format("Evac Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.WhitePartVacuum.Value, model.Final_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }

            //****mdb 11/18/18
            //FinalEvac_Failed

            try
            {
                string EventLogString;
                EventLogString = string.Format("Final Evac Pressure: {0:0} microns", IO.Signals.BluePartVacuum.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Final Evac Setpoint: {0:0} microns", model.Final_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18


            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))  // Late Leak Check 6/21/2016 TAS, per francisco
            {
                CycleNoTest(Localization.LateLeakFailed_Prompt, Localization.LateLeakFailed_TH);
            }
            else
                CycleNoTest(Localization.FinalEvacFailed, Localization.FinalEvacFailed);
        }

        void FinalEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].FinalEvacResult = "Pass";
            Machine.Test[port].EvacTimeBeforeLastRORResult = "Pass";

            if (port == Port.Blue)
            {
                String EventLogString = string.Format("Evac Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.BluePartVacuummTorr.Value, model.Final_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            else
            {
                String EventLogString = string.Format("Evac Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.WhitePartVacuum.Value, model.Final_Evac_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }

            if (Config.Mode.BasePressureCheckEnabled.ProcessValue)
            {
                BasePressureCheck.Start();
            }
            else
            {
                RateOfRise.Start();
            }
        }

        void FinalEvac_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum, EvacTarget;
            //if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuummTorr;
            }
            //else
            //{
            //    //PartVacuum = IO.Signals.WhitePartVacuum;
            //}

            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))
            {
                EvacTarget = Config.Pressure.LateLeakCheckRORMaxSetPoint.ProcessValue;
            }
            else
                EvacTarget = model.Final_Evac_Pressure_SetPointt.ProcessValue;

            if (PartVacuum < EvacTarget) // model.Final_Evac_Pressure_SetPoint.ProcessValue) TAS 6-21-2016 Francisco request
            {
                AppendToToolTip($"Final Evac: {PartVacuum:0.0} < {EvacTarget:0.0}");

                step.Pass();
            }
            else
            {
                AppendToToolTip($"Final Evac: {PartVacuum:0.0} > {EvacTarget:0.0}");
                step.Fail();
            }
        }

        void FinalEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].FinalEvacTime = step.ElapsedTime.TotalSeconds;
            Machine.Test[port].FinalEvacPressure = IO.Signals.BluePartVacuummTorr.Value;

            Machine.Test[port].EvacTimeBeforeLastROR = Machine.Test[port].InitialEvacTime + Machine.Test[port].FinalEvacTime;
            Machine.Test[port].EvacPressBeforeLastROR = IO.Signals.BluePartVacuummTorr.Value;

            if (port == Port.Blue)
            {
                Machine.Test[port].EvacPressure = IO.Signals.BluePartVacuummTorr.Value;
            }
            //else
            //{
            //    //Machine.Test[port].EvacPressure = IO.Signals.WhitePartVacuum.Value;
            //}
            
        }

        void FinalEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.SignalsToDisplay.Add(signal.PartVacuummTorr);
            step.ParametersToDisplay.Add(model.Final_Evac_Pressure_SetPointt);
            Machine.Test[port].FinalEvacSetpoint = model.Final_Evac_Pressure_SetPointt.ProcessValue;

            Machine.Test[port].FinalEvacTimeForPlot = model.Final_Evac_Delay.ProcessValue;
            Machine.Cycle[port].bFinalEvacLimitsForDataPlot = true;

            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))
            {
                step.TimeDelay = Config.Time.LateLeakCheckEvacDelay;
            }
            else
                step.TimeDelay=model.Final_Evac_Delay;
        }

        void LateLeakCheckEvac_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void LateLeakCheckEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void LateLeakCheckEvac_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void LateLeakCheckEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void LateLeakCheckEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void BasePressureCheck_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].BasePressBeforeLastRORResult = "Fail";
            CycleNoTest(Localization.BasePressureCheckFailed, Localization.BasePressureCheckFailed);
        }

        void BasePressureCheck_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].BasePressBeforeLastRORResult = "Pass";
            RateOfRise.Start();
        }

        void BasePressureCheck_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            double PartVacuum;
            //if (port == Port.Blue)
            {
                PartVacuum = IO.Signals.BluePartVacuummTorr;
            }
            //else
            //{
            //    PartVacuum = IO.Signals.WhitePartVacuum;
            //}
            if (PartVacuum < Config.Pressure.Base_Pressure_Check_Pressure_SetPoint.ProcessValue)
            {
                step.Pass();
            }
            else
            {
                step.Fail();
            }
        }

        void BasePressureCheck_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].BaseTimeBeforeLastROR = step.ElapsedTime.TotalSeconds;
            Machine.Test[port].BasePressBeforeLastROR = IO.Signals.BluePartVacuum.Value;
        }

        void BasePressureCheck_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {           

            ////dout.UnitEvac.Disable();
            ////dout.RateOfRiseValve.Enable();
            //IO.DOut.CrossOverValve.Disable();
            //IO.DOut.BasePressureTestValve.Disable();
            IO.DOut.BasePressureTestValve.Disable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
        }

        void RateOfRise_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].RORResult = "Fail";

            //IO.DOut.CrossOverValve.Disable();
            if (port == Port.Blue)
            {
                String EventLogString = string.Format("ROR Pressure: {0:0.000} mTorr, Setpoint: {0:0.000} mTorr", IO.Signals.BluePartVacuummTorr.Value, model.ROR_Pressure_Check_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            //else
            //{
            //    String EventLogString = string.Format("ROR Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.WhitePartVacuum.Value, model.ROR_Pressure_Check_Pressure_SetPoint.ProcessValue);
            //    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            //}
            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))  // Late Leak Check 6/21/2016 TAS, per francisco
            {
                CycleNoTest(Localization.LateLeakFailed_Prompt, Localization.LateLeakFailed_TH);
            }
            else
                RepeatEvac.Start();
        }

        void RateOfRise_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.BlueStartingCountsForDataBase = 0;
            MyStaticVariables.BlueEndingCountsForDatabase = 0;

            Machine.Test[port].RORResult = "Pass";

            //IO.DOut.CrossOverValve.Disable();
            Machine.Test[port].RateOfRisePassedFlag = true;
            if (port == Port.Blue)
            {
                String EventLogString = string.Format("ROR Pressure: {0:0.000} mTorr, Setpoint: {0:0.000} mTorr", IO.Signals.BluePartVacuummTorr.Value,model.ROR_Pressure_Check_Pressure_SetPointt.ProcessValue);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            //else
            //{
            //    String EventLogString = string.Format("ROR Pressure: {0:0.000} Torr, Setpoint: {0:0.000} Torr", IO.Signals.WhitePartVacuum.Value, model.ROR_Pressure_Check_Pressure_SetPoint.ProcessValue);
            //    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            //}

            if ((port == Port.Blue && MyStaticVariables.LateLeakCheckBlueTestInProgress) || (port == Port.White && MyStaticVariables.LateLeakCheckWhiteTestInProgress))  // Late Leak Check 6/21/2016 TAS, per francisco
            {
                CyclePass(Localization.LateLeakPassed_Prompt, Localization.LateLeakPassed_TH);
            }
            else
                WaitForOtherROR.Start();
        }

        void RateOfRise_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].RORTime = step.ElapsedTime.TotalSeconds;
            if (port == Port.Blue)
            {
                Machine.Test[port].RORPressure = IO.Signals.BluePartVacuummTorr.Value;
            }
            //else
            //{
            //    Machine.Test[port].RORPressure = IO.Signals.WhitePartVacuum.Value;
            //}
        }

        void RateOfRise_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.SignalsToDisplay.Add(signal.PartVacuummTorr);
            step.ParametersToDisplay.Add(model.ROR_Pressure_Check_Pressure_SetPointt);
            Machine.Test[port].RORSetpoint = model.ROR_Pressure_Check_Pressure_SetPointt.ProcessValue;
            IO.Signals.BlueSetPoint.Value = model.ROR_Pressure_Check_Pressure_SetPointt.ProcessValue;
            Machine.Test[port].RORDelayTimeForPlot=model.ROR_Pressure_Check_Delay.ProcessValue;
            Machine.Cycle[Port.Blue].bRORLimitsForDataPlot = true;

            //dout.RateOfRiseValve.Disable();
            Thread.Sleep(500);
            
            //dout.UnitEvac.Enable();
            IO.DOut.BasePressureTestValve.Enable();
            IO.DOut.HighSideRateOfRiseValve.Disable();
            ////IO.DOut.LowSideRateOfRiseValve.Disable();
            //if (port == Port.Blue)
            //{
            //    if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
            //    {
            //        IO.DOut.CrossOverValve.Enable();
            //    }
            //}
            //else
            //{
            //    if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
            //    {
            //        IO.DOut.CrossOverValve.Enable();
            //    }
            //}            
        }

        void RepeatEvac_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].EvacTimeBeforeLastRORResult = "Fail";
            CycleNoTest(Localization.RepeatEvacFailed, Localization.RepeatEvacFailed);
        }

        void RepeatEvac_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].EvacTimeBeforeLastRORResult = "Pass";
            if (Config.Mode.BasePressureCheckEnabled.ProcessValue)
            {
                BasePressureCheck.Start();
            }
            else
            {
                RateOfRise.Start();
            }
        }

        void RepeatEvac_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].RepeatEvacTime = Machine.Test[port].RepeatEvacTime + step.ElapsedTime.TotalSeconds;

            AppendToToolTip($"Repeat Evac: {IO.Signals.BluePartVacuummTorr.Value:0.0} ");
            step.Pass();
        }

        void RepeatEvac_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].EvacTimeBeforeLastROR = Machine.Test[port].InitialEvacTime + Machine.Test[port].FinalEvacTime + Machine.Test[port].RepeatEvacTime + step.ElapsedTime.TotalSeconds;
            Machine.Test[port].EvacPressBeforeLastROR = IO.Signals.BluePartVacuummTorr.Value;

            if (port == Port.Blue)
            {
                Machine.Test[port].EvacPressure = IO.Signals.BluePartVacuummTorr.Value;
            }
            //else
            //{
            //    Machine.Test[port].EvacPressure = IO.Signals.WhitePartVacuum.Value;
            //}
            TimeSpan EvacTime = DateTime.Now - MyStaticVariables.EvacStartTime;
            if (EvacTime.TotalSeconds > model.Maximum_Evac_Delay)
            {
                step.Fail();
            }
        }

        void RepeatEvac_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //dout.UnitEvac.Enable();
            //dout.RateOfRiseValve.Enable();
            IO.DOut.HighSideRateOfRiseValve.Enable();
            IO.DOut.BasePressureTestValve.Enable();
        }

        void HoseFillDelay_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void HoseFillDelay_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void HoseFillDelay_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void HoseFillDelay_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void HiSideCharge_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ChargeResult = "Fail";

            IO.DOut.BlueCircuit2HiSideCharge.Disable();
            IO.DOut.BlueCircuit2LoSideCharge.Disable();

            string EventLogString;
            if (port == Port.Blue)
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.BlueSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            else
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.WhiteSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }


            //****mdb 11/18/18
            //HighSideCharge_Failed
            try
            {
                EventLogString = string.Format("Charge Amount: {0:0.00} lbs", IO.Signals.BluePartChargeInPounds.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Setpoint: {0:0.00} lbs", IO.Signals.BlueSetPoint.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Flow: {0:0.00} oz/s", IO.Signals.BluePartFlow.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Target: {0:0.00} lbs", model.TotalCharge.ProcessValue / 16.0);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18


            //CycleFail(Localization.HiSideChargeFailed, Localization.HiSideChargeFailed);
            CycleFail(Machine.Test[port].TestResult, Machine.Test[port].TestHistory);
        }

        void HiSideCharge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ChargeResult = "Pass";

            if (port == Port.Blue)
            {
                    if (Machine.Test[port].ForceHiSideChargeFlag)
                    {
                        Machine.Test[port].PassedChargeFlag = true;
                        ToolDrainDelay.Start();
                    }
                    else
                    {
                        if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                        {

                            if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                            {
                                LowSideCharge.Start();
                            }
                            else
                            {
                                if (model.HiSidePercentage.ProcessValue < 99.5)
                                {
                                    LowSideCharge.Start();
                                }
                                else
                                {
                                    Machine.Test[port].PassedChargeFlag = true;
                                    ToolDrainDelay.Start();
                                }
                            }
                        }
                        else
                        {
                            Machine.Test[port].PassedChargeFlag = true;
                            ToolDrainDelay.Start();
                        }
                    }
                
            }
            else
            {
                if (Machine.Test[port].ForceHiSideChargeFlag)
                {
                    Machine.Test[port].PassedChargeFlag = true;
                    ToolDrainDelay.Start();
                }
                else
                {
                    if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                    {
                        if (model.HiSidePercentage.ProcessValue < 99.5)
                        {
                            LowSideCharge.Start();
                        }
                        else
                        {
                            Machine.Test[port].PassedChargeFlag = true;
                            ToolDrainDelay.Start();
                        }
                    }
                    else
                    {
                        Machine.Test[port].PassedChargeFlag = true;
                        ToolDrainDelay.Start();
                    }
                }
            }
        }

        void HiSideCharge_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].TestResult = Localization.MaximumTimeFailed;
            Machine.Test[port].TestHistory = Localization.MaximumTimeTH;

            step.Fail();
        }

        void HiSideCharge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].HighSideChargeTime = step.ElapsedTime.TotalSeconds;
            Machine.Test[port].ChargeTime = step.ElapsedTime.TotalSeconds;
            Machine.Test[port].ActualChargeWeight = IO.Signals.BluePartChargeByCounter.Value;
            MyStaticVariables.ActualCharge = Machine.Test[port].ActualChargeWeight;

            Machine.Test[port].RefSupplyPressDuringCharge = IO.Signals.BlueSupplyPressure.Value;
            
                //****mdb12/11/17
                //if (model.UnitType.ProcessValue.Contains("HP") && Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                {
                    //do not check the pressure if a heat pump unit which will switch on low flow
                }
                else//mdb12/11/17
                {
                    if (model.LowSideChargePressureCheckEnabled.ProcessValue)
                    {
                        if (model.HiSidePercentage.ProcessValue > 99.5)
                        {
                            //check low side gun pressure, if it goes up, fail
                            Machine.Test[port].LowSideChargePressureCheckPressureValue = IO.Signals.BlueLoSideToolPressure.Value;
                            double LowSidePressureChange = Machine.Test[port].LowSideChargePressureCheckPressureValue - Machine.Test[port].LowSideChargePressureCheckPressureStart;
                            if (LowSidePressureChange > model.Low_Side_Charge_Pressure_Check_SetPoint.ProcessValue)
                            {

                            AppendToToolTip($"Hi Side Charge: Low Side Prs Incrs. {LowSidePressureChange:0.0}");
                                Machine.Test[port].TestResult = Localization.LowSideServiceValveOpen;
                                Machine.Test[port].TestHistory = Localization.LowSideServiceValveOpen;

                                step.Fail();
                            }
                        }
                    }
                }

                double PartFlow;
                if (port == Port.Blue)
                {
                    PartFlow = IO.Signals.BluePartFlow.Value;
                }
                else
                {
                    PartFlow = IO.Signals.WhitePartFlow.Value;
                }

                if (PartFlow < Config.Flow.Minimum_Flowmeter_Rate.ProcessValue)
                {
                }
                else
                {
                    Machine.Test[port].LowFlowAlarmStartTime = DateTime.Now;
                }
                TimeSpan LowFlowAlarmTime = DateTime.Now - Machine.Test[port].LowFlowAlarmStartTime;

                if (Machine.Test[port].HiSideOnlyCharge)
                {
                    //save last flow
                    if (!Machine.Test[port].SavedLastFlow)
                    {
                        if (port == Port.Blue)
                        {
                            if (IO.Signals.BlueHiSideCounter.Value < 600)
                            {
                                Machine.Test[port].SavedLastFlow = true;

                                //adjust offset if enabled
                                if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue && (Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue > Config.Flow.Minimum_Flowmeter_Rate.ProcessValue) && (Machine.Test[port].LastFlowValue < 5.0))
                                {
                                    Machine.Test[port].CounterStopValueHiSide = Machine.Test[port].CounterStopValueHiSide - Convert.ToInt32((IO.Signals.BluePartFlow.Value - Machine.Test[port].LastFlowValue) * Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue);
                                    Machine.Cycle[port].bLoadHiSideLimit = true;
                                }
                                Machine.Test[port].LastFlowValue = IO.Signals.BluePartFlow.Value;
                            }
                        }
                        else
                        {
                            if (IO.Signals.WhiteHiSideCounter.Value < 600)
                            {
                                Machine.Test[port].SavedLastFlow = true;

                                //adjust offset if enabled
                                if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue)
                                {
                                    Machine.Test[port].CounterStopValueHiSide = Machine.Test[port].CounterStopValueHiSide - Convert.ToInt32((IO.Signals.WhitePartFlow.Value - Machine.Test[port].LastFlowValue) * Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue);
                                    Machine.Cycle[port].bLoadHiSideLimit = true;

                                }
                                Machine.Test[port].LastFlowValue = IO.Signals.WhitePartFlow.Value;
                            }
                        }
                    }
                }

                double PartCharge;
                if (port == Port.Blue)
                {
                    PartCharge = IO.Signals.BluePartCharge.Value - Machine.Test[port].HiSideBatchStart;
                }
                else
                {
                    PartCharge = IO.Signals.WhitePartCharge.Value - Machine.Test[port].HiSideBatchStart;
                }
                double OverChargeLimit;
                if (port == Port.Blue)
                {
                    if ((Machine.Test[port].ForceHiSideChargeFlag) || (!Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue))
                    {
                        OverChargeLimit = (Config.Flow.Maximum_Over_Charge_Percentage.ProcessValue / 100.0) * model.TotalCharge.ProcessValue;//oz
                    }
                    else
                    {
                        OverChargeLimit = (Config.Flow.Maximum_Over_Charge_Percentage.ProcessValue / 100.0) * (model.HiSidePercentage.ProcessValue / 100.0) * model.TotalCharge.ProcessValue;//oz
                    }
                }
                else
                {
                    if ((Machine.Test[port].ForceHiSideChargeFlag) || (!Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue))
                    {
                        OverChargeLimit = (Config.Flow.Maximum_Over_Charge_Percentage.ProcessValue / 100.0) * model.TotalCharge.ProcessValue;//oz
                    }
                    else
                    {
                        OverChargeLimit = (Config.Flow.Maximum_Over_Charge_Percentage.ProcessValue / 100.0) * (model.HiSidePercentage.ProcessValue / 100.0) * model.TotalCharge.ProcessValue;//oz
                    }
                }
                double MaximumTime = OverChargeLimit / Config.Flow.Average_Charge_Rate.ProcessValue;

                Machine.Test[port].ChargeTimeoutDelay = MaximumTime;

                //open loside charge valve 5 oz early
                if (port == Port.Blue)
                {
                    if ((IO.Signals.BlueHiSideCounter.Value < (Machine.Test[port].CounterStopValueHiSide + 100)) && (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue) && (!Machine.Test[port].ForceHiSideChargeFlag) && (model.HiSidePercentage.ProcessValue < 99.5))
                    {
                        Machine.Cycle[port].bEnableLowSideCharge = true;
                    }
                }
                else
                {
                    if ((IO.Signals.WhiteHiSideCounter.Value < (Machine.Test[port].CounterStopValueHiSide + 100)) && (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue) && (!Machine.Test[port].ForceHiSideChargeFlag) && (model.HiSidePercentage.ProcessValue < 99.5))
                    {
                        Machine.Cycle[port].bEnableLowSideCharge = true;
                    }
                }


            double tempMaxToolPressure =Config.Pressure.MaximumBlueToolPressureDuringCharge.ProcessValue;


            //****mdb12/11/17
            if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue &&
                    (PartFlow < model.FlowRateSwitch.ProcessValue) &&
                    (step.ElapsedTime.TotalSeconds > 5.0))
                {
                    //****mdb 2/20/18
                    //if (PartFlow < Config.Flow.HP_Flowmeter_Switch_SetPoint.ProcessValue)
                            Machine.Cycle[port].bEnableLowSideCharge = true;
                            step.Pass();
                            return;
                }
                else if (!Config.Mode.HP_SwitchChargeOnFlow.ProcessValue &&
                         (LowFlowAlarmTime.TotalSeconds > 3.0) && (step.ElapsedTime.TotalSeconds > 5.0))
                {
                    //fail on minimum rate error
                    //if ((PartFlow < Config.Flow.Minimum_Flowmeter_Rate.ProcessValue) && (step.ElapsedTime.TotalSeconds > 5.0))
                    Machine.Test[port].TestResult = Localization.LowFlowFailed;
                    Machine.Test[port].TestHistory = Localization.LowFlowTH;

                    step.Fail();
                }
                else if (step.ElapsedTime.TotalSeconds > MaximumTime)
                {
                    //fail on timeout based on rate (uses Elapsed Time)
                    Machine.Test[port].TestResult = Localization.MaximumTimeFailed;
                    Machine.Test[port].TestHistory = Localization.MaximumTimeTH;

                    step.Fail();
                }
                else if (IO.Signals.BlueHiSideToolPressure > tempMaxToolPressure)
                {

                    Machine.Test[port].TestResult = "Tool Pressure Too High";
                    Machine.Test[port].TestHistory = "Tool Pressure High";
                    VtiEvent.Log.WriteInfo($"Hi Side Tool Pressure too high ({IO.Signals.BlueHiSideToolPressure} > {tempMaxToolPressure} psi after {step.ElapsedTime.TotalSeconds:0.0} sec)");

                    step.Fail();
                }
                else//****mdb12/11/17
                {

                    //pass when count is expired/valve closes
                    if (step.ElapsedTime.TotalSeconds > 4.0)
                    {
                        if (IO.Signals.CounterOutputs.Value < 0.5)
                        {
                            step.Pass();
                        }
                        else if ((IO.Signals.CounterOutputs.Value > 1.5) && (IO.Signals.CounterOutputs.Value < 2.5))
                        {
                            step.Pass();
                        }
                    }
                }
            
        }

        void HiSideCharge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

                Machine.Test[port].ChargeTargetWeight = model.TotalCharge.ProcessValue;
                Machine.Test[port].ChargeTargetWeightMaxSetpoint = model.TotalCharge.ProcessValue + (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);
                Machine.Test[port].ChargeTargetWeightMinSetpoint = model.TotalCharge - (model.MinimumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);

                IO.Signals.BlueSetPoint.Value = model.TotalCharge.ProcessValue / 16.0;
                Machine.Cycle[Port.Blue].bChargeLimitsForDataPlot = true;

                if (model.LowSideChargePressureCheckEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue > 99.5)
                    {
                        //do pressure check on low side gun to check pressure
                        //IO.DOut.BlueCircuit2LoSideToolStem.Disable();
                        Machine.Test[port].LowSideChargePressureCheckPressureStart = IO.Signals.BlueLoSideToolPressure.Value;
                        //Thread.Sleep(500);
                    }
                }

                Machine.Test[port].LowFlowAlarmStartTime = DateTime.Now;

                string EventLogString;

                Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;

                //dout.BoosterDisable.Enable();

                //IO.DOut.VacuumPumpEnable.Disable();
                
                dout.HiSideEvac.Disable();
                dout.LoSideEvac.Disable();
                dout.HiSideRecovery.Disable();
                dout.LoSideRecovery.Disable();
                dout.RateOfRiseValve.Disable();
                dout.UnitEvac.Disable();
                Thread.Sleep(1000);
                if ((Machine.Test[port].ForceHiSideChargeFlag) || (Machine.Test[port].ForceChargeFlag))
                {
                    dout.HiSideToolStem.Enable();
                    Thread.Sleep(1000);
                }

                Machine.Test[port].RecoverHiSideFlag = true;
                if (dout.LoSideToolStem.Value)
                {
                    Machine.Test[port].RecoverLowSideFlag = true;
                }

                if (port == Port.Blue)
                {
                    EventLogString = string.Format("Hi Side Start Supply Pressure: {0:0.0} psig", IO.Signals.BlueSupplyPressure.Value);
                    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);

                    Machine.Test[port].HiSideBatchStart = IO.Signals.BluePartCharge;
                }
                else
                {
                    EventLogString = string.Format("Hi Side Start Supply Pressure: {0:0.0} psig", IO.Signals.WhiteSupplyPressure.Value);
                    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);

                    Machine.Test[port].HiSideBatchStart = IO.Signals.WhitePartCharge;
                }


                //?reset/rezero flowmeter?
                //load hiside counter with parital counts
                //load lowside counter with total counts
                //open hiside hiside charge valve if enabled
                //set timeout based on rate and charge value
                if (port == Port.Blue)
                {
                    double TargetTotalCharge = model.TotalCharge.ProcessValue;//in oz
                    double TargetHiSideCharge;
                    bool HiSideOnlyFlag;

                    if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                    {
                    //TargetHiSideCharge = TargetTotalCharge;
                    TargetHiSideCharge = TargetTotalCharge * (model.HiSidePercentage.ProcessValue) / 100.0;

                    HiSideOnlyFlag = false;
                        Machine.Test[port].HiSideOnlyCharge = false;
                    }
                    else
                    {
                        if ((Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue) && (!Machine.Test[port].ForceHiSideChargeFlag) && (model.HiSidePercentage.ProcessValue < 99.5))
                        {
                            TargetHiSideCharge = TargetTotalCharge * (model.HiSidePercentage.ProcessValue) / 100.0;
                            HiSideOnlyFlag = false;
                            Machine.Test[port].HiSideOnlyCharge = false;
                        }
                        else
                        {
                            TargetHiSideCharge = TargetTotalCharge;
                            HiSideOnlyFlag = true;
                            Machine.Test[port].HiSideOnlyCharge = true;
                        }
                    }
                    int TargetTotalCounts;
                    int TargetHiSideCounts;

                    //end value at 500 so it can be adjusted
                    Machine.Test[port].CounterStopValueHiSide = 500;
                    Machine.Test[port].CounterStopValueLowSide = 500;
                    if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue && (Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue > Config.Flow.Minimum_Flowmeter_Rate.ProcessValue)&&(Machine.Test[0].LastFlowValue<5.0))
                    {
                        //adjust offset for the last flow
                        if (HiSideOnlyFlag)
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue) * Machine.Test[port].LastFlowValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueHiSide);
                        }
                        else
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue) * Machine.Test[port].LastFlowValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        }
                        TargetHiSideCounts = Convert.ToInt32(TargetHiSideCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts) * Machine.Test[port].LastFlowValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueHiSide);
                    }
                    else
                    {
                        if (HiSideOnlyFlag)
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue) + Machine.Test[port].CounterStopValueHiSide;
                        }
                        else
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue) + Machine.Test[port].CounterStopValueLowSide;
                        }
                        TargetHiSideCounts = Convert.ToInt32(TargetHiSideCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts) + Machine.Test[port].CounterStopValueHiSide;
                    }

                    Machine.Test[port].LoadHiSideCounter = TargetHiSideCounts;

                    Machine.Test[port].CounterStartValueHiSide = Machine.Test[port].LoadHiSideCounter;
                    Machine.Cycle[port].bLoadHiSideCounter = true;
                    Machine.Cycle[port].bEnableHiSideCharge = true;

                    if (Config.Mode.HP_SwitchChargeOnFlow.ProcessValue)
                    {
                        Machine.Test[port].LoadLowSideCounter = TargetTotalCounts;
                    }
                    else
                    {
                        if ((Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue == false) || (Machine.Test[port].ForceHiSideChargeFlag) || (model.HiSidePercentage.ProcessValue > 99.5))
                        {
                            Machine.Test[port].LoadLowSideCounter = 20000;
                        }
                        else
                        {
                            Machine.Test[port].LoadLowSideCounter = TargetTotalCounts;

                        }
                    }
                    Machine.Test[port].PartChargeByCounterStart = Convert.ToDouble(Machine.Test[port].LoadLowSideCounter);

                    Machine.Test[port].ChargeStartCounts = TargetTotalCounts;
                    Machine.Test[port].TargetCounts = TargetTotalCounts - 500;
                    Machine.Test[port].CounterStartValueLowSide = Machine.Test[port].LoadLowSideCounter;
                    Machine.Cycle[port].bLoadLowSideCounter = true;
                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = TargetLowSideCharge / Config.Flow.Average_Charge_Rate.ProcessValue };
                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = 120.0 };
                }
                else
                {
                    double TargetTotalCharge = model.TotalCharge.ProcessValue;//oz
                    double TargetHiSideCharge;
                    bool HiSideOnlyFlag;
                    if ((Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue) && (!Machine.Test[port].ForceHiSideChargeFlag) && (model.HiSidePercentage.ProcessValue < 99.5))
                    {
                        TargetHiSideCharge = TargetTotalCharge * (model.HiSidePercentage.ProcessValue) / 100.0;
                        HiSideOnlyFlag = false;
                        Machine.Test[port].HiSideOnlyCharge = false;
                    }
                    else
                    {
                        TargetHiSideCharge = TargetTotalCharge;
                        HiSideOnlyFlag = true;
                        Machine.Test[port].HiSideOnlyCharge = true;
                    }

                    int TargetTotalCounts;
                    int TargetHiSideCounts;

                    //end value at 500 so it can be adjusted
                    Machine.Test[port].CounterStopValueHiSide = 500;
                    Machine.Test[port].CounterStopValueLowSide = 500;
                    if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue)
                    {
                        if (HiSideOnlyFlag)
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue) * Machine.Test[port].LastFlowValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueHiSide);
                        }
                        else
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue) * Machine.Test[port].LastFlowValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        }
                        TargetHiSideCounts = Convert.ToInt32(TargetHiSideCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Convert.ToDouble(Config.Flow.White_Circuit1_Flowmeter_Offset_Counts) * Machine.Test[port].LastFlowValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueHiSide);

                    }
                    else
                    {
                        if (HiSideOnlyFlag)
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue) + Machine.Test[port].CounterStopValueHiSide;
                        }
                        else
                        {
                            TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue) + Machine.Test[port].CounterStopValueLowSide;
                        }
                        TargetHiSideCounts = Convert.ToInt32(TargetHiSideCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts) + Machine.Test[port].CounterStopValueHiSide;
                    }
                    //Machine.Test[port].HiSideCounter = TargetHiSideCounts;
                    Machine.Test[port].LoadHiSideCounter = TargetHiSideCounts;


                    Machine.Test[port].CounterStartValueHiSide = Machine.Test[port].LoadHiSideCounter;
                    Machine.Cycle[port].bLoadHiSideCounter = true;
                    Machine.Cycle[port].bEnableHiSideCharge = true;

                    if ((Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue == false) || (Machine.Test[port].ForceHiSideChargeFlag) || (model.HiSidePercentage.ProcessValue > 99.5))
                    {
                        Machine.Test[port].LoadLowSideCounter = 20000;
                    }
                    else
                    {
                        Machine.Test[port].LoadLowSideCounter = TargetTotalCounts;
                    }

                    Machine.Test[port].PartChargeByCounterStart = Convert.ToDouble(Machine.Test[port].LoadLowSideCounter);

                    Machine.Test[port].ChargeStartCounts = TargetTotalCounts;
                    Machine.Test[port].TargetCounts = TargetTotalCounts - 500;
                    Machine.Test[port].CounterStartValueLowSide = Machine.Test[port].LoadLowSideCounter;
                    Machine.Cycle[port].bLoadLowSideCounter = true;

                    //Machine.Cycle[port].bLoadLowSideCounter = true;
                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = TargetLowSideCharge / Config.Flow.Average_Charge_Rate.ProcessValue };
                }
            
        }

        void LowSideCharge_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueCircuit2HiSideCharge.Disable();
            IO.DOut.BlueCircuit2LoSideCharge.Disable();

            Machine.Test[port].ChargeResult = "Fail";

            string EventLogString;
            if (port == Port.Blue)
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.BlueSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            else
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.WhiteSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }

            //****mdb 11/18/18
            //LowSideCharge_Failed
            try
            {
                EventLogString = string.Format("Charge Amount: {0:0.00} lbs", IO.Signals.BluePartChargeInPounds.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Setpoint: {0:0.00} lbs", IO.Signals.BlueSetPoint.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Flow: {0:0.00} oz/s", IO.Signals.BluePartFlow.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Charge Target: {0:0.00} lbs", model.TotalCharge.ProcessValue/16.0);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                CycleFail(Machine.Test[port].TestResult, Machine.Test[port].TestHistory);
            }
            catch (Exception ex)
            {
                CycleFail(Localization.LowSideChargeFailed, Localization.LowSideChargeFailed);
                Console.WriteLine(ex.Message);
            }
            //****mdb 11/18/18


            //CycleFail(Localization.LowSideChargeFailed, Localization.LowSideChargeFailed);
            ////CycleFail(Machine.Test[port].TestResult, Machine.Test[port].TestHistory);
        }

        void LowSideCharge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ChargeResult = "Pass";
            //CyclePass(Localization.Passed, Localization.PassedTH);
            Machine.Test[port].PassedChargeFlag = true;

                ToolDrainDelay.Start();
        }

        void LowSideCharge_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].TestResult = Localization.MaximumTimeFailed;
            Machine.Test[port].TestHistory = Localization.MaximumTimeTH;

            step.Fail();
        }

        void LowSideCharge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ChargeTime = Machine.Test[port].HighSideChargeTime + step.ElapsedTime.TotalSeconds;
            Machine.Test[port].RefSupplyPressDuringCharge = IO.Signals.BlueSupplyPressure.Value;
            Machine.Test[port].ActualChargeWeight = IO.Signals.BluePartChargeByCounter.Value;
            MyStaticVariables.ActualCharge = Machine.Test[port].ActualChargeWeight;

            MyStaticVariables.BlueLowSideEndWeight = IO.Signals.BluePartChargeByCounter.Value;
            MyStaticVariables.BlueLowSideChargeWeight = MyStaticVariables.BlueLowSideEndWeight - MyStaticVariables.BlueLowSideStartWeight;


            if (Machine.Test[port].ForceChargeFlag)
                {

                }
                else
                {
                    if (model.LowSideChargePressureCheckEnabled.ProcessValue)
                    {
                        if (model.HiSidePercentage.ProcessValue < 0.5)
                        {
                            //check hi side gun pressure, if it goes up, fail (guns swapped)
                            Machine.Test[port].LowSideChargePressureCheckPressureValue = IO.Signals.BlueHiSideToolPressure.Value;
                            double LowSidePressureChange = Machine.Test[port].LowSideChargePressureCheckPressureValue - Machine.Test[port].LowSideChargePressureCheckPressureStart;

                            if (LowSidePressureChange > model.Low_Side_Charge_Pressure_Check_SetPoint.ProcessValue)
                            {
                                    Machine.Test[port].TestResult = Localization.LowSideServiceValveOpen;
                                    Machine.Test[port].TestHistory = Localization.LowSideServiceValveOpen;

                                    step.Fail();
                            }
                        }
                    }
                }


                double PartFlow;
                if (port == Port.Blue)
                {
                    PartFlow = IO.Signals.BluePartFlow.Value;
                }
                else
                {
                    PartFlow = IO.Signals.WhitePartFlow.Value;
                }

                if (PartFlow < Config.Flow.Minimum_Flowmeter_Rate.ProcessValue)
                {
                }
                else
                {
                    Machine.Test[port].LowFlowAlarmStartTime = DateTime.Now;
                }
                TimeSpan LowFlowAlarmTime = DateTime.Now - Machine.Test[port].LowFlowAlarmStartTime;

                //save last flow
                if (!Machine.Test[port].SavedLastFlow)
                {
                    if (port == Port.Blue)
                    {
                        if (IO.Signals.BlueLowSideCounter.Value < 1000)
                        {
                            Machine.Test[port].SavedLastFlow = true;

                            //adjust offset if enabled
                            if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue && (Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue > Config.Flow.Minimum_Flowmeter_Rate.ProcessValue) && (Machine.Test[port].LastFlowValue < 5.0))
                            {
                                Machine.Test[port].CounterStopValueLowSide = Machine.Test[port].CounterStopValueLowSide - Convert.ToInt32((IO.Signals.BluePartFlow.Value - Machine.Test[port].LastFlowValue) * Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue);
                                Machine.Cycle[port].bLoadLowSideLimit = true;
                            }
                            Machine.Test[port].LastFlowValue = IO.Signals.BluePartFlow.Value;
                        }
                    }
                    else
                    {
                        if (IO.Signals.WhiteLowSideCounter.Value < 1000)
                        {
                            Machine.Test[port].SavedLastFlow = true;

                            //adjust offset if enabled
                            if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue)
                            {
                                Machine.Test[port].CounterStopValueLowSide = Machine.Test[port].CounterStopValueLowSide - Convert.ToInt32((IO.Signals.WhitePartFlow.Value - Machine.Test[port].LastFlowValue) * Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue);
                                Machine.Cycle[port].bLoadLowSideLimit = true;

                            }
                            Machine.Test[port].LastFlowValue = IO.Signals.WhitePartFlow.Value;
                        }
                    }
                }

                double PartCharge;
                if (port == Port.Blue)
                {
                    PartCharge = IO.Signals.BluePartCharge.Value - Machine.Test[port].LowSideBatchStart;
                }
                else
                {
                    PartCharge = IO.Signals.WhitePartCharge.Value - Machine.Test[port].LowSideBatchStart;
                }
                double OverChargeLimit;
                
                        OverChargeLimit = (Config.Flow.Maximum_Over_Charge_Percentage.ProcessValue / 100.0) * model.TotalCharge.ProcessValue;//oz
                
                double MaximumTime = OverChargeLimit / Config.Flow.Average_Charge_Rate.ProcessValue;
                Machine.Test[port].ChargeTimeoutDelay = MaximumTime;


            double tempMaxToolPressure =Config.Pressure.MaximumBlueToolPressureDuringCharge.ProcessValue;


            //fail on minimum rate error
            //if ((PartFlow < Config.Flow.Minimum_Flowmeter_Rate.ProcessValue) && (step.ElapsedTime.TotalSeconds > 5.0))
            if ((LowFlowAlarmTime.TotalSeconds > 3.0) && (step.ElapsedTime.TotalSeconds > 5.0))
                {
                    Machine.Test[port].TestResult = Localization.LowFlowFailed;
                    Machine.Test[port].TestHistory = Localization.LowFlowTH;

                    step.Fail();
                }
                else
                {
                    //fail on timeout based on rate (uses Elapsed Time)
                    if (step.ElapsedTime.TotalSeconds > MaximumTime)
                    {
                        Machine.Test[port].TestResult = Localization.MaximumTimeFailed;
                        Machine.Test[port].TestHistory = Localization.MaximumTimeTH;

                        step.Fail();
                    }
                    else if (IO.Signals.BlueLoSideToolPressure.Value > tempMaxToolPressure)
                    {

                        Machine.Test[port].TestResult = "Tool Pressure Too High";
                        Machine.Test[port].TestHistory = "Tool Pressure High";
                        VtiEvent.Log.WriteInfo($"Low Side Tool Pressure too high ({IO.Signals.BlueLoSideToolPressure.Value} > {tempMaxToolPressure} psi after {step.ElapsedTime.TotalSeconds:0.0} sec)");

                        step.Fail();
                    }
                    else
                    {
                        {
                            {

                                //pass when count is expired/valve closes
                                //pass when count is expired/valve closes
                                if (step.ElapsedTime.TotalSeconds > 4.0)
                                {
                                    if (IO.Signals.CounterOutputs.Value < 0.5)
                                    {
                                        step.Pass();
                                    }
                                }
                            }
                        }
                    }
                }
            
        }

        void LowSideCharge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
                if (model.HiSidePercentage.ProcessValue < 0.5)
                {
                    IO.Signals.BlueSetPoint.Value = model.TotalCharge.ProcessValue / 16.0;
                    Machine.Cycle[Port.Blue].bChargeLimitsForDataPlot = true;
                }
            AppendToToolTip($"Hi Side Charge Weight: {IO.Signals.BluePartChargeByCounter.Value:0.0}");
            MyStaticVariables.BlueLowSideStartWeight = IO.Signals.BluePartChargeByCounter.Value;
            Machine.Test[port].ChargeTargetWeight = model.TotalCharge.ProcessValue;
                Machine.Test[port].ChargeTargetWeightMaxSetpoint = model.TotalCharge.ProcessValue + (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);
                Machine.Test[port].ChargeTargetWeightMinSetpoint = model.TotalCharge - (model.MinimumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);

                Machine.Test[port].LowFlowAlarmStartTime = DateTime.Now;

                if (model.LowSideChargePressureCheckEnabled.ProcessValue)
                {
                    if (model.HiSidePercentage.ProcessValue < 0.5)
                    {
                        //do pressure check on high side gun to check pressure (guns swapped for heat pump
                        //IO.DOut.BlueCircuit2LoSideToolStem.Disable();
                        Machine.Test[port].LowSideChargePressureCheckPressureStart = IO.Signals.BlueHiSideToolPressure.Value;
                        //Thread.Sleep(500);
                    }
                }


                string EventLogString;

                Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;

                //dout.BoosterDisable.Enable();

                //IO.DOut.CrossOverValve.Disable();

                //IO.DOut.VacuumPumpEnable.Disable();
                dout.HiSideEvac.Disable();
                dout.LoSideEvac.Disable();
                dout.HiSideRecovery.Disable();
                dout.LoSideRecovery.Disable();
                dout.RateOfRiseValve.Disable();
                dout.UnitEvac.Disable();

                dout.HiSideCharge.Disable();

                Thread.Sleep(1000);
                if ((Machine.Test[port].ForceLowSideChargeFlag) || (Machine.Test[port].ForceChargeFlag))
                {
                    dout.LoSideToolStem.Enable();
                    Thread.Sleep(1000);
                }

                Machine.Test[port].RecoverLowSideFlag = true;
                if (dout.HiSideToolStem.Value)
                {
                    Machine.Test[port].RecoverHiSideFlag = true;
                }

                if (port == Port.Blue)
                {
                    EventLogString = string.Format("Low Side Start Supply Pressure: {0:0.0} psig", IO.Signals.BlueSupplyPressure.Value);
                    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);

                    Machine.Test[port].LowSideBatchStart = IO.Signals.BluePartCharge;
                }
                else
                {
                    EventLogString = string.Format("Hi Side Start Supply Pressure: {0:0.0} psig", IO.Signals.WhiteSupplyPressure.Value);
                    VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);

                    Machine.Test[port].LowSideBatchStart = IO.Signals.WhitePartCharge;
                }


                //?reset/rezero flowmeter?
                //load hiside counter with parital counts
                //load lowside counter with total counts
                //open hiside hiside charge valve if enabled
                //set timeout based on rate and charge value
                if (port == Port.Blue)
                {
                    double TargetTotalCharge = model.TotalCharge.ProcessValue;//oz
                    double TargetLowSideCharge;
                    if ((Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue) && (!Machine.Test[port].ForceLowSideChargeFlag) && (model.HiSidePercentage.ProcessValue > 0.5))
                    {
                        TargetLowSideCharge = TargetTotalCharge * (100.0 - model.HiSidePercentage.ProcessValue) / 100.0;
                    }
                    else
                    {
                        TargetLowSideCharge = TargetTotalCharge;
                    }

                    int TargetTotalCounts;
                    int TargetLowSideCounts;

                    Machine.Test[port].CounterStopValueLowSide = 500;

                    if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue && (Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue > Config.Flow.Minimum_Flowmeter_Rate.ProcessValue) && (Machine.Test[port].LastFlowValue < 5.0))
                    {
                        TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue * Machine.Test[port].LastFlowValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        TargetLowSideCounts = Convert.ToInt32(TargetLowSideCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts * Machine.Test[port].LastFlowValue / Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);

                    }
                    else
                    {
                        TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        TargetLowSideCounts = Convert.ToInt32(TargetLowSideCharge * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts + Machine.Test[port].CounterStopValueLowSide);
                    }

                    //Machine.Test[port].HiSideCounter = TargetHiSideCounts;
                    Machine.Test[port].LoadLowSideCounter = TargetLowSideCounts;

                    if ((Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue == false) || (Machine.Test[port].ForceLowSideChargeFlag) || (model.HiSidePercentage.ProcessValue < 0.5))
                    {
                        Machine.Test[port].CounterStartValueLowSide = Machine.Test[port].LoadLowSideCounter;
                        Machine.Cycle[port].bLoadLowSideCounter = true;
                        Machine.Cycle[port].bEnableLowSideCharge = true;

                        Machine.Test[port].ChargeStartCounts = TargetTotalCounts;
                        Machine.Test[port].TargetCounts = TargetTotalCounts - 500;

                        Machine.Test[port].PartChargeByCounterStart = Convert.ToDouble(Machine.Test[port].LoadLowSideCounter);
                    }
                    else
                    {
                        //Machine.Cycle[port].bEnableLowSideCharge = true;
                    }
                    //Machine.Test[port].LoadHiSideCounter = 20000;
                    //Machine.Cycle[port].bLoadHiSideCounter = true;

                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = TargetLowSideCharge / Config.Flow.Average_Charge_Rate.ProcessValue };
                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = 120.0 };
                }
                else
                {
                    double TargetTotalCharge = model.TotalCharge.ProcessValue;//oz
                    double TargetLowSideCharge;
                    if ((Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue) && (!Machine.Test[port].ForceLowSideChargeFlag) && (model.HiSidePercentage.ProcessValue > 0.5))
                    {
                        TargetLowSideCharge = TargetTotalCharge * (100.0 - model.HiSidePercentage.ProcessValue) / 100.0;
                    }
                    else
                    {
                        TargetLowSideCharge = TargetTotalCharge;
                    }

                    int TargetTotalCounts;
                    int TargetLowSideCounts;

                    Machine.Test[port].CounterStopValueLowSide = 500;

                    if (Config.Mode.AdjustOffsetCountsUsingFlowEnabled.ProcessValue)
                    {
                        TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue * Machine.Test[port].LastFlowValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        TargetLowSideCounts = Convert.ToInt32(TargetLowSideCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts * Machine.Test[port].LastFlowValue / Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue + Machine.Test[port].CounterStopValueLowSide);

                    }
                    else
                    {
                        TargetTotalCounts = Convert.ToInt32(TargetTotalCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue + Machine.Test[port].CounterStopValueLowSide);
                        TargetLowSideCounts = Convert.ToInt32(TargetLowSideCharge * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts + Machine.Test[port].CounterStopValueLowSide);
                    }
                    //Machine.Test[port].HiSideCounter = TargetHiSideCounts;
                    Machine.Test[port].LoadLowSideCounter = TargetLowSideCounts;

                    if ((Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue == false) || (Machine.Test[port].ForceLowSideChargeFlag) || (model.HiSidePercentage.ProcessValue < 0.5))
                    {
                        Machine.Test[port].CounterStartValueLowSide = Machine.Test[port].LoadLowSideCounter;
                        Machine.Cycle[port].bLoadLowSideCounter = true;
                        Machine.Cycle[port].bEnableLowSideCharge = true;

                        Machine.Test[port].PartChargeByCounterStart = Convert.ToDouble(Machine.Test[port].LoadLowSideCounter);

                        Machine.Test[port].ChargeStartCounts = TargetTotalCounts;
                        Machine.Test[port].TargetCounts = TargetTotalCounts - 500;
                    }
                    else
                    {
                        //Machine.Cycle[port].bEnableLowSideCharge = true;
                    }

                    //Machine.Test[port].LoadHiSideCounter = 20000;
                    //Machine.Cycle[port].bLoadHiSideCounter = true;

                    //Machine.Cycle[port].bLoadLowSideCounter = true;
                    //step.TimeDelay = new TimeDelayParameter { ProcessValue = TargetLowSideCharge / Config.Flow.Average_Charge_Rate.ProcessValue };
                }
            
        }

        void ToolDrainDelay_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ToolDrainResult = "Fail";

            Machine.Test[port].ChargeResult = "Fail";
            CycleFail(Localization.ToolDrainFailed, Localization.ToolDrainFailed);
        }

        void ToolDrainDelay_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ToolDrainResult = "Pass";

            int TotalCounts;
            if (port == Port.Blue)
            {
                MyStaticVariables.BlueStartingCountsForDataBase = Machine.Test[port].ChargeStartCounts;
                MyStaticVariables.BlueEndingCountsForDatabase = Machine.Test[port].ChargeEndCounts;
                if ((Machine.Test[port].ForceHiSideChargeFlag) || (!Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)||(model.HiSidePercentage.ProcessValue>99.5))
                {
                    //use the hiside counter
                    Machine.Test[port].ChargeEndCounts = Convert.ToInt32(IO.Signals.BlueHiSideCounter.Value);
                    //TotalCounts = Machine.Test[port].ChargeStartCounts + (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    TotalCounts = (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    Machine.Test[port].ActualCounts = TotalCounts;
                    VtiEvent.Log.WriteInfo($"Tool Drain Delay: Blue starting counts:{Machine.Test[port].ChargeStartCounts}; Blue Ending Counts:{Machine.Test[port].ChargeEndCounts};Target Charge:{model.TotalCharge.ProcessValue}");
                    Machine.Test[port].ChargeCalculatedWeight=Convert.ToDouble(TotalCounts)/Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue;
                }
                else
                {
                    //use the lowside counter
                    //use the hiside counter
                    Machine.Test[port].ChargeEndCounts = Convert.ToInt32(IO.Signals.BlueLowSideCounter.Value);
                    //TotalCounts = Machine.Test[port].ChargeStartCounts + (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    TotalCounts = (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    Machine.Test[port].ActualCounts = TotalCounts;
                    VtiEvent.Log.WriteInfo($"Tool Drain Delay: Blue starting counts:{Machine.Test[port].ChargeStartCounts}; Blue Ending Counts:{Machine.Test[port].ChargeEndCounts};Target Charge:{model.TotalCharge.ProcessValue}");
                    Machine.Test[port].ChargeCalculatedWeight=Convert.ToDouble(TotalCounts)/Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue;
                }
                AppendToToolTip($"Counts: From {Machine.Test[port].ChargeStartCounts:0} to {Convert.ToInt32(IO.Signals.BlueHiSideCounter.Value):0}");
                AppendToToolTip($"Counts/oz: {Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue:0.00} - Offset: {Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue}");
            }
            else
            {
                if ((Machine.Test[port].ForceHiSideChargeFlag) || (!Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)||(model.HiSidePercentage.ProcessValue>99.5))
                {
                    //use the hiside counter
                    Machine.Test[port].ChargeEndCounts = Convert.ToInt32(IO.Signals.WhiteHiSideCounter.Value);
                    //TotalCounts = Machine.Test[port].ChargeStartCounts + (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    TotalCounts = (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    Machine.Test[port].ActualCounts = TotalCounts;
                    Machine.Test[port].ChargeCalculatedWeight = Convert.ToDouble(TotalCounts) / Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue;
                }
                else
                {
                    //use the lowside counter
                    //use the hiside counter
                    Machine.Test[port].ChargeEndCounts = Convert.ToInt32(IO.Signals.WhiteLowSideCounter.Value);
                    //TotalCounts = Machine.Test[port].ChargeStartCounts + (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    TotalCounts = (Machine.Test[port].ChargeStartCounts - Machine.Test[port].ChargeEndCounts);
                    Machine.Test[port].ActualCounts = TotalCounts;
                    Machine.Test[port].ChargeCalculatedWeight = Convert.ToDouble(TotalCounts) / Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue;
                }
                AppendToToolTip($"Counts: From {Machine.Test[port].ChargeStartCounts:0} to {Convert.ToInt32(IO.Signals.BlueHiSideCounter.Value):0}");
                AppendToToolTip($"Counts/oz: {Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue:0.00} - Offset: {Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue}");
            }

            AppendToToolTip($"Total Charge: {Machine.Test[port].ChargeCalculatedWeight:0.00}");


            Machine.Test[port].ActualChargeWeight = Machine.Test[port].ChargeCalculatedWeight;
            MyStaticVariables.ActualCharge = Machine.Test[port].ActualChargeWeight;
            Machine.Test[port].ChargeTargetWeight = model.TotalCharge.ProcessValue;
            Machine.Test[port].ChargeTargetWeightMaxSetpoint = model.TotalCharge.ProcessValue + (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);
            Machine.Test[port].ChargeTargetWeightMinSetpoint = model.TotalCharge - (model.MinimumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue);

            if (Machine.Test[0].HiSideOnlyCharge)
            {
                Machine.Test[0].TargetCounts = Machine.Test[0].CounterStartValueHiSide - Machine.Test[0].CounterStopValueHiSide;
            }
            else
            {
                Machine.Test[0].TargetCounts = Machine.Test[0].CounterStartValueLowSide - Machine.Test[0].CounterStopValueLowSide;
            }


            //load FlowmeterCalibrateForm
            if ((Machine.Test[port].ForceChargeFlag) || (Machine.Test[port].ForceHiSideChargeFlag) || (Machine.Test[port].ForceLowSideChargeFlag))
            {
                if (port == Port.Blue)
                {
                    Machine.Test[0].CalTargetWeight = model.TotalCharge.ProcessValue;
                    //Machine.Test[0].CalTargetCounts = Convert.ToInt32(model.TotalCharge.ProcessValue * Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue);
                    if (Machine.Test[0].HiSideOnlyCharge)
                    {
                        Machine.Test[0].CalTargetCounts = Machine.Test[0].CounterStartValueHiSide - Machine.Test[0].CounterStopValueHiSide;
                    }
                    else
                    {
                        Machine.Test[0].CalTargetCounts = Machine.Test[0].CounterStartValueLowSide - Machine.Test[0].CounterStopValueLowSide;
                    }
                    Machine.Test[0].CalActualCounts = TotalCounts;
                    Machine.Test[0].CalWeightByCounter = Machine.Test[port].ChargeCalculatedWeight;
                    Machine.Test[0].CalLoadCounterData = true;
                }
                else
                {
                    Machine.Test[1].CalTargetWeight = model.TotalCharge.ProcessValue;
                    //Machine.Test[1].CalTargetCounts = Convert.ToInt32(model.TotalCharge.ProcessValue * Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue + Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue);
                    if (Machine.Test[1].HiSideOnlyCharge)
                    {
                        Machine.Test[1].CalTargetCounts = Machine.Test[1].CounterStartValueHiSide - Machine.Test[1].CounterStopValueHiSide;
                    }
                    else
                    {
                        Machine.Test[1].CalTargetCounts = Machine.Test[1].CounterStartValueLowSide - Machine.Test[1].CounterStopValueLowSide;
                    }

                    Machine.Test[1].CalActualCounts = TotalCounts;
                    Machine.Test[1].CalWeightByCounter = Machine.Test[port].ChargeCalculatedWeight;
                    Machine.Test[1].CalLoadCounterData = true;
                }

                if (Machine.Test[port].PassedChargeFlag)
                {
                    if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag && !Machine.Test[port].RecoverUnitFlag)
                    {
                        WaitForFINALWEIGHT.Start();
                    }
                    else
                    {
                        Int32 Pounds;
                        double Ounces;
                        
                            Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                            Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                            if (Ounces > 15.95)
                            {
                                Ounces = 0.0;
                                Pounds = Pounds + 1;
                            }
                        
                        CyclePass(string.Format(Localization.PassedCharge,Pounds,Ounces ), string.Format(Localization.PassedChargeTH, Pounds,Ounces));
                    }
                }

            }
            else
            {
                //overcharge calculation do not calculate if force charge
                if (port == Port.Blue)
                {
                    if ((Machine.Test[port].ChargeCalculatedWeight > (model.TotalCharge.ProcessValue + (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue))))
                    {
                        Machine.Test[port].PassedChargeFlag = false;
                        Int32 Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                        double Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                        if (Ounces > 15.95)
                        {
                            Ounces = 0.0;
                            Pounds = Pounds + 1;
                        }

                        //****mdb 11/18/18
                        //ToolDrainDelay_Passed just above CycleFail(string.Format(Localization.OverCharge...
                        string EventLogString;
                        try
                        {
                            EventLogString = string.Format("Charge Amount: {0:0.00} lbs", IO.Signals.BluePartChargeInPounds.Value);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Charge Setpoint: {0:0.00} lbs", IO.Signals.BlueSetPoint.Value);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Charge Flow: {0:0.00} oz/s", IO.Signals.BluePartFlow.Value);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Charge Calculated Weight: {0:0.00} lbs", Machine.Test[0].ChargeCalculatedWeight / 16.0);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Charge Target: {0:0.00} lbs", model.TotalCharge.ProcessValue / 16.0);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Max Charge Weight Error: {0:0.00} lbs", (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue)/16.0);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Max Charge Weight Calc: {0:0.00} lbs", model.TotalCharge.ProcessValue / 16.0 + (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue)/16.0);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Actual Partial Charge Weight: {0:0.00} lbs", MyStaticVariables.InitialPartialCharge / 16.0);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                            EventLogString = string.Format("Elapsed Time: {0:0.00} sec", step.ElapsedTime.TotalSeconds);
                            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        //****mdb 11/18/18


                        CycleFail(string.Format(Localization.OverChargeFail, Pounds,Ounces), string.Format(Localization.OverChargeFailTH, Pounds,Ounces));
                    }
                    else
                    {
                        if (Machine.Test[port].ChargeCalculatedWeight < (model.TotalCharge.ProcessValue - (model.MinimumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue)))
                        {
                            Machine.Test[port].PassedChargeFlag = false;
                            Int32 Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                            double Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                            if (Ounces > 15.95)
                            {
                                Ounces = 0.0;
                                Pounds = Pounds + 1;
                            }

                            CycleFail(string.Format(Localization.UnderChargeFail,Pounds,Ounces ), string.Format(Localization.UnderChargeFailTH, Pounds,Ounces));
                        }
                        else
                        {
                            if (Machine.Test[port].PassedChargeFlag)
                            {
                                if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag)
                                {
                                    //WaitForFINALWEIGHT.Start();
                                    dout.HiSideToolStem.Disable();
                                    dout.LoSideToolStem.Disable();
                                    Thread.Sleep(1000);
                                    if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
                                    return;
                                }
                                else
                                {
                                    Int32 Pounds;
                                    double Ounces;
                                    
                                        Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                                        Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                                        if (Ounces > 15.95)
                                        {
                                            Ounces = 0.0;
                                            Pounds = Pounds + 1;
                                        }
                                    

                                    CyclePass(string.Format(Localization.PassedCharge, Pounds,Ounces), string.Format(Localization.PassedChargeTH, Pounds,Ounces));
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Machine.Test[port].ChargeCalculatedWeight > ((model.TotalCharge.ProcessValue + (model.MaximumChargeWeightError.ProcessValue/100*model.TotalCharge.ProcessValue))))
                    {
                        Machine.Test[port].PassedChargeFlag = false;
                        Int32 Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                        double Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                        if (Ounces > 15.95)
                        {
                            Ounces = 0.0;
                            Pounds = Pounds + 1;
                        }


                        CycleFail(string.Format(Localization.OverChargeFail, Pounds,Ounces), string.Format(Localization.OverChargeFailTH, Pounds,Ounces));
                    }
                    else
                    {
                        if (Machine.Test[port].ChargeCalculatedWeight < ((model.TotalCharge.ProcessValue - (model.MaximumChargeWeightError.ProcessValue / 100 * model.TotalCharge.ProcessValue))))
                        {
                            Machine.Test[port].PassedChargeFlag = false;
                            Int32 Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                            double Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                            if (Ounces > 15.95)
                            {
                                Ounces = 0.0;
                                Pounds = Pounds + 1;
                            }


                            CycleFail(string.Format(Localization.UnderChargeFail, Pounds,Ounces), string.Format(Localization.UnderChargeFailTH, Pounds,Ounces));
                        }
                        else
                        {
                            if (Machine.Test[port].PassedChargeFlag)
                            {
                                if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag)
                                {
                                    dout.HiSideToolStem.Disable();
                                    dout.LoSideToolStem.Disable();
                                    Thread.Sleep(1000);
                                    if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
                                    return;
                                }
                                else
                                {
                                    Int32 Pounds;
                                    double Ounces;
                                    

                                        Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                                        Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                                        if (Ounces > 15.95)
                                        {
                                            Ounces = 0.0;
                                            Pounds = Pounds + 1;
                                        }
                                    

                                    CyclePass(string.Format(Localization.PassedCharge, Pounds,Ounces), string.Format(Localization.PassedChargeTH, Pounds,Ounces));
                                }
                            }
                        }
                    }

                }
            }

            //if (Config.Mode.RecoverToServiceValvePartialStart.ProcessValue)
            //{
                // Prompt to close service valves
                // Leave tool stems enabled
                Machine.Cycle[0].bShowMessageFinalData = true;
                //Machine.Cycle[0].bShowMessageForm = true;
                WaitForAcknowledgePostCharge.Start();
            //}
            //else
            //{

            //    Machine.Cycle[0].bShowMessageFinalData = true;//show the data for the partial charge
            //    dout.HiSideToolStem.Disable();
            //    dout.LoSideToolStem.Disable();
            //    Thread.Sleep(1000);
            //    if (Config.Mode.InsertValveCoresAfterChargeEnabled.ProcessValue) WaitForAcknowledgePostCharge.Start();
            //    else ChargeHoseChargeToolRecovery.Start();
            //    //Reset.Start();
            //}
        }

        void ToolDrainDelay_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideToolStem.Disable();
            dout.LoSideToolStem.Disable();
            step.Pass();
        }

        void ToolDrainDelay_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ToolDrainPressure = IO.Signals.BlueHiSideToolPressure.Value;
            Machine.Test[port].ToolDrainTime = step.ElapsedTime.TotalSeconds;
        }

        void ToolDrainDelay_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].ToolDrainResult = "Aborted";

            Machine.Cycle[port].bDockTheDataPlot = true;

            Machine.Test[port].PartChargeByCounterStart = 0;

            string EventLogString;
            if (port == Port.Blue)
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.BlueSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }
            else
            {
                EventLogString = string.Format("End Supply Pressure: {0:0.0} psig", IO.Signals.WhiteSupplyPressure.Value);
                VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, EventLogString), VtiEventCatType.Test_Cycle);
            }

            dout.HiSideCharge.Disable();
            dout.LoSideCharge.Disable();
        }

        void WaitForAcknowledgePostCharge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
        }

        void WaitForAcknowledgePostCharge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
            {
                step.Pass();
            }
        }

        void WaitForAcknowledgePostCharge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void ChargeHoseChargeToolRecovery_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			double HiPress = IO.Signals.BlueHiSideToolPressure.Value;
			double LoPress = IO.Signals.BlueLoSideToolPressure.Value;
			double RecPress = HiPress > LoPress ? HiPress : LoPress;
			MyStaticVariables.EndingRecoveryPressBlue.Add(RecPress);
			MyStaticVariables.TimeTo50PsiBlue.Add((MyStaticVariables.RecoveryAbove50PsiBlue - MyStaticVariables.RecoveryStartBlue).TotalSeconds);

			if (!Machine.Test[port].FailToolRecoveryFlag)
            {
                Machine.Test[port].FailToolRecoveryFlag = true;
                Machine.Test[port].RecoverHiSideFlag = true;
                Machine.Test[port].RecoverLowSideFlag = true;
            }

            //dout.RecoveryPumpEnable.Disable();
            Machine.Test[port].RecoveryResult = "Fail";
            Machine.Test[port].PassedFlag = false;
            CycleNoTest(Localization.ToolRecoveryFailed, Localization.ToolRecoveryFailed);

        }

        void ChargeHoseChargeToolRecovery_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			double HiPress = IO.Signals.BlueHiSideToolPressure.Value;
			double LoPress = IO.Signals.BlueLoSideToolPressure.Value;
			double RecPress = HiPress > LoPress ? HiPress : LoPress;
			MyStaticVariables.EndingRecoveryPressBlue.Add(RecPress);
			MyStaticVariables.TimeTo50PsiBlue.Add((MyStaticVariables.RecoveryAbove50PsiBlue - MyStaticVariables.RecoveryStartBlue).TotalSeconds);

			Machine.Test[port].RecoveryResult = "Pass";

            //dout.RecoveryPumpEnable.Disable();
            //if ((Machine.Test[port].ForceLowSideChargeFlag) || (Machine.Test[port].ForceHiSideChargeFlag)||(Machine.Test[port].ForceChargeFlag))
            //{
            if (Config.Mode.ScaleEnabled.ProcessValue && !Machine.Test[port].ForceChargeFlag && !Machine.Test[port].RecoverUnitFlag)
            {
                WaitForFINALWEIGHT.Start();
            }
            else
            {
                if (Machine.Test[port].PassedChargeFlag)
                {
                    dout.PassGreenLight.Enable();
                }

                IO.DOut.BlueCircuit2HiSideRecovery.Disable();
                IO.DOut.BlueCircuit2LoSideRecovery.Disable();

                IO.DOut.BlueCircuit2Alarm.Enable();
                Thread.Sleep(500);
                IO.DOut.BlueCircuit2Alarm.Disable();
                Thread.Sleep(500);
                IO.DOut.BlueCircuit2Alarm.Enable();
                Thread.Sleep(500);
                IO.DOut.BlueCircuit2Alarm.Disable();
                
                    Reset.Start();
            }
            //}
            //else
            //{
            //    OperatorAcknowledge.Start();
            //}
        }

        void ChargeHoseChargeToolRecovery_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			if(Machine.Test[port].InitialRecoveryPassed)
			{
				if(IO.Signals.BlueHiSideToolPressure.Value < model.Recovery_Pressure_SetPoint.ProcessValue)
				{
					step.Pass();
				}
				else
				{
					step.Fail();
				}
			}
			else
			{
				step.Fail();
			}
			//if (signal.PartPressure.Value < Config.Pressure.Recovery_Pressure_SetPoint.ProcessValue)
			//{
			//    step.Pass();
			//}
			//else
			//{
			//    step.Fail();
			//}
		}

        void ChargeHoseChargeToolRecovery_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			if(port == 0)
			{
				if(IO.Signals.BlueHiSideToolPressure.Value > Config.Pressure.RecoverOnResetSetpoint.ProcessValue || IO.Signals.BlueHiSideToolPressure.Value > model.Recovery_Pressure_SetPoint.ProcessValue) dout.HiSideRecovery.Enable();
				if(IO.Signals.BlueLoSideToolPressure.Value > Config.Pressure.RecoverOnResetSetpoint.ProcessValue || IO.Signals.BlueLoSideToolPressure.Value > model.Recovery_Pressure_SetPoint.ProcessValue) dout.LoSideRecovery.Enable();

				if(IO.Signals.BlueHiSideToolPressure.Value > 50 || IO.Signals.BlueLoSideToolPressure.Value > 50) MyStaticVariables.RecoveryAbove50PsiBlue = DateTime.Now;

				if(step.ElapsedTime.TotalSeconds < model.Initial_Recovery_Timeout.ProcessValue && IO.Signals.BlueHiSideToolPressure.Value < model.Initial_Recovery_Setpoint.ProcessValue)
					Machine.Test[port].InitialRecoveryPassed = true;

				if(step.ElapsedTime.TotalSeconds >= model.Initial_Recovery_Timeout.ProcessValue && Machine.Test[port].InitialRecoveryPressure == double.MinValue)
				{
					Machine.Test[port].InitialRecoveryPressure = IO.Signals.BlueHiSideToolPressure.Value;
				}
			}

			Machine.Test[port].RecoveryTime = step.ElapsedTime.TotalSeconds;
            
            if (step.ElapsedTime.TotalSeconds > 4.0)
            {
                if (port == Port.Blue)
                {
                    if (IO.Signals.BlueHiSideToolPressure.Value < model.Recovery_Pressure_SetPoint.ProcessValue && 
                        IO.Signals.BlueLoSideToolPressure.Value < model.Recovery_Pressure_SetPoint.ProcessValue)
                    {
                        TimeSpan tsGoodRecoverPressure = DateTime.Now - MyStaticVariables.dtGoodRecoveryPressureStart;
                        if (tsGoodRecoverPressure.TotalSeconds > 10.0)
                        {
							if(Machine.Test[port].InitialRecoveryPassed)
								step.Pass();
							else
								step.Fail();
						}
                    }
                    else
                    {
                        MyStaticVariables.dtGoodRecoveryPressureStart=DateTime.Now;
                    }
                }
                else
                {
                    if (IO.Signals.WhiteHiSideToolPressure.Value < 0)
                    {
						if(Machine.Test[port].InitialRecoveryPassed)
							step.Pass();
						else
							step.Fail();
					}
                }
            }
        }

        void ChargeHoseChargeToolRecovery_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
			MyStaticVariables.RecoveryStartBlue = DateTime.Now;
			MyStaticVariables.RecoveryAbove50PsiBlue = DateTime.Now;
			Machine.Test[port].InitialRecoveryPressure = double.MinValue;

			step.SignalsToDisplay.Add(signal.HiSideToolPressure);
            step.ParametersToDisplay.Add(model.Recovery_Pressure_SetPoint);
            //dout.RecoveryPumpEnable.Enable();
            dout.HiSideCharge.Disable();
            dout.LoSideCharge.Disable();

            Machine.Cycle[port].bDockTheDataPlot = true;


            Machine.Test[port].LoadLowSideCounter = 20000;
            Machine.Cycle[port].bLoadLowSideCounter = true;
            Machine.Cycle[port].bDisableLowSideCharge = true;
            Machine.Test[port].LoadHiSideCounter = 20000;
            Machine.Cycle[port].bLoadHiSideCounter = true;
            Machine.Cycle[port].bDisableHiSideCharge = true;

            MyStaticVariables.dtGoodRecoveryPressureStart = DateTime.Now;

            if ((Machine.Test[port].SerialNumber == "BLANK TEST") || (Machine.Test[port].ForceHiSideChargeFlag) || (Machine.Test[port].ForceLowSideChargeFlag) || Machine.Test[port].ForceChargeFlag || (Machine.Test[port].RecoverUnitFlag) )
            {
                if (Config.Mode.RecoverStemsRetractedForceCharge.ProcessValue)
                {
                    dout.HiSideToolStem.Disable();
                    dout.LoSideToolStem.Disable();
                }
                else
                {
                    if (Machine.Test[port].RecoverHiSideFlag)
                    {
                        dout.HiSideToolStem.Enable();
                    }
                    else
                    {
                        dout.HiSideToolStem.Disable();
                    }
                    if (Machine.Test[port].RecoverLowSideFlag)
                    {
                        dout.LoSideToolStem.Enable();

                    }
                    else
                    {
                        dout.LoSideToolStem.Disable();
                    }
                }
            }
            else
            {
                if (Config.Mode.RecoverStemsRetractedUnits.ProcessValue)
                {
                    dout.HiSideToolStem.Disable();
                    dout.LoSideToolStem.Disable();
                }
                else
                {
                    if (Machine.Test[port].RecoverHiSideFlag)
                    {
                        dout.HiSideToolStem.Enable();
                    }
                    else
                    {
                        dout.HiSideToolStem.Disable();
                    }
                    if (Machine.Test[port].RecoverLowSideFlag)
                    {
                        dout.LoSideToolStem.Enable();

                    }
                    else
                    {
                        dout.LoSideToolStem.Disable();
                    }
                }
            }
            Thread.Sleep(1000);

            if (port == Port.Blue)
            {
                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                {
                    dout.HiSideRecovery.Enable();
                }
                if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                {
                        dout.LoSideRecovery.Enable();
                    
                }
            }
            else
            {
                if (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue)
                {
                    dout.HiSideRecovery.Enable();
                }
                if (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue)
                {
                    dout.LoSideRecovery.Enable();
                }
            }
            Machine.Test[port].RecoverHiSideFlag = false;
            Machine.Test[port].RecoverLowSideFlag = false;

        }

        void ChargeToolEvacuation_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleFail(step);
        }

        void ChargeToolEvacuation_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Reset.Start();
        }

        void ChargeToolEvacuation_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Pass(); // step.Fail();
        }

        void ChargeToolEvacuation_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            if (IO.Signals.BluePartVacuum.Value < Config.Pressure.PartialChargeServiceValveEvacSetpoint.ProcessValue)
            {
                step.Pass();
            }
        }

        void ChargeToolEvacuation_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            dout.HiSideCharge.Disable();
            dout.HiSideRecovery.Disable();
            dout.LoSideCharge.Disable();
            dout.LoSideRecovery.Disable();
            Thread.Sleep(1000);
            dout.HiSideEvac.Enable();
            dout.LoSideEvac.Enable();
        }

        void OperatorAcknowledge_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        void OperatorAcknowledge_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Reset.Start();
        }

        void OperatorAcknowledge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (IO.DIn.AcknowledgeButton1.Value)
            //{
            //    step.Pass();
            //}
        }

        void OperatorAcknowledge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            
        }

        void WaitForAcknowledge_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
                if (port == Port.Blue)
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagBlue || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                        step.Pass();
                    }
                }
                else
                {
                    if (MyStaticVariables.WaitForAcknowledgeFlagWhite || IO.DIn.Acknowledge.Value)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                        step.Pass();
                    }
                }
            
        }

        void WaitForAcknowledge_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            //IO.DOut.AlarmOutput.Enable();
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue= false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
        }


        void NotEnergized_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.DIn.MCRPower24VoltSense.Value)
            {
                NotEnergized.Stop();
                Machine.ManualCommands.Reset();
            }
        }

        void NotEnergized_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.ReadyToTest = false;
            CloseAllValves();
        }

        DateTime GreenLightOnTime;
        DateTime GreenLightOffTime;
        void UpdateTime_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds < 3600.0)
            {
                if (port == Port.Blue)
                {
                    IO.Signals.BlueElapsedTime.Value = step.ElapsedTime.TotalSeconds;
                }
                else
                {
                    IO.Signals.WhiteElapsedTime.Value = step.ElapsedTime.TotalSeconds;
                }
            }
            Machine.Test[port].ElapsedTime = step.ElapsedTime.TotalSeconds;
            if ((Machine.Test[port].PassedFlag)&&(Machine.Cycle[port].ChargeHoseChargeToolRecovery.State!=CycleStepState.InProcess))
            {
                if(!dout.PassGreenLight.Value)
                {
                    dout.PassGreenLight.Enable();
                }
            }
            else
            {
                if ((Machine.Test[port].FailedFlag) && (Machine.Cycle[port].ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess))
                {
                    if(!dout.FailRedLight.Value)
                    {
                        dout.FailRedLight.Enable();
                    }
                }
                else
                {
                    if ((Machine.Test[port].NoTestFlag)&&(Machine.Cycle[port].ChargeHoseChargeToolRecovery.State!=CycleStepState.InProcess))
                    {
                        if (!dout.FailRedLight.Value)
                        {
                            dout.FailRedLight.Enable();
                        }
                    }
                    else
                    {
                        if (dout.PassGreenLight.Value)
                        {
                            TimeSpan LightOn = (DateTime.Now - GreenLightOnTime);
                            if (LightOn.TotalSeconds > 0.5)
                            {
                                GreenLightOffTime = DateTime.Now;
                                dout.PassGreenLight.Disable();
                            }
                        }
                        else
                        {
                            TimeSpan LightOff = (DateTime.Now - GreenLightOffTime);
                            if (LightOff.TotalSeconds > 0.5)
                            {
                                GreenLightOnTime = DateTime.Now;
                                dout.PassGreenLight.Enable();
                            }
                        }
                    }
                }
            }
        }

        void WaitForPalmButtons_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Reset.Start();
        }

        void WaitForPalmButtons_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Config.Mode.AutoDemoCycleEnable.ProcessValue)
            {
                //Reset.Start();
                step.Pass();
            }
            else
            {
                //if ((!IO.DIn.LeftPalmButton.Value) && (!IO.DIn.RightPalmButton.Value))
                //{
                //    //Reset.Start();
                //    step.Pass();
                //}
            }
        }

        void WaitForPalmButtons_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

        }

        delegate void SetControlValueCallback(Control oControl, string propName, object propValue);
        public void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[] { oControl, propName, propValue });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        p.SetValue(oControl, propValue, null);
                    }
                }
            }
        }
        void SetDataPlotLegendState(bool bVal) // sets the data plot legend visibility
        {
            bDataPlotLegendVisible = bVal;
            bUpdateDataPlotSettings = true;
        }

        void SetSemiLogDataPlotState(bool bVal)
        {
            if (bVal)
            { // enable semilog data plot
                Machine.DataPlot[Port.Blue].Settings.PlotSemiLog = true;
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMaxDn, "Visible", true);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMaxUp, "Visible", true);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMinDn, "Visible", true);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMinUp, "Visible", true);
            }
            else
            { // disable semilog data plot
                Machine.DataPlot[Port.Blue].Settings.PlotSemiLog = false;
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMaxDn, "Visible", false);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMaxUp, "Visible", false);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMinDn, "Visible", false);
                SetControlPropertyValue(Machine.DataPlot[Port.Blue].YMinUp, "Visible", false);
            }
        }

        protected void ShowDataPlotTrace(AnalogSignal analogSig, bool bHideAllOtherTraces)
        {
            int ii, ndx = -1;
            try
            {
                if (bHideAllOtherTraces)
                { // Hide all traces
                    for (ii = 0; ii < Machine.DataPlot[0].Traces.Count; ii++)
                        Machine.DataPlot[0].Traces.Settings.TraceVisibility[ii] = false;
                }
                String strName = analogSig.Key.ToString();
                ndx = Machine.DataPlot[0].Traces.IndexOf(strName);
                Machine.DataPlot[0].Traces.Settings.TraceVisibility[ndx] = true;
                bUpdateDataPlotSettings = true;
            }
            catch (Exception ex)
            {
                VtiEvent.Log.WriteInfo(ex.Message, VtiEventCatType.Test_Cycle);
            }
        }

        delegate string GetControlValueCallback(Control oControl, string propName);
        public string GetControlPropertyValue(Control oControl, string propName)
        {
            string strRet = null;
            if (oControl.InvokeRequired)
            {
                GetControlValueCallback d = new GetControlValueCallback(GetControlPropertyValue);
                strRet = (string)oControl.Invoke(d, new object[] { oControl, propName });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if (p.Name.ToUpper() == propName.ToUpper())
                    {
                        strRet = (string)p.GetValue(oControl, null);
                        return strRet;
                    }
                }
            }
            return strRet;
        }



        //private void UpdateElapsedTime()
        //{
        //    double dateTime;
        //    dateTime = signal.ElapsedTime.Value;
        //    CrntTime[port] = DateTime.Now;
        //    TimeSpan ElapsedTime = CrntTime[port] - StartTime[port];
        //    signal.ElapsedTime.Value = ElapsedTime.TotalSeconds;
        //}

        // Visual Basic Lives on: 
        // using Microsoft.VisualBasic
        // DateAndTime.DateDiff(DateInterval.Minute, LargeBlowerIdleStart, DateTime.Now, FirstDayOfWeek.Monday, FirstWeekOfYear.Jan1)


        public ArrayList HighN2CalibrationArrayList = new ArrayList();
        public string[,] HighN2CalibrationArray;
        public Int16 counter = 0;
        void ATestStep_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            return;
        }

        void ATestStep_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //WaitForPartTracerProcessToComplete.Start();
            //step.Prompt = string.Format(Localization.ATestStep_PromptPass, .00023F);

            // Creating directory
            //string path;
            //path = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            //Console.WriteLine(path);
            //string newpath = System.IO.Path.Combine(path, "SMCITV Calibration Data");
            //Console.WriteLine(newpath);
            //if (!Directory.Exists(newpath))
            //{
            //    try
            //    {
            //        Directory.CreateDirectory(newpath);
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            //// Stream Writer
            //try
            //{
            //    path = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            //    path = System.IO.Path.Combine(path, "SMC Cal Data.txt");
            //}
            //catch (Exception ex) { Console.WriteLine(ex.Message); };


            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(path))
            //{
            //    for (int y = 0; y < HighN2CalibrationArray.GetLength(0); y++)
            //    {
            //        if (HighN2CalibrationArray[y, 0] != null)
            //        {
            //            file.WriteLine(HighN2CalibrationArray[y, 0] + "," + HighN2CalibrationArray[y, 1]);
            //            Console.WriteLine(HighN2CalibrationArray[y, 0] + "," + HighN2CalibrationArray[y, 1]);
            //        };
            //    }
            //}


            //newpath = System.IO.Path.Combine(newpath, "filename " + DateTime.Now.ToString("D") + ".txt");
            //File.Copy(path, newpath);

            //// Clear the contents of the Array
            //Array.Clear(HighN2CalibrationArray, 0, HighN2CalibrationArray.Length);
            //// confirmed cleared
            //for (int y = 0; y < HighN2CalibrationArray.GetLength(0); y++)
            //{
            //    if (HighN2CalibrationArray[y, 0] != null)
            //    {
            //        Console.WriteLine(HighN2CalibrationArray[y, 0] + "," + HighN2CalibrationArray[y, 1]);
            //    };
            //}

            // // Read the file back
            //string[] lines = System.IO.File.ReadAllLines(path);
            //Int16 counting = 0;
            //foreach (string line in lines)
            //{
            //    Console.WriteLine("This: " + line);
            //    HighN2CalibrationArray[counting, 0] = (line.Substring(0, line.IndexOf(","))).Trim();
            //    HighN2CalibrationArray[counting, 1] = (line.Substring((line.IndexOf(",") + 1), line.Length - (line.IndexOf(",") + 1))).Trim();
            //    Console.WriteLine("Same: " + HighN2CalibrationArray[counting, 0] + "," + HighN2CalibrationArray[counting, 1]);
            //}



            //string[] text = {"first line", "second line", "third"};
            //System.IO.File.WriteAllLines(path, text);  //can only be a one deminsional array

            // Example #2: Write one string to a text file. 
            //string text = "A class is the most powerful data type in C#. Like structures, " +
            //               "a class defines the data and behavior of the data type. ";
            //System.IO.File.WriteAllText(@"C:\Users\Public\TestFolder\WriteText.txt", text);


        }

        void ATestStep_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {


            //// Array List http://www.dotnetperls.com/arraylist
            ////Console.WriteLine(HighN2CalibrationArrayList[HighN2CalibrationArrayList.Count - 1].ToString());
            //HighN2CalibrationArrayList.Add((HighN2CalibrationArrayList.Count + 1) + ", " + (HighN2CalibrationArrayList.Count + 2));
            ////Console.WriteLine(HighN2CalibrationArrayList[HighN2CalibrationArrayList.Count - 1]);

            //// Multideminsional Array
            //HighN2CalibrationArray[counter, 0] = counter.ToString(); // set point
            //HighN2CalibrationArray[counter, 1] = (counter + 100).ToString();  // pressure
            ////Console.WriteLine("I:" + counter + " HNC(" + counter + ", 0)=" + HighN2CalibrationArray[counter, 0]);
            //counter = ++counter;

            //C# equivalent to redim an array
            //int[] YourArray;
            //...
            //int[] temp = new int[i + 1];
            //if (YourArray != null)
            //    Array.Copy(YourArray, temp, Math.Min(YourArray.Length, temp.Length));
            //YourArray = temp;


            // Elapsed Time Usage
            //if (step.ElapsedTime.Seconds > 5F)
            //{
            //    step.Prompt = string.Format(Localization.ATestStep_PromptPass, .00023d);
            //}
            //if (step.ElapsedTime.Seconds > 10F)
            //{
            //    step.Pass();
            //}
        }


        void AutoDemoCycleStartUp_ValveDelayElapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Config.Mode.AutoDemoCycleEnable.ProcessValue == true && Config.TestMode == TestModes.Autotest)
            {
                //? How do Idle calculate the Time since as step started?  delay between bt and cl
                {
                    VtiEvent.Log.WriteEntry(string.Format("CHAMBER LEAK", ""), VTIWindowsControlLibrary.Classes.SystemDiagnostics.EventLogEntryType.Information);
                    Config.CurrentModel[Port.Blue].LoadFrom(Config.DefaultModel);
                    Machine.Test[Port.Blue].SerialNumber = "CHAMBER LEAK";
                    
                    Machine.Cycle[Port.Blue].ScanSerialNumber2.Stop();
                    Machine.Cycle[Port.Blue].CycleStart();
                    Machine.Cycle[Port.Blue].AutoDemoCycleStartUp.Stop();
                }
            }
        }

        //void AutoDemoCycleStartUp_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        //{

        //} 


        public bool IsIdle
        {
            get
            {
                bool idle = true;

                if (Properties.Settings.Default.DualPortSystem)
                {
                    if (port == 0 ? Config.Mode.BlueCircuit2PortEnabled : Config.Mode.WhiteCircuit1PortEnabled)
                    {
                        if (!Idle.Enabled) idle = false;
                    }
                }
                else
                {
                    if (!ScanSerialNumber2.Enabled) idle = false;
                }

                return idle;
            }
        }

        public virtual bool RequiresAcknowledge
        {
            get
            {
                return
                    this.CycleSteps.Any(s => s.State == CycleStepState.Failed) ||
                    TestAborted.State == CycleStepState.InProcess ||
                    InvalidModelNumber.State == CycleStepState.InProcess;
            }
        }

        public void AppendToToolTip(string txt1)
        {
            MyStaticVariables.ToolTip1 = MyStaticVariables.ToolTip1 + txt1 + Environment.NewLine;
        }
        public void ClearToolTip()
        {
            MyStaticVariables.ToolTip1 = "";
        }
        public virtual void Acknowledge()
        {
            // If any step is failed, reset the cycle
            if (this.CycleSteps.Any(s => s.State == CycleStepState.Failed))
            {
                Reset.Start();
            }

            // check to see if this test is waiting for an acknowledge
            else if (TestAborted.State == CycleStepState.InProcess ||
                InvalidModelNumber.State == CycleStepState.InProcess)
            {
                Reset.Start();
            }
            // otherwise, abort this test
            else if (!IsIdle)
            {
                CycleAbort(Localization.TestAborted, Localization.TestAbortedTH);
                TestAborted.Start();
            }
        }

        public virtual void CloseAllValves()
        {
            try
            {
                // hide manual commands window
                //Machine.ManualCommands.Hide();
                // close all valves
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void DataPlotSetup(int APort, float LinYMax, float LinYMin, bool ResetDataPlot)
        { // Use for linear, optional restart plot
            APort = 0;
            if (ResetDataPlot)
            {
                Machine.DataPlot[APort].Start();
                Machine.DataPlot[APort].Settings.AutoShowAll = true;
                Machine.DataPlot[APort].Settings.AutoShowEnd = false;
            }
            // Set up the dataplot
            Machine.DataPlot[APort].Settings.YMax = (float)LinYMax;
            Machine.DataPlot[APort].Settings.YMin = (float)LinYMin;
            SetSemiLogDataPlotState(false);

        }
        public void DataPlotSetup(int APort, float LinYMax, float LinYmin, float XMax, float Xmin, bool ResetDataPlot)
        { // Use for linear and scale xmax and xmin, optional restart plot
            APort = 0;
            if (ResetDataPlot)
            {
                Machine.DataPlot[APort].Start();
                Machine.DataPlot[APort].Settings.AutoShowAll = true;
                Machine.DataPlot[APort].Settings.AutoShowEnd = false;
            }
            // Set up the dataplot
            Machine.DataPlot[APort].Settings.XMin = Xmin;
            Machine.DataPlot[APort].Settings.XMax = XMax;  // reset xmax if you reset the data plot
            Machine.DataPlot[APort].Settings.YMax = LinYMax;
            Machine.DataPlot[APort].Settings.YMin = LinYmin;
            SetSemiLogDataPlotState(false);

        }
        public void DataPlotSetup(int APort, int YMaxExpo, int YminExpo, bool AutoScaleYMax, bool ResetDataPlot)
        { // Use for logrithmic, optional restart plot
            APort = 0;

            if (ResetDataPlot)
            {
                Machine.DataPlot[APort].Start();
                Machine.DataPlot[APort].Settings.AutoShowAll = true;
                Machine.DataPlot[APort].Settings.AutoShowEnd = false;
            }

            // Set up the dataplot
            if (YMaxExpo < YminExpo || YMaxExpo == YminExpo)
            {
                // invalid values
            }
            else
            {
                Machine.DataPlot[APort].Settings.YMaxExp = YMaxExpo;
                Machine.DataPlot[APort].Settings.YMinExp = YminExpo;
            }
            Machine.DataPlot[APort].Settings.AutoScaleYMaxExp = AutoScaleYMax;
            SetSemiLogDataPlotState(true);

        }


        public void DataPlotSetup(int APort, int YMaxExpo, int YminExpo, bool AutoScaleYMax, float XMax, float Xmin, bool ResetDataPlot)
        { // Use for logrithmic and scale xmax and xmin, optional restart plot
            APort = 0;

            if (ResetDataPlot)
            {
                Machine.DataPlot[APort].Start();
                Machine.DataPlot[APort].Settings.AutoShowAll = true;
                Machine.DataPlot[APort].Settings.AutoShowEnd = false;
            }

            // Set up the dataplot
            Machine.DataPlot[APort].Settings.XMin = Xmin;
            Machine.DataPlot[APort].Settings.XMax = XMax;  // reset xmax if you reset the data plot
            if (YMaxExpo < YminExpo || YMaxExpo == YminExpo)
            {
                // invalid values
            }
            else
            {
                Machine.DataPlot[APort].Settings.YMaxExp = YMaxExpo;
                Machine.DataPlot[APort].Settings.YMinExp = YminExpo;
            }
            Machine.DataPlot[APort].Settings.AutoScaleYMaxExp = AutoScaleYMax;
            SetSemiLogDataPlotState(true);

        }
        //        // Set up the dataplot
        ////Machine.DataPlot[APort].Stop();
        //SetSemiLogDataPlotState(true);
        //SetDataPlotLegendState(true);
        //if (ResetDataPlot)   Machine.DataPlot[APort].Start();
        //Machine.DataPlot[APort].Settings.XMax = (float)30;  // reset xmax if you reset the data plot
        //Machine.DataPlot[APort].Settings.AutoShowAll = true;
        ////Machine.DataPlot[APort].Settings.AutoScaleYMaxExp = AutoScaleYMax;
        //// Zoom in data plot to +/- x around process value and limit
        ////Machine.DataPlot[APort].Settings.PlotSemiLog = false;
        ////Machine.DataPlot[APort].Settings.YMax =(float)1E-3;
        //Machine.DataPlot[APort].Settings.YMaxExp = -4;
        ////Machine.DataPlot[APort].Settings.YMin = (float)0;
        //Machine.DataPlot[APort].Settings.YMinExp = -9;  


        public override void CycleStart()
        {
            //IO.DOut.ConveyorEnable.Disable();

            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }

            Machine.Test[port].RunningATestFlag = true;
            switch (Config.Control.Language.ProcessValue)
            {
                case Languages.English:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.EnglishCulture;
                    break;

                case Languages.Spanish:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.SpanishCulture;
                    break;
            }

            bool QuitFlag;
            Idle.Stop();
            MyStaticVariables.ReadyToTest = false;
            QuitFlag = false;

            //if ((Config.Mode.SelectModelFromSerialNumber.ProcessValue)&&(Machine.Test[port].SerialNumber.Length>=7))
            //{
            //    //set the model from the serial number
            //    string SNModelCode = Machine.Test[port].SerialNumber.Substring(3, 3);
                
            //    //foreach Model model in Mo

            //    switch (SNModelCode)
            //    {
            //        case "180":
            //            Config.CurrentModel[port].Load("15 TON");
            //            break;
            //        case "210":
            //            Config.CurrentModel[port].Load("17.5 TON");
            //            break;
            //        case "240":
            //            Config.CurrentModel[port].Load("20 TON");
            //            break;
            //        case "300":
            //            Config.CurrentModel[port].Load("25 TON");
            //            break;
            //        default:
            //            Config.CurrentModel[port].Load("DEFAULT");
            //            break;
            //    }

            //    //warn if the default model
            //    if (model.Name == "DEFAULT")
            //    {
            //        switch (MessageBox.Show("DEFAULT Model Selected, do you want to run the default model?", "DEFAULT MODEL SELECTED", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            //        {
            //            case DialogResult.Yes:
            //                QuitFlag = false;
            //                break;
            //            case DialogResult.No:
            //                QuitFlag = true;
            //                Reset.Start();
            //                break;
            //        }
                    
            //    }
            //}

            if (!QuitFlag)
            {
                Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;

                UpdateTime.Start();

                dout.FailRedLight.Disable();
                dout.PassGreenLight.Disable();

                if (port == Port.Blue)
                {
                    IO.Signals.BlueStartWeight.Value = 0.0;
                    IO.Signals.BlueNetWeight.Value = 0.0;
                }
                else
                {
                    IO.Signals.WhiteStartWeight.Value = 0.0;
                    IO.Signals.WhiteNetWeight.Value = 0.0;
                }

                //IO.DOut.VacuumPumpEnable.Enable();
                if (!IO.DOut.EvacPumpEnable.Value)
                {
                    IO.DOut.EvacPumpEnable.Enable();
                    Thread.Sleep(1000);
                }
                //if (!IO.DOut.LowSideEvacPump.Value)
                //{
                //    IO.DOut.LowSideEvacPump.Enable();
                //}

                VtiEvent.Log.WriteInfo("(" + PortName + ") " + String.Format(Localization.CycleStarted, Machine.Test[port].SerialNumber),
                    VtiEventCatType.Test_Cycle);

                // Reset prompt
                Machine.Prompt[port].Clear();
                Machine.Prompt[port].AppendText(Localization.CurrentTestMode + ": " + Config.TestMode.ToString() + Environment.NewLine);
                Machine.Prompt[port].AppendText(Environment.NewLine);
                if (Machine.Test[port].ModelNumber == "")
                {
                    Machine.Test[port].ModelNumber = model.Name;
                }
                Machine.Prompt[port].AppendText(
                    string.Format(Localization.ModelNumber, Machine.Test[port].ModelNumber) + Environment.NewLine);

                Machine.Prompt[port].AppendText(Environment.NewLine);
                if (!string.IsNullOrEmpty(Machine.Test[port].SerialNumber))
                    Machine.Prompt[port].AppendText(
                        string.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber) + Environment.NewLine);

                Machine.Prompt[port].AppendText(Environment.NewLine);

                {
                    TestInProgress = true;
                };

                // Set up UutRecord
                this.UutRecord = new UutRecord
                {
                    SerialNo = Machine.Test[port].SerialNumber,
                    SystemID = Config.Control.System_ID,
                    ModelNo = Machine.Test[port].ModelNumber,//model.Name,
                    OpID = Machine.Test[port].OpID,//Config.OpID,
                    DateTime = DateTime.Now,
                    TestType = "Ref Charge",
                    TestPort = PortName
                };
                Machine.Test[port].RefName="";
                if (port == Port.Blue)
                {
                    Machine.Test[port].RefName = Config.Control.BlueRefrigerantName.ProcessValue;
                }
                else
                {
                    Machine.Test[port].RefName = Config.Control.WhiteRefrigerantName.ProcessValue;
                }

                AppendToToolTip($"{Machine.Test[port].SerialNumber} | {Machine.Test[port].ModelNumber} |{DateTime.Now.ToLongTimeString()}");

                // Machine.Test[Port.Blue].FilledWithTracerGas = false;  // MyStaticVariables.FilledWithTracerGas = false;

                ////CycleStartDelay.Start();
                //// AutoRun the DataPlot
                //if (Machine.DataPlot[port].Settings.AutoRun1) //  if (Machine.OpFormSingle.DataPlot.Settings.AutoRun1)
                //{
                //    Machine.OpFormDual.DataPlot[port].Settings.XMax = 60F;
                //    Machine.OpFormDual.DataPlot[port].Settings.DataCollectionInterval = 0.25F;

                //    Machine.OpFormDual.DataPlot[port].Start();
                //}

                CycleStartDelay.Start();

                //if (port == Port.Blue)
                //{
                //    if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                //    {
                //        if (((Machine.Test[port].ForceHiSideChargeFlag)||(Machine.Test[port].ForceChargeFlag)) && (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue))
                //        {
                //            if (model.HiSidePercentage.ProcessValue > 0.5)
                //            {
                //                //HiSideCharge.Start();
                //                HiSideToolCheck.Start();
                //            }
                //            else
                //            {
                //                //LowSideCharge.Start();
                //                LowSideToolCheck.Start();
                //            }
                //        }
                //        else
                //        {
                //            if ((Machine.Test[port].ForceLowSideChargeFlag) && (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue))
                //            {
                //                //LowSideCharge.Start();
                //                LowSideToolCheck.Start();
                //            }
                //            else
                //            {
                //                if (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue)
                //                {
                //                    //HiSideToolCheck.Start();
                //                    HiSideToolCheck.Start();
                //                }
                //                else
                //                {
                //                    if (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue)
                //                    {
                //                        //LowSideToolCheck.Start();
                //                        LowSideToolCheck.Start();
                //                    }
                //                    else
                //                    {
                //                        CycleFail(Localization.Circuit2NoToolEnabled, Localization.CircuitNoToolEnabledTH);
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //else//white port
                //{
                //    if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                //    {
                //        if (((Machine.Test[port].ForceHiSideChargeFlag)||Machine.Test[port].ForceChargeFlag) && (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                //        {
                //            if (model.HiSidePercentage.ProcessValue > 0.5)
                //            {
                //                //HiSideCharge.Start();
                //                //HiSideToolCheck.Start();
                //                WaitToStartToolCheck.Start();
                //            }
                //            else
                //            {
                //                //LowSideCharge.Start();
                //                //LowSideToolCheck.Start();
                //                WaitToStartToolCheck.Start();
                //            }
                //        }
                //        else
                //        {
                //            if ((Machine.Test[port].ForceLowSideChargeFlag) && (Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue))
                //            {
                //                //LowSideCharge.Start();
                //                //LowSideToolCheck.Start();
                //                WaitToStartToolCheck.Start();
                //            }
                //            else
                //            {
                //                if ((!Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue) && (!Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                //                {
                //                    CycleFail(Localization.Circuit1NoToolEnabled, Localization.CircuitNoToolEnabledTH);
                //                }
                //                else
                //                {
                //                    WaitToStartToolCheck.Start();
                //                }
                //            }
                //        }
                //    }
                //}
            }
            else
            {
                Reset.Start();
            }
        }

        public override void CycleStop()
        {
            // Stop the DataPlot
            if (Machine.DataPlot[Port.Blue].Settings.AutoRun1) // if (Machine.OpFormSingle.DataPlot.Settings.AutoRun1)
            {
                Machine.OpFormSingle.DataPlot.Stop();
            }
            TestInProgress = false;
            // Stop all cycle steps
            try
            {
                foreach (CycleStep step in this.EnabledSteps)
                {
                    if (!step.Equals(this.Idle) && step.Enabled) step.Stop();
                }
            }
            catch
            {
            }
            //if (Config.Mode.AutoDemoCycleEnable)
            //{
            //    AutoDemoCycleStartUp.Start();
            //}
        }

        public virtual void CycleAbort(String TestResult) { CycleAbort(TestResult, TestResult); }
        public virtual void CycleAbort(String TestResult, String TestHistoryEntry)
        {
            VtiEvent.Log.WriteWarning(TestResult,
                VtiEventCatType.Test_Cycle,
                String.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber));

            this.CycleStop();

            this.CycleNoTest(TestResult, TestHistoryEntry);
        }

        public virtual void CycleNoTest(String TestResult) { CycleNoTest(TestResult, TestResult); }
        public virtual void CycleNoTest(String TestResult, String TestHistoryEntry)
        {
            if (Config.Mode.RecoverStemsRetractedUnits.ProcessValue && TestResult == Localization.ToolRecoveryFailed) { } // dont write recovery failure if stems are retracted when recovering
            else Machine.Test[port].TestResultToSendToRemoteSQLDatabase = Config.Control.StatusWriteFailValue.ProcessValue;
            Machine.Cycle[port].bStopDataPlot = true;

            Machine.Test[port].PassedFlag = false;
            MyStaticVariables.PassedFlag = false;

            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;
            Machine.Test[port].NoTestFlag = true;

            if (port == Port.Blue)
            {
                Machine.Test[1].AbortTest = true;
            }
            else
            {
                Machine.Test[0].AbortTest = true;
            }

            //CloseAllValves();
            dout.HiSideCharge.Disable();
            dout.HiSideEvac.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();

            dout.LoSideCharge.Disable();
            dout.LoSideEvac.Disable();
            dout.LoSideRecovery.Disable();
            dout.LoSideToolStem.Disable();

            dout.AlarmOutput.Disable();
            dout.PassGreenLight.Disable();
            dout.FailRedLight.Disable();

            Machine.Cycle[port].bDisableHiSideCharge = true;
            Machine.Cycle[port].bDisableLowSideCharge = true;

            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = true;
                //IO.DOut.AlarmOutput.Enable();
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = true;
            }

            //IO.DOut.NoTestAmberLight.Enable();
            dout.PassGreenLight.Disable();
            dout.FailRedLight.Enable();

            dout.AlarmOutput.Enable();

            this.RecordCycleResults(TestResult, TestHistoryEntry, Color.Black, Color.Yellow);
            VtiEvent.Log.WriteWarning(TestResult,
                VtiEventCatType.Test_Cycle,
                String.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber));

            WaitForAcknowledge.Start();
        }

        public override void CycleNoTest(CycleStep step)
        {
            base.CycleNoTest(step);
            VtiEvent.Log.WriteWarning(step.Name,
                VtiEventCatType.Test_Cycle,
                String.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber));
        }

        public virtual void CycleFail(String TestResult) { CycleFail(TestResult, TestResult); }
        public virtual void CycleFail(String TestResult, String TestHistoryEntry)
        {
            Machine.Test[port].TestResultToSendToRemoteSQLDatabase=Config.Control.StatusWriteFailValue.ProcessValue;
            Machine.Cycle[port].bStopDataPlot = true;

            Machine.Test[port].PassedFlag = false;
            MyStaticVariables.PassedFlag = false;


            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;
            Machine.Test[port].FailedFlag = true;

            if (port == Port.Blue)
            {
                Machine.Test[1].AbortTest = true;
            }
            else
            {
                Machine.Test[0].AbortTest = true;
            }

            //CloseAllValves();
            dout.HiSideCharge.Disable();
            dout.HiSideEvac.Disable();
            dout.HiSideRecovery.Disable();
            dout.HiSideToolStem.Disable();

            dout.LoSideCharge.Disable();
            dout.LoSideEvac.Disable();
            dout.LoSideRecovery.Disable();
            dout.LoSideToolStem.Disable();

            dout.AlarmOutput.Disable();
            dout.PassGreenLight.Disable();
            dout.FailRedLight.Disable();

            Machine.Cycle[port].bDisableHiSideCharge = true;
            Machine.Cycle[port].bDisableLowSideCharge = true;

            //this.CycleStop();

            dout.PassGreenLight.Disable();
            dout.FailRedLight.Enable();

            dout.AlarmOutput.Enable();

            this.RecordCycleResults(TestResult, TestHistoryEntry, Color.Yellow, Color.Red);
            VtiEvent.Log.WriteInfo(TestResult,
                VtiEventCatType.Test_Cycle,
                String.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber));

            WaitForAcknowledge.Start();
        }

        public override void CycleFail(CycleStep step)
        {
            this.CycleStop();

            base.CycleFail(step);
            //VtiEvent.Log.WriteInfo(step.Name, VtiEventCatType.Test_Cycle);
            VtiEvent.Log.WriteInfo(step.Name,
                VtiEventCatType.Test_Cycle,
                String.Format(Localization.SerialNumberForLog, Machine.Test[port].SerialNumber));
        }

        public virtual void CyclePass(String TestResult) { CyclePass(TestResult, TestResult); }
        public virtual void CyclePass(String TestResult, String TestHistoryEntry)
        {
            Machine.Test[port].TestResultToSendToRemoteSQLDatabase=Config.Control.StatusWritePassValue.ProcessValue;

            Machine.Test[port].PassedFlag = true;
            MyStaticVariables.PassedFlag = true;
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
            }
            dout.PassGreenLight.Enable();
            dout.FailRedLight.Disable();

            
            this.RecordCycleResults(TestResult, TestHistoryEntry, Color.Black, Color.LawnGreen);
            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName,TestResult), VtiEventCatType.Test_Cycle);

        }

        public override void CyclePass(CycleStep step)
        {
            base.CyclePass(step);
            VtiEvent.Log.WriteInfo(step.Name, VtiEventCatType.Test_Cycle);
        }

        public void fnInsertATestRecord(String strConnectLennox,String strSqlCmd)
        {
            SqlConnection sqlConnection2;
            try
            {
                sqlConnection2 = new SqlConnection(strConnectLennox);
                SqlCommand cmd = new SqlCommand();
                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                // Set the test result and write the records

                cmd.CommandText = strSqlCmd;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection2;

                sqlConnection2.Open();

                cmd.ExecuteNonQuery();


                sqlConnection2.Close();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                VtiEvent.Log.WriteError(Ex.Message);
            }
            finally
            {
                try
                {
                    //sqlConnection2.Close();
                }
                catch
                {

                }
            }
        }

        public override void RecordCycleResults(String TestResult, String TestHistoryEntry, Color TestHistoryForeground, Color TestHistoryBackground)
        {
            // Add entry to Test History window
            Machine.TestHistory[port].AddEntry(Machine.Test[0].SerialNumber+": "+ TestHistoryEntry, TestHistoryForeground, TestHistoryBackground,MyStaticVariables.ToolTip1);
            ClearToolTip();
            //Machine.TestHistory[port].AddEntry(TestHistoryEntry, TestHistoryForeground, TestHistoryBackground);


            try
            {
                Int32 Pounds = Convert.ToInt32(Machine.Test[port].ChargeCalculatedWeight / 16 - 0.5);
                double Ounces = Machine.Test[port].ChargeCalculatedWeight - Convert.ToDouble(Pounds) * 16.0;
                if (Ounces > 15.5)
                {
                    Ounces = 0.0;
                    Pounds = Pounds + 1;
                }
                string TestResultString = TestResult + "," + Machine.Test[port].TestResultToSendToRemoteSQLDatabase + "," + String.Format("{0:0} lbs {1:0.00} oz", Pounds,Ounces);
                // Set the test result and write the records
                if (this.UutRecord != null)
                {
                    this.UutRecord.TestResult = TestResultString;
                    this.RecordResults();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                VtiEvent.Log.WriteError(ex.Message);

            }


            ////Lennox Data Storage
            ////Call Lennox Stored Procedure ProcessStatusUpdate if a coil
            //// Assemble connection string from parameters defined by Jason Hass 3/8/2016
            //// RemoteConnectionString build
            //string strConnectLennox = "";
            //if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
            //    strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            //if (strConnectLennox.Length > 0)
            //    if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            //strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            //strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            //if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            //if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            //VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

            //String CoilStatus = "";
            //SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);

            //if(Machine.Test[port].ForceChargeFlag||Machine.Test[port].RecoverUnitFlag)
            //{

            //}
            //else
            //{
            //    // Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
            //    // "test.TestResultToSendToRemoteSQLDatabase"
            //    // The appropriate status write pass value or status write fail value should be the string within the test. TestResultToSend ToRemoteSQLDatabase)
            //    if (strConnectLennox != "")
            //    {
            //        try
            //        {

            //            SqlCommand cmd = new SqlCommand("PROCESS_STATUS_UPDATE", sqlConnection1);

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.Add("SERIAL", SqlDbType.Char);
            //            cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
            //            cmd.Parameters["SERIAL"].Size = 18;

            //            cmd.Parameters.Add("PROCESS_STATUS", SqlDbType.Char);
            //            cmd.Parameters["PROCESS_STATUS"].Direction = ParameterDirection.Input;
            //            if (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == "") // If reset occurs value may be null
            //                Machine.Test[port].TestResultToSendToRemoteSQLDatabase = Config.Control.StatusWriteFailValue.ProcessValue;
            //            cmd.Parameters["PROCESS_STATUS"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
            //            cmd.Parameters["PROCESS_STATUS"].Size = 10;

            //            cmd.Parameters.Add("RetCode", SqlDbType.Char);
            //            cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
            //            //cmd.Parameters["RetCode"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
            //            cmd.Parameters["RetCode"].Size = 10;


            //            //SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
            //            //returnParameter.Direction = ParameterDirection.ReturnValue;

            //            cmd.Connection = sqlConnection1;

            //            sqlConnection1.Open();

            //            cmd.ExecuteNonQuery();

            //            // return value should match the process status sent if no error occured.
            //            CoilStatus = cmd.Parameters["RetCode"].Value.ToString();

            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //            // write the error message to the system log
            //            // write the error message to the system log
            //            VtiEvent.Log.WriteError(
            //              string.Format("An error writing to remote database (Lennox Status Table)"),
            //              VtiEventCatType.Database, ex.ToString());
            //        }
            //        finally
            //        {
            //            try
            //            {
            //                // always close the connection
            //                sqlConnection1.Close();
            //                //int intCoilStatus = Convert.ToInt32(CoilStatus);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //                // write the error message to the system log
            //                VtiEvent.Log.WriteError(
            //                  string.Format("An error writing to remote database (Lennox Status Table)"),
            //                  VtiEventCatType.Database, ex.ToString());
            //            };

            //            //if (CoilStatus == Config.Control.StatusReadPassValue.ProcessValue)
            //            //{
            //            //    // all is good

            //            //}
            //            //else
            //            //{
            //            //    // An error occured updating the status of the unit,  Call a cycle step to notify the operator

            //            //}

            //        }
            //    }
            //}

            ////Store to UutRecords
            //if (Machine.Test[port].ModelNumber == "")
            //{
            //    Machine.Test[port].ModelNumber = "DEFAULT";
            //}
            //Machine.Test[port].TestResult = TestResult;
            //if (strConnectLennox != "")
            //{
            //    try
            //    {
            //        SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //        SqlCommand cmd = new SqlCommand();
            //        Config.Control.TestResultTableName.ProcessValue = "UutRecords";
            //        // Set the test result and write the records
            //        String strSqlCmd =
            //"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //            //"insert into dbo.TestResult "+
            //"(SerialNo, ModelNo, DateTime, SystemID, OpID, TestType, TestResult, TestPort) " +
            //"values('" + Machine.Test[port].SerialNumber + "', '" +
            // Machine.Test[port].ModelNumber + "', '" +             
            // DateTime.Now.ToString() + "', '" +
            // Config.Control.System_ID.ProcessValue + "', '" +
            // Machine.Test[port].OpID + "', '" +
            // Config.Control.UutRecordTestType.ProcessValue + "', '" +
            // Machine.Test[port].TestResult + "', '" +
            // "BLUE PORT" + "')";
            //        Console.WriteLine(strSqlCmd);

            //        cmd.CommandText = strSqlCmd;
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = sqlConnection2;

            //        sqlConnection2.Open();

            //        cmd.ExecuteNonQuery();


            //        sqlConnection2.Close();
            //    }
            //    catch (Exception Ex)
            //    {
            //        Console.WriteLine(Ex.Message);
            //        VtiEvent.Log.WriteError(Ex.Message);
            //    }
            //}

            ////Get ID
            //Machine.Test[port].UutRecordID = "";
            //if (strConnectLennox != "")
            //{
            //    try
            //    {
            //        SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //        SqlCommand cmd = new SqlCommand();
            //        Object returnValue;
                                
            //        string sCommandText = string.Format("Select ID from dbo.UutRecords where SerialNo = '{0}' order by DateTime desc",Machine.Test[port].SerialNumber);
            //        cmd.CommandText = sCommandText;
            //        cmd.CommandType = CommandType.Text;
            //        cmd.Connection = sqlConnection2;

            //        sqlConnection2.Open();
            //        returnValue = cmd.ExecuteScalar();
            //        sqlConnection2.Close();

            //        string TempString = returnValue.ToString();

            //        Machine.Test[port].UutRecordID = TempString;
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}

            //if (Machine.Test[port].UutRecordID != "")
            //{
            //    //Call Lennox Stored Procedure ProcessStatusXRef if a coil
            //    if (Machine.Test[port].ForceChargeFlag || Machine.Test[port].RecoverUnitFlag)
            //    {

            //    }
            //    else
            //    {
            //        // Also add code here for providing all the information Lennox requires for Process Check Insert
            //        try
            //        {
            //            SqlCommand cmd = new SqlCommand("PROCESS_CHECK_INSERT", sqlConnection1);

            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.Parameters.Add("SERIAL", SqlDbType.Char);
            //            cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
            //            cmd.Parameters["SERIAL"].Size = 18;

            //            cmd.Parameters.Add("RESULTS_ID", SqlDbType.Char);
            //            cmd.Parameters["RESULTS_ID"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["RESULTS_ID"].Value = Machine.Test[port].UutRecordID;
            //            cmd.Parameters["RESULTS_ID"].Size = 18;

            //            string Test_Status = (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == Config.Control.StatusWritePassValue.ProcessValue) ? "PASS" : "FAIL";
            //            cmd.Parameters.Add("TEST_STATUS", SqlDbType.Char);
            //            cmd.Parameters["TEST_STATUS"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["TEST_STATUS"].Value = Test_Status;
            //            cmd.Parameters["TEST_STATUS"].Size = 10;

            //            cmd.Parameters.Add("LINE", SqlDbType.Char);
            //            cmd.Parameters["LINE"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["LINE"].Value = Config.Control.LennoxLineNum.ProcessValue;
            //            cmd.Parameters["LINE"].Size = 10;

            //            cmd.Parameters.Add("STATION", SqlDbType.Char);
            //            cmd.Parameters["STATION"].Direction = ParameterDirection.Input;
            //            cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
            //            cmd.Parameters["STATION"].Size = 10;

            //            cmd.Parameters.Add("RetCode", SqlDbType.Char);
            //            cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
            //            //cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
            //            cmd.Parameters["RetCode"].Size = 10;

            //            //SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
            //            //returnParameter.Direction = ParameterDirection.ReturnValue;

            //            cmd.Connection = sqlConnection1;

            //            sqlConnection1.Open();

            //            cmd.ExecuteNonQuery();

            //            // RetCode is defind in stored proc @RetCode but is never set
            //            //String CoilStatus = cmd.Parameters["RetCode"].Value;
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //            // write the error message to the system log
            //            VtiEvent.Log.WriteError(
            //                  string.Format("An error writing to remote database (Lennox Status Table)"),
            //                  VtiEventCatType.Database, ex.ToString());
            //        }
            //        finally
            //        {
            //            try
            //            {
            //                // always close the connection
            //                sqlConnection1.Close();
            //                //int intCoilStatus = Convert.ToInt32(CoilStatus);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine(ex.Message);
            //                // write the error message to the system log
            //                VtiEvent.Log.WriteError(
            //                  string.Format("An error writing to remote database (Lennox Status Table)"),
            //                  VtiEventCatType.Database, ex.ToString());
            //            };

            //            //if (CoilStatus == Config.Control.StatusReadPassValue.ProcessValue)
            //            //{
            //            //    // all is good

            //            //}
            //            //else
            //            //{
            //            //    // An error occured updating the status of the unit,  Call a cycle step to display to notify the operator

            //            //}

            //        }

            //    }

            //    //Store to UutRecordDetails

            //    if (Machine.Test[port].InitialEvacResult != "Not Run")
            //    {
            //        //InitialEvacTime
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "InitialEvac" + "', '" +
            //         Machine.Test[port].InitialEvacResult + "', '" +
            //         "InitialEvacTime" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "InitialEvacDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.Initial_Evac_Delay.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //InitialEvacSetpoint
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "InitialEvac" + "', '" +
            //         Machine.Test[port].InitialEvacResult + "', '" +
            //         "InitialEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "InitialEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //InitialEvacPressure
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "InitialEvac" + "', '" +
            //         Machine.Test[port].InitialEvacResult + "', '" +
            //         "InitialEvacPressure" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].InitialEvacPressure) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "InitialEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].FinalEvacResult != "Not Run")
            //    {
            //        //FinalEvacTime
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "FinalEvac" + "', '" +
            //         Machine.Test[port].FinalEvacResult + "', '" +
            //         "FinalEvacTime" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "FinalEvacDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.Final_Evac_Delay.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }


            //        //FinalEvacSetpoint
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "FinalEvac" + "', '" +
            //         Machine.Test[port].FinalEvacResult + "', '" +
            //         "FinalEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "FinalEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //FinalEvacPressure
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "FinalEvac" + "', '" +
            //         Machine.Test[port].FinalEvacResult + "', '" +
            //         "FinalEvacPressure" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].FinalEvacPressure) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "FinalEvacSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].EvacTimeBeforeLastRORResult != "Not Run")
            //    {
            //        //EvacTimeBeforeLastROR
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "EvacTimeBeforeLastROR" + "', '" +
            //         Machine.Test[port].EvacTimeBeforeLastRORResult + "', '" +
            //         "EvacTimeBeforeLastROR" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "MaxEvacDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.Maximum_Evac_Delay.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //EvacPressBeforeLastROR
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "EvacPressBeforeLastROR" + "', '" +
            //         Machine.Test[port].EvacTimeBeforeLastRORResult + "', '" +
            //         "EvacPressBeforeLastROR" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].EvacPressBeforeLastROR) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "FinalEvacSetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.Final_Evac_Pressure_SetPoint.ProcessValue) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].BasePressBeforeLastRORResult != "Not Run")
            //    {
            //        //BasePressBeforeLastROR
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "BasePressBeforeLastROR" + "', '" +
            //         Machine.Test[port].BasePressBeforeLastRORResult + "', '" +
            //         "BasePressBeforeLastROR" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].BasePressBeforeLastROR) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "BasePressSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Config.Pressure.Base_Pressure_Check_Pressure_SetPoint.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].BaseTimeBeforeLastROR) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].RORResult != "Not Run")
            //    {
            //        //RORTime
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "RateOfRise" + "', '" +
            //         Machine.Test[port].RORResult + "', '" +
            //         "RORTime" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].RORTime) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "RORDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.ROR_Pressure_Check_Delay.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //RORPressSetpoint
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "RateOfRise" + "', '" +
            //         Machine.Test[port].RORResult + "', '" +
            //         "RORSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].RORSetpoint) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "RORSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].RORSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //RORPressure
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "RateOfRise" + "', '" +
            //         Machine.Test[port].RORResult + "', '" +
            //         "RORPressure" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].RORPressure) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "RORSetpoint" + "', '" +
            //         string.Format("{0:0.000}", Machine.Test[port].RORSetpoint) + "', '" +
            //         "Torr" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].ChargeResult != "Not Run")
            //    {
            //        //ChargeTime
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "Charge" + "', '" +
            //         Machine.Test[port].ChargeResult + "', '" +
            //         "ChargeTime" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "ChargeDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].ChargeTimeoutDelay) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //RefSupplyPressDuringCharge
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "Charge" + "', '" +
            //         Machine.Test[port].ChargeResult + "', '" +
            //         "RefPressDuringCharge" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].RefSupplyPressDuringCharge) + "', '" +
            //         "NoMinSetpoint" + "', '" +
            //         "0.0" + "', '" +
            //         "NoMaxSetpoint" + "', '" +
            //         "0.0" + "', '" +
            //         "psig" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //ChargeTargetWeight
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "Charge" + "', '" +
            //         Machine.Test[port].ChargeResult + "', '" +
            //         "ChargeTargetWeight" + "', '" +
            //         string.Format("{0:0.0}", model.TotalCharge.ProcessValue) + "', '" +
            //         "NoMinSetpoint" + "', '" +
            //         "0.0" + "', '" +
            //         "NoMaxSetpoint" + "', '" +
            //         "0.0" + "', '" +
            //         "oz" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }

            //        //ActualTargetWeight
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "Charge" + "', '" +
            //         Machine.Test[port].ChargeResult + "', '" +
            //         "ActualChargeWeight" + "', '" +
            //         string.Format("{0:0.00}", Machine.Test[port].ActualChargeWeight) + "', '" +
            //         "MinChargeWeight" + "', '" +
            //          string.Format("{0:0.00}", Machine.Test[port].ChargeTargetWeightMinSetpoint) + "', '" +
            //         "MaxChargeWeight" + "', '" +
            //         string.Format("{0:0.00}", Machine.Test[port].ChargeTargetWeightMaxSetpoint) + "', '" +
            //         "oz" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    if (Machine.Test[port].RecoveryResult != "Not Run")
            //    {
            //        //RecoveryTime
            //        if (strConnectLennox != "")
            //        {
            //            try
            //            {
            //                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //                SqlCommand cmd = new SqlCommand();
            //                Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //                // Set the test result and write the records
            //                String strSqlCmd =
            //        "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                    //"insert into dbo.TestResult "+
            //        "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //        "values('" + Machine.Test[port].UutRecordID + "', '" +
            //         DateTime.Now.ToString() + "', '" +
            //         "Charge" + "', '" +
            //         Machine.Test[port].RecoveryResult + "', '" +
            //         "RecoveryTime" + "', '" +
            //         string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "', '" +
            //         "NoMinSetPoint" + "', '" +
            //         "0.0" + "', '" +
            //         "ChargeDelaySetpoint" + "', '" +
            //         string.Format("{0:0.0}", model.Tool_Recovery_Timeout.ProcessValue) + "', '" +
            //         "seconds" + "', '" +
            //          string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "')";
            //                Console.WriteLine(strSqlCmd);

            //                cmd.CommandText = strSqlCmd;
            //                cmd.CommandType = CommandType.Text;
            //                cmd.Connection = sqlConnection2;

            //                sqlConnection2.Open();

            //                cmd.ExecuteNonQuery();


            //                sqlConnection2.Close();
            //            }
            //            catch (Exception Ex)
            //            {
            //                Console.WriteLine(Ex.Message);
            //                VtiEvent.Log.WriteError(Ex.Message);
            //            }
            //        }
            //    }

            //    //MachineCycleTime
            //    Machine.Test[port].MachineCycleTime = IO.Signals.BlueElapsedTime.Value;
            //    if (strConnectLennox != "")
            //    {
            //        try
            //        {
            //            SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //            SqlCommand cmd = new SqlCommand();
            //            Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //            // Set the test result and write the records
            //            String strSqlCmd =
            //    "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                //"insert into dbo.TestResult "+
            //    "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //    "values('" + Machine.Test[port].UutRecordID + "', '" +
            //     DateTime.Now.ToString() + "', '" +
            //     "MachineCycleTime" + "', '" +
            //     Machine.Test[port].TestResultToSendToRemoteSQLDatabase + "', '" +
            //     "MachineCycleTime" + "', '" +
            //     string.Format("{0:0.0}", Machine.Test[port].MachineCycleTime) + "', '" +
            //     "NoMinSetPoint" + "', '" +
            //     "0.0" + "', '" +
            //     "NoMaxSetpoint" + "', '" +
            //     "0.0" + "', '" +
            //     "seconds" + "', '" +
            //      string.Format("{0:0.0}", Machine.Test[port].MachineCycleTime) + "')";
            //            Console.WriteLine(strSqlCmd);

            //            cmd.CommandText = strSqlCmd;
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = sqlConnection2;

            //            sqlConnection2.Open();

            //            cmd.ExecuteNonQuery();


            //            sqlConnection2.Close();
            //        }
            //        catch (Exception Ex)
            //        {
            //            Console.WriteLine(Ex.Message);
            //            VtiEvent.Log.WriteError(Ex.Message);
            //        }
            //    }


            //    //IdleTime
            //    if (strConnectLennox != "")
            //    {
            //        try
            //        {
            //            SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //            SqlCommand cmd = new SqlCommand();
            //            Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
            //            // Set the test result and write the records
            //            String strSqlCmd =
            //    "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //                //"insert into dbo.TestResult "+
            //    "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
            //    "values('" + Machine.Test[port].UutRecordID + "', '" +
            //     DateTime.Now.ToString() + "', '" +
            //     "MachineIdleTime" + "', '" +
            //     Machine.Test[port].TestResultToSendToRemoteSQLDatabase + "', '" +
            //     "MachineIdleTime" + "', '" +
            //     string.Format("{0:0.0}", Machine.Test[port].IdleTime) + "', '" +
            //     "NoMinSetPoint" + "', '" +
            //     "0.0" + "', '" +
            //     "NoMaxSetpoint" + "', '" +
            //     "0.0" + "', '" +
            //     "seconds" + "', '" +
            //      string.Format("{0:0.0}", Machine.Test[port].IdleTime) + "')";
            //            Console.WriteLine(strSqlCmd);

            //            cmd.CommandText = strSqlCmd;
            //            cmd.CommandType = CommandType.Text;
            //            cmd.Connection = sqlConnection2;

            //            sqlConnection2.Open();

            //            cmd.ExecuteNonQuery();


            //            sqlConnection2.Close();
            //        }
            //        catch (Exception Ex)
            //        {
            //            Console.WriteLine(Ex.Message);
            //            VtiEvent.Log.WriteError(Ex.Message);
            //        }
            //    }              
                

            //}       

            // Save test result for prompt
            Machine.Test[port].Result = TestResult;
        }

        protected virtual void ScanSerialNumber_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Config.TestMode != TestModes.Autotest)
                this.Stop();

            test = Machine.Test[port] = new TestInfo();
            Machine.Prompt[port].RemoveText(String.Format(Localization.SelectPort, PortName));

            if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Scan_Model_and_Serial_Seperately)
                step.Prompt = Localization.ScanSerialNumber_Prompt;
            else
                step.Prompt = Localization.ScanSerialNumber_Prompt2;
        }

        void ScanSerialNumber_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        { // Port.Blue not defined in this contect and [0] does not refer to same variable
            if (Machine.Test[Port.Blue].SerialNumber != "" && !string.IsNullOrEmpty(Machine.Test[Port.Blue].SerialNumber))
            {
                this.CycleStart();
                ScanSerialNumber.Stop();
            }
            if (Config.TestMode != TestModes.Autotest)
                this.Stop();
        }

        protected virtual void ScanSerialNumber2_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            string prompt;

            if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Scan_Model_and_Serial_Seperately)
                prompt = Localization.ScanSerialNumber2_Prompt;
            else
                prompt = Localization.ScanSerialNumber2_Prompt2;

            if (Machine.Test[port] != null && !String.IsNullOrEmpty(Machine.Test[port].Result))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(Localization.LastTestResult);
                sb.AppendLine(Machine.Test[Port.Blue].Result);
                sb.AppendLine();
                sb.Append(prompt);
                step.Prompt = sb.ToString();
            }
            else
                step.Prompt = prompt;

            test = Machine.Test[port] = new TestInfo();
        }

        void ScanSerialNumber2_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected virtual void Reset_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            if (Machine.Test[port].SerialNumber != "")
            {
                if (Machine.Test[port].Result == "")
                {
                    Machine.Test[port].Result = "RESET";
                    Machine.TestHistory[port].AddEntry("RESET", Color.Black, Color.Yellow);
                }
            }

            if (!IO.DIn.MCRPower24VoltSense.Value)
            {
                SetControlPropertyValue(Machine.Prompt[port], "BackColor", Color.White); //This is a thread safe method
                SetControlPropertyValue(Machine.Prompt[port], "DefaultColor", Color.Black); //This is a thread safe method
                step.Color = Color.Red;
                step.ColorDetails = Color.Red;
            }
            else if (Machine.Test[0].Result == "")
            {
                SetControlPropertyValue(Machine.Prompt[port], "BackColor", Color.White); //This is a thread safe method
                SetControlPropertyValue(Machine.Prompt[port], "DefaultColor", Color.Black); //This is a thread safe method
                step.Color = Color.Black;
                step.ColorDetails = Color.Black;
            }
            else if (Machine.Test[0].Result.ToUpper().Contains("PASS")||Machine.Test[0].Result.ToUpper().Contains("ACEPTABLE"))
            {
                SetControlPropertyValue(Machine.Prompt[port], "BackColor", Color.LightGreen); //This is a thread safe method
                SetControlPropertyValue(Machine.Prompt[port], "DefaultColor", Color.Black); //This is a thread safe method
                step.Color = Color.Black;
                step.ColorDetails = Color.Black;
            }
            else
            {
                SetControlPropertyValue(Machine.Prompt[port], "BackColor", Color.LightPink); //This is a thread safe method
                SetControlPropertyValue(Machine.Prompt[port], "DefaultColor", Color.Black); //This is a thread safe method
                step.Color = Color.Yellow;
                step.ColorDetails = Color.Yellow;
            }


            if (Config.Control.HorizontalSplitterLocation.ProcessValue > 0.5)
            {
                Machine.Cycle[0].bSetHorizotalSplitter = true;
                //Machine.OpFormSingle.splitContainer1.SplitterDistance = (int)Config.Control.HorizontalSplitterLocation.ProcessValue;
            }
            if (Config.Control.VerticalSplitterLocation.ProcessValue > 0.5)
            {
                Machine.Cycle[0].bSetVerticalSplitter = true;
                //Machine.OpFormSingle.splitContainer2.SplitterDistance = (int)Config.Control.VerticalSplitterLocation.ProcessValue;
            }


            Machine.Cycle[0].bHideMessageBox = true;

            IO.Signals.BlueSetPoint.Value = 0.0;

            if (Machine.OpFormSingle.DataPlot.Settings.AutoRun1)
            {
                Machine.Cycle[port].bStopDataPlot = true;
            }

            switch (Config.Control.Language.ProcessValue)
            {
                case Languages.English:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.EnglishCulture;
                    break;

                case Languages.Spanish:
                    System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.SpanishCulture;
                    break;
            }

           //i (!IO.SerialIn.ZebraPrinter.IsAvailable) IO.SerialIn.ZebraPrinter.Start();
            //UpdateTime.Stop();
            Disabled.Stop();
            //if (port == Port.Blue ?
            ////    Config.Mode.BluePortEnabled :
            // if(   Properties.Settings.Default.DualPortSystem &&
            //    Config.Mode.WhitePortEnabled)
            //{

            
            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName, Localization.ResetInitiated));
            if (Machine.Test[port].SerialNumber != "")
            {
                if (!Machine.Test[port].PassedFlag)
                {
                    dout.PassGreenLight.Disable();
                }

                if ((!Machine.Test[port].FailedFlag) && (!Machine.Test[port].NoTestFlag))
                {
                    dout.FailRedLight.Disable();
                    if (Machine.Test[port].PassedFlag)
                    {
                        dout.PassGreenLight.Enable();
                    }
                }
            }

            //save database data here
            if (Machine.Test[port].SerialNumber != "")
            {
                //ForwardCycleResult(Machine.Test[port].Result);
                SaveToDataBases.Start();
            }

            // Clear cycle flags
            if (port == Port.Blue)
            {
                MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                if (Properties.Settings.Default.DualPortSystem)
                {
                    if (Machine.Cycle[1].Idle.State == CycleStepState.InProcess)
                    {
                        MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                    }
                }
            }
            else
            {
                MyStaticVariables.WaitForAcknowledgeFlagWhite = false;
                if (Machine.Cycle[0].Idle.State == CycleStepState.InProcess)
                {
                    MyStaticVariables.WaitForAcknowledgeFlagBlue = false;
                }

            }

            //if (Machine.Cycle[1].ToolDrainDelay.State != CycleStepState.InProcess || Machine.Cycle[0].ToolDrainDelay.State != CycleStepState.InProcess
            //    || Machine.Cycle[1].HiSideCharge.State != CycleStepState.InProcess || Machine.Cycle[0].HiSideCharge.State != CycleStepState.InProcess
            //    || Machine.Cycle[1].LowSideCharge.State != CycleStepState.InProcess || Machine.Cycle[0].LowSideCharge.State != CycleStepState.InProcess
            //    || Machine.Cycle[1].WaitForOtherROR.State != CycleStepState.InProcess || Machine.Cycle[0].WaitForOtherROR.State != CycleStepState.InProcess)
           
            //if(!Machine.Test[port].BlueCharge || !Machine.Test[port].WhiteCharge)

            //{

            // RMN 3/11/2014  
             //   Config.CurrentModel[port].LoadFrom(Config.DefaultModel);
             //   Config.CurrentModel[1].LoadFrom(Config.DefaultModel);

           // }
            MyStaticVariables.SerialNumberByMessBoxFlag = false;
            MyStaticVariables.MessageBoxInvalidText = "";

            Config.Mode.ScaleEnabled.ProcessValue = false;
            MyStaticVariables.PassedFlag = false;

            Machine.Test[port].MTL_NBR = "";

            Machine.Test[port].FailToolRecoveryFlag = false;

            Machine.Test[port].UsingRoughPumpForToolCheckFlag = false;
            Machine.Test[port].ForceLowSideChargeFlag = false;
            Machine.Test[port].ForceHiSideChargeFlag = false;
            Machine.Test[port].RecoverHiSideFlag = false;
            Machine.Test[port].RecoverLowSideFlag = false;
			Machine.Test[port].InitialRecoveryPassed = false;
			Machine.Test[port].ForceChargeFlag = false;

            Machine.Test[port].PassedChargeFlag = false;

            Machine.Test[port].RunningATestFlag = false;

            Machine.Test[port].PassedFlag = false;
            Machine.Test[port].FailedFlag = false;
            Machine.Test[port].NoTestFlag = false;

            Machine.Test[port].AbortTest = false;

            Machine.Test[port].RecoverUnitFlag = false;

            Machine.Test[port].RateOfRisePassedFlag = false;

            Machine.Test[port].TestHistory = "";
            Machine.Test[port].TestResult = "";
            Machine.Test[port].SerialNumber = "";
            Machine.Test[0].ModelNumber = "";
            Machine.Test[port].TestResultToSendToRemoteSQLDatabase="";

            Machine.Test[port].DataPlotStartTime=0.0;
            Machine.Test[port].FinalEvacTimeForPlot = 0.0;
            Machine.Test[port].RORDelayTimeForPlot=0.0;

            Machine.Test[port].ChargeCalculatedWeight = 0.0;
            Machine.Test[port].PartChargeByCounterStart = 0;

            Machine.Test[port].UnitStartWeight = 0.0;
            Machine.Test[port].UnitEndWeight = 0.0;
            Machine.Test[port].UnitNetWeight = 0.0;

            Machine.Test[port].SavedLastFlow = false;
            Machine.Test[port].HiSideOnlyCharge = false;
            Machine.Test[port].CounterStartValueHiSide = 0;
            Machine.Test[port].CounterStartValueLowSide = 0;
            Machine.Test[port].CounterStopValueHiSide = 0;
            Machine.Test[port].CounterStopValueLowSide = 0;

            Machine.Test[port].PreChargeUnitPressCheckResult="Not Run";
            Machine.Test[port].PreChargeUnitPressCheckSetPoint=0.0;
            Machine.Test[port].PreChargeUnitPressCheckPressure = 0.0;
            Machine.Test[port].PreChargeUnitPressCheckTime = 0.0;

            Machine.Test[port].ToolDrainResult = "Not Run";
            Machine.Test[port].ToolDrainPressure = 0.0;
            Machine.Test[port].ToolDrainTime = 0.0;

            Machine.Test[port].InitialEvacResult="Not Run";
            Machine.Test[port].InitialEvacTime = 0.0;
            Machine.Test[port].InitialEvacSetpoint = 0.0;
            Machine.Test[port].InitialEvacPressure=0.0;

            Machine.Test[port].FinalEvacResult = "Not Run";
            Machine.Test[port].FinalEvacTime = 0.0;
            Machine.Test[port].FinalEvacSetpoint = 0.0;
            Machine.Test[port].FinalEvacPressure = 0.0;

            Machine.Test[port].EvacTimeBeforeLastRORResult = "Not Run";
            Machine.Test[port].RepeatEvacTime = 0.0;
            Machine.Test[port].EvacTimeBeforeLastROR = 0.0;
            Machine.Test[port].EvacPressBeforeLastROR = 0.0;

            Machine.Test[port].BasePressBeforeLastRORResult = "Not Run";
            Machine.Test[port].BaseTimeBeforeLastROR = 0.0;
            Machine.Test[port].BasePressBeforeLastROR = 0.0;

            Machine.Test[port].RORResult = "Not Run";

            Machine.Test[port].ChargeResult = "Not Run";

            Machine.Test[port].LowSideChargePressureCheckPressureStart=0.0;
            Machine.Test[port].LowSideChargePressureCheckPressureValue=0.0;

            Machine.Test[port].ChargeTime = 0.0;
            Machine.Test[port].ChargeTimeoutDelay = 0.0;
            Machine.Test[port].HighSideChargeTime = 0.0;
            Machine.Test[port].ChargeTime = 0.0;
            Machine.Test[port].ChargeTargetWeight = 0.0;
            MyStaticVariables.ActualCharge = 0.0;
            Machine.Test[port].ActualChargeWeight = 0.0;
            Machine.Test[port].ChargeTargetWeightMaxSetpoint = 0.0;
            Machine.Test[port].ChargeTargetWeightMinSetpoint = 0.0;
            Machine.Test[port].TargetCounts = 0;
            Machine.Test[port].ActualCounts = 0;

            Machine.Test[port].RecoveryResult = "Not Run";
            Machine.Test[port].RecoveryTime = 0.0;

            Machine.Test[port].MachineCycleTime = 0.0;
            Machine.Test[port].IdleTime = 0.0;
            Machine.Test[port].RefSupplyPressDuringCharge = 0.0;
            MyStaticVariables.BlueLowSideChargeWeight = 0.0;
            MyStaticVariables.BlueLowSideEndWeight = 0.0;
            MyStaticVariables.BlueLowSideStartWeight = 0.0;
            MyStaticVariables.LeakRate=0;

            MyStaticVariables.ReadyForFinalWeightFlag = false;

            MyStaticVariables.RemoveProcessFittingPrompt = false;


            try
            {
                // Stop all cycle steps
                foreach (CycleStep step2 in this.CycleSteps)
                {
                    if (!step2.Equals(this.Idle))
                        step2.Reset();
                }
            }
            catch
            {
            }

            //if ((Config.CurrentModel[1].Name != Config.CurrentModel[0].Name)&&(port==Port.White))
            //{
            //    if (Config.CurrentModel[0].Name.ToUpper() == "DEFAULT")
            //    {
            //        Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
            //    }
            //    else
            //    {
            //        Config.CurrentModel[1].Load(Config.CurrentModel[0].Name);
            //    }
            //}

            // Reset Prompt
            Machine.Prompt[port].Clear();
            Machine.Prompt[port].AppendText(Localization.CurrentTestMode + ": " + Config.TestMode.ToString() + Environment.NewLine);
            if (Config.Mode.ModelScanMode.ProcessValue == ModelScanOptions.Select_Model_Number_via_Touch_Screen)
                Machine.Prompt[port].AppendText(string.Format(Localization.ModelNumber, Config.CurrentModel[port].Name) + Environment.NewLine);
            
            

            // Restart the threads for the Serial I/O devices
            //if (!IO.SerialIn.LN2TrapTemperature.IsAvailable) IO.SerialIn.LN2TrapTemperature.Start();
            //if (!IO.SerialIn.TemperatureControl.IsAvailable) IO.SerialIn.TemperatureControl.Start();
            //if (!IO.SerialIn.OverTempControl.IsAvailable) IO.SerialIn.OverTempControl.Start();

            //CloseAllValves();
            dout.HiSideCharge.Disable();
            dout.HiSideEvac.Disable();
            dout.HiSideRecovery.Disable();
            dout.ReversingValve.Disable();

            dout.LoSideCharge.Disable();
            dout.LoSideEvac.Disable();
            dout.LoSideRecovery.Disable();
            if (Config.Mode.StemPushersRetractedOnIdle.ProcessValue)
            {
                dout.LoSideToolStem.Disable();
                dout.HiSideToolStem.Disable();
            }
            else
            {
                dout.LoSideToolStem.Enable();
                dout.HiSideToolStem.Enable();
            }

            Machine.Cycle[0].bDisableHiSideCharge = true;
            Machine.Cycle[0].bDisableLowSideCharge = true;
            if (Properties.Settings.Default.DualPortSystem)
            {
                Machine.Cycle[1].bDisableHiSideCharge = true;
                Machine.Cycle[1].bDisableLowSideCharge = true;
            }


            //dout.RecoveryPumpEnable.Disable();
            //dout.BoosterDisable.Disable();

            //IO.DOut.CrossOverValve.Disable();

            //IO.DOut.ConveyorEnable.Disable();

            dout.AlarmOutput.Disable();
            //dout.PassGreenLight.Disable();
            //dout.FailRedLight.Disable();

            Machine.Test[port].LoadLowSideCounter = 10000;
            Machine.Cycle[port].bLoadLowSideCounter = true;
            Machine.Cycle[port].bDisableLowSideCharge = true;
            Machine.Test[port].LoadHiSideCounter = 10000;
            Machine.Cycle[port].bLoadHiSideCounter = true;
            Machine.Cycle[port].bDisableHiSideCharge = true;

            Machine.Test[port].CounterStopValueHiSide = 500;
            Machine.Cycle[port].bLoadHiSideLimit = true;

            Machine.Test[port].CounterStopValueLowSide = 500;
            Machine.Cycle[port].bLoadLowSideLimit = true;

            if (!IO.DIn.MCRPower24VoltSense.Value)
            {
                NotEnergized.Start();
            }
            else
            {
                if ((IO.Signals.BlueHiSideToolPressure.Value > Config.Pressure.RecoverOnResetSetpoint.ProcessValue && IO.Signals.BlueHiSideToolPressure.Value > model.Recovery_Pressure_SetPoint.ProcessValue) ||
                    (IO.Signals.BlueLoSideToolPressure > Config.Pressure.RecoverOnResetSetpoint.ProcessValue && IO.Signals.BlueLoSideToolPressure.Value > model.Recovery_Pressure_SetPoint.ProcessValue))
                {
                    if (ChargeHoseChargeToolRecovery.State != CycleStepState.InProcess && HoseRecoveryDelay.State != CycleStepState.InProcess) HoseRecoveryDelay.Start();
                }
                else
                {
                    dout.UnitEvac.Disable();
                    dout.RateOfRiseValve.Enable();
                    ResetComplete.Start();
                }
            }
            //}
            //else
            //{
            //    Reset.Stop();
            //}
            //this.CycleStop();

        }

        protected virtual void ResetComplete_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            try
            {
                foreach (CycleStep step2 in this.CycleSteps)
                {
                    step2.Reset();
                }
            }
            catch
            {
            }

            // Reset Sequences
            foreach (var sequence in Machine.Sequences[port])
                sequence.BackColor = System.Drawing.SystemColors.Control;
            Machine.Sequences[port][0].BackColor = Properties.Settings.Default.SequenceGoodColor;

            VtiEvent.Log.WriteInfo(String.Format("({0}) {1}", PortName,Localization.ResetComplete));

            //Machine.Cycle[0].bUpdateLanguage = true;

            if (Config.Mode.AutoDemoCycleEnable)
            {
                AutoDemoCycleStartUp.Start();
            }
            else
            {
                Idle.Start();
                if (WaitForSerialNumber.State != CycleStepState.InProcess) WaitForSerialNumber.Start();
            }
            

        }

        protected virtual void Idle_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables._RoughPumpStartTime = DateTime.Now;
            if (din.MCRPower24VoltSense.Value)
            {
   
                if ((port == Port.Blue) && (!Config.Mode.BlueCircuit2PortEnabled.ProcessValue))
                {
                    step.Prompt = Localization.Disabled_Prompt;
                }
                else
                {
                    if ((port == Port.White) && (!Config.Mode.WhiteCircuit1PortEnabled.ProcessValue))
                    {
                        step.Prompt = Localization.Disabled_Prompt;
                    }
                    else
                    {
                        if (Config.TestMode == TestModes.Manual)
                        {
                            step.Prompt = Localization.ManualCommandMANUALMODE;
                        }
                        else
                        {
                            MyStaticVariables.ReadyToTest = true;
                            _RoughPumpIdleStart = DateTime.Now;

                            // good place to test prompt and display issue

                            if (!String.IsNullOrEmpty(Machine.Test[port].Result))
                            {
                                StringBuilder sb = new StringBuilder();
                                if (Config.Mode.ScaleEnabled.ProcessValue)
                                {
                                    sb.Append(Localization.IdleScaleEnabled_Prompt);
                                    if (Config.TestMode == TestModes.Autotest)
                                    {
                                        if (MyStaticVariables.ReadyToTest)
                                        {
                                            //IO.DOut.ConveyorEnable.Enable();
                                        }
                                    }
                                }
                                else
                                {
                                   
                                    if (Config.TestMode == TestModes.Autotest)
                                    {
                                        if (MyStaticVariables.ReadyToTest)
                                        {
                                            //IO.DOut.ConveyorEnable.Enable();
                                        }
                                    }
                                }
                                sb.AppendLine(" ");

                                //sb.Append(Localization.LastTestResult);
                                ////sb.AppendLine(string.Format(Machine.Test[0].Result, Machine.Test[0].LeakRate));
                                //sb.AppendLine(Machine.Test[port].Result);
                                ////sb.AppendLine();
                                ////sb.Append(string.Format(Localization.Idle_Prompt, PortName));
                                step.Prompt = sb.ToString();
                            }
                            else
                            {
                                if (Config.Mode.ScaleEnabled.ProcessValue)
                                {
                                    step.Prompt = Localization.IdleScaleEnabled_Prompt;
                                    if (Config.TestMode == TestModes.Autotest)
                                    {
                                        if (MyStaticVariables.ReadyToTest)
                                        {
                                            //IO.DOut.ConveyorEnable.Enable();
                                        }
                                    }
                                }
                                else
                                {
                                    
                                    if (Config.TestMode == TestModes.Autotest)
                                    {
                                        if (MyStaticVariables.ReadyToTest)
                                        {
                                            //IO.DOut.ConveyorEnable.Enable();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MyStaticVariables.ReadyToTest = false;
                step.Prompt = Localization.MCROff;
            }
            //else
            //step.Prompt = String.Format(Localization.Idle_Prompt, PortName);
        }

        DateTime _RoughPumpIdleStart;
        DateTime _RoughPumpOffStart;
        protected virtual void Idle_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[port].IdleTime = step.ElapsedTime.TotalSeconds;

            if ((IO.DIn.MCRPower24VoltSense.Value) && ((IO.DOut.EvacPumpEnable.Value)))
            {
            }
            else
            {
                MyStaticVariables._RoughPumpStartTime = DateTime.Now;
            }
            TimeSpan _RoughPumpOffTime = DateTime.Now - MyStaticVariables._RoughPumpStartTime;
            if (_RoughPumpOffTime.TotalSeconds > 60)
            {
                //if ((!IO.DIn.HighSideEvacPumpOilLevel.Value)&&(!IO.DOut.EvacPumpEnable.Value))
                if ((!IO.DOut.EvacPumpEnable.Value))
                {
                    if (HighSideLowOilWarning.State != CycleStepState.InProcess)
                    {
                        HighSideLowOilWarning.Start();
                    }
                }
                //if ((!IO.DIn.LowSideEvacPumpOilLevel.Value) && (!IO.DOut.LowSideEvacPump.Value))
                //{
                //    if (LowSideLowOilWarning.State != CycleStepState.InProcess)
                //    {
                //        LowSideLowOilWarning.Start();
                //    }
                //}

            }
            if ((_RoughPumpOffTime.TotalSeconds > Config.Time.RoughPumpIdlePowerOff.ProcessValue) && (Config.Time.RoughPumpIdlePowerOff.ProcessValue > 0.1)&&(MyStaticVariables.ReadyToTest))//if not ready to test other side is running, do not switch off pump
            {
                if (Config.TestMode == TestModes.Autotest)
                {
                    //IO.DOut.VacuumPumpEnable.Disable(); // Rough pump power off idle timer
                    IO.DOut.EvacPumpEnable.Disable();
                    //IO.DOut.LowSideEvacPump.Disable();
                }
            }
            //if (ScanSerialNumber.State != CycleStepState.InProcess && Config.TestMode == TestModes.Autotest)
            //    ScanSerialNumber.Start();


            //if ((Config.CurrentModel[1].Name != Config.CurrentModel[0].Name)&&(port==Port.White))
            ////{
            ////    if (Config.CurrentModel[0].Name.ToUpper() == "DEFAULT")
            ////    {
            ////        Config.CurrentModel[1].Load("DEFAULT");
            ////    }
            ////    else
            ////    {
            ////        Config.CurrentModel[1].Load(Config.CurrentModel[0].Name);
            ////    }
            //    Reset.Start();
            ////    //return;
            ////}
            //else
            {
                if (Config.TestMode != TestModes.Autotest)
                {
                    Idle.Stop();
                }
                else
                {
                    try
                    {
                        // Stop the "Idle" step if any other step starts
                        foreach (CycleStep step2 in this.EnabledSteps)
                            if((step != step2)&&(step2 != LowOilWarning) && (step2 != ScanSerialNumber) && (step2 != ScanModelNumber) && (step2 != SaveToDataBases)&&(step2 != ThreeBeeps))
                            {
                                Idle.Stop();
                            }
                    }
                    catch
                    {
                    }
                }
                if (step.ElapsedTime.TotalSeconds > 5.0)
                {
                    if (port == Port.Blue)
                    {
                        if (IO.Signals.BlueSupplyPressure.Value < Config.Pressure.Blue_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                        {
                            if (Machine.Cycle[0].LowRefPressureWarning.State != CycleStepState.InProcess)
                            {
                                Machine.Cycle[0].LowRefPressureWarning.Start();
                            }
                        }
                    }
                    if (port == Port.White)
                    {
                        if (IO.Signals.WhiteSupplyPressure.Value < Config.Pressure.White_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                        {
                            if (Machine.Cycle[1].LowRefPressureWarning.State != CycleStepState.InProcess)
                            {
                                Machine.Cycle[1].LowRefPressureWarning.Start();
                            }
                        }
                    }
                    //if (Config.Mode.RecoveryTankFloatSwitchEnabled.ProcessValue)
                    //{
                    //    if (!IO.DIn.BlueRecoveryTankFloatSwitch.Value)
                    //    {
                    //        if (Machine.Cycle[0].RecoveryTankFullWarning.State != CycleStepState.InProcess)
                    //        {
                    //            Machine.Cycle[0].RecoveryTankFullWarning.Start();
                    //        }
                    //    }
                    //}
                    //if(Config.Mode.WhiteRecoveryTankFloatSwitchEnabled.ProcessValue)
                    //{
                    //    if (!IO.DIn.WhiteRecoveryTankFloatSwitch.Value)
                    //    {
                    //        if (Machine.Cycle[1].RecoveryTankFullWarning.State != CycleStepState.InProcess)
                    //        {
                    //            Machine.Cycle[1].RecoveryTankFullWarning.Start();
                    //        }
                    //    }
                    //}
                }
            }
            if (!IO.DIn.MCRPower24VoltSense.Value)
            {
                NotEnergized.Start();
                MyStaticVariables.ReadyToTest = false;
            }   
        }
        protected void PrintPassLabel()
        {
            string strCoilID = Machine.Test[port].SerialNumber;
            string strDateTime = DateTime.Now.ToString();
            string strStation = Config.Control.System_ID.ProcessValue.ToString();
            string strResult = "PASS";
            string strOpID = Config.OpID;
            PrintLabel(strCoilID, strDateTime, strStation, strResult, strOpID);
        }

        protected void PrintLabel(string strCoilID, string strDateTime, string strStation, string strResult, string strOpID)
        {
            //string filename = @"ZM400Label.txt";
            //try
            //{
            //    IntPtr handleForTheOpenPrinter = new IntPtr();
            //    DOCINFO documentInformation = new DOCINFO();
            //    int printerBytesWritten = 0;
            //    documentInformation.printerDocumentName = "ZebraPrinterJob";
            //    documentInformation.printerDocumentDataType = "RAW";
            //    long retVal;
            //    retVal = RawPrinter.OpenPrinter(Config.Control.ZebraPrinter.ProcessValue, ref handleForTheOpenPrinter, 0);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    retVal = RawPrinter.StartDocPrinter(handleForTheOpenPrinter, 1, ref documentInformation);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    retVal = RawPrinter.StartPagePrinter(handleForTheOpenPrinter);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    string strText1 = "";
            //    strText1 += @"^XA" + Environment.NewLine; // start of print block
            //    int textWidth = 35, textHeight = 70, lineSpace = 60;
            //    float paperWidth = float.Parse(Config.Control.ZebraPrinterPaperWidth.ProcessValue);
            //    if (paperWidth > 2 && paperWidth <= 4)
            //    {
            //        textWidth = Convert.ToInt32(float.Parse(textWidth.ToString()) * paperWidth / 2f);
            //        textHeight = Convert.ToInt32(float.Parse(textHeight.ToString()) * paperWidth / 2f);
            //        lineSpace = Convert.ToInt32(float.Parse(lineSpace.ToString()) * paperWidth / 2f);
            //    }
            //    string strTextWidth = String.Format("{0}", textWidth);
            //    string strTextHeight = String.Format("{0}", textHeight);
            //    string strLineSpace;
            //    strText1 += @"^CF0," + strTextHeight + "," + strTextWidth + Environment.NewLine; // set alphanumeric character to 70 pixels high and 35 pixels wide
            //    strLineSpace = String.Format("{0}", 30);
            //    strText1 += @"^FO50," + strLineSpace + Environment.NewLine; // set position to 50, 30
            //    strText1 += @"^FD" + strCoilID + @"^FS" + Environment.NewLine;

            //    strLineSpace = String.Format("{0}", 30 + lineSpace);
            //    strText1 += @"^FO50," + strLineSpace + Environment.NewLine; // set position to 50, 90
            //    strText1 += @"^FD" + strDateTime + @"^FS" + Environment.NewLine;

            //    strLineSpace = String.Format("{0}", 30 + 2 * lineSpace);
            //    strText1 += @"^FO50," + strLineSpace + Environment.NewLine; // set position to 50, 150
            //    strText1 += @"^FD" + strStation + "^FS" + Environment.NewLine;

            //    strLineSpace = String.Format("{0}", 30 + 3 * lineSpace);
            //    strText1 += @"^FO50," + strLineSpace + Environment.NewLine; // set position to 50, 210
            //    strText1 += @"^FD" + strResult + "^FS" + Environment.NewLine;
            //    if (Config.Mode.IncludeOpIDOnLabel.ProcessValue)
            //    {
            //        strLineSpace = String.Format("{0}", 30 + 4 * lineSpace);
            //        strText1 += @"^FO50," + strLineSpace + Environment.NewLine; // set position to 50, 270
            //        strText1 += @"^FD" + strOpID + "^FS" + Environment.NewLine;
            //    }
            //    strText1 += @"^XZ" + Environment.NewLine; // end of print block
            //    retVal = RawPrinter.WritePrinter(handleForTheOpenPrinter, strText1, strText1.Length, ref printerBytesWritten);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    retVal = RawPrinter.EndPagePrinter(handleForTheOpenPrinter);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    retVal = RawPrinter.EndDocPrinter(handleForTheOpenPrinter);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //    retVal = RawPrinter.ClosePrinter(handleForTheOpenPrinter);
            //    if (retVal == 0)
            //        throw new NotSupportedException();
            //}
            //catch (Exception ex)
            //{
            //    VtiEvent.Log.WriteError(
            //      String.Format("Error in PrintLabel:(CoilID{0}) Time{1} Station(2) Result(3) OpID(4)",
            //        strCoilID, strDateTime, strStation, strResult, strOpID),
            //        VtiEventCatType.Test_Cycle);
            //}
        }



        private void SendPassLabelToZebraPrinter(string serialText)
        {
            try
            {
                using (StreamReader infile = new StreamReader(@"C:\Users\VTI\Desktop\Zebra Printer\BarCodeTemplate.txt"))
                {
                    string line;
                    while ((line = infile.ReadLine()) != null)
                    {
                        line = line.Replace("SerialText", serialText);
                        line = line.Replace("DateTimeText", DateTime.Now.ToString("hh:mm tt MM:dd:yyyy"));
                        Machine.ZM400.WriteLine(line);
                    }
                    infile.Close();
                }
            }
            catch (Exception e)
            {
                VtiEvent.Log.WriteError(
                    String.Format("An error occurred writing to ZM400 printer."),
                    VtiEventCatType.Database, e.ToString());
            }
        }


        public bool FinalChargeAmount(string strConnectVTIToLennox,string SerialNumber)
        {
            bool ReturnValue = false;
            MyStaticVariables.InitialPartialCharge = 0.0;
            Machine.Test[0].PartialChargeActualCharge = 0.0;
            //To get the partial charge amount
            //First:
            //Select ID
            //from dbo.UutRecords
            //where SerialNo = '{0}' and SystemID Contains 'PARTIAL'
            //Get ID
            string TempUutRecordID = "";
            if (strConnectVTIToLennox != "")
            {
                try
                {
                    SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
                    SqlCommand cmd = new SqlCommand();
                    Object returnValue;

                    string sCommandText = string.Format("Select ID from dbo.UutRecords where SerialNo = '{0}' and TestType = 'PARTIAL' order by DateTime desc", Machine.Test[port].SerialNumber);
                    cmd.CommandText = sCommandText;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection2;

                    sqlConnection2.Open();
                    returnValue = cmd.ExecuteScalar();
                    
                    string TempString = returnValue.ToString();

                    sqlConnection2.Close();


                    TempUutRecordID = TempString;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            if (TempUutRecordID != "")
            {
                //Second:
                //Select Value
                //From dbo.UutRecordDetails
                //Where UutRecordID = '{0}' and ValueName = 'ActualChargeWeight'
                try
                {
                    SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
                    SqlCommand cmd = new SqlCommand();
                    Object returnValue;

                    string sCommandText = string.Format("Select Value from dbo.UutRecordDetails where UutRecordID = {0} and ValueName = 'ActualChargeWeight' order by DateTime desc", TempUutRecordID);
                    cmd.CommandText = sCommandText;
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = sqlConnection2;

                    sqlConnection2.Open();
                    returnValue = cmd.ExecuteScalar();
                    sqlConnection2.Close();

                    string TempString = returnValue.ToString().Trim();

                    MyStaticVariables.InitialPartialCharge = Convert.ToDouble(TempString)*16.0;
                    Machine.Test[0].PartialChargeActualCharge = MyStaticVariables.InitialPartialCharge;
                    ReturnValue = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return ReturnValue;
        }

		public void InsertUUTRecordDetail(string strConnectVTIToLennox, string UutRecordID, string Test1, string Result1, double Value1, string ValueName1, double MinSetpoint, string MinSetpointName, double MaxSetpoint, string MaxSetpointName, string Units1, double ElapsedTime1)
		{
			//RecoveryTime
			if(strConnectVTIToLennox != "")
			{
				try
				{
					//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
					//SqlCommand cmd = new SqlCommand();
					Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
					// Set the test result and write the records
					String strSqlCmd =
						"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
						//"insert into dbo.TestResult "+
						"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
						"values('" + UutRecordID + "', '" +
						 DateTime.Now.ToString() + "', '" +
						 Test1 + "', '" +
						 Result1 + "', '" +
						 ValueName1 + "', '" +
						 $"{Value1}" + "', '" +
						 MinSetpointName + "', '" +
						 $"{MinSetpoint}" + "', '" +
						 MaxSetpoint + "', '" +
						 $"{MaxSetpoint}" + "', '" +
						 Units1 + "', '" +
						 $"{ElapsedTime1}" + "')";
					Console.WriteLine(strSqlCmd);

					fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
					if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
					{
						fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
					}

				}
				catch(Exception Ex)
				{
					Console.WriteLine(Ex.Message);
					VtiEvent.Log.WriteError(Ex.Message);
				}
			}
		}

		/*
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
		protected void ForwardCycleResult(string TestResult)
		{

			//Lennox Data Storage
			//Call Lennox Stored Procedure ProcessStatusUpdate if a coil
			// Assemble connection string from parameters defined by Jason Hass 3/8/2016
			// RemoteConnectionString build
			string strConnectLennox = "";
			if(Config.Control.RemoteConnectionString_LennoxKeywords != "")
				strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
			if(strConnectLennox.Length > 0)
				if(strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
			strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
			strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
			if(Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
			if(Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

			VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

			string strConnectVTIToLennox = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

			String CoilStatus = "";
			SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);

			if(Machine.Test[port].ForceChargeFlag || Machine.Test[port].RecoverUnitFlag)
			{

			}
			else
			{
				// Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
				// "test.TestResultToSendToRemoteSQLDatabase"
				// The appropriate status write pass value or status write fail value should be the string within the test. TestResultToSend ToRemoteSQLDatabase)
				if(strConnectLennox != "")
				{
					try
					{

						SqlCommand cmd = new SqlCommand("PROCESS_STATUS_UPDATE", sqlConnection1);

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add("SERIAL", SqlDbType.Char);
						cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
						cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
						cmd.Parameters["SERIAL"].Size = 18;

						cmd.Parameters.Add("PROCESS_STATUS", SqlDbType.Char);
						cmd.Parameters["PROCESS_STATUS"].Direction = ParameterDirection.Input;
						if(Machine.Test[port].TestResultToSendToRemoteSQLDatabase == "") // If reset occurs value may be null
							Machine.Test[port].TestResultToSendToRemoteSQLDatabase = Config.Control.StatusWriteFailValue.ProcessValue;
                        
                        if (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == Config.Control.StatusWriteFailValue.ProcessValue && (Machine.Test[0].Result.ToUpper().Contains("PASS") || Machine.Test[0].Result.ToUpper().Contains("ACEPTABLE")))
                        {
                            TestResult = "Failed - " + Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
                        }

						cmd.Parameters["PROCESS_STATUS"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
						cmd.Parameters["PROCESS_STATUS"].Size = 10;

						cmd.Parameters.Add("RetCode", SqlDbType.Char);
						cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
						//cmd.Parameters["RetCode"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
						cmd.Parameters["RetCode"].Size = 10;


						//SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
						//returnParameter.Direction = ParameterDirection.ReturnValue;

						cmd.Connection = sqlConnection1;

						sqlConnection1.Open();

						cmd.ExecuteNonQuery();

						// return value should match the process status sent if no error occured.
						CoilStatus = cmd.Parameters["RetCode"].Value.ToString();

						VtiEvent.Log.WriteInfo("Process Status Update called with CoilStatus = " + Machine.Test[port].TestResultToSendToRemoteSQLDatabase + " Return Value = " + CoilStatus);

					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.Message);
						// write the error message to the system log
						// write the error message to the system log
						VtiEvent.Log.WriteError(
						  string.Format("An error writing to remote database (Lennox Status Table)"),
						  VtiEventCatType.Database, ex.ToString());
					}
					finally
					{
						try
						{
							// always close the connection
							sqlConnection1.Close();
							//int intCoilStatus = Convert.ToInt32(CoilStatus);
						}
						catch(Exception ex)
						{
							Console.WriteLine(ex.Message);
							// write the error message to the system log
							VtiEvent.Log.WriteError(
							  string.Format("An error writing to remote database (Lennox Status Table)"),
							  VtiEventCatType.Database, ex.ToString());
						};

						//if (CoilStatus == Config.Control.StatusReadPassValue.ProcessValue)
						//{
						//    // all is good

						//}
						//else
						//{
						//    // An error occured updating the status of the unit,  Call a cycle step to notify the operator

						//}

					}
				}
			}

			string TempTestType = Config.Control.UutRecordTestType.ProcessValue;
			string TempMinPrechargeSetPoint = "";
			string TempMaxPrechargeSetPoint = "";


			TempMinPrechargeSetPoint = "0.0";
			TempMaxPrechargeSetPoint = model.Precharge_Unit_Check_Pressure_SetPoint.ProcessValue.ToString();


			//read test number
			Int32 TestNumber = 0;
			if(strConnectVTIToLennox != "")
			{
				try
				{
					SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
					SqlCommand cmd = new SqlCommand();
					Object returnValue;

					string sCommandText = string.Format("Select TestNumber from dbo.UutRecords where SerialNo = '{0}' and TestType = '{1}' order by DateTime desc", Machine.Test[port].SerialNumber, TempTestType);
					cmd.CommandText = sCommandText;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = sqlConnection2;

					sqlConnection2.Open();
					returnValue = cmd.ExecuteScalar();
					sqlConnection2.Close();

					string TempString = returnValue.ToString();

					TestNumber = Convert.ToInt32(TempString);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			TestNumber = TestNumber + 1;

            //Store to UutRecords, and read back the identity to be used for the RESULTS_ID and UutRecordID references to status and detail tables
            if (Machine.Test[port].ModelNumber == "")
			{
				Machine.Test[port].ModelNumber = "DEFAULT";
			}
			Machine.Test[port].TestResult = TestResult;
			if(strConnectVTIToLennox != "")
			{
				try
				{
					SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
					SqlCommand cmd = new SqlCommand();

					Config.Control.TestResultTableName.ProcessValue = "UutRecords";
					// Set the test result and write the records
					String strSqlCmd =
					"insert into UutRecords " +
					"(SerialNo, ModelNo, DateTime, SystemID, OpID, TestType, TestResult, TestPort,TestNumber) " +
					"values('" + Machine.Test[port].SerialNumber + "', '" +
					 Machine.Test[port].ModelNumber + "', '" +
					 DateTime.Now.ToString() + "', '" +
					 Config.Control.System_ID.ProcessValue + "', '" +
					 Machine.Test[port].OpID + "', '" +
					 TempTestType + "', '" +
					 Machine.Test[port].TestResult + "', '" +
					 "BLUE PORT" + "', '" +
					 string.Format("{0}", TestNumber) + "')";

					Console.WriteLine(strSqlCmd);

					//fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
					cmd.CommandText = strSqlCmd + " SELECT SCOPE_IDENTITY()";
					cmd.CommandType = CommandType.Text;
					cmd.Connection = sqlConnection2;
					sqlConnection2.Open();
					//cmd.ExecuteNonQuery();
					Machine.Test[port].UutRecordID = Convert.ToInt32(cmd.ExecuteScalar()).ToString();
					VtiEvent.Log.WriteInfo(
							string.Format("UUTRecordID = " + Machine.Test[port].UutRecordID),
									VtiEventCatType.Database);

					sqlConnection2.Close();

					if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
					{
						fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
					}
				}
				catch(Exception Ex)
				{
					VtiEvent.Log.WriteError(Ex.Message);
				}
			}

			//Get ID // This is dangerous and does not work 100% of the time.  Use Scope_IDentity(). TAS 6-10-2022
			//Machine.Test[port].UutRecordID = "";
			if(strConnectVTIToLennox != "")
			{
				try
				{
					SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
					SqlCommand cmd = new SqlCommand();
					Object returnValue;

					string sCommandText = string.Format("Select ID from dbo.UutRecords where SerialNo = '{0}' order by DateTime desc", Machine.Test[port].SerialNumber);
					cmd.CommandText = sCommandText;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = sqlConnection2;

					sqlConnection2.Open();
					returnValue = cmd.ExecuteScalar();
					sqlConnection2.Close();

					string TempString = returnValue.ToString();
					VtiEvent.Log.WriteInfo(
						string.Format("UUTRecordID returned from query = " + TempString),
								VtiEventCatType.Database);

					if(TempString != Machine.Test[port].UutRecordID)
						VtiEvent.Log.WriteInfo(
						  string.Format("An error occured the UUTRecordID is missing or does not match the identity from the UUTRecord's table entry, this may cause issues at downstream processes."),
						  VtiEventCatType.Database);
					//Machine.Test[port].UutRecordID = TempString;
				}
				catch(Exception ex)
				{
					VtiEvent.Log.WriteInfo(
					  string.Format("An error occured the UUTRecordID is missing or does not match the identity of the UUTRecord's table, this may cause issues at downstream processes."),
					  VtiEventCatType.Database, ex.ToString());
				}
			}

            if (Config.Mode.QueryForPreviousSystem.ProcessValue)
            {
                //read previous system used
                if (strConnectVTIToLennox != "")
                {
                    try
                    {
                        SqlConnection sqlConnection2 = new SqlConnection(strConnectVTIToLennox);
                        SqlCommand cmd = new SqlCommand();
                        SqlDataReader returnValue;

                        //string sCommandText = string.Format("Select SystemID, DateTime from dbo.UutRecords where SerialNo = '{0}' and SystemID != '{1}' order by DateTime desc", Machine.Test[port].SerialNumber, Config.Control.System_ID.ProcessValue);
                        string sCommandText = string.Format("SELECT u.SystemID, MAX(urd.DateTime) AS LatestDetailDateTime FROM UutRecords u JOIN UutRecordDetails urd ON u.ID = urd.UutRecordID WHERE u.SerialNo = '{0}' AND u.SystemID != '{1}' AND u.DateTime = (SELECT MAX(DateTime) FROM UutRecords WHERE SerialNo = '{0}' AND SystemID != '{1}') GROUP BY u.SystemID", Machine.Test[port].SerialNumber, Config.Control.System_ID.ProcessValue);
                        cmd.CommandText = sCommandText;
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = sqlConnection2;

                        sqlConnection2.Open();
                        returnValue = cmd.ExecuteReader();

                        returnValue.Read();
                        Machine.Test[port].PreviousSystemID = returnValue["SystemID"].ToString();
                        Machine.Test[port].PreviousSystemEndDateTime = DateTime.Parse(returnValue["LatestDetailDateTime"].ToString());
                        returnValue.Close();

                        sqlConnection2.Close();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            // This does not work --- TAS 6/10/2022
            //if not UutRecordID, generate one from the last record
            //if (Machine.Test[port].UutRecordID == "")  
            //{
            //    Machine.Test[port].UutRecordID = string.Format("{0:0}", Machine.Test[port].LastUutRecordID + 1);                    
            //}
            //Machine.Test[port].LastUutRecordID = Convert.ToInt64(Machine.Test[port].UutRecordID);


            if (Machine.Test[port].UutRecordID != "")
			{
				//Call Lennox Stored Procedure ProcessStatusXRef if a coil
				if(Machine.Test[port].ForceChargeFlag || Machine.Test[port].RecoverUnitFlag)
				{

				}
				else
				{
					// Also add code here for providing all the information Lennox requires for Process Check Insert
					try
					{
						SqlCommand cmd = new SqlCommand("PROCESS_CHECK_INSERT", sqlConnection1);

						cmd.CommandType = CommandType.StoredProcedure;
						cmd.Parameters.Add("SERIAL", SqlDbType.Char);
						cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
						cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
						cmd.Parameters["SERIAL"].Size = 18;

						cmd.Parameters.Add("RESULTS_ID", SqlDbType.Char);
						cmd.Parameters["RESULTS_ID"].Direction = ParameterDirection.Input;
						cmd.Parameters["RESULTS_ID"].Value = Machine.Test[port].UutRecordID;
						cmd.Parameters["RESULTS_ID"].Size = 18;

						string Test_Status = (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == Config.Control.StatusWritePassValue.ProcessValue) ? "PASS" : "FAIL";
						cmd.Parameters.Add("TEST_STATUS", SqlDbType.Char);
						cmd.Parameters["TEST_STATUS"].Direction = ParameterDirection.Input;
						cmd.Parameters["TEST_STATUS"].Value = Test_Status;
						cmd.Parameters["TEST_STATUS"].Size = 10;

						cmd.Parameters.Add("LINE", SqlDbType.Char);
						cmd.Parameters["LINE"].Direction = ParameterDirection.Input;
						cmd.Parameters["LINE"].Value = Config.Control.LennoxLineNum.ProcessValue;
						cmd.Parameters["LINE"].Size = 10;

						cmd.Parameters.Add("STATION", SqlDbType.Char);
						cmd.Parameters["STATION"].Direction = ParameterDirection.Input;
						cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
						cmd.Parameters["STATION"].Size = 10;

						cmd.Parameters.Add("RetCode", SqlDbType.Char);
						cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
						//cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
						cmd.Parameters["RetCode"].Size = 10;

						//SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
						//returnParameter.Direction = ParameterDirection.ReturnValue;

						cmd.Connection = sqlConnection1;

						sqlConnection1.Open();

						cmd.ExecuteNonQuery();

						// RetCode is defind in stored proc @RetCode but is never set
						//String CoilStatus = cmd.Parameters["RetCode"].Value;
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.Message);
						// write the error message to the system log
						VtiEvent.Log.WriteError(
							  string.Format("An error writing to remote database (Lennox Status Table)"),
							  VtiEventCatType.Database, ex.ToString());
					}
					finally
					{
						try
						{
							// always close the connection
							sqlConnection1.Close();
							//int intCoilStatus = Convert.ToInt32(CoilStatus);
						}
						catch(Exception ex)
						{
							Console.WriteLine(ex.Message);
							// write the error message to the system log
							VtiEvent.Log.WriteError(
							  string.Format("An error writing to remote database (Lennox Status Table)"),
							  VtiEventCatType.Database, ex.ToString());
						};
					}

				}
			}

			//store to local UutRecords
			try
			{
				//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
				//SqlCommand cmd = new SqlCommand();
				//store UUTRecordID in TestType, here at the local copy

				Config.Control.TestResultTableName.ProcessValue = "UutRecords";
				// Set the test result and write the records
				String strSqlCmd =
				"insert into UutRecords " +
				"(SerialNo, ModelNo, DateTime, SystemID, OpID, TestType, TestResult, TestPort) " +
				"values('" + Machine.Test[port].SerialNumber + "', '" +
				 Machine.Test[port].ModelNumber + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 Config.Control.System_ID.ProcessValue + "', '" +
				 Machine.Test[port].OpID + "', '" +
				 Config.Control.UutRecordTestType.ProcessValue + "', '" +
				 Machine.Test[port].TestResult + "', '" +
				 "BLUE PORT" + "', '" +
				 "')";

				Console.WriteLine(strSqlCmd);

				//fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
				if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
				{
					fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
				}
			}
			catch(Exception Ex)
			{
				Console.WriteLine(Ex.Message);
			}

            //Store to UutRecordDetails

            //PrechargePressureCheck
            if (Machine.Test[port].PreChargeUnitPressCheckResult != "Not Run")
			{

				//PreChargeUnitPressCheck

				//PreChargeUnitPressSetpoint
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "PreEvacPressCheck" + "', '" +
				 Machine.Test[port].PreChargeUnitPressCheckResult + "', '" +
				 "PreEvacPressCheckSetpoint" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].PreChargeUnitPressCheckSetPoint) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "PreEvacPressSetpoint" + "', '" +
				 string.Format("{0:0.000}", Machine.Test[port].PreChargeUnitPressCheckSetPoint) + "', '" +
				 "psig" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].PreChargeUnitPressCheckTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//PreChargeCheckPressure
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "PreEvacPressCheck" + "', '" +
				 Machine.Test[port].PreChargeUnitPressCheckResult + "', '" +
				 "PreEvacPressCheckPressure" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].PreChargeUnitPressCheckPressure) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "PreEvacCheckPressSetpoint" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].PreChargeUnitPressCheckSetPoint) + "', '" +
				 "psig" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].PreChargeUnitPressCheckTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

			}

            if (Machine.Test[port].InitialEvacResult != "Not Run")
			{
                if (Config.Mode.QueryForPreviousSystem)
                {
                    //Previous System
                    if (strConnectVTIToLennox != "")
                    {
                        try
                        {
                            //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                            //SqlCommand cmd = new SqlCommand();
                            Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                            // Set the test result and write the records
                            String strSqlCmd =
                    "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
                    //"insert into dbo.TestResult "+
                    "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
                    "values('" + Machine.Test[port].UutRecordID + "', '" +
                     DateTime.Now.ToString() + "', '" +
                     "Previous System" + "', '" +
                     Machine.Test[port].PreviousSystemID + "', '" +
                     "Time Since Last System" + "', '" +
                     string.Format("{0:0.0}", (MyStaticVariables.EvacStartTime - Machine.Test[port].PreviousSystemEndDateTime).TotalMinutes) + "', '" +
                     "NoMinSetPoint" + "', '" +
                     "0.0" + "', '" +
                     "MaxEvacDelaySetpoint" + "', '" +
                     "0.0" + "', '" +
                     "minutes" + "', '" +
                      string.Format("{0:0.0}", (MyStaticVariables.EvacStartTime - Machine.Test[port].PreviousSystemEndDateTime).TotalMinutes) + "')";
                            Console.WriteLine(strSqlCmd);

                            fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                            if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                            {
                                fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                            }

                            //cmd.CommandText = strSqlCmd;
                            //cmd.CommandType = CommandType.Text;
                            //cmd.Connection = sqlConnection2;

                            //sqlConnection2.Open();

                            //cmd.ExecuteNonQuery();


                            //sqlConnection2.Close();
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.Message);
                            VtiEvent.Log.WriteError(Ex.Message);
                        }
                    }

                    //Start Initial Evac Pressure
                    if (strConnectVTIToLennox != "")
                    {
                        try
                        {
                            //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                            //SqlCommand cmd = new SqlCommand();
                            Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                            // Set the test result and write the records
                            String strSqlCmd =
                    "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
                    //"insert into dbo.TestResult "+
                    "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
                    "values('" + Machine.Test[port].UutRecordID + "', '" +
                     DateTime.Now.ToString() + "', '" +
                     "InitialEvac" + "', '" +
                     Machine.Test[port].InitialEvacResult + "', '" +
                     "Starting Initial Evac Pressure" + "', '" +
                     string.Format("{0:0.00E0}", Machine.Test[port].StartInitialEvacPressure) + "', '" +
                     "NoMinSetPoint" + "', '" +
                     "0.0" + "', '" +
                     "MaxEvacDelaySetpoint" + "', '" +
                     "0.0" + "', '" +
                     "Torr" + "', '" +
                      string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
                            Console.WriteLine(strSqlCmd);

                            fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                            if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                            {
                                fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                            }

                            //cmd.CommandText = strSqlCmd;
                            //cmd.CommandType = CommandType.Text;
                            //cmd.Connection = sqlConnection2;

                            //sqlConnection2.Open();

                            //cmd.ExecuteNonQuery();


                            //sqlConnection2.Close();
                        }
                        catch (Exception Ex)
                        {
                            Console.WriteLine(Ex.Message);
                            VtiEvent.Log.WriteError(Ex.Message);
                        }
                    }
                }

                //InitialEvacTime
                if (strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "InitialEvac" + "', '" +
				 Machine.Test[port].InitialEvacResult + "', '" +
				 "InitialEvacTime" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "MaxEvacDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.Maximum_Evac_Delay.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}

						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//LowSideChargeWeight
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "LowSideCharge" + "', '" +
				 Machine.Test[port].ChargeResult + "', '" +
				 "LowSideChargeWeight" + "', '" +
				 string.Format("{0:0.0000}", MyStaticVariables.BlueLowSideChargeWeight / 16.0) + "', '" +
				 "MinChargeWeight" + "', '" +
				  string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMinSetpoint / 16.0) + "', '" +
				 "MaxChargeWeight" + "', '" +
				 string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMaxSetpoint / 16.0) + "', '" +
				 "lbs" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							//fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

                //InitialEvacSetpoint
                if (strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "InitialEvac" + "', '" +
				 Machine.Test[port].InitialEvacResult + "', '" +
				 "InitialEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "InitialEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//InitialEvacPressure
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "InitialEvac" + "', '" +
				 Machine.Test[port].InitialEvacResult + "', '" +
				 "InitialEvacPressure" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].InitialEvacPressure) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "InitialEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].InitialEvacSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].InitialEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].FinalEvacResult != "Not Run")
			{
				//FinalEvacTime
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "FinalEvac" + "', '" +
				 Machine.Test[port].FinalEvacResult + "', '" +
				 "FinalEvacTime" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "FinalEvacDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.Final_Evac_Delay.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}


				//FinalEvacSetpoint
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "FinalEvac" + "', '" +
				 Machine.Test[port].FinalEvacResult + "', '" +
				 "FinalEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "FinalEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//FinalEvacPressure
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "FinalEvac" + "', '" +
				 Machine.Test[port].FinalEvacResult + "', '" +
				 "FinalEvacPressure" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].FinalEvacPressure) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "FinalEvacSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].FinalEvacSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].FinalEvacTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].EvacTimeBeforeLastRORResult != "Not Run")
			{
				//EvacTimeBeforeLastROR
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "EvacTimeBeforeLastROR" + "', '" +
				 Machine.Test[port].EvacTimeBeforeLastRORResult + "', '" +
				 "EvacTimeBeforeLastROR" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "MaxEvacDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.Maximum_Evac_Delay.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "')";
						Console.WriteLine(strSqlCmd);


						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//EvacPressBeforeLastROR
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "EvacPressBeforeLastROR" + "', '" +
				 Machine.Test[port].EvacTimeBeforeLastRORResult + "', '" +
				 "EvacPressBeforeLastROR" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].EvacPressBeforeLastROR) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "FinalEvacSetpoint" + "', '" +
				 string.Format("{0:0}", model.Final_Evac_Pressure_SetPointt.ProcessValue) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].EvacTimeBeforeLastROR) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].BasePressBeforeLastRORResult != "Not Run")
			{
				//BasePressBeforeLastROR
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "BasePressBeforeLastROR" + "', '" +
				 Machine.Test[port].BasePressBeforeLastRORResult + "', '" +
				 "BasePressBeforeLastROR" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].BasePressBeforeLastROR) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "BasePressSetpoint" + "', '" +
				 string.Format("{0:0}", Config.Pressure.Base_Pressure_Check_Pressure_SetPoint.ProcessValue) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].BaseTimeBeforeLastROR) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].RORResult != "Not Run")
			{
				//RORTime
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "RateOfRise" + "', '" +
				 Machine.Test[port].RORResult + "', '" +
				 "RORTime" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].RORTime) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "RORDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.ROR_Pressure_Check_Delay.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//RORPressSetpoint
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "RateOfRise" + "', '" +
				 Machine.Test[port].RORResult + "', '" +
				 "RORSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].RORSetpoint) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "RORSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].RORSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//RORPressure
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "RateOfRise" + "', '" +
				 Machine.Test[port].RORResult + "', '" +
				 "RORPressure" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].RORPressure) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "RORSetpoint" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].RORSetpoint) + "', '" +
				 "microns" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].RORTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].ChargeResult == "Not Run")
			{
				VtiEvent.Log.WriteInfo("Actual Charge Weight Was NOT RECORDED ChargeResult = NOT RUN: " + string.Format("{0:0.0000}", Machine.Test[port].ActualChargeWeight / 16.0));
			}
			else
			{
				//ActualTargetWeight
				if(strConnectVTIToLennox != "")
				{
					try
					{
                        // Prevent writing negative charge weights

                        if (Machine.Test[port].ActualChargeWeight < 0)

                            Machine.Test[port].ActualChargeWeight = 0;

                        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                        //SqlCommand cmd = new SqlCommand();
                        Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
						"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
						//"insert into dbo.TestResult "+
						"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
						"values('" + Machine.Test[port].UutRecordID + "', '" +
						 DateTime.Now.ToString() + "', '" +
						 "Charge" + "', '" +
						 Machine.Test[port].ChargeResult + "', '" +
						 "ActualChargeWeight" + "', '" +
						 string.Format("{0:0.0000}", Machine.Test[port].ActualChargeWeight / 16.0) + "', '" +
						 "MinChargeWeight" + "', '" +
						  string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMinSetpoint / 16.0) + "', '" +
						 "MaxChargeWeight" + "', '" +
						 string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMaxSetpoint / 16.0) + "', '" +
						 "lbs" + "', '" +
						  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}

						VtiEvent.Log.WriteError("Actual Charge Weight Written: " + string.Format("{0:0.0000}", Machine.Test[port].ActualChargeWeight / 16.0));

						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						MessageBox.Show("An error occured recording the Actual Charge Weight");
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//ChargeTime
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
						"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
						//"insert into dbo.TestResult "+
						"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
						"values('" + Machine.Test[port].UutRecordID + "', '" +
						 DateTime.Now.ToString() + "', '" +
						 "Charge" + "', '" +
						 Machine.Test[port].ChargeResult + "', '" +
						 "ChargeTime" + "', '" +
						 string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "', '" +
						 "NoMinSetPoint" + "', '" +
						 "0.0" + "', '" +
						 "ChargeDelaySetpoint" + "', '" +
						 string.Format("{0:0.0}", Machine.Test[port].ChargeTimeoutDelay) + "', '" +
						 "seconds" + "', '" +
						  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				//RefSupplyPressDuringCharge
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "Charge" + "', '" +
				 Machine.Test[port].ChargeResult + "', '" +
				 "RefPressDuringCharge" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].RefSupplyPressDuringCharge) + "', '" +
				 "NoMinSetpoint" + "', '" +
				 "0.0" + "', '" +
				 "NoMaxSetpoint" + "', '" +
				 "0.0" + "', '" +
				 "psig" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				if(model.LowSideChargePressureCheckEnabled.ProcessValue && ((model.HiSidePercentage.ProcessValue > 99.5) || (model.HiSidePercentage.ProcessValue < 0.5)))
				{
					//LowSideChargePressureCheckStartPressure
					if(strConnectVTIToLennox != "")
					{
						try
						{
							//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
							//SqlCommand cmd = new SqlCommand();
							Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
							// Set the test result and write the records
							String strSqlCmd =
					"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
					//"insert into dbo.TestResult "+
					"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
					"values('" + Machine.Test[port].UutRecordID + "', '" +
					 DateTime.Now.ToString() + "', '" +
					 "Charge" + "', '" +
					 Machine.Test[port].ChargeResult + "', '" +
					 "LowSideToolCheckStartPress" + "', '" +
					 string.Format("{0:0.0}", Machine.Test[port].LowSideChargePressureCheckPressureStart) + "', '" +
					 "NoMinSetpoint" + "', '" +
					 "0.0" + "', '" +
					 "NoMaxSetpoint" + "', '" +
					 "0.0" + "', '" +
					 "psig" + "', '" +
					  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
							Console.WriteLine(strSqlCmd);

							fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
							if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
							{
								fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
							}


							//cmd.CommandText = strSqlCmd;
							//cmd.CommandType = CommandType.Text;
							//cmd.Connection = sqlConnection2;

							//sqlConnection2.Open();

							//cmd.ExecuteNonQuery();


							//sqlConnection2.Close();
						}
						catch(Exception Ex)
						{
							Console.WriteLine(Ex.Message);
							VtiEvent.Log.WriteError(Ex.Message);
						}
					}

					//LowSideChargePressureCheckPressureValue
					if(strConnectVTIToLennox != "")
					{
						try
						{
							//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
							//SqlCommand cmd = new SqlCommand();
							Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
							// Set the test result and write the records
							String strSqlCmd =
					"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
					//"insert into dbo.TestResult "+
					"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
					"values('" + Machine.Test[port].UutRecordID + "', '" +
					 DateTime.Now.ToString() + "', '" +
					 "Charge" + "', '" +
					 Machine.Test[port].ChargeResult + "', '" +
					 "LowSideToolCheckEndPress" + "', '" +
					 string.Format("{0:0.0}", Machine.Test[port].LowSideChargePressureCheckPressureValue) + "', '" +
					 "NoMinSetpoint" + "', '" +
					 "0.0" + "', '" +
					 "MaxSetpoint" + "', '" +
					 string.Format("{0:0.0}", Machine.Test[port].LowSideChargePressureCheckPressureStart + model.Low_Side_Charge_Pressure_Check_SetPoint.ProcessValue) + "', '" +
					 "psi" + "', '" +
					  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
							Console.WriteLine(strSqlCmd);

							fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
							if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
							{
								fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
							}


							//cmd.CommandText = strSqlCmd;
							//cmd.CommandType = CommandType.Text;
							//cmd.Connection = sqlConnection2;

							//sqlConnection2.Open();

							//cmd.ExecuteNonQuery();


							//sqlConnection2.Close();
						}
						catch(Exception Ex)
						{
							Console.WriteLine(Ex.Message);
							VtiEvent.Log.WriteError(Ex.Message);
						}
					}
				}

				//ChargeTargetWeight
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "Charge" + "', '" +
				 Machine.Test[port].ChargeResult + "', '" +
				 "ChargeTargetWeight" + "', '" +
				 string.Format("{0:0.0000}", model.TotalCharge.ProcessValue / 16.0) + "', '" +
				 "NoMinSetpoint" + "', '" +
				 "0.0" + "', '" +
				 "NoMaxSetpoint" + "', '" +
				 "0.0" + "', '" +
				 "lbs" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}

				// Moved to the top 6/6/22 TAS
				////ActualTargetWeight
				//if (strConnectVTIToLennox != "")
				//{
				//    try
				//    {
				//        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
				//        //SqlCommand cmd = new SqlCommand();
				//        Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
				//        // Set the test result and write the records
				//        String strSqlCmd =
				//"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//            //"insert into dbo.TestResult "+
				//"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				//"values('" + Machine.Test[port].UutRecordID + "', '" +
				// DateTime.Now.ToString() + "', '" +
				// "Charge" + "', '" +
				// Machine.Test[port].ChargeResult + "', '" +
				// "ActualChargeWeight" + "', '" +
				// string.Format("{0:0.0000}", Machine.Test[port].ActualChargeWeight/16.0) + "', '" +
				// "MinChargeWeight" + "', '" +
				//  string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMinSetpoint/16.0) + "', '" +
				// "MaxChargeWeight" + "', '" +
				// string.Format("{0:0.0000}", Machine.Test[port].ChargeTargetWeightMaxSetpoint/16.0) + "', '" +
				// "lbs" + "', '" +
				//  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
				//        Console.WriteLine(strSqlCmd);

				//        fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
				//        if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
				//        {
				//            fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
				//        }


				//        //cmd.CommandText = strSqlCmd;
				//        //cmd.CommandType = CommandType.Text;
				//        //cmd.Connection = sqlConnection2;

				//        //sqlConnection2.Open();

				//        //cmd.ExecuteNonQuery();


				//        //sqlConnection2.Close();
				//    }
				//    catch (Exception Ex)
				//    {
				//        MessageBox.Show("An error occured recording the Actual Charge Weight");
				//        Console.WriteLine(Ex.Message);
				//        VtiEvent.Log.WriteError(Ex.Message);
				//    }
				//}


				//ActualChargeCounts
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "Charge" + "', '" +
				 Machine.Test[port].ChargeResult + "', '" +
				 "ActualChargeCounts" + "', '" +
				 string.Format("{0:0}", Machine.Test[port].ActualCounts) + "', '" +
				 "TargetChargeCounts" + "', '" +
				  string.Format("{0:0}", Machine.Test[port].TargetCounts) + "', '" +
				 "NoMaxSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "counts" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
                //ActualChargeCounts
                if (strConnectVTIToLennox != "")
                {
                    try
                    {
                        double startingcountsTemp = MyStaticVariables.BlueStartingCountsForDataBase;
                        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                        //SqlCommand cmd = new SqlCommand();
                        Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                        // Set the test result and write the records
                        String strSqlCmd =
                "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
                //"insert into dbo.TestResult "+
                "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
                "values('" + Machine.Test[port].UutRecordID + "', '" +
                 DateTime.Now.ToString() + "', '" +
                 "Charge" + "', '" +
                 Machine.Test[port].ChargeResult + "', '" +
                 "StartingCounts" + "', '" +
                 string.Format("{0:0}", startingcountsTemp) + "', '" +
                 "TargetCharge" + "', '" +
                  string.Format("{0:0}", model.TotalCharge.ProcessValue) + "', '" +
                 "NoMaxSetPoint" + "', '" +
                 "0.0" + "', '" +
                 "counts" + "', '" +
                  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
                        Console.WriteLine(strSqlCmd);

                        fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                        if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                        {
                            fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                        }


                        //cmd.CommandText = strSqlCmd;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Connection = sqlConnection2;

                        //sqlConnection2.Open();

                        //cmd.ExecuteNonQuery();


                        //sqlConnection2.Close();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                        VtiEvent.Log.WriteError(Ex.Message);
                    }
                }
                //ActualChargeCounts
                if (strConnectVTIToLennox != "")
                {
                    try
                    {
                        double endingcountsTemp =MyStaticVariables.BlueEndingCountsForDatabase;
                        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                        //SqlCommand cmd = new SqlCommand();
                        Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
                        // Set the test result and write the records
                        String strSqlCmd =
                "insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
                //"insert into dbo.TestResult "+
                "(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
                "values('" + Machine.Test[port].UutRecordID + "', '" +
                 DateTime.Now.ToString() + "', '" +
                 "Charge" + "', '" +
                 Machine.Test[port].ChargeResult + "', '" +
                 "EndingCounts" + "', '" +
                 string.Format("{0:0}", endingcountsTemp) + "', '" +
                 "TargetChargeCounts" + "', '" +
                  string.Format("{0:0}", Machine.Test[port].TargetCounts) + "', '" +
                 "NoMaxSetPoint" + "', '" +
                 "0.0" + "', '" +
                 "counts" + "', '" +
                  string.Format("{0:0.0}", Machine.Test[port].ChargeTime) + "')";
                        Console.WriteLine(strSqlCmd);

                        fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
                        if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
                        {
                            fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
                        }


                        //cmd.CommandText = strSqlCmd;
                        //cmd.CommandType = CommandType.Text;
                        //cmd.Connection = sqlConnection2;

                        //sqlConnection2.Open();

                        //cmd.ExecuteNonQuery();


                        //sqlConnection2.Close();
                    }
                    catch (Exception Ex)
                    {
                        Console.WriteLine(Ex.Message);
                        VtiEvent.Log.WriteError(Ex.Message);
                    }
                }
            }


			//ToolDrain
			if(Machine.Test[port].ToolDrainResult != "Not Run")
			{
				//ToolDrainPressure
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "ToolDrain" + "', '" +
				 Machine.Test[port].ToolDrainResult + "', '" +
				 "ToolDrainPressure" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].ToolDrainPressure) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "NoMaxSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "psig" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].ToolDrainTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}

					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}
            
			if(Machine.Test[port].RecoveryResult != "Not Run")
			{
				//RecoveryTime
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "Charge" + "', '" +
				 Machine.Test[port].RecoveryResult + "', '" +
				 "RecoveryTime" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "ChargeDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.Tool_Recovery_Timeout.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			if(Machine.Test[port].RecoveryResult != "Not Run")
			{
				//RecoveryTime
				if(port == 0)
				{

					if(MyStaticVariables.TimeTo50PsiBlue.Count > 0)
					{
						InsertUUTRecordDetail(strConnectVTIToLennox, Machine.Test[port].UutRecordID, "Recovery", Machine.Test[port].RecoveryResult, MyStaticVariables.TimeTo50PsiBlue[0], "Time To 50 Psi", 0, "", 0, "", "seconds", MyStaticVariables.TimeTo50PsiBlue[0]);
						InsertUUTRecordDetail(strConnectVTIToLennox, Machine.Test[port].UutRecordID, "Recovery", Machine.Test[port].RecoveryResult, MyStaticVariables.EndingRecoveryPressBlue[0], "Ending Recovery Pressure", 0, "", 0, "", "PSIG", 0);
						if(Machine.Test[port].InitialRecoveryPressure != double.MinValue)
						{
							string initialRecoveryResult;
							if(Machine.Test[port].InitialRecoveryPassed)
								initialRecoveryResult = "Pass";
							else
								initialRecoveryResult = "Fail";
							InsertUUTRecordDetail(strConnectVTIToLennox, Machine.Test[port].UutRecordID, "InitialRecovery", initialRecoveryResult, Machine.Test[port].InitialRecoveryPressure, "Initial Recovery Pressure", 0, "", 0, "", "PSIG", 0);
							Machine.Test[port].InitialRecoveryPressure = double.MinValue;
						}
					}
				}
				if(strConnectVTIToLennox != "")
				{
					try
					{
						//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
						//SqlCommand cmd = new SqlCommand();
						Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
						// Set the test result and write the records
						String strSqlCmd =
				"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
				//"insert into dbo.TestResult "+
				"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
				"values('" + Machine.Test[port].UutRecordID + "', '" +
				 DateTime.Now.ToString() + "', '" +
				 "Charge" + "', '" +
				 Machine.Test[port].RecoveryResult + "', '" +
				 "RecoveryTime" + "', '" +
				 string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "', '" +
				 "NoMinSetPoint" + "', '" +
				 "0.0" + "', '" +
				 "ChargeDelaySetpoint" + "', '" +
				 string.Format("{0:0.0}", model.Tool_Recovery_Timeout.ProcessValue) + "', '" +
				 "seconds" + "', '" +
				  string.Format("{0:0.0}", Machine.Test[port].RecoveryTime) + "')";
						Console.WriteLine(strSqlCmd);

						fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
						if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
						{
							fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
						}


						//cmd.CommandText = strSqlCmd;
						//cmd.CommandType = CommandType.Text;
						//cmd.Connection = sqlConnection2;

						//sqlConnection2.Open();

						//cmd.ExecuteNonQuery();


						//sqlConnection2.Close();
					}
					catch(Exception Ex)
					{
						Console.WriteLine(Ex.Message);
						VtiEvent.Log.WriteError(Ex.Message);
					}
				}
			}

			//MachineCycleTime
			Machine.Test[port].MachineCycleTime = IO.Signals.BlueElapsedTime.Value;
			if(strConnectVTIToLennox != "")
			{
				try
				{
					//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
					//SqlCommand cmd = new SqlCommand();
					Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
					// Set the test result and write the records
					String strSqlCmd =
			"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
			//"insert into dbo.TestResult "+
			"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
			"values('" + Machine.Test[port].UutRecordID + "', '" +
			 DateTime.Now.ToString() + "', '" +
			 "MachineCycleTime" + "', '" +
			 Machine.Test[port].TestResultToSendToRemoteSQLDatabase + "', '" +
			 "MachineCycleTime" + "', '" +
			 string.Format("{0:0.0}", Machine.Test[port].MachineCycleTime) + "', '" +
			 "NoMinSetPoint" + "', '" +
			 "0.0" + "', '" +
			 "NoMaxSetpoint" + "', '" +
			 "0.0" + "', '" +
			 "seconds" + "', '" +
			  string.Format("{0:0.0}", Machine.Test[port].MachineCycleTime) + "')";
					Console.WriteLine(strSqlCmd);

					fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
					if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
					{
						fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
					}


					//cmd.CommandText = strSqlCmd;
					//.CommandType = CommandType.Text;
					//cmd.Connection = sqlConnection2;

					//sqlConnection2.Open();

					//cmd.ExecuteNonQuery();


					//sqlConnection2.Close();
				}
				catch(Exception Ex)
				{
					Console.WriteLine(Ex.Message);
					VtiEvent.Log.WriteError(Ex.Message);
				}
			}


			//IdleTime
			if(strConnectVTIToLennox != "")
			{
				try
				{
					//SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
					//SqlCommand cmd = new SqlCommand();
					Config.Control.TestResultTableName.ProcessValue = "UutRecordDetails";
					// Set the test result and write the records
					String strSqlCmd =
			"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
			//"insert into dbo.TestResult "+
			"(UutRecordID, DateTime, Test, Result, ValueName, Value, MinSetpointName, MinSetpoint, MaxSetpointName, MaxSetpoint, Units, ElapsedTime) " +
			"values('" + Machine.Test[port].UutRecordID + "', '" +
			 DateTime.Now.ToString() + "', '" +
			 "MachineIdleTime" + "', '" +
			 Machine.Test[port].TestResultToSendToRemoteSQLDatabase + "', '" +
			 "MachineIdleTime" + "', '" +
			 string.Format("{0:0.0}", Machine.Test[port].IdleTime) + "', '" +
			 "NoMinSetPoint" + "', '" +
			 "0.0" + "', '" +
			 "NoMaxSetpoint" + "', '" +
			 "0.0" + "', '" +
			 "seconds" + "', '" +
			  string.Format("{0:0.0}", Machine.Test[port].IdleTime) + "')";
					Console.WriteLine(strSqlCmd);

					fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
					if(Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
					{
						fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
					}


					//cmd.CommandText = strSqlCmd;
					//cmd.CommandType = CommandType.Text;
					//cmd.Connection = sqlConnection2;

					//sqlConnection2.Open();

					//cmd.ExecuteNonQuery();


					//sqlConnection2.Close();
				}
				catch(Exception Ex)
				{
					Console.WriteLine(Ex.Message);
					VtiEvent.Log.WriteError(Ex.Message);
				}
			}


			//#region LNXQA
			//// Assemble connection string from parameters defined by Jason Hass 3/8/2016
			//// RemoteConnectionString build
			//string strConnectLennox = "";
			//if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
			//    strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
			//if (strConnectLennox.Length > 0)
			//    if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
			//strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
			//strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
			//if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
			//if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

			//VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

			//String CoilStatus = "";
			//SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);
			//// Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
			//// "test.TestResultToSendToRemoteSQLDatabase"
			//// The appropriate status write pass value or status write fail value should be the string within the test. TestResultToSend ToRemoteSQLDatabase)
			//if (strConnectLennox != "")
			//{
			//    try
			//    {

			//        SqlCommand cmd = new SqlCommand("PROCESS_STATUS_UPDATE", sqlConnection1);

			//        cmd.CommandType = CommandType.StoredProcedure;
			//        cmd.Parameters.Add("SERIAL", SqlDbType.Char);
			//        cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
			//        cmd.Parameters["SERIAL"].Size = 18;

			//        cmd.Parameters.Add("PROCESS_STATUS", SqlDbType.Char);
			//        cmd.Parameters["PROCESS_STATUS"].Direction = ParameterDirection.Input;
			//        if (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == "") // If reset occurs value may be null
			//            Machine.Test[port].TestResultToSendToRemoteSQLDatabase = Config.Control.StatusWriteFailValue.ProcessValue;
			//        cmd.Parameters["PROCESS_STATUS"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
			//        cmd.Parameters["PROCESS_STATUS"].Size = 10;

			//        cmd.Parameters.Add("RetCode", SqlDbType.Char);
			//        cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
			//        //cmd.Parameters["RetCode"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
			//        cmd.Parameters["RetCode"].Size = 10;


			//        //SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
			//        //returnParameter.Direction = ParameterDirection.ReturnValue;

			//        cmd.Connection = sqlConnection1;

			//        sqlConnection1.Open();

			//        cmd.ExecuteNonQuery();

			//        // return value should match the process status sent if no error occured.
			//        CoilStatus = cmd.Parameters["RetCode"].Value.ToString();

			//    }
			//    catch (Exception ex)
			//    {
			//        Console.WriteLine(ex.Message);
			//        // write the error message to the system log
			//        // write the error message to the system log
			//        VtiEvent.Log.WriteError(
			//          string.Format("An error writing to remote database (Lennox Status Table)"),
			//          VtiEventCatType.Database, ex.ToString());
			//    }
			//    finally
			//    {
			//        try
			//        {
			//            // always close the connection
			//            sqlConnection1.Close();
			//            //int intCoilStatus = Convert.ToInt32(CoilStatus);
			//        }
			//        catch (Exception ex)
			//        {
			//            Console.WriteLine(ex.Message);
			//            // write the error message to the system log
			//            VtiEvent.Log.WriteError(
			//              string.Format("An error writing to remote database (Lennox Status Table)"),
			//              VtiEventCatType.Database, ex.ToString());
			//        };

			//        //if (CoilStatus == Config.Control.StatusReadPassValue.ProcessValue)
			//        //{
			//        //    // all is good

			//        //}
			//        //else
			//        //{
			//        //    // An error occured updating the status of the unit,  Call a cycle step to notify the operator

			//        //}

			//    }

			//    // Also add code here for providing all the information Lennox requires for Process Check Insert
			//    try
			//    {
			//        SqlCommand cmd = new SqlCommand("PROCESS_CHECK_INSERT", sqlConnection1);

			//        cmd.CommandType = CommandType.StoredProcedure;
			//        cmd.Parameters.Add("SERIAL", SqlDbType.Char);
			//        cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
			//        cmd.Parameters["SERIAL"].Size = 18;

			//        cmd.Parameters.Add("RESULTS_ID", SqlDbType.Char);
			//        cmd.Parameters["RESULTS_ID"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["RESULTS_ID"].Value = Machine.Test[port].TestResultToSendToRemoteSQLDatabase;
			//        cmd.Parameters["RESULTS_ID"].Size = 18;

			//        string Test_Status = (Machine.Test[port].TestResultToSendToRemoteSQLDatabase == Config.Control.StatusWritePassValue.ProcessValue) ? "PASS" : "FAIL";
			//        cmd.Parameters.Add("TEST_STATUS", SqlDbType.Char);
			//        cmd.Parameters["TEST_STATUS"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["TEST_STATUS"].Value = Test_Status;
			//        cmd.Parameters["TEST_STATUS"].Size = 10;

			//        cmd.Parameters.Add("LINE", SqlDbType.Char);
			//        cmd.Parameters["LINE"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["LINE"].Value = Config.Control.LennoxLineNum.ProcessValue;
			//        cmd.Parameters["LINE"].Size = 10;

			//        cmd.Parameters.Add("STATION", SqlDbType.Char);
			//        cmd.Parameters["STATION"].Direction = ParameterDirection.Input;
			//        cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
			//        cmd.Parameters["STATION"].Size = 10;

			//        cmd.Parameters.Add("RetCode", SqlDbType.Char);
			//        cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
			//        //cmd.Parameters["STATION"].Value = Config.Control.LennoxStationNum.ProcessValue;
			//        cmd.Parameters["RetCode"].Size = 10;

			//        //SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
			//        //returnParameter.Direction = ParameterDirection.ReturnValue;

			//        cmd.Connection = sqlConnection1;

			//        sqlConnection1.Open();

			//        cmd.ExecuteNonQuery();

			//        // RetCode is defind in stored proc @RetCode but is never set
			//        //String CoilStatus = cmd.Parameters["RetCode"].Value;
			//    }
			//    catch (Exception ex)
			//    {
			//        Console.WriteLine(ex.Message);
			//        // write the error message to the system log
			//        VtiEvent.Log.WriteError(
			//              string.Format("An error writing to remote database (Lennox Status Table)"),
			//              VtiEventCatType.Database, ex.ToString());
			//    }
			//    finally
			//    {
			//        try
			//        {
			//            // always close the connection
			//            sqlConnection1.Close();
			//            //int intCoilStatus = Convert.ToInt32(CoilStatus);
			//        }
			//        catch (Exception ex)
			//        {
			//            Console.WriteLine(ex.Message);
			//            // write the error message to the system log
			//            VtiEvent.Log.WriteError(
			//              string.Format("An error writing to remote database (Lennox Status Table)"),
			//              VtiEventCatType.Database, ex.ToString());
			//        };

			//        //if (CoilStatus == Config.Control.StatusReadPassValue.ProcessValue)
			//        //{
			//        //    // all is good

			//        //}
			//        //else
			//        //{
			//        //    // An error occured updating the status of the unit,  Call a cycle step to display to notify the operator

			//        //}

			//    }

			//}
			//#endregion


			//// CODE BELOW TO PLACE THE RECORD IN THE VTI DB (Coil Records) ON LENNOX-5 FOR LEAK RATE FOR REPAIR STATION
			//// Commented out now to allow the VTI_Coil_Records Region code above populate the Coil_Records database

			//#region VTI_COIL_RECORDS
			////string strConnect = Config.Control.RemoteConnectionString_VTI.ProcessValue;
			/////*
			////@"Integrated Security = True;
			////Trusted_Connection = True;
			////Connect Timeout = 10;
			////Data Source = " + Config.Control.RemoteDataSource.ProcessValue + @";
			////Initial Catalog = " + Config.Control.RemoteInitialCatalog.ProcessValue;
			////*/
			////DataContext db = null;
			////string sqlCmd = "";
			////int ret = 0;
			//try
			//{
			////    db = new DataContext(strConnect);
			////    DateTime testTime = DateTime.Now;
			////    double dFlowRate = 0, dRejectCriteria = 0;
			////    string result = "";
			////    string SN = "";
			////    if (Machine.Test[0] == null)
			////    {
			////        SN = "DummySerialNumber";
			////        result = "This is a test";
			////    }
			////    else
			////    {
			////        if (Machine.Test[0].SerialNumber == "")
			////            SN = "DummySerialNumber";
			////        else
			////        {
			////            SN = Machine.Test[0].SerialNumber;
			////            result = Machine.Test[0].Result;
			////        }
			////    }

			//    //dFlowRate = Machine.Test[0].LeakRate;
			//    //double Reject;
			//    //Reject = Config.Flow.FineTestRejectRate.ProcessValue;

			//    //dRejectCriteria = Reject;
			//    //int nFirstLDTest;
			//    //try
			//    //{
			//    //    nFirstLDTest = QueryTestResultsForSN(SN);
			//    //}
			//    //catch (Exception e1)
			//    //{
			//    //    VtiEvent.Log.WriteError(
			//    //         String.Format("An error occurred checking the First_LD_Flag for S/N " + SN + "."),
			//    //         VtiEventCatType.Database,
			//    //         e1.ToString());

			//    //    nFirstLDTest = 0;
			//    //}
			//    //string strBadgeNumber = Config.OpID;
			//    //sqlCmd = string.Format("insert into dbo.Test_Results (Serial_Number, Model_Number, Date_Time, System_ID, Op_ID, First_PD_Test, First_LD_Test, Flow_Rate, Reject_Criteria, Test_Result) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
			//    //  SN,
			//    //  model.Name,
			//    //  testTime,
			//    //  Config.Control.System_ID.ProcessValue,
			//    //  strBadgeNumber,
			//    //  '0',
			//    //  nFirstLDTest,
			//    //  dFlowRate,
			//    //  dRejectCriteria,
			//    //  result);

			//    //ret = db.ExecuteCommand(sqlCmd);

			//}
			//catch (Exception e)
			//{
			//    VtiEvent.Log.WriteError(
			//        String.Format("An error occurred writing a Test Result for the chamber station."),
			//        VtiEventCatType.Database,
			//        e.ToString());
			//}
			//finally
			//{
			//    //db.Connection.Close();
			//    //db.Dispose();
			//}
			//#endregion

		}


		public string GetOperatorNameFromBadgeID(string strText)
        {
            string retString = null;
            string strConnect = Config.Control.RemoteConnectionString_VTI.ProcessValue;
            DataContext db = null;
            string sqlCmd = "";
            try
            {
                db = new DataContext(strConnect);
                sqlCmd = string.Format("select securitylevel, firstname, lastname from security_users where decryptbadgeid like '%" + strText + "%'");
                IEnumerable<securityUsersResult> securityUsersMatch = db.ExecuteQuery<securityUsersResult>(sqlCmd);
                foreach (securityUsersResult match in securityUsersMatch)
                {
                    retString = match.FirstName + " " + match.LastName;
                    break;
                }
                db.Connection.Close();
                db.Dispose();
            }
            catch (Exception e)
            {
                VtiEvent.Log.WriteError(
                  string.Format("An error occurred inside VerifyBadgeIDFromBarCodeScan."),
                    VtiEventCatType.Database, e.ToString());
            }
            return retString;
        }

        private string GetSNStatus(string SN)
        {

            #region LNXQA
            // ADD CODE HERE TO ACQUIRE THE STATUS FOR THE SERIAL NUMBER

            // Assemble connection string from parameters defined by Jason Hass 3/8/2016

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

            SqlConnection sqlConnection1 = new SqlConnection(strConnectLennox);
            String CoilStatus = "";
            // Place code here for Status Update (Pass or Fail delivered already from CyclePass, CycleFail or CycleNoTest through 
            // "Machine.Test[port].TestResultToSendToRemoteSQLDatabase"
            // The appropriate status write pass value or status write fail value should be the string within the Machine.Test[port]. TestResultToSend ToRemoteSQLDatabase)
            if (strConnectLennox != "")
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(Config.Control.RemoteConnectionString_LennoxStatusCheckSP.ProcessValue, sqlConnection1);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("SERIAL", SqlDbType.Char);
                    cmd.Parameters["SERIAL"].Direction = ParameterDirection.Input;
                    cmd.Parameters["SERIAL"].Value = Machine.Test[port].SerialNumber;
                    cmd.Parameters["SERIAL"].Size = 18;

                    cmd.Parameters.Add("RetCode", SqlDbType.Char);
                    cmd.Parameters["RetCode"].Direction = ParameterDirection.Output;
                    cmd.Parameters["RetCode"].Size = 10;

                    //SqlParameter returnParameter = cmd.Parameters.Add("RetCode", SqlDbType.Char);
                    //returnParameter.Direction = ParameterDirection.Output;

                    cmd.Connection = sqlConnection1;

                    sqlConnection1.Open();

                    cmd.ExecuteNonQuery();

                    // return value should match the process status sent if no error occured.
                    CoilStatus = cmd.Parameters["RetCode"].Value.ToString();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    // write the error message to the system log
                    VtiEvent.Log.WriteError(
                      string.Format("An error reading from remote database (Lennox Status Table)"),
                      VtiEventCatType.Database, ex.ToString());

                }
                finally
                {
                    try
                    {
                        // always close the connection
                        sqlConnection1.Close();
                        //int intCoilStatus = Convert.ToInt32(CoilStatus);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        // write the error message to the system log
                    }
                    finally
                    {

                    }

                }

                bool readyToRun = false;
                Char delimiter = ',';
                string[] StatusReadPassValues = Config.Control.StatusReadPassValue.ProcessValue.Split(delimiter);
                foreach (var StatusReadPassValue in StatusReadPassValues)
                {
                    if (CoilStatus.Trim() == StatusReadPassValue) readyToRun = true;
                }

                if (readyToRun || CoilStatus.Trim() == Config.Control.StatusReadPassValue.ProcessValue.Trim() || CoilStatus.Trim() == Config.Control.StatusWriteFailValue.ProcessValue.Trim())
                {
                    // all is good
                    return "Ready";

                }
                else
                {
                    // An error occured updating the status of the unit,  Call a cycle step to display to notify the operator
                    return "NotReady";

                };
            }
            #endregion


            //string SerialNumber = "";
            //SerialNumber = SN;
            //string strConnect = Config.Control.RemoteConnectionString_VTI.ProcessValue;
            //DataContext db = null;
            //string sqlCmd = "";

            //// ADD CODE HERE TO ACQUIRE THE STATUS FOR THE SERIAL NUMBER


            //// THE CODE BELOW WAS UTILIZED FOR ALLIED AIR ORIGINALLY
            //try
            //{
            //    db = new DataContext(strConnect);

            //    sqlCmd = "select Test_Result from TEST_RESULTS where Serial_Number = '" + SerialNumber + "' and System_ID = '" + "PDFill" + "'";

            //    IEnumerable<queryResult> flagtest = db.ExecuteQuery<queryResult>(sqlCmd);
            //    string strResult = "";

            //    foreach (queryResult qr in flagtest)
            //    {
            //        strResult = qr.Test_Result;

            //    }
            //    db.Connection.Close();
            //    db.Dispose();

            //    List<string> codes = Config.Control.StatusReadPassValue.ProcessValue.Replace(" ", "").Split(',').ToList<string>();
            //    bool bIsCodeMatch = false;
            //    foreach (string code in codes)
            //    {
            //        if (strResult.Contains(code))
            //        {
            //            bIsCodeMatch = true;
            //            break;
            //        }
            //    }

            //    if (bIsCodeMatch)
            //    { // allow SN to run a cycle on this station

            //        test.SerialNumber = SN;
            //        return "Ready";
            //    }
            //    return "NotReady";
            //}
            //catch (Exception e)
            //{
            //    VtiEvent.Log.WriteError(
            //      string.Format("An error reading from remote database (determining proof test)"),
            //      VtiEventCatType.Database, e.ToString());
            //}

            return "ErrorReadingFromRemoteDatabase";
        }
    }

}

