using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// AnalogInputs class
    /// 
    /// Subclass of the IOSubSystemBase class
    /// Contains fields for the analog inputs.  The Analog Inputs
    /// are the "raw values" (i.e. volts, milliamps, etc)
    /// Each field is of type IAnalogInput, which is an interface
    /// in the VTIWindowsControlLibrary.  At runtime, the IOSubSystemBase
    /// class constructor locates the analog input in the I/O Interface
    /// that matches the field name.
    /// </summary>
    public class AnalogInputs : IOSubSystemBase<IAnalogInput>
    {
        public AnalogInputs(IOInterface IOInterface) : base(IOInterface) { }
        /*
            public IAnalogInput BlueLoRangeVac;
            public IAnalogInput WhiteLoRangeVac;
        */

        public IAnalogInput BlueCircuit2SupplyPressureVolts;
        public IAnalogInput BlueCircuit2HiSideToolPressureVolts;
        public IAnalogInput BlueCircuit2LoSideToolPressureVolts;

        public IAnalogInput BlueCircuit2HiSideCounterVolts;
        public IAnalogInput BlueCircuit2LoSideCounterVolts;

        public IAnalogInput BlueCircuit2HiSideCounterLimitVolts;
        public IAnalogInput BlueCircuit2LoSideCounterLimitVolts;

        public IAnalogInput RefrigerantPPMVolts;
        public IAnalogInput CounterOutputVolts; 

        public IAnalogInput BlueCDG10Volts;
        public IAnalogInput BlueCDG1000Volts; 

        //public IAnalogInput WhiteCircuit1SupplyPressureVolts;
        //public IAnalogInput WhiteCircuit1HiSideToolPressureVolts;




    }
}
