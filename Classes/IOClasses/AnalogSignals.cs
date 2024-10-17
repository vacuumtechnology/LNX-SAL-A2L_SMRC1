using System;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes;
using VTI_EVAC_AND_SINGLE_CHARGE.Properties;
using VTIWindowsControlLibrary.Classes.IO;
//using VTIWindowsControlLibrary.Classes.CycleSteps;
//using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// AnalogSignals class
    /// 
    /// Subclass of the IOSubSystemBase class
    /// Contains fields for the analog signals.  The Analog Signals
    /// are the "real" signals (i.e. psi, torr, cc/sec, etc).
    /// This class also contains an example of a subclass "AnalogSignalPort" that
    /// can be used for multi-port systems, such as a PD
    /// </summary>
    public class AnalogSignals : AnalogSignalCollection
    {
        public AnalogSignal BlueSetPoint;
        public AnalogSignal RefrigerantPPMVolts;
        public AnalogSignal RefrigerantPPM;

        public AnalogSignal BlueSupplyPressure;//calculate in event handler
        public AnalogSignal BlueHiSideToolPressure;//calculate in event handler
        public AnalogSignal BlueLoSideToolPressure;//calculate in event handler

        public AnalogSignal BlueSupplyPressureBP;//uses Bob Powell Linear Convertor
        public AnalogSignal BlueHiSideToolPressureBP;//uses Bob Powell Linear Convertor
        public AnalogSignal BlueLoSideToolPressureBP;//uses Bob Powell Linear Convertor

        public AnalogSignal BluePartFlow;
        public AnalogSignal BluePartCharge;
        public AnalogSignal BluePartChargeByCounter;
        public AnalogSignal BluePartChargeInPounds;

        public AnalogSignal BlueHiSideCounter;
        public AnalogSignal BlueLowSideCounter;
        public AnalogSignal BlueHiSideCounterLimitSignal;
        public AnalogSignal BlueLowSideCounterLimitSignal;

        public AnalogSignal WhiteSupplyPressure;
        public AnalogSignal WhiteHiSideToolPressure;
        public AnalogSignal WhitePartFlow;
        public AnalogSignal WhitePartCharge;
        public AnalogSignal WhitePartChargeByCounter;

        public AnalogSignal WhiteHiSideCounter;
        public AnalogSignal WhiteLowSideCounter;

        public AnalogSignal BluePartVacuum;
        public AnalogSignal WhitePartVacuum;


        public AnalogSignal BlueEvacPressureCDG10Volts;
        public AnalogSignal BlueEvacPressureCDG10;
        public AnalogSignal BlueEvacPressureCDG1000Volts;
        public AnalogSignal BlueEvacPressureCDG1000;
        public AnalogSignal BluePartVacuummTorr;

        public AnalogSignal CounterOutputs;

        public AnalogSignal BlueElapsedTime;
        public AnalogSignal WhiteElapsedTime;

        public AnalogSignal ScaleWeight;
        public AnalogSignal BlueStartWeight;
        public AnalogSignal BlueNetWeight;
        public AnalogSignal WhiteStartWeight;
        public AnalogSignal WhiteNetWeight;

        public AnalogOutputSignal BlueHiSideCounterValue;
        public AnalogOutputSignal BlueLoSideCounterValue;
        public AnalogOutputSignal BlueHiSideCounterLimit;
        public AnalogOutputSignal BlowLoSideCounterLimit;

        public class AnalogSignalPort
        {

            public AnalogSignal HiSideToolPressure;
            public AnalogSignal PartVacuum;
            public AnalogSignal PartVacuummTorr;

            public AnalogSignal PartPressure;
            public AnalogSignal PartFlow;
            public AnalogSignal PartCharge;
            public AnalogSignal PartChargeByCounter;
            public AnalogSignal PartChargeInPounds;
            public AnalogSignal PartTemperature;

            public AnalogSignal UnitStartWeight;
            public AnalogSignal UnitNetWeight;

            public AnalogSignal SupplyPressure;
            public AnalogSignal ElapsedTime;
        }

        // Array for the analog signal "ports"
        protected AnalogSignalPort[] _port;
        public AnalogSignalPort[] Port { get { return _port; } }

        // Constructor for AnalogSignals
        // Calls the base class constructor
        // Creates the analog signal ports, and assigns the FillPressure
        // field for each
        public AnalogSignals()//(IOInterface IOInterface)
        //: base(IOInterface)
        {
            InitializePorts();
            InitializeSignals();
        }

        protected virtual void InitializePorts()
        {
            _port = new AnalogSignalPort[2];
            _port[0] = new AnalogSignalPort();
            _port[1] = new AnalogSignalPort();

        }
            
        

        protected virtual void InitializeSignals()
        {
            //Set Up analog outputs
            BlueHiSideCounterValue = new AnalogOutputSignal("Hi Side Counter", "Counts", "0", 100.0, 0.0, IO.AOut.BlueCircuit2HiSideCountLimit);

            //Analog Signals
            BlueHiSideCounter = new AnalogSignal(Localization.AnalogSignalHiSideCounts, "", "0", 30000F, true, true, IO.AIn.BlueCircuit2HiSideCounterVolts, IO.SignalConverters.BlueHiSideCounterSigConvert);
            BlueLowSideCounter = new AnalogSignal(Localization.AnalogSignalLoSideCounts, "", "0", 30000F, true, true, IO.AIn.BlueCircuit2LoSideCounterVolts, IO.SignalConverters.BlueLoSideCounterSigConvert);

            BlueHiSideCounterLimitSignal = new AnalogSignal(Localization.AnalogSignalHiSideCounterLimit, "", "0", 30000F, true, true, IO.AIn.BlueCircuit2HiSideCounterLimitVolts, IO.SignalConverters.BlueHiSideCounterLimitSigConvert);
            BlueLowSideCounterLimitSignal = new AnalogSignal(Localization.AnalogSignalLowSideCounterLimit, "", "0", 30000F, true, true, IO.AIn.BlueCircuit2LoSideCounterLimitVolts, IO.SignalConverters.BlueLoSideCounterLimitSigConvert);


            CounterOutputs = new AnalogSignal(Localization.AnalogSignalCounterOutputs, "", "0", 20F, true, true, IO.AIn.CounterOutputVolts, IO.SignalConverters.CounterOutputSigConvert);

            //analog input transducers changed to allow real time adjustment of offsets
            BlueSupplyPressureBP = new AnalogSignal(Localization.AnalogSignalSupplyPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true, IO.AIn.BlueCircuit2SupplyPressureVolts, IO.SignalConverters.BlueSupplyPressureSigConvert);
            BlueSupplyPressureBP.ValueChanged += BlueSupplyPressureBP_ValueChanged;
            BlueSupplyPressure = new AnalogSignal(Localization.AnalogSignalSupplyPressure, Localization.AnalogSignalpsig, "0.0", -1, true, true);

            //analog input transducers changed to allow real time adjustment of offsets
            BlueHiSideToolPressureBP = new AnalogSignal(Localization.AnalogSignalToolPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true, IO.AIn.BlueCircuit2HiSideToolPressureVolts, IO.SignalConverters.BlueHiSidePressureSigConvert);
            BlueHiSideToolPressureBP.ValueChanged += BlueHiSideToolPressureBP_ValueChanged;
            BlueHiSideToolPressure = new AnalogSignal(Localization.AnalogSignalToolPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true);

            //analog input transducers changed to allow real time adjustment of offsets
            BlueLoSideToolPressureBP = new AnalogSignal(Localization.AnalogSignalLoSideToolPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true, IO.AIn.BlueCircuit2LoSideToolPressureVolts, IO.SignalConverters.BlueLoSidePressureSigConvert);
            BlueLoSideToolPressureBP.ValueChanged += BlueLoSideToolPressureBP_ValueChanged;
            BlueLoSideToolPressure = new AnalogSignal(Localization.AnalogSignalLoSideToolPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true);

            //WhiteSupplyPressure = new AnalogSignal(Localization.AnalogSignalSupplyPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true, IO.AIn.WhiteCircuit1SupplyPressureVolts, IO.SignalConverters.WhiteSupplyPressureSigConvert);
            
            //WhiteHiSideToolPressure = new AnalogSignal(Localization.AnalogSignalToolPressure, Localization.AnalogSignalpsig, "0.0", 500F, true, true, IO.AIn.WhiteCircuit1HiSideToolPressureVolts, IO.SignalConverters.WhiteHiSidePressureSigConvert);
            
            //WhiteHiSideToolPressure.ValueChanged += WhiteHiSideToolPressure_ValueChanged;

            
            WhiteHiSideCounter = new AnalogSignal(Localization.AnalogSignalHiSideCounts, "", "0", -1, true, true);
            
            WhiteLowSideCounter = new AnalogSignal(Localization.AnalogSignalLoSideCounts, "", "0", -1, true, true);

            RefrigerantPPMVolts = new AnalogSignal("Refrigerant PPM Volts", "volts", "0.000", 10F, true, true, IO.AIn.RefrigerantPPMVolts, IO.SignalConverters.RefrigerantPPMVoltsConv);
            RefrigerantPPMVolts.ValueChanged += RefrigerantPPMVolts_ValueChanged;
            RefrigerantPPM = new AnalogSignal("Refrigerant PPM", "PPM", "0.0", -1, true, true);
            
            BlueEvacPressureCDG10Volts = new AnalogSignal("CDG 10 Volts", "volts", "0.000", 10F, true, true, IO.AIn.BlueCDG10Volts, IO.SignalConverters.BlueCDG10VoltsConv);
            BlueEvacPressureCDG10Volts.ValueChanged += BlueEvacPressureCDG10Volts_ValueChanged;
            BlueEvacPressureCDG10 = new AnalogSignal("CDG 10 Press", "Torr", "0.000", -1, true, true);



            BlueEvacPressureCDG1000Volts = new AnalogSignal("CDG 1000 Volts", "volts", "0.000", 10F, true, true, IO.AIn.BlueCDG1000Volts, IO.SignalConverters.BlueCDG1000VoltsConv);
            BlueEvacPressureCDG1000Volts.ValueChanged += BlueEvacPressureCDG1000Volts_ValueChanged;
            BlueEvacPressureCDG1000 = new AnalogSignal("CDG 1000 Press", "Torr", "0", -1, true, true);


            BluePartVacuummTorr = new AnalogSignal(Localization.AnalogSignalEvacPressure_mTorr, "mTorr", "0", 1500F, true, true);
            BluePartVacuum = new AnalogSignal(Localization.AnalogSignalEvacPressure,"Torr","0.0",-1,true,true);
            _port[0].PartVacuum = BluePartVacuum;
			WhitePartVacuum = new AnalogSignal(Localization.AnalogSignalEvacPressure,"Torr","0.0",-1,true,true);

			////CounterOutputs = new AnalogSignal("Counter Outputs", "", "0", -1, true, true);
			//CounterOutputs = new AnalogSignal(Localization.AnalogSignalCounterOutputs, "", "0", -1, true, true);

			//BluePartCharge = new AnalogSignal("Part Charge", "oz", "0.00", -1, true, true);
			BluePartCharge = new AnalogSignal(Localization.AnalogSignalPartCharge, Localization.AnalogSignaloz, "0.00", -1, true, true);
            BluePartChargeInPounds = new AnalogSignal(Localization.AnalogSignalPartCharge, Localization.AnalogSignallbs, "0.000", -1, true, true);
            //WhitePartCharge = new AnalogSignal("Part Charge", "oz", "0.00", -1, true, true);
            WhitePartCharge = new AnalogSignal(Localization.AnalogSignalPartCharge, Localization.AnalogSignaloz, "0.00", -1, true, true);

            //BluePartChargeByCounter = new AnalogSignal("Part Charge","lb","0.0",-1,true,true);
            BluePartChargeByCounter = new AnalogSignal(Localization.AnalogSignalPartCharge, Localization.AnalogSignaloz, "0.0", -1, true, true);
            //WhitePartChargeByCounter = new AnalogSignal("Part Charge","lb","0.0",-1,true,true);
            WhitePartChargeByCounter = new AnalogSignal(Localization.AnalogSignalPartCharge, Localization.AnalogSignaloz, "0.0", -1, true, true);

            //BluePartFlow = new AnalogSignal("Part Flow", "oz/s", "0.00", -1, true, true);
            BluePartFlow = new AnalogSignal(Localization.AnalogSignalPartFlow, Localization.AnalogSignaloz_s, "0.00", -1, true, true);
            //WhitePartFlow = new AnalogSignal("Part Flow", "oz/s", "0.00", -1, true, true);
            WhitePartFlow = new AnalogSignal(Localization.AnalogSignalPartFlow, Localization.AnalogSignaloz_s, "0.00", -1, true, true);

            ScaleWeight = new AnalogSignal(Localization.ScaleWeight, Localization.AnalogSignallbs, "0.00", -1, true, true);
            BlueStartWeight = new AnalogSignal(Localization.UnitStartWeight, Localization.AnalogSignallbs, "0.00", -1, true, true);
            BlueNetWeight = new AnalogSignal(Localization.UnitNetWeight, Localization.AnalogSignaloz, "0.0", -1, true, true);
            WhiteStartWeight = new AnalogSignal(Localization.UnitStartWeight, Localization.AnalogSignallbs, "0.00", -1, true, true);
            WhiteNetWeight = new AnalogSignal(Localization.UnitNetWeight, Localization.AnalogSignaloz, "0.0", -1, true, true);

            //ElapsedTime = new AnalogSignal("Elapsed Time", "sec", "0.0", -1, true, true);
            BlueElapsedTime = new AnalogSignal(Localization.AnalogSignalElapsedTime,Localization.AnalogSignalseconds, "0.0", -1, true, true);
            WhiteElapsedTime = new AnalogSignal(Localization.AnalogSignalElapsedTime, Localization.AnalogSignalseconds, "0.0", -1, true, true);

            BlueSetPoint = new AnalogSignal("Set Point", "", "0.000", -1, true, true);

            _port[0].PartVacuum = BluePartVacuum;
            _port[0].PartVacuummTorr = BluePartVacuummTorr;
            _port[0].HiSideToolPressure = BlueHiSideToolPressure;
            _port[1].HiSideToolPressure = WhiteHiSideToolPressure;

            _port[0].PartPressure = BlueHiSideToolPressure;
            _port[0].PartFlow = BluePartFlow;
            _port[0].PartCharge = BluePartCharge;
            _port[0].PartChargeByCounter = BluePartChargeByCounter;
            _port[0].SupplyPressure = BlueSupplyPressure;

            _port[0].UnitStartWeight = BlueStartWeight;
            _port[0].UnitNetWeight = BlueNetWeight;

            _port[0].ElapsedTime = BlueElapsedTime;

            _port[1].PartVacuum = BluePartVacuum;

            _port[1].PartPressure = WhiteHiSideToolPressure;
            _port[1].PartFlow = WhitePartFlow;
            _port[1].PartCharge = WhitePartCharge;
            _port[1].PartChargeByCounter = WhitePartChargeByCounter;
            _port[1].SupplyPressure = WhiteSupplyPressure;

            _port[1].UnitStartWeight = WhiteStartWeight;
            _port[1].UnitNetWeight = WhiteNetWeight;


            _port[1].ElapsedTime = WhiteElapsedTime;
        }

        private void RefrigerantPPMVolts_ValueChanged(object sender, EventArgs e)
        {
            RefrigerantPPM.RawValue = RefrigerantPPMVolts.RawValue;
            RefrigerantPPM.Value = RefrigerantPPMVolts.RawValue * 100;

        }

        private void BlueEvacPressureCDG1000Volts_ValueChanged(object sender, EventArgs e)
        {
            BlueEvacPressureCDG1000.RawValue = BlueEvacPressureCDG1000Volts.RawValue;
            BlueEvacPressureCDG1000.Value = MyStaticVariables.Blue1000TorrCDG.GetSignal((BlueEvacPressureCDG1000Volts.RawValue / 10 * Config.Pressure.BlueCDG1000FullScale.ProcessValue) + Config.Pressure.BlueCDG1000Offset.ProcessValue);
        }

        private void BlueEvacPressureCDG10Volts_ValueChanged(object sender, EventArgs e)
        {
            BlueEvacPressureCDG10.RawValue = BlueEvacPressureCDG10Volts.RawValue;
            BlueEvacPressureCDG10.Value = MyStaticVariables.Blue10TorrCDG.GetSignal((BlueEvacPressureCDG10Volts.RawValue / 10 * Config.Pressure.BlueCDG10FullScale.ProcessValue) + Config.Pressure.BlueCDG10Offset.ProcessValue);

            try
            {
                if (IO.Signals.BlueEvacPressureCDG10.Value > 9.0)
                {
                    IO.Signals.BluePartVacuum.Value = IO.Signals.BlueEvacPressureCDG1000.Value;
                    IO.Signals.BluePartVacuummTorr.Value = IO.Signals.BlueEvacPressureCDG1000.Value * 1000;
                }
                else
                {
                    IO.Signals.BluePartVacuum.Value = IO.Signals.BlueEvacPressureCDG10.Value;
                    IO.Signals.BluePartVacuummTorr.Value = IO.Signals.BlueEvacPressureCDG10.Value * 1000;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        void BlueLoSideToolPressureBP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IO.Signals.BlueLoSideToolPressure.RawValue = IO.Signals.BlueLoSideToolPressureBP.RawValue;
                IO.Signals.BlueLoSideToolPressure.Value = (IO.Signals.BlueLoSideToolPressure.RawValue - 1.0) / 4.0 * Config.Pressure.BlueCircuit2LoSideToolCheckTransducerFullScale.ProcessValue - Config.Pressure.BlueCircuit2LoSideToolCheckTransducerOffset.ProcessValue;
            }
            catch
            {

            }
        }

        void BlueHiSideToolPressureBP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IO.Signals.BlueHiSideToolPressure.RawValue = IO.Signals.BlueHiSideToolPressureBP.RawValue;
                IO.Signals.BlueHiSideToolPressure.Value = (IO.Signals.BlueHiSideToolPressure.RawValue - 1.0) / 4.0 * Config.Pressure.BlueCircuit2ToolCheckTransducerFullScale.ProcessValue - Config.Pressure.BlueCircuit2ToolCheckTransducerOffset.ProcessValue;
            }
            catch
            {
            }
        }

        void BlueSupplyPressureBP_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                IO.Signals.BlueSupplyPressure.RawValue = IO.Signals.BlueSupplyPressureBP.RawValue;
                IO.Signals.BlueSupplyPressure.Value = (IO.Signals.BlueSupplyPressure.RawValue - 1.0) / 4.0 * Config.Pressure.BlueCircuit2SupplyTransducerFullScale.ProcessValue - Config.Pressure.BlueCircuit2SupplyTransducerOffset.ProcessValue;
            }
            catch
            {
            }
        }


        void WhiteHiSideToolPressure_ValueChanged(object sender, EventArgs e)
        {
            
        }


    }
}
