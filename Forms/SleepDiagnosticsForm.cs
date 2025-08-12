using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    public partial class SleepDiagnosticsForm : Form
    {

        Label[] InitialBasePressureCheckTime;
        Label[] InitialBasePressureCheckPressure;
        Label[] SystemEvacuationTimeInHr;
        Label[] SystemEvacuationPressure;
        Label[] FinalBasePressureCheckTime;
        Label[] FinalBasePressureCheckPressure;
        Label[] ROR1Initialtime;
        Label[] ROR1InitialPressure;
        Label[] ROR1Finaltime;
        Label[] ROR1FinalPressure;
        Label[] ROR1mtorrPerMin;
        Label[] RepeatEvac1Time;
        Label[] RepeatEvac1Pressure;
        Label[] ROR2Initialtime;
        Label[] ROR2InitialPressure;
        Label[] ROR2Finaltime;
        Label[] ROR2FinalPressure;
        Label[] ROR2mtorrPerMin;
        Label[] RepeatEvac2Time;
        Label[] RepeatEvac2Pressure;
        Label[] ROR3Initialtime;
        Label[] ROR3InitialPressure;
        Label[] ROR3Finaltime;
        Label[] ROR3FinalPressure;
        Label[] ROR3mtorrPerMin;
        Label[] Result;
        Label[] Date;

        public SleepDiagnosticsForm()
        {
            InitializeComponent();
            
        InitialBasePressureCheckTime        = new Label[1] { label4};
        InitialBasePressureCheckPressure    = new Label[1] { label5};
        SystemEvacuationTimeInHr            = new Label[1] { label7};
        SystemEvacuationPressure            = new Label[1] { label27};
        FinalBasePressureCheckTime          = new Label[1] { label10};
        FinalBasePressureCheckPressure      = new Label[1] { label44};
        ROR1Initialtime                     = new Label[1] { label20};
        ROR1InitialPressure                 = new Label[1] { label21};
        ROR1Finaltime                       = new Label[1] { label24};
        ROR1FinalPressure                   = new Label[1] { label25};
        ROR1mtorrPerMin                     = new Label[1] { label8};
        RepeatEvac1Time                     = new Label[1] { label45};
        RepeatEvac1Pressure                 = new Label[1] { label46};
        ROR2Initialtime                     = new Label[1] { label30};
        ROR2InitialPressure                 = new Label[1] { label28};
        ROR2Finaltime                       = new Label[1] { label22};
        ROR2FinalPressure                   = new Label[1] { label18};
        ROR2mtorrPerMin                     = new Label[1] { label13};
        RepeatEvac2Time                     = new Label[1] { label47};
        RepeatEvac2Pressure                 = new Label[1] { label48};
        ROR3Initialtime                     = new Label[1] { label40};
        ROR3InitialPressure                 = new Label[1] { label39};
        ROR3Finaltime                       = new Label[1] { label37};
        ROR3FinalPressure                   = new Label[1] { label36};
        ROR3mtorrPerMin                     = new Label[1] { label34};
        Result                              = new Label[1] { label101};
            Date = new Label[1] { DateLabel};
        }

        public void ClearInitialBasePressCheckData(int port1)
        {
            InitialBasePressureCheckTime[port1].Text = "- sec";
            InitialBasePressureCheckPressure[port1].Text = "- mtorr";
        }
        public void ClearSystemEvacutionData(int port1)
        {
            SystemEvacuationTimeInHr[port1].Text = "- hr";
            SystemEvacuationPressure[port1].Text = "- mtorr";
        }
        public void ClearFinalBasePressCheckData(int port1)
        {
            FinalBasePressureCheckTime[port1].Text = "- sec";
            FinalBasePressureCheckPressure[port1].Text = "- mtorr";
        }
        public void ClearRORtoHosesOnGunsData(int port1)
        {
            ROR1Initialtime[port1].Text = "-";
            ROR1InitialPressure[port1].Text = "-";
            ROR1Finaltime[port1].Text = "-";
            ROR1FinalPressure[port1].Text = "-";
            ROR1mtorrPerMin[port1].Text = "-";
            ROR1mtorrPerMin[port1].ForeColor = Color.Black;
        }
        public void ClearRepeatEvac1Data(int port1)
        {
            RepeatEvac1Time[port1].Text = "-";
            RepeatEvac1Pressure[port1].Text = "-";
        }
        public void ClearRORtoGunsData(int port1)
        {
            ROR2Initialtime[port1].Text = "-";
            ROR2InitialPressure[port1].Text = "-";
            ROR2Finaltime[port1].Text = "-";
            ROR2FinalPressure[port1].Text = "-";
            ROR2mtorrPerMin[port1].Text = "-";
            ROR2mtorrPerMin[port1].ForeColor = Color.Black;
        }
        public void ClearRepeatEvac2Data(int port1)
        {
            RepeatEvac2Time[port1].Text = "-";
            RepeatEvac2Pressure[port1].Text = "-";
        }
        public void ClearRORWithoutGunsData(int port1)
        {
            ROR3Initialtime[port1].Text = "-";
            ROR3InitialPressure[port1].Text = "-";
            ROR3Finaltime[port1].Text = "-";
            ROR3FinalPressure[port1].Text = "-";
            ROR3mtorrPerMin[port1].Text = "-";
            ROR3mtorrPerMin[port1].ForeColor = Color.Black;
        }
        public void ClearResultData(int port1)
        {
            Result[port1].Text = "-";
        }

        public void SetDate(int port1,string Date1)
        {
           Date[port1].Text = Date1;
        }

        public void InsertInitialBasePressCheckData(int port1,double time1, double Pressure1)
        {
            InitialBasePressureCheckTime[port1].Text = $"{time1:0} sec";
            InitialBasePressureCheckPressure[port1].Text = $"{Pressure1:0} mtorr";
        }
        public void InsertSystemEvacutionData(int port1, double time1, double Pressure1)
        {
            SystemEvacuationTimeInHr[port1].Text = $"{time1:0.0} hr";
            SystemEvacuationPressure[port1].Text = $"{Pressure1:0} mtorr";
        }
        public void InsertFinalBasePressCheckData(int port1, double time1, double Pressure1)
        {
            FinalBasePressureCheckTime[port1].Text = $"{time1:0} sec";
            FinalBasePressureCheckPressure[port1].Text = $"{Pressure1:0} mtorr";
        }
        public void InsertRORtoHosesOnGunsData(int port1, string time1, double Pressure1, string time2, double Pressure2,double ror1,Color Color1)
        {
            ROR1Initialtime[port1].Text = $"{time1}";
            ROR1InitialPressure[port1].Text = $"{Pressure1:0}";
            ROR1Finaltime[port1].Text = $"{time2}";
            ROR1FinalPressure[port1].Text = $"{Pressure2:0}";
            ROR1mtorrPerMin[port1].Text = $"{ror1:0.0}";
            ROR1mtorrPerMin[port1].ForeColor = Color1;
        }
        public void InsertRepeatEvac1Data(int port1, double time1, double Pressure1)
        {
            RepeatEvac1Time[port1].Text = $"{time1:0} sec";
            RepeatEvac1Pressure[port1].Text = $"{Pressure1:0} mtorr";
        }
        public void InsertRORtoGunsData(int port1, string time1, double Pressure1, string time2, double Pressure2, double ror1, Color Color1)
        {
            ROR2Initialtime[port1].Text = $"{time1}";
            ROR2InitialPressure[port1].Text = $"{Pressure1:0}";
            ROR2Finaltime[port1].Text = $"{time2}";
            ROR2FinalPressure[port1].Text = $"{Pressure2:0}";
            ROR2mtorrPerMin[port1].Text = $"{ror1:0.0}";
            ROR2mtorrPerMin[port1].ForeColor = Color1;
        }
        public void InsertRepeatEvac2Data(int port1, double time1, double Pressure1)
        {
            RepeatEvac2Time[port1].Text = $"{time1:0} sec";
            RepeatEvac2Pressure[port1].Text = $"{Pressure1:0} mtorr";
        }
        public void InsertRORWithoutGunsData(int port1, string time1, double Pressure1, string time2, double Pressure2, double ror1, Color Color1)
        {
            ROR3Initialtime[port1].Text = $"{time1}";
            ROR3InitialPressure[port1].Text = $"{Pressure1:0}";
            ROR3Finaltime[port1].Text = $"{time2}";
            ROR3FinalPressure[port1].Text = $"{Pressure2:0}";
            ROR3mtorrPerMin[port1].Text = $"{ror1:0.0}";
            ROR3mtorrPerMin[port1].ForeColor = Color1;
        }
        public void InsertResultData(int port1,string result1)
        {
            Result[port1].Text = $"{result1}";
        }

        public void ClearForm()
        {
            for (int i=0;i<1;i++)
            {
                ClearInitialBasePressCheckData(i);
                ClearSystemEvacutionData(i);
                ClearFinalBasePressCheckData(i);
                ClearRORtoHosesOnGunsData(i);
                ClearRepeatEvac1Data(i);
                ClearRORtoGunsData(i);
                ClearRepeatEvac2Data(i);
                ClearRORWithoutGunsData(i);
                ClearResultData(i);
            }
        }
        public void ClearBlue()
        {
            int i = 0;
            ClearInitialBasePressCheckData(i);
                ClearSystemEvacutionData(i);
                ClearFinalBasePressCheckData(i);
                ClearRORtoHosesOnGunsData(i);
                ClearRepeatEvac1Data(i);
                ClearRORtoGunsData(i);
                ClearRepeatEvac2Data(i);
                ClearRORWithoutGunsData(i);
                ClearResultData(i);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label65_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
