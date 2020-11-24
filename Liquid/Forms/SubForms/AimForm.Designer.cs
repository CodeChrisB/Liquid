
namespace AqHaxCSGO.Forms.SubForms
{
    partial class AimForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxTrigger = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aim FORM";
            // 
            // checkBoxTrigger
            // 
            this.checkBoxTrigger.AutoSize = true;
            this.checkBoxTrigger.Location = new System.Drawing.Point(56, 57);
            this.checkBoxTrigger.Name = "checkBoxTrigger";
            this.checkBoxTrigger.Size = new System.Drawing.Size(138, 29);
            this.checkBoxTrigger.TabIndex = 1;
            this.checkBoxTrigger.Text = "TriggerBot";
            this.checkBoxTrigger.UseVisualStyleBackColor = true;
            this.checkBoxTrigger.CheckedChanged += new System.EventHandler(this.checkBoxTrigger_CheckedChanged);
            // 
            // AimForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 478);
            this.Controls.Add(this.checkBoxTrigger);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AimForm";
            this.Text = "AimForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxTrigger;
    }
}