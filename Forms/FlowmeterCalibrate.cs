using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using VTIWindowsControlLibrary.Classes;
using System.IO;
using System.IO.Ports;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTIWindowsControlLibrary.Forms;
using VTIWindowsControlLibrary.Classes.ClientForms;
using VTIWindowsControlLibrary.Classes.Util;
//using NAudio.Wave;
//using NAudio.CoreAudioApi;
 

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{

    public partial class FlowmeterCalibrate : Form
    {
        double BlueAverageFlow;
        double WhiteAverageFlow;

        public FlowmeterCalibrate()
        {
            InitializeComponent();
        }

        

        private void aboutVTIDataPlotViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox.Show();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void Form_TextChanged(object sender, EventArgs e)
        {
            this.ActivateMdiChild(null);
            this.ActivateMdiChild(sender as Form);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tileHorizontallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticallyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int NumberOfDataPoints = 0;
            double SumCountsPerOz = 0;
            double SumOffsetCountsPerOz = 0;
            double SumFlow = 0;

            double Offset;
            double CountsPerOz;
            double Flow;

            if (BlueUseData1.Checked)
            {
                if ((BlueTargetCounts1.Text != "")&&(BlueActualCounts1.Text!="")&&(BlueActualWeight1.Text!=""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts1.Text) - Convert.ToDouble(BlueActualCounts1.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts1.Text) / (Convert.ToDouble(BlueActualWeight1.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow1.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (BlueUseData2.Checked)
            {
                if ((BlueTargetCounts2.Text != "") && (BlueActualCounts2.Text != "") && (BlueActualWeight2.Text != ""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts2.Text) - Convert.ToDouble(BlueActualCounts2.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts2.Text) / (Convert.ToDouble(BlueActualWeight2.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow2.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (BlueUseData3.Checked)
            {
                if ((BlueTargetCounts3.Text != "") && (BlueActualCounts3.Text != "") && (BlueActualWeight3.Text != ""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts3.Text) - Convert.ToDouble(BlueActualCounts3.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts3.Text) / (Convert.ToDouble(BlueActualWeight3.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow3.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (BlueUseData4.Checked)
            {
                if ((BlueTargetCounts4.Text != "") && (BlueActualCounts4.Text != "") && (BlueActualWeight4.Text != ""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts4.Text) - Convert.ToDouble(BlueActualCounts4.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts4.Text) / (Convert.ToDouble(BlueActualWeight4.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow4.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (BlueUseData5.Checked)
            {
                if ((BlueTargetCounts5.Text != "") && (BlueActualCounts5.Text != "") && (BlueActualWeight5.Text != ""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts5.Text) - Convert.ToDouble(BlueActualCounts5.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts5.Text) / (Convert.ToDouble(BlueActualWeight5.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow5.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (BlueUseData6.Checked)
            {
                if ((BlueTargetCounts6.Text != "") && (BlueActualCounts6.Text != "") && (BlueActualWeight6.Text != ""))
                {
                    Offset = Convert.ToDouble(BlueTargetCounts6.Text) - Convert.ToDouble(BlueActualCounts6.Text);
                    CountsPerOz = Convert.ToDouble(BlueActualCounts6.Text) / (Convert.ToDouble(BlueActualWeight6.Text)*16.0);
                    Flow = Convert.ToDouble(BlueFlow6.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }

            if (NumberOfDataPoints == 0)
            {
                MessageBox.Show("NO DATA SELECTED!", Application.ProductName);
            }
            else
            {
                BlueCalculatedCountsPerOz.Text = string.Format("{0:0.000}", SumCountsPerOz / Convert.ToDouble(NumberOfDataPoints));
                BlueCalculatedOffsetCounts.Text = string.Format("{0:0.0}", SumOffsetCountsPerOz / Convert.ToDouble(NumberOfDataPoints));
                BlueAverageFlow = SumFlow / Convert.ToDouble(NumberOfDataPoints);
            }
        }

        private void ReadTorrConIIIConfiguration()
        {
            ////serialPort1.WriteLine("");//clear if in input mode

            ////read mac address
            //textBox1.Text = " ";
            //textBox2.Text = " ";
            //textBox3.Text = " ";
            //textBox4.Text = " ";
            //textBox5.Text = " ";
            //textBox6.Text = " ";
            //String TempString = ReadTorrConIII("m");
            ////String TempString = ReadTorrConIII("v");
            //int iperiod0;
            //int iperiod1;
            //iperiod0 = TempString.IndexOf(".");
            //textBox1.Text = TempString.Substring(0, iperiod0);
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox2.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox3.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox4.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox5.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //textBox6.Text = TempString.Substring(iperiod0 + 1);

            //Thread.Sleep(100);

            ////read gateway
            //textBox7.Text = " ";
            //textBox8.Text = " ";
            //textBox9.Text = " ";
            //textBox10.Text = " ";
            //TempString = ReadTorrConIII("w");
            //iperiod0 = TempString.IndexOf(".");
            //textBox7.Text = TempString.Substring(0, iperiod0);
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox8.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox9.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //textBox10.Text = TempString.Substring(iperiod0 + 1);

            //Thread.Sleep(100);


            ////read subnet
            //textBox11.Text = " ";
            //textBox12.Text = " ";
            //textBox13.Text = " ";
            //textBox14.Text = " ";
            //TempString = ReadTorrConIII("s");
            //iperiod0 = TempString.IndexOf(".");
            //textBox11.Text = TempString.Substring(0, iperiod0);
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox12.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox13.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //textBox14.Text = TempString.Substring(iperiod0 + 1);

            //Thread.Sleep(100);


            ////read ip
            //textBox15.Text = " ";
            //textBox16.Text = " ";
            //textBox17.Text = " ";
            //textBox18.Text = " ";
            //TempString = ReadTorrConIII("i");

            //iperiod0 = TempString.IndexOf(".");
            //textBox15.Text = TempString.Substring(0, iperiod0);
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox16.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //iperiod1 = TempString.IndexOf(".", iperiod0 + 1);
            //textBox17.Text = TempString.Substring(iperiod0 + 1, iperiod1 - iperiod0 - 1);
            //iperiod0 = iperiod1;
            //textBox18.Text = TempString.Substring(iperiod0 + 1);

            //Thread.Sleep(100);


            ////read port
            //textBox19.Text = " ";
            //textBox19.Text = ReadTorrConIII("t");
            //Thread.Sleep(100);

            ////read offset
            //textBox20.Text = " ";
            //textBox20.Text = ReadTorrConIII("o");
            //Thread.Sleep(100);

            ////read gain
            //textBox21.Text = " ";
            //textBox21.Text = ReadTorrConIII("g");
            //Thread.Sleep(100);

            ////read sp1
            //textBox22.Text = " ";
            //textBox22.Text = ReadTorrConIII("1");
            //Thread.Sleep(100);

            ////read sp2
            //textBox23.Text = " ";
            //textBox23.Text = ReadTorrConIII("2");
            //Thread.Sleep(100);

            ////read unit name
            //textBox24.Text = " ";
            //textBox24.Text = ReadTorrConIII("u");
            //Thread.Sleep(100);

            ////read unit gain
            //textBox25.Text = " ";
            //textBox25.Text = ReadTorrConIII("n");
            //Thread.Sleep(100);

            ////read unit offset
            //textBox26.Text = " ";
            //textBox26.Text = ReadTorrConIII("f");
            //Thread.Sleep(100);

            ////read convectron flag
            //textBox27.Text = " ";
            //textBox27.Text = ReadTorrConIII("c");
            //Thread.Sleep(100);

            ////read display digits
            //textBox28.Text = " ";
            //textBox28.Text = ReadTorrConIII("h");
            //Thread.Sleep(100);

            //timer1.Start();

        }

        Double SpecGasFlow;
        Double SpecGasFlowUnitToTLS;
        Double SpecGasMW;
        Double SpecGasVisc;
        Double SpecGasUpstreamPressure;
        Double SpecGasDownstreamPressure;

        Double CalculatedElementSize;

        Double TestGasPercentage;
        Double TestGasFlowUnitToTLS;
        Double TestGasMW;
        Double TestGasVisc;
        Double TestGasUpstreamPressure;
        Double TestGasDownstreamPressure;

        Double CalculatedTotalTestGasFlow;
        Double CalculatedTestGasOnlyFlow;

        private Double VTIFlowFunction(Double ElementSize,Double MW,Double Visc, Double Press)
        {
            Double retVal=0;

            Double MolecularFlow=ElementSize*Press/Math.Sqrt(MW)*1E-9;
            Double ViscousFlow= 0.004564*Math.Pow(ElementSize,1.6025)*Press*Press/Visc*1E-9;
            Double OrificeFlow=0.000011/Math.Sqrt(MW)*Math.Pow(ElementSize,0.67)*Press/0.76;

            retVal = 1 / (1 / (MolecularFlow + ViscousFlow) + 1 / OrificeFlow);

            return retVal;
        }


        private String ReadTorrConIII(String data)
        {
            String retVal;
            ////String TempStr;
            ////Single tempPress;

            ////            if (Monitor.TryEnter(this.SerialLock, 500))
            ////            {
            retVal = " ";
            //try
            //{
            //    //Byte[2] chararray
            //    //chararray[0]=13;
                
            //    serialPort1.DiscardInBuffer();
            //    serialPort1.Write(data);
            //    Thread.Sleep(250);
            //    //TempStr = serialPort1.ReadLine();

            //    Actions.WaitForUpTo(300, () => this.serialPort1.BytesToRead > 2);
            //    byte[] _bytearray = new byte[50];
            //    int n = serialPort1.BytesToRead;
            //    int i;
            //    for(i=0;i<50;i++)
            //    {
            //        _bytearray[i]=0;
            //    }
            //    //StringBuilder sb = new StringBuilder();
                    
            //    for(i=0;i < n;i++)
            //    {
            //        byte tempbyte;
            //        tempbyte = (byte)serialPort1.ReadByte();
            //        if ((tempbyte!=10)&&(tempbyte!=13))
            //        {
            //            _bytearray[i]=tempbyte;
            //        }
            //    }
            //    ASCIIEncoding ascii = new ASCIIEncoding();
            //    retVal = ascii.GetString(_bytearray);
                
            //    // = serialPort1.ReadByte();
            //    //int RetLen = TempStr.Length;
            //    //retVal=TempStr.Remove(RetLen - 1);
            //    //retVal.
            //    //retVal.TrimEnd(
            //    /*                    if (retVal.StartsWith("0.0000-"))
            //                        {
            //                            pressure=0.000F;
            //                            errCode=String.Empty;
            //                            pressureReady=true;
            //                            if (!backgroundWorker1.IsBusy)
            //                                backgroundWorker1.RunWorkerAsync();    // use the BackgroundWorker thread to handle anything UI-related via the BackgroundProcess method

            //                        }
            //                        else if (Single.TryParse(retVal, out tempPress))
            //                        {
            //                            pressure = tempPress;
            //                            errCode = String.Empty;
            //                            pressureReady = true;
            //                            if (!backgroundWorker1.IsBusy)
            //                                backgroundWorker1.RunWorkerAsync();    // use the BackgroundWorker thread to handle anything UI-related via the BackgroundProcess method
            //                        }
            //                        else if (retVal.StartsWith("HHH") ||
            //                            retVal.StartsWith("EPL") ||
            //                            retVal.StartsWith("EPH") ||
            //                            retVal.StartsWith("CBL"))
            //                        {
            //                            pressureReady = false;
            //                            pressure = Single.NaN;
            //                            errCode = retVal.Substring(0,3);
            //                        }
            //                        else
            //                        {
            //                            pressureReady = false;
            //                            pressure = Single.NaN;
            //                            errCode = String.Empty;
            //                        }
            //     * */
            //}
            //catch
            //{
            //    //pressureReady = false;
            //    //commError = true;
            //}
            //finally
            //{
            //    //Monitor.Exit(this.SerialLock);
            //    //textBox29.Text = retVal;
                
            //}
            return retVal;

        }







        private void Form1_Load(object sender, EventArgs e)
        {
            //serialPort1.BaudRate = 19200;
            //serialPort1.DataBits = 8;
            //serialPort1.Parity = System.IO.Ports.Parity.None;
            //serialPort1.StopBits = System.IO.Ports.StopBits.One;
            //serialPort1.Handshake = System.IO.Ports.Handshake.None;
            //// Get a list of serial port names.
            //string[] ports = SerialPort.GetPortNames();

            ////Console.WriteLine("The following serial ports were found:");

            //// Display each port name to the console.
            //foreach (string port in ports)
            //{
            //    //Console.WriteLine(port);
            //    listBox1.Items.Add(port);
            //}

            ////read mac address
            //textBox1.Text = " ";
            //textBox2.Text = " ";
            //textBox3.Text = " ";
            //textBox4.Text = " ";
            //textBox5.Text = " ";
            //textBox6.Text = " ";

            ////read gateway
            //textBox7.Text = " ";
            //textBox8.Text = " ";
            //textBox9.Text = " ";
            //textBox10.Text = " ";

            ////read subnet
            //textBox11.Text = " ";
            //textBox12.Text = " ";
            //textBox13.Text = " ";
            //textBox14.Text = " ";

            ////read ip
            //textBox15.Text = " ";
            //textBox16.Text = " ";
            //textBox17.Text = " ";
            //textBox18.Text = " ";

            ////read port
            //textBox19.Text = " ";

            ////read offset
            //textBox20.Text = " ";

            ////read gain
            //textBox21.Text = " ";

            ////read sp1
            //textBox22.Text = " ";

            ////read sp2
            //textBox23.Text = " ";

            ////read unit name
            //textBox24.Text = " ";

            ////read unit gain
            //textBox25.Text = " ";

            ////read unit offset
            //textBox26.Text = " ";

            ////read convectron flag
            //textBox27.Text = " ";

            ////read display digits
            //textBox28.Text = " ";
            if (!Properties.Settings.Default.DualPortSystem)
            {
                WhiteActualCounts1.Visible = false;
                WhiteActualCounts2.Visible=false;
                WhiteActualCounts3.Visible=false;
                WhiteActualCounts4.Visible=false;
                WhiteActualCounts5.Visible=false;
                WhiteActualCounts6.Visible=false;
                WhiteActualWeight1.Visible=false;
                WhiteActualWeight2.Visible=false;
                WhiteActualWeight3.Visible=false;
                WhiteActualWeight4.Visible=false;
                WhiteActualWeight5.Visible=false;
                WhiteActualWeight6.Visible=false;
                WhiteCalculatedCountsPerOz.Visible=false;
                WhiteCalculatedOffsetCounts.Visible=false;
                WhiteCurrentCountsPerOz.Visible=false;
                WhiteCurrentOffsetCounts.Visible=false;
                WhiteFlow1.Visible=false;
                WhiteFlow2.Visible=false;
                WhiteFlow3.Visible=false;
                WhiteFlow4.Visible=false;
                WhiteFlow5.Visible=false;
                WhiteFlow6.Visible=false;
                WhiteTargetCounts1.Visible=false;
                WhiteTargetCounts2.Visible=false;
                WhiteTargetCounts3.Visible=false;
                WhiteTargetCounts4.Visible=false;
                WhiteTargetCounts5.Visible=false;
                WhiteTargetCounts6.Visible=false;
                WhiteTargetWeight1.Visible=false;
                WhiteTargetWeight2.Visible=false;
                WhiteTargetWeight3.Visible=false;
                WhiteTargetWeight4.Visible=false;
                WhiteTargetWeight5.Visible=false;
                WhiteTargetWeight6.Visible=false;
                WhiteUseData1.Visible=false;
                WhiteUseData2.Visible=false;
                WhiteUseData3.Visible=false;
                WhiteUseData4.Visible=false;
                WhiteUseData5.Visible=false;
                WhiteUseData6.Visible=false;
                WhiteWeightByCounter1.Visible=false;
                WhiteWeightByCounter2.Visible=false;
                WhiteWeightByCounter3.Visible=false;
                WhiteWeightByCounter4.Visible=false;
                WhiteWeightByCounter5.Visible=false;
                WhiteWeightByCounter6.Visible=false;

                label18.Visible = false;
                label11.Visible = false;
                label10.Visible = false;
                label4.Visible = false;
                label9.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
                label19.Visible = false;
                label15.Visible = false;
                label13.Visible = false;
                label12.Visible = false;
                label16.Visible = false;

                button5.Visible = false;
                button8.Visible = false;
                button7.Visible = false;
                button6.Visible = false;

                button9.Location = new System.Drawing.Point(520,37);
                this.MinimumSize = new System.Drawing.Size(630, 500);
                this.Size = new System.Drawing.Size(630,619);
            }



                  
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            double CountsPerOz = Convert.ToDouble(BlueCalculatedCountsPerOz.Text);
            if((CountsPerOz>Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.MinValue)&&(CountsPerOz<Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.MaxValue))
            {
                //Save blue counts per oz
                Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue = CountsPerOz;
                Config.Save();
                BlueCurrentCountsPerOz.Text = BlueCalculatedCountsPerOz.Text;
            }
            else
            {
                MessageBox.Show("COUNTS PER OUNCE OUT OF RANGE", Application.ProductName);
            }     

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

//            //String retVal;
//            //Single tempPress;
            
////            if (Monitor.TryEnter(this.SerialLock, 500))
////            {
//            //retVal = " ";
//            textBox29.Text=ReadTorrConIII("p");
//            /*
//                try
//                {
//                    serialPort1.Write("p");
//                    retVal = serialPort1.ReadLine();
///*                    if (retVal.StartsWith("0.0000-"))
//                    {
//                        pressure=0.000F;
//                        errCode=String.Empty;
//                        pressureReady=true;
//                        if (!backgroundWorker1.IsBusy)
//                            backgroundWorker1.RunWorkerAsync();    // use the BackgroundWorker thread to handle anything UI-related via the BackgroundProcess method

//                    }
//                    else if (Single.TryParse(retVal, out tempPress))
//                    {
//                        pressure = tempPress;
//                        errCode = String.Empty;
//                        pressureReady = true;
//                        if (!backgroundWorker1.IsBusy)
//                            backgroundWorker1.RunWorkerAsync();    // use the BackgroundWorker thread to handle anything UI-related via the BackgroundProcess method
//                    }
//                    else if (retVal.StartsWith("HHH") ||
//                        retVal.StartsWith("EPL") ||
//                        retVal.StartsWith("EPH") ||
//                        retVal.StartsWith("CBL"))
//                    {
//                        pressureReady = false;
//                        pressure = Single.NaN;
//                        errCode = retVal.Substring(0,3);
//                    }
//                    else
//                    {
//                        pressureReady = false;
//                        pressure = Single.NaN;
//                        errCode = String.Empty;
//                    }
 
//                }
//                catch
//                {
//                    //pressureReady = false;
//                    //commError = true;
//                }
//                finally
//                {
//                    //Monitor.Exit(this.SerialLock);
//                    textBox29.Text = retVal;
//                }
//            */
//            //}
// //       }



        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            double OffsetCountsPerOz = Convert.ToDouble(BlueCalculatedOffsetCounts.Text);
            if ((OffsetCountsPerOz > Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.MinValue) && (OffsetCountsPerOz < Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.MaxValue))
            {
                //Save blue counts per oz
                Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue = OffsetCountsPerOz;
                if ((BlueAverageFlow > Config.Flow.Minimum_Flowmeter_Rate.ProcessValue)&&(BlueAverageFlow<10.0))
                {
                    Config.Flow.Blue_Flowmeter_Calibration_Flow.ProcessValue = BlueAverageFlow;
                }
                else
                {
                    MessageBox.Show("CALIBRATION FLOW OUT OF RANGE", Application.ProductName);
                }
                Config.Save();
                BlueCurrentOffsetCounts.Text = BlueCalculatedOffsetCounts.Text;

            }
            else
            {
                MessageBox.Show("OFFSET COUNTS PER OUNCE OUT OF RANGE", Application.ProductName);
            }     

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlueUseData1.Checked = false;
            BlueUseData2.Checked = false;
            BlueUseData3.Checked = false;
            BlueUseData4.Checked = false;
            BlueUseData5.Checked = false;

            BlueTargetWeight1.Text = "";
            BlueTargetWeight2.Text = "";
            BlueTargetWeight3.Text = "";
            BlueTargetWeight4.Text = "";
            BlueTargetWeight5.Text = "";
            BlueTargetWeight6.Text = "";

            BlueTargetCounts1.Text = "";
            BlueTargetCounts2.Text = "";
            BlueTargetCounts3.Text = "";
            BlueTargetCounts4.Text = "";
            BlueTargetCounts5.Text = "";
            BlueTargetCounts6.Text = "";

            BlueActualCounts1.Text = "";
            BlueActualCounts2.Text = "";
            BlueActualCounts3.Text = "";
            BlueActualCounts4.Text = "";
            BlueActualCounts5.Text = "";
            BlueActualCounts6.Text = "";

            BlueActualWeight1.Text = "";
            BlueActualWeight2.Text = "";
            BlueActualWeight3.Text = "";
            BlueActualWeight4.Text = "";
            BlueActualWeight5.Text = "";
            BlueActualWeight6.Text = "";

            BlueWeightByCounter1.Text = "";
            BlueWeightByCounter2.Text = "";
            BlueWeightByCounter3.Text = "";
            BlueWeightByCounter4.Text = "";
            BlueWeightByCounter5.Text = "";
            BlueWeightByCounter6.Text = "";

            BlueFlow1.Text = "";
            BlueFlow2.Text = "";
            BlueFlow3.Text = "";
            BlueFlow4.Text = "";
            BlueFlow5.Text = "";
            BlueFlow6.Text = "";

            BlueCurrentCountsPerOz.Text = "";
            BlueCurrentOffsetCounts.Text = "";

            BlueCalculatedCountsPerOz.Text = "";
            BlueCalculatedOffsetCounts.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TargetWeight2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Machine.Test[0].CalLoadCounterData)
            {
                Machine.Test[0].CalLoadCounterData = false;

                BlueCurrentCountsPerOz.Text = string.Format("{0:0.000}", Config.Flow.Blue_Circuit2_Flowmeter_Counts_Per_Ounce.ProcessValue);
                BlueCurrentOffsetCounts.Text = string.Format("{0:0.0}", Config.Flow.Blue_Circuit2_Flowmeter_Offset_Counts.ProcessValue);
                if (BlueTargetWeight1.Text == "")
                {
                    BlueTargetWeight1.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                    BlueTargetCounts1.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                    BlueWeightByCounter1.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                    BlueActualCounts1.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                    BlueFlow1.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                }
                else
                {
                    if (BlueTargetWeight2.Text == "")
                    {
                        BlueTargetWeight2.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                        BlueTargetCounts2.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                        BlueWeightByCounter2.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                        BlueActualCounts2.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                        BlueFlow2.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                    }
                    else
                    {
                        if (BlueTargetWeight3.Text == "")
                        {
                            BlueTargetWeight3.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                            BlueTargetCounts3.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                            BlueWeightByCounter3.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                            BlueActualCounts3.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                            BlueFlow3.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                        }
                        else
                        {
                            if (BlueTargetWeight4.Text == "")
                            {
                                BlueTargetWeight4.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                                BlueTargetCounts4.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                                BlueWeightByCounter4.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                                BlueActualCounts4.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                                BlueFlow4.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                            }
                            else
                            {
                                if (BlueTargetWeight5.Text == "")
                                {
                                    BlueTargetWeight5.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                                    BlueTargetCounts5.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                                    BlueWeightByCounter5.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                                    BlueActualCounts5.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                                    BlueFlow5.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                                }
                                else
                                {
                                    BlueTargetWeight6.Text = string.Format("{0:0.0000}", Machine.Test[0].CalTargetWeight/16.0);
                                    BlueTargetCounts6.Text = string.Format("{0:0}", Machine.Test[0].CalTargetCounts);
                                    BlueWeightByCounter6.Text = string.Format("{0:0.0000}", Machine.Test[0].CalWeightByCounter/16.0);
                                    BlueActualCounts6.Text = string.Format("{0:0}", Machine.Test[0].CalActualCounts);
                                    BlueFlow6.Text = string.Format("{0:0.00}", Machine.Test[0].LastFlowValue);
                                }
                            }
                        }
                    }
                }
            }
            if (Properties.Settings.Default.DualPortSystem)
            {
                if (Machine.Test[1].CalLoadCounterData)
                {
                    Machine.Test[1].CalLoadCounterData = false;

                    WhiteCurrentCountsPerOz.Text = string.Format("{0:0.000}", Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue);
                    WhiteCurrentOffsetCounts.Text = string.Format("{0:0.0}", Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue);
                    if (WhiteTargetWeight1.Text == "")
                    {
                        WhiteTargetWeight1.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                        WhiteTargetCounts1.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                        WhiteWeightByCounter1.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                        WhiteActualCounts1.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                        WhiteFlow1.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                    }
                    else
                    {
                        if (WhiteTargetWeight2.Text == "")
                        {
                            WhiteTargetWeight2.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                            WhiteTargetCounts2.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                            WhiteWeightByCounter2.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                            WhiteActualCounts2.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                            WhiteFlow2.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                        }
                        else
                        {
                            if (WhiteTargetWeight3.Text == "")
                            {
                                WhiteTargetWeight3.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                                WhiteTargetCounts3.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                                WhiteWeightByCounter3.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                                WhiteActualCounts3.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                                WhiteFlow3.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                            }
                            else
                            {
                                if (WhiteTargetWeight4.Text == "")
                                {
                                    WhiteTargetWeight4.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                                    WhiteTargetCounts4.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                                    WhiteWeightByCounter4.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                                    WhiteActualCounts4.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                                    WhiteFlow4.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                                }
                                else
                                {
                                    if (WhiteTargetWeight5.Text == "")
                                    {
                                        WhiteTargetWeight5.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                                        WhiteTargetCounts5.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                                        WhiteWeightByCounter5.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                                        WhiteActualCounts5.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                                        WhiteFlow5.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                                    }
                                    else
                                    {
                                        WhiteTargetWeight6.Text = string.Format("{0:0.000}", Machine.Test[1].CalTargetWeight);
                                        WhiteTargetCounts6.Text = string.Format("{0:0}", Machine.Test[1].CalTargetCounts);
                                        WhiteWeightByCounter6.Text = string.Format("{0:0.000}", Machine.Test[1].CalWeightByCounter);
                                        WhiteActualCounts6.Text = string.Format("{0:0}", Machine.Test[1].CalActualCounts);
                                        WhiteFlow6.Text = string.Format("{0:0.00}", Machine.Test[1].LastFlowValue);
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            double CountsPerOz = Convert.ToDouble(WhiteCalculatedCountsPerOz.Text);
            if ((CountsPerOz > Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.MinValue) && (CountsPerOz < Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.MaxValue))
            {
                //Save blue counts per oz
                Config.Flow.White_Circuit1_Flowmeter_Counts_Per_Ounce.ProcessValue = CountsPerOz;
                Config.Save();
                WhiteCurrentCountsPerOz.Text = WhiteCalculatedCountsPerOz.Text;
            }
            else
            {
                MessageBox.Show("COUNTS PER OUNCE OUT OF RANGE", Application.ProductName);
            }     

        }

        private void button6_Click(object sender, EventArgs e)
        {
            double OffsetCountsPerOz = Convert.ToDouble(WhiteCalculatedOffsetCounts.Text);
            if ((OffsetCountsPerOz > Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.MinValue) && (OffsetCountsPerOz < Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.MaxValue))
            {
                //Save blue counts per oz
                Config.Flow.White_Circuit1_Flowmeter_Offset_Counts.ProcessValue = OffsetCountsPerOz;
                Config.Flow.White_Flowmeter_Calibration_Flow.ProcessValue = WhiteAverageFlow;
                Config.Save();
                WhiteCurrentOffsetCounts.Text = WhiteCalculatedOffsetCounts.Text;
            }
            else
            {
                MessageBox.Show("OFFSET COUNTS PER OUNCE OUT OF RANGE", Application.ProductName);
            }     

        }

        private void button5_Click(object sender, EventArgs e)
        {
            WhiteUseData1.Checked = false;
            WhiteUseData2.Checked = false;
            WhiteUseData3.Checked = false;
            WhiteUseData4.Checked = false;
            WhiteUseData5.Checked = false;

            WhiteTargetWeight1.Text = "";
            WhiteTargetWeight2.Text = "";
            WhiteTargetWeight3.Text = "";
            WhiteTargetWeight4.Text = "";
            WhiteTargetWeight5.Text = "";
            WhiteTargetWeight6.Text = "";

            WhiteTargetCounts1.Text = "";
            WhiteTargetCounts2.Text = "";
            WhiteTargetCounts3.Text = "";
            WhiteTargetCounts4.Text = "";
            WhiteTargetCounts5.Text = "";
            WhiteTargetCounts6.Text = "";

            WhiteActualCounts1.Text = "";
            WhiteActualCounts2.Text = "";
            WhiteActualCounts3.Text = "";
            WhiteActualCounts4.Text = "";
            WhiteActualCounts5.Text = "";
            WhiteActualCounts6.Text = "";

            WhiteActualWeight1.Text = "";
            WhiteActualWeight2.Text = "";
            WhiteActualWeight3.Text = "";
            WhiteActualWeight4.Text = "";
            WhiteActualWeight5.Text = "";
            WhiteActualWeight6.Text = "";

            WhiteWeightByCounter1.Text = "";
            WhiteWeightByCounter2.Text = "";
            WhiteWeightByCounter3.Text = "";
            WhiteWeightByCounter4.Text = "";
            WhiteWeightByCounter5.Text = "";
            WhiteWeightByCounter6.Text = "";

            WhiteFlow1.Text = "";
            WhiteFlow2.Text = "";
            WhiteFlow3.Text = "";
            WhiteFlow4.Text = "";
            WhiteFlow5.Text = "";
            WhiteFlow6.Text = "";

            WhiteCurrentCountsPerOz.Text = "";
            WhiteCurrentOffsetCounts.Text = "";

            WhiteCalculatedCountsPerOz.Text = "";
            WhiteCalculatedOffsetCounts.Text = "";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int NumberOfDataPoints = 0;
            double SumCountsPerOz = 0;
            double SumOffsetCountsPerOz = 0;
            double SumFlow = 0;

            double Offset;
            double CountsPerOz;
            double Flow;

            if (WhiteUseData1.Checked)
            {
                if ((WhiteTargetCounts1.Text != "") && (WhiteActualCounts1.Text != "") && (WhiteActualWeight1.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts1.Text) - Convert.ToDouble(WhiteActualCounts1.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts1.Text) / Convert.ToDouble(WhiteActualWeight1.Text);
                    Flow = Convert.ToDouble(WhiteFlow1.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (WhiteUseData2.Checked)
            {
                if ((WhiteTargetCounts2.Text != "") && (WhiteActualCounts2.Text != "") && (WhiteActualWeight2.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts2.Text) - Convert.ToDouble(WhiteActualCounts2.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts2.Text) / Convert.ToDouble(WhiteActualWeight2.Text);
                    Flow = Convert.ToDouble(WhiteFlow2.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (WhiteUseData3.Checked)
            {
                if ((WhiteTargetCounts3.Text != "") && (WhiteActualCounts3.Text != "") && (WhiteActualWeight3.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts3.Text) - Convert.ToDouble(WhiteActualCounts3.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts3.Text) / Convert.ToDouble(WhiteActualWeight3.Text);
                    Flow = Convert.ToDouble(WhiteFlow3.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (WhiteUseData4.Checked)
            {
                if ((WhiteTargetCounts4.Text != "") && (WhiteActualCounts4.Text != "") && (WhiteActualWeight4.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts4.Text) - Convert.ToDouble(WhiteActualCounts4.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts4.Text) / Convert.ToDouble(WhiteActualWeight4.Text);
                    Flow = Convert.ToDouble(WhiteFlow4.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (WhiteUseData5.Checked)
            {
                if ((WhiteTargetCounts5.Text != "") && (WhiteActualCounts5.Text != "") && (WhiteActualWeight5.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts5.Text) - Convert.ToDouble(WhiteActualCounts5.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts5.Text) / Convert.ToDouble(WhiteActualWeight5.Text);
                    Flow = Convert.ToDouble(WhiteFlow5.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }
            if (WhiteUseData6.Checked)
            {
                if ((WhiteTargetCounts6.Text != "") && (WhiteActualCounts6.Text != "") && (WhiteActualWeight6.Text != ""))
                {
                    Offset = Convert.ToDouble(WhiteTargetCounts6.Text) - Convert.ToDouble(WhiteActualCounts6.Text);
                    CountsPerOz = Convert.ToDouble(WhiteActualCounts6.Text) / Convert.ToDouble(WhiteActualWeight6.Text);
                    Flow = Convert.ToDouble(WhiteFlow6.Text);
                    NumberOfDataPoints = NumberOfDataPoints + 1;
                    SumCountsPerOz = SumCountsPerOz + CountsPerOz;
                    SumOffsetCountsPerOz = SumOffsetCountsPerOz + Offset;
                    SumFlow = SumFlow + Flow;
                }
            }

            if (NumberOfDataPoints == 0)
            {
                MessageBox.Show(Localization.NoWeightEnteredOrDataSelected, Application.ProductName);
            }
            else
            {
                WhiteCalculatedCountsPerOz.Text = string.Format("{0:0.000}", SumCountsPerOz / Convert.ToDouble(NumberOfDataPoints));
                WhiteCalculatedOffsetCounts.Text = string.Format("{0:0.0}", SumOffsetCountsPerOz / Convert.ToDouble(NumberOfDataPoints));
                WhiteAverageFlow = SumFlow / Convert.ToDouble(NumberOfDataPoints);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}