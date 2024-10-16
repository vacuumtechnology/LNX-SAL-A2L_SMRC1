using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;
using VTIWindowsControlLibrary.Classes.IO;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// DigitalOutputs class
    /// 
    /// Subclass of the IOSubSystemBase
    /// Contains fields for the digital inputs.
    /// Each field is of type IDigitalOutput, which is an interface
    /// in the VTIWindowsControlLibrary.  At runtime, the IOSubSystemBase
    /// class constructor locates the digital output in the I/O Interface
    /// that matches the field name.
    /// </summary>
    public class DigitalOutputs : IOSubSystemBase<IDigitalOutput>
    {
        // Example Digital Outputs
        //public IDigitalOutput CompHi;
        //public IDigitalOutput CompLo;

        //public IDigitalOutput ConveyorEnable;
        //public IDigitalOutput ComputerRunLatch;

        public IDigitalOutput BlueCircuit2LightStackGreen;
        public IDigitalOutput BlueCircuit2LightStackRed;
        public IDigitalOutput BlueCircuit2LightStackYellow;
        public IDigitalOutput BlueCircuit2Alarm;

        //public IDigitalOutput WhiteCircuit1LightStackGreen;
        //public IDigitalOutput WhiteCircuit1LightStackRed;
        //public IDigitalOutput WhiteCircuit1LightStackYellow;
        //public IDigitalOutput WhiteCircuit1Alarm;

        public IDigitalOutput HighSideRateOfRiseValve;
        public IDigitalOutput BasePressureTestValve;

        //public IDigitalOutput WhiteCircuit1UnitEvac;
        //public IDigitalOutput LowSideRateOfRiseValve;

        //public IDigitalOutput CrossOverValve;

        public IDigitalOutput BlueCircuit2HiSideToolStem;
        public IDigitalOutput BlueCircuit2HiSideEvac;
        //public IDigitalOutput BlueCircuit2BoosterDisable;
        public IDigitalOutput BlueCircuit2HiSideRecovery;

        public IDigitalOutput BlueCircuit2LoSideToolStem;
        public IDigitalOutput BlueCircuit2LoSideEvac;
        //public IDigitalOutput BlueCircuit2RecoveryPumpEnable;
        public IDigitalOutput BlueCircuit2LoSideRecovery;

        public IDigitalOutput BlueCircuit2FlowmeterReset;

        //public IDigitalOutput WhiteCircuit1HiSideToolStem;
        //public IDigitalOutput WhiteCircuit1HiSideEvac;
        ////public IDigitalOutput WhiteCircuit1BoosterDisable;
        //public IDigitalOutput WhiteCircuit1HiSideRecovery;

        //public IDigitalOutput WhiteCircuit1LoSideToolStem;
        //public IDigitalOutput WhiteCircuit1LoSideEvac;
        ////public IDigitalOutput WhiteCircuit1RecoveryPumpEnable;
        //public IDigitalOutput WhiteCircuit1LoSideRecovery;

        //public IDigitalOutput WhiteCircuit1FlowmeterReset;

        //public IDigitalOutput VacuumPumpEnable;
        //public IDigitalOutput HighSideEvacPump;
        //public IDigitalOutput LowSideEvacPump;
        public IDigitalOutput EvacPumpEnable;

        //fake outputs for schematic
        //public IDigitalOutput WhiteCircuit1HiSideCharge;
        //public IDigitalOutput WhiteCircuit1LoSideCharge;
        public IDigitalOutput BlueCircuit2HiSideCharge;
        public IDigitalOutput BlueCircuit2LoSideCharge;
        public IDigitalOutput ReversingValve;

        public class DigitalOutputPort
        {
            public IDigitalOutput AlarmOutput;

            public IDigitalOutput PassGreenLight;
            public IDigitalOutput FailRedLight;
            public IDigitalOutput NoTestYellowLight;

            public IDigitalOutput LeftPassLight;
            public IDigitalOutput LeftFailLight;
            public IDigitalOutput LeftNoTestLight;

            public IDigitalOutput RateOfRiseValve;
            public IDigitalOutput UnitEvac;

            public IDigitalOutput HiSideToolStem;
            public IDigitalOutput HiSideEvac;
            public IDigitalOutput BoosterDisable;
            public IDigitalOutput HiSideRecovery;

            public IDigitalOutput LoSideToolStem;
            public IDigitalOutput LoSideEvac;
            public IDigitalOutput RecoveryPumpEnable;
            public IDigitalOutput LoSideRecovery;

            //fake IO for schematic
            public IDigitalOutput HiSideCharge;
            public IDigitalOutput LoSideCharge;


            public IDigitalOutput ReversingValve;
        }

        protected DigitalOutputPort[] _port;
        public DigitalOutputPort[] Port { get { return _port; } }

        public DigitalOutputs(IOInterface IOInterface)
            : base(IOInterface)
        {
            InitializePorts();
            InitializeOutputs();
        }

        protected virtual void InitializePorts()
        {
            if (Properties.Settings.Default.DualPortSystem)
            {
                _port = new DigitalOutputPort[2];
                _port[0] = new DigitalOutputPort();
                _port[1] = new DigitalOutputPort();
            }
            else
            {
                _port = new DigitalOutputPort[1];
                _port[0] = new DigitalOutputPort();
            }
        }

        protected virtual void InitializeOutputs()
        {
            _port[0].RateOfRiseValve = HighSideRateOfRiseValve;
            _port[0].UnitEvac = BasePressureTestValve;
            _port[0].ReversingValve = ReversingValve;

            //_port[0].BoosterDisable = BlueCircuit2BoosterDisable;
            _port[0].HiSideEvac = BlueCircuit2HiSideEvac;
            _port[0].HiSideRecovery = BlueCircuit2HiSideRecovery;
            _port[0].HiSideToolStem = BlueCircuit2HiSideToolStem;

            //_port[0].RecoveryPumpEnable = BlueCircuit2RecoveryPumpEnable;
            _port[0].LoSideEvac = BlueCircuit2LoSideEvac;
            _port[0].LoSideRecovery = BlueCircuit2LoSideRecovery;
            _port[0].LoSideToolStem = BlueCircuit2LoSideToolStem;

            _port[0].HiSideCharge = BlueCircuit2HiSideCharge;
            _port[0].LoSideCharge = BlueCircuit2LoSideCharge;

            _port[0].PassGreenLight = BlueCircuit2LightStackGreen;
            _port[0].FailRedLight = BlueCircuit2LightStackRed;
            _port[0].NoTestYellowLight = BlueCircuit2LightStackYellow;
            
            _port[0].AlarmOutput = BlueCircuit2Alarm;

            BlueCircuit2HiSideCharge.ValueChanging += BlueCircuit2HiSideCharge_ValueChanging;
            BlueCircuit2HiSideEvac.ValueChanging += BlueCircuit2HiSideEvac_ValueChanging;
            BlueCircuit2LoSideCharge.ValueChanging += BlueCircuit2LoSideCharge_ValueChanging;
            BlueCircuit2LoSideEvac.ValueChanging += BlueCircuit2LoSideEvac_ValueChanging;


            if (Properties.Settings.Default.DualPortSystem)
            {
                _port[1].RateOfRiseValve = HighSideRateOfRiseValve;
                //_port[1].RateOfRiseValve = LowSideRateOfRiseValve;

                ////_port[1].BoosterDisable = WhiteCircuit1BoosterDisable;
                //_port[1].HiSideEvac = WhiteCircuit1HiSideEvac;
                //_port[1].HiSideRecovery = WhiteCircuit1HiSideRecovery;
                //_port[1].HiSideToolStem = WhiteCircuit1HiSideToolStem;

                ////_port[1].RecoveryPumpEnable = WhiteCircuit1RecoveryPumpEnable;
                //_port[1].LoSideEvac = WhiteCircuit1LoSideEvac;
                //_port[1].LoSideRecovery = WhiteCircuit1LoSideRecovery;
                //_port[1].LoSideToolStem = WhiteCircuit1LoSideToolStem;

                //_port[1].HiSideCharge = WhiteCircuit1HiSideCharge;
                //_port[1].LoSideCharge = WhiteCircuit1LoSideCharge;


                //_port[1].PassGreenLight = WhiteCircuit1LightStackGreen;
                //_port[1].FailRedLight = WhiteCircuit1LightStackRed;
                //_port[1].NoTestYellowLight = WhiteCircuit1LightStackYellow;
                //_port[1].AlarmOutput = WhiteCircuit1Alarm;
            }

        }


        void BlueCircuit2HiSideEvac_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        {
            if (e.NewValue && Config.TestMode == Enums.TestModes.Manual)
            {
                if (IO.Signals.BlueHiSideToolPressure.Value > 5)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Evac, Pressure Too High";
                    //return;
                }
                else if (IO.DOut.BlueCircuit2HiSideCharge.Value)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Evac, charge valve is open";
                }
            }
        }

        void BlueCircuit2HiSideCharge_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        {
            if (e.NewValue && Config.TestMode == Enums.TestModes.Manual)
            {
                if (IO.Signals.BlueHiSideToolPressure.Value > -10)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Charge, Port not under vacuum";
                    //return;
                }
                else if (IO.DOut.BlueCircuit2HiSideEvac.Value)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Charge, Evac valve is open";
                }
            }

        }
        void BlueCircuit2LoSideEvac_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        {
            if (e.NewValue && Config.TestMode == Enums.TestModes.Manual)
            {
                if (IO.Signals.BlueLoSideToolPressure.Value > 5)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Evac, Pressure Too High";
                    //return;
                }
                else if (IO.DOut.BlueCircuit2LoSideCharge.Value)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Evac, charge valve is open";
                }
            }
        }

        void BlueCircuit2LoSideCharge_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        {
            if (e.NewValue && Config.TestMode == Enums.TestModes.Manual)
            {
                if (IO.Signals.BlueLoSideToolPressure.Value > -10)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Charge, Port not under vacuum";
                    //return;
                }
                else if (IO.DOut.BlueCircuit2LoSideEvac.Value)
                {
                    e.Cancel = true;
                    e.Reason = "Can't Open Charge, Evac valve is open";
                }
            }

        }



        void SnifferBack_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void SniffingEnable_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void HydraulicPump_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void RoughPumpEnable_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberTestPressurePurgeValve_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void RoughPumpBypassValve_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberTestMassive_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberTestPeek_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberTestFine_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberRoughIso_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberBypass_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberVent_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void SnifferValve_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void VerificationLeak_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ChamberLeak_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void ForelineLeak_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void BlowerEnable_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void BlowerReset_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void AlarmOutput_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void SafetyChamberLatch_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void PassGreenLight_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void FailRedLight_ValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        void NoTestAmberLight_ValueChanged(object sender, EventArgs e)
        {
            Machine.ValvesPanel[VTI_EVAC_AND_SINGLE_CHARGE.Enums.Port.Blue].UpdateValvesPanel();
        }

        void DoorEnable_ValueChanged(object sender, EventArgs e)
        {
            Machine.ValvesPanel[VTI_EVAC_AND_SINGLE_CHARGE.Enums.Port.Blue].UpdateValvesPanel();
        }

        void DoorDirection_ValueChanged(object sender, EventArgs e)
        {
            Machine.ValvesPanel[VTI_EVAC_AND_SINGLE_CHARGE.Enums.Port.Blue].UpdateValvesPanel();
        }

        //void GPTOutletValve_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        //{
        //  if (Config.Mode.DigitalOutputInterlocks)
        //  {
        //    if (e.NewValue)
        //    {
        //      // Don't allow Getter Outlet Valve to open if Outlet Pressure is greater than 
        //      // Config.Pressure.OutletPressureThreshold
        //      if (IO.Signals.OutletPressureSignal.Value > Config.Pressure.OutletPressureThreshold)
        //      {
        //        e.Cancel = true;
        //        e.Reason = String.Format(Localization.GetterOutletValveInterlock, Config.Pressure.OutletPressureThreshold.ProcessValue);
        //      }
        //    }
        //  }
        //}

        //void GPTInletValve_ValueChanging(IDigitalOutput sender, DigitalOutputChangingEventArgs e)
        //{
        //  if (Config.Mode.DigitalOutputInterlocks)
        //  {
        //    if (e.NewValue)
        //    {
        //      // Don't allow Getter Inlet Valve to open if Turbo Outlet Pressure is greater than 
        //      // Config.Pressure.GetterInletPressureThreshold
        //      if (IO.Signals.TurboOutletPressureSignal.Value > Config.Pressure.GetterInletPressureThreshold)
        //      {
        //        e.Cancel = true;
        //        e.Reason = String.Format(Localization.GetterInletValveInterlock, Config.Pressure.GetterInletPressureThreshold.ProcessValue);
        //      }
        //    }
        //  }
        //}
    }
}
