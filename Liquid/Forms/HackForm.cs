using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using AqHaxCSGO.Forms.SubForms;
using Liquid;
using Liquid.MemoryManagers;
using Liquid.Objects;
using MaterialSkin;
using MaterialSkin.Controls;

namespace AqHaxCSGO.Forms
{
    public partial class HackForm : MaterialForm
    {
        private bool IsWaitingForInput = false;
        private int currentKey = 16;
        KeysConverter keyConverter = new KeysConverter();

        System.Timers.Timer timer = new System.Timers.Timer();




        public HackForm()
        {
            InitializeComponent();
            AllocConsole();


            #region Visuals Data
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "Liquid");
            string fullSavePath = Path.Combine(programDataPath, "CSG.dat");
            try
            {
                string[] lines = File.ReadAllLines(fullSavePath);
                if (lines.Length == 0)
                {
                    File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    lines = File.ReadAllLines(fullSavePath);
                }
                Color colorCT = new Color();
                Color colorT = new Color();
                Color colorR = new Color();
                int p = 0;
                foreach (string line in lines)
                {
                    if (p == 1)
                    {
                        colorCT = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    if (p == 2)
                    {
                        colorT = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    if (p == 3)
                    {
                        colorR = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    p++;
                }

               
                Globals.WallHackEnemy = colorCT;
                Globals.WallHackTeammate = colorT;
                Globals.RenderColor = colorR;
            }
            catch
            {
                try
                {
                    try
                    {
                        File.Create(fullSavePath);
                        File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    }
                    catch
                    {
                        Directory.CreateDirectory(programDataPath);
                        File.Create(fullSavePath);
                        File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    }
                }
                catch
                {
                    MessageBox.Show("IO Error. \nApp save file cannot be initialized. \nRunning the program again should shortly fix th issue.",
                                    "FATAL ERROR");
                    Environment.Exit(1);
                }
            }
            #endregion

            #region Settings
            SaveManager.SettingsScheme settings = SaveManager.LoadSettings();
            Globals.BunnyHopAccuracy = Math.Abs(settings.BunnyAccuracy - 5);
            Globals.IdleWait = Math.Abs(settings.IdlePowerConsumption - 50) / 10;
            Globals.UsageDelay = Math.Abs(settings.UsagePowerConsumption - 5);
            Globals.TriggerKey = settings.TriggerKey;
            currentKey = settings.TriggerKey;
            #endregion

            #region SETUP
            if (!Memory.Init())
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
                if (Program.entryForm.InvokeRequired)
                {
                    Program.entryForm.BeginInvoke((MethodInvoker)delegate () {
                        Program.entryForm.Visible = true;
                    });
                }
                this.Close();
            }
            else
            {
                var materialSkinManager = MaterialSkinManager.Instance;
                materialSkinManager.AddFormToManage(this);
                materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue200, Primary.Blue300, Primary.Red600, Accent.Blue200, TextShade.WHITE);
            }
            #endregion

            #region EVENT REGISTER
            this.FormClosing += new FormClosingEventHandler(AppEx);

            timer.Elapsed += new ElapsedEventHandler(UpdateHandle);
            timer.Interval = 90000;
            timer.Start();
            #endregion


          
        }


        #region Some Shit For Loading State
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        #endregion

        private void AppEx(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (IsWaitingForInput)
            {
                currentKey = e.KeyValue;
                //keyButton.Text = e.KeyCode.ToString();
                IsWaitingForInput = false;
            }
        }
        private void UpdateHandle(object source, ElapsedEventArgs e)
        {
            if (!(Process.GetProcessesByName("csgo").Length > 0))
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
                if (this.InvokeRequired)
                {
                    this.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.Hide();
                        Program.entryForm.Visible = true;
                        this.Close();
                    });
                }
            }
        }


        private void AimButton_Click(object sender, EventArgs e)
        {
            openChildForm(new AimForm());
        }

        private void VisualButton_Click(object sender, EventArgs e)
        {
            
        }

        private void MiscButton_Click(object sender, EventArgs e)
        {
            
        }

        private void MovementButton_Click(object sender, EventArgs e)
        {
        
        }



        private Form activeForm = null;
        private void openChildForm(Form child)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = child;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;

            panelChildForm.Controls.Add(child);
            panelChildForm.Tag = child;
            child.BringToFront();
            child.Show();
        }
    }
}
