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

            #region VERSION CHECK
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            int[] versionParts = { fvi.FileMajorPart, fvi.FileMinorPart, fvi.FileBuildPart };
            int[] latestVersion = GetVersion();

            if (latestVersion[0] != 0) {
                if (latestVersion[0] > versionParts[0]) {
                    DialogResult dr = MessageBox.Show("New version of AqHax-CSGO is available. Would you like to update ?", "New Version !", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes) {
                        Process.Start("https://github.com/krxdev-kaan/AqHax-CSGO/releases");
                    }
                } else if (latestVersion[0] == versionParts[0]) {
                    if (latestVersion[1] > versionParts[1]) {
                        DialogResult dr = MessageBox.Show("New version of AqHax-CSGO is available. Would you like to update ?", "New Version !", MessageBoxButtons.YesNo);
                        if (dr == DialogResult.Yes) {
                            Process.Start("https://github.com/krxdev-kaan/AqHax-CSGO/releases");
                        }
                    } else if (latestVersion[1] == versionParts[1]) {
                        if (latestVersion[2] > versionParts[2]) {
                            DialogResult dr = MessageBox.Show("New version of AqHax-CSGO is available. Would you like to update ?", "New Version !", MessageBoxButtons.YesNo);
                            if (dr == DialogResult.Yes) {
                                Process.Start("https://github.com/krxdev-kaan/AqHax-CSGO/releases");
                            }
                        }
                    }
                }
            }
            #endregion

            
            #region Visuals Data
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

                ctColor.BackColor = colorCT;
                tColor.BackColor = colorT;
                rColor.BackColor = colorR;
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
            if (!Memory.Init()) {
                timer.Stop();
                timer.Dispose();
                timer = null;
                if (Program.entryForm.InvokeRequired) {
                    Program.entryForm.BeginInvoke((MethodInvoker)delegate () {
                        Program.entryForm.Visible = true;
                    });
                }
                this.Close();
            } else {
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


            #region
            activeStateCheckBox.Size = new Size(200, 200);
            #endregion
        }

        private int[] GetVersion() 
        {
            try 
            {
                using (var webC = new WebClient()) 
                {
                    webC.Headers.Add("User-Agent", "request");
                    string json = webC.DownloadString("https://api.github.com/repos/krxdev-kaan/AqHax-CSGO/releases");
                    JsonTextReader reader = new JsonTextReader(new StringReader(json));
                    while (reader.Read()) 
                    {
                        if (reader.Value != null) 
                        {
                            if (reader.TokenType == JsonToken.PropertyName) 
                            {
                                if (reader.Value.ToString() == "tag_name") 
                                {
                                    reader.Read();
                                    string version = reader.Value.ToString();
                                    string int_ified = version.Substring(1);
                                    string[] splitted = int_ified.Split('.');
                                    int[] result = new int[3];
                                    for (int i = 0; i < splitted.Length; i++) 
                                    {
                                        result[i] = Convert.ToInt32(splitted[i]);
                                    }
                                    return result;
                                }
                            }
                        }
                    }
                    return new int[] { 0, 0, 0 };
                }
            } 
            catch 
            {
                return new int[] { 0, 0, 0 };
            }
        }
 

        #region Events
        private void AppEx(object sender, FormClosingEventArgs e) 
        {
            Environment.Exit(1);
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            if (IsWaitingForInput) 
            {
                currentKey = e.KeyValue;
                keyButton.Text = e.KeyCode.ToString();
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
                        var materialSkinManager = MaterialSkinManager.Instance;
                        materialSkinManager.AddFormToManage(this); 
                        materialSkinManager.ColorScheme = new ColorScheme(Primary.Red600, Primary.Red900, Primary.Red600, Accent.Red200, TextShade.WHITE);
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
        #endregion

        #region User Events

        private void wallCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.WallHackEnabled = wallCheckBox.Checked;
        }

        private void fullCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.WallHackFullEnabled = fullCheckBox.Checked;
        }

        private void fresnelCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.WallHackGlowOnly = fresnelCheckBox.Checked;
        }

        private void radarCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.RadarEnabled = radarCheckBox.Checked;
        }

        private void renderColorCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.RenderEnabled = renderColorCheckBox.Checked;
        }

        private void enemyCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.RenderEnemyOnly = enemyCheckBox.Checked;
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

            ctColor.BackColor = Color.FromArgb(r2, g2, b2);

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

            tColor.BackColor = Color.FromArgb(r2, g2, b2);

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

            rColor.BackColor = Color.FromArgb(r2, g2, b2);

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

        private void aimCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.AimEnabled = aimCheckBox.Checked;

            if (Globals.AimEnabled) 
            {
                triggerBotCheckBox.Checked = false;
            }
        }

        private void shootOnCollideCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.AimShootOnCollide = shootOnCollideCheckBox.Checked;
        }

        private void recoilControlCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.AimRecoil = recoilControlCheckBox.Checked;
        }

        private void triggerBotCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.TriggerEnabled = triggerBotCheckBox.Checked;

            if (Globals.TriggerEnabled) 
            {
                aimCheckBox.Checked = false;
            }
        }

        private void holdForTriggerCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.TriggerPressOnlyEnabled = holdForTriggerCheckBox.Checked;
        }

        private void aimAssistCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            MessageBox.Show("This feature is not implemented yet because im not sure if i want to add it right now.");
        }

        private void bunnyHopCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.BunnyHopEnabled = bunnyHopCheckBox.Checked;
        }

        private void antiFlashCheckBox_CheckedChanged(object sender, EventArgs e) 
        {
            Globals.AntiFlashEnabled = antiFlashCheckBox.Checked;
        }

        private void keyButton_Click(object sender, EventArgs e) 
        {
            IsWaitingForInput = !IsWaitingForInput;
            keyButton.Text = "Press any key..";
        }

        private void saveButton_Click(object sender, EventArgs e) 
        {
            if (IsWaitingForInput) 
            {
                MessageBox.Show("Aim/Trigger Key undefined.", "Error");
                return;
            }

            Globals.TriggerKey = currentKey;
            Globals.BunnyHopAccuracy = bunnySlider.Value;
            Globals.IdleWait = idlePowerSlider.Value;
            Globals.UsageDelay = usagePowerSlider.Value;

            SaveManager.SettingsScheme settings = new SaveManager.SettingsScheme();
            settings.BunnyAccuracy = Globals.BunnyHopAccuracy;
            settings.IdlePowerConsumption = Globals.IdleWait;
            settings.UsagePowerConsumption = Globals.UsageDelay;
            settings.TriggerKey = Globals.TriggerKey;
            SaveManager.SaveSettings(settings);
        }
      

        private void fullBloomSlider_Scroll(object sender, EventArgs e)
        {
            Globals.FullBloomAmount = ((float)fullBloomSlider.Value) / 10;
        }

        private void renderBrightnessSlider_Scroll(object sender, EventArgs e)
        {
            Globals.RenderBrightness = renderBrightnessSlider.Value;
        }
        #endregion

        #region Some Shit For Loading State
        [DllImport("kernel32.dll")]
        static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();

        #endregion

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("This will come in the Future");
        }



        private void activeStateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Globals.active = activeStateCheckBox.Checked;
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
