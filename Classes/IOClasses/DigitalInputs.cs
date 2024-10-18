using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using System.Drawing;


namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// DigitalInputs class
    /// 
    /// Subclass of the IOSubSystemBase
    /// Contains fields for the digital inputs.
    /// Each field is of type IDigitalInput, which is an interface
    /// in the VTIWindowsControlLibrary.  At runtime, the IOSubSystemBase
    /// class constructor locates the digital input in the I/O Interface
    /// that matches the field name.
    /// </summary>
    public class DigitalInputs : IOSubSystemBase<IDigitalInput>
    {
        public DigitalInputs(IOInterface IOInterface)
            : base(IOInterface)
        {
            InitializePorts();
            InitializeInputs();
        }
        //public IDigitalInput AcknowledgeButton1;

        public IDigitalInput MCRPower24VoltSense;

        //public IDigitalInput StandbySwitch;

        public IDigitalInput Acknowledge;

        //public IDigitalInput HighSideEvacPumpOilLevel;
        //public IDigitalInput LowSideEvacPumpOilLevel;

        public IDigitalInput BlueCircuit2FlowmeterFault;

        public IDigitalInput AreaWarningFromCust;
        public IDigitalInput PurgeFlowInlet;
        public IDigitalInput BluePumpEnableSense;
        public IDigitalInput BlueCircuit2FlowmeterCounter;
        public IDigitalInput BlueHeatPumpControlInput;
        //public IDigitalInput WhiteCircuit1FlowmeterFault;

        //public IDigitalInput BlueRecoveryTankFloatSwitch;
        //public IDigitalInput WhiteRecoveryTankFloatSwitch;

        public class DigitalInputPort
        {
            public IDigitalInput Acknowledge;

            public IDigitalInput MCRPower24VoltSense;

            public IDigitalInput FlowmeterFault;

            public IDigitalInput RightPalmButton;

            public IDigitalInput LeftPalmButton;

            public IDigitalInput RecoveryTankFloatSwitch;


        }

        protected DigitalInputPort[] _port;
        public DigitalInputPort[] Port { get { return _port; } }

        protected virtual void InitializePorts()
        {
            if (Properties.Settings.Default.DualPortSystem)
            {
                _port = new DigitalInputPort[2];
                _port[0] = new DigitalInputPort();
                _port[1] = new DigitalInputPort();
            }
            else
            {
                _port = new DigitalInputPort[1];
                _port[0] = new DigitalInputPort();
            }
        }

        protected virtual void InitializeInputs()
        {
            //_port[0].AcknowledgeButton1 = AcknowledgeButton1;
            _port[0].MCRPower24VoltSense = MCRPower24VoltSense;
            //_port[0].LeftPalmButton = LeftPalmButton;
            //_port[0].RightPalmButton = RightPalmButton;
            _port[0].FlowmeterFault = BlueCircuit2FlowmeterFault;
            //_port[0].RecoveryTankFloatSwitch = BlueRecoveryTankFloatSwitch;

            if (Properties.Settings.Default.DualPortSystem)
            {
                //_port[1].AcknowledgeButton1 = AcknowledgeButton1;
                _port[1].MCRPower24VoltSense = MCRPower24VoltSense;
                //_port[1].LeftPalmButton = LeftPalmButton;
                //_port[1].RightPalmButton = RightPalmButton;
                //_port[1].FlowmeterFault = WhiteCircuit1FlowmeterFault;
                //_port[1].RecoveryTankFloatSwitch = WhiteRecoveryTankFloatSwitch;
            }
            MCRPower24VoltSense.ValueChanged += new EventHandler(MCRPower24VoltSense_ValueChanged);
            //StandbySwitch.ValueChanged += StandbySwitch_ValueChanged;
            Acknowledge.ValueChanged += Acknowledge_ValueChanged;

        }

        private void Acknowledge_ValueChanged(object sender, EventArgs e)
        {
            Machine.Cycle[0].bHideMessageBox = true;
            MyStaticVariables.WaitForAcknowledgeFlagBlue = true;
            //Machine.Cycle[1].bHideMessageBox = true;
        }

        void StandbySwitch_ValueChanged(object sender, EventArgs e)
        {
            //if (IO.DIn.StandbySwitch.Value)
            //{
            //    try
            //    {
            //        //System.Diagnostics.Process.Start("shutdown.exe -s -f -t 02");
            //        Process process1 = new Process();

            //        string path = @" C:\Windows\System32";
            //        string shut_args = "-s -f -t 02 ";

                    
            //        process1.StartInfo.FileName = "shutdown.exe";

            //        // choose appropriate arguments from the section ['Shutdown Arguments explained']
            //        // and store the value in shut_args variable
            //        // Fill the shutdown argument 'shut_args' yourselves.
            //        //process1.StartInfo.WorkingDirectory = path;
            //        process1.StartInfo.Arguments = shut_args;

            //        process1.StartInfo.CreateNoWindow = true;
            //        process1.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            //        process1.Start();

            //        process1.WaitForExit(10000);
            //        if (!process1.HasExited)
            //            process1.Kill();
            //        process1.Close();
            //    }
            //    catch (Exception Ex)
            //    {
            //        Console.WriteLine(Ex.Message);
            //    }
            //}
        }

        void MCRPower24VoltSense_ValueChanged(object sender, EventArgs e)
        {
            if (!IO.DIn.MCRPower24VoltSense.Value)
            {
                try
                {
                    if (Machine.Test[0].SerialNumber != "")
                    {
                        //Machine.Cycle[0].UutRecord.TestResult = "ESTOP";
                        Machine.TestHistory[0].AddEntry("ESTOP", Color.Black, Color.Yellow);
                        Machine.Test[0].Result = "ESTOP";
                    }
                    // hide manual commands window
                    //Machine.ManualCommands.Hide();
                    // close all valves
                    IO.DOut.EvacPumpEnable.Disable();
                    IO.DOut.BlueCircuit2HiSideEvac.Disable();
                    IO.DOut.BlueCircuit2HiSideRecovery.Disable();
                    IO.DOut.BlueCircuit2HiSideToolStem.Disable();

                    Machine.Cycle[0].bDisableHiSideCharge = true;
                    Machine.Cycle[0].bDisableLowSideCharge = true;
                    if (Properties.Settings.Default.DualPortSystem)
                    {
                        Machine.Cycle[1].bDisableHiSideCharge = true;
                        Machine.Cycle[1].bDisableLowSideCharge = true;
                    }

                    Machine.ManualCommands.Reset();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                if (Machine.Cycle != null && Machine.Cycle[0] != null)
                {
                    Machine.ManualCommands.Reset();
                }
            }
        }
    }
}
