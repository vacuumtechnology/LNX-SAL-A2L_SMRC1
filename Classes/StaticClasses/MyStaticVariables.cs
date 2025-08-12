using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes
{
    public class MyStaticVariables
    {// static members can be accessed without instantiating the class and are always available.
        //Static members are shared (via the class name) between all objects derived from this class.
        public static bool LateLeakCheckBlueTestInProgress = false;
        public static bool LateLeakCheckWhiteTestInProgress = false;

        public static bool thisIsGlobal = false;
        public static bool AnalogHasBeenInitialized = false;

        public static bool LastAcknowledgeValue = false;

        public static bool ReadyToTest = false;
        public static string ToolTip1 = "";

        public static DateTime _RoughPumpStartTime;

        public static DateTime ScaleWriteTime;

        public static bool ReadyForFinalWeightFlag = false;
        public static bool StartEvacAndChargeFlag = false;

        public static SignalAverager Blue10TorrCDG = new SignalAverager(5);
        public static SignalAverager Blue1000TorrCDG = new SignalAverager(5);

        public static double BlueLowSideChargeWeight;
        public static double BlueLowSideStartWeight;
        public static double BlueLowSideEndWeight;

        public static string MessageRefrigerantType = "";
        public static string MessageRefrigerantName = "";
        public static string MessageSerialNumber="";
        public static string MessageModelNumber="";
        public static double TotalCharge=0.0;
        public static double ActualCharge=0.0;
        public static bool PassedFlag=false;

        public static double InitialPartialCharge=0.0;
        public static double FinalPartialCharge=0.0;

        public static bool SerialNumberByMessBoxFlag=false;

        public static string MessageBoxInvalidText="";

        public static bool ReadTheScaleFlag = false;

        public static bool InitializeCounter = false;
        public static bool USBCounterError = false;
        public static bool ShowUSBCounterSetupError = false;
        public static bool ShowUSBCounterNoDetectedError = false;
        public static DateTime USBErrorTime = DateTime.Now;

        public static Boolean WaitForAcknowledgeFlagBlue=false;
        public static Boolean WaitForAcknowledgeFlagWhite=false;

        public static DateTime EvacStartTime;

        public static Double LeakRate=0;

        public static DateTime LastAnalogReadTime = DateTime.Now;

        public static Double LastBlueCharge;
        public static Double LastWhiteCharge;

        public static string EnteredSerialNumber;


        public static double ChargeTargetWeight;
        public static double ActualChargeWeight;

        public static bool RemoveProcessFittingPrompt;

        public static DateTime dtGoodRecoveryPressureStart=DateTime.Now;

		public static List<double> TimeTo50PsiBlue = new List<double>();
		public static List<double> EndingRecoveryPressBlue = new List<double>();
		public static DateTime RecoveryStartBlue;
		public static DateTime RecoveryAbove50PsiBlue;

        public static SleepDiagnostic[] SleepDiagnosticVar = new SleepDiagnostic[2]
        {
            new SleepDiagnostic(),new SleepDiagnostic()
        };

        public class SleepDiagnostic
        {
            public bool RORToHoseOnGunsStarted = false;
            public bool RORToGunsStarted = false;
            public bool RORWithoutGunsStarted = false;
            public DateTime RORToGunsCalcStartTime = DateTime.Now;
            public DateTime RORToGunsCalcEndTime = DateTime.Now;
            public DateTime RORWithoutGunsCalcStartTime = DateTime.Now;
            public DateTime RORWithoutGunsCalcEndTime = DateTime.Now;
            public DateTime RORToHoseOnGunsCalcStartTime = DateTime.Now;
            public DateTime RORToHoseOnGunsCalcEndTime = DateTime.Now;
            public DateTime EvacStarted = DateTime.Now;
            public DateTime EvacEnd = DateTime.Now;

            public double InitialBasePressureCheckTime = 0;
            public double InitialBasePressureCheckPressure = 0;
            public double SystemEvacuationTimeInHr = 0;
            public double SystemEvacuationPressure = 0;
            public double FinalBasePressureCheckTime = 0;
            public double FinalBasePressureCheckPressure = 0;
            public string ROR1Initialtime = "";
            public double ROR1InitialPressure = 0;
            public string ROR1Finaltime = "";
            public double ROR1FinalPressure = 0;
            public double ROR1mtorrPerMin = 0;
            public double RepeatEvac1Time = 0;
            public double RepeatEvac1Pressure = 0;
            public string ROR2Initialtime = "";
            public double ROR2InitialPressure = 0;
            public string ROR2Finaltime = "";
            public double ROR2FinalPressure = 0;
            public double ROR2mtorrPerMin = 0;
            public double RepeatEvac2Time = 0;
            public double RepeatEvac2Pressure = 0;
            public string ROR3Initialtime = "";
            public double ROR3InitialPressure = 0;
            public string ROR3Finaltime = "";
            public double ROR3FinalPressure = 0;
            public double ROR3mtorrPerMin = 0;
            public string Result = "";
            public double ror1 { get { return (ROR1FinalPressure - ROR1InitialPressure) / ((RORToHoseOnGunsCalcEndTime - RORToHoseOnGunsCalcStartTime).TotalMinutes); } }
            public double ror2 { get { return (ROR2FinalPressure - ROR2InitialPressure) / ((RORToGunsCalcEndTime - RORToGunsCalcStartTime).TotalMinutes); } }
            public double ror3 { get { return (ROR3FinalPressure - ROR3InitialPressure) / ((RORWithoutGunsCalcEndTime - RORWithoutGunsCalcStartTime).TotalMinutes); } }
            public bool Passed
            {
                get
                {
                    if ((ror1 < Configuration.Config.Flow.SleepDiagnosticMaxROR.ProcessValue || !RORToHoseOnGunsStarted) &&
                        ror2 < Configuration.Config.Flow.SleepDiagnosticMaxROR.ProcessValue &&
                        ror3 < Configuration.Config.Flow.SleepDiagnosticMaxROR.ProcessValue) return true;
                    else return false;
                }
            }


        }

        public static List<UUTRecordDetailToWrite> BlueUUTRecordsToWrite = new List<UUTRecordDetailToWrite>();

        public class UUTRecordDetailToWrite
        {
            public DateTime DateTime1;
            public String Test1;
            public String Result1;
            public string ValueName1;
            public double value1;
            public double MinSetpoint1;
            public string MinSetpointName1;
            public double MaxSetpoint1;
            public string MaxSetpointName1;
            public string Units1;
            public double ElapsedTime1;

            public UUTRecordDetailToWrite(DateTime dateTime1, string test1, string result1, string valueName1, double value1, double minSetpoint1, string minSetpointName1, double maxSetpoint1, string maxSetpointName1, string units1, double elapsedTime1)
            {
                DateTime1 = dateTime1;
                Test1 = test1;
                Result1 = result1;
                ValueName1 = valueName1;
                this.value1 = value1;
                MinSetpoint1 = minSetpoint1;
                MinSetpointName1 = minSetpointName1;
                MaxSetpoint1 = maxSetpoint1;
                MaxSetpointName1 = maxSetpointName1;
                Units1 = units1;
                ElapsedTime1 = elapsedTime1;
            }
        }
        public static double MilesToKilo(double miles)
        {
            // This method can be accessed through the class name MyStaticVariables not through an instance of MyStaticVariables and is always available
            // No instantiation is needed
            return miles * 1.609;
        }

        public class ProcessSatusResult
        {
            public string CoilStatus = "";
            public string Message = "";
            public string MTL_NBR = "";
        }

		public class ProcessSatusResult2
		{
			public string CoilStatus = "";
			public string Message = "";
			public string MTL_NBR = "";
			public float CHARGE_WEIGHT = (float)0.0;
			public string Refrig_type = "";
		}

		public class ModelDataResult
        {
            public string ModelName = "";
            public string RefrigerantType = "";
            public string TotalCharge = "";
            public string HiSideChargePercentage = "";
            public string RORPressureCheckDelay = "";
            public string RateOfRisePressureCheckSetpoint = "";
            public string InitialEvacDelay = "";
            public string InitialEvacPressureSetpoint = "";
            public string FinalEvacDelay = "";
            public string FinalEvacPressureSetpoint = "";
            public string RepeatEvacDelay = "";
            public string MaximumEvacDelay = "";
            public string ToolDrainDelay = "";
            public string ToolRecoveryTimeout = "";
            public string RecoveryPressureSetpoint = "";
            public string PrechargeUnitCheckPressureSetpoint = "";
            public string MaximumChargeWeightError = "";
            public string MinimumChargeWeightError = "";
            public string LowSideChargePressureCheck = "";
            public string LowSideChargePressureLimit = "";
            public string PartialChargePercent = "";
            public string UnitType = "";
            public string PartialChargePressTarget = "";
            public string CoilType = "";
            public bool ModelDataIsGood = false;
        }

        public class SignalAverager
        {
            public int Num2Avgerage;
            public int index;
            public double[] Data;
            public bool ready2AverageAll;

            public SignalAverager()
            {
                Num2Avgerage = 4;
                index = 0;
                Data = new double[Num2Avgerage];
                ready2AverageAll = false;
            }

            public SignalAverager(int num2Avgerage)
            {
                Num2Avgerage = num2Avgerage;
                Data = new double[Num2Avgerage];
                ready2AverageAll = false;
            }

            public double GetSignal(double UnAveragedSignal)
            {
                #region Add Data
                Data[index] = UnAveragedSignal;
                index++;
                #endregion

                #region reset indext if out of bounds of array
                if (index >= Num2Avgerage)
                {
                    index = 0;
                    ready2AverageAll = true;
                }
                #endregion

                if (ready2AverageAll) // if array is full, sum all
                {
                    double sum = 0;
                    for (int i = 0; i < Num2Avgerage; i++)
                    {
                        sum = sum + Data[i];
                    }
                    return sum / Num2Avgerage;
                }
                else //if array is not full, sum data to index
                {
                    double sum = 0;
                    for (int i = 0; i < index; i++)
                    {
                        sum = sum + Data[i];
                    }
                    return sum / Num2Avgerage;
                }
            }
        }


    }
}
