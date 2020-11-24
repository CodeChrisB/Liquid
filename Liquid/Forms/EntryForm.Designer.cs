namespace Liquid
{
    partial class EntryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryForm));
            this.initButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.launcherButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // initButton
            // 
            this.initButton.BackColor = System.Drawing.SystemColors.HotTrack;
            this.initButton.Depth = 0;
            this.initButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.initButton.Location = new System.Drawing.Point(519, 367);
            this.initButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.initButton.Name = "initButton";
            this.initButton.Primary = true;
            this.initButton.Size = new System.Drawing.Size(422, 92);
            this.initButton.TabIndex = 10;
            this.initButton.Text = "Connect to the Client";
            this.initButton.UseVisualStyleBackColor = false;
            this.initButton.Click += new System.EventHandler(this.initButton_Click);
            // 
            // launcherButton
            // 
            this.launcherButton.BackColor = System.Drawing.Color.Peru;
            this.launcherButton.Depth = 0;
            this.launcherButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.125F);
            this.launcherButton.ForeColor = System.Drawing.Color.Black;
            this.launcherButton.Location = new System.Drawing.Point(16, 367);
            this.launcherButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.launcherButton.Name = "launcherButton";
            this.launcherButton.Primary = true;
            this.launcherButton.Size = new System.Drawing.Size(411, 92);
            this.launcherButton.TabIndex = 9;
            this.launcherButton.Text = "Launch The Game";
            this.launcherButton.UseVisualStyleBackColor = false;
            this.launcherButton.Click += new System.EventHandler(this.launcherButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::AqHaxCSGO.Properties.Resources.entryLayer;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.launcherButton);
            this.panel1.Controls.Add(this.initButton);
            this.panel1.Location = new System.Drawing.Point(-18, 40);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 528);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("MV Boli", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(284, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 85);
            this.label1.TabIndex = 11;
            this.label1.Text = "Liquid Client";
            // 
            // EntryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AqHaxCSGO.Properties.Resources.entryLayer;
            this.ClientSize = new System.Drawing.Size(916, 557);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialRaisedButton initButton;
        private MaterialSkin.Controls.MaterialRaisedButton launcherButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}