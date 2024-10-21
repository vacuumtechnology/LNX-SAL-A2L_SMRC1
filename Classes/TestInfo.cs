using System;


namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes
{
    public class TestInfo
    {
		public DateTime LastHiCounterWriteTime = DateTime.Now;
		public DateTime LastLoCounterWriteTime = DateTime.Now;

		public bool InitialRecoveryPassed { get; set; }
		public double InitialRecoveryPressure { get; set; }
		public double VerificationMeasuredFlow { get; set; }
        public double PDStartPressure { get; set; }
        public double PDEndPressure { get; set; }
        public double PDTestPressureDrop { get; set; }

        public bool MessageBoxFlag { get; set; }

        public double UnitStartWeight { get; set; }
        public double UnitEndWeight { get; set; }
        public double UnitNetWeight { get; set; }

        public string SerialNumber { get; set; }
        public int Port { get; set; }
        public double CalVolSum { get; set; }
        public int CalVolCount { get; set; }
        public double CalVolPressure { get; set; }
        public double FinalUnitSum { get; set; }
        public int FinalUnitCount { get; set; }
        public double FinalUnitPressure { get; set; }
        public double ExpansionSum { get; set; }
        public int ExpansionCount { get; set; }
        public double ExpansionPressure { get; set; }
        public double CalVolume { get; set; }
        public double UnitVolume { get; set; }
        public double IncEvacPressure { get; set; }
        public double SettlePressure { get; set; }
        //public double RORPressure { get; set; }
        public double LeakRate { get; set; }
        public double CapRSettlePressure { get; set; }
        public double CapRRORPressure { get; set; }
        public double CapRLeakRate { get; set; }
        public bool OpenRecovB4Reset { get; set; }
        public string PreviousSystemID { get; set; }
        public DateTime PreviousSystemEndDateTime { get; set; }


        public string TestResultToSendToRemoteSQLDatabase { get; set; }
        public string Result { get; set; }

        public string MTL_NBR { get; set; }

        public string TestResult { get; set; }
        public string TestHistory { get; set; }

        public bool FilledWithTracerGas { get; set; }
        public string MessageFormText { get; set; }


        public double PartialChargeActualCharge { get; set; }

        public bool BlueCharge { get; set; }
        public bool WhiteCharge { get; set; }

        public int HiSideCounter { get; set; }
        public int LowSideCounter { get; set; }

        public int LoadHiSideCounter { get; set; }
        public int LoadLowSideCounter { get; set; }

        public bool CountersInitialized { get; set; }

        public bool UsingRoughPumpForToolCheckFlag { get; set; }

        public bool HiSideCounterOutputOnFlag { get; set; }
        public bool LowSideCounterOutputOnFlag { get; set; }

        public int CounterOutputByte { get; set; }

        public bool ForceLowSideChargeFlag { get; set; }
        public bool ForceHiSideChargeFlag { get; set; }

        public bool ForceChargeFlag { get; set; }

        public bool RecoverLowSideFlag { get; set; }
        public bool RecoverHiSideFlag { get; set; }

        public double LowSideBatchStart { get; set; }
        public double HiSideBatchStart { get; set; }

        public bool PassedChargeFlag { get; set; }

        public string RefName { get; set; }
        public string LeakySide { get; set; }
        public double EvacPressure { get; set; }
        public double RORPressure { get; set; }
        public double ElapsedTime { get; set; }

        public int ChargeStartCounts { get; set; }
        public int ChargeEndCounts { get; set; }

        public double ChargeCalculatedWeight{get; set;}

        public bool PassedFlag { get; set; }
        public bool FailedFlag { get; set; }
        public bool NoTestFlag { get; set; }

        public double PartChargeByCounterStart { get; set; }

        public bool AbortTest { get; set; }

        public double CalTargetWeight { get; set; }
        public int CalTargetCounts { get; set; }
        public double CalWeightByCounter { get; set; }
        public int CalActualCounts { get; set; }
        public bool CalLoadCounterData { get; set; }

        public bool RecoverUnitFlag { get; set; }
        public bool RateOfRisePassedFlag { get; set; }

        public string ModelNumber { get; set; }

        public int StoredProcedureCheck { get; set; }

        public string PassedString { get; set; }

        public DateTime LowFlowAlarmStartTime { get; set; }

        public bool RunningATestFlag { get; set; }

        public bool HiSideOnlyCharge { get; set; }
        public int CounterStartValueHiSide { get; set; }
        public int CounterStartValueLowSide { get; set; }
        public int CounterStopValueHiSide { get; set; }
        public int CounterStopValueLowSide { get; set; }
        public bool SavedLastFlow { get; set; }
        public double LastFlowValue { get; set; }

        public string OpID { get; set; }
        public string UutRecordID { get; set; }
        public Int64 LastUutRecordID { get; set; }

        public string PreChargeUnitPressCheckResult;
        public double PreChargeUnitPressCheckSetPoint;
        public double PreChargeUnitPressCheckPressure;
        public double PreChargeUnitPressCheckTime;

        public string ToolDrainResult;
        public double ToolDrainPressure;
        public double ToolDrainTime;

        public string InitialEvacResult;
        public string FinalEvacResult;
        public string EvacTimeBeforeLastRORResult;
        public string BasePressBeforeLastRORResult;
        public string RORResult;
        public string ChargeResult;
        public string RecoveryResult;

        public double StartInitialEvacPressure;

        public double InitialEvacTime;
        public double InitialEvacSetpoint;
        public double InitialEvacPressure;

        public double FinalEvacTime;
        public double FinalEvacSetpoint;
        public double FinalEvacPressure;

        public double RepeatEvacTime;

        public double EvacTimeBeforeLastROR;
        public double EvacPressBeforeLastROR;
        public double BaseTimeBeforeLastROR;
        public double BasePressBeforeLastROR;

        public double RORTime;
        public double RORSetpoint;
        //public double RORPressure;

        public double RORStartPressure;
        public double RORDeltaPressure;

        public double ConvectionFinalEvacPressure;
        public double CDGFinalEvacPressure;
        public double ConvectionFinalRORPressure;
        public double CDGFinalRORPressure;
        public double ConvectionTimeToEvacSetPoint;
        public double CDGTimeToEvacSetPoint;


        public double HighSideChargeTime;
        public double ChargeTime;
        public double ChargeTimeoutDelay;
        public double ChargeTargetWeight;
        public double ChargeTargetWeightMaxSetpoint;
        public double ChargeTargetWeightMinSetpoint;
        public double ActualChargeWeight;
        public Int32 ActualCounts;
        public Int32 TargetCounts;

        public double DataPlotStartTime;
        public double FinalEvacTimeForPlot;
        public double RORDelayTimeForPlot;

        public double LowSideChargePressureCheckPressureStart;
        public double LowSideChargePressureCheckPressureValue;

        public double RecoveryTime;

        public double MachineCycleTime;
        public double IdleTime;

        public double RefSupplyPressDuringCharge;

        public bool FailToolRecoveryFlag;
            
        

    }

    public class securityUsersResult
    {
        public string BadgeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SecurityLevel { get; set; }
    }
    public class queryResult
    {
        public long UnitID { get; set; }
        public string SerialNo { get; set; }
        public string ModelRun { get; set; }
        public DateTime DateRun { get; set; }
        public string ProcessInterlock { get; set; }
        public string KCInterlock { get; set; }
        public string ProdOrder { get; set; }
        public string Test_Result { get; set; }
    }

}
