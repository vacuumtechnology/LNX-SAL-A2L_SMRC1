using System;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TRANE_GAS_MANIFOLD.Classes.Configuration;
using TRANE_GAS_MANIFOLD.Classes.IOClasses;
using TRANE_GAS_MANIFOLD.Enums;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Classes.IO;
using VTIWindowsControlLibrary.Classes.Configuration;
using VTIWindowsControlLibrary.Classes.CycleSteps;
using VTIWindowsControlLibrary.Classes.Graphing.Util;
using VTIWindowsControlLibrary.Data;
using VTIWindowsControlLibrary.Enums;
using System.Collections;
using System.Reflection;

namespace TRANE_GAS_MANIFOLD.Classes
{
    public partial class CycleSteps : CycleStepsBase
    {
        public CycleStep PartHighN2FillStartBlue, 
            //PartFillCheckHoseBlue, 
            PartConnectorCheckBlue,
          PartStabilizeN2FillPressureBlue, PartPressureDecayTestTimeBlue,
          PartN2FillDumpBlue, PartN2EvacuationBlue, PartTracerSquirtBlue, PartTracerDumpBlue, PartTracerEvacuationBlue,
          WaitForPartPDProofToComplete, WaitForPartTracerProcessToComplete
          ;

        public DateTime N2DumpCheckBlue { get; set; }
        public DateTime TracerDumpCheckBlue { get; set; }
        public DateTime TracerEvacCheckBlue { get; set; }

        public void CycleSteps_BlueHoses_initialize()
        {

            PartConnectorCheckBlue = new CycleStep
            {
                ValveDelay = Config.Time.ConnectorCheckFillDelay,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure

            };
            PartConnectorCheckBlue.Started += new CycleStep.CycleStepEventHandler(PartConnectorCheckBlue_Started);
            PartConnectorCheckBlue.ValveDelayElapsed += new CycleStep.CycleStepEventHandler(PartConnectorCheckBlue_ValveDelayElapsed);
            PartConnectorCheckBlue.Tick += new CycleStep.CycleStepEventHandler(PartConnectorCheckBlue_Tick);
            PartConnectorCheckBlue.Passed += new CycleStep.CycleStepEventHandler(PartConnectorCheckBlue_Passed);
            PartConnectorCheckBlue.Failed += new CycleStep.CycleStepEventHandler(PartConnectorCheckBlue_Failed);

            PartHighN2FillStartBlue = new CycleStep
            {
                TimeDelay = model.PDChargeDelay,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure
            };
            PartHighN2FillStartBlue.Started += new CycleStep.CycleStepEventHandler(PartHighN2FillStartBlue_Started);
            PartHighN2FillStartBlue.Tick += new CycleStep.CycleStepEventHandler(PartHighN2FillStartBlue_Tick);
            PartHighN2FillStartBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartBlue_Elapsed);
            PartHighN2FillStartBlue.Failed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartBlue_Failed);
            PartHighN2FillStartBlue.Passed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartBlue_Passed);

            PartStabilizeN2FillPressureBlue = new CycleStep
           {
               TimeDelay = model.PDPressureStabilizeDelay,
               DisplayDetailsOnPassFail = false,
               ProcessValue = IO.Signals.BlueManifoldTransducerPressure,
               //DisplayElapsedTime = true

           };
            PartStabilizeN2FillPressureBlue.Started += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureBlue_Started);
            PartStabilizeN2FillPressureBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureBlue_Elapsed);
            PartStabilizeN2FillPressureBlue.Passed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureBlue_Passed);
            PartStabilizeN2FillPressureBlue.Failed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureBlue_Failed);

            PartN2FillDumpBlue = new CycleStep
            {
                TimeDelay = model.PDN2DumpDelay,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            PartN2FillDumpBlue.Started += new CycleStep.CycleStepEventHandler(PartN2FillDumpBlue_Started);
            PartN2FillDumpBlue.Tick += new CycleStep.CycleStepEventHandler(PartN2FillDumpBlue_Tick);
            PartN2FillDumpBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartN2FillDumpBlue_Elapsed);
            PartN2FillDumpBlue.Failed += new CycleStep.CycleStepEventHandler(PartN2FillDumpBlue_Failed);
            PartN2FillDumpBlue.Passed += new CycleStep.CycleStepEventHandler(PartN2FillDumpBlue_Passed);

            PartN2EvacuationBlue = new CycleStep
            {
                TimeDelay = model.N2EvacuationDelay,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure
            };
            PartN2EvacuationBlue.Started += new CycleStep.CycleStepEventHandler(PartN2EvacuationBlue_Started);
            PartN2EvacuationBlue.Tick += new CycleStep.CycleStepEventHandler(PartN2EvacuationBlue_Tick);
            PartN2EvacuationBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartN2EvacuationBlue_Elapsed);
            PartN2EvacuationBlue.Passed += new CycleStep.CycleStepEventHandler(PartN2EvacuationBlue_Passed);
            PartN2EvacuationBlue.Failed += new CycleStep.CycleStepEventHandler(PartN2EvacuationBlue_Failed);

            PartTracerSquirtBlue = new CycleStep
            {
                Prompt = Localization.PartTracerSquirtBlue_Prompt,
                DisplayDetailsOnPassFail = false,
                TimeDelay = model.SquirtTestMeasureTime,
                ValveDelay = model.SquirtTestFillTime,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure
            };
            PartTracerSquirtBlue.Started += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_Started);
            PartTracerSquirtBlue.ValveDelayElapsed += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_ValveDelayElapsed);
            PartTracerSquirtBlue.Tick += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_Tick);
            PartTracerSquirtBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_Elapsed);
            PartTracerSquirtBlue.Passed += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_Passed);
            PartTracerSquirtBlue.Failed += new CycleStep.CycleStepEventHandler(PartTracerSquirtBlue_Failed);


            PartTracerDumpBlue = new CycleStep
            {
                Prompt = Localization.PartTracerDumpBlue_Prompt,
                TimeDelay = model.TracerGasDumpTime,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            PartTracerDumpBlue.Started += new CycleStep.CycleStepEventHandler(PartTracerDumpBlue_Started);
            PartTracerDumpBlue.Tick += new CycleStep.CycleStepEventHandler(PartTracerDumpBlue_Tick);
            PartTracerDumpBlue.Elapsed += new CycleStep.CycleStepEventHandler(PartTracerDumpBlue_Elapsed);
            PartTracerDumpBlue.Passed += new CycleStep.CycleStepEventHandler(PartTracerDumpBlue_Passed);
            PartTracerDumpBlue.Failed += new CycleStep.CycleStepEventHandler(PartTracerDumpBlue_Failed);

            PartTracerEvacuationBlue = new CycleStep
            {
                Prompt = Localization.PartTracerEvacuationBlue_Prompt,
                DisplayDetailsOnPassFail = false,
                //TimeDelay = model.TracerGasEvacuationTime, checking timer in tick even TAS 11/13/12
                ProcessValue = IO.Signals.BlueManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            PartTracerEvacuationBlue.Started += new CycleStep.CycleStepEventHandler(PartTracerEvacuationBlue_Started);
            PartTracerEvacuationBlue.Tick += new CycleStep.CycleStepEventHandler(PartTracerEvacuationBlue_Tick);
            PartTracerEvacuationBlue.Passed += new CycleStep.CycleStepEventHandler(PartTracerEvacuationBlue_Passed);
            PartTracerEvacuationBlue.Failed += new CycleStep.CycleStepEventHandler(PartTracerEvacuationBlue_Failed);
        }

        void PartConnectorCheckBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            ////throw new NotImplementedException();
            MyStaticVariables.WaitForAcknowledgeFlag = true;
            CycleNoTest("Left Part not connected", "Left Check Conn");
            VtiEvent.Log.WriteInfo(String.Format("Failed, Blue manifold connector check pressure: {0:0} psi", IO.Signals.BlueManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //VtiEvent.Log.WriteInfo(String.Format("Failed, Blue check hose connector check pressure: {0:0} psi", IO.Signals.BlueeSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            //Machine.Test[Port.Blue].Result = Localization.PartConnectorCheckBlue_FailedPrompt;
            ChamberRough.Stop();
            BlowerStart.Stop();
            IO.DOut.BlueLeftPartDump.Enable();
            if (Config.Mode.WhitePortEnabled.ProcessValue)
            {
                PartHighN2FillStartWhite.Stop();
                PartConnectorCheckWhite.Stop();
                IO.DOut.WhiteRightPartHighPressureFill.Disable();
                IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
                Thread.Sleep(500);
                IO.DOut.WhiteRightPartDump.Enable();
            }
            ChamberVent.Start();
        }

        void PartConnectorCheckBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (model.ConnectorCheckProcess && Machine.Test[Port.Blue].SerialNumber != "BLANK TEST")
            //{
                VtiEvent.Log.WriteInfo(String.Format("Passed, Blue manifold connector check pressure: {0:0} psi", IO.Signals.BlueManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //    VtiEvent.Log.WriteInfo(String.Format("Passed, Blue check hose connector check pressure: {0:0} psi", IO.Signals.BlueeSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            //}
            //else
            //{
            //    VtiEvent.Log.WriteInfo(String.Format("Connector check was not performed.  Disabled or BLANK TEST."), VtiEventCatType.Test_Cycle);
            //}
            //PartHighN2FillStartBlue.Start();
            if ((Config.Mode.CrossCircuitCheckMode.ProcessValue)&& Config.Mode.WhitePortEnabled.ProcessValue && Config.Mode.BluePortEnabled.ProcessValue)
            {
                VtiEvent.Log.WriteInfo(String.Format("Cross Circuit check White manifold pressure: {0:0} psi", IO.Signals.WhiteManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
                if (IO.Signals.WhiteManifoldTransducerPressure.Value < model.PDN2DumpPressureSetPoint.ProcessValue)//passed cross circuit check
                {
                    if (model.ConnectorCheckProcess.ProcessValue)
                    {
                        PartConnectorCheckWhite.Start();
                    }
                    else
                    {
                        PartHighN2FillStartBlue.Start();
                        PartHighN2FillStartWhite.Start();
                    }
                }
                else
                {
                    //failed cross circuit check
                    MyStaticVariables.WaitForAcknowledgeFlag = true;
                    CycleNoTest("Failed Cross Circuit Test", "Fail Cross Circuit");
                    VtiEvent.Log.WriteInfo(String.Format("Failed Cross Circuit Test, White manifold connector check pressure: {0:0} psi", IO.Signals.WhiteManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
                    //VtiEvent.Log.WriteInfo(String.Format("Failed, Blue check hose connector check pressure: {0:0} psi", IO.Signals.BlueeSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
                    //Machine.Test[Port.Blue].Result = Localization.PartConnectorCheckBlue_FailedPrompt;
                    ChamberRough.Stop();
                    BlowerStart.Stop();
                    IO.DOut.BlueLeftPartDump.Enable();
                    //if (Config.Mode.WhitePortEnabled.ProcessValue)
                    {
                        PartHighN2FillStartWhite.Stop();
                        PartConnectorCheckWhite.Stop();
                        IO.DOut.WhiteRightPartHighPressureFill.Disable();
                        IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
                        Thread.Sleep(500);
                        IO.DOut.WhiteRightPartDump.Enable();
                    }
                    ChamberVent.Start();
                    step.Stop();
                }
            }
            else
            {
                if (Config.Mode.WhitePortEnabled.ProcessValue)
                {
                    if (model.ConnectorCheckProcess.ProcessValue)
                    {
                        PartConnectorCheckWhite.Start();
                    }
                    else
                    {
                        PartHighN2FillStartBlue.Start();
                        PartHighN2FillStartWhite.Start();
                    }
                }
                else
                {
                    PartHighN2FillStartBlue.Start();
                }
            }
        

            step.Stop();
        }

        void PartConnectorCheckBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            try
            {
                if (step.ElapsedTime.TotalSeconds > Config.Time.ConnectorCheckFillDelay.ProcessValue + Config.Time.ConnectorCheckStabilizeDelay.ProcessValue)
                {
                    //Console.WriteLine(IO.Signals.BlueManifoldTransducerPressure.Value);
            //        //Console.WriteLine(IO.Signals.BlueeSideCheckHoseTransPress.Value);
                    //Console.WriteLine(Config.Pressure.ConnectorCheckFillPressureSetPoint.ProcessValue);
                    double ConnectorCheckManifoldFillMax;
            //        double ConnectorCheckFillCheckHoseMin;
                    if((Machine.Test[Port.Blue].SerialNumber == "BLANK TEST")||MyStaticVariables.ChamberCalibrationCheck||MyStaticVariables.CalChamber||!model.ConnectorCheckProcess.ProcessValue)
                   {
                        // do not do a connector check on a blank test, or cal chamber or chamber leak
                        step.Pass();
                   }
                   else
                    {
            //            if (Config.Mode.BlueLeftFillCheckHoseEnabled)
            //            {
            //                VtiEvent.Log.WriteInfo(String.Format("Blue fill check hose enabled"), VtiEventCatType.Test_Cycle);

            //                // Just make sure the pressure is rising on the check hose for connector check
            //                ConnectorCheckFillCheckHoseMin = IO.Signals.BlueManifoldTransducerPressure.Value / 2;
            //                if (IO.Signals.BlueeSideCheckHoseTransPress.Value < ConnectorCheckFillCheckHoseMin)
            //                {
            //                    PartConnectorCheckBlue.Fail();
            //                }
            //                else
            //                {
            //                    PartConnectorCheckBlue.Pass();
            //                }
            //            }
            //            else
            //            {
                            // one hose connector check, if pressure exceeds ConnectorCheckFillPressureSetPoint fail con check
                            ConnectorCheckManifoldFillMax = Config.Pressure.ConnectorCheckFillPressureSetPoint.ProcessValue;
                            if (IO.Signals.BlueManifoldTransducerPressure.Value > ConnectorCheckManifoldFillMax)
                            {
                                PartConnectorCheckBlue.Fail();
                            }
                            else
                            {
                                // passed connector check
                                PartConnectorCheckBlue.Pass();
                            }
                        }
                   }

                }
            
            catch (Exception ex)
            {
               // what happened
                VtiEvent.Log.WriteInfo(String.Format("An error occured in PartConnectorCheckBlue_Tick cycle step. " + ex.Message), VtiEventCatType.Application_Error);
            }

        }

        void PartConnectorCheckBlue_ValveDelayElapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {// wait Config.Time.ConnectorCheckFillDelay
            //IO.DOut.BlueLeftPartHighPressureFill.Disable();
            //VtiEvent.Log.WriteInfo(String.Format("Blue manifold connector check fill pressure: {0:0} psi", IO.Signals.BlueManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //VtiEvent.Log.WriteInfo(String.Format("Blue check hose connector check fill pressure: {0:0} psi", IO.Signals.BlueeSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            
        }

        void PartConnectorCheckBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (Config.Mode.BlueLeftFillCheckHoseEnabled)
            //{
            //    AnalogSignal[] SignalToShow = new AnalogSignal[1] { (IO.Signals.BlueeSideCheckHoseTransPress) };
            //    step.SignalsToDisplay = SignalToShow;
            //}
            //if (IO.DOut.BlueLeftPartEvac.Value || IO.DOut.BlueLeftPartDump.Value || IO.DOut.BlueLeftPartRecovery.Value || IO.DOut.BlueLeftPartHighPressureFill.Value)
            //{
            //    step.Stop();
            //}
            //else
            //{
            //    IO.DOut.BlueLeftPartHighPressureFill.Enable();
            //}
            IO.DOut.BlueLeftPartDump.Disable();
            IO.DOut.BlueLeftPartEvac.Disable();
            IO.DOut.BlueLeftPartRecovery.Disable();
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            Thread.Sleep(500);
            IO.DOut.BlueLeftPartHighPressureFill.Enable();
            Thread.Sleep((int)(Config.Time.ConnectorCheckFillDelay.ProcessValue * 1000));
            IO.DOut.BlueLeftPartHighPressureFill.Disable();

        }

        void WaitForPartTracerProcessToComplete_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.WaitForAcknowledgeFlag == true)
            {
                WaitForAcknowledge.Start();
            }
            else
            {
                ChamberOpen.Start();
            }
        }

        void WaitForPartTracerProcessToComplete_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if ((PartTracerEvacuationBlue.State == CycleStepState.Passed) || (!Machine.Test[Port.Blue].FilledWithTracerGas))
            {
                WaitForPartTracerProcessToComplete.Pass();
            }

        }

        void PartTracerEvacuationBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartEvac.Disable();
            CycleNoTest("Tracer Gas evacuation timeout", "TG Evac. Timeout");
        }

        void PartTracerEvacuationBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartEvac.Disable();
        }

        void PartTracerEvacuationBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (step.ElapsedTime.TotalSeconds > model.TracerGasEvacuationTime.ProcessValue
                && BackgroundMeasureDelay.State != CycleStepState.InProcess)  // keep pumping if background measure is in process
            {
                if (IO.Signals.BlueManifoldTransducerPressure.Value < model.TracerGasEvacuationPressure.ProcessValue)
                {
                    PartTracerEvacuationBlue.Pass();
                }
                else
                {
                    PartTracerEvacuationBlue.Fail();
                }
            }
        }

        void PartTracerEvacuationBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartEvac.Enable();
        }

        void PartTracerDumpBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest("Blue tracer gas dump timeout", "Blue TG dump timeout");
            //Reset.Start();
        }

        void PartTracerDumpBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if filled with helium pump it, otherwise, done
            if (Machine.Test[Port.Blue].FilledWithTracerGas) //  if (MyStaticVariables.FilledWithTracerGas)
            {
                PartTracerEvacuationBlue.Start();
                Machine.Test[Port.Blue].FilledWithTracerGas = false;
            }
        }

        void PartTracerDumpBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartDump.Disable();
            if ((IO.Signals.BlueManifoldTransducerPressure.Value < model.TracerGasDumpPressure.ProcessValue))
            {   // pressure less than dump set point 
                PartTracerDumpBlue.Pass();
            }
            else if (IO.Signals.BlueManifoldTransducerPressure.Value > model.TracerGasDumpPressure.ProcessValue)
            {
                PartTracerDumpBlue.Fail();
            }
        }

        void PartTracerDumpBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (Config.Mode.quitEarlyTracerGasDumpCheck.ProcessValue)
            //{ // if quit early enabled else wait entire delay
            //    //if ((DateTime.Now - TracerDumpCheckBlue).Seconds > 5 && (IO.Signals.BlueManifoldTransducerPressure.Value < model.TracerGasDumpPressure.ProcessValue) && IO.DOut.BlueLeftPartDump.Value)
            //    if ((DateTime.Now - TracerDumpCheckBlue).Seconds > 5 && (IO.Signals.BlueeSideCheckHoseTransPress.Value < model.TracerGasDumpPressure.ProcessValue) && IO.DOut.BlueLeftPartDump.Value)
            //    {   // pressure less than dump set point then close dump valve stabilize and check pressure is less than dump set point
            //        IO.DOut.BlueLeftPartDump.Disable();
            //        TracerDumpCheckBlue = DateTime.Now;
            //    }
            //    //else if (IO.Signals.BlueeSideCheckHoseTransPress.Value > model.TracerGasDumpPressure.ProcessValue && !IO.DOut.BlueLeftPartDump.Value)
            //    //{  // pressure rise open dump valve
            //    //    IO.DOut.BlueLeftPartDump.Enable();
            //    //}
            //    if ((DateTime.Now - TracerDumpCheckBlue).Seconds > 10 && !IO.DOut.BlueLeftPartDump.Value)  // quit early dump check
            //    {
            //        PartTracerDumpBlue.Pass();
            //    }
            //}
        }

        void PartTracerDumpBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartEvac.Disable();
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            Thread.Sleep(500);
            IO.DOut.BlueLeftPartDump.Enable();
        }

        void PartTracerFillBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // Monitor for high fine failures
            if (IO.Signals.ChamberFlowOzyear.Value > (model.FineTestRejectRate.ProcessValue*Config.Flow.HighFineTestRejectSetPoint.ProcessValue))
            {
                //Failed during Fill
                String TempString = string.Format("Fail During Fill {0:0.00} oz/yr", IO.Signals.ChamberFlowOzyear.Value);
                CycleFail(TempString,TempString);
                PartTracerDumpBlue.Start();
                if (Config.Mode.WhitePortEnabled)
                {
                    PartTracerFillWhite.Stop();
                    PartTracerDumpWhite.Start();
                }
                ChamberVent.Start();
            }
            else
            {
                // Didn't reach tracer gas fill pressure or failed leak test
                String TempString = string.Format("TG Fill Low Press: {0:0.00} psig",IO.Signals.BlueManifoldTransducerPressure.Value);
                CycleNoTest(TempString,TempString);
                // Dump Tracer Gas 
                PartTracerDumpBlue.Start();
                if (Config.Mode.WhitePortEnabled)
                {
                    PartTracerFillWhite.Stop();
                    PartTracerDumpWhite.Start();
                }

                ChamberVent.Start();
            }
        }

        void PartTracerFillBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // wait fine test delay
            TestFineDelay.Start();
        }

        void PartTracerFillBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            if (IO.Signals.BlueManifoldTransducerPressure.Value >= model.TracerGasFillTargetPressure)
            {
                PartTracerFillBlue.Pass();
            }
            else
            {
                PartTracerFillBlue.Fail();
            }
        }

        void PartTracerFillBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.LeakRate = IO.Signals.ChamberFlowOzyear.Value;
            MyStaticVariables.TGFillBluePressure = IO.Signals.BlueManifoldTransducerPressure.Value;
            MyStaticVariables.TGFillWhitePresure = IO.Signals.WhiteManifoldTransducerPressure.Value;
            MyStaticVariables.TestSignal = IO.Signals.InficonRawSignal.Value;
            MyStaticVariables.ULPressureSetPoint = model.TracerGasFillTargetPressure.ProcessValue;
            MyStaticVariables.RejectRate = model.FineTestRejectRate.ProcessValue;
            MyStaticVariables.ChamberSplit = Config.Flow.ChamberCalibrationSplitFactor.ProcessValue;
            MyStaticVariables.ChamberTestPressure = IO.Signals.ChamberPressure.Value;
            MyStaticVariables.RoughTestPressure = IO.Signals.RoughPumpPressure.Value;
            MyStaticVariables.ForelineTestPressure = IO.Signals.InficonForeline.Value;
            MyStaticVariables.PolyColdTestTemperature = IO.Signals.PolyColdTemperatureSignal.Value;


            Machine.Test[Port.Blue].LeakRate = IO.Signals.ChamberFlowOzyear.Value;
            // Monitor for high fine failures
            if (IO.Signals.ChamberFlowOzyear.Value > (model.FineTestRejectRate.ProcessValue*Config.Flow.HighFineTestRejectSetPoint.ProcessValue))
            {
                step.Fail();
            }
        }

        void PartTracerFillBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.Blue].FilledWithTracerGas = true;
            IO.DOut.BlueLeftPartEvac.Disable();
            Thread.Sleep(500);
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Enable();
        }

        void PartTracerSquirtBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //throw new NotImplementedException();
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            String TempString = string.Format("Fail:Squirt {0:0.00 oz/yr}", IO.Signals.ChamberFlowOzyear.Value);
            CycleFail(TempString,TempString);
            PartTracerDumpBlue.Start();
            ChamberVent.Start();
        }

        void PartTracerSquirtBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // fill it up
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            PartTracerFillBlue.Start();
        }

        void PartTracerSquirtBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.LeakRate = IO.Signals.ChamberFlowOzyear.Value;
            MyStaticVariables.TGFillBluePressure = IO.Signals.BlueManifoldTransducerPressure.Value;
            MyStaticVariables.TGFillWhitePresure = IO.Signals.WhiteManifoldTransducerPressure.Value;
            MyStaticVariables.TestSignal = IO.Signals.InficonRawSignal.Value;
            MyStaticVariables.ULPressureSetPoint = model.TracerGasFillTargetPressure.ProcessValue;
            MyStaticVariables.RejectRate = model.FineTestRejectRate.ProcessValue;
            MyStaticVariables.ChamberSplit = Config.Flow.ChamberCalibrationSplitFactor.ProcessValue;
            MyStaticVariables.ChamberTestPressure = IO.Signals.ChamberPressure.Value;
            MyStaticVariables.RoughTestPressure = IO.Signals.RoughPumpPressure.Value;
            MyStaticVariables.ForelineTestPressure = IO.Signals.InficonForeline.Value;
            MyStaticVariables.PolyColdTestTemperature = IO.Signals.PolyColdTemperatureSignal.Value;


            // monitor for squirt test failures
            if (IO.Signals.ChamberFlowOzyear.Value > (Config.Flow.SquirtTestReject.ProcessValue * model.FineTestRejectRate.ProcessValue))
            {
                if (step.ElapsedTime.TotalSeconds > 2.0)
                {
                    //Failed during Squirt Test
                    PartTracerSquirtBlue.Fail();
                }
            }
        }

        void PartTracerSquirtBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.ChamberFlowOzyear.Value < (Config.Flow.SquirtTestReject.ProcessValue * model.FineTestRejectRate.ProcessValue))
            {
                //Failed during Squirt Test
                PartTracerSquirtBlue.Pass();
            }
        }

        void PartTracerSquirtBlue_ValveDelayElapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
        }

        void PartTracerSquirtBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.Blue].FilledWithTracerGas = true;
            IO.DOut.BlueLeftPartEvac.Disable();
            Thread.Sleep(500);
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Enable();
        }

        void WaitForPartPDProofToComplete_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            BackgroundMeasureDelay.Start();
        }

        void WaitForPartPDProofToComplete_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (MyStaticVariables.PDProofTestCompleteReadyForTestValveToOpen == true)
                WaitForPartPDProofToComplete.Pass();
        }

        void WaitForPartPDProofToComplete_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //throw new NotImplementedException();
        }

        void PartN2EvacuationBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest("Blue N2 Evacuation", "Blue N2 Evac");
            ChamberVent.Start();
        }

        void PartN2EvacuationBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.PDProofTestCompleteReadyForTestValveToOpen = true;
            step.Stop();
        }

        void PartN2EvacuationBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //IO.DOut.BlueLeftPartEvac.Disable();
            if (IO.Signals.BlueManifoldTransducerPressure.Value < model.N2EvacuationSetPoint.ProcessValue)
            {
                PartN2EvacuationBlue.Pass();
            }
            else
            {
                PartN2EvacuationBlue.Fail();
            }
        }

        void PartN2EvacuationBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // not used
        }

        void PartN2EvacuationBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //IO.DOut.TrashPumpPowerEnable.Enable();
            IO.DOut.BlueLeftPartDump.Disable();
            IO.DOut.BlueLeftPartHighPressureFill.Disable();
            IO.DOut.BlueLeftPartRecovery.Disable();
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            Thread.Sleep(500);
            IO.DOut.BlueLeftPartEvac.Enable();
        }

        void PartPressureDecayTestTimeBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleFail("Failed Pressure Decay", "Failed Pressure Decay");
            ChamberVent.Start();
        }

        void PartPressureDecayTestTimeBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            PartN2FillDumpBlue.Start();
        }

        void PartPressureDecayTestTimeBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.Blue].PDEndPressure = IO.Signals.BlueManifoldTransducerPressure.Value;
            Machine.Test[Port.Blue].PDTestPressureDrop = Machine.Test[Port.Blue].PDStartPressure - Machine.Test[Port.Blue].PDEndPressure;

            if (Machine.Test[Port.Blue].PDTestPressureDrop > model.PDMaximumTestPressureDrop)
            { PartPressureDecayTestTimeBlue.Fail(); }
            else { PartPressureDecayTestTimeBlue.Pass(); }
        }

        void PartPressureDecayTestTimeBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.Blue].PDStartPressure = IO.Signals.BlueManifoldTransducerPressure.Value;
        }

        void PartStabilizeN2FillPressureBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(PartStabilizeN2FillPressureBlue);
            Reset.Start();
        }

        void PartStabilizeN2FillPressureBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            PartPressureDecayTestTimeBlue.Start();
        }

        void PartStabilizeN2FillPressureBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BlueManifoldTransducerPressure.Value > model.PDFinalChargePressureSetPoint.ProcessValue)
            {
                PartStabilizeN2FillPressureBlue.Pass();
            }
            else
            {
                PartStabilizeN2FillPressureBlue.Fail();
            }
        }

        void PartStabilizeN2FillPressureBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // add system message;
            IO.DOut.BlueLeftPartHighPressureFill.Disable();

        }


        void PartN2FillDumpBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // add system message;

            PartN2EvacuationBlue.Start();
            step.Stop();

        }

        void PartN2FillDumpBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //throw new NotImplementedException();
            CycleNoTest("High Pressure after Pressure Decay Dump Delay expired", "N2 Dump Timeout");
            //Reset.Start();
        }
        void PartN2FillDumpBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.BlueManifoldTransducerPressure.Value < model.PDN2DumpPressureSetPoint.ProcessValue)
            {
                IO.DOut.BlueLeftPartDump.Disable();
                PartN2FillDumpBlue.Pass();
            }
            else
            {
                PartN2FillDumpBlue.Fail();
            }
        }

        void PartN2FillDumpBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            ////if (Config.Mode.BlueLeftFillCheckHoseEnabled.ProcessValue)
            ////if ((IO.Signals.BlueManifoldTransducerPressure.Value < model.PDN2DumpPressureSetPoint.ProcessValue) && IO.DOut.BlueLeftPartDump.Value)

            //if ((IO.Signals.BlueeSideCheckHoseTransPress.Value < model.PDN2DumpPressureSetPoint.ProcessValue) && IO.DOut.BlueLeftPartDump.Value)
            //{   // pressure less than dump set point then close dump valve stabilize and check pressure is less than dump set point
            //    IO.DOut.BlueLeftPartDump.Disable();
            //    N2DumpCheckBlue = DateTime.Now;
            //}
            //else if (IO.Signals.BlueeSideCheckHoseTransPress.Value > model.PDN2DumpPressureSetPoint.ProcessValue && !IO.DOut.BlueLeftPartDump.Value)
            //{  // pressure rise open dump valve
            //    IO.DOut.BlueLeftPartDump.Enable();
            //}
            //if ((DateTime.Now - N2DumpCheckBlue).Seconds > 10 && !IO.DOut.BlueLeftPartDump.Value)  // quit early dump check
            //{
            //    PartN2FillDumpBlue.Pass();
            //}
        }

        void PartN2FillDumpBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartHighPressureFill.Disable();
            IO.DOut.BlueLeftPartEvac.Disable();
            IO.DOut.BlueLeftPartRecovery.Disable();
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            Thread.Sleep(500);
            //if (IO.DOut.BlueLeftPartEvac.Value || IO.DOut.BlueLeftPartRecovery.Value ||
            //        IO.DOut.BlueLeftPartTracergasHiFillPressure.Value ||
            //            IO.DOut.BlueLeftPartTracergasLowFillPressure.Value)
            //{ // checking for problems
            //    step.Stop();
            //}
            //else
            {
                IO.DOut.BlueLeftPartDump.Enable();
            }
        }

        void PartHighN2FillStartBlue_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // go to stabilize delay
            PartStabilizeN2FillPressureBlue.Start();
            PartHighN2FillStartBlue.Stop();
        }

        void PartHighN2FillStartBlue_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // set test result to failed n2 fill
            // go to dump
            // reset chamber process
            CycleNoTest("N2 Fill Pressure too Low");
            Reset.Start();
        }

        void PartHighN2FillStartBlue_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.BlueLeftPartHighPressureFill.Disable();
            if (IO.Signals.BlueManifoldTransducerPressure.Value < model.PDFinalChargePressureSetPoint.ProcessValue)
            {
                // Part did not reach PDFinalChargePressureSetPoint before charge delay expired
                // set test result
                PartHighN2FillStartBlue.Fail();
            }
            else
            {
                PartHighN2FillStartBlue.Pass();
            }


        }

        void PartHighN2FillStartBlue_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            if (IO.Signals.BlueManifoldTransducerPressure.Value > model.PDFinalChargePressureSetPoint.ProcessValue + model.PDFinalChargePressMaximumOvershoot.ProcessValue)
            {  // overshoot set point reached, stop early
                IO.DOut.BlueLeftPartHighPressureFill.Disable();
                PartHighN2FillStartBlue.Pass();
            }
            else
            {
                if (IO.DOut.BlueLeftPartEvac.Value || IO.DOut.BlueLeftPartDump.Value || IO.DOut.BlueLeftPartRecovery.Value)
                {
                    step.Stop();
                }
                else
                {
                    IO.DOut.BlueLeftPartHighPressureFill.Enable();
                }
            }

        }

        void PartHighN2FillStartBlue_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Prompt = string.Format(Localization.PartHighN2FillStartBlue_Prompt, "Blue");
            // Blue
            IO.DOut.BlueLeftPartTracergasHiFillPressure.Disable();
            IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
            IO.DOut.BlueLeftPartDump.Disable();
            IO.DOut.BlueLeftPartEvac.Disable();

            NumericParameter[] PramToShow = new NumericParameter[1] { model.PDFinalChargePressureSetPoint };
            step.ParametersToDisplay = PramToShow;

        }

    } // end brace for // public partial class CycleSteps : CycleStepsBase
}
