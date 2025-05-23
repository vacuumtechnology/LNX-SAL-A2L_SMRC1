namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveConfigFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemPressuresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCommandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editCycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.schematicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.digitalIOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.machineDataLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valvesPanelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualCmdExecLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterChangeLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMeters = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonManualCommands = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEventViewer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEditCycle = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSchematic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDigitalIO = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDataPlot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonValvesPanel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonShutdown = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CurrentTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.SystemID = new System.Windows.Forms.ToolStripStatusLabel();
            this.OpID = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerStatusBar = new System.Windows.Forms.Timer(this.components);
            this.timerSlidePanels = new System.Windows.Forms.Timer(this.components);
            this.ScannerText = new System.Windows.Forms.RichTextBox();
            this.showActiveCycleStepsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.windowToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windowToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(16, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(1685, 58);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.saveConfigFileToolStripMenuItem});
            this.fileToolStripMenuItem.MergeIndex = 1;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(87, 48);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.MergeIndex = 20;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveConfigFileToolStripMenuItem
            // 
            this.saveConfigFileToolStripMenuItem.Name = "saveConfigFileToolStripMenuItem";
            this.saveConfigFileToolStripMenuItem.Size = new System.Drawing.Size(448, 54);
            this.saveConfigFileToolStripMenuItem.Text = "Save Config File...";
            this.saveConfigFileToolStripMenuItem.Click += new System.EventHandler(this.saveConfigFileToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemPressuresToolStripMenuItem,
            this.manualCommandsToolStripMenuItem,
            this.eventViewerToolStripMenuItem,
            this.editCycleToolStripMenuItem,
            this.schematicToolStripMenuItem,
            this.digitalIOToolStripMenuItem,
            this.dataPlotToolStripMenuItem,
            this.toolStripSeparator2,
            this.machineDataLogToolStripMenuItem,
            this.permissionsToolStripMenuItem,
            this.testHistoryToolStripMenuItem,
            this.valvesPanelToolStripMenuItem,
            this.manualCmdExecLogToolStripMenuItem,
            this.parameterChangeLogToolStripMenuItem,
            this.showActiveCycleStepsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(106, 48);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // systemPressuresToolStripMenuItem
            // 
            this.systemPressuresToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.Meters;
            this.systemPressuresToolStripMenuItem.Name = "systemPressuresToolStripMenuItem";
            this.systemPressuresToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.systemPressuresToolStripMenuItem.Text = "S&ystem Signals";
            this.systemPressuresToolStripMenuItem.Click += new System.EventHandler(this.systemPressuresToolStripMenuItem_Click);
            // 
            // manualCommandsToolStripMenuItem
            // 
            this.manualCommandsToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.barcode;
            this.manualCommandsToolStripMenuItem.Name = "manualCommandsToolStripMenuItem";
            this.manualCommandsToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.manualCommandsToolStripMenuItem.Text = "&Manual Commands";
            this.manualCommandsToolStripMenuItem.Click += new System.EventHandler(this.manualCommandsToolStripMenuItem_Click);
            // 
            // eventViewerToolStripMenuItem
            // 
            this.eventViewerToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.EventLog;
            this.eventViewerToolStripMenuItem.Name = "eventViewerToolStripMenuItem";
            this.eventViewerToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.eventViewerToolStripMenuItem.Text = "Event &Viewer";
            this.eventViewerToolStripMenuItem.Click += new System.EventHandler(this.systemLogToolStripMenuItem_Click);
            // 
            // editCycleToolStripMenuItem
            // 
            this.editCycleToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.WRENCH;
            this.editCycleToolStripMenuItem.Name = "editCycleToolStripMenuItem";
            this.editCycleToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.editCycleToolStripMenuItem.Text = "&Edit Cycle";
            this.editCycleToolStripMenuItem.Click += new System.EventHandler(this.editCycleToolStripMenuItem_Click);
            // 
            // schematicToolStripMenuItem
            // 
            this.schematicToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.gears;
            this.schematicToolStripMenuItem.Name = "schematicToolStripMenuItem";
            this.schematicToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.schematicToolStripMenuItem.Text = "&Schematic";
            this.schematicToolStripMenuItem.Click += new System.EventHandler(this.schematicToolStripMenuItem_Click);
            // 
            // digitalIOToolStripMenuItem
            // 
            this.digitalIOToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.NET08;
            this.digitalIOToolStripMenuItem.Name = "digitalIOToolStripMenuItem";
            this.digitalIOToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.digitalIOToolStripMenuItem.Text = "&Digital I/O";
            // 
            // dataPlotToolStripMenuItem
            // 
            this.dataPlotToolStripMenuItem.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.GRAPH04;
            this.dataPlotToolStripMenuItem.Name = "dataPlotToolStripMenuItem";
            this.dataPlotToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.dataPlotToolStripMenuItem.Text = "Data &Plot";
            this.dataPlotToolStripMenuItem.Click += new System.EventHandler(this.dataPlotToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(501, 6);
            // 
            // machineDataLogToolStripMenuItem
            // 
            this.machineDataLogToolStripMenuItem.Name = "machineDataLogToolStripMenuItem";
            this.machineDataLogToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.machineDataLogToolStripMenuItem.Text = "Machine Data L&og";
            this.machineDataLogToolStripMenuItem.Visible = false;
            // 
            // permissionsToolStripMenuItem
            // 
            this.permissionsToolStripMenuItem.Name = "permissionsToolStripMenuItem";
            this.permissionsToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.permissionsToolStripMenuItem.Text = "Pe&rmissions";
            this.permissionsToolStripMenuItem.Click += new System.EventHandler(this.permissionsToolStripMenuItem_Click);
            // 
            // testHistoryToolStripMenuItem
            // 
            this.testHistoryToolStripMenuItem.Name = "testHistoryToolStripMenuItem";
            this.testHistoryToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.testHistoryToolStripMenuItem.Text = "Test &History";
            this.testHistoryToolStripMenuItem.Click += new System.EventHandler(this.testHistoryToolStripMenuItem_Click);
            // 
            // valvesPanelToolStripMenuItem
            // 
            this.valvesPanelToolStripMenuItem.Name = "valvesPanelToolStripMenuItem";
            this.valvesPanelToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.valvesPanelToolStripMenuItem.Text = "Valves Panel";
            this.valvesPanelToolStripMenuItem.Visible = false;
            this.valvesPanelToolStripMenuItem.Click += new System.EventHandler(this.valvesPanelToolStripMenuItem_Click);
            // 
            // manualCmdExecLogToolStripMenuItem
            // 
            this.manualCmdExecLogToolStripMenuItem.Name = "manualCmdExecLogToolStripMenuItem";
            this.manualCmdExecLogToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.manualCmdExecLogToolStripMenuItem.Text = "Manual Cmd Exec Log";
            this.manualCmdExecLogToolStripMenuItem.Click += new System.EventHandler(this.manualCmdExecLogToolStripMenuItem_Click);
            // 
            // parameterChangeLogToolStripMenuItem
            // 
            this.parameterChangeLogToolStripMenuItem.Name = "parameterChangeLogToolStripMenuItem";
            this.parameterChangeLogToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.parameterChangeLogToolStripMenuItem.Text = "Parameter Change Log";
            this.parameterChangeLogToolStripMenuItem.Click += new System.EventHandler(this.parameterChangeLogToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(152, 48);
            this.windowToolStripMenuItem.Text = "&Window";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(104, 48);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(266, 54);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMeters,
            this.toolStripButtonManualCommands,
            this.toolStripButtonEventViewer,
            this.toolStripButtonEditCycle,
            this.toolStripButtonSchematic,
            this.toolStripButtonDigitalIO,
            this.toolStripButtonDataPlot,
            this.toolStripButtonValvesPanel,
            this.toolStripSeparator1,
            this.toolStripButtonShutdown});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 58);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1685, 43);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonMeters
            // 
            this.toolStripButtonMeters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMeters.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.Meters;
            this.toolStripButtonMeters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMeters.Name = "toolStripButtonMeters";
            this.toolStripButtonMeters.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonMeters.Text = "Show Meters";
            this.toolStripButtonMeters.Click += new System.EventHandler(this.toolStripButtonMeters_Click);
            // 
            // toolStripButtonManualCommands
            // 
            this.toolStripButtonManualCommands.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonManualCommands.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.barcode;
            this.toolStripButtonManualCommands.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonManualCommands.Name = "toolStripButtonManualCommands";
            this.toolStripButtonManualCommands.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonManualCommands.Text = "Manual Commands";
            this.toolStripButtonManualCommands.Click += new System.EventHandler(this.toolStripButtonManualCommands_Click);
            // 
            // toolStripButtonEventViewer
            // 
            this.toolStripButtonEventViewer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEventViewer.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.EventLog;
            this.toolStripButtonEventViewer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEventViewer.Name = "toolStripButtonEventViewer";
            this.toolStripButtonEventViewer.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonEventViewer.Text = "Event Viewer";
            this.toolStripButtonEventViewer.Click += new System.EventHandler(this.toolStripButtonSystemLog_Click);
            // 
            // toolStripButtonEditCycle
            // 
            this.toolStripButtonEditCycle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditCycle.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.WRENCH;
            this.toolStripButtonEditCycle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditCycle.Name = "toolStripButtonEditCycle";
            this.toolStripButtonEditCycle.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonEditCycle.Text = "Edit Cycle";
            this.toolStripButtonEditCycle.Click += new System.EventHandler(this.toolStripButtonEditCycle_Click);
            // 
            // toolStripButtonSchematic
            // 
            this.toolStripButtonSchematic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSchematic.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.gears;
            this.toolStripButtonSchematic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSchematic.Name = "toolStripButtonSchematic";
            this.toolStripButtonSchematic.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonSchematic.Text = "Schematic";
            this.toolStripButtonSchematic.Click += new System.EventHandler(this.toolStripButtonSchematic_Click);
            // 
            // toolStripButtonDigitalIO
            // 
            this.toolStripButtonDigitalIO.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDigitalIO.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.NET08;
            this.toolStripButtonDigitalIO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDigitalIO.Name = "toolStripButtonDigitalIO";
            this.toolStripButtonDigitalIO.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonDigitalIO.Text = "Digital I/O";
            this.toolStripButtonDigitalIO.Click += new System.EventHandler(this.toolStripButtonDigitalIO_Click);
            // 
            // toolStripButtonDataPlot
            // 
            this.toolStripButtonDataPlot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDataPlot.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.GRAPH04;
            this.toolStripButtonDataPlot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDataPlot.Name = "toolStripButtonDataPlot";
            this.toolStripButtonDataPlot.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonDataPlot.Text = "Data Plot";
            this.toolStripButtonDataPlot.Click += new System.EventHandler(this.toolStripButtonDataPlot_Click);
            // 
            // toolStripButtonValvesPanel
            // 
            this.toolStripButtonValvesPanel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonValvesPanel.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.Valves;
            this.toolStripButtonValvesPanel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonValvesPanel.Name = "toolStripButtonValvesPanel";
            this.toolStripButtonValvesPanel.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonValvesPanel.Text = "Valves";
            this.toolStripButtonValvesPanel.Visible = false;
            this.toolStripButtonValvesPanel.Click += new System.EventHandler(this.toolStripButtonValvesPanel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // toolStripButtonShutdown
            // 
            this.toolStripButtonShutdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonShutdown.Image = global::VTI_EVAC_AND_SINGLE_CHARGE.Properties.Resources.Red_X;
            this.toolStripButtonShutdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShutdown.Name = "toolStripButtonShutdown";
            this.toolStripButtonShutdown.Size = new System.Drawing.Size(58, 36);
            this.toolStripButtonShutdown.Text = "Shutdown System";
            this.toolStripButtonShutdown.Click += new System.EventHandler(this.toolStripButtonShutdown_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentTime,
            this.CurrentDate,
            this.SystemID,
            this.OpID});
            this.statusStrip1.Location = new System.Drawing.Point(0, 1026);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(3, 0, 37, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1685, 54);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CurrentTime
            // 
            this.CurrentTime.Name = "CurrentTime";
            this.CurrentTime.Size = new System.Drawing.Size(127, 41);
            this.CurrentTime.Text = "8:00 AM";
            // 
            // CurrentDate
            // 
            this.CurrentDate.Name = "CurrentDate";
            this.CurrentDate.Size = new System.Drawing.Size(106, 41);
            this.CurrentDate.Text = "8/8/08";
            // 
            // SystemID
            // 
            this.SystemID.Name = "SystemID";
            this.SystemID.Size = new System.Drawing.Size(150, 41);
            this.SystemID.Text = "System ID";
            // 
            // OpID
            // 
            this.OpID.Name = "OpID";
            this.OpID.Size = new System.Drawing.Size(169, 41);
            this.OpID.Text = "Logged Off";
            // 
            // timerStatusBar
            // 
            this.timerStatusBar.Tick += new System.EventHandler(this.timerStatusBar_Tick);
            // 
            // timerSlidePanels
            // 
            this.timerSlidePanels.Tick += new System.EventHandler(this.timerSlidePanels_Tick);
            // 
            // ScannerText
            // 
            this.ScannerText.AcceptsTab = true;
            this.ScannerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScannerText.Location = new System.Drawing.Point(941, 57);
            this.ScannerText.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.ScannerText.Name = "ScannerText";
            this.ScannerText.Size = new System.Drawing.Size(737, 66);
            this.ScannerText.TabIndex = 8;
            this.ScannerText.Text = "";
            this.ScannerText.TextChanged += new System.EventHandler(this.ScannerText_TextChanged);
            // 
            // showActiveCycleStepsToolStripMenuItem
            // 
            this.showActiveCycleStepsToolStripMenuItem.Name = "showActiveCycleStepsToolStripMenuItem";
            this.showActiveCycleStepsToolStripMenuItem.Size = new System.Drawing.Size(504, 54);
            this.showActiveCycleStepsToolStripMenuItem.Text = "Show Active Cycle Steps";
            this.showActiveCycleStepsToolStripMenuItem.Click += new System.EventHandler(this.showActiveCycleStepsToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1685, 1080);
            this.Controls.Add(this.ScannerText);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MinimumSize = new System.Drawing.Size(1653, 1023);
            this.Name = "MainForm";
            this.Text = "VTI_EVAC_AND_SINGLE_CHARGE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMeters;
        private System.Windows.Forms.ToolStripButton toolStripButtonManualCommands;
        private System.Windows.Forms.ToolStripButton toolStripButtonEventViewer;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditCycle;
        private System.Windows.Forms.ToolStripButton toolStripButtonSchematic;
        private System.Windows.Forms.ToolStripButton toolStripButtonDigitalIO;
        private System.Windows.Forms.ToolStripButton toolStripButtonDataPlot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShutdown;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem machineDataLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permissionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel CurrentTime;
        private System.Windows.Forms.ToolStripStatusLabel CurrentDate;
        private System.Windows.Forms.ToolStripStatusLabel SystemID;
        private System.Windows.Forms.ToolStripStatusLabel OpID;
        private System.Windows.Forms.ToolStripMenuItem systemPressuresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualCommandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventViewerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editCycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem schematicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem digitalIOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Timer timerStatusBar;
        private System.Windows.Forms.ToolStripButton toolStripButtonValvesPanel;
        private System.Windows.Forms.ToolStripMenuItem valvesPanelToolStripMenuItem;
        public System.Windows.Forms.Timer timerSlidePanels;
        public System.Windows.Forms.RichTextBox ScannerText;
        private System.Windows.Forms.ToolStripMenuItem saveConfigFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualCmdExecLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parameterChangeLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showActiveCycleStepsToolStripMenuItem;
    }
}

