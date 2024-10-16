using System;
using System.Linq;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Components;
using VTIWindowsControlLibrary.Classes.ClientForms;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    public partial class SchematicFormDual : SchematicFormBase
    {
        public SchematicFormDual()
        {
            InitializeComponent();

            //this.schematicPanelMain.LoadMetafileFromByteArray(Properties.Resources.schematic);

            foreach (SchematicCheckBox schematicCheckBox in schematicPanelMain.Controls.OfType<SchematicCheckBox>())
                schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);
            foreach (SchematicCheckBox schematicCheckBox in schematicPanelLeft.Controls.OfType<SchematicCheckBox>())
                schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);

        }

        void schematicCheckBox_Click(object sender, EventArgs e)
        {
            Config.TestMode = TestModes.Manual;
            if (schematicCheckBox16.Checked)//Blue Hi Side Charge
            {
                Machine.Cycle[0].bEnableHiSideCharge=true;
            }
            else
            {
                Machine.Cycle[0].bDisableHiSideCharge=true;
            }
            if (schematicCheckBox4.Checked)//Blue Low Side Charge
            {
                Machine.Cycle[0].bEnableLowSideCharge = true;
            }
            else
            {
                Machine.Cycle[0].bDisableLowSideCharge = true;
            }

            if (schematicCheckBox30.Checked)//Blue Hi Side Charge
            {
                Machine.Cycle[1].bEnableHiSideCharge = true;
            }
            else
            {
                Machine.Cycle[1].bDisableHiSideCharge = true;
            }
            if (schematicCheckBox27.Checked)//Blue Low Side Charge
            {
                Machine.Cycle[1].bEnableLowSideCharge = true;
            }
            else
            {
                Machine.Cycle[1].bDisableLowSideCharge = true;
            }
           
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void schematicCheckBox38_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox39_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox27_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox30_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox6_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox42_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}