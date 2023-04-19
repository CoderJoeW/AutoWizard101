namespace ProjectMaelstrom
{
    partial class Main
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
            panel1 = new Panel();
            editSettingsBtn = new Button();
            manaAmountLabel = new Label();
            label2 = new Label();
            label1 = new Label();
            resolutionSelector = new ComboBox();
            startConfigurationBtn = new Button();
            panel2 = new Panel();
            loadHalfangBotBtn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(editSettingsBtn);
            panel1.Controls.Add(manaAmountLabel);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(resolutionSelector);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(5, 6, 5, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(927, 74);
            panel1.TabIndex = 0;
            // 
            // editSettingsBtn
            // 
            editSettingsBtn.Location = new Point(785, 18);
            editSettingsBtn.Margin = new Padding(3, 4, 3, 4);
            editSettingsBtn.Name = "editSettingsBtn";
            editSettingsBtn.Size = new Size(134, 40);
            editSettingsBtn.TabIndex = 1;
            editSettingsBtn.Text = "Settings";
            editSettingsBtn.UseVisualStyleBackColor = true;
            editSettingsBtn.Click += editSettingsBtn_Click;
            // 
            // manaAmountLabel
            // 
            manaAmountLabel.AutoSize = true;
            manaAmountLabel.Location = new Point(501, 24);
            manaAmountLabel.Margin = new Padding(5, 0, 5, 0);
            manaAmountLabel.Name = "manaAmountLabel";
            manaAmountLabel.Size = new Size(87, 30);
            manaAmountLabel.TabIndex = 3;
            manaAmountLabel.Text = "100/200";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(422, 24);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 30);
            label2.TabIndex = 2;
            label2.Text = "Mana:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 24);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 30);
            label1.TabIndex = 1;
            label1.Text = "Select Resolution";
            // 
            // resolutionSelector
            // 
            resolutionSelector.FormattingEnabled = true;
            resolutionSelector.Items.AddRange(new object[] { "1024x768", "1280x720", "2256x1504" });
            resolutionSelector.Location = new Point(197, 18);
            resolutionSelector.Margin = new Padding(5, 6, 5, 6);
            resolutionSelector.Name = "resolutionSelector";
            resolutionSelector.Size = new Size(191, 38);
            resolutionSelector.TabIndex = 0;
            resolutionSelector.Text = "1024x768";
            resolutionSelector.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // startConfigurationBtn
            // 
            startConfigurationBtn.Location = new Point(21, 106);
            startConfigurationBtn.Margin = new Padding(5, 6, 5, 6);
            startConfigurationBtn.Name = "startConfigurationBtn";
            startConfigurationBtn.Size = new Size(274, 74);
            startConfigurationBtn.TabIndex = 1;
            startConfigurationBtn.Text = "Start Configuration";
            startConfigurationBtn.UseVisualStyleBackColor = true;
            startConfigurationBtn.Click += startConfigurationBtn_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(335, 106);
            panel2.Name = "panel2";
            panel2.Size = new Size(580, 400);
            panel2.TabIndex = 2;
            // 
            // loadHalfangBotBtn
            // 
            loadHalfangBotBtn.Location = new Point(21, 192);
            loadHalfangBotBtn.Margin = new Padding(5, 6, 5, 6);
            loadHalfangBotBtn.Name = "loadHalfangBotBtn";
            loadHalfangBotBtn.Size = new Size(274, 74);
            loadHalfangBotBtn.TabIndex = 3;
            loadHalfangBotBtn.Text = "Load Halfang Bot";
            loadHalfangBotBtn.UseVisualStyleBackColor = true;
            loadHalfangBotBtn.Click += loadHalfangBotBtn_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 518);
            Controls.Add(loadHalfangBotBtn);
            Controls.Add(panel2);
            Controls.Add(startConfigurationBtn);
            Controls.Add(panel1);
            Margin = new Padding(5, 6, 5, 6);
            MaximumSize = new Size(951, 582);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox resolutionSelector;
        private Label manaAmountLabel;
        private Label label2;
        private Button editSettingsBtn;
        private Button startConfigurationBtn;
        private Panel panel2;
        private Button loadHalfangBotBtn;
    }
}