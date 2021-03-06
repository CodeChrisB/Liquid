﻿namespace Liquid
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelChildForm = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.sideMenuPanel = new System.Windows.Forms.Panel();
            this.MovementButton = new System.Windows.Forms.Button();
            this.MiscButton = new System.Windows.Forms.Button();
            this.VisualButton = new System.Windows.Forms.Button();
            this.AimButton = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.panelChildForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.sideMenuPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChildForm
            // 
            this.panelChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(46)))));
            this.panelChildForm.Controls.Add(this.label1);
            this.panelChildForm.Controls.Add(this.pictureBox1);
            this.panelChildForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildForm.Location = new System.Drawing.Point(301, 46);
            this.panelChildForm.Name = "panelChildForm";
            this.panelChildForm.Size = new System.Drawing.Size(993, 479);
            this.panelChildForm.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Agency FB", 20.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(401, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 59);
            this.label1.TabIndex = 1;
            this.label1.Text = "Liquid Client";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::AqHaxCSGO.Properties.Resources.clientIcon;
            this.pictureBox1.Location = new System.Drawing.Point(394, 183);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // sideMenuPanel
            // 
            this.sideMenuPanel.AutoScroll = true;
            this.sideMenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.sideMenuPanel.Controls.Add(this.MovementButton);
            this.sideMenuPanel.Controls.Add(this.MiscButton);
            this.sideMenuPanel.Controls.Add(this.VisualButton);
            this.sideMenuPanel.Controls.Add(this.AimButton);
            this.sideMenuPanel.Controls.Add(this.panelLogo);
            this.sideMenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideMenuPanel.Location = new System.Drawing.Point(0, 46);
            this.sideMenuPanel.Margin = new System.Windows.Forms.Padding(6);
            this.sideMenuPanel.Name = "sideMenuPanel";
            this.sideMenuPanel.Size = new System.Drawing.Size(301, 479);
            this.sideMenuPanel.TabIndex = 9;
            // 
            // MovementButton
            // 
            this.MovementButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.MovementButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MovementButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MovementButton.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.MovementButton.Location = new System.Drawing.Point(0, 332);
            this.MovementButton.Margin = new System.Windows.Forms.Padding(6);
            this.MovementButton.Name = "MovementButton";
            this.MovementButton.Size = new System.Drawing.Size(301, 64);
            this.MovementButton.TabIndex = 7;
            this.MovementButton.Text = "Movement";
            this.MovementButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MovementButton.UseVisualStyleBackColor = false;
            // 
            // MiscButton
            // 
            this.MiscButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.MiscButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MiscButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MiscButton.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.MiscButton.Location = new System.Drawing.Point(0, 268);
            this.MiscButton.Margin = new System.Windows.Forms.Padding(6);
            this.MiscButton.Name = "MiscButton";
            this.MiscButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MiscButton.Size = new System.Drawing.Size(301, 64);
            this.MiscButton.TabIndex = 5;
            this.MiscButton.Text = "Misc";
            this.MiscButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.MiscButton.UseVisualStyleBackColor = false;
            // 
            // VisualButton
            // 
            this.VisualButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.VisualButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.VisualButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VisualButton.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.VisualButton.Location = new System.Drawing.Point(0, 204);
            this.VisualButton.Margin = new System.Windows.Forms.Padding(6);
            this.VisualButton.Name = "VisualButton";
            this.VisualButton.Size = new System.Drawing.Size(301, 64);
            this.VisualButton.TabIndex = 3;
            this.VisualButton.Text = "Visual";
            this.VisualButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VisualButton.UseVisualStyleBackColor = false;
            // 
            // AimButton
            // 
            this.AimButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.AimButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AimButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AimButton.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.AimButton.Location = new System.Drawing.Point(0, 140);
            this.AimButton.Margin = new System.Windows.Forms.Padding(6);
            this.AimButton.Name = "AimButton";
            this.AimButton.Size = new System.Drawing.Size(301, 64);
            this.AimButton.TabIndex = 1;
            this.AimButton.Text = " Aim";
            this.AimButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AimButton.UseVisualStyleBackColor = false;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Margin = new System.Windows.Forms.Padding(6);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(301, 140);
            this.panelLogo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.infoPanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 525);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 186);
            this.panel1.TabIndex = 10;
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.infoPanel.Location = new System.Drawing.Point(0, 0);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(1294, 186);
            this.infoPanel.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 711);
            this.Controls.Add(this.panelChildForm);
            this.Controls.Add(this.sideMenuPanel);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Brown;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(0, 46, 0, 0);
            this.ShowInTaskbar = false;
            this.Sizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liquid Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyEvent);
            this.panelChildForm.ResumeLayout(false);
            this.panelChildForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.sideMenuPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChildForm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel sideMenuPanel;
        private System.Windows.Forms.Button MovementButton;
        private System.Windows.Forms.Button MiscButton;
        private System.Windows.Forms.Button VisualButton;
        private System.Windows.Forms.Button AimButton;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel infoPanel;
    }
}

