using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.IO.SerialIO;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using System.Windows.Forms;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses
{
    public class SerialInputs
    {
        public AthenaController ZebraPrinter;

        //public TricorFlowmeterController BlueFlowmeterController;

        //public TricorFlowmeterController WhiteFlowmeterController;
        public BarcodeScanner Scanner;

        public SerialInputs()
        {


            Scanner = new BarcodeScanner
            {
                SerialPortParameter = Config.Control.ScannerPort,
            };
            Scanner.SerialPort.ReadTimeout = 1000;
            Scanner.Start();

          //  WhiteEvacPressure.Start();

            //ZebraPrinter = new AthenaController(0, 1000, "K")
            //{
            //    ChannelID = 0,
            //    SerialPortParameter = Config.Control.ZebraPrinterPort
            //};
            //ZebraPrinter.Start();

            //BlueFlowmeterController = new TricorFlowmeterController
            //{
            //    SerialPortParameter=Config.Control.BlueCircuit2FlowmeterPort
            //};

            //BlueFlowmeterController.Start();


            //WhiteFlowmeterController = new TricorFlowmeterController
            //{
            //    SerialPortParameter = Config.Control.WhiteCircuit1FlowmeterPort
            //};

            //WhiteFlowmeterController.Start();

            #region Temperature
            /* temperature
      TemperatureControl = new SoloTempController
      {
        ModbusInterface = RS485Interface,
        SlaveID = (byte)Config.Control.TemperatureControlSlaveID
      };
      TemperatureControl.Start();
      TemperatureControl.OnLineConfigurationEnabled = true;
      TemperatureControl.RunMode = true;
     
      OverTempControl = new SoloTempController
      {
        ModbusInterface = RS485Interface,
        SlaveID = (byte)Config.Control.OverTempControlSlaveID
      };
      OverTempControl.Start();
      OverTempControl.OnLineConfigurationEnabled = true;
      OverTempControl.DigitalInputs.Alarm1.ValueChanged += new EventHandler(AlarmOverTemp_ValueChanged);

      LN2TrapTemperature = new AthenaController(0, 1000, "°K")
      {
        ChannelID = (byte)Config.Control.Athena_Readout_Network_ID.ProcessValue
      };
      try
      {
        LN2TrapTemperature.PortName = Config.Control.LN2TrapTemperature.ProcessValue.PortName;
        LN2TrapTemperature.BaudRate = Config.Control.LN2TrapTemperature.ProcessValue.BaudRate;
        LN2TrapTemperature.Parity = Config.Control.LN2TrapTemperature.ProcessValue.Parity;
        LN2TrapTemperature.DataBits = Config.Control.LN2TrapTemperature.ProcessValue.DataBits;
        LN2TrapTemperature.StopBits = Config.Control.LN2TrapTemperature.ProcessValue.StopBits;
        LN2TrapTemperature.Start();
      }
      catch
      {
        VtiEvent.Log.WriteWarning(String.Format("Unable to open serial port {0} for LN2TrapTemperature", Config.Control.LN2TrapTemperature));
        MessageBox.Show(String.Format("Unable to open serial port {0} for LN2TrapTemperature", Config.Control.LN2TrapTemperature), "VTI_EVAC_AND_DUAL_CHARGE", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    void AlarmOverTemp_ValueChanged(object sender, EventArgs e)
    {
      if (OverTempControl.DigitalInputs.Alarm1.Value && Machine.Cycle[Enums.Port.Blue].TestInProgress)
      {
        Machine.Cycle[Enums.Port.Blue].CycleAbort(Localization.OverTempWarning, Localization.OverTempWarningTH);
        Machine.Cycle[Enums.Port.Blue].OverTemp.Start();
      }
    }
       */
            #endregion
        }
    }
}
