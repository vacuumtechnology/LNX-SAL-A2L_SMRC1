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
    public partial class BadgeForm : Form
    {
        public BadgeForm()
        {
            InitializeComponent();
        }

        private void BadgeForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
        }

        private void textBadge_TextChanged(object sender, EventArgs e)
        {
            if (textBadge.Text.Length >= 8)
            {
                //Machine.scannerText = "";
                OK.PerformClick();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {

        }
    }
}
