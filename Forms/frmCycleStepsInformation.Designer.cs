﻿namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    partial class CycleStepsActiveForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CycleStepsActiveForm));
            this.rtbCycleStepsActive = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbCycleStepsActive
            // 
            this.rtbCycleStepsActive.Location = new System.Drawing.Point(8, 5);
            this.rtbCycleStepsActive.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.rtbCycleStepsActive.Name = "rtbCycleStepsActive";
            this.rtbCycleStepsActive.Size = new System.Drawing.Size(647, 534);
            this.rtbCycleStepsActive.TabIndex = 0;
            this.rtbCycleStepsActive.Text = "";
            this.rtbCycleStepsActive.TextChanged += new System.EventHandler(this.rtbCycleStepsActive_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 575);
            this.button1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CycleStepsActiveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 713);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rtbCycleStepsActive);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.Name = "CycleStepsActiveForm";
            this.Text = "Information";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CycleStepsActiveForm_Show);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtbCycleStepsActive;
        private System.Windows.Forms.Button button1;

    }
}