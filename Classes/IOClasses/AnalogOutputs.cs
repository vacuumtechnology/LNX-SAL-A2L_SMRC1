using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.IO.Interfaces;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    /// <summary>
    /// AnalogOutputs class
    /// 
    /// Subclass of the IOSubSystemBase class
    /// Contains fields for the analog inputs.  The Analog Inputs
    /// are the "raw values" (i.e. volts, milliamps, etc)
    /// Each field is of type IAnalogInput, which is an interface
    /// in the VTIWindowsControlLibrary.  At runtime, the IOSubSystemBase
    /// 
    /// class constructor locates the analog input in the I/O Interface
    /// that matches the field name.
    /// </summary>
    public class AnalogOutputs : IOSubSystemBase<IAnalogOutput>
    {
        public AnalogOutputs(IOInterface IOInterface) : base(IOInterface) { }
        /*
            public IAnalogInput BlueLoRangeVac;
            public IAnalogInput WhiteLoRangeVac;
        */

        public IAnalogOutput BlueCircuit2HiSideStartCountValue;
        public IAnalogOutput BlueCircuit2LoSideStartCountValue;

        public IAnalogOutput BlueCircuit2HiSideCountLimit;
        public IAnalogOutput BlueCircuit2LoSideCountLimit; 

        public IAnalogOutput AreaMonitorHighSetpoint;


    }
}
