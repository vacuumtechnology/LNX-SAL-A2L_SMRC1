using System;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    partial class FlowmeterCalibrate
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutVTIDataPlotViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BlueCalculatedCountsPerOz = new System.Windows.Forms.TextBox();
            this.BlueCalculatedOffsetCounts = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.BlueTargetWeight1 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.BlueCurrentOffsetCounts = new System.Windows.Forms.TextBox();
            this.BlueCurrentCountsPerOz = new System.Windows.Forms.TextBox();
            this.BlueUseData1 = new System.Windows.Forms.CheckBox();
            this.BlueUseData2 = new System.Windows.Forms.CheckBox();
            this.BlueUseData3 = new System.Windows.Forms.CheckBox();
            this.BlueUseData4 = new System.Windows.Forms.CheckBox();
            this.BlueUseData5 = new System.Windows.Forms.CheckBox();
            this.BlueUseData6 = new System.Windows.Forms.CheckBox();
            this.BlueTargetWeight2 = new System.Windows.Forms.TextBox();
            this.BlueTargetWeight3 = new System.Windows.Forms.TextBox();
            this.BlueTargetWeight4 = new System.Windows.Forms.TextBox();
            this.BlueTargetWeight5 = new System.Windows.Forms.TextBox();
            this.BlueTargetWeight6 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter1 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter2 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter3 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter4 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter5 = new System.Windows.Forms.TextBox();
            this.BlueWeightByCounter6 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts1 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts2 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts3 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts4 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts5 = new System.Windows.Forms.TextBox();
            this.BlueTargetCounts6 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts1 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts2 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts3 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts4 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts5 = new System.Windows.Forms.TextBox();
            this.BlueActualCounts6 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight1 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight2 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight3 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight4 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight5 = new System.Windows.Forms.TextBox();
            this.BlueActualWeight6 = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.WhiteActualWeight6 = new System.Windows.Forms.TextBox();
            this.WhiteActualWeight5 = new System.Windows.Forms.TextBox();
            this.WhiteActualWeight4 = new System.Windows.Forms.TextBox();
            this.WhiteActualWeight3 = new System.Windows.Forms.TextBox();
            this.WhiteActualWeight2 = new System.Windows.Forms.TextBox();
            this.WhiteActualWeight1 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts6 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts5 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts4 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts3 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts2 = new System.Windows.Forms.TextBox();
            this.WhiteActualCounts1 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts6 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts5 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts4 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts3 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts2 = new System.Windows.Forms.TextBox();
            this.WhiteTargetCounts1 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter6 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter5 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter4 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter3 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter2 = new System.Windows.Forms.TextBox();
            this.WhiteWeightByCounter1 = new System.Windows.Forms.TextBox();
            this.WhiteTargetWeight6 = new System.Windows.Forms.TextBox();
            this.WhiteTargetWeight5 = new System.Windows.Forms.TextBox();
            this.WhiteTargetWeight4 = new System.Windows.Forms.TextBox();
            this.WhiteTargetWeight3 = new System.Windows.Forms.TextBox();
            this.WhiteTargetWeight2 = new System.Windows.Forms.TextBox();
            this.WhiteUseData6 = new System.Windows.Forms.CheckBox();
            this.WhiteUseData5 = new System.Windows.Forms.CheckBox();
            this.WhiteUseData4 = new System.Windows.Forms.CheckBox();
            this.WhiteUseData3 = new System.Windows.Forms.CheckBox();
            this.WhiteUseData2 = new System.Windows.Forms.CheckBox();
            this.WhiteUseData1 = new System.Windows.Forms.CheckBox();
            this.WhiteCurrentCountsPerOz = new System.Windows.Forms.TextBox();
            this.WhiteCurrentOffsetCounts = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.WhiteTargetWeight1 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.WhiteCalculatedOffsetCounts = new System.Windows.Forms.TextBox();
            this.WhiteCalculatedCountsPerOz = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.BlueFlow1 = new System.Windows.Forms.TextBox();
            this.BlueFlow2 = new System.Windows.Forms.TextBox();
            this.BlueFlow3 = new System.Windows.Forms.TextBox();
            this.BlueFlow4 = new System.Windows.Forms.TextBox();
            this.BlueFlow5 = new System.Windows.Forms.TextBox();
            this.BlueFlow6 = new System.Windows.Forms.TextBox();
            this.WhiteFlow1 = new System.Windows.Forms.TextBox();
            this.WhiteFlow2 = new System.Windows.Forms.TextBox();
            this.WhiteFlow3 = new System.Windows.Forms.TextBox();
            this.WhiteFlow4 = new System.Windows.Forms.TextBox();
            this.WhiteFlow5 = new System.Windows.Forms.TextBox();
            this.WhiteFlow6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(820, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.MergeIndex = 1;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.MergeIndex = 20;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(89, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.MergeIndex = 21;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tileHorizontallyToolStripMenuItem,
            this.tileVerticallyToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.toolStripSeparator3});
            this.windowToolStripMenuItem.MergeIndex = 20;
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // tileHorizontallyToolStripMenuItem
            // 
            this.tileHorizontallyToolStripMenuItem.Name = "tileHorizontallyToolStripMenuItem";
            this.tileHorizontallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileHorizontallyToolStripMenuItem.Text = "Tile &Horizontally";
            this.tileHorizontallyToolStripMenuItem.Click += new System.EventHandler(this.tileHorizontallyToolStripMenuItem_Click);
            // 
            // tileVerticallyToolStripMenuItem
            // 
            this.tileVerticallyToolStripMenuItem.Name = "tileVerticallyToolStripMenuItem";
            this.tileVerticallyToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.tileVerticallyToolStripMenuItem.Text = "Tile &Vertically";
            this.tileVerticallyToolStripMenuItem.Click += new System.EventHandler(this.tileVerticallyToolStripMenuItem_Click);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.cascadeToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutVTIDataPlotViewerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutVTIDataPlotViewerToolStripMenuItem
            // 
            this.aboutVTIDataPlotViewerToolStripMenuItem.Name = "aboutVTIDataPlotViewerToolStripMenuItem";
            this.aboutVTIDataPlotViewerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.aboutVTIDataPlotViewerToolStripMenuItem.Text = "&About VTI DataPlot Viewer";
            this.aboutVTIDataPlotViewerToolStripMenuItem.Click += new System.EventHandler(this.aboutVTIDataPlotViewerToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 521);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "Use\r\nData";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BlueCalculatedCountsPerOz
            // 
            this.BlueCalculatedCountsPerOz.Location = new System.Drawing.Point(162, 412);
            this.BlueCalculatedCountsPerOz.Name = "BlueCalculatedCountsPerOz";
            this.BlueCalculatedCountsPerOz.ReadOnly = true;
            this.BlueCalculatedCountsPerOz.Size = new System.Drawing.Size(80, 20);
            this.BlueCalculatedCountsPerOz.TabIndex = 9;
            this.BlueCalculatedCountsPerOz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueCalculatedCountsPerOz.WordWrap = false;
            this.BlueCalculatedCountsPerOz.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BlueCalculatedOffsetCounts
            // 
            this.BlueCalculatedOffsetCounts.Location = new System.Drawing.Point(162, 496);
            this.BlueCalculatedOffsetCounts.Name = "BlueCalculatedOffsetCounts";
            this.BlueCalculatedOffsetCounts.ReadOnly = true;
            this.BlueCalculatedOffsetCounts.Size = new System.Drawing.Size(80, 20);
            this.BlueCalculatedOffsetCounts.TabIndex = 10;
            this.BlueCalculatedOffsetCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueCalculatedOffsetCounts.WordWrap = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(59, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 32);
            this.label7.TabIndex = 20;
            this.label7.Text = "Target \r\nWt (lbs)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(187, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 32);
            this.label14.TabIndex = 28;
            this.label14.Text = "Target \r\nCounts";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(143, 450);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(99, 32);
            this.label25.TabIndex = 56;
            this.label25.Text = "Calculated\r\nOffset Counts";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(251, 100);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(55, 32);
            this.label26.TabIndex = 58;
            this.label26.Text = "Actual \r\nCounts";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label26.Click += new System.EventHandler(this.label26_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(312, 100);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 32);
            this.label27.TabIndex = 60;
            this.label27.Text = "Actual \r\nWeight";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BlueTargetWeight1
            // 
            this.BlueTargetWeight1.Location = new System.Drawing.Point(65, 135);
            this.BlueTargetWeight1.Name = "BlueTargetWeight1";
            this.BlueTargetWeight1.ReadOnly = true;
            this.BlueTargetWeight1.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight1.TabIndex = 63;
            this.BlueTargetWeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight1.WordWrap = false;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(26, 376);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(105, 32);
            this.label28.TabIndex = 62;
            this.label28.Text = "Current \r\nCounts Per Oz";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label28.Click += new System.EventHandler(this.label28_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(196, 44);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(301, 25);
            this.label29.TabIndex = 64;
            this.label29.Text = "Flowmeter Calibration Form";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 390);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 42);
            this.button2.TabIndex = 69;
            this.button2.Text = "SAVE COUNTS PER OZ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 32);
            this.label2.TabIndex = 71;
            this.label2.Text = "Calculated \r\nCounts Per Oz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 450);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 32);
            this.label3.TabIndex = 72;
            this.label3.Text = "Current \r\nOffset Counts";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(123, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 48);
            this.label8.TabIndex = 76;
            this.label8.Text = "Weight \r\nBy\r\nCounter";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(262, 472);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 44);
            this.button3.TabIndex = 77;
            this.button3.Text = "SAVE OFFSET COUNTS";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(95, 521);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 42);
            this.button4.TabIndex = 79;
            this.button4.Text = "Clear All Data";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BlueCurrentOffsetCounts
            // 
            this.BlueCurrentOffsetCounts.Location = new System.Drawing.Point(54, 495);
            this.BlueCurrentOffsetCounts.Name = "BlueCurrentOffsetCounts";
            this.BlueCurrentOffsetCounts.ReadOnly = true;
            this.BlueCurrentOffsetCounts.Size = new System.Drawing.Size(80, 20);
            this.BlueCurrentOffsetCounts.TabIndex = 80;
            this.BlueCurrentOffsetCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueCurrentOffsetCounts.WordWrap = false;
            // 
            // BlueCurrentCountsPerOz
            // 
            this.BlueCurrentCountsPerOz.Location = new System.Drawing.Point(51, 412);
            this.BlueCurrentCountsPerOz.Name = "BlueCurrentCountsPerOz";
            this.BlueCurrentCountsPerOz.ReadOnly = true;
            this.BlueCurrentCountsPerOz.Size = new System.Drawing.Size(80, 20);
            this.BlueCurrentCountsPerOz.TabIndex = 81;
            this.BlueCurrentCountsPerOz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueCurrentCountsPerOz.WordWrap = false;
            // 
            // BlueUseData1
            // 
            this.BlueUseData1.AutoSize = true;
            this.BlueUseData1.Location = new System.Drawing.Point(38, 137);
            this.BlueUseData1.Name = "BlueUseData1";
            this.BlueUseData1.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData1.TabIndex = 82;
            this.BlueUseData1.UseVisualStyleBackColor = true;
            // 
            // BlueUseData2
            // 
            this.BlueUseData2.AutoSize = true;
            this.BlueUseData2.Location = new System.Drawing.Point(38, 174);
            this.BlueUseData2.Name = "BlueUseData2";
            this.BlueUseData2.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData2.TabIndex = 83;
            this.BlueUseData2.UseVisualStyleBackColor = true;
            // 
            // BlueUseData3
            // 
            this.BlueUseData3.AutoSize = true;
            this.BlueUseData3.Location = new System.Drawing.Point(38, 206);
            this.BlueUseData3.Name = "BlueUseData3";
            this.BlueUseData3.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData3.TabIndex = 84;
            this.BlueUseData3.UseVisualStyleBackColor = true;
            // 
            // BlueUseData4
            // 
            this.BlueUseData4.AutoSize = true;
            this.BlueUseData4.Location = new System.Drawing.Point(38, 250);
            this.BlueUseData4.Name = "BlueUseData4";
            this.BlueUseData4.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData4.TabIndex = 85;
            this.BlueUseData4.UseVisualStyleBackColor = true;
            // 
            // BlueUseData5
            // 
            this.BlueUseData5.AutoSize = true;
            this.BlueUseData5.Location = new System.Drawing.Point(38, 284);
            this.BlueUseData5.Name = "BlueUseData5";
            this.BlueUseData5.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData5.TabIndex = 86;
            this.BlueUseData5.UseVisualStyleBackColor = true;
            // 
            // BlueUseData6
            // 
            this.BlueUseData6.AutoSize = true;
            this.BlueUseData6.Location = new System.Drawing.Point(38, 330);
            this.BlueUseData6.Name = "BlueUseData6";
            this.BlueUseData6.Size = new System.Drawing.Size(15, 14);
            this.BlueUseData6.TabIndex = 87;
            this.BlueUseData6.UseVisualStyleBackColor = true;
            // 
            // BlueTargetWeight2
            // 
            this.BlueTargetWeight2.Location = new System.Drawing.Point(65, 168);
            this.BlueTargetWeight2.Name = "BlueTargetWeight2";
            this.BlueTargetWeight2.ReadOnly = true;
            this.BlueTargetWeight2.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight2.TabIndex = 88;
            this.BlueTargetWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight2.WordWrap = false;
            this.BlueTargetWeight2.TextChanged += new System.EventHandler(this.TargetWeight2_TextChanged);
            // 
            // BlueTargetWeight3
            // 
            this.BlueTargetWeight3.Location = new System.Drawing.Point(65, 206);
            this.BlueTargetWeight3.Name = "BlueTargetWeight3";
            this.BlueTargetWeight3.ReadOnly = true;
            this.BlueTargetWeight3.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight3.TabIndex = 89;
            this.BlueTargetWeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight3.WordWrap = false;
            // 
            // BlueTargetWeight4
            // 
            this.BlueTargetWeight4.Location = new System.Drawing.Point(65, 244);
            this.BlueTargetWeight4.Name = "BlueTargetWeight4";
            this.BlueTargetWeight4.ReadOnly = true;
            this.BlueTargetWeight4.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight4.TabIndex = 90;
            this.BlueTargetWeight4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight4.WordWrap = false;
            // 
            // BlueTargetWeight5
            // 
            this.BlueTargetWeight5.Location = new System.Drawing.Point(65, 284);
            this.BlueTargetWeight5.Name = "BlueTargetWeight5";
            this.BlueTargetWeight5.ReadOnly = true;
            this.BlueTargetWeight5.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight5.TabIndex = 91;
            this.BlueTargetWeight5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight5.WordWrap = false;
            // 
            // BlueTargetWeight6
            // 
            this.BlueTargetWeight6.Location = new System.Drawing.Point(65, 330);
            this.BlueTargetWeight6.Name = "BlueTargetWeight6";
            this.BlueTargetWeight6.ReadOnly = true;
            this.BlueTargetWeight6.Size = new System.Drawing.Size(50, 20);
            this.BlueTargetWeight6.TabIndex = 92;
            this.BlueTargetWeight6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetWeight6.WordWrap = false;
            // 
            // BlueWeightByCounter1
            // 
            this.BlueWeightByCounter1.Location = new System.Drawing.Point(125, 134);
            this.BlueWeightByCounter1.Name = "BlueWeightByCounter1";
            this.BlueWeightByCounter1.ReadOnly = true;
            this.BlueWeightByCounter1.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter1.TabIndex = 99;
            this.BlueWeightByCounter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter1.WordWrap = false;
            // 
            // BlueWeightByCounter2
            // 
            this.BlueWeightByCounter2.Location = new System.Drawing.Point(125, 168);
            this.BlueWeightByCounter2.Name = "BlueWeightByCounter2";
            this.BlueWeightByCounter2.ReadOnly = true;
            this.BlueWeightByCounter2.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter2.TabIndex = 100;
            this.BlueWeightByCounter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter2.WordWrap = false;
            // 
            // BlueWeightByCounter3
            // 
            this.BlueWeightByCounter3.Location = new System.Drawing.Point(125, 206);
            this.BlueWeightByCounter3.Name = "BlueWeightByCounter3";
            this.BlueWeightByCounter3.ReadOnly = true;
            this.BlueWeightByCounter3.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter3.TabIndex = 101;
            this.BlueWeightByCounter3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter3.WordWrap = false;
            // 
            // BlueWeightByCounter4
            // 
            this.BlueWeightByCounter4.Location = new System.Drawing.Point(125, 244);
            this.BlueWeightByCounter4.Name = "BlueWeightByCounter4";
            this.BlueWeightByCounter4.ReadOnly = true;
            this.BlueWeightByCounter4.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter4.TabIndex = 102;
            this.BlueWeightByCounter4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter4.WordWrap = false;
            // 
            // BlueWeightByCounter5
            // 
            this.BlueWeightByCounter5.Location = new System.Drawing.Point(125, 281);
            this.BlueWeightByCounter5.Name = "BlueWeightByCounter5";
            this.BlueWeightByCounter5.ReadOnly = true;
            this.BlueWeightByCounter5.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter5.TabIndex = 103;
            this.BlueWeightByCounter5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter5.WordWrap = false;
            // 
            // BlueWeightByCounter6
            // 
            this.BlueWeightByCounter6.Location = new System.Drawing.Point(125, 330);
            this.BlueWeightByCounter6.Name = "BlueWeightByCounter6";
            this.BlueWeightByCounter6.ReadOnly = true;
            this.BlueWeightByCounter6.Size = new System.Drawing.Size(55, 20);
            this.BlueWeightByCounter6.TabIndex = 104;
            this.BlueWeightByCounter6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueWeightByCounter6.WordWrap = false;
            // 
            // BlueTargetCounts1
            // 
            this.BlueTargetCounts1.Location = new System.Drawing.Point(202, 134);
            this.BlueTargetCounts1.Name = "BlueTargetCounts1";
            this.BlueTargetCounts1.ReadOnly = true;
            this.BlueTargetCounts1.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts1.TabIndex = 105;
            this.BlueTargetCounts1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts1.WordWrap = false;
            // 
            // BlueTargetCounts2
            // 
            this.BlueTargetCounts2.Location = new System.Drawing.Point(202, 168);
            this.BlueTargetCounts2.Name = "BlueTargetCounts2";
            this.BlueTargetCounts2.ReadOnly = true;
            this.BlueTargetCounts2.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts2.TabIndex = 106;
            this.BlueTargetCounts2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts2.WordWrap = false;
            // 
            // BlueTargetCounts3
            // 
            this.BlueTargetCounts3.Location = new System.Drawing.Point(202, 206);
            this.BlueTargetCounts3.Name = "BlueTargetCounts3";
            this.BlueTargetCounts3.ReadOnly = true;
            this.BlueTargetCounts3.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts3.TabIndex = 107;
            this.BlueTargetCounts3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts3.WordWrap = false;
            // 
            // BlueTargetCounts4
            // 
            this.BlueTargetCounts4.Location = new System.Drawing.Point(202, 244);
            this.BlueTargetCounts4.Name = "BlueTargetCounts4";
            this.BlueTargetCounts4.ReadOnly = true;
            this.BlueTargetCounts4.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts4.TabIndex = 108;
            this.BlueTargetCounts4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts4.WordWrap = false;
            // 
            // BlueTargetCounts5
            // 
            this.BlueTargetCounts5.Location = new System.Drawing.Point(202, 284);
            this.BlueTargetCounts5.Name = "BlueTargetCounts5";
            this.BlueTargetCounts5.ReadOnly = true;
            this.BlueTargetCounts5.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts5.TabIndex = 109;
            this.BlueTargetCounts5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts5.WordWrap = false;
            // 
            // BlueTargetCounts6
            // 
            this.BlueTargetCounts6.Location = new System.Drawing.Point(202, 330);
            this.BlueTargetCounts6.Name = "BlueTargetCounts6";
            this.BlueTargetCounts6.ReadOnly = true;
            this.BlueTargetCounts6.Size = new System.Drawing.Size(43, 20);
            this.BlueTargetCounts6.TabIndex = 110;
            this.BlueTargetCounts6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueTargetCounts6.WordWrap = false;
            // 
            // BlueActualCounts1
            // 
            this.BlueActualCounts1.Location = new System.Drawing.Point(263, 134);
            this.BlueActualCounts1.Name = "BlueActualCounts1";
            this.BlueActualCounts1.ReadOnly = true;
            this.BlueActualCounts1.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts1.TabIndex = 111;
            this.BlueActualCounts1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts1.WordWrap = false;
            // 
            // BlueActualCounts2
            // 
            this.BlueActualCounts2.Location = new System.Drawing.Point(263, 168);
            this.BlueActualCounts2.Name = "BlueActualCounts2";
            this.BlueActualCounts2.ReadOnly = true;
            this.BlueActualCounts2.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts2.TabIndex = 112;
            this.BlueActualCounts2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts2.WordWrap = false;
            // 
            // BlueActualCounts3
            // 
            this.BlueActualCounts3.Location = new System.Drawing.Point(263, 206);
            this.BlueActualCounts3.Name = "BlueActualCounts3";
            this.BlueActualCounts3.ReadOnly = true;
            this.BlueActualCounts3.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts3.TabIndex = 113;
            this.BlueActualCounts3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts3.WordWrap = false;
            // 
            // BlueActualCounts4
            // 
            this.BlueActualCounts4.Location = new System.Drawing.Point(263, 244);
            this.BlueActualCounts4.Name = "BlueActualCounts4";
            this.BlueActualCounts4.ReadOnly = true;
            this.BlueActualCounts4.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts4.TabIndex = 114;
            this.BlueActualCounts4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts4.WordWrap = false;
            // 
            // BlueActualCounts5
            // 
            this.BlueActualCounts5.Location = new System.Drawing.Point(263, 284);
            this.BlueActualCounts5.Name = "BlueActualCounts5";
            this.BlueActualCounts5.ReadOnly = true;
            this.BlueActualCounts5.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts5.TabIndex = 115;
            this.BlueActualCounts5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts5.WordWrap = false;
            // 
            // BlueActualCounts6
            // 
            this.BlueActualCounts6.Location = new System.Drawing.Point(263, 330);
            this.BlueActualCounts6.Name = "BlueActualCounts6";
            this.BlueActualCounts6.ReadOnly = true;
            this.BlueActualCounts6.Size = new System.Drawing.Size(43, 20);
            this.BlueActualCounts6.TabIndex = 116;
            this.BlueActualCounts6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualCounts6.WordWrap = false;
            // 
            // BlueActualWeight1
            // 
            this.BlueActualWeight1.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight1.Location = new System.Drawing.Point(312, 135);
            this.BlueActualWeight1.Name = "BlueActualWeight1";
            this.BlueActualWeight1.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight1.TabIndex = 117;
            this.BlueActualWeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight1.WordWrap = false;
            // 
            // BlueActualWeight2
            // 
            this.BlueActualWeight2.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight2.Location = new System.Drawing.Point(312, 168);
            this.BlueActualWeight2.Name = "BlueActualWeight2";
            this.BlueActualWeight2.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight2.TabIndex = 118;
            this.BlueActualWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight2.WordWrap = false;
            // 
            // BlueActualWeight3
            // 
            this.BlueActualWeight3.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight3.Location = new System.Drawing.Point(312, 206);
            this.BlueActualWeight3.Name = "BlueActualWeight3";
            this.BlueActualWeight3.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight3.TabIndex = 119;
            this.BlueActualWeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight3.WordWrap = false;
            // 
            // BlueActualWeight4
            // 
            this.BlueActualWeight4.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight4.Location = new System.Drawing.Point(312, 244);
            this.BlueActualWeight4.Name = "BlueActualWeight4";
            this.BlueActualWeight4.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight4.TabIndex = 120;
            this.BlueActualWeight4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight4.WordWrap = false;
            // 
            // BlueActualWeight5
            // 
            this.BlueActualWeight5.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight5.Location = new System.Drawing.Point(312, 284);
            this.BlueActualWeight5.Name = "BlueActualWeight5";
            this.BlueActualWeight5.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight5.TabIndex = 121;
            this.BlueActualWeight5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight5.WordWrap = false;
            // 
            // BlueActualWeight6
            // 
            this.BlueActualWeight6.BackColor = System.Drawing.SystemColors.Info;
            this.BlueActualWeight6.Location = new System.Drawing.Point(312, 330);
            this.BlueActualWeight6.Name = "BlueActualWeight6";
            this.BlueActualWeight6.Size = new System.Drawing.Size(56, 20);
            this.BlueActualWeight6.TabIndex = 122;
            this.BlueActualWeight6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueActualWeight6.WordWrap = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(520, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 48);
            this.label4.TabIndex = 129;
            this.label4.Text = "Weight \r\nBy\r\nCounter";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(709, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 32);
            this.label5.TabIndex = 128;
            this.label5.Text = "Actual \r\nWeight";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(648, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 32);
            this.label6.TabIndex = 127;
            this.label6.Text = "Actual \r\nCounts";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(584, 100);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 32);
            this.label9.TabIndex = 126;
            this.label9.Text = "Target \r\nCounts";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(456, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 32);
            this.label10.TabIndex = 125;
            this.label10.Text = "Target \r\nWt (oz)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(417, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 26);
            this.label11.TabIndex = 124;
            this.label11.Text = "Use\r\nData";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WhiteActualWeight6
            // 
            this.WhiteActualWeight6.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight6.Location = new System.Drawing.Point(709, 330);
            this.WhiteActualWeight6.Name = "WhiteActualWeight6";
            this.WhiteActualWeight6.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight6.TabIndex = 177;
            this.WhiteActualWeight6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight6.WordWrap = false;
            // 
            // WhiteActualWeight5
            // 
            this.WhiteActualWeight5.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight5.Location = new System.Drawing.Point(709, 284);
            this.WhiteActualWeight5.Name = "WhiteActualWeight5";
            this.WhiteActualWeight5.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight5.TabIndex = 176;
            this.WhiteActualWeight5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight5.WordWrap = false;
            // 
            // WhiteActualWeight4
            // 
            this.WhiteActualWeight4.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight4.Location = new System.Drawing.Point(709, 244);
            this.WhiteActualWeight4.Name = "WhiteActualWeight4";
            this.WhiteActualWeight4.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight4.TabIndex = 175;
            this.WhiteActualWeight4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight4.WordWrap = false;
            // 
            // WhiteActualWeight3
            // 
            this.WhiteActualWeight3.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight3.Location = new System.Drawing.Point(709, 206);
            this.WhiteActualWeight3.Name = "WhiteActualWeight3";
            this.WhiteActualWeight3.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight3.TabIndex = 174;
            this.WhiteActualWeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight3.WordWrap = false;
            // 
            // WhiteActualWeight2
            // 
            this.WhiteActualWeight2.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight2.Location = new System.Drawing.Point(709, 168);
            this.WhiteActualWeight2.Name = "WhiteActualWeight2";
            this.WhiteActualWeight2.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight2.TabIndex = 173;
            this.WhiteActualWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight2.WordWrap = false;
            // 
            // WhiteActualWeight1
            // 
            this.WhiteActualWeight1.BackColor = System.Drawing.SystemColors.Info;
            this.WhiteActualWeight1.Location = new System.Drawing.Point(709, 135);
            this.WhiteActualWeight1.Name = "WhiteActualWeight1";
            this.WhiteActualWeight1.Size = new System.Drawing.Size(56, 20);
            this.WhiteActualWeight1.TabIndex = 172;
            this.WhiteActualWeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualWeight1.WordWrap = false;
            // 
            // WhiteActualCounts6
            // 
            this.WhiteActualCounts6.Location = new System.Drawing.Point(660, 330);
            this.WhiteActualCounts6.Name = "WhiteActualCounts6";
            this.WhiteActualCounts6.ReadOnly = true;
            this.WhiteActualCounts6.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts6.TabIndex = 171;
            this.WhiteActualCounts6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts6.WordWrap = false;
            // 
            // WhiteActualCounts5
            // 
            this.WhiteActualCounts5.Location = new System.Drawing.Point(660, 284);
            this.WhiteActualCounts5.Name = "WhiteActualCounts5";
            this.WhiteActualCounts5.ReadOnly = true;
            this.WhiteActualCounts5.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts5.TabIndex = 170;
            this.WhiteActualCounts5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts5.WordWrap = false;
            // 
            // WhiteActualCounts4
            // 
            this.WhiteActualCounts4.Location = new System.Drawing.Point(660, 244);
            this.WhiteActualCounts4.Name = "WhiteActualCounts4";
            this.WhiteActualCounts4.ReadOnly = true;
            this.WhiteActualCounts4.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts4.TabIndex = 169;
            this.WhiteActualCounts4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts4.WordWrap = false;
            // 
            // WhiteActualCounts3
            // 
            this.WhiteActualCounts3.Location = new System.Drawing.Point(660, 206);
            this.WhiteActualCounts3.Name = "WhiteActualCounts3";
            this.WhiteActualCounts3.ReadOnly = true;
            this.WhiteActualCounts3.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts3.TabIndex = 168;
            this.WhiteActualCounts3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts3.WordWrap = false;
            // 
            // WhiteActualCounts2
            // 
            this.WhiteActualCounts2.Location = new System.Drawing.Point(660, 168);
            this.WhiteActualCounts2.Name = "WhiteActualCounts2";
            this.WhiteActualCounts2.ReadOnly = true;
            this.WhiteActualCounts2.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts2.TabIndex = 167;
            this.WhiteActualCounts2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts2.WordWrap = false;
            // 
            // WhiteActualCounts1
            // 
            this.WhiteActualCounts1.Location = new System.Drawing.Point(660, 134);
            this.WhiteActualCounts1.Name = "WhiteActualCounts1";
            this.WhiteActualCounts1.ReadOnly = true;
            this.WhiteActualCounts1.Size = new System.Drawing.Size(43, 20);
            this.WhiteActualCounts1.TabIndex = 166;
            this.WhiteActualCounts1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteActualCounts1.WordWrap = false;
            // 
            // WhiteTargetCounts6
            // 
            this.WhiteTargetCounts6.Location = new System.Drawing.Point(599, 330);
            this.WhiteTargetCounts6.Name = "WhiteTargetCounts6";
            this.WhiteTargetCounts6.ReadOnly = true;
            this.WhiteTargetCounts6.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts6.TabIndex = 165;
            this.WhiteTargetCounts6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts6.WordWrap = false;
            // 
            // WhiteTargetCounts5
            // 
            this.WhiteTargetCounts5.Location = new System.Drawing.Point(599, 284);
            this.WhiteTargetCounts5.Name = "WhiteTargetCounts5";
            this.WhiteTargetCounts5.ReadOnly = true;
            this.WhiteTargetCounts5.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts5.TabIndex = 164;
            this.WhiteTargetCounts5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts5.WordWrap = false;
            // 
            // WhiteTargetCounts4
            // 
            this.WhiteTargetCounts4.Location = new System.Drawing.Point(599, 244);
            this.WhiteTargetCounts4.Name = "WhiteTargetCounts4";
            this.WhiteTargetCounts4.ReadOnly = true;
            this.WhiteTargetCounts4.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts4.TabIndex = 163;
            this.WhiteTargetCounts4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts4.WordWrap = false;
            // 
            // WhiteTargetCounts3
            // 
            this.WhiteTargetCounts3.Location = new System.Drawing.Point(599, 206);
            this.WhiteTargetCounts3.Name = "WhiteTargetCounts3";
            this.WhiteTargetCounts3.ReadOnly = true;
            this.WhiteTargetCounts3.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts3.TabIndex = 162;
            this.WhiteTargetCounts3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts3.WordWrap = false;
            // 
            // WhiteTargetCounts2
            // 
            this.WhiteTargetCounts2.Location = new System.Drawing.Point(599, 168);
            this.WhiteTargetCounts2.Name = "WhiteTargetCounts2";
            this.WhiteTargetCounts2.ReadOnly = true;
            this.WhiteTargetCounts2.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts2.TabIndex = 161;
            this.WhiteTargetCounts2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts2.WordWrap = false;
            // 
            // WhiteTargetCounts1
            // 
            this.WhiteTargetCounts1.Location = new System.Drawing.Point(599, 134);
            this.WhiteTargetCounts1.Name = "WhiteTargetCounts1";
            this.WhiteTargetCounts1.ReadOnly = true;
            this.WhiteTargetCounts1.Size = new System.Drawing.Size(43, 20);
            this.WhiteTargetCounts1.TabIndex = 160;
            this.WhiteTargetCounts1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetCounts1.WordWrap = false;
            // 
            // WhiteWeightByCounter6
            // 
            this.WhiteWeightByCounter6.Location = new System.Drawing.Point(538, 330);
            this.WhiteWeightByCounter6.Name = "WhiteWeightByCounter6";
            this.WhiteWeightByCounter6.ReadOnly = true;
            this.WhiteWeightByCounter6.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter6.TabIndex = 159;
            this.WhiteWeightByCounter6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter6.WordWrap = false;
            // 
            // WhiteWeightByCounter5
            // 
            this.WhiteWeightByCounter5.Location = new System.Drawing.Point(538, 281);
            this.WhiteWeightByCounter5.Name = "WhiteWeightByCounter5";
            this.WhiteWeightByCounter5.ReadOnly = true;
            this.WhiteWeightByCounter5.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter5.TabIndex = 158;
            this.WhiteWeightByCounter5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter5.WordWrap = false;
            // 
            // WhiteWeightByCounter4
            // 
            this.WhiteWeightByCounter4.Location = new System.Drawing.Point(538, 244);
            this.WhiteWeightByCounter4.Name = "WhiteWeightByCounter4";
            this.WhiteWeightByCounter4.ReadOnly = true;
            this.WhiteWeightByCounter4.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter4.TabIndex = 157;
            this.WhiteWeightByCounter4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter4.WordWrap = false;
            // 
            // WhiteWeightByCounter3
            // 
            this.WhiteWeightByCounter3.Location = new System.Drawing.Point(538, 206);
            this.WhiteWeightByCounter3.Name = "WhiteWeightByCounter3";
            this.WhiteWeightByCounter3.ReadOnly = true;
            this.WhiteWeightByCounter3.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter3.TabIndex = 156;
            this.WhiteWeightByCounter3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter3.WordWrap = false;
            // 
            // WhiteWeightByCounter2
            // 
            this.WhiteWeightByCounter2.Location = new System.Drawing.Point(538, 168);
            this.WhiteWeightByCounter2.Name = "WhiteWeightByCounter2";
            this.WhiteWeightByCounter2.ReadOnly = true;
            this.WhiteWeightByCounter2.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter2.TabIndex = 155;
            this.WhiteWeightByCounter2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter2.WordWrap = false;
            // 
            // WhiteWeightByCounter1
            // 
            this.WhiteWeightByCounter1.Location = new System.Drawing.Point(538, 134);
            this.WhiteWeightByCounter1.Name = "WhiteWeightByCounter1";
            this.WhiteWeightByCounter1.ReadOnly = true;
            this.WhiteWeightByCounter1.Size = new System.Drawing.Size(43, 20);
            this.WhiteWeightByCounter1.TabIndex = 154;
            this.WhiteWeightByCounter1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteWeightByCounter1.WordWrap = false;
            // 
            // WhiteTargetWeight6
            // 
            this.WhiteTargetWeight6.Location = new System.Drawing.Point(481, 330);
            this.WhiteTargetWeight6.Name = "WhiteTargetWeight6";
            this.WhiteTargetWeight6.ReadOnly = true;
            this.WhiteTargetWeight6.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight6.TabIndex = 153;
            this.WhiteTargetWeight6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight6.WordWrap = false;
            // 
            // WhiteTargetWeight5
            // 
            this.WhiteTargetWeight5.Location = new System.Drawing.Point(481, 284);
            this.WhiteTargetWeight5.Name = "WhiteTargetWeight5";
            this.WhiteTargetWeight5.ReadOnly = true;
            this.WhiteTargetWeight5.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight5.TabIndex = 152;
            this.WhiteTargetWeight5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight5.WordWrap = false;
            // 
            // WhiteTargetWeight4
            // 
            this.WhiteTargetWeight4.Location = new System.Drawing.Point(481, 244);
            this.WhiteTargetWeight4.Name = "WhiteTargetWeight4";
            this.WhiteTargetWeight4.ReadOnly = true;
            this.WhiteTargetWeight4.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight4.TabIndex = 151;
            this.WhiteTargetWeight4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight4.WordWrap = false;
            // 
            // WhiteTargetWeight3
            // 
            this.WhiteTargetWeight3.Location = new System.Drawing.Point(481, 206);
            this.WhiteTargetWeight3.Name = "WhiteTargetWeight3";
            this.WhiteTargetWeight3.ReadOnly = true;
            this.WhiteTargetWeight3.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight3.TabIndex = 150;
            this.WhiteTargetWeight3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight3.WordWrap = false;
            // 
            // WhiteTargetWeight2
            // 
            this.WhiteTargetWeight2.Location = new System.Drawing.Point(481, 168);
            this.WhiteTargetWeight2.Name = "WhiteTargetWeight2";
            this.WhiteTargetWeight2.ReadOnly = true;
            this.WhiteTargetWeight2.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight2.TabIndex = 149;
            this.WhiteTargetWeight2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight2.WordWrap = false;
            // 
            // WhiteUseData6
            // 
            this.WhiteUseData6.AutoSize = true;
            this.WhiteUseData6.Location = new System.Drawing.Point(435, 330);
            this.WhiteUseData6.Name = "WhiteUseData6";
            this.WhiteUseData6.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData6.TabIndex = 148;
            this.WhiteUseData6.UseVisualStyleBackColor = true;
            // 
            // WhiteUseData5
            // 
            this.WhiteUseData5.AutoSize = true;
            this.WhiteUseData5.Location = new System.Drawing.Point(435, 284);
            this.WhiteUseData5.Name = "WhiteUseData5";
            this.WhiteUseData5.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData5.TabIndex = 147;
            this.WhiteUseData5.UseVisualStyleBackColor = true;
            // 
            // WhiteUseData4
            // 
            this.WhiteUseData4.AutoSize = true;
            this.WhiteUseData4.Location = new System.Drawing.Point(435, 250);
            this.WhiteUseData4.Name = "WhiteUseData4";
            this.WhiteUseData4.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData4.TabIndex = 146;
            this.WhiteUseData4.UseVisualStyleBackColor = true;
            // 
            // WhiteUseData3
            // 
            this.WhiteUseData3.AutoSize = true;
            this.WhiteUseData3.Location = new System.Drawing.Point(435, 206);
            this.WhiteUseData3.Name = "WhiteUseData3";
            this.WhiteUseData3.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData3.TabIndex = 145;
            this.WhiteUseData3.UseVisualStyleBackColor = true;
            // 
            // WhiteUseData2
            // 
            this.WhiteUseData2.AutoSize = true;
            this.WhiteUseData2.Location = new System.Drawing.Point(435, 174);
            this.WhiteUseData2.Name = "WhiteUseData2";
            this.WhiteUseData2.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData2.TabIndex = 144;
            this.WhiteUseData2.UseVisualStyleBackColor = true;
            // 
            // WhiteUseData1
            // 
            this.WhiteUseData1.AutoSize = true;
            this.WhiteUseData1.Location = new System.Drawing.Point(435, 137);
            this.WhiteUseData1.Name = "WhiteUseData1";
            this.WhiteUseData1.Size = new System.Drawing.Size(15, 14);
            this.WhiteUseData1.TabIndex = 143;
            this.WhiteUseData1.UseVisualStyleBackColor = true;
            // 
            // WhiteCurrentCountsPerOz
            // 
            this.WhiteCurrentCountsPerOz.Location = new System.Drawing.Point(448, 412);
            this.WhiteCurrentCountsPerOz.Name = "WhiteCurrentCountsPerOz";
            this.WhiteCurrentCountsPerOz.ReadOnly = true;
            this.WhiteCurrentCountsPerOz.Size = new System.Drawing.Size(80, 20);
            this.WhiteCurrentCountsPerOz.TabIndex = 142;
            this.WhiteCurrentCountsPerOz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteCurrentCountsPerOz.WordWrap = false;
            // 
            // WhiteCurrentOffsetCounts
            // 
            this.WhiteCurrentOffsetCounts.Location = new System.Drawing.Point(451, 495);
            this.WhiteCurrentOffsetCounts.Name = "WhiteCurrentOffsetCounts";
            this.WhiteCurrentOffsetCounts.ReadOnly = true;
            this.WhiteCurrentOffsetCounts.Size = new System.Drawing.Size(80, 20);
            this.WhiteCurrentOffsetCounts.TabIndex = 141;
            this.WhiteCurrentOffsetCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteCurrentOffsetCounts.WordWrap = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(492, 521);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(76, 42);
            this.button5.TabIndex = 140;
            this.button5.Text = "Clear All Data";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(659, 472);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 44);
            this.button6.TabIndex = 139;
            this.button6.Text = "SAVE OFFSET COUNTS";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(432, 450);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 32);
            this.label12.TabIndex = 138;
            this.label12.Text = "Current \r\nOffset Counts";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(534, 376);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 32);
            this.label13.TabIndex = 137;
            this.label13.Text = "Calculated \r\nCounts Per Oz";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(659, 390);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 42);
            this.button7.TabIndex = 136;
            this.button7.Text = "SAVE COUNTS PER OZ";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // WhiteTargetWeight1
            // 
            this.WhiteTargetWeight1.Location = new System.Drawing.Point(481, 135);
            this.WhiteTargetWeight1.Name = "WhiteTargetWeight1";
            this.WhiteTargetWeight1.ReadOnly = true;
            this.WhiteTargetWeight1.Size = new System.Drawing.Size(33, 20);
            this.WhiteTargetWeight1.TabIndex = 135;
            this.WhiteTargetWeight1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteTargetWeight1.WordWrap = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(423, 376);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 32);
            this.label15.TabIndex = 134;
            this.label15.Text = "Current \r\nCounts Per Oz";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(540, 450);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 32);
            this.label16.TabIndex = 133;
            this.label16.Text = "Calculated\r\nOffset Counts";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // WhiteCalculatedOffsetCounts
            // 
            this.WhiteCalculatedOffsetCounts.Location = new System.Drawing.Point(559, 496);
            this.WhiteCalculatedOffsetCounts.Name = "WhiteCalculatedOffsetCounts";
            this.WhiteCalculatedOffsetCounts.ReadOnly = true;
            this.WhiteCalculatedOffsetCounts.Size = new System.Drawing.Size(80, 20);
            this.WhiteCalculatedOffsetCounts.TabIndex = 132;
            this.WhiteCalculatedOffsetCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteCalculatedOffsetCounts.WordWrap = false;
            // 
            // WhiteCalculatedCountsPerOz
            // 
            this.WhiteCalculatedCountsPerOz.Location = new System.Drawing.Point(559, 412);
            this.WhiteCalculatedCountsPerOz.Name = "WhiteCalculatedCountsPerOz";
            this.WhiteCalculatedCountsPerOz.ReadOnly = true;
            this.WhiteCalculatedCountsPerOz.Size = new System.Drawing.Size(80, 20);
            this.WhiteCalculatedCountsPerOz.TabIndex = 131;
            this.WhiteCalculatedCountsPerOz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteCalculatedCountsPerOz.WordWrap = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(598, 521);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(76, 42);
            this.button8.TabIndex = 130;
            this.button8.Text = "Calculate";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(583, 45);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(76, 24);
            this.label18.TabIndex = 179;
            this.label18.Text = "WHITE";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(696, 37);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(76, 42);
            this.button9.TabIndex = 181;
            this.button9.Text = "Hide";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // BlueFlow1
            // 
            this.BlueFlow1.Location = new System.Drawing.Point(374, 137);
            this.BlueFlow1.Name = "BlueFlow1";
            this.BlueFlow1.ReadOnly = true;
            this.BlueFlow1.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow1.TabIndex = 183;
            this.BlueFlow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow1.WordWrap = false;
            // 
            // BlueFlow2
            // 
            this.BlueFlow2.Location = new System.Drawing.Point(374, 168);
            this.BlueFlow2.Name = "BlueFlow2";
            this.BlueFlow2.ReadOnly = true;
            this.BlueFlow2.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow2.TabIndex = 184;
            this.BlueFlow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow2.WordWrap = false;
            // 
            // BlueFlow3
            // 
            this.BlueFlow3.Location = new System.Drawing.Point(374, 206);
            this.BlueFlow3.Name = "BlueFlow3";
            this.BlueFlow3.ReadOnly = true;
            this.BlueFlow3.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow3.TabIndex = 185;
            this.BlueFlow3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow3.WordWrap = false;
            // 
            // BlueFlow4
            // 
            this.BlueFlow4.Location = new System.Drawing.Point(374, 244);
            this.BlueFlow4.Name = "BlueFlow4";
            this.BlueFlow4.ReadOnly = true;
            this.BlueFlow4.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow4.TabIndex = 186;
            this.BlueFlow4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow4.WordWrap = false;
            // 
            // BlueFlow5
            // 
            this.BlueFlow5.Location = new System.Drawing.Point(374, 284);
            this.BlueFlow5.Name = "BlueFlow5";
            this.BlueFlow5.ReadOnly = true;
            this.BlueFlow5.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow5.TabIndex = 187;
            this.BlueFlow5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow5.WordWrap = false;
            // 
            // BlueFlow6
            // 
            this.BlueFlow6.Location = new System.Drawing.Point(374, 330);
            this.BlueFlow6.Name = "BlueFlow6";
            this.BlueFlow6.ReadOnly = true;
            this.BlueFlow6.Size = new System.Drawing.Size(33, 20);
            this.BlueFlow6.TabIndex = 188;
            this.BlueFlow6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BlueFlow6.WordWrap = false;
            // 
            // WhiteFlow1
            // 
            this.WhiteFlow1.Location = new System.Drawing.Point(771, 134);
            this.WhiteFlow1.Name = "WhiteFlow1";
            this.WhiteFlow1.ReadOnly = true;
            this.WhiteFlow1.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow1.TabIndex = 189;
            this.WhiteFlow1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow1.WordWrap = false;
            this.WhiteFlow1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // WhiteFlow2
            // 
            this.WhiteFlow2.Location = new System.Drawing.Point(771, 168);
            this.WhiteFlow2.Name = "WhiteFlow2";
            this.WhiteFlow2.ReadOnly = true;
            this.WhiteFlow2.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow2.TabIndex = 190;
            this.WhiteFlow2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow2.WordWrap = false;
            // 
            // WhiteFlow3
            // 
            this.WhiteFlow3.Location = new System.Drawing.Point(771, 206);
            this.WhiteFlow3.Name = "WhiteFlow3";
            this.WhiteFlow3.ReadOnly = true;
            this.WhiteFlow3.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow3.TabIndex = 191;
            this.WhiteFlow3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow3.WordWrap = false;
            // 
            // WhiteFlow4
            // 
            this.WhiteFlow4.Location = new System.Drawing.Point(771, 244);
            this.WhiteFlow4.Name = "WhiteFlow4";
            this.WhiteFlow4.ReadOnly = true;
            this.WhiteFlow4.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow4.TabIndex = 192;
            this.WhiteFlow4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow4.WordWrap = false;
            // 
            // WhiteFlow5
            // 
            this.WhiteFlow5.Location = new System.Drawing.Point(771, 284);
            this.WhiteFlow5.Name = "WhiteFlow5";
            this.WhiteFlow5.ReadOnly = true;
            this.WhiteFlow5.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow5.TabIndex = 193;
            this.WhiteFlow5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow5.WordWrap = false;
            // 
            // WhiteFlow6
            // 
            this.WhiteFlow6.Location = new System.Drawing.Point(771, 330);
            this.WhiteFlow6.Name = "WhiteFlow6";
            this.WhiteFlow6.ReadOnly = true;
            this.WhiteFlow6.Size = new System.Drawing.Size(33, 20);
            this.WhiteFlow6.TabIndex = 194;
            this.WhiteFlow6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WhiteFlow6.WordWrap = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(768, 100);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 26);
            this.label19.TabIndex = 195;
            this.label19.Text = "Flow \r\n(oz/s)";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(371, 102);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 26);
            this.label20.TabIndex = 196;
            this.label20.Text = "Flow \r\n(oz/s)";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FlowmeterCalibrate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 580);
            this.ControlBox = false;
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.WhiteFlow6);
            this.Controls.Add(this.WhiteFlow5);
            this.Controls.Add(this.WhiteFlow4);
            this.Controls.Add(this.WhiteFlow3);
            this.Controls.Add(this.WhiteFlow2);
            this.Controls.Add(this.WhiteFlow1);
            this.Controls.Add(this.BlueFlow6);
            this.Controls.Add(this.BlueFlow5);
            this.Controls.Add(this.BlueFlow4);
            this.Controls.Add(this.BlueFlow3);
            this.Controls.Add(this.BlueFlow2);
            this.Controls.Add(this.BlueFlow1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.WhiteActualWeight6);
            this.Controls.Add(this.WhiteActualWeight5);
            this.Controls.Add(this.WhiteActualWeight4);
            this.Controls.Add(this.WhiteActualWeight3);
            this.Controls.Add(this.WhiteActualWeight2);
            this.Controls.Add(this.WhiteActualWeight1);
            this.Controls.Add(this.WhiteActualCounts6);
            this.Controls.Add(this.WhiteActualCounts5);
            this.Controls.Add(this.WhiteActualCounts4);
            this.Controls.Add(this.WhiteActualCounts3);
            this.Controls.Add(this.WhiteActualCounts2);
            this.Controls.Add(this.WhiteActualCounts1);
            this.Controls.Add(this.WhiteTargetCounts6);
            this.Controls.Add(this.WhiteTargetCounts5);
            this.Controls.Add(this.WhiteTargetCounts4);
            this.Controls.Add(this.WhiteTargetCounts3);
            this.Controls.Add(this.WhiteTargetCounts2);
            this.Controls.Add(this.WhiteTargetCounts1);
            this.Controls.Add(this.WhiteWeightByCounter6);
            this.Controls.Add(this.WhiteWeightByCounter5);
            this.Controls.Add(this.WhiteWeightByCounter4);
            this.Controls.Add(this.WhiteWeightByCounter3);
            this.Controls.Add(this.WhiteWeightByCounter2);
            this.Controls.Add(this.WhiteWeightByCounter1);
            this.Controls.Add(this.WhiteTargetWeight6);
            this.Controls.Add(this.WhiteTargetWeight5);
            this.Controls.Add(this.WhiteTargetWeight4);
            this.Controls.Add(this.WhiteTargetWeight3);
            this.Controls.Add(this.WhiteTargetWeight2);
            this.Controls.Add(this.WhiteUseData6);
            this.Controls.Add(this.WhiteUseData5);
            this.Controls.Add(this.WhiteUseData4);
            this.Controls.Add(this.WhiteUseData3);
            this.Controls.Add(this.WhiteUseData2);
            this.Controls.Add(this.WhiteUseData1);
            this.Controls.Add(this.WhiteCurrentCountsPerOz);
            this.Controls.Add(this.WhiteCurrentOffsetCounts);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.WhiteTargetWeight1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.WhiteCalculatedOffsetCounts);
            this.Controls.Add(this.WhiteCalculatedCountsPerOz);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.BlueActualWeight6);
            this.Controls.Add(this.BlueActualWeight5);
            this.Controls.Add(this.BlueActualWeight4);
            this.Controls.Add(this.BlueActualWeight3);
            this.Controls.Add(this.BlueActualWeight2);
            this.Controls.Add(this.BlueActualWeight1);
            this.Controls.Add(this.BlueActualCounts6);
            this.Controls.Add(this.BlueActualCounts5);
            this.Controls.Add(this.BlueActualCounts4);
            this.Controls.Add(this.BlueActualCounts3);
            this.Controls.Add(this.BlueActualCounts2);
            this.Controls.Add(this.BlueActualCounts1);
            this.Controls.Add(this.BlueTargetCounts6);
            this.Controls.Add(this.BlueTargetCounts5);
            this.Controls.Add(this.BlueTargetCounts4);
            this.Controls.Add(this.BlueTargetCounts3);
            this.Controls.Add(this.BlueTargetCounts2);
            this.Controls.Add(this.BlueTargetCounts1);
            this.Controls.Add(this.BlueWeightByCounter6);
            this.Controls.Add(this.BlueWeightByCounter5);
            this.Controls.Add(this.BlueWeightByCounter4);
            this.Controls.Add(this.BlueWeightByCounter3);
            this.Controls.Add(this.BlueWeightByCounter2);
            this.Controls.Add(this.BlueWeightByCounter1);
            this.Controls.Add(this.BlueTargetWeight6);
            this.Controls.Add(this.BlueTargetWeight5);
            this.Controls.Add(this.BlueTargetWeight4);
            this.Controls.Add(this.BlueTargetWeight3);
            this.Controls.Add(this.BlueTargetWeight2);
            this.Controls.Add(this.BlueUseData6);
            this.Controls.Add(this.BlueUseData5);
            this.Controls.Add(this.BlueUseData4);
            this.Controls.Add(this.BlueUseData3);
            this.Controls.Add(this.BlueUseData2);
            this.Controls.Add(this.BlueUseData1);
            this.Controls.Add(this.BlueCurrentCountsPerOz);
            this.Controls.Add(this.BlueCurrentOffsetCounts);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.BlueTargetWeight1);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.BlueCalculatedOffsetCounts);
            this.Controls.Add(this.BlueCalculatedCountsPerOz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FlowmeterCalibrate";
            this.Text = "Flowmeter Calibration Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutVTIDataPlotViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BlueCalculatedCountsPerOz;
        private System.Windows.Forms.TextBox BlueCalculatedOffsetCounts;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox BlueTargetWeight1;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox BlueCurrentOffsetCounts;
        private System.Windows.Forms.TextBox BlueCurrentCountsPerOz;
        private System.Windows.Forms.CheckBox BlueUseData1;
        private System.Windows.Forms.CheckBox BlueUseData2;
        private System.Windows.Forms.CheckBox BlueUseData3;
        private System.Windows.Forms.CheckBox BlueUseData4;
        private System.Windows.Forms.CheckBox BlueUseData5;
        private System.Windows.Forms.CheckBox BlueUseData6;
        private System.Windows.Forms.TextBox BlueTargetWeight2;
        private System.Windows.Forms.TextBox BlueTargetWeight3;
        private System.Windows.Forms.TextBox BlueTargetWeight4;
        private System.Windows.Forms.TextBox BlueTargetWeight5;
        private System.Windows.Forms.TextBox BlueTargetWeight6;
        private System.Windows.Forms.TextBox BlueWeightByCounter1;
        private System.Windows.Forms.TextBox BlueWeightByCounter2;
        private System.Windows.Forms.TextBox BlueWeightByCounter3;
        private System.Windows.Forms.TextBox BlueWeightByCounter4;
        private System.Windows.Forms.TextBox BlueWeightByCounter5;
        private System.Windows.Forms.TextBox BlueWeightByCounter6;
        private System.Windows.Forms.TextBox BlueTargetCounts1;
        private System.Windows.Forms.TextBox BlueTargetCounts2;
        private System.Windows.Forms.TextBox BlueTargetCounts3;
        private System.Windows.Forms.TextBox BlueTargetCounts4;
        private System.Windows.Forms.TextBox BlueTargetCounts5;
        private System.Windows.Forms.TextBox BlueTargetCounts6;
        private System.Windows.Forms.TextBox BlueActualCounts1;
        private System.Windows.Forms.TextBox BlueActualCounts2;
        private System.Windows.Forms.TextBox BlueActualCounts3;
        private System.Windows.Forms.TextBox BlueActualCounts4;
        private System.Windows.Forms.TextBox BlueActualCounts5;
        private System.Windows.Forms.TextBox BlueActualCounts6;
        private System.Windows.Forms.TextBox BlueActualWeight1;
        private System.Windows.Forms.TextBox BlueActualWeight2;
        private System.Windows.Forms.TextBox BlueActualWeight3;
        private System.Windows.Forms.TextBox BlueActualWeight4;
        private System.Windows.Forms.TextBox BlueActualWeight5;
        private System.Windows.Forms.TextBox BlueActualWeight6;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox WhiteActualWeight6;
        private System.Windows.Forms.TextBox WhiteActualWeight5;
        private System.Windows.Forms.TextBox WhiteActualWeight4;
        private System.Windows.Forms.TextBox WhiteActualWeight3;
        private System.Windows.Forms.TextBox WhiteActualWeight2;
        private System.Windows.Forms.TextBox WhiteActualWeight1;
        private System.Windows.Forms.TextBox WhiteActualCounts6;
        private System.Windows.Forms.TextBox WhiteActualCounts5;
        private System.Windows.Forms.TextBox WhiteActualCounts4;
        private System.Windows.Forms.TextBox WhiteActualCounts3;
        private System.Windows.Forms.TextBox WhiteActualCounts2;
        private System.Windows.Forms.TextBox WhiteActualCounts1;
        private System.Windows.Forms.TextBox WhiteTargetCounts6;
        private System.Windows.Forms.TextBox WhiteTargetCounts5;
        private System.Windows.Forms.TextBox WhiteTargetCounts4;
        private System.Windows.Forms.TextBox WhiteTargetCounts3;
        private System.Windows.Forms.TextBox WhiteTargetCounts2;
        private System.Windows.Forms.TextBox WhiteTargetCounts1;
        private System.Windows.Forms.TextBox WhiteWeightByCounter6;
        private System.Windows.Forms.TextBox WhiteWeightByCounter5;
        private System.Windows.Forms.TextBox WhiteWeightByCounter4;
        private System.Windows.Forms.TextBox WhiteWeightByCounter3;
        private System.Windows.Forms.TextBox WhiteWeightByCounter2;
        private System.Windows.Forms.TextBox WhiteWeightByCounter1;
        private System.Windows.Forms.TextBox WhiteTargetWeight6;
        private System.Windows.Forms.TextBox WhiteTargetWeight5;
        private System.Windows.Forms.TextBox WhiteTargetWeight4;
        private System.Windows.Forms.TextBox WhiteTargetWeight3;
        private System.Windows.Forms.TextBox WhiteTargetWeight2;
        private System.Windows.Forms.CheckBox WhiteUseData6;
        private System.Windows.Forms.CheckBox WhiteUseData5;
        private System.Windows.Forms.CheckBox WhiteUseData4;
        private System.Windows.Forms.CheckBox WhiteUseData3;
        private System.Windows.Forms.CheckBox WhiteUseData2;
        private System.Windows.Forms.CheckBox WhiteUseData1;
        private System.Windows.Forms.TextBox WhiteCurrentCountsPerOz;
        private System.Windows.Forms.TextBox WhiteCurrentOffsetCounts;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox WhiteTargetWeight1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox WhiteCalculatedOffsetCounts;
        private System.Windows.Forms.TextBox WhiteCalculatedCountsPerOz;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox BlueFlow1;
        private System.Windows.Forms.TextBox BlueFlow2;
        private System.Windows.Forms.TextBox BlueFlow3;
        private System.Windows.Forms.TextBox BlueFlow4;
        private System.Windows.Forms.TextBox BlueFlow5;
        private System.Windows.Forms.TextBox BlueFlow6;
        private System.Windows.Forms.TextBox WhiteFlow1;
        private System.Windows.Forms.TextBox WhiteFlow2;
        private System.Windows.Forms.TextBox WhiteFlow3;
        private System.Windows.Forms.TextBox WhiteFlow4;
        private System.Windows.Forms.TextBox WhiteFlow5;
        private System.Windows.Forms.TextBox WhiteFlow6;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        //private System.Windows.Forms.Button button2;

    }
}

