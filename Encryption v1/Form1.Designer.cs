namespace Encryption_v1
{
    partial class Form1
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
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.KeyBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.testButton = new System.Windows.Forms.Button();
            this.ShowPassCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(76, 72);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(124, 27);
            this.EncryptButton.TabIndex = 0;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(221, 72);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(124, 27);
            this.DecryptButton.TabIndex = 1;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // KeyBox
            // 
            this.KeyBox.Location = new System.Drawing.Point(12, 25);
            this.KeyBox.Name = "KeyBox";
            this.KeyBox.Size = new System.Drawing.Size(408, 20);
            this.KeyBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(44, 190);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(124, 27);
            this.testButton.TabIndex = 4;
            this.testButton.Text = "benchmark";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // ShowPassCheck
            // 
            this.ShowPassCheck.AutoSize = true;
            this.ShowPassCheck.Location = new System.Drawing.Point(12, 49);
            this.ShowPassCheck.Name = "ShowPassCheck";
            this.ShowPassCheck.Size = new System.Drawing.Size(102, 17);
            this.ShowPassCheck.TabIndex = 5;
            this.ShowPassCheck.Text = "Show Password";
            this.ShowPassCheck.UseVisualStyleBackColor = true;
            this.ShowPassCheck.CheckedChanged += new System.EventHandler(this.ShowPassCheck_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(281, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 27);
            this.button1.TabIndex = 6;
            this.button1.Text = "test2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 259);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowPassCheck);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyBox);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.TextBox KeyBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.CheckBox ShowPassCheck;
        private System.Windows.Forms.Button button1;
    }
}

