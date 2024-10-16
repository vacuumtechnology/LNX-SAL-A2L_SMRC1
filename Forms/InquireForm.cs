using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq.SqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTIWindowsControlLibrary.Classes.Data;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Data;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
//using VTI_EVAC_AND_DUAL_CHARGE.Data;
//using Excel12 = Microsoft.Office.Interop.Excel;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
  /// <summary>
  /// Represents the Inquire Form of the client application
  /// </summary>
  public partial class InquireForm2 : Form
  {
    private VtiDataContext db;

    /// <summary>
    /// Initializes a new instance of the Inquire Form
    /// </summary>
    public InquireForm2()
    {
      InitializeComponent();
    }

    private void buttonFindRecords_Click(object sender, EventArgs e)
    {
      //this.LookupSerialNumber(textBoxSerialNumber.Text);
        string FirstDate=this.dateTimePickerStart.Value.ToString();
        string LastDate= this .dateTimePickerEnd.Value.AddDays(1).ToString();
        try
        {

            string strConnectLennox = "";
            if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            if (strConnectLennox.Length > 0)
                if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            string strConnectVTI = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;


            string sqlCmd = string.Format(
                "select ID,SystemID,SerialNo,ModelNo,OpID,TestType,TestResult,DateTime,TestPort from dbo.UutRecords where SerialNo like '{0}' order by DateTime desc",
                textBoxSerialNumber.Text
                );
            SqlDataAdapter dap = new SqlDataAdapter(sqlCmd, strConnectVTI);
            DataSet ds = new DataSet();

            dap.Fill(ds);
            dataGridViewUUTRecords.DataSource = ds.Tables[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    /// <summary>
    /// Finds all data related to the specified serial number.
    /// </summary>
    /// <param name="SerialNumber">Serial number to look up</param>
    public void LookupSerialNumber(string SerialNumber)
    {
       
      //if (dataGridViewUUTRecords.InvokeRequired)
      //  dataGridViewUUTRecords.Invoke(new Action<string>(LookupSerialNumber), SerialNumber);
      //else {
      //  dataGridViewUUTRecords.DataSource =
      //      from uutRecord in db.UutRecords
      //      where SqlMethods.Like(uutRecord.SerialNo, SerialNumber) ||
      //        String.IsNullOrEmpty(SerialNumber) ||
      //        uutRecord.SerialNo.Contains(SerialNumber)
      //      //where uutRecord.SerialNo == SerialNumber
      //      select uutRecord;

      //  if (dataGridViewUUTRecords.Rows.Count > 0) {
      //    dataGridViewUUTRecordDetails.DataSource =
      //        from uutRecordDetail in db.UutRecordDetails
      //        where uutRecordDetail.UutRecordID == dataGridViewUUTRecords.Rows[0].Cells[0].Value as Nullable<long>
      //        select uutRecordDetail;
      //  } else {
      //    dataGridViewUUTRecordDetails.DataSource = null;
      //  }
      //}
    }

    private void dataGridViewUUTRecords_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            string strConnectLennox = "";
            if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            if (strConnectLennox.Length > 0)
                if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            string strConnectVTI = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

            String sqlCmd = string.Format(
        "select * from dbo.UutRecordDetails where UutRecordID = '{0}'", dataGridViewUUTRecords.SelectedCells[1].Value.ToString());

            SqlDataAdapter dap1 = new SqlDataAdapter(sqlCmd, strConnectVTI);
            DataSet ds1 = new DataSet();

            dap1.Fill(ds1);
            dataGridViewUUTRecordDetails.DataSource = ds1.Tables[0];

            //dataGridViewUUTRecordDetails2.DataSource =
            //    from uutRecordDetail in db.UutRecordDetails
            //    where uutRecordDetail.UutRecordID == dataGridViewUUTRecords2.Rows[e.RowIndex].Cells[0].Value as Nullable<long>
            //    select uutRecordDetail;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

      //dataGridViewUUTRecordDetails.DataSource =
      //    from uutRecordDetail in db.UutRecordDetails
      //    where uutRecordDetail.UutRecordID == dataGridViewUUTRecords.Rows[e.RowIndex].Cells[0].Value as Nullable<long>
      //    select uutRecordDetail;
    }

    private void buttonFilterRecords_Click(object sender, EventArgs e)
    {
        string FirstDate=this.dateTimePickerStart.Value.ToString();
        string LastDate= this .dateTimePickerEnd.Value.AddDays(1).ToString();
        try
        {

            string strConnectLennox = "";
            if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            if (strConnectLennox.Length > 0)
                if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            string strConnectVTI = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

            string sqlCmd = string.Format(
                "select ID,SystemID,SerialNo,ModelNo,OpID,TestType,TestResult,DateTime,TestPort from dbo.UutRecords where DateTime>= '{0}' and DateTime <= '{1}' order by DateTime desc",
                FirstDate, LastDate
                );
            SqlDataAdapter dap = new SqlDataAdapter(sqlCmd, strConnectVTI);
            DataSet ds = new DataSet();

            dap.Fill(ds);
            dataGridViewUUTRecords2.DataSource = ds.Tables[0];

                
            

            //if (dataGridViewUUTRecords2.Rows.Count > 0) 
            //{
            //    sqlCmd = string.Format(
            //        "select from dbo.UutRecordDetails where UutRecordID = '{0}'",dataGridViewUUTRecords2.Rows[0].Cells[0].Value.ToString());

            //    SqlDataAdapter dap1 = new SqlDataAdapter(sqlCmd, strConnectLennox);
            //    DataSet ds1 = new DataSet();

            //    dap1.Fill(ds1);
            //    dataGridViewUUTRecordDetails2.DataSource = ds1.Tables[0];

            //    //dataGridViewUUTRecordDetails2.DataSource =
            //    //from uutRecordDetail in db.UutRecordDetails
            //    // where uutRecordDetail.UutRecordID == dataGridViewUUTRecords2.Rows[0].Cells[0].Value as Nullable<long>
            //    //select uutRecordDetail;

            //} else {
            //    dataGridViewUUTRecordDetails2.DataSource = null;
            //}


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        

      //dataGridViewUUTRecords.DataSource =
      //    from uutRecord in db.UutRecords
      //    where
      //        uutRecord.DateTime.Date >= dateTimePickerStart.Value.Date &&
      //        uutRecord.DateTime.Date <= dateTimePickerEnd.Value.Date &&

      //        (SqlMethods.Like(uutRecord.SerialNo, textBoxSerialNumberFilter.Text) ||
      //          String.IsNullOrEmpty(textBoxSerialNumberFilter.Text) ||
      //          uutRecord.SerialNo.Contains(textBoxSerialNumberFilter.Text)) &&

      //        (SqlMethods.Like(uutRecord.ModelNo, textBoxModel.Text) || 
      //          String.IsNullOrEmpty(textBoxModel.Text) ||
      //          uutRecord.ModelNo.Contains(textBoxModel.Text)) &&

      //        (SqlMethods.Like(uutRecord.OpID, textBoxOperator.Text) || 
      //          String.IsNullOrEmpty(textBoxOperator.Text) ||
      //          uutRecord.OpID.Contains(textBoxOperator.Text)) &&

      //        (SqlMethods.Like(uutRecord.TestType, textBoxTestType.Text) || 
      //          String.IsNullOrEmpty(textBoxTestType.Text) ||
      //          uutRecord.TestType.Contains(textBoxTestType.Text)) &&

      //        (SqlMethods.Like(uutRecord.TestResult, textBoxTestResult.Text) || 
      //          String.IsNullOrEmpty(textBoxTestResult.Text) ||
      //          uutRecord.TestResult.Contains(textBoxTestResult.Text))
      //    select uutRecord;
      ////dataGridViewUUTRecords2.DataSource =
      ////    VtiLib.Data.UutRecords.Where(uutRecord => uutRecord.DateTime >= System.DateTime.Today);

      //if (dataGridViewUUTRecords2.Rows.Count > 0) {
      //  dataGridViewUUTRecordDetails2.DataSource =
      //      from uutRecordDetail in db.UutRecordDetails
      //      where uutRecordDetail.UutRecordID == dataGridViewUUTRecords2.Rows[0].Cells[0].Value as Nullable<long>
      //      select uutRecordDetail;
      //} else {
      //  dataGridViewUUTRecordDetails2.DataSource = null;
      //}
    }

    private void dataGridViewUutRecords2_RowEnter(object sender, DataGridViewCellEventArgs e)
    {
        try
        {
            string strConnectLennox = "";
            if (Config.Control.RemoteConnectionString_LennoxKeywords != "")
                strConnectLennox = Config.Control.RemoteConnectionString_LennoxKeywords;
            if (strConnectLennox.Length > 0)
                if (strConnectLennox.Substring(strConnectLennox.Length - 1) != ";" && strConnectLennox != "") strConnectLennox = strConnectLennox + ";";
            strConnectLennox = strConnectLennox + "Data Source = " + Config.Control.RemoteConnectionString_LennoxServerName.ProcessValue;
            strConnectLennox = strConnectLennox + "; Initial Catalog = " + Config.Control.RemoteConnectionString_LennoxDatabaseName.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue != "") strConnectLennox = strConnectLennox + "; UID = " + Config.Control.RemoteConnectionString_LennoxLogin.ProcessValue;
            if (Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue != "") strConnectLennox = strConnectLennox + "; PWD = " + Config.Control.RemoteConnectionString_LennoxPassword.ProcessValue;

            string strConnectVTI = Config.Control.RemoteConnectionString_VTIToLennox.ProcessValue;

            String sqlCmd = string.Format(
        "select * from dbo.UutRecordDetails where UutRecordID = '{0}'", dataGridViewUUTRecords2.SelectedCells[1].Value.ToString());

            SqlDataAdapter dap1 = new SqlDataAdapter(sqlCmd, strConnectVTI);
            DataSet ds1 = new DataSet();

            dap1.Fill(ds1);
            dataGridViewUUTRecordDetails2.DataSource = ds1.Tables[0];

            //dataGridViewUUTRecordDetails2.DataSource =
            //    from uutRecordDetail in db.UutRecordDetails
            //    where uutRecordDetail.UutRecordID == dataGridViewUUTRecords2.Rows[e.RowIndex].Cells[0].Value as Nullable<long>
            //    select uutRecordDetail;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void buttonExportData_Click(object sender, EventArgs e)
    {
      // The following commented-out block of code used Microsoft Interopt features to
      // create a spreadsheet.  I'm leaving it here for now since it worked and it's a
      // good example.  RWP 7/23/09
      //Object missing = System.Reflection.Missing.Value;
      //Excel12.Application ExcelApp = new Excel12.Application();
      //Excel12.Workbook workbook = ExcelApp.Workbooks.Add(missing);
      //Excel12.Sheets sheets = ExcelApp.Worksheets;
      //Excel12.Worksheet sheet1 = (Excel12.Worksheet)ExcelApp.Worksheets.get_Item("Sheet1");
      //Excel12.Range range;
      //sheet1.Name = "UUT Records";

      //// Export titles
      //for (int j = 0; j < dataGridViewUUTRecords2.Columns.Count; j++)
      //{
      //    range = (Excel12.Range)sheet1.Cells[1, j + 1];
      //    range.Value2 = dataGridViewUUTRecords2.Columns[j].HeaderText;
      //}

      //// Export data
      //for (int i = 0; i < dataGridViewUUTRecords2.Rows.Count - 1; i++)
      //{
      //    for (int j = 0; j < dataGridViewUUTRecords2.Columns.Count; j++)
      //    {
      //        range = (Excel12.Range)sheet1.Cells[i + 2, j + 1];
      //        range.Value2 = dataGridViewUUTRecords2[j, i].Value;
      //        if (j == 3) range.NumberFormat = "m/d/yyyy";
      //    }
      //}

      ////Excel12.Worksheet sheet2 = (Excel12.Worksheet)ExcelApp.Worksheets.get_Item("Sheet2");
      ////sheet2.Name = "UUT Record Details";

      //workbook.SaveAs(@"C:\exceltest.xls",
      //    Excel12.XlFileFormat.xlXMLSpreadsheet, missing, missing,
      //    false, false, Excel12.XlSaveAsAccessMode.xlNoChange,
      //    missing, missing, missing, missing, missing);

      //workbook.Close(false, missing, missing);
      //workbook = null;

      //ExcelApp.Quit();
      //ExcelApp = null;

      //GC.Collect();

      String delimiter;
      if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
        System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.FileName);

        if (saveFileDialog1.FilterIndex == 1)
          delimiter = ",";
        else
          delimiter = "\t";

        //if (!checkBoxIncludeDetails.Checked)
        //{
            // Write header line
            string strheader = dataGridViewUUTRecords2.Columns[0].HeaderText;
            for (int i=1;i<dataGridViewUUTRecords2.Columns.Count;i++)
            {             
               strheader=strheader+delimiter+ dataGridViewUUTRecords2.Columns[i].HeaderText;
            }
            sw.WriteLine(strheader);
          //sw.WriteLine(String.Join(delimiter,
          //    new[] {
          //                  "ID",
          //                  "Serial Number",
          //                  "System ID",
          //                  "Operator",
          //                  "Model Number",
          //                  "Date Time",
          //                  "Test Type",
          //                  "Test Result",
          //                  "Test Port",
          //                  "Elapsed Time",
          //                  "LeakRate",
          //                  "TGFillBluePressure",
          //                  "BackgroundSignal",
          //                  "TestSignal",
          //                  "ULPressureSetPoint",
          //                  "RejectRate",
          //                  "ChamberSplit",
          //                  "ChamberTestPressure",
          //                  "RoughTestPressure",
          //                  "ForelineTestPressure",
          //                  "PolyColdTestTemperature",
          //                  "TGFillWhitePressure"
          //              }));
        //} //else {
          // Write header line
          //sw.WriteLine(String.Join(delimiter,
          //    new[] {
          //                  "ID",
          //                  "Serial Number",
          //                  "System ID",
          //                  "Operator",
          //                  "Model Number",
          //                  "Date Time",
          //                  "Test Type",
          //                  "Test Result",
          //                  "Detail ID",
          //                  "Detail Date Time",
          //                  "Detail Test Type",
          //                  "Detail Test Result",
          //                  "Value Name",
          //                  "Value",
          //                  "Min Setpoint Name",
          //                  "Min Setpoint Value",
          //                  "Max Setpoint Name",
          //                  "Max Setpoint Value",
          //                  "Units",
          //                  "Elapsed Time"
          //              }));
        //}

        // Write UUT Records
        for(int irow=0;irow<dataGridViewUUTRecords2.Rows.Count; irow++)
        {
           string strrow = "";
           try
           {
               strrow=dataGridViewUUTRecords2.Rows[irow].Cells[0].Value.ToString();
           }
           catch
           {
               strrow = " ";
           }
           for(int icol=1;icol<dataGridViewUUTRecords2.Columns.Count; icol++)
           {
              strrow = strrow + delimiter + dataGridViewUUTRecords2.Rows[irow].Cells[icol].Value.ToString();
           }
           sw.WriteLine(strrow);
        }

        //foreach (var uutRecord in
        //    from uutRecord in db.UutRecords
        //    where
        //        uutRecord.DateTime.Date >= dateTimePickerStart.Value.Date &&
        //        uutRecord.DateTime.Date <= dateTimePickerEnd.Value.Date &&
        //        (String.IsNullOrEmpty(textBoxSerialNumberFilter.Text) ||
        //         uutRecord.SerialNo.Contains(textBoxSerialNumberFilter.Text)) &&
        //        (String.IsNullOrEmpty(textBoxModel.Text) ||
        //         uutRecord.ModelNo.Contains(textBoxModel.Text)) &&
        //        (String.IsNullOrEmpty(textBoxOperator.Text) ||
        //         uutRecord.OpID.Contains(textBoxOperator.Text)) &&
        //        (String.IsNullOrEmpty(textBoxTestType.Text) ||
        //         uutRecord.TestType.Contains(textBoxTestType.Text)) &&
        //        (String.IsNullOrEmpty(textBoxTestResult.Text) ||
        //         uutRecord.TestResult.Contains(textBoxTestResult.Text))
        //    select uutRecord) {
        //  sw.WriteLine(String.Join(delimiter,
        //      new[] {
        //                    uutRecord.ID.ToString(),
        //                    uutRecord.SerialNo,
        //                    uutRecord.SystemID,
        //                    uutRecord.OpID,
        //                    uutRecord.ModelNo,
        //                    uutRecord.DateTime.ToString(),
        //                    uutRecord.TestType,
        //                    uutRecord.TestResult,
        //                    uutRecord.TestPort,
        //                    //uutRecord.ElapsedTime.ToString(),
        //                    //uutRecord.LeakRate.ToString(),
        //                    //uutRecord.TGFillBluePressure.ToString(),
        //                    //uutRecord.BackgroundSignal.ToString(),
        //                    //uutRecord.TestSignal.ToString(),
        //                    //uutRecord.ULPressureSetPoint.ToString(),
        //                    //uutRecord.RejectRate.ToString(),
        //                    //uutRecord.ChamberSplit.ToString(),
        //                    //uutRecord.ChamberTestPressure.ToString(),
        //                    //uutRecord.RoughTestPressure.ToString(),
        //                    //uutRecord.ForelineTestPressure.ToString(),
        //                    //uutRecord.PolyColdTestTemperature.ToString(),
        //                    //uutRecord.TGFillWhitePressure.ToString()
        //                }));

        //  if (checkBoxIncludeDetails.Checked) {
        //    foreach (var uutRecordDetail in uutRecord.UutRecordDetails) {
        //      sw.WriteLine(String.Join(delimiter,
        //          new[] {
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            String.Empty,
        //                            uutRecordDetail.ID.ToString(),
        //                            uutRecordDetail.DateTime.ToString(),
        //                            uutRecordDetail.Test,
        //                            uutRecordDetail.Result,
        //                            uutRecordDetail.ValueName,
        //                            uutRecordDetail.Value.ToString(),
        //                            uutRecordDetail.MinSetpointName,
        //                            uutRecordDetail.MinSetpoint.ToString(),
        //                            uutRecordDetail.MaxSetpointName,
        //                            uutRecordDetail.MaxSetpoint.ToString(),
        //                            uutRecordDetail.Units,
        //                            uutRecordDetail.ElapsedTime.ToString()
        //                        }));
        //    }
        //  }
        //}
        sw.Close();
      }
    }

    private void InquireForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing) {
        this.Hide();
        e.Cancel = true;
      }
      db.Dispose();
    }

    private void InquireForm_VisibleChanged(object sender, EventArgs e)
    {
      if (Visible) {
        //db = new VtiDataContext(VtiLib2.ConnectionString);
          db = new VtiDataContext(Properties.Settings.Default.VtiDataConnectionString);

        dateTimePickerStart.Value = System.DateTime.Now.Date;
        dateTimePickerEnd.Value = System.DateTime.Now.Date;
        textBoxSerialNumber.Text = String.Empty;
        textBoxModel.Text = String.Empty;
        textBoxTestType.Text = String.Empty;
        textBoxTestResult.Text = String.Empty;
      }
    }
  }
}
