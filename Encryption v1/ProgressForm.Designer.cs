namespace Encryption_v1
{
    partial class ProgressForm
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
            this.Progress = new Encryption_v1.SolidProgress();
            this.Display = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Progress
            // 
            this.Progress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Progress.Location = new System.Drawing.Point(12, 25);
            this.Progress.MaxValue = 100;
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(401, 20);
            this.Progress.TabIndex = 0;
            this.Progress.Value = 0;
            // 
            // Display
            // 
            this.Display.AutoSize = true;
            this.Display.Location = new System.Drawing.Point(12, 9);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(43, 13);
            this.Display.TabIndex = 1;
            this.Display.Text = "readout";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 58);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.Progress);
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SolidProgress Progress;
        private System.Windows.Forms.Label Display;
    }
}