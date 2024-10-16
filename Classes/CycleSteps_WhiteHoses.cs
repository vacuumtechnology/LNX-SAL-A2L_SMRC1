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
        public CycleStep PartHighN2FillStartWhite, 
            //PartFillCheckHoseWhite, 
            PartConnectorCheckWhite,
          PartStabilizeN2FillPressureWhite,
          PartN2FillDumpWhite, PartN2EvacuationWhite, PartTracerSquirtWhite, PartTracerDumpWhite, ParttracerEvacuationWhite,
          PartPressureDecayTestTimeWhite, PartTracerFillWhite
          ;

        public DateTime N2DumpCheckWhite { get; set; }
        public DateTime TracerDumpCheckWhite { get; set; }
        public DateTime TracerEvacCheckWhite { get; set; }

        public void CycleSteps_WhiteHoses_initialize()
        {

            PartConnectorCheckWhite = new CycleStep
            {
                ValveDelay = Config.Time.ConnectorCheckFillDelay,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure
            };
            PartConnectorCheckWhite.Started += new CycleStep.CycleStepEventHandler(PartConnectorCheckWhite_Started);
            PartConnectorCheckWhite.ValveDelayElapsed += new CycleStep.CycleStepEventHandler(PartConnectorCheckWhite_ValveDelayElapsed);
            PartConnectorCheckWhite.Tick += new CycleStep.CycleStepEventHandler(PartConnectorCheckWhite_Tick);
            PartConnectorCheckWhite.Passed += new CycleStep.CycleStepEventHandler(PartConnectorCheckWhite_Passed);
            PartConnectorCheckWhite.Failed += new CycleStep.CycleStepEventHandler(PartConnectorCheckWhite_Failed);

            PartHighN2FillStartWhite = new CycleStep
            {
                TimeDelay = model.PDChargeDelay,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure
            };
            PartHighN2FillStartWhite.Started += new CycleStep.CycleStepEventHandler(PartHighN2FillStartWhite_Started);
            PartHighN2FillStartWhite.Tick += new CycleStep.CycleStepEventHandler(PartHighN2FillStartWhite_Tick);
            PartHighN2FillStartWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartWhite_Elapsed);
            PartHighN2FillStartWhite.Failed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartWhite_Failed);
            PartHighN2FillStartWhite.Passed += new CycleStep.CycleStepEventHandler(PartHighN2FillStartWhite_Passed);

            PartStabilizeN2FillPressureWhite = new CycleStep
           {
               TimeDelay = model.PDPressureStabilizeDelay,
               DisplayDetailsOnPassFail = false,
               ProcessValue = IO.Signals.WhiteManifoldTransducerPressure,
               //DisplayElapsedTime = true

           };
            PartStabilizeN2FillPressureWhite.Started += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureWhite_Started);
            PartStabilizeN2FillPressureWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureWhite_Elapsed);
            PartStabilizeN2FillPressureWhite.Passed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureWhite_Passed);
            PartStabilizeN2FillPressureWhite.Failed += new CycleStep.CycleStepEventHandler(PartStabilizeN2FillPressureWhite_Failed);

            PartN2FillDumpWhite = new CycleStep
            {
                TimeDelay = model.PDN2DumpDelay,
                DisplayDetailsOnPassFail = false,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            PartN2FillDumpWhite.Started += new CycleStep.CycleStepEventHandler(PartN2FillDumpWhite_Started);
            PartN2FillDumpWhite.Tick += new CycleStep.CycleStepEventHandler(PartN2FillDumpWhite_Tick);
            PartN2FillDumpWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartN2FillDumpWhite_Elapsed);
            PartN2FillDumpWhite.Failed += new CycleStep.CycleStepEventHandler(PartN2FillDumpWhite_Failed);
            PartN2FillDumpWhite.Passed += new CycleStep.CycleStepEventHandler(PartN2FillDumpWhite_Passed);

            PartN2EvacuationWhite = new CycleStep
            {
                TimeDelay = model.N2EvacuationDelay,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure
            };
            PartN2EvacuationWhite.Started += new CycleStep.CycleStepEventHandler(PartN2EvacuationWhite_Started);
            PartN2EvacuationWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartN2EvacuationWhite_Elapsed);
            PartN2EvacuationWhite.Passed += new CycleStep.CycleStepEventHandler(PartN2EvacuationWhite_Passed);
            PartN2EvacuationWhite.Failed += new CycleStep.CycleStepEventHandler(PartN2EvacuationWhite_Failed);

            PartTracerSquirtWhite = new CycleStep
            {
                Prompt = Localization.PartTracerSquirtWhite_Prompt,
                TimeDelay = model.SquirtTestMeasureTime,
                ValveDelay = model.SquirtTestFillTime,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure
            };
            PartTracerSquirtWhite.Started += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_Started);
            PartTracerSquirtWhite.ValveDelayElapsed += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_ValveDelayElapsed);
            PartTracerSquirtWhite.Tick += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_Tick);
            PartTracerSquirtWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_Elapsed);
            PartTracerSquirtWhite.Passed += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_Passed);
            PartTracerSquirtWhite.Failed += new CycleStep.CycleStepEventHandler(PartTracerSquirtWhite_Failed);


            PartTracerDumpWhite = new CycleStep
            {
                //Prompt = Localization.PartTracerDumpWhite_Prompt,
                TimeDelay = model.TracerGasDumpTime,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            PartTracerDumpWhite.Started += new CycleStep.CycleStepEventHandler(PartTracerDumpWhite_Started);
            PartTracerDumpWhite.Tick += new CycleStep.CycleStepEventHandler(PartTracerDumpWhite_Tick);
            PartTracerDumpWhite.Elapsed += new CycleStep.CycleStepEventHandler(PartTracerDumpWhite_Elapsed);
            PartTracerDumpWhite.Passed += new CycleStep.CycleStepEventHandler(PartTracerDumpWhite_Passed);
            PartTracerDumpWhite.Failed += new CycleStep.CycleStepEventHandler(PartTracerDumpWhite_Failed);

            ParttracerEvacuationWhite = new CycleStep
            {
                Prompt = Localization.PartTracerEvacuationWhite_Prompt,
                TimeDelay = model.TracerGasEvacuationTime,
                ProcessValue = IO.Signals.WhiteManifoldTransducerPressure,
                //DisplayElapsedTime = true
            };
            ParttracerEvacuationWhite.Started += new CycleStep.CycleStepEventHandler(ParttracerEvacuationWhite_Started);
            ParttracerEvacuationWhite.Tick += new CycleStep.CycleStepEventHandler(ParttracerEvacuationWhite_Tick);
            ParttracerEvacuationWhite.Elapsed += new CycleStep.CycleStepEventHandler(ParttracerEvacuationWhite_Elapsed);
            ParttracerEvacuationWhite.Passed += new CycleStep.CycleStepEventHandler(ParttracerEvacuationWhite_Passed);
            ParttracerEvacuationWhite.Failed += new CycleStep.CycleStepEventHandler(ParttracerEvacuationWhite_Failed);


        }


        void PartConnectorCheckWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            ////throw new NotImplementedException();
            MyStaticVariables.WaitForAcknowledgeFlag = true;
            CycleNoTest("Right Part not connected", "Right Check Conn");
            VtiEvent.Log.WriteInfo(String.Format("Failed, White manifold connector check pressure: {0:0} psi", IO.Signals.WhiteManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //VtiEvent.Log.WriteInfo(String.Format("Failed, White check hose connector check pressure: {0:0} psi", IO.Signals.WhiteSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            //Machine.Test[Port.White].Result = Localization.PartConnectorCheckWhite_FailedPrompt;
            ChamberRough.Stop();
            BlowerStart.Stop();
            IO.DOut.WhiteRightPartDump.Enable();
            if (Config.Mode.BluePortEnabled.ProcessValue)
            {
                PartConnectorCheckBlue.Stop();
                PartHighN2FillStartBlue.Stop();
                IO.DOut.BlueLeftPartTracergasLowFillPressure.Disable();
                IO.DOut.BlueLeftPartHighPressureFill.Disable();
                Thread.Sleep(500);
                IO.DOut.BlueLeftPartDump.Enable();
            }
            ChamberVent.Start();
        }

        void PartConnectorCheckWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (model.ConnectorCheckProcess && Machine.Test[Port.White].SerialNumber != "BLANK TEST")
            //{
                VtiEvent.Log.WriteInfo(String.Format("Passed, White manifold connector check pressure: {0:0} psi", IO.Signals.WhiteManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //    VtiEvent.Log.WriteInfo(String.Format("Passed, White check hose connector check pressure: {0:0} psi", IO.Signals.WhiteSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            //}
            //else
            //{
            //    VtiEvent.Log.WriteInfo(String.Format("Connector check was not performed.  Disabled or BLANK TEST."), VtiEventCatType.Test_Cycle);
            //}
            PartHighN2FillStartWhite.Start();
            if (Config.Mode.BluePortEnabled.ProcessValue)
            {
                PartHighN2FillStartBlue.Start();
            }
            step.Stop();
        }

        void PartConnectorCheckWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            try
            {
               if (step.ElapsedTime.TotalSeconds > Config.Time.ConnectorCheckFillDelay.ProcessValue + Config.Time.ConnectorCheckStabilizeDelay.ProcessValue)
             {
            //        //Console.WriteLine(IO.Signals.WhiteManifoldTransducerPressure.Value);
                    //Console.WriteLine(IO.Signals.WhiteeSideCheckHoseTransPress.Value);
            //        //Console.WriteLine(Config.Pressure.ConnectorCheckFillPressureSetPoint.ProcessValue);
                    double ConnectorCheckManifoldFillMax;
            //      double ConnectorCheckFillCheckHoseMin;
                   if ((Machine.Test[Port.White].SerialNumber == "BLANK TEST")||MyStaticVariables.CalChamber||MyStaticVariables.ChamberCalibrationCheck)
                   {
                        // do not do a connector check on a blank test
                        step.Pass();
                    }
                    else
                    {
            //            if (Config.Mode.WhiteRightFillCheckHoseEnabled)
            //            {
            //                VtiEvent.Log.WriteInfo(String.Format("White fill check hose enabled."), VtiEventCatType.Test_Cycle);

            //                // Just make sure the pressure is rising on the check hose for connector check
            //                ConnectorCheckFillCheckHoseMin = IO.Signals.WhiteManifoldTransducerPressure.Value / 2;
            //                if (IO.Signals.WhiteSideCheckHoseTransPress.Value < ConnectorCheckFillCheckHoseMin)
            //                {
            //                    PartConnectorCheckWhite.Fail();
            //                }
            //                else
            //                {
            //                    PartConnectorCheckWhite.Pass();
            //                }
            //            }
            //            else
            //            {
                            // one hose connector check, if pressure exceeds ConnectorCheckFillPressureSetPoint fail con check
                            ConnectorCheckManifoldFillMax = Config.Pressure.ConnectorCheckFillPressureSetPoint.ProcessValue;
                           if (IO.Signals.WhiteManifoldTransducerPressure.Value > ConnectorCheckManifoldFillMax)
                            {
                                PartConnectorCheckWhite.Fail();
                            }
                            else
                            {
                                // passed connector check
                                PartConnectorCheckWhite.Pass();
                           }
            //            }
                  }

                }
            }
            catch (Exception ex)
            {
                // what happened
                VtiEvent.Log.WriteInfo(String.Format("An error occured in PartConnectorCheckWhite_Tick cycle step. " + ex.Message), VtiEventCatType.Application_Error);
            }

        }

        void PartConnectorCheckWhite_ValveDelayElapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {// wait Config.Time.ConnectorCheckFillDelay
            //IO.DOut.WhiteRightPartHighPressureFill.Disable();
            VtiEvent.Log.WriteInfo(String.Format("White manifold connector check fill pressure: {0:0} psi", IO.Signals.WhiteManifoldTransducerPressure.Value), VtiEventCatType.Test_Cycle);
            //VtiEvent.Log.WriteInfo(String.Format("White check hose connector check fill pressure: {0:0} psi", IO.Signals.WhiteSideCheckHoseTransPress.Value), VtiEventCatType.Test_Cycle);
            
        }

        void PartConnectorCheckWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if (Config.Mode.WhiteRightFillCheckHoseEnabled)
            //{
            //    AnalogSignal[] SignalToShow = new AnalogSignal[1] { (IO.Signals.WhiteSideCheckHoseTransPress) };
            //    step.SignalsToDisplay = SignalToShow;
            //}
            //if (IO.DOut.WhiteRightPartDump.Value || IO.DOut.WhiteRightPartEvac.Value || IO.DOut.WhiteRightPartRecovery.Value)
            //{
            //    step.Stop();
            //}
            //else
            //{
            //    IO.DOut.WhiteRightPartHighPressureFill.Enable();
            //}
            IO.DOut.WhiteRightPartDump.Disable();
            IO.DOut.WhiteRightPartEvac.Disable();
            IO.DOut.WhiteRightPartRecovery.Disable();
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            Thread.Sleep(500);
            IO.DOut.WhiteRightPartHighPressureFill.Enable();
            Thread.Sleep((int)(Config.Time.ConnectorCheckFillDelay.ProcessValue * 1000));
            IO.DOut.WhiteRightPartHighPressureFill.Disable();
        }

        void ParttracerEvacuationWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartEvac.Disable();
            CycleNoTest(ParttracerEvacuationWhite);
        }

        void ParttracerEvacuationWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartEvac.Disable();
        }

        void ParttracerEvacuationWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartEvac.Disable();
            //if (IO.Signals.WhiteManifoldTransducerPressure < model.TracerGasEvacuationPressure)
            {
                ParttracerEvacuationWhite.Pass();
            }
            //else
            //{
            //    ParttracerEvacuationWhite.Fail();
            //}
        }

        void ParttracerEvacuationWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            // possibly add a quit early evac check later (usually good to wait entire evacuation time)
            //if ((DateTime.Now - TracerEvacCheckWhite).Seconds > 5 && (IO.Signals.WhiteManifoldTransducerPressure.Value < model.TracerGasEvacuationPressure.ProcessValue) 
            //        && IO.DOut.WhiteRightPartEvac.Value)
            //{   // pressure less than evac set point then close evac valve stabilize and check pressure is less than evac set point
            //    IO.DOut.WhiteRightPartDump.Disable();
            //    TracerEvacCheckWhite = DateTime.Now;
            //}
            //else if (IO.Signals.WhiteManifoldTransducerPressure.Value > model.TracerGasEvacuationPressure.ProcessValue && !IO.DOut.WhiteRightPartEvac.Value)
            //{  // pressure rise open evac valve
            //    IO.DOut.WhiteRightPartDump.Enable();
            //}
            //if ((DateTime.Now - TracerEvacCheckWhite).Seconds > 10 && !IO.DOut.WhiteRightPartEvac.Value)  // quit early evac check
            //{
            //    ParttracerEvacuationWhite.Pass();
            //}
        }

        void ParttracerEvacuationWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Machine.Test[Port.White].FilledWithTracerGas)
            {
                //IO.DOut.TrashPumpPowerEnable.Enable();
                if (IO.DOut.WhiteRightPartHighPressureFill.Value || IO.DOut.WhiteRightPartDump.Value || IO.DOut.WhiteRightPartRecovery.Value)
                {
                    step.Stop();
                }
                else
                {
                    IO.DOut.WhiteRightPartEvac.Enable();
                }
            }
        }
        void PartTracerDumpWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest("White tracer gas dump timeout", "White TG dump timeout");
            //Reset.Start();
        }

        void PartTracerDumpWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if filled with helium pump it, otherwise, done
            if (Machine.Test[Port.White].FilledWithTracerGas) //  if (MyStaticVariables.FilledWithTracerGas)
            {
                ParttracerEvacuationWhite.Start();
                Machine.Test[Port.White].FilledWithTracerGas = false;
            }
        }
        void PartTracerDumpWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartDump.Disable();
            if ((IO.Signals.WhiteManifoldTransducerPressure.Value < model.TracerGasDumpPressure.ProcessValue))
            {   // pressure less than dump set point 
                PartTracerDumpWhite.Pass();
            }
            else if (IO.Signals.WhiteManifoldTransducerPressure.Value > model.TracerGasDumpPressure.ProcessValue)
            {
                PartTracerDumpWhite.Fail();
            }
        }

        void PartTracerDumpWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (Config.Mode.quitEarlyTracerGasDumpCheck.ProcessValue)
            {
                if ((DateTime.Now - TracerDumpCheckWhite).Seconds > 5 && (IO.Signals.WhiteManifoldTransducerPressure.Value < model.TracerGasDumpPressure.ProcessValue) && IO.DOut.WhiteRightPartDump.Value)
                {   // pressure less than dump set point then close dump valve stabilize and check pressure is less than dump set point
                    IO.DOut.WhiteRightPartDump.Disable();
                    TracerDumpCheckWhite = DateTime.Now;
                }
                else if (IO.Signals.WhiteManifoldTransducerPressure.Value > model.TracerGasDumpPressure.ProcessValue && !IO.DOut.WhiteRightPartDump.Value)
                {  // pressure rise open dump valve
                    IO.DOut.WhiteRightPartDump.Enable();
                }
                if ((DateTime.Now - TracerDumpCheckWhite).Seconds > 10 && !IO.DOut.WhiteRightPartDump.Value)  // quit early dump check
                {
                    PartTracerDumpWhite.Pass();
                }
            }
        }

        void PartTracerDumpWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartEvac.Disable();
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            Thread.Sleep(500);
            IO.DOut.WhiteRightPartDump.Enable();
        }

        void PartTracerFillWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // Monitor for high fine failures
            if (IO.Signals.ChamberFlowOzyear.Value > (model.FineTestRejectRate.ProcessValue*Config.Flow.HighFineTestRejectSetPoint.ProcessValue))
            {
                //if(!Config.Mode.BluePortEnabled.ProcessValue)
                {
                    //Failed during Fill Test
                    String TempString = string.Format("Fail During Fill {0:0.00} oz/yr", IO.Signals.ChamberFlowOzyear.Value);
                    CycleFail(TempString, TempString);
                                        
                }
                PartTracerDumpWhite.Start();
                if (Config.Mode.BluePortEnabled)
                {
                    PartTracerFillBlue.Stop();
                    PartTracerDumpBlue.Start();
                }

               // if(!Config.Mode.BluePortEnabled.ProcessValue)
                {
                    ChamberVent.Start();
                }
            }
            else
            {
                
                // Didn't reach tracer gas fill pressure or failed leak test
                String TempString = string.Format("TG Fill Low Press: {0:0.00} psig", IO.Signals.BlueManifoldTransducerPressure.Value);
                CycleNoTest(TempString, TempString);

                // Dump Tracer Gas 
                PartTracerDumpWhite.Start();
                if (Config.Mode.BluePortEnabled)
                {
                    PartTracerFillBlue.Stop();
                    PartTracerDumpBlue.Start();
                }
                //if(!Config.Mode.BluePortEnabled.ProcessValue)
                {
                    ChamberVent.Start();
                }
            }
        }
        void PartTracerFillWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (!Config.Mode.BluePortEnabled.ProcessValue)
            {
                // wait fine test delay
                TestFineDelay.Start();
            }
        }

        void PartTracerFillWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
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


            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            if (IO.Signals.WhiteManifoldTransducerPressure.Value >= model.TracerGasFillTargetPressure)
            {
                PartTracerFillWhite.Pass();
            }
            else
            {
                PartTracerFillWhite.Fail();
            }
        }

        void PartTracerFillWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (!Config.Mode.BluePortEnabled.ProcessValue)
            {

            }
            // Monitor for high fine failures
            if (IO.Signals.ChamberFlowOzyear.Value > (model.FineTestRejectRate.ProcessValue*Config.Flow.HighFineTestRejectSetPoint.ProcessValue))
            {
                step.Fail();
            }
        }

        void PartTracerFillWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.White].FilledWithTracerGas = true;
            IO.DOut.WhiteRightPartEvac.Disable();
            Thread.Sleep(500);
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Enable();
        }

        void PartTracerSquirtWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //throw new NotImplementedException();
            //IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            if (!Config.Mode.BluePortEnabled.ProcessValue)
            {
                String TempString = string.Format("Fail:Squirt {0:0.00 oz/yr}", IO.Signals.ChamberFlowOzyear.Value);
                CycleFail(TempString, TempString);

                ChamberVent.Start();
            }
            PartTracerDumpWhite.Start();
        }

        void PartTracerSquirtWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // fill it up
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            PartTracerFillWhite.Start();
        }

        void PartTracerSquirtWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
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
                    PartTracerSquirtWhite.Fail();
                }
            }
        }

        void PartTracerSquirtWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.ChamberFlowOzyear.Value < (Config.Flow.SquirtTestReject.ProcessValue * model.FineTestRejectRate.ProcessValue))
            {
                //Failed during Squirt Test
                PartTracerSquirtWhite.Pass();
            }
        }

        void PartTracerSquirtWhite_ValveDelayElapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
        }

        void PartTracerSquirtWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.White].FilledWithTracerGas = true;
            IO.DOut.WhiteRightPartEvac.Disable();
            Thread.Sleep(500);
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Enable();
        }


        void PartN2EvacuationWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest("White N2 Evacuation","White N2 Evac");
            ChamberVent.Start();
        }

        void PartN2EvacuationWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            MyStaticVariables.PDProofTestCompleteReadyForTestValveToOpen = true;
            step.Stop();
        }

        void PartN2EvacuationWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //IO.DOut.WhiteRightPartEvac.Disable();
            if (IO.Signals.WhiteManifoldTransducerPressure.Value < model.N2EvacuationSetPoint.ProcessValue)
            {
                PartN2EvacuationWhite.Pass();
            }
            else
            {
                PartN2EvacuationWhite.Fail();
            }
        }

        void PartN2EvacuationWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //IO.DOut.TrashPumpPowerEnable.Enable();
            IO.DOut.WhiteRightPartDump.Disable();
            IO.DOut.WhiteRightPartHighPressureFill.Disable();
            IO.DOut.WhiteRightPartRecovery.Disable();
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            Thread.Sleep(500);
            if (IO.DOut.WhiteRightPartHighPressureFill.Value || IO.DOut.WhiteRightPartDump.Value || IO.DOut.WhiteRightPartEvac.Value || IO.DOut.WhiteRightPartRecovery.Value)
            {
                step.Stop();
            }
            else
            {
                IO.DOut.WhiteRightPartEvac.Enable();
            }
        }

        void PartPressureDecayTestTimeWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleFail("Failed Pressure Decay", "Failed Pressure Decay");
            ChamberVent.Start();
        }

        void PartPressureDecayTestTimeWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            PartN2FillDumpWhite.Start();
        }

        void PartPressureDecayTestTimeWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.White].PDEndPressure = IO.Signals.WhiteManifoldTransducerPressure.Value;
            Machine.Test[Port.White].PDTestPressureDrop = Machine.Test[Port.White].PDStartPressure - Machine.Test[Port.White].PDEndPressure;

            if (Machine.Test[Port.White].PDTestPressureDrop > model.PDMaximumTestPressureDrop)
            { PartPressureDecayTestTimeWhite.Fail(); }
            else { PartPressureDecayTestTimeWhite.Pass(); }
        }

        void PartPressureDecayTestTimeWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            Machine.Test[Port.White].PDStartPressure = IO.Signals.WhiteManifoldTransducerPressure.Value;
        }

        void PartStabilizeN2FillPressureWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            CycleNoTest(PartStabilizeN2FillPressureWhite);
            Reset.Start();
        }

        void PartStabilizeN2FillPressureWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            PartPressureDecayTestTimeWhite.Start();
        }

        void PartStabilizeN2FillPressureWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.WhiteManifoldTransducerPressure.Value > model.PDFinalChargePressureSetPoint.ProcessValue)
            {
                PartStabilizeN2FillPressureWhite.Pass();
            }
            else
            {
                PartStabilizeN2FillPressureWhite.Fail();
            }
        }

        void PartStabilizeN2FillPressureWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // add system message;
            IO.DOut.WhiteRightPartHighPressureFill.Disable();

        }


        void PartN2FillDumpWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // add system message;

            PartN2EvacuationWhite.Start();
            step.Stop();

        }

        void PartN2FillDumpWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //throw new NotImplementedException();
            CycleNoTest("High Pressure after Pressure Decay Dump Delay expired", "N2 Dump Timeout");
            Reset.Start();
        }
        void PartN2FillDumpWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            if (IO.Signals.WhiteManifoldTransducerPressure.Value < model.PDN2DumpPressureSetPoint.ProcessValue)
            {
                IO.DOut.WhiteRightPartDump.Disable();
                PartN2FillDumpWhite.Pass();
            }
            else
            {
                PartN2FillDumpWhite.Fail();
            }
        }

        void PartN2FillDumpWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            //if ((IO.Signals.WhiteSideCheckHoseTransPress.Value < model.PDN2DumpPressureSetPoint.ProcessValue)
            //        && IO.DOut.WhiteRightPartDump.Value)
            //{   // pressure less than dump set point then close dump valve stabilize and check pressure is less than dump set point
            //    IO.DOut.WhiteRightPartDump.Disable();
            //    N2DumpCheckWhite = DateTime.Now;
            //}
            //else if (IO.Signals.WhiteSideCheckHoseTransPress.Value > model.PDN2DumpPressureSetPoint.ProcessValue && !IO.DOut.WhiteRightPartDump.Value)
            //{  // pressure rise open dump valve
            //    IO.DOut.WhiteRightPartDump.Enable();
            //}
            //if ((DateTime.Now - N2DumpCheckWhite).Seconds > 10 && !IO.DOut.WhiteRightPartDump.Value)  // quit early dump check
            //{
            //    PartN2FillDumpWhite.Pass();
            //}
        }

        void PartN2FillDumpWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartHighPressureFill.Disable();
            IO.DOut.WhiteRightPartEvac.Disable();
            IO.DOut.WhiteRightPartRecovery.Disable();
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            Thread.Sleep(500);

            IO.DOut.WhiteRightPartDump.Enable();
        }

        void PartHighN2FillStartWhite_Passed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // go to stabilize delay
            PartStabilizeN2FillPressureWhite.Start();
            PartHighN2FillStartWhite.Stop();
        }

        void PartHighN2FillStartWhite_Failed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            // set test result to failed n2 fill
            // go to dump
            // reset chamber process
            CycleNoTest("N2 Fill Pressure too Low");
            Reset.Start();
        }

        void PartHighN2FillStartWhite_Elapsed(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            IO.DOut.WhiteRightPartHighPressureFill.Disable();
            if (IO.Signals.WhiteManifoldTransducerPressure.Value < model.PDFinalChargePressureSetPoint.ProcessValue)
            {
                // Part did not reach PDFinalChargePressureSetPoint before charge delay expired
                // set test result
                PartHighN2FillStartWhite.Fail();
            }
            else
            {
                PartHighN2FillStartWhite.Pass();
            }


        }

        void PartHighN2FillStartWhite_Tick(CycleStep step, CycleStep.CycleStepEventArgs e)
        {

            if (IO.Signals.WhiteManifoldTransducerPressure.Value > model.PDFinalChargePressureSetPoint.ProcessValue + model.PDFinalChargePressMaximumOvershoot.ProcessValue)
            {  // overshoot set point reached, stop early
                IO.DOut.WhiteRightPartHighPressureFill.Disable();
                PartHighN2FillStartWhite.Pass();
            }
            else
            {
                if (IO.DOut.WhiteRightPartEvac.Value || IO.DOut.WhiteRightPartDump.Value || IO.DOut.WhiteRightPartEvac.Value || IO.DOut.WhiteRightPartRecovery.Value)
                {
                    step.Stop();
                }
                else
                {
                    IO.DOut.WhiteRightPartHighPressureFill.Enable();
                }
            }

        }

        void PartHighN2FillStartWhite_Started(CycleStep step, CycleStep.CycleStepEventArgs e)
        {
            step.Prompt = string.Format(Localization.PartHighN2FillStartWhite_Prompt, "White");
            // White
            IO.DOut.WhiteRightPartTracergasHiFillPressure.Disable();
            IO.DOut.WhiteRightPartTracergasLowFillPressure.Disable();
            IO.DOut.WhiteRightPartDump.Disable();
            IO.DOut.WhiteRightPartEvac.Disable();

            NumericParameter[] PramToShow = new NumericParameter[1] { model.PDFinalChargePressureSetPoint };
            step.ParametersToDisplay = PramToShow;

        }

    } // end brace for // public partial class CycleSteps : CycleStepsBase
}
