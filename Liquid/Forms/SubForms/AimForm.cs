using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Liquid.Objects;

namespace AqHaxCSGO.Forms.SubForms
{
    public partial class AimForm : Form
    {
        public AimForm()
        {
            InitializeComponent();
        }

        private void checkBoxTrigger_CheckedChanged(object sender, EventArgs e)
        {
            Globals.TriggerEnabled = checkBoxTrigger.Checked;
        }
    }
}
