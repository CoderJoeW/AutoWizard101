namespace ProjectMaelstrom
{
    partial class Settings
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
            this.lazarusOrgId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lazarusAuthKey = new System.Windows.Forms.TextBox();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lazarus Organization Id";
            // 
            // lazarusOrgId
            // 
            this.lazarusOrgId.Location = new System.Drawing.Point(12, 37);
            this.lazarusOrgId.Name = "lazarusOrgId";
            this.lazarusOrgId.Size = new System.Drawing.Size(300, 31);
            this.lazarusOrgId.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lazarus Auth Key";
            // 
            // lazarusAuthKey
            // 
            this.lazarusAuthKey.Location = new System.Drawing.Point(12, 129);
            this.lazarusAuthKey.Name = "lazarusAuthKey";
            this.lazarusAuthKey.Size = new System.Drawing.Size(300, 31);
            this.lazarusAuthKey.TabIndex = 3;
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Location = new System.Drawing.Point(12, 180);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(300, 34);
            this.saveSettingsBtn.TabIndex = 4;
            this.saveSettingsBtn.Text = "Save";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 232);
            this.Controls.Add(this.saveSettingsBtn);
            this.Controls.Add(this.lazarusAuthKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lazarusOrgId);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox lazarusOrgId;
        private Label label2;
        private TextBox lazarusAuthKey;
        private Button saveSettingsBtn;
    }
}