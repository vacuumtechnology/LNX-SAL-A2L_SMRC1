using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes;
//using VTI_EVAC_AND_DUAL_CHARGE.Data;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Enums;
using VTIWindowsControlLibrary.Interfaces;
using VTIWindowsControlLibrary.Classes.ManualCommands;
using VTIWindowsControlLibrary.Classes.ClientForms;

namespace VTI_EVAC_AND_SINGLE_CHARGE
{
    /// <summary>
    /// ManualCommandsClass
    /// Contains all of the methods that become "manual commands"
    /// Each method must be proceeded by the ManualCommand attribute to become a manual command
    /// The ManualCommand attribute takes care of getting the command onto the manual commands form
    /// and it handles the permissions to the commands.
    /// </summary>
    public class ManualCommands : ManualCommandsBase
    {
        [ManualCommand("SHOW ACTIVE CYCLE STEPS", true, CommandPermissionType.None)]
        public virtual void ShowActiveCycleSteps()
        {
            try
            {
                Config.Mode.ShowCycleSteps.ProcessValue = true;
            }
            catch (Exception e3)
            {
                VtiEvent.Log.WriteWarning("Error SHOW ACTIVE CYCLE STEPS form. " + e3.Message, VtiEventCatType.Manual_Command);
            }
        }
        [ManualCommand("SAVE CONFIG FILE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void SaveConfigGoodFile()
        {
            VTIWindowsControlLibrary.Classes.Util.SaveConfigGoodFile.Save();
        }
        [ManualCommand("VIEW PARAMETER CHANGE LOG", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewParamChangeLog()
        {
            VTIWindowsControlLibrary.Classes.ClientForms.ParamChangeLog.Show();
        }
        [ManualCommand("VIEW MANUAL CMD EXEC LOG", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewManualCmdExecLog()
        {
            VTIWindowsControlLibrary.Classes.ClientForms.ManualCmdExecLog.Show();
        }
        [ManualCommand("A TEST STEP", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ATestStep()
        {
           //// Machine.Cycle[Port.Blue].bStartDataPlot=true;
            //Machine.Cycle[0].bShowMessageCloseLiquidValve = true;
            //Machine.Cycle[0].bShowMessageFinalData = true;
            Machine.Cycle[0].bShowMessageForm = true;

            //string strConnectLennox = "";
            //if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
            //    strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            //if (strConnectLennox.Length > 0)
            //    if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            //strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            //strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            //if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            //if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            //VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

            //string strConnectVTIToLennox = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

            //Int16 port = 0;
            //string TestResult = "PASS_IT";

            //string TempTestType = "SQLTEST";

            //int TestNumber = 1;

            //Machine.Test[0].SerialNumber = "SQLTest1";

            ////Store to UutRecords
            //if (Machine.Test[port].ModelNumber == "")
            //{
            //    Machine.Test[port].ModelNumber = "DEFAULT";
            //}
            //Machine.Test[port].TestResult = TestResult;
            //if (strConnectVTIToLennox != "")
            //{
            //    try
            //    {
            //        //SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
            //        //SqlCommand cmd = new SqlCommand();
            //        Config.Control.TestResultTableName.ProcessValue = "UutRecords";
            //        // Set the test result and write the records
            //        String strSqlCmd =
            //"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
            //            //"insert into dbo.TestResult "+
            //"(SerialNo, ModelNo, DateTime, SystemID, OpID, TestType, TestResult, TestPort, Line, Station,TestNumber) " +
            //"values('" + Machine.Test[port].SerialNumber + "', '" +
            // Machine.Test[port].ModelNumber + "', '" +
            // DateTime.Now.ToString() + "', '" +
            // Config.Control.System_ID.ProcessValue + "', '" +
            // Machine.Test[port].OpID + "', '" +
            // TempTestType + "', '" +
            // Machine.Test[port].TestResult + "', '" +
            // "BLUE PORT" + "', '" +
            // Config.Control.LennoxLineNum + "', '" +
            // Config.Control.LennoxStationNum + "', '" +
            // string.Format("{0}", TestNumber) + "')";
            //        Console.WriteLine(strSqlCmd);

            //        Machine.Cycle[0].fnInsertATestRecord(strConnectVTIToLennox, strSqlCmd);
            //        if (Config.Control.RemoteConnectionString_VTI.ProcessValue != "")
            //        {
            //            Machine.Cycle[0].fnInsertATestRecord(Config.Control.RemoteConnectionString_VTI.ProcessValue, strSqlCmd);
            //        }

            //        //cmd.CommandText = strSqlCmd;
            //        //cmd.CommandType = CommandType.Text;
            //        //cmd.Connection = sqlConnection2;

            //        //sqlConnection2.Open();

            //        //cmd.ExecuteNonQuery();


            //        //sqlConnection2.Close();
            //    }
            //    catch (Exception Ex)
            //    {
            //        Console.WriteLine(Ex.Message);
            //        VtiEvent.Log.WriteError(Ex.Message);
            //    }
            //}





            //try
            //{
            //    IO.AOut.BlueCircuit2HiSideStartCountValue.Value = 1.0;
            //    IO.AOut.BlueCircuit2LoSideStartCountValue.Value = 2.0;
            //    IO.AOut.BlueCircuit2LoSideCountLimit.Value = 4.0;
            //    IO.AOut.BlueCircuit2HiSideCountLimit.Value = 3.0;
            //    Console.WriteLine(IO.AOut.BlueCircuit2HiSideStartCountValue.Value.ToString());
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        ////    try
        ////    {
        ////        SqlConnection sqlConnection1 = new SqlConnection(Config.Control.TestResultConnectionString.ProcessValue);
        ////        SqlCommand cmd = new SqlCommand();

        ////        // Set the test result and write the records
        ////        String strSqlCmd =
        ////"insert into " + Config.Control.TestResultTableName.ProcessValue + " " +
        ////            //"insert into dbo.TestResult "+
        ////"(SerialNo, ModelNo, RefName, ChargeWt, ChargeTarget, EvacPressure, EvacSetPoint, RORPressure, RORSetPoint, ElapsedTime, TestResult,ScaleChargeWt,Passed) " +
        ////"values('" +"SerialNumber" + "', '" +
        //// "Model" + "', '" +
        //// "R410A" + "', '" +
        //// string.Format("{0:0.00}", 24.0) + "', '" +
        //// string.Format("{0:0.00}", 24.1) + "', '" +
        //// string.Format("{0:0.000}", 0.5) + "', '" +
        //// string.Format("{0:0.000}", 1.0) + "', '" +
        //// string.Format("{0:0.000}", 2.0) + "', '" +
        //// string.Format("{0:0.000}", 5.0) + "', '" +
        //// string.Format("{0:0.0}", 120) + "', '" +
        //// "TestResult" +"', '" +
        //// string.Format("{0:0.00}",24.3) + "', '" +
        //// "0" +
        //// "')";

        ////        cmd.CommandText = strSqlCmd;
        ////        cmd.CommandType = CommandType.Text;
        ////        cmd.Connection = sqlConnection1;

        ////        sqlConnection1.Open();

        ////        cmd.ExecuteNonQuery();


        ////        sqlConnection1.Close();
        ////    }
        ////    catch (Exception Ex)
        ////    {
        ////        Console.WriteLine(Ex.Message);
        ////    }
        //    try
        //    {
        //        SqlConnection sqlConnection1 = new SqlConnection("Data Source = Nlquality; User ID = vtisql; Password = RheemVTI1;");
        //        SqlCommand cmd = new SqlCommand("CheckCompressorScan",sqlConnection1);
        //        object ReturnValue;
        //        //SqlCommand cmd = new SqlCommand("GetUnitModelNumber", sqlConnection1);

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.Add("serialnumber",SqlDbType.NVarChar);
        //        cmd.Parameters["serialnumber"].Direction = ParameterDirection.Input;
        //        cmd.Parameters["serialnumber"].Value = "Q011607331";
        //        cmd.Parameters["serialnumber"].Size = 25;

        //        SqlParameter returnParameter = cmd.Parameters.Add("RetVal", SqlDbType.Int);
        //        returnParameter.Direction = ParameterDirection.ReturnValue;

        //        //cmd.Parameters.Add("result", SqlDbType.Int);
        //        //cmd.Parameters["result"].Direction = ParameterDirection.Output;
        //        cmd.Connection = sqlConnection1;

        //        //cmd.Parameters.Add("modelnumber", SqlDbType.NVarChar);
        //        //cmd.Parameters["modelnumber"].Size = 25;
        //        //cmd.Parameters["modelnumber"].Direction = ParameterDirection.Output;


        //        sqlConnection1.Open();

        //        ReturnValue = cmd.ExecuteNonQuery();

        //        String TempString = cmd.Parameters["RetVal"].Value.ToString();
        //        //ReturnValue = cmd.ExecuteScalar();
        //        //string TempString = ReturnValue.ToString();

        //        //String TempString = cmd.ExecuteScalar().ToString
        //        //String TempString = cmd.Parameters["modelnumber"].Value.ToString();
        //        //Machine.Test[Port.Blue].StoredProcedureCheck=Convert.ToInt32(cmd.Parameters["result"].Value.ToString());

        //        sqlConnection1.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);

        //    }


        ////    MyStaticVariables.LeakRate = 1;
        ////    MyStaticVariables.TGFillBluePressure = 2;
        ////    MyStaticVariables.TGFillWhitePresure = 3;
        ////    MyStaticVariables.BackgroundSignal = 4;
        ////    MyStaticVariables.TestSignal = 5;
        ////    MyStaticVariables.ULPressureSetPoint = 6;
        ////    MyStaticVariables.RejectRate = 7;
        ////    MyStaticVariables.ChamberSplit = 8;
        ////    MyStaticVariables.ChamberTestPressure = 9;
        ////    MyStaticVariables.RoughTestPressure = 10;
        ////    MyStaticVariables.ForelineTestPressure = 11;
        ////    MyStaticVariables.PolyColdTestTemperature = 12;

        ////    MyStaticVariables.SerialNumberArray[0] = "SerialNum";

        ////    //try
        ////    {
        ////        // Set the test result and write the records
        ////        String strSqlCmd =
        ////"insert into dbo.UutRecords " +
        ////"(SerialNo, ModelNo, SystemID, OpID, TestResult, " +
        ////            //"LeakRate, elapsedtime, TestSignal, BackgroundSignal, ULPressureSetPoint, TGFillBluePressure, RejectRate) " +
        ////"ElapsedTime, LeakRate, TGFillBluePressure, TGFillWhitePressure, BackgroundSignal, TestSignal, ULPressureSetPoint, RejectRate, ChamberSplit, ChamberTestPressure, RoughTestPressure, ForelineTestPressure, PolyColdTestTemperature) " +
        ////"values('" + MyStaticVariables.SerialNumberArray[0] + "', '" +
        //// "ModelName" + "', '" +
        ////Config.Control.System_ID.ProcessValue + "', '" +
        ////Config.OpID + "', '" +
        ////"Test Result" + "', '" +
        ////            //IO.Signals.PressCheckPressSignal.Value + "', '" +
        ////IO.Signals.ElapsedTime.Value + "', '" +
        ////MyStaticVariables.LeakRate + "', '" +
        ////MyStaticVariables.TGFillBluePressure + "', '" +
        ////MyStaticVariables.TGFillWhitePresure + "', '" +
        ////MyStaticVariables.BackgroundSignal + "', '" +
        ////MyStaticVariables.TestSignal + "', '" +
        ////MyStaticVariables.ULPressureSetPoint + "', '" +
        ////MyStaticVariables.RejectRate + "', '" +
        ////MyStaticVariables.ChamberSplit + "', '" +
        ////MyStaticVariables.ChamberTestPressure + "', '" +
        ////MyStaticVariables.RoughTestPressure + "', '" +
        ////MyStaticVariables.ForelineTestPressure + "', '" +
        ////MyStaticVariables.PolyColdTestTemperature +
        ////"')";

        ////        VtiLib.Data.ExecuteCommand(strSqlCmd);
        ////    }
        ////    //catch
        ////    {
        ////    }

        }

        [ManualCommand("SPANISH", true, CommandPermissionType.AnyLoggedInUser)]
        public void Spanish()
        {
            Config.Control.Language.ProcessValue = Languages.Spanish;
            Config.Save();
            Machine.Cycle[0].bUpdateLanguage = true;
        }

        [ManualCommand("ENGLISH", true, CommandPermissionType.AnyLoggedInUser)]
        public void English()
        {
            Config.Control.Language.ProcessValue = Languages.English;
            Config.Save();
            Machine.Cycle[0].bUpdateLanguage = true;
        }

        [ManualCommand("ZERO REF2", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("ZERO WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ZeroCircuit1()
        {
            //IO.DOut.WhiteCircuit1FlowmeterReset.Enable();
            //Thread.Sleep(1000);
            //IO.DOut.WhiteCircuit1FlowmeterReset.Disable();
        }

        [ManualCommand("ZERO", true, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("ZERO REF1", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("ZERO BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ZeroCircuit2()
        {
            IO.DOut.BlueCircuit2FlowmeterReset.Enable();
            Thread.Sleep(1000);
            IO.DOut.BlueCircuit2FlowmeterReset.Disable();
        }


        [ManualCommand("OPEN BLUE HISIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void OpenBlueHisideCharge()
        {
            Machine.Cycle[0].bEnableHiSideCharge=true;
        }
        [ManualCommand("OPEN WHITE HISIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void OpenWhiteHisideCharge()
        {
            Machine.Cycle[1].bEnableHiSideCharge=true;
        }
        [ManualCommand("CLOSE BLUE HISIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void CloseBlueHisideCharge()
        {
            Machine.Cycle[0].bDisableHiSideCharge=true;
        }
        [ManualCommand("CLOSE WHITE HISIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void CloseWhiteHisideCharge()
        {
            Machine.Cycle[1].bDisableHiSideCharge=true;
        }

        [ManualCommand("OPEN BLUE LOWSIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void OpenBlueLowsideCharge()
        {
            Machine.Cycle[0].bEnableLowSideCharge=true;
        }
        [ManualCommand("OPEN WHITE LOWSIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void OpenWhiteLowsideCharge()
        {
            Machine.Cycle[1].bEnableLowSideCharge=true;
        }
        [ManualCommand("CLOSE BLUE LOWSIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void CloseBlueLowsideCharge()
        {
            Machine.Cycle[0].bDisableLowSideCharge=true;
        }
        [ManualCommand("CLOSE WHITE LOWSIDE CHARGE",false,CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void CloseWhiteLowsideCharge()
        {
            Machine.Cycle[1].bDisableLowSideCharge=true;
        }

        [ManualCommand("SERIAL NUMBER",true,CommandPermissionType.AnyLoggedInUser)]
        public virtual void SerialNumber()
        {
            bool QuitFlag=false;
            string TempString;
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    
                    string TempString1 = InputBox.Show(Localization.EnterSerialNumber,Localization.EnterSerialNumber);
                    if (TempString1 != "")
                    {
                        Machine.Cycle[0].sSerialNumberFromSNForm = TempString1;
                        Machine.Cycle[0].bSerialNumberFromSNForm = true;
                        MyStaticVariables.SerialNumberByMessBoxFlag = true;
                        //// Check to see if the ScannerText matches the SerialNumberPattern regex
                        //System.Text.RegularExpressions.Regex rSn = new System.Text.RegularExpressions.Regex(Config.Control.SerialNumberPattern);
                        //System.Text.RegularExpressions.Match mSn = rSn.Match(TempString1);

                        //if (mSn.Success)
                        //{
                        //    Machine.Test[0].SerialNumber = TempString1;
                        //    Machine.Test[1].SerialNumber = TempString1;

                        //    //default model
                        //    if ((Config.CurrentModel[0].Name == "Default") || (Config.CurrentModel[1].Name == "Default"))
                        //    {
                        //        //force model selection
                        //        if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Machine.Cycle[0].Idle.State == CycleStepState.InProcess))
                        //        {
                        //            if (Config.Mode.CheckStoredProcedureEnabled.ProcessValue)
                        //            {
                        //                Machine.Cycle[0].CheckStoredProcedure.Start();
                        //            }
                        //            else
                        //            {
                        //                Machine.Cycle[0].WaitForModelSelection.Start();
                        //            }
                        //        }
                        //        else if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue) && (Machine.Cycle[1].Idle.State == CycleStepState.InProcess))
                        //        {
                        //            if (Config.Mode.CheckStoredProcedureEnabled.ProcessValue)
                        //            {
                        //                Machine.Cycle[1].CheckStoredProcedure.Start();
                        //            }
                        //            else
                        //            {
                        //                Machine.Cycle[1].WaitForModelSelection.Start();
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Machine.Cycle[0].Idle.State == CycleStepState.InProcess))
                        //        {
                        //           Machine.Cycle[0].CycleStart();
                        //        }
                        //        //if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue) && (Machine.Cycle[1].Idle.State == CycleStepState.InProcess))
                        //        //{
                        //        //  Machine.Cycle[1].CycleStart();
                        //        //}
                        //    }
                        //}
                        //else
                        //{
                        //    MessageBox.Show(Machine.MainForm,"Invalid Serial Number Scan", "INVALID SERIAL NUMBER");
                        //}

                        //////serial number checks
                        ////if ((Config.Mode.SelectModelFromSerialNumber.ProcessValue) && (Machine.Test[0].SerialNumber.Length >= 7) && (Machine.Test[0].SerialNumber != "BLANK TEST"))
                        ////{
                        ////    //    //set the model from the serial number
                        ////    int StartChar = Convert.ToInt32(Config.Control.ModelInSerialNumberStartLocation.ProcessValue) - 1;
                        ////    int CodeLength = Convert.ToInt32(Config.Control.ModelInSerialNumberLength.ProcessValue);
                        ////    string SNModelCode = Machine.Test[0].SerialNumber.Substring(StartChar, CodeLength);

                        ////    try
                        ////    {
                        ////        //SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\VtiData.mdf;Integrated Security=True;Connect Timeout=30");
                        ////        SqlConnection sqlConnection1 = new SqlConnection(VTI_EVAC_AND_DUAL_CHARGE.Properties.Settings.Default.VtiDataConnectionString);
                        ////        SqlCommand cmd = new SqlCommand();
                        ////        Object returnValue;

                        ////        String sCommandText;
                        ////        String TempString3;


                        ////        //cmd.CommandText = "Select ModelNo from dbo.ModelParameters where ProcessValue = '180'";
                        ////        sCommandText = string.Format(Config.Control.ModelFromSNSQLString, SNModelCode);
                        ////        cmd.CommandText = sCommandText;
                        ////        cmd.CommandType = CommandType.Text;
                        ////        cmd.Connection = sqlConnection1;

                        ////        sqlConnection1.Open();
                        ////        returnValue = cmd.ExecuteScalar();
                        ////        sqlConnection1.Close();

                        ////        TempString3 = returnValue.ToString();

                        ////        if (TempString3 != null)
                        ////        {
                        ////            Config.CurrentModel[0].Load(TempString3);
                        ////            Config.CurrentModel[1].Load(TempString3);
                        ////        }
                        ////        else
                        ////        {
                        ////            Config.CurrentModel[0].LoadFrom(Config.DefaultModel);
                        ////            Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
                        ////        }
                        ////    }
                        ////    catch
                        ////    {
                        ////        Config.CurrentModel[0].LoadFrom(Config.DefaultModel);
                        ////        Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
                        ////    }

                        ////}

                        ////if (Config.Mode.EvacTestPassFromESEnabled.ProcessValue)
                        ////{
                        ////    QuitFlag = true;
                        ////    //check for ES pass record
                        ////    try
                        ////    {
                        ////        //SqlConnection sqlConnection1 = new SqlConnection("Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\VtiData.mdf;Integrated Security=True;Connect Timeout=30");
                        ////        SqlConnection sqlConnection2 = new SqlConnection(Config.Control.ESTestConnectionString.ProcessValue);
                        ////        SqlCommand cmd2 = new SqlCommand();
                        ////        Object returnValue;

                        ////        String sCommandText;
                        ////        String TempString4;


                        ////        //cmd.CommandText = "Select ModelNo from dbo.ModelParameters where ProcessValue = '180'";
                        ////        sCommandText = string.Format(Config.Control.ESTestSQLString.ProcessValue, Machine.Test[0].SerialNumber);
                        ////        cmd2.CommandText = sCommandText;
                        ////        cmd2.CommandType = CommandType.Text;
                        ////        cmd2.Connection = sqlConnection2;

                        ////        sqlConnection2.Open();
                        ////        returnValue = cmd2.ExecuteScalar();
                        ////        sqlConnection2.Close();

                        ////        TempString4 = returnValue.ToString();

                        ////        if (TempString4 != null)
                        ////        {
                        ////            QuitFlag = false;
                        ////        }
                        ////        else
                        ////        {
                        ////            if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                        ////            {
                        ////                Machine.Cycle[0].CycleFail(Localization.ESStationFailed, Localization.ESStationFailedTH);
                        ////            }
                        ////            if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                        ////            {
                        ////                Machine.Cycle[1].CycleFail(Localization.ESStationFailed, Localization.ESStationFailedTH);
                        ////            }
                        ////        }
                        ////    }
                        ////    catch (Exception e)
                        ////    {
                        ////        VtiEvent.Log.WriteError("Error Checking ES Database", VtiEventCatType.Application_Error, e.ToString());
                        ////        if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[0].CycleFail(Localization.ESStationFailed, Localization.ESStationFailedTH);
                        ////        }
                        ////        if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[1].CycleFail(Localization.ESStationFailed, Localization.ESStationFailedTH);
                        ////        }
                        ////    }
                        ////}

                        ////if (!QuitFlag)
                        ////{
                        ////    //default model
                        ////    if (Config.CurrentModel[0].Name == "Default")
                        ////    {
                        ////        //force model selection
                        ////        if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[0].WaitForModelSelection.Start();
                        ////        }
                        ////        if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[1].WaitForModelSelection.Start();
                        ////        }
                        ////    }
                        ////    else
                        ////    {
                        ////        if (Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[0].CycleStart();
                        ////        }
                        ////        if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                        ////        {
                        ////            Machine.Cycle[1].CycleStart();
                        ////        }
                        ////    }
                        ////}

                    }
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }



        //[ManualCommand("ATESTSTEP", true, CommandPermissionType.CheckPermissionWithWarning)]
        //public virtual void ATESTSTEP()
        //{
        //    Machine.Cycle[0].ATestStep.Start();
        //}










        [ManualCommand("VIEW EVENT VIEWER", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("VIEW SYSTEM LOG", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewEventViewer()
        {
            System.Diagnostics.Process.Start("notepad.exe", VtiEvent.Log.LogFileName);
            //VtiEvent.Viewer.Show(Machine.MainForm);
        }

        [ManualCommand("VIEW EDIT CYCLE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewEditCycle()
        {
            EditCycle.Show(Machine.MainForm);
        }

        [ManualCommand("VIEW MANUAL COMMANDS", false, CommandPermissionType.None)]
        public virtual void ViewManualCommands()
        {
            //ManualCommandsClass.Show(Program.MainForm);
            this.Show(Machine.MainForm);
        }

        [ManualCommand("VIEW METERS", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewMeters()
        {
            if (Properties.Settings.Default.DualPortSystem)
            {
                if (!Machine.SystemSignals[Port.Blue].Visible ||
                    !Machine.SystemSignals[Port.White].Visible)
                    Machine.SystemSignals[Port.Blue].Visible =
                    Machine.SystemSignals[Port.White].Visible = true;
                else
                    Machine.SystemSignals[Port.Blue].Visible =
                    Machine.SystemSignals[Port.White].Visible = false;
            }
            else
                Machine.SystemSignals[Port.Blue].Visible =
                    !Machine.SystemSignals[Port.Blue].Visible;
        }

        [ManualCommand("VIEW PERMISSIONS", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewPermissions()
        {
            Permissions.ShowDialog();
        }

        [ManualCommand("VIEW DATA PLOT", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewDataPlot()
        {
            Machine.DataPlotDockControl[Port.Blue].Show();
            if (Properties.Settings.Default.DualPortSystem)
                Machine.DataPlotDockControl[Port.White].Show();
        }

        [ManualCommand("VIEW SCHEMATIC", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewSchematic()
        {
            switch (MessageBox.Show(Localization.SchematicActiveQuestion, Localization.ViewSchematic, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Machine.Schematic.Show(true);
                    break;
                case DialogResult.No:
                    Machine.Schematic.Show(false);
                    break;
            }
        }

        [ManualCommand("VIEW DIGITAL IO", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ViewDigitalIO()
        {
            switch (MessageBox.Show(Localization.DigitalIOActiveQuestion, Localization.ViewDigitalIO, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    DigitalIO.Show(true);
                    break;
                case DialogResult.No:
                    DigitalIO.Show(false);
                    break;
            }
        }

        public virtual void InitializeCounter()
        {
            Int32 Tempint;
            Tempint = Machine.InitializeCounter;
        }

        [ManualCommand("LOGIN", true, CommandPermissionType.None)]
        [ManualCommand("LOGON", false, CommandPermissionType.None)]
        public virtual void Login()
        {
            //if (!MyStaticVariables.USBCounterError)
            {
                if (string.IsNullOrEmpty(Config.OpID))
                {
                    String tempOpId;
                    String tempLogIn;
                                        
                    //tempOpId = VtiLib.Data.OpIDfromPassword(KeyPad.Show(Localization.AskPassword, true, 80, 80, 1020, 460));  // tas 3/7/2013 added an overload for show
                    tempLogIn = KeyPad.Show(Localization.AskPassword, true, 80, 80, 1020, 460);  // tas 3/7/2013 added an overload for show
                    tempOpId = VtiLib.Data.OpIDfromPassword(tempLogIn);
                    
                    if (tempOpId != string.Empty)
                    {
                        Config.OpID = tempOpId;
                        Machine.Test[0].OpID = Config.OpID;
                        (Machine.MainForm.Controls["statusStrip1"] as StatusStrip).Items["OpID"].Text = Config.OpID;
                        VtiEvent.Log.WriteInfo("User '" + Config.OpID + "' logged in.", VtiEventCatType.Login);
                        Config.TestMode = TestModes.Autotest;
                        IO.DOut.EvacPumpEnable.Enable();
                    }
                    else
                    {
                        //check lennox login
                        string Tempsecuritylevel="";
                        string Tempfirstname="";
                        string Templastname="";

                        //Lennox Data Storage
                        //Call Lennox Stored Procedure ProcessStatusUpdate if a coil
                        // Assemble connection string from parameters defined by Jason Hass 3/8/2016
                        // RemoteConnectionString build
                        string strConnectLennox = "";
                        if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                            strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
                        if (strConnectLennox.Length > 0)
                            if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
                        strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
                        strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
                        if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
                        if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

                        VtiEvent.Log.WriteInfo("Lennox Conn String", VtiEventCatType.Database, strConnectLennox);

                        strConnectLennox = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

                        if (strConnectLennox != "")
                        {
                            try
                            {

                                SqlConnection sqlConnection2 = new SqlConnection(strConnectLennox);
                                SqlCommand cmd = new SqlCommand();
                                

                                string sCommandText = string.Format("Select securitylevel, firstname, lastname from dbo.security_users where decryptbadgeid like '{0}'", tempLogIn);
                                cmd.CommandText = sCommandText;
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = sqlConnection2;

                                sqlConnection2.Open();
                                SqlDataReader reader = cmd.ExecuteReader();
                                

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        string TempHeader = reader.GetName(i);
                                        string TempString = reader.GetValue(i).ToString();
                                        if (TempHeader == "securitylevel")
                                        {
                                            Tempsecuritylevel = TempString;
                                        }
                                        if (TempHeader == "firstname")
                                        {
                                            Tempfirstname = TempString;
                                        }
                                        if (TempHeader == "lastname")
                                        {
                                            Templastname = TempString;
                                        }
                                    }

                                }

                                sqlConnection2.Close();

                                if (Tempsecuritylevel != "")
                                {
                                    Config.OpID = Tempsecuritylevel;
                                    Machine.Test[0].OpID = Tempfirstname + " " + Templastname;
                                    (Machine.MainForm.Controls["statusStrip1"] as StatusStrip).Items["OpID"].Text = Machine.Test[0].OpID;
                                    VtiEvent.Log.WriteInfo("User '" + Machine.Test[0].OpID + "' logged in.", VtiEventCatType.Login);
                                    Config.TestMode = TestModes.Autotest;
                                    IO.DOut.EvacPumpEnable.Enable();

                                }
                                else
                                {

                                    VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                                    MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                                    this.Login();   // make the user try again

                                }

                                //Machine.Test[port].UutRecordID = TempString;
                            }
                            catch (Exception ex)
                            {
                                
                                Console.WriteLine(ex.Message);
                                VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                                MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                                this.Login();   // make the user try again

                            }
                        }



                        //VtiEvent.Log.WriteWarning("Invalid password entered.", VtiEventCatType.Login);
                        //MessageBox.Show(Localization.InvalidPassword, Application.ProductName);
                        //this.Login();   // make the user try again
                    }
                }
                else
                {
                    VtiEvent.Log.WriteWarning("User '" + Config.OpID + "' already logged in.", VtiEventCatType.Login);
                    MessageBox.Show(Localization.CurrentUser + "'" + Config.OpID + "' " + Localization.MustLogOff, Application.ProductName);
                }
            }
        }

        [ManualCommand("LOGOFF", true, CommandPermissionType.AnyLoggedInUser)]
        [ManualCommand("LOGOUT", false, CommandPermissionType.AnyLoggedInUser)]
        public virtual void Logoff()
        {
            //if (MessageBox.Show(Localization.AskLogOff, Application.ProductName, MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                VtiEvent.Log.WriteInfo("User '" + Config.OpID + "' logged off.", VtiEventCatType.Login);
                Config.OpID = string.Empty;
                (Machine.MainForm.Controls["statusStrip1"] as StatusStrip).Items["OpID"].Text = Localization.LoggedOff;
                IO.DOut.EvacPumpEnable.Disable();
                Config.TestMode = TestModes.Logoff;
                Machine.Cycle[0].bScannerTextSetFocusOnce = true;
            }
        }

        [ManualCommand("RESET", true, CommandPermissionType.AnyLoggedInUser)]
        public virtual void Reset()
        {
            try
            {
                Machine.Cycle[Port.Blue].Reset.Start();

                //Machine.Cycle[Port.White].Reset.Start();
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }

        [ManualCommand("RESET REF2", false, CommandPermissionType.AnyLoggedInUser)]
        [ManualCommand("RESET WHITE", false, CommandPermissionType.AnyLoggedInUser)]
        public virtual void ResetCircuit1()
        {
            Machine.Cycle[Port.White].Reset.Start();
        }

        [ManualCommand("RESET REF1", false, CommandPermissionType.AnyLoggedInUser)]
        [ManualCommand("RESET BLUE", false, CommandPermissionType.AnyLoggedInUser)]
        public virtual void ResetCircuit2()
        {
            Machine.Cycle[Port.Blue].Reset.Start();
        }


        public virtual void ShowMessageForm()
        {
            Machine.Message.Show();
        }

        public virtual void HideMessageForm()
        {
            Machine.Message.Hide();
        }

        [ManualCommand("SHUT DOWN", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ShutDownApp()
        {
            bool thrdError = false;

            //if (MessageBox.Show((Machine.Cycle[0].Idle.Enabled || !Config.Mode.BluePortEnabled.ProcessValue || Machine.Cycle[0].ScanSerialNumber2.Enabled) &&
            //                     (!Properties.Settings.Default.DualPortSystem || Machine.Cycle[1].Idle.Enabled || !Config.Mode.WhitePortEnabled.ProcessValue || Machine.Cycle[1].ScanSerialNumber2.Enabled) ?
            //    Localization.AskShutdown : Localization.AskShutdownNotIdle,
            //    Application.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK)
            //{
            try
            {
                Machine.MainForm.Cursor = Cursors.WaitCursor;

                VtiEvent.Log.WriteWarning("System shutting down...");

                VtiEvent.Log.WriteVerbose("Saving Configuration...");
                Config.Save();

                VtiEvent.Log.WriteVerbose("Stopping Machine Cycle...");
                Machine.Cycle[0].Stop();
                if (Machine.Cycle[0].ProcessThread != null && !Machine.Cycle[0].ProcessThread.Join(3000))
                {
                    thrdError = true;
                    VtiEvent.Log.WriteError("Error stopping the Machine Cycle Thread!");
                }

                if (Properties.Settings.Default.DualPortSystem)
                {
                    Machine.Cycle[Port.White].Stop();
                    if (Machine.Cycle[Port.White].ProcessThread != null && !Machine.Cycle[Port.White].ProcessThread.Join(3000))
                    {
                        thrdError = true;
                        VtiEvent.Log.WriteError("Error stopping the Machine Cycle Thread!");
                    }
                }
                VtiEvent.Log.WriteVerbose("Stopping I/O Interface...");
                Config.IO.Interface.TurnAllOff();
                Config.IO.Interface.Stop();
                if (Config.IO.Interface.ProcessThread != null && !Config.IO.Interface.ProcessThread.Join(3000))
                {
                    thrdError = true;
                    VtiEvent.Log.WriteError("Error stopping the I/O Interface Thread!");
                }

                //VtiEvent.Log.WriteVerbose("Stopping Temperature Control Thread...");
                //IO.SerialIn.TemperatureControl.Stop();
                //if (!IO.SerialIn.TemperatureControl.ProcessThread.Join(3000))
                //{
                //  thrdError = true;
                //  VtiEvent.Log.WriteError("Error stopping the Temperature Control Thread!");
                //}

                //VtiEvent.Log.WriteVerbose("Stopping Over Temp Control Thread...");
                //IO.SerialIn.OverTempControl.Stop();
                //if (!IO.SerialIn.OverTempControl.ProcessThread.Join(3000))
                //{
                //  thrdError = true;
                //  VtiEvent.Log.WriteError("Error stopping the Over Temp Control Thread!");
                //}

                if (thrdError)
                {
                    VtiEvent.Log.WriteVerbose("Terminating the application...");
                    Environment.Exit(-1);
                }
                else
                {
                    VtiEvent.Log.WriteVerbose("Exiting the application...");
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                VtiEvent.Log.WriteError("An error occurred shutting down the application!",
                  VtiEventCatType.Application_Error, e.ToString());
                VtiEvent.Log.WriteVerbose("Terminating the application...");
                Environment.Exit(-1);
            }
            //      }
        }

        [ManualCommand("AUTOTEST", true, CommandPermissionType.AnyLoggedInUser)]
        public virtual void AutoTest()
        {
            Config.TestMode = TestModes.Autotest;
        }

        [ManualCommand("MANUAL MODE", true, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ManualMode()
        {
            MyStaticVariables.ReadyToTest = false;

            //IO.DOut.ConveyorEnable.Disable();

            //if (Config.TestMode != TestModes.Manual)
            //{
            //    Config.TestMode = TestModes.Manual;

            //    for (int i = 0; i < 3; i++)
            //    {
            //        Machine.Cycle[i].CycleStop();


            //        // Reset Prompt
            //        Machine.OpForm.Prompt[i].Clear();
            //        Machine.OpForm.Prompt[i].AppendText(Localization.CurrentTestMode + ": " + Config.TestMode.ToString() + Environment.NewLine + Environment.NewLine);
            //    }
            //}
            //Config.TestMode = TestModes.Manual;
            Machine.Cycle[0].bManualMode = true;
        }
        /*
            [ManualCommand("RESET", true, CommandPermissionType.AnyLoggedInUser)]
            public virtual void Reset()
            {
              if (Config.TestMode == TestModes.Autotest)
              {
                Machine.Cycle[Port.Blue].CloseAllValves();
              }
              else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        */
        [ManualCommand("FLOWMETER CALIBRATION", true, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void FlowmeterCalibration()
        {
            //Machine.FlowmeterCalibrate.Show();
            Machine.Cycle[0].bDisplayFlowmeterCalibration = true;
        }
        public virtual void DisplayFlowmeterCalibration()
        {
            Machine.FlowmeterCalibrate.Show();
        }

        [ManualCommand("RUN DIAGNOSTICS", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void Diagnostics()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    Machine.Test[0].SerialNumber = "DIAGNOSTICS";
                    Machine.Cycle[0].CycleStart();
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else 
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        } 

        [ManualCommand("BLANK TEST", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void BlankTest()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                            if (MyStaticVariables.ReadyToTest)
                            {
                                if(Config.Mode.BlueCircuit2PortEnabled.ProcessValue)
                                {
                                  //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                                  Machine.Test[0].SerialNumber = "BLANK TEST";
                                  Machine.Cycle[0].CycleStart();
                                }
                                if (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)
                                {
                                    //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                                    if (Config.CurrentModel[1].Name != Config.CurrentModel[0].Name)
                                    {
                                        if (Config.CurrentModel[0].Name.ToUpper() == "DEFAULT")
                                        {
                                            Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
                                        }
                                        else
                                        {
                                            Config.CurrentModel[1].Load(Config.CurrentModel[0].Name);
                                        }
                                    }
                                    Machine.Test[1].SerialNumber = "BLANK TEST";
                                    Machine.Cycle[1].CycleStart();
                                }
                                return;
                            }
                            else
                            {
                                MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                            }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("EVAC LATE LEAK CHECK REF1", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("EVAC LATE LEAK CHECK BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void EvacLateLeakBlue()
        {
            MyStaticVariables.LateLeakCheckBlueTestInProgress = true;
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {

                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                    Machine.Test[0].SerialNumber = "EVAC LATE LEAK CHECK BLUE";
                        Machine.Cycle[0].CycleStart();
                  
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("EVAC LATE LEAK CHECK REF2", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("EVAC LATE LEAK CHECK WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void EvacLateLeakWhite()
        {
            MyStaticVariables.LateLeakCheckWhiteTestInProgress = true;
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {

                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                    Machine.Test[1].SerialNumber = "EVAC LATE LEAK CHECK REF2";
                        Machine.Cycle[1].CycleStart();

                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public virtual void DisplayInquire()
        {
            Inquire2.Show();
            //VTIWindowsControlLibrary.Classes.ClientForms.Inquire.Show();
        }

        [ManualCommand("INQUIRE", true, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void Inquire()
        {
            Machine.Cycle[Port.Blue].bDisplayInquireForm = true;
            //if (Machine.Cycle[0].Idle.State == CycleStepState.InProcess) // && (!Properties.Settings.Default.DualPortSystem || Machine.Cycle[1].IsIdle))
            {
                // Config.TestMode = TestModes.Inquire;
                // Rod Edit's 2010-05-10
               // VTIWindowsControlLibrary.Classes.ClientForms.Inquire.Show();
            }
            //else
            //    MessageBox.Show(Localization.SystemNotIdle, Application.ProductName);
        }

        public virtual void DisplaySelectModel()
        {

            bool bIsVisibleManualCommandsForm = IsVisible();
            if (bIsVisibleManualCommandsForm)
            {
                Hide();
            }

            //if (MyStaticVariables.ReadyToTest)
            if(Machine.Cycle[Port.Blue].Idle.State==CycleStepState.InProcess)
            {
                SelectModelForm.Show(Config.CurrentModel[Port.Blue], Config.DefaultModel);
                //SelectModelForm.Show(Config.CurrentModel[Port.White], Config.DefaultModel);
            }
            else
            {
                MessageBox.Show(Localization.SystemNotIdle, Application.ProductName);
            }


        }

        public virtual void DisplayWhiteSelectModel()
        {

            bool bIsVisibleManualCommandsForm = IsVisible();
            if (bIsVisibleManualCommandsForm)
            {
                Hide();
            }

            //if (MyStaticVariables.ReadyToTest)
            if(Machine.Cycle[Port.White].Idle.State==CycleStepState.InProcess)
            {
                SelectModelForm.Show(Config.CurrentModel[Port.White], Config.DefaultModel);
                //SelectModelForm.Show(Config.CurrentModel[Port.White], Config.DefaultModel);
            }
            else
            {
                MessageBox.Show(Localization.SystemNotIdle, Application.ProductName);
            }


        }


        //[ManualCommand("SELECT MODEL", !Config.Mode.PrechargeSystem.ProcessValue, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("SELECT MODEL", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("SELECT REF1 MODEL", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("SELECT BLUE MODEL", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void SelectModel()
        {
            Machine.Cycle[Port.Blue].bDisplaySelectModel = true;
        }

        [ManualCommand("SELECT REF2 MODEL", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("SELECT WHITE MODEL", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void SelectWhiteModel()
        {
            Machine.Cycle[Port.White].bDisplaySelectModel = true;
        }


        [ManualCommand("ACKNOWLEDGE WARNING", true, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void AcknowledgeWarning()
        {
            if (IO.Signals.BlueSupplyPressure.Value > Config.Pressure.Blue_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
            {
                Machine.Cycle[0].LowRefPressureWarning.Pass();
            }
            if (Properties.Settings.Default.DualPortSystem)
            {
                if (IO.Signals.WhiteSupplyPressure.Value > Config.Pressure.White_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                {
                    Machine.Cycle[1].LowRefPressureWarning.Pass();
                }
            }
            Machine.Cycle[0].LowOilWarning.Pass();
            if (Properties.Settings.Default.DualPortSystem)
            {
                Machine.Cycle[1].LowOilWarning.Pass();
            }
        }

        [ManualCommand("ACKNOWLEDGE", true, CommandPermissionType.None)]
        public virtual void Acknowledge()
        {
            MyStaticVariables.WaitForAcknowledgeFlagBlue = true;
            MyStaticVariables.WaitForAcknowledgeFlagWhite = true;
        }


        [ManualCommand("DISABLE WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void DisableCircuit1()
        {
            Config.Mode.WhiteCircuit1PortEnabled.ProcessValue = false;
            Config.Save();
            Machine.Cycle[Port.White].Reset.Start();

            //Machine.Cycle[Port.White].Reset.Start();            
        }
        [ManualCommand("ENABLE WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void EnableCircuit1()
        {
            Config.Mode.WhiteCircuit1PortEnabled.ProcessValue = true;
            Config.Save();
            Machine.Cycle[Port.White].Reset.Start();

            //Machine.Cycle[Port.White].Reset.Start();           

        }
        [ManualCommand("DISABLE BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void DisableCircuit2()
        {
            Config.Mode.BlueCircuit2PortEnabled.ProcessValue = false;
            Config.Save();
            Machine.Cycle[Port.Blue].Reset.Start();

            Machine.Cycle[Port.Blue].Reset.Start();            
        }
        [ManualCommand("ENABLE BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void EnableCircuit2()
        {
            Config.Mode.BlueCircuit2PortEnabled.ProcessValue = true;
            Config.Save();
            //Machine.Cycle[Port.Blue].Reset.Start();

            Machine.Cycle[Port.Blue].Reset.Start();       
        }

        [ManualCommand("SET SCALE OFFSET", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void SetScaleOffset()
        {
            Config.Control.ScaleWeightOffset.ProcessValue = IO.Signals.ScaleWeight.Value + Config.Control.ScaleWeightOffset;
            Config.Save();
        }

        [ManualCommand("ENABLE SCALE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void EnableScale()
            //Should Enable the scale once
        {
            Config.Mode.ScaleEnabled.ProcessValue = true; //value gets set to false in Reset
            Config.Save();
            
        }

        [ManualCommand("FORCE CHARGE BOTH", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceBothCharge()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue)&&(Config.Mode.WhiteCircuit1PortEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[0].SerialNumber = "FORCE CHARGE BOTH";
                        Machine.Test[0].ForceChargeFlag = true;
                        Machine.Cycle[0].CycleStart();
                        Machine.Test[1].SerialNumber = "FORCE CHARGE BOTH";
                        Machine.Test[1].ForceChargeFlag = true;
                        Machine.Cycle[1].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show(Localization.BothCircuitsNotEnabled, Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //[ManualCommand("FORCE CHARGE WHITE", true, CommandPermissionType.CheckPermissionWithWarning)]
        //public virtual void ForceCircuit1Charge()
        //{
        //    if (Config.TestMode == TestModes.Autotest)
        //    {
        //        if (MyStaticVariables.ReadyToTest)
        //        {
        //            if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue))
        //            {
        //                //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
        //                Machine.Test[1].SerialNumber = "FORCE WHITE CHARGE";
        //                Machine.Test[1].ForceChargeFlag = true;
        //                Machine.Cycle[1].CycleStart();
        //            }
        //            else
        //            {
        //                MessageBox.Show(Localization.Circuit1NotEnabled, Application.ProductName);
        //            }
        //            return;
        //        }
        //        else
        //        {
        //            MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
        //        }
        //    }
        //    else
        //        MessageBox.Show(
        //            Localization.MustBeInAutotest,
        //            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}

        [ManualCommand("FORCE CHARGE REF2", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("FORCE CHARGE WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceChargeWhiteByWeight()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[1].SerialNumber = "FORCE REF2 CHARGE";
                        string TempCharge = InputBox.Show("Enter Weight To Charge","ENTER WEIGHT","64");
                        if(TempCharge!="")
                        {
                            Config.DefaultModel.TotalCharge.ProcessValue = Convert.ToDouble(TempCharge);
                            Config.Save();
                            Config.CurrentModel[1].LoadFrom(Config.DefaultModel);
                            Machine.Test[1].ForceChargeFlag = true;
                            Machine.Cycle[1].CycleStart();
                        }
                    }
                    else
                    {
                        MessageBox.Show(Localization.Circuit1NotEnabled, Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("FORCE CHARGE", true, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("FORCE CHARGE REF1", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("FORCE CHARGE BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceChargeBlueByWeight()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue))
                    {
                        ////Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        //Machine.Test[0].SerialNumber = "FORCE CHARGE";
                        //string TempCharge = InputBox.Show("Enter Weight To Charge", "ENTER WEIGHT", "64");

                        //if (TempCharge != "")
                        //{
                        //    Config.DefaultModel.TotalCharge.ProcessValue = Convert.ToDouble(TempCharge);
                        //    Config.DefaultModel.MaximumChargeWeightError.ProcessValue = 0.02 * Convert.ToDouble(TempCharge);
                        //    Config.DefaultModel.MinimumChargeWeightError.ProcessValue = 0.02 * Convert.ToDouble(TempCharge);
                        //    Config.Save();
                        //    Config.CurrentModel[0].LoadFrom(Config.DefaultModel);
                        //    Machine.Test[0].ForceChargeFlag = true;
                        //    Machine.Cycle[0].CycleStart();
                        //}
                        if (IO.Signals.BlueSupplyPressure.Value < Config.Pressure.Blue_Refrigerant_Low_Pressure_Alarm_SetPoint.ProcessValue)
                        {
                            // An error occured updating the status of the unit,  Call a cycle step to display to notify the operator
                            Machine.Prompt[0].AppendText(Environment.NewLine + "LOW PRESSURE FAULT, CHECK REFRIGERANT SUPPLY" + Environment.NewLine);
                            return;
                        }
                        else
                        {
                            Machine.Test[0].SerialNumber = "FORCE CHARGE";
                            Machine.Test[0].ForceChargeFlag = true;
                            // all is good
                            Machine.Cycle[0].WaitForModelSelection.Start();
                        }
                    }
                    else
                    {
                        MessageBox.Show(Localization.Circuit1NotEnabled, Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
                
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        //[ManualCommand("FORCE CHARGE BLUE", true, CommandPermissionType.CheckPermissionWithWarning)]
        //public virtual void ForceCircuit2Charge()
        //{
        //    if (Config.TestMode == TestModes.Autotest)
        //    {
        //        if (MyStaticVariables.ReadyToTest)
        //        {
        //            if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue))
        //            {
        //                //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
        //                Machine.Test[0].SerialNumber = "FORCE BLUE CHARGE";
        //                Machine.Test[0].ForceChargeFlag = true;
        //                Machine.Cycle[0].CycleStart();
        //            }
        //            else
        //            {
        //                MessageBox.Show(Localization.Circuit2NotEnabled, Application.ProductName);
        //            }
        //            return;
        //        }
        //        else
        //        {
        //            MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
        //        }
        //    }
        //    else
        //        MessageBox.Show(
        //            Localization.MustBeInAutotest,
        //            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}


        [ManualCommand("FORCE LOW SIDE CHARGE W", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceLowSideCharge1()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue)&&(Config.Mode.WhiteCircuit1LowSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[1].SerialNumber = "FORCE LOW SIDE CHARGE";
                        Machine.Test[1].ForceLowSideChargeFlag = true;
                        Machine.Cycle[1].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show("WHITE CIRCUIT LOW SIDE NOT ENABLED", Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("FORCE HI SIDE CHARGE W", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceHiSideCharge1()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue) && (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[1].SerialNumber = "FORCE HI SIDE CHARGE";
                        Machine.Test[1].ForceHiSideChargeFlag = true;
                        Machine.Cycle[1].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show("WHITE CIRCUIT HIGH SIDE NOT ENABLED", Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("FINAL WEIGHT", false, CommandPermissionType.AnyLoggedInUser)]
        public virtual void FinalWeight()
        {
            if ((Machine.Cycle[Port.Blue].WaitForFINALWEIGHT.State == CycleStepState.InProcess) || (Machine.Cycle[Port.White].WaitForFINALWEIGHT.State == CycleStepState.InProcess))
            {
                MyStaticVariables.ReadyForFinalWeightFlag = true;
            }
        }

        [ManualCommand("START", false, CommandPermissionType.AnyLoggedInUser)]
        public virtual void StartEvacAndCharge()
        {
            if ((Machine.Cycle[Port.Blue].WaitForSTART.State == CycleStepState.InProcess) || (Machine.Cycle[Port.White].WaitForSTART.State == CycleStepState.InProcess))
            {
                MyStaticVariables.StartEvacAndChargeFlag = true;
            }
        }

        [ManualCommand("RECOVER REF2", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("RECOVER WHITE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void RecoverCircuit1()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest||(Machine.Cycle[Port.White].Idle.State==CycleStepState.InProcess)||!Machine.Test[Port.White].RunningATestFlag)
                {
                    if ((Config.Mode.WhiteCircuit1PortEnabled.ProcessValue) && (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[1].SerialNumber = "RECOVER REF2 CIRCUIT";
                        Machine.Test[1].RecoverUnitFlag = true;
                        Machine.Cycle[1].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show(Localization.Circuit1NotEnabled , Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
        [ManualCommand("FORCE LOW SIDE CHARGE B", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceLowSideCharge2()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Config.Mode.BlueCircuit2LowSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[0].SerialNumber = "FORCE LOW SIDE CHARGE";
                        Machine.Test[0].ForceLowSideChargeFlag = true;
                        Machine.Cycle[0].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show("BLUE CIRCUIT LOW SIDE NOT ENABLED", Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("FORCE HI SIDE CHARGE B", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void ForceHiSideCharge2()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[0].SerialNumber = "FORCE HI SIDE CHARGE";
                        Machine.Test[0].ForceHiSideChargeFlag = true;
                        Machine.Cycle[0].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show("BLUE CIRCUIT LOW SIDE NOT ENABLED", Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        [ManualCommand("RECOVER A UNIT", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void RecoverAUnit()
        {

        }
        [ManualCommand("RECOVER", true, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("RECOVER REF1", false, CommandPermissionType.CheckPermissionWithWarning)]
        [ManualCommand("RECOVER BLUE", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void RecoverCircuit2()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest ||(Machine.Cycle[Port.Blue].Idle.State==CycleStepState.InProcess)||!Machine.Test[Port.Blue].RunningATestFlag)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[0].SerialNumber = "RECOVER REF1 CIRCUIT";
                        Machine.Test[0].RecoverUnitFlag = true;
                        Machine.Cycle[0].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show(Localization.Circuit2NotEnabled, Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        [ManualCommand("RECOVER BOTH", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void RecoverBoth()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (MyStaticVariables.ReadyToTest)
                {
                    if ((Config.Mode.BlueCircuit2PortEnabled.ProcessValue) && (Config.Mode.BlueCircuit2HiSideEnabled.ProcessValue) && (Config.Mode.WhiteCircuit1PortEnabled.ProcessValue) && (Config.Mode.WhiteCircuit1HiSideEnabled.ProcessValue))
                    {
                        //Config.CurrentModel[i].LoadFrom(Config.DefaultModel);
                        Machine.Test[0].SerialNumber = "RECOVER BOTH";
                        Machine.Test[0].RecoverUnitFlag = true;
                        Machine.Cycle[0].CycleStart();

                        Machine.Test[1].SerialNumber = "RECOVER BOTH";
                        Machine.Test[1].RecoverUnitFlag = true;
                        Machine.Cycle[1].CycleStart();
                    }
                    else
                    {
                        MessageBox.Show(Localization.BothCircuitsNotEnabled, Application.ProductName);
                    }
                    return;
                }
                else
                {
                    MessageBox.Show(Localization.SystemNotReadyToTest, Application.ProductName);
                }
            }
            else
                MessageBox.Show(
                    Localization.MustBeInAutotest,
                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }


        [ManualCommand("VACUUM DIAGNOSTICS", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void VacuumDiagnostics()
        {
        }

        //}

        // not a good idea on large chambers with hydrolics
        //[ManualCommand("STAND BY", true, CommandPermissionType.CheckPermissionWithWarning)]
        //public virtual void StandBy()
        //{
        //    if (Machine.Cycle[0].IsIdle &&
        //        (!Properties.Settings.Default.DualPortSystem ||
        //         Machine.Cycle[1].IsIdle))
        //        Config.TestMode = TestModes.StandBy;
        //    else
        //        MessageBox.Show(Localization.SystemNotIdle, Application.ProductName);
        //}

        [ManualCommand("CLOSE ALL VALVES", false, CommandPermissionType.CheckPermissionWithWarning)]
        public virtual void CloseAllValves()
        {
            if (Config.TestMode == TestModes.Autotest)
            {
                if (Config.Mode.BlueCircuit2PortEnabled)
                {
                    Machine.Test[Port.Blue].SerialNumber = "Close All Valves";
                    Machine.Cycle[Port.Blue].CloseAllValves();
                }
            }
            else
            {
                MessageBox.Show(Localization.NotInAutoTestMode, Application.ProductName);
            }
        }

        /*
            [ManualCommand("Ready for Sequence", true, CommandPermissionType.CheckPermissionWithWarning)]
            public virtual void ReadyForSequence()
            {
              if (Config.TestMode == TestModes.Autotest)
              {
                if (Config.Mode.BluePortEnabled)
                {
                  Machine.Test[Port.Blue].SerialNumber = "Ready for Sequence";
                  Machine.Cycle[Port.Blue].ReadyForDummySequence();
                }
              }
            }
        */
    }
}
