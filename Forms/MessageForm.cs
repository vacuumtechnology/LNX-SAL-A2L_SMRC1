using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }
        private void buttonOK_Click(object sender, EventArgs e)
        {
            Machine.Test[0].MessageBoxFlag = false;
            MyStaticVariables.WaitForAcknowledgeFlagBlue = true;
            this.Hide();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void ChangeButtonText(string buttonTxt)
        {
            buttonOK.Text = buttonTxt;
        }

        public void ChangeFontColor(Color fontColor)
        {
            buttonOK.ForeColor = fontColor;
            textBox1.ForeColor = fontColor;
        }
    }
}
