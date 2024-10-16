using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes.IO.SignalConverters;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{

    public class AnalogSignalConverters
    {

        //public LinearSignal ChamberDiffPressureSigConvert = new LinearSignal
        //{  // With out the sig converter the value change would not fire tas 6/14/12


        //};
        public LinearSignal BlueCDG10VoltsConv = new LinearSignal();
        public LinearSignal BlueCDG1000VoltsConv = new LinearSignal();
        public LinearSignal RefrigerantPPMVoltsConv = new LinearSignal();

        public LinearSignal PartPressureSigConvert = new LinearSignal
        {
            FullScale = 1000.0,
            Offset=0.0,
            InputMinimum=1.0,
            InputMaximum=5.0,
        };

        public LinearSignal PartFlowSigConvert = new LinearSignal
        {
            FullScale=10.0,
            Offset=0.0,
            InputMinimum=1.0,
            InputMaximum=5.0,
        };

        public LinearSignal BlueSupplyPressureSigConvert = new LinearSignal
        {
            FullScale = Config.Pressure.BlueCircuit2SupplyTransducerFullScale.ProcessValue,
            Offset = Config.Pressure.BlueCircuit2SupplyTransducerOffset.ProcessValue,
            InputMinimum = 1.0,
            InputMaximum = 5.0,
        };

        public LinearSignal BlueHiSidePressureSigConvert = new LinearSignal
        {
            FullScale = Config.Pressure.BlueCircuit2ToolCheckTransducerFullScale.ProcessValue,
            Offset = Config.Pressure.BlueCircuit2ToolCheckTransducerOffset.ProcessValue,
            InputMinimum = 1.0,
            InputMaximum = 5.0,
        };

        public LinearSignal BlueLoSidePressureSigConvert = new LinearSignal
        {
            FullScale = Config.Pressure.BlueCircuit2LoSideToolCheckTransducerFullScale.ProcessValue,
            Offset = Config.Pressure.BlueCircuit2LoSideToolCheckTransducerOffset.ProcessValue,
            InputMinimum = 1.0,
            InputMaximum = 5.0,
        };


        public LinearSignal BlueHiSideCounterSigConvert = new LinearSignal
        {
            FullScale=65536,
            Offset=32767,
            InputMinimum=0.0,
            InputMaximum=10.0,
        };

        public LinearSignal BlueLoSideCounterSigConvert = new LinearSignal
        {
            FullScale = 65536,
            Offset = 32767,
            InputMinimum = 0.0,
            InputMaximum = 10.0,
        };

        public LinearSignal BlueHiSideCounterLimitSigConvert = new LinearSignal
        {
            FullScale = 65536,
            Offset = 32767,
            InputMinimum = 0.0,
            InputMaximum = 10.0,
        };

        public LinearSignal BlueLoSideCounterLimitSigConvert = new LinearSignal
        {
            FullScale = 65536,
            Offset = 32767,
            InputMinimum = 0.0,
            InputMaximum = 10.0,
        };


        public LinearSignal CounterOutputSigConvert = new LinearSignal
        {
            FullScale = 20.0,
            Offset = 0.0,
            InputMinimum = 0.0,
            InputMaximum = 10.0,
        };


        public LinearSignal WhiteSupplyPressureSigConvert = new LinearSignal
        {
            FullScale = Config.Pressure.WhiteCircuit1SupplyTransducerFullScale.ProcessValue,
            Offset = Config.Pressure.WhiteCircuit1SupplyTransducerOffset.ProcessValue,
            InputMinimum = 1.0,
            InputMaximum = 5.0,
        };

        public LinearSignal WhiteHiSidePressureSigConvert = new LinearSignal
        {
            FullScale = Config.Pressure.WhiteCircuit1ToolCheckTransducerFullScale.ProcessValue,
            Offset = Config.Pressure.WhiteCircuit1ToolCheckTransducerOffset.ProcessValue,
            InputMinimum = 1.0,
            InputMaximum = 5.0,
        };
        /* More Examples
     
          public LogLinearSignal TurboInletPressure =
          new LogLinearSignal
          {
            LinearFactor = 1.33322, // convert from Torr to mBar
            VoltsPerDecade = 0.6,
            MinExponent = -11.46,
            MaxExponent = 3
          };

        public TorrconSignal TurboOutletPressure =
          new TorrconSignal
          {
            LinearFactor = 1.33322 // convert from Torr to mBar
          };

        public TorrconSignal GetterOutletPressure =
          new TorrconSignal
          {
            LinearFactor = 1.33322 // convert from Torr to mBar
          };

        public TorrconSignal OutletPressure =
          new TorrconSignal
          {
            LinearFactor = 1.33322 // convert from Torr to mBar
          };

        public LinearSignal HiPace80Turbo =
          new LinearSignal
          {
            FullScaleParameter = Config.Control.HiPace80TurboFullScale,
            OffsetParameter = Config.Control.HiPace80TurboOffset,
            InputMinimum = 0,
            InputMaximum = 10
          };
     
            public TorrconSignal BlueConvectronSignalConverter =
              new TorrconSignal { LinearFactor = Config.Pressure.BlueConvectronSpan.ProcessValue / 100 };
            public TorrconSignal WhiteConvectronSignalConverter =
              new TorrconSignal { LinearFactor = Config.Pressure.WhiteConvectronSpan.ProcessValue / 100 };
            public LinearSignal BlueLoPressSignalConverter =
              new LinearSignal
              {
                  FullScaleParameter = Config.Pressure.BlueLoPressFullScale,
                  OffsetParameter = Config.Pressure.BlueLoPressOffset,
                  InputMinimum = 0,
                  InputMaximum = 10
              };
            public LinearSignal WhiteLoPressSignalConverter =
              new LinearSignal
              {
                  FullScaleParameter = Config.Pressure.WhiteLoPressFullScale,
                  OffsetParameter = Config.Pressure.WhiteLoPressOffset,
                  InputMinimum = 0,
                  InputMaximum = 10
              };
        */
    }
}
