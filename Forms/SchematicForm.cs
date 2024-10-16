using System;
using System.Linq;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.Configuration;
using VTI_EVAC_AND_SINGLE_CHARGE.Enums;
using VTIWindowsControlLibrary.Classes;
using VTIWindowsControlLibrary.Components;
using VTIWindowsControlLibrary.Classes.ClientForms;
using System.Threading;
using VTI_EVAC_AND_SINGLE_CHARGE.Classes.IOClasses;

namespace VTI_EVAC_AND_SINGLE_CHARGE.Forms
{
    public partial class SchematicForm : SchematicFormBase
    {
        public SchematicForm()
        {
            InitializeComponent();
            // loaded schematic into properties of form
            //this.schematicPanelMain.LoadMetafileFromByteArray(Properties.Resources.schematic);

            //foreach (SchematicCheckBox schematicCheckBox in schematicPanelMain.Controls.OfType<SchematicCheckBox>())
            //    schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);
            //foreach (SchematicCheckBox schematicCheckBox in schematicPanelLeft.Controls.OfType<SchematicCheckBox>())
            //    schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);
            ////foreach (SchematicCheckBox schematicCheckBox in schematicPanelCharge.Controls.OfType<SchematicCheckBox>())
            ////    schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);
            ////foreach (SchematicCheckBox schematicCheckBox in schematicPanelOther.Controls.OfType<SchematicCheckBox>())
            ////    schematicCheckBox.Click += new EventHandler(schematicCheckBox_Click);

            foreach (SchematicCheckBox schematicCheckBox in schematicPanelMain.Controls.OfType<SchematicCheckBox>())
                schematicCheckBox.CheckedUserChanging += schematicCheckBox_CheckedUserChanging;
            foreach (SchematicCheckBox schematicCheckBox in schematicPanelLeft.Controls.OfType<SchematicCheckBox>())
                schematicCheckBox.CheckedUserChanging += schematicCheckBox_CheckedUserChanging;
        

        }

        void schematicCheckBox_CheckedUserChanging(SchematicCheckBox sender, SchematicCheckBox.CheckChangingEventArgs e)
        {
            Config.TestMode = TestModes.Manual;
        }




        void schematicCheckBox_Click(object sender, EventArgs e)
        {
            {
                Config.TestMode = TestModes.Manual;
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void schematicPanelMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void SchematicForm_Load(object sender, EventArgs e)
        {
            //tabControl1.SelectTab(tabPage2);
            //tabControl1.SelectTab(tabPage3);
            tabControl1.SelectTab(tabPage1);

        }

        private void schematicPanelCharge_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox17_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicPanelOther_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void schematicCheckBox36_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}