using System;
using System.Windows.Forms;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.ClientForms;
using VTIWindowsControlLibrary.Classes.CycleSteps;
using VTIWindowsControlLibrary.Enums;
using System.Drawing;
//using MccDaq;


namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
	public partial class MainForm : Form
	{
		#region Construction

		public MainForm()
		{
			if(Properties.Settings.Default.DebugMode) MessageBox.Show("Waiting for debugger to attach.  Click OK to continue.", "Debug Mode", MessageBoxButtons.OK);
			VtiEvent.Log.WriteInfo("Initializing Main Form...");
			InitializeComponent();
			timerStatusBar.Interval = (61 - System.DateTime.Now.Second) * 1000;
			timerStatusBar.Enabled = true;
			CurrentTime.Text = System.DateTime.Now.ToShortTimeString();
			CurrentDate.Text = System.DateTime.Now.ToShortDateString();
		}

		#endregion

		#region Properties

		//public StatusStrip statusStrip
		//{
		//    get { return this.statusStrip1; }
		//}

		//public MenuStrip MenuStrip
		//{
		//    get { return menuStrip1; }
		//}

		#endregion

		#region Events

		private void toolStripButtonMeters_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewMeters();
		}

		private void toolStripButtonManualCommands_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewManualCommands();
		}

		private void toolStripButtonEditCycle_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewEditCycle();
		}

		private void toolStripButtonShutdown_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ShutDownApp();
		}

		private void toolStripButtonSystemLog_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewEventViewer();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			VtiEvent.Log.WriteVerbose("Loading Main Form...");

			statusStrip1.Items["SystemID"].Text = Config.Control.System_ID.ProcessValue.ToString();

			if(Properties.Settings.Default.DualPortSystem)
				Machine.OpFormDual.Show();
			else
				Machine.OpFormSingle.Show();

			//Machine.ManualCommands.Logoff();
			Config.TestMode = TestModes.Logoff;
			// Reset Prompt
			Machine.Prompt[0].Clear();
			Machine.Prompt[0].AppendText(Localization.OpLoggedOff + Environment.NewLine + Environment.NewLine);
			Machine.Prompt[0].AppendText(Localization.ScanLogin + Environment.NewLine);

			this.ScannerText.Focus();
			this.ScannerText.BackColor = System.Drawing.Color.GreenYellow;




		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if((e.CloseReason == CloseReason.FormOwnerClosing) ||
				(e.CloseReason == CloseReason.MdiFormClosing) ||
				(e.CloseReason == CloseReason.UserClosing) ||
				(e.CloseReason == CloseReason.None))
			{
				e.Cancel = true;
				Machine.ManualCommands.ShutDownApp();
			}
		}

		private void toolStripButtonDataPlot_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewDataPlot();
		}

		private void toolStripButtonSchematic_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewSchematic();
		}

		private void permissionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewPermissions();
		}

		private void systemPressuresToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewMeters();
		}

		private void manualCommandsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewManualCommands();
		}

		private void systemLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewEventViewer();
		}

		private void editCycleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewEditCycle();
		}

		private void schematicToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void dataPlotToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewDataPlot();
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ShutDownApp();
		}

		#endregion

		private void toolStripButtonDigitalIO_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewDigitalIO();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AboutBox.Show();
		}

		private void timerStatusBar_Tick(object sender, EventArgs e)
		{
			timerStatusBar.Interval = 60000;
			CurrentTime.Text = System.DateTime.Now.ToShortTimeString();
			CurrentDate.Text = System.DateTime.Now.ToShortDateString();
		}

		private void testHistoryToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(Properties.Settings.Default.DualPortSystem)
			{
				// Machine.OpFormDual.TestHistoryDockControl[0].Show();
				//Machine.OpFormDual.TestHistoryDockControl[1].Show();
			}
			else
			{
				Machine.OpFormSingle.TestHistoryDockControl.Show();
			}
		}

		private void toolStripButtonValvesPanel_Click(object sender, EventArgs e)
		{
			// display only one ValvePanel regardless of how many ports are enabled
			if(Properties.Settings.Default.DualPortSystem)
			{
				// if (Machine.OpFormDual.ValvesPanelDockControl[0].Visible)
				// {
				//     Machine.OpFormDual.ValvesPanelDockControl[0].Hide();
				// }
				// else
				// {
				//     Machine.OpFormDual.ValvesPanelDockControl[0].Show();
				// }
			}
			else
			{
				if(Machine.OpFormSingle.ValvesPanelDockControl.Visible)
				{
					Machine.OpFormSingle.ValvesPanelDockControl.Hide();
				}
				else
				{
					Machine.OpFormSingle.ValvesPanelDockControl.Show();
				}
			}
		}

		private void valvesPanelToolStripMenuItem_Click(object sender, EventArgs e)
		{
			toolStripButtonValvesPanel_Click(sender, e);
		}


		//CRC16 calcuation
		private ushort CRC16(ushort crc, ushort data)
		{
			ushort Poly16 = 0xA001;
			ushort LSB, i;
			ushort FFOO = 0xFF00;
			ushort OOFF = 0x00FF;
			ushort OOO1 = 0x0001;
			ushort lOOO = 0x1000;
			crc = (ushort)((ushort)((ushort)(crc ^ data) | FFOO) & (ushort)(crc | OOFF));
			for(i = 0; i < 8; i++)
			{
				LSB = (ushort)(crc & OOO1);
				crc = (ushort)(crc / 2);
				if(LSB >= (ushort)0x1)
				{
					crc = (ushort)(crc ^ Poly16);
				}
			}
			return (crc);
		}



		private void timerSlidePanels_Tick(object sender, EventArgs e)
		{

			IO.AOut.AreaMonitorHighSetpoint.Value = Convert.ToDouble(Config.Control.AreaMonitorHighLevelAlarm.ProcessValue) / 3276.8;

			if(IO.DIn.PurgeFlowInlet.Value || !Config.Mode.A2LRefrigerantMode.ProcessValue)
			{
				if(Machine.Cycle[0].PurgeOffPrompt.State == CycleStepState.InProcess)
					Machine.Cycle[0].PurgeOffPrompt.Pass();
			}
			else
			{
				if(Config.Mode.A2LRefrigerantMode.ProcessValue)
				{
					if(Machine.Cycle[0].PurgeOffPrompt.State != CycleStepState.InProcess)
						Machine.Cycle[0].PurgeOffPrompt.Start();
					MyStaticVariables.ReadyToTest = false;

				}
			}

			if(IO.Signals.RefrigerantPPM.Value > Config.Control.AreaMonitorHighLevelAlarm.ProcessValue)
			{
				if(Machine.Cycle[0].RefrigerantPPMHighWarning.State != CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMHighWarning.Start();
				if(Machine.Cycle[0].RefrigerantPPMLowWarning.State == CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMLowWarning.Pass();
				MyStaticVariables.ReadyToTest = false;
			}
			else if(IO.Signals.RefrigerantPPM.Value > Config.Control.AreaMonitorLowLevelAlarm.ProcessValue)
			{
				if(Machine.Cycle[0].RefrigerantPPMHighWarning.State == CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMHighWarning.Pass();
				if(Machine.Cycle[0].RefrigerantPPMLowWarning.State != CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMLowWarning.Start();
			}
			else
			{
				if(Machine.Cycle[0].RefrigerantPPMHighWarning.State == CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMHighWarning.Pass();
				if(Machine.Cycle[0].RefrigerantPPMLowWarning.State == CycleStepState.InProcess) Machine.Cycle[0].RefrigerantPPMLowWarning.Pass();
			}

			if(!IO.DIn.AreaWarningFromCust.Value)
			{
				if(Machine.Cycle[0].AreaWarningPrompt.State == CycleStepState.InProcess) Machine.Cycle[0].AreaWarningPrompt.Pass();

			}
			else
			{
				if(Machine.Cycle[0].AreaWarningPrompt.State != CycleStepState.InProcess) Machine.Cycle[0].AreaWarningPrompt.Start();
				MyStaticVariables.ReadyToTest = false;

			}

			if (Machine.Cycle[Port.Blue].bDisplaySleepDiagnosticsForm == true)
			{
				Machine.Cycle[Port.Blue].bDisplaySleepDiagnosticsForm = false;
				Machine.ManualCommands.DisplaySleepDiagnosticsForm();
			}
			if (Machine.Cycle[Port.Blue].bHideSleepDiagnosticsForm == true)
			{
				Machine.Cycle[Port.Blue].bHideSleepDiagnosticsForm = false;
				Machine.ManualCommands.HideSleepDiagnosticsForm();
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertbasePressCheck1Data == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertbasePressCheck1Data = false;
				Machine.SleepDiagnosticsForm.InsertInitialBasePressCheckData(0, MyStaticVariables.SleepDiagnosticVar[0].InitialBasePressureCheckTime, MyStaticVariables.SleepDiagnosticVar[0].InitialBasePressureCheckPressure);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertSystemEvacData == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertSystemEvacData = false;
				Machine.SleepDiagnosticsForm.InsertSystemEvacutionData(0, MyStaticVariables.SleepDiagnosticVar[0].SystemEvacuationTimeInHr, MyStaticVariables.SleepDiagnosticVar[0].SystemEvacuationPressure);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertBasePressCheck2Data == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertBasePressCheck2Data = false;
				Machine.SleepDiagnosticsForm.InsertFinalBasePressCheckData(0, MyStaticVariables.SleepDiagnosticVar[0].FinalBasePressureCheckTime, MyStaticVariables.SleepDiagnosticVar[0].FinalBasePressureCheckPressure);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORtoHosesOnGunsData == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORtoHosesOnGunsData = false;
				MyStaticVariables.SleepDiagnosticVar[0].ROR1Initialtime = MyStaticVariables.SleepDiagnosticVar[0].RORToHoseOnGunsCalcStartTime.ToString("hh:mm tt");
				MyStaticVariables.SleepDiagnosticVar[0].ROR1Finaltime = MyStaticVariables.SleepDiagnosticVar[0].RORToHoseOnGunsCalcEndTime.ToString("hh:mm tt");
				double ror1 = (MyStaticVariables.SleepDiagnosticVar[0].ROR1FinalPressure - MyStaticVariables.SleepDiagnosticVar[0].ROR1InitialPressure) / ((MyStaticVariables.SleepDiagnosticVar[0].RORToHoseOnGunsCalcEndTime - MyStaticVariables.SleepDiagnosticVar[0].RORToHoseOnGunsCalcStartTime).TotalMinutes);
				Color color1 = (ror1 > Config.Flow.SleepDiagnosticMaxROR.ProcessValue) ? Color.Red : Color.DarkGreen;
				Machine.SleepDiagnosticsForm.InsertRORtoHosesOnGunsData(0, MyStaticVariables.SleepDiagnosticVar[0].ROR1Initialtime, MyStaticVariables.SleepDiagnosticVar[0].ROR1InitialPressure, MyStaticVariables.SleepDiagnosticVar[0].ROR1Finaltime, MyStaticVariables.SleepDiagnosticVar[0].ROR1FinalPressure, ror1, color1);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRepeatEvac1Data == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRepeatEvac1Data = false;
				Machine.SleepDiagnosticsForm.InsertRepeatEvac1Data(0, MyStaticVariables.SleepDiagnosticVar[0].RepeatEvac1Time, MyStaticVariables.SleepDiagnosticVar[0].RepeatEvac1Pressure);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORtoGunsData == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORtoGunsData = false;
				if (!MyStaticVariables.SleepDiagnosticVar[0].RORToHoseOnGunsStarted) Machine.SleepDiagnosticsForm.ClearRORtoHosesOnGunsData(0);
				MyStaticVariables.SleepDiagnosticVar[0].ROR2Initialtime = MyStaticVariables.SleepDiagnosticVar[0].RORToGunsCalcStartTime.ToString("hh:mm tt");
				MyStaticVariables.SleepDiagnosticVar[0].ROR2Finaltime = MyStaticVariables.SleepDiagnosticVar[0].RORToGunsCalcEndTime.ToString("hh:mm tt");
				double ror1 = (MyStaticVariables.SleepDiagnosticVar[0].ROR2FinalPressure - MyStaticVariables.SleepDiagnosticVar[0].ROR2InitialPressure) / ((MyStaticVariables.SleepDiagnosticVar[0].RORToGunsCalcEndTime - MyStaticVariables.SleepDiagnosticVar[0].RORToGunsCalcStartTime).TotalMinutes);
				Color color1 = (ror1 > Config.Flow.SleepDiagnosticMaxROR.ProcessValue) ? Color.Red : Color.DarkGreen;
				Machine.SleepDiagnosticsForm.InsertRORtoGunsData(0, MyStaticVariables.SleepDiagnosticVar[0].ROR2Initialtime, MyStaticVariables.SleepDiagnosticVar[0].ROR2InitialPressure, MyStaticVariables.SleepDiagnosticVar[0].ROR2Finaltime, MyStaticVariables.SleepDiagnosticVar[0].ROR2FinalPressure, ror1, color1);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRepeatEvac2Data == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRepeatEvac2Data = false;
				Machine.SleepDiagnosticsForm.InsertRepeatEvac2Data(0, MyStaticVariables.SleepDiagnosticVar[0].RepeatEvac2Time, MyStaticVariables.SleepDiagnosticVar[0].RepeatEvac2Pressure);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORwithoutGunsData == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertRORwithoutGunsData = false;
				MyStaticVariables.SleepDiagnosticVar[0].ROR3Initialtime = MyStaticVariables.SleepDiagnosticVar[0].RORWithoutGunsCalcStartTime.ToString("hh:mm tt");
				MyStaticVariables.SleepDiagnosticVar[0].ROR3Finaltime = MyStaticVariables.SleepDiagnosticVar[0].RORWithoutGunsCalcEndTime.ToString("hh:mm tt");
				double ror1 = (MyStaticVariables.SleepDiagnosticVar[0].ROR3FinalPressure - MyStaticVariables.SleepDiagnosticVar[0].ROR3InitialPressure) / ((MyStaticVariables.SleepDiagnosticVar[0].RORWithoutGunsCalcEndTime - MyStaticVariables.SleepDiagnosticVar[0].RORWithoutGunsCalcStartTime).TotalMinutes);
				Color color1 = (ror1 > Config.Flow.SleepDiagnosticMaxROR.ProcessValue) ? Color.Red : Color.DarkGreen;
				Machine.SleepDiagnosticsForm.InsertRORWithoutGunsData(0, MyStaticVariables.SleepDiagnosticVar[0].ROR3Initialtime, MyStaticVariables.SleepDiagnosticVar[0].ROR3InitialPressure, MyStaticVariables.SleepDiagnosticVar[0].ROR3Finaltime, MyStaticVariables.SleepDiagnosticVar[0].ROR3FinalPressure, ror1, color1);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertResult == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertResult = false;
				Machine.SleepDiagnosticsForm.InsertResultData(0, MyStaticVariables.SleepDiagnosticVar[0].Result);
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticinsertDate == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticinsertDate = false;
				Machine.SleepDiagnosticsForm.SetDate(0, DateTime.Now.ToString("MM/dd/yy"));
			}
			if (Machine.Cycle[Port.Blue].bsleepDiagnosticClearForm == true)
			{
				Machine.Cycle[Port.Blue].bsleepDiagnosticClearForm = false;
				Machine.SleepDiagnosticsForm.ClearBlue();
			}

			try
			{
				if(Machine.Cycle[Port.Blue].bScannerTextSetFocusOnce)
				{
					Machine.Cycle[Port.Blue].bScannerTextSetFocusOnce = false;
					this.ScannerText.Focus();
					this.ScannerText.BackColor = System.Drawing.Color.GreenYellow;
				}
				else this.ScannerText.BackColor = System.Drawing.Color.WhiteSmoke;
			}
			catch
			{

			}


			byte[] dataByte;
			dataByte = new Byte[50];

			byte[] InputData;
			InputData = new Byte[500];

			Int16 ModbusAddress;
			Int16 NUMDATA;
			Int16 ii;
			UInt16 Crc;
			Byte Crc_LByte;
			Byte Crc_HByte;

			//if (Config.Mode.ScaleEnabled.ProcessValue)
			//{
			//    if (MyStaticVariables.ReadTheScaleFlag)
			//    {
			//        TimeSpan ScaleReadDelay = DateTime.Now - MyStaticVariables.ScaleWriteTime;
			//        if (ScaleReadDelay.TotalSeconds > 0.5)
			//        {
			//          if (Config.Mode.UseHardyScale.ProcessValue) 
			//          {
			//            //read the data back, then write a new command
			//            try 
			//            {
			//              int BytesToRead = Machine.Scale.BytesToRead;

			//              if (BytesToRead>0) 
			//              {
			//                //convert data
			//                Machine.Scale.Read(InputData, 0, BytesToRead);

			//                IO.Signals.ScaleWeight.Value = (double)BitConverter.ToSingle(new byte[] { InputData[20], InputData[19], InputData[18], InputData[17] }, 0);
			//                IO.Signals.ScaleWeight.Value = IO.Signals.ScaleWeight.Value - Config.Control.ScaleWeightOffset; 

			//                //write a new command
			//                //Gross Weight Address 0x6082 command 03 read holding registers
			//                dataByte[0] = 0x01;
			//                dataByte[1] = 0x04;// 0x03;

			//                ModbusAddress = 0x05;//0x6082;

			//                dataByte[2] = (byte)(((ushort)ModbusAddress & (ushort)0xFF00) / ((ushort)256));
			//                dataByte[3] = (byte)((ushort)ModbusAddress & (ushort)0x00FF);

			//                dataByte[4] = 0x00;
			//                dataByte[5] = 0x0A;

			//                NUMDATA = 6;

			//                Crc = (ushort)0xFFFF;

			//                for (ii = 0; ii < NUMDATA; ii++)
			//                {
			//                  Crc = CRC16(Crc, dataByte[ii]);
			//                }

			//                Crc_LByte = (byte)(Crc & (ushort)0x00FF);
			//                Crc_HByte = (byte)((Crc & (ushort)0xFF00) / ((ushort)256));

			//                dataByte[NUMDATA] = Crc_LByte;
			//                dataByte[NUMDATA + 1] = Crc_HByte;

			//                Machine.Scale.DiscardInBuffer();
			//                Machine.Scale.Write(dataByte, 0, NUMDATA + 2);
			//                MyStaticVariables.ScaleWriteTime = DateTime.Now;
			//                MyStaticVariables.ReadTheScaleFlag = true;
			//              }
			//              else 
			//              {
			//                MyStaticVariables.ReadTheScaleFlag = false;
			//              }
			//            }
			//            catch (Exception Ex) {
			//              Console.WriteLine(Ex.Message);
			//              MyStaticVariables.ReadTheScaleFlag = false;
			//            }

			//          }
			//          else 
			//          {
			//            try {
			//              string TempString = Machine.Scale.ReadExisting();

			//              if (TempString != "") {
			//                TempString = TempString.Substring(0, TempString.IndexOf(" "));
			//                IO.Signals.ScaleWeight.Value = Convert.ToDouble(TempString);

			//                Machine.Scale.DiscardInBuffer();
			//                Machine.Scale.WriteLine("~*P*~");
			//                MyStaticVariables.ScaleWriteTime = DateTime.Now;
			//                MyStaticVariables.ReadTheScaleFlag = true;
			//              }
			//              else {
			//                MyStaticVariables.ReadTheScaleFlag = false;
			//              }
			//            }
			//            catch (Exception Ex) {
			//              Console.WriteLine(Ex.Message);
			//              MyStaticVariables.ReadTheScaleFlag = false;
			//            }
			//          }
			//        }
			//    }
			//    else
			//    {
			//      if (Config.Mode.UseHardyScale.ProcessValue) 
			//      {
			//        try
			//        {
			//          //write only
			//          //Gross Weight Address 0x6082 command 03 read holding registers
			//          dataByte[0] = 0x01;
			//          dataByte[1] = 0x04;// 0x03;

			//          ModbusAddress = 0x05;// 0x6082;

			//          dataByte[2] = (byte)(((ushort)ModbusAddress & (ushort)0xFF00) / ((ushort)256));
			//          dataByte[3] = (byte)((ushort)ModbusAddress & (ushort)0x00FF);

			//          dataByte[4] = 0x00;
			//          dataByte[5] = 0x0A;

			//          NUMDATA = 6;

			//          Crc = (ushort)0xFFFF;

			//          for (ii = 0; ii < NUMDATA; ii++)
			//          {
			//            Crc = CRC16(Crc, dataByte[ii]);
			//          }

			//          Crc_LByte = (byte)(Crc & (ushort)0x00FF);
			//          Crc_HByte = (byte)((Crc & (ushort)0xFF00) / ((ushort)256));

			//          dataByte[NUMDATA] = Crc_LByte;
			//          dataByte[NUMDATA + 1] = Crc_HByte;

			//          Machine.Scale.DiscardInBuffer();
			//          Machine.Scale.Write(dataByte, 0, NUMDATA + 2);

			//          //Machine.Scale.DiscardInBuffer();
			//          //Machine.Scale.WriteLine("~*P*~");
			//          MyStaticVariables.ScaleWriteTime = DateTime.Now;
			//          MyStaticVariables.ReadTheScaleFlag = true;
			//        }
			//        catch (Exception Ex)
			//        {
			//          Console.WriteLine(Ex.Message);
			//          MyStaticVariables.ReadTheScaleFlag = false;

			//        }
			//      }
			//      else 
			//      {
			//        try {
			//          Machine.Scale.DiscardInBuffer();
			//          Machine.Scale.WriteLine("~*P*~");
			//          MyStaticVariables.ScaleWriteTime = DateTime.Now;
			//          MyStaticVariables.ReadTheScaleFlag = true;
			//        }
			//        catch (Exception Ex) {
			//          Console.WriteLine(Ex.Message);
			//          MyStaticVariables.ReadTheScaleFlag = false;

			//        }
			//      }
			//    }
			//}

			try
			{
				if(IO.DIn.Acknowledge.Value && !MyStaticVariables.LastAcknowledgeValue)
				{
					MyStaticVariables.WaitForAcknowledgeFlagBlue = true;
					MyStaticVariables.WaitForAcknowledgeFlagWhite = true;
				}
				MyStaticVariables.LastAcknowledgeValue = IO.DIn.Acknowledge.Value;
			}
			catch
			{
			}

			if(Machine.Cycle[0].bSetHorizotalSplitter)
			{
				Machine.Cycle[0].bSetHorizotalSplitter = false;
				Machine.OpFormSingle.splitContainer1.SplitterDistance = (int)Config.Control.HorizontalSplitterLocation.ProcessValue;
			}
			if(Machine.Cycle[0].bSetVerticalSplitter)
			{
				Machine.Cycle[0].bSetVerticalSplitter = false;
				Machine.OpFormSingle.splitContainer2.SplitterDistance = (int)Config.Control.VerticalSplitterLocation.ProcessValue;
			}

			if(Machine.Cycle[Port.Blue].bStartDataPlot)
			{
				Machine.Cycle[Port.Blue].bStartDataPlot = false;
				Machine.OpFormSingle.DataPlot.Settings.XMax = 300F;
				Machine.OpFormSingle.DataPlot.Settings.YMax = (float)Machine.Test[Port.Blue].FinalEvacSetpoint * 2.0F;
				Machine.OpFormSingle.DataPlot.Settings.YMin = 0.0F;
				Machine.OpFormSingle.DataPlot.Settings.DataCollectionInterval = 0.25F;
				if(Config.Mode.UndockDataPlot)
				{
					Machine.OpFormSingle.DataPlotDockControl.ShowUndocked();
					//Machine.OpFormSingle.DataPlotDockControl.Left = 0;
					//Machine.OpFormSingle.DataPlotDockControl.Top = 0;
					//Machine.OpFormSingle.DataPlot.Left = 0;
					//Machine.OpFormSingle.DataPlot.Top = 0;
					//Machine.OpFormSingle.DataPlotDockControl.Width = 1000;
					//Machine.OpFormSingle.DataPlotDockControl.Height = 1000;
					//Machine.OpFormSingle.DataPlot.Width = 1000;
					//Machine.OpFormSingle.DataPlot.Height = 1000;
					Machine.OpFormSingle.DataPlotDockControl.UndockFrameLocation = new System.Drawing.Point { X = 0, Y = 0 };
					Machine.OpFormSingle.DataPlotDockControl.UndockFrame.Width = 700;
					Machine.OpFormSingle.DataPlotDockControl.UndockFrame.Height = 700;
				}
				Machine.Test[0].DataPlotStartTime = IO.Signals.BlueElapsedTime.Value;

				if(Config.Mode.UseCDGForTest.ProcessValue)
				{
					try
					{
						if(Config.Mode.ProductionModePlot.ProcessValue)
						{
							for(int i = 0; i <= 13; i++)
							{
								if((i == 0) || (i == 5) || (i == 6))
								{
									Machine.DataPlot[0].Traces[i].Visible = true;
								}
								else
								{
									Machine.DataPlot[0].Traces[i].Visible = false;
								}
							}
						}
					}
					catch(Exception ex)
					{
						Console.WriteLine(ex.Message);
					}

				}
				Machine.OpFormSingle.DataPlot.Start();
			}
			if(Machine.Cycle[Port.Blue].bFinalEvacLimitsForDataPlot)
			{
				Machine.Cycle[Port.Blue].bFinalEvacLimitsForDataPlot = false;

				Machine.OpFormSingle.DataPlot.Settings.XMax = (float)((IO.Signals.BlueElapsedTime.Value - Machine.Test[0].DataPlotStartTime) + Machine.Test[0].FinalEvacTimeForPlot);
			}
			if(Machine.Cycle[Port.Blue].bRORLimitsForDataPlot)
			{
				Machine.OpFormSingle.DataPlot.Settings.YMax = (float)Machine.Test[Port.Blue].RORSetpoint * 2.0F;
				Machine.OpFormSingle.DataPlot.Settings.XMax = (float)((IO.Signals.BlueElapsedTime.Value - Machine.Test[0].DataPlotStartTime) + Machine.Test[0].RORDelayTimeForPlot);



				Machine.Cycle[Port.Blue].bRORLimitsForDataPlot = false;

			}
			if(Machine.Cycle[Port.Blue].bChargeLimitsForDataPlot)
			{
				Machine.Cycle[Port.Blue].bChargeLimitsForDataPlot = false;
				Machine.OpFormSingle.DataPlot.Settings.YMax = (float)MyStaticVariables.TotalCharge / 16.0F * 1.5F;
				//Machine.OpFormSingle.DataPlotDockControl.ShowDocked();
			}
			if(Machine.Cycle[Port.Blue].bDockTheDataPlot)
			{
				Machine.Cycle[Port.Blue].bDockTheDataPlot = false;
				Machine.OpFormSingle.DataPlotDockControl.ShowDocked();

			}

			if(Machine.Cycle[Port.Blue].bStopDataPlot)
			{
				Machine.Cycle[Port.Blue].bStopDataPlot = false;
				Machine.OpFormSingle.DataPlotDockControl.ShowDocked();
				Machine.OpFormSingle.DataPlot.Stop();

			}

			if(Machine.Cycle[Port.Blue].bShowMessageInvalidPassword)
			{
				Machine.Cycle[Port.Blue].bShowMessageInvalidPassword = false;

				string TempText = Localization.InvalidPassword + ": " + MyStaticVariables.MessageBoxInvalidText;

				Machine.Message.textBox1.Text = TempText;

				Machine.ManualCommands.ShowMessageForm();

			}

			if(Machine.Cycle[Port.Blue].bShowMessageInvalidSerialNumber)
			{
				Machine.Cycle[Port.Blue].bShowMessageInvalidSerialNumber = false;

				string TempText = ": " + MyStaticVariables.MessageBoxInvalidText;

				Machine.Message.textBox1.Text = TempText;

				Machine.ManualCommands.ShowMessageForm();

			}

			if(Machine.Cycle[Port.Blue].bShowMessageForm)
			{
				Machine.Message.buttonOK.ForeColor = System.Drawing.Color.Black;
				Machine.Message.buttonOK.Text = "AKCNOWLEDGE";
				Machine.Cycle[Port.Blue].bShowMessageForm = false;
				Machine.Test[Port.Blue].MessageBoxFlag = true;
				Machine.Message.textBox1.BackColor = System.Drawing.Color.White;
				Int32 Pounds = Convert.ToInt32(MyStaticVariables.TotalCharge / 16.0 - 0.5);
				Int32 Ounces = Convert.ToInt32(MyStaticVariables.TotalCharge) - Pounds * 16;
				if(Ounces > 15)
				{
					Ounces = 0;
					Pounds = Pounds + 1;
				}

				//Machine.Message.textBox1.Text = string.Format("Serial Number = {0} , Model Number = {1} , Charge Weight = {2:0} lbs {3:0} oz", MyStaticVariables.MessageSerialNumber, MyStaticVariables.MessageModelNumber, Pounds,Ounces);
				//string TempText;
				Machine.Message.textBox1.Clear();


				//TempText = string.Format("Serial Number = {0} , Model Number = {1} , Charge Weight = {2:0} lbs {3:0} oz", MyStaticVariables.MessageSerialNumber, MyStaticVariables.MessageModelNumber, Pounds, Ounces);
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Refrigerant Type = {0}", MyStaticVariables.MessageRefrigerantType));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Refrigerant Name = {0}", MyStaticVariables.MessageRefrigerantName));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Serial Number = {0}", MyStaticVariables.MessageSerialNumber));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Model Number = {0}", MyStaticVariables.MessageModelNumber));
				//****mdb10/28/17
				if(Config.CurrentModel[0].CoilType.ProcessValue.ToUpper().Contains("C"))
				{
					Machine.Message.textBox1.AppendText(Environment.NewLine + "COPPER COIL");
				}
				else if(Config.CurrentModel[0].CoilType.ProcessValue.ToUpper().Contains("A"))
				{
					Machine.Message.textBox1.AppendText(Environment.NewLine + "ALUMINIUM COIL");
				}
				//****mdb10/28/17

				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Charge Weight = {0:0} lbs {1:0} oz", Pounds, Ounces));


				//Machine.Message.textBox1.Text = TempText;// string.Format("Serial Number = {0} , Model Number = {1} , Charge Weight = {2:0} lbs {3:0} oz", MyStaticVariables.MessageSerialNumber, MyStaticVariables.MessageModelNumber, Pounds, Ounces);
				//Machine.Message.textBox1.AppendText(Environment.NewLine + "IS THIS A NEW LINE?");
				//Machine.Message.textBox1.AppendText(Environment.NewLine + "ANOTHER?");

				Machine.Message.buttonAccept.Select();
				Machine.ManualCommands.ShowMessageForm();
			}

			if(Machine.Cycle[Port.Blue].bShowMessageCloseLiquidValve)
			{
				Machine.Cycle[Port.Blue].bShowMessageCloseLiquidValve = false;
				Machine.Test[Port.Blue].MessageBoxFlag = true;

				Machine.Message.textBox1.BackColor = System.Drawing.Color.White;
				Machine.Message.textBox1.ForeColor = System.Drawing.Color.Black;

				Machine.Message.buttonOK.Text = "ACKNOWLEDGE";
				Machine.Message.textBox1.Text = Machine.Test[0].MessageFormText;

				Machine.Message.buttonAccept.Select();
				Machine.ManualCommands.ShowMessageForm();

			}

			if(Machine.Cycle[Port.Blue].bShowMessageFinalData)
			{
				Machine.Cycle[Port.Blue].bShowMessageFinalData = false;
				Machine.Test[Port.Blue].MessageBoxFlag = true;

				if(MyStaticVariables.PassedFlag)
				{
					Machine.Message.textBox1.BackColor = System.Drawing.Color.LightGreen;
				}
				else
				{
					Machine.Message.textBox1.BackColor = System.Drawing.Color.LightPink;
				}
				Machine.Message.textBox1.ForeColor = System.Drawing.Color.Black;

				if(Config.Mode.ChangeFinalFormAckButton.ProcessValue)
				{
					Machine.Message.buttonOK.ForeColor = System.Drawing.Color.HotPink;
					Machine.Message.buttonOK.Text = "VALVES CLOSED";
				}
				else
				{
					Machine.Message.buttonOK.ForeColor = System.Drawing.Color.Black;
					Machine.Message.buttonOK.Text = "AKCNOWLEDGE";
				}


				Int32 PoundsTotalCharge = Convert.ToInt32(MyStaticVariables.TotalCharge / 16.0 - 0.5);
				Int32 OuncesTotalCharge = Convert.ToInt32(MyStaticVariables.TotalCharge) - PoundsTotalCharge * 16;
				if(OuncesTotalCharge > 15)
				{
					OuncesTotalCharge = 0;
					PoundsTotalCharge = PoundsTotalCharge + 1;
				}

				Int32 PoundsActualCharge = Convert.ToInt32(MyStaticVariables.ActualCharge / 16.0 - 0.5);
				//Double OuncesActualCharge = Convert.ToInt32(MyStaticVariables.ActualCharge) - PoundsActualCharge * 16;
				Double OuncesActualCharge = MyStaticVariables.ActualCharge - Convert.ToDouble(PoundsActualCharge) * 16.0;

				if(OuncesActualCharge > 15.99)
				{
					OuncesActualCharge = 0.0;
					PoundsActualCharge = PoundsActualCharge + 1;
				}

				Machine.Message.textBox1.Clear();
				Machine.Message.textBox1.AppendText(Config.Control.PostChargeOperatorInstruction.ProcessValue);
				Machine.Message.textBox1.AppendText(Environment.NewLine + Environment.NewLine + string.Format("Serial Number = {0}", MyStaticVariables.MessageSerialNumber));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Model Number = {0}", MyStaticVariables.MessageModelNumber));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Target Charge Weight = {0:0} lbs {1:0} oz", PoundsTotalCharge, OuncesTotalCharge));
				Machine.Message.textBox1.AppendText(Environment.NewLine + string.Format("Actual Charge Weight = {0:0} lbs {1:0.00} oz", PoundsActualCharge, OuncesActualCharge));
				//string.Format("Serial Number = {0} , Model Number = {1} , Target Charge Weight = {2:0} lbs {3:0} oz, Actual Charge Weight = {4:0} lbs {5:0.00} oz", MyStaticVariables.MessageSerialNumber, MyStaticVariables.MessageModelNumber, PoundsTotalCharge, OuncesTotalCharge, PoundsActualCharge, OuncesActualCharge);

				Machine.Message.buttonAccept.Select();
				Machine.ManualCommands.ShowMessageForm();
			}

			if(Machine.Cycle[Port.Blue].bDisplayFlowmeterCalibration == true)
			{
				Machine.Cycle[Port.Blue].bDisplayFlowmeterCalibration = false;
				Machine.ManualCommands.DisplayFlowmeterCalibration();
			}
			if(Machine.Cycle[Port.Blue].bManualMode == true)
			{
				//IO.DOut.ConveyorEnable.Disable();

				Machine.Cycle[Port.Blue].bManualMode = false;
				Config.TestMode = TestModes.Manual;
				Machine.Cycle[0].Reset.Start();
				if(Properties.Settings.Default.DualPortSystem)
				{
					Machine.Cycle[1].Reset.Start();
				}
			}
			if(Machine.Cycle[Port.Blue].bUpdateLanguage == true)
			{
				Machine.Cycle[Port.Blue].bUpdateLanguage = false;

				switch(Config.Control.Language.ProcessValue)
				{
					case Languages.English:
						System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.EnglishCulture;
						//Program.MainForm.EnglishButton.Checked = true;
						//Program.MainForm.SpanishButton.Checked = false;
						break;

					case Languages.Spanish:
						System.Threading.Thread.CurrentThread.CurrentUICulture = Machine.SpanishCulture;
						//Program.MainForm.EnglishButton.Checked = false;
						//Program.MainForm.SpanishButton.Checked = true;
						break;
				}

				for(int i = 0; i < (Properties.Settings.Default.DualPortSystem ? 2 : 1); i++)
				{
					// Reset sequence step text
					Machine.Cycle[i].ReadyForSequence.Sequence.Text = Localization.SeqReadyForSequence;
					Machine.Cycle[i].HiSideToolCheck.Sequence.Text = Localization.SeqHiSideToolCheck;
					Machine.Cycle[i].LowSideToolCheck.Sequence.Text = Localization.SeqLoSideToolCheck;
					Machine.Cycle[i].FinalEvac.Sequence.Text = Localization.SeqFinalEvac;
					Machine.Cycle[i].RateOfRise.Sequence.Text = Localization.SeqRORCheck;
					Machine.Cycle[i].HiSideCharge.Sequence.Text = Localization.SeqChargeHiSide;
					Machine.Cycle[i].LowSideCharge.Sequence.Text = Localization.SeqChargeLoSide;
					Machine.Cycle[i].ToolDrainDelay.Sequence.Text = Localization.SeqToolDrain;
					Machine.Cycle[i].InsertValveCores.Sequence.Text = Localization.SeqInsertValveCores;
					Machine.Cycle[i].ChargeHoseChargeToolRecovery.Sequence.Text = Localization.SeqChargeHoseChargeToolRecovery;

					// Reset step prompts
					foreach(CycleStep step in Machine.Cycle[i].CycleSteps)
					{
						if(!string.IsNullOrEmpty(Machine.LocalizationResource.GetString(step.Name + "_Prompt")))
						{
							step.Prompt = Machine.LocalizationResource.GetString(step.Name + "_Prompt");
						}
						else
						{
							if(!string.IsNullOrEmpty(Machine.LocalizationResource.GetString(step.Name + "Prompt")))
							{
								step.Prompt = Machine.LocalizationResource.GetString(step.Name + "Prompt");
							}
						}
					}
					Machine.Cycle[i].NotEnergized.Color = System.Drawing.Color.Red;
					Machine.Cycle[i].WaitForAcknowledge.Color = System.Drawing.Color.Red;
					Machine.Cycle[i].LowOilWarning.Color = System.Drawing.Color.Red;
					Machine.Cycle[i].LowRefPressureWarning.Color = System.Drawing.Color.Red;

					//Machine.PortNames = new StringCollection();
					//Machine.PortNames.Add(Localization.LeftPort);
					//Machine.PortNames.Add(Localization.RightPort);
					//Machine.OpForm.SetPortName(Port.Left, Localization.LeftPort);
					//Machine.OpForm.SetPortName(Port.Right, Localization.RightPort);
				}
				Machine.ManualCommands.UpdateCommands();

				Machine.Cycle[0].Reset.Start();
				if(Properties.Settings.Default.DualPortSystem)
				{
					Machine.Cycle[1].Reset.Start();
				}

			}


			if(Machine.Cycle[Port.Blue].bUpdateDataPlotSettings)
			{
				Machine.DataPlot[Port.Blue].Settings.LegendVisible =
				  Machine.Cycle[Port.Blue].bDataPlotLegendVisible;
				Machine.DataPlot[Port.Blue].SetSettings();
				Machine.Cycle[Port.Blue].bUpdateDataPlotSettings = false;
			}
			if(Machine.Cycle[Port.Blue].bDisplaySelectModel)
			{
				Machine.Cycle[Port.Blue].bDisplaySelectModel = false;
				Machine.ManualCommands.DisplaySelectModel();
			}
			if(Properties.Settings.Default.DualPortSystem)
			{
				if(Machine.Cycle[Port.White].bDisplaySelectModel)
				{
					Machine.Cycle[Port.White].bDisplaySelectModel = false;
					Machine.ManualCommands.DisplayWhiteSelectModel();
				}
			}

			if(Machine.Cycle[Port.Blue].bSerialNumberFromSNForm)
			{
				Machine.Cycle[Port.Blue].bSerialNumberFromSNForm = false;
				this.ScannerText.Text = Machine.Cycle[Port.Blue].sSerialNumberFromSNForm + "\n";
			}
			if(Machine.Cycle[Port.Blue].bDisplayInquireForm)
			{
				Machine.Cycle[Port.Blue].bDisplayInquireForm = false;
				Machine.ManualCommands.DisplayInquire();
			}
			if(MyStaticVariables.USBCounterError)
			{
				//TimeSpan ErrorTime = DateTime.Now - MyStaticVariables.USBErrorTime;
				//if (ErrorTime.TotalSeconds > 20.0)
				//{
				//    Environment.Exit(-1);
				//}
			}
			//if (MyStaticVariables.ShowUSBCounterNoDetectedError)
			//{
			//    MyStaticVariables.ShowUSBCounterNoDetectedError = false;
			//    MessageBox.Show("USB Counter not detected.  Program will halt.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			//}

			if(Machine.Cycle[Port.Blue].bHideMessageBox)
			{
				Machine.Cycle[Port.Blue].bHideMessageBox = false;
				Machine.Test[Port.Blue].MessageBoxFlag = false;
				Machine.ManualCommands.HideMessageForm();
			}


			//if (!MyStaticVariables.InitializeCounter)
			//{
			//    if ((Config.TestMode == TestModes.Autotest) || (Config.TestMode == TestModes.Manual))
			//    {
			//        TimeSpan StartTime = DateTime.Now - MyStaticVariables.USBErrorTime;
			//        if (StartTime.TotalSeconds > 5.0)
			//        {
			//            Machine.Test[Port.Blue].MessageBoxFlag = false;
			//            Machine.ManualCommands.HideMessageForm();

			//            MyStaticVariables.InitializeCounter = true;
			//            Machine.ManualCommands.InitializeCounter();
			//        }
			//        else
			//        {
			//            if (!Machine.Test[Port.Blue].MessageBoxFlag)
			//            {
			//                Machine.Message.textBox1.Text = Localization.CheckingUSBCounter;
			//                Machine.Test[Port.Blue].MessageBoxFlag = true;
			//                Machine.ManualCommands.ShowMessageForm();
			//            }
			//        }
			//    }
			//    else
			//    {
			//        MyStaticVariables.USBErrorTime = DateTime.Now;
			//    }
			//}
			try
			{
				if(Machine.Cycle[0].bLoadHiSideLimit)
				{
					Machine.Cycle[0].bLoadHiSideLimit = false;
					IO.AOut.BlueCircuit2HiSideCountLimit.Value = Convert.ToDouble(Machine.Test[0].CounterStopValueHiSide) / 3276.8;
				}
				else
				{
					if(IO.AOut.BlueCircuit2HiSideCountLimit.Value > 0.0001)
					{
						IO.AOut.BlueCircuit2HiSideCountLimit.Value = 0.0;
					}
				}
				if(Machine.Cycle[0].bLoadLowSideLimit)
				{
					Machine.Cycle[0].bLoadLowSideLimit = false;
					IO.AOut.BlueCircuit2LoSideCountLimit.Value = Convert.ToDouble(Machine.Test[0].CounterStopValueLowSide) / 3276.8;
				}
				else
				{
					if(IO.AOut.BlueCircuit2LoSideCountLimit.Value > 0.0001)
					{
						IO.AOut.BlueCircuit2LoSideCountLimit.Value = 0.0;
					}
				}
				if(Properties.Settings.Default.DualPortSystem)
				{
					if(Machine.Cycle[1].bLoadHiSideLimit)
					{
						Machine.Cycle[1].bLoadHiSideLimit = false;
						//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal0Reg1, Machine.Test[1].CounterStopValueHiSide);//goes high at this count
					}
					if(Machine.Cycle[1].bLoadLowSideLimit)
					{
						Machine.Cycle[1].bLoadLowSideLimit = false;
						//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal0Reg0, Machine.Test[1].CounterStopValueLowSide);//goes high at this count
					}
				}
				if(Machine.Cycle[0].bLoadHiSideCounter)
				{
					Machine.Cycle[0].bLoadHiSideCounter = false;
					IO.AOut.BlueCircuit2HiSideStartCountValue.Value = Convert.ToDouble(Machine.Test[0].LoadHiSideCounter) / 3276.8;
					Machine.Test[0].LastHiCounterWriteTime = DateTime.Now;
				}
				else if((DateTime.Now - Machine.Test[0].LastHiCounterWriteTime).TotalSeconds > .5) // Delay by .5 to make sure PLC sees value before it resets to 0
				{
					if(IO.AOut.BlueCircuit2HiSideStartCountValue.Value > 0.0001)
					{
						IO.AOut.BlueCircuit2HiSideStartCountValue.Value = 0.0;
					}
				}
				if(Machine.Cycle[0].bLoadLowSideCounter)
				{
					Machine.Cycle[0].bLoadLowSideCounter = false;
					IO.AOut.BlueCircuit2LoSideStartCountValue.Value = Convert.ToDouble(Machine.Test[0].LoadLowSideCounter) / 3276.8;
					Machine.Test[0].LastLoCounterWriteTime = DateTime.Now;
				}
				else if((DateTime.Now - Machine.Test[0].LastLoCounterWriteTime).TotalSeconds > .5) // Delay by .5 to make sure PLC sees value before it resets to 0
				{
					if(IO.AOut.BlueCircuit2LoSideStartCountValue.Value > 0.0001)
					{
						IO.AOut.BlueCircuit2LoSideStartCountValue.Value = 0.0;
					}
				}
				if(Properties.Settings.Default.DualPortSystem)
				{
					if(Machine.Cycle[1].bLoadHiSideCounter)
					{
						Machine.Cycle[1].bLoadHiSideCounter = false;

						//CounterMode Mode = MccDaq.CounterMode.Totalize;
						//Mode = Mode | MccDaq.CounterMode.NoRecycleOff;
						//Mode = Mode | MccDaq.CounterMode.RangeLimitOff;
						//Mode = Mode | MccDaq.CounterMode.CountDownOn;
						//Mode = Mode | MccDaq.CounterMode.OutputInitialStateLow;
						////Mode = Mode | MccDaq.CounterMode.OutputInitialStateHigh;
						////Mode = Mode | MccDaq.CounterMode.OutputOn;

						//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.MaxLimitReg1, 25000);
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.MinLimitReg1, -25000);
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal0Reg1, 0);//goes high at this count
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal1Reg1, 25000);//goes low at this count

						//CounterDebounceTime CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
						//CounterDebounceMode CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
						//CounterEdgeDetection CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
						//CounterTickSize myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
						//int mappedChannel = 0;

						//CounterRegister MccCounter = MccDaq.CounterRegister.LoadReg1;
						//int NumCounter = 1;

						//ULStat = Machine.CounterBoard.CConfigScan(NumCounter, Mode, CounterDebounceTime, CounterDebounceMode, CounterEdgeDetection, myCounterTickSize, mappedChannel);

						//if (ULStat.Value == 0)
						{
							int LoadVal = Machine.Test[1].LoadHiSideCounter;
							//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccCounter, LoadVal);
						}

						//int CounterNum = 2;
						//MccDaq.GateControl GateControl = MccDaq.GateControl.NoGate;
						//MccDaq.CountEdge CounterEdge = MccDaq.CountEdge.PositiveEdge;
						//MccDaq.CounterSource CounterSource = MccDaq.CounterSource.CtrInput2;
						//MccDaq.OptionState SpecialGate = MccDaq.OptionState.Disabled;
						//MccDaq.Reload Reload = MccDaq.Reload.LoadReg;
						//MccDaq.RecycleMode RecycleMode = MccDaq.RecycleMode.Recycle;
						//MccDaq.BCDMode BCDMode = MccDaq.BCDMode.Disabled;
						//MccDaq.CountDirection CountDirection = MccDaq.CountDirection.CountDown;
						//MccDaq.C9513OutputControl OutputControl = MccDaq.C9513OutputControl.ToggleOnTc;

						//MccDaq.ErrorInfo ULSTAT;

						//ULSTAT = Machine.CounterBoard.C9513Config(CounterNum, GateControl, CounterEdge, CounterSource, SpecialGate, Reload, RecycleMode, BCDMode, CountDirection, OutputControl);

						//MccDaq.CounterRegister RegName = MccDaq.CounterRegister.LoadReg2;
						//int LoadVal = Machine.Test[1].LoadHiSideCounter;

						//ULSTAT = Machine.CounterBoard.CLoad(RegName, LoadVal);
					}
					if(Machine.Cycle[1].bLoadLowSideCounter)
					{
						Machine.Cycle[1].bLoadLowSideCounter = false;

						//CounterMode Mode = MccDaq.CounterMode.Totalize;
						//Mode = Mode | MccDaq.CounterMode.NoRecycleOff;
						//Mode = Mode | MccDaq.CounterMode.RangeLimitOff;
						//Mode = Mode | MccDaq.CounterMode.CountDownOn;
						//Mode = Mode | MccDaq.CounterMode.OutputInitialStateLow;
						////Mode = Mode | MccDaq.CounterMode.OutputInitialStateHigh;
						////Mode = Mode | MccDaq.CounterMode.OutputOn;

						//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.MaxLimitReg0, 25000);
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.MinLimitReg0, -25000);
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal0Reg0, 0);//goes high at this count
						//ULStat = Machine.CounterBoard.CLoad32(MccDaq.CounterRegister.OutputVal1Reg0, 25000);//goes low at this count

						//CounterDebounceTime CounterDebounceTime = MccDaq.CounterDebounceTime.DebounceNone;
						//CounterDebounceMode CounterDebounceMode = MccDaq.CounterDebounceMode.TriggerAfterStable;
						//CounterEdgeDetection CounterEdgeDetection = MccDaq.CounterEdgeDetection.RisingEdge;
						//CounterTickSize myCounterTickSize = MccDaq.CounterTickSize.Tick20pt83ns;
						//int mappedChannel = 0;

						// MccCounter = MccDaq.CounterRegister.LoadReg0;
						//int NumCounter = 0;

						//ULStat = Machine.CounterBoard.CConfigScan(NumCounter, Mode, CounterDebounceTime, CounterDebounceMode, CounterEdgeDetection, myCounterTickSize, mappedChannel);

						//if (ULStat.Value == 0)
						{
							int LoadVal = Machine.Test[1].LoadLowSideCounter;
							//ErrorInfo ULStat = Machine.CounterBoard.CLoad32(MccCounter, LoadVal);
						}

						//int CounterNum = 1;
						//MccDaq.GateControl GateControl = MccDaq.GateControl.NoGate;
						//MccDaq.CountEdge CounterEdge = MccDaq.CountEdge.PositiveEdge;
						//MccDaq.CounterSource CounterSource = MccDaq.CounterSource.CtrInput2;
						//MccDaq.OptionState SpecialGate = MccDaq.OptionState.Disabled;
						//MccDaq.Reload Reload = MccDaq.Reload.LoadReg;
						//MccDaq.RecycleMode RecycleMode = MccDaq.RecycleMode.Recycle;
						//MccDaq.BCDMode BCDMode = MccDaq.BCDMode.Disabled;
						//MccDaq.CountDirection CountDirection = MccDaq.CountDirection.CountDown;
						//MccDaq.C9513OutputControl OutputControl = MccDaq.C9513OutputControl.ToggleOnTc;

						//MccDaq.ErrorInfo ULSTAT;

						//ULSTAT = Machine.CounterBoard.C9513Config(CounterNum, GateControl, CounterEdge, CounterSource, SpecialGate, Reload, RecycleMode, BCDMode, CountDirection, OutputControl);

						//MccDaq.CounterRegister RegName = MccDaq.CounterRegister.LoadReg1;
						//int LoadVal = Machine.Test[1].LoadLowSideCounter;

						//ULSTAT = Machine.CounterBoard.CLoad(RegName, LoadVal);
					}
				}
				if(Machine.Cycle[0].bEnableHiSideCharge)
				{
					Machine.Cycle[0].bEnableHiSideCharge = false;
					IO.DOut.BlueCircuit2HiSideCharge.Enable();
				}
				if(Machine.Cycle[0].bDisableHiSideCharge)
				{
					Machine.Cycle[0].bDisableHiSideCharge = false;
					IO.DOut.BlueCircuit2HiSideCharge.Disable();
				}
				if(Machine.Cycle[0].bEnableLowSideCharge)
				{
					Machine.Cycle[0].bEnableLowSideCharge = false;
					IO.DOut.BlueCircuit2LoSideCharge.Enable();
				}
				if(Machine.Cycle[0].bDisableLowSideCharge)
				{
					Machine.Cycle[0].bDisableLowSideCharge = false;
					IO.DOut.BlueCircuit2LoSideCharge.Disable();
				}

			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			try
			{
				//calcuate the part flow from the change in the counter
				TimeSpan AnalogReadDelay = DateTime.Now - MyStaticVariables.LastAnalogReadTime;
				if(AnalogReadDelay.TotalSeconds > 1.5)
				{
					IO.Signals.BluePartFlow.Value = (IO.Signals.BluePartCharge.Value - MyStaticVariables.LastBlueCharge) / AnalogReadDelay.TotalSeconds;
					IO.Signals.WhitePartFlow.Value = (IO.Signals.WhitePartCharge.Value - MyStaticVariables.LastWhiteCharge) / AnalogReadDelay.TotalSeconds;

					MyStaticVariables.LastBlueCharge = IO.Signals.BluePartCharge.Value;
					MyStaticVariables.LastWhiteCharge = IO.Signals.WhitePartCharge.Value;
					MyStaticVariables.LastAnalogReadTime = DateTime.Now;
				}


				if(Machine.Test[0].PartChargeByCounterStart > 1)
				{
					IO.Signals.BluePartChargeByCounter.Value = (Machine.Test[0].PartChargeByCounterStart - IO.Signals.BlueLowSideCounter.Value) / Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue;
				}
				else
				{
					IO.Signals.BluePartChargeByCounter.Value = 0;
				}
				IO.Signals.BluePartChargeInPounds.Value = IO.Signals.BluePartChargeByCounter.Value / 16.0;
				if(Properties.Settings.Default.DualPortSystem)
				{
					if(Machine.Test[1].PartChargeByCounterStart > 1)
					{
						IO.Signals.WhitePartChargeByCounter.Value = (Machine.Test[1].PartChargeByCounterStart - IO.Signals.WhiteLowSideCounter.Value) / Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue;
					}
					else
					{
						IO.Signals.WhitePartChargeByCounter.Value = 0;
					}
				}
				IO.Signals.BluePartCharge.Value = IO.Signals.BluePartChargeByCounter.Value;
				if(Properties.Settings.Default.DualPortSystem)
				{
					IO.Signals.WhitePartCharge.Value = IO.Signals.WhitePartChargeByCounter.Value;
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			if(Config.Mode.ShowCycleSteps.ProcessValue)
			{
				if(Machine.CycleStepsForm.Visible == false)
					Machine.CycleStepsForm.Show();

				String strStepNames = "";
				foreach(CycleStep step in Machine.Cycle[Port.Blue].CycleSteps)
				{
					if(step.Name == "ScanSerialNumber" || step.Name == "ScanSerialNumber2") // exclude
						continue;
					if(step.State == CycleStepState.InProcess)
						if(strStepNames.Length == 0)
							strStepNames += step.Name;
						else
							strStepNames += String.Format("\n" + step.Name);
				}
				//foreach (CycleStep step2 in Machine.Cycle[Port.White].CycleSteps)  // for dual port
				//{
				//    if (step2.Name == "ScanSerialNumber" || step2.Name == "ScanSerialNumber2")
				//        continue;
				//    if (step2.State == CycleStepState.InProcess)
				//        if (strStepNames.Length == 0)
				//            strStepNames += step2.Name;
				//        else
				//            strStepNames += Environment.NewLine + step2.Name;
				//}
				if(Machine.CycleStepsForm.rtbCycleStepsActive.Text != strStepNames)
					Machine.CycleStepsForm.rtbCycleStepsActive.Text = strStepNames;
			}
			else { if(Machine.CycleStepsForm.Visible) Machine.CycleStepsForm.Hide(); }
		}

		private void ScannerText_TextChanged(object sender, EventArgs e)
		{

		}
		private void saveConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.SaveConfigGoodFile();
		}
		private void manualCmdExecLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewManualCmdExecLog();
		}
		private void parameterChangeLogToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Machine.ManualCommands.ViewParamChangeLog();
		}

		private void showActiveCycleStepsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Config.Mode.ShowCycleSteps.ProcessValue = true;
		}
	}
}