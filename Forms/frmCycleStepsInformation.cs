﻿using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    public partial class CycleStepsActiveForm : Form
    {

        public CycleStepsActiveForm()
        {
            InitializeComponent();

        }

        private void rtbCycleStepsActive_TextChanged(object sender, EventArgs e)
        {

        }

        private void CycleStepsActiveForm_Load(object sender, EventArgs e)
        {

        }

        private void CycleStepsActiveForm_Show(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Mode.ShowCycleSteps.ProcessValue = false;
            Config.Mode.Save();
            
        }
    }
}