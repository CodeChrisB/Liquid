using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using Liquid.MemoryManagers;
using MaterialSkin;
using MaterialSkin.Controls;
using System.IO;
using Liquid.Objects;
using System.Runtime.InteropServices;

namespace Liquid 
{
    public partial class EntryForm : MaterialForm 
    {
        public EntryForm() 
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue200, Primary.Blue300, Primary.Red600, Accent.Blue200, TextShade.WHITE);
        }


        private void launcherButton_Click(object sender, EventArgs e) 
        {
            Process.Start("steam://rungameid/730");
        }

        private void initButton_Click(object sender, EventArgs e) 
        {
            if ((Process.GetProcessesByName("csgo").Length > 0)) 
            {
               
                new MainForm().Show();
             
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red900, Primary.Red600, Accent.Red200, TextShade.WHITE);
                this.Visible = false;
            }
        }


    }
}
