namespace ProjectMaelstrom
{
    partial class SettingsForm
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
            label1 = new Label();
            ocrSpaceApiKey = new TextBox();
            saveSettingsBtn = new Button();
            label2 = new Label();
            selectedGameResolution = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(193, 30);
            label1.TabIndex = 0;
            label1.Text = "OCR Space API Key";
            // 
            // ocrSpaceApiKey
            // 
            ocrSpaceApiKey.Location = new Point(14, 44);
            ocrSpaceApiKey.Margin = new Padding(4, 4, 4, 4);
            ocrSpaceApiKey.Name = "ocrSpaceApiKey";
            ocrSpaceApiKey.Size = new Size(359, 35);
            ocrSpaceApiKey.TabIndex = 1;
            // 
            // saveSettingsBtn
            // 
            saveSettingsBtn.Location = new Point(13, 178);
            saveSettingsBtn.Margin = new Padding(4, 4, 4, 4);
            saveSettingsBtn.Name = "saveSettingsBtn";
            saveSettingsBtn.Size = new Size(360, 41);
            saveSettingsBtn.TabIndex = 4;
            saveSettingsBtn.Text = "Save";
            saveSettingsBtn.UseVisualStyleBackColor = true;
            saveSettingsBtn.Click += saveSettingsBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(231, 30);
            label2.TabIndex = 5;
            label2.Text = "Select Game Resolution";
            // 
            // selectedGameResolution
            // 
            selectedGameResolution.FormattingEnabled = true;
            selectedGameResolution.Items.AddRange(new object[] { "1280x720" });
            selectedGameResolution.Location = new Point(14, 133);
            selectedGameResolution.Name = "selectedGameResolution";
            selectedGameResolution.Size = new Size(359, 38);
            selectedGameResolution.TabIndex = 6;
            selectedGameResolution.Text = "1280x720";
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 243);
            Controls.Add(selectedGameResolution);
            Controls.Add(label2);
            Controls.Add(saveSettingsBtn);
            Controls.Add(ocrSpaceApiKey);
            Controls.Add(label1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "SettingsForm";
            Text = "Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ocrSpaceApiKey;
        private Button saveSettingsBtn;
        private Label label2;
        private ComboBox selectedGameResolution;
    }
}