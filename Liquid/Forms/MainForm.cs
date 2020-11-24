using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Windows.Forms;
using Liquid.MemoryManagers;
using Liquid.Objects;
using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using System.Net;
using SlimDX.DirectInput;
using System.Threading;
using Liquid.Misc;
using Liquid.Objects.Structs;

namespace Liquid 
{
    public partial class MainForm : MaterialForm 
    {
        private bool IsWaitingForInput = false;
        private int currentKey = 16;
        KeysConverter keyConverter = new KeysConverter();

        System.Timers.Timer timer = new System.Timers.Timer();




        public MainForm() 
        {
            InitializeComponent();
            AllocConsole();


            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "Liquid");
            string fullSavePath = Path.Combine(programDataPath, "CSG.dat");
            try {
                string[] lines = File.ReadAllLines(fullSavePath);
                if (lines.Length == 0) {
                    File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    lines = File.ReadAllLines(fullSavePath);
                }
                Color colorCT = new Color();
                Color colorT = new Color();
                Color colorR = new Color();
                int p = 0;
                foreach (string line in lines) {
                    if (p == 1) {
                        colorCT = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    if (p == 2) {
                        colorT = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    if (p == 3) {
                        colorR = Color.FromArgb(Convert.ToInt32(line.Substring(0, 3)), Convert.ToInt32(line.Substring(3, 3)), Convert.ToInt32(line.Substring(6, 3)));
                    }
                    p++;
                }

                //ctColor.BackColor = colorCT;
                //tColor.BackColor = colorT;
                //rColor.BackColor = colorR;
                Globals.WallHackEnemy = colorCT;
                Globals.WallHackTeammate = colorT;
                Globals.RenderColor = colorR;
            } catch {
                try {
                    try {
                        File.Create(fullSavePath);
                        File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    } catch {
                        Directory.CreateDirectory(programDataPath);
                        File.Create(fullSavePath);
                        File.WriteAllLines(fullSavePath, new string[] { "00", "255000000", "000255000", "255000000" });
                    }
                } catch {
                    MessageBox.Show("IO Error. \nApp save file cannot be initialized. \nRunning the program again should shortly fix th issue.",
                                    "FATAL ERROR");
                    Environment.Exit(1);
                }
            }

            SaveManager.SettingsScheme settings = SaveManager.LoadSettings();
            Globals.BunnyHopAccuracy = Math.Abs(settings.BunnyAccuracy - 5);
            Globals.IdleWait = Math.Abs(settings.IdlePowerConsumption - 50) / 10;
            Globals.UsageDelay = Math.Abs(settings.UsagePowerConsumption - 5);
            Globals.TriggerKey = settings.TriggerKey;
            currentKey = settings.TriggerKey;

 


            this.FormClosing += new FormClosingEventHandler(AppEx);

            timer.Elapsed += new ElapsedEventHandler(UpdateHandle);
            timer.Interval = 90000;
            timer.Start();



        }

       
 


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
                if (this.InvokeRequired) {
                    this.BeginInvoke((MethodInvoker)delegate () 
                    {
                        this.Hide();
                        Program.entryForm.Visible = true;
                        this.Close();
                        });
                }
            }
        }


        private void MainForm_Load(object sender, EventArgs e) 
        {
            NetvarManager.LoadOffsets();
            OffsetManager.ScanOffsets();
            Threads.InitAll();
            FreeConsole();
            NetvarManager.netvarList.Clear();
        }


      
        private void ctColor_Click(object sender, EventArgs e) 
        {
            ColorDialog clrDialog = new ColorDialog();
            Color c = new Color();

            if (clrDialog.ShowDialog() == DialogResult.OK) 
            {
                c = clrDialog.Color;
            }

            string r = ToFormedColor(c.R.ToString());
            string g = ToFormedColor(c.G.ToString());
            string b = ToFormedColor(c.B.ToString());

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "Liquid");
            string fullSavePath = Path.Combine(programDataPath, "CSG.dat");
            string[] lines = File.ReadAllLines(fullSavePath);
            lines[1] = r + g + b;
            File.WriteAllLines(fullSavePath, lines);

            int r2 = Convert.ToInt32(r);
            int g2 = Convert.ToInt32(g);
            int b2 = Convert.ToInt32(b);

            //ctColor.BackColor = Color.FromArgb(r2, g2, b2);

            Globals.WallHackEnemy = Color.FromArgb(r2, g2, b2);
        }

        private void tColor_Click(object sender, EventArgs e) 
        {
            ColorDialog clrDialog = new ColorDialog();
            Color c = new Color();

            if (clrDialog.ShowDialog() == DialogResult.OK) 
            {
                c = clrDialog.Color;
            }

            string r = ToFormedColor(c.R.ToString());
            string g = ToFormedColor(c.G.ToString());
            string b = ToFormedColor(c.B.ToString());

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "Liquid");
            string fullSavePath = Path.Combine(programDataPath, "CSG.dat");
            string[] lines = File.ReadAllLines(fullSavePath);
            lines[2] = r + g + b;
            File.WriteAllLines(fullSavePath, lines);

            int r2 = Convert.ToInt32(r);
            int g2 = Convert.ToInt32(g);
            int b2 = Convert.ToInt32(b);

            //tColor.BackColor = Color.FromArgb(r2, g2, b2);

            Globals.WallHackTeammate = Color.FromArgb(r2, g2, b2);
        }

        private void rColor_Click(object sender, EventArgs e) 
        {
            ColorDialog clrDialog = new ColorDialog();
            Color c = new Color();

            if (clrDialog.ShowDialog() == DialogResult.OK) 
            {
                c = clrDialog.Color;
            }

            string r = ToFormedColor(c.R.ToString());
            string g = ToFormedColor(c.G.ToString());
            string b = ToFormedColor(c.B.ToString());

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string programDataPath = Path.Combine(appDataPath, "Liquid");
            string fullSavePath = Path.Combine(programDataPath, "CSG.dat");
            string[] lines = File.ReadAllLines(fullSavePath);
            lines[3] = r + g + b;
            File.WriteAllLines(fullSavePath, lines);

            int r2 = Convert.ToInt32(r);
            int g2 = Convert.ToInt32(g);
            int b2 = Convert.ToInt32(b);

            //rColor.BackColor = Color.FromArgb(r2, g2, b2);

            Globals.RenderColor = Color.FromArgb(r2, g2, b2);
        }

        string ToFormedColor(string f) 
        {
            if (f.Length == 2) 
            {
                f = "0" + f;
                return f;
            } 
            else if (f.Length == 1) 
            {
                f = "00" + f;
                return f;
            } 
            else 
            {
                return f;
            }
        }

        


        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();



        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This will come in the Future");
        }



        private void activeStateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           // Globals.active = activeStateCheckBox.Checked;
        }

        private void CheckTeamCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This will come in the Future");
        }

        private void legitModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This will come in the Future");
        }
    }
}

