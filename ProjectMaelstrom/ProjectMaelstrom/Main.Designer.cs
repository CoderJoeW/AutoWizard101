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
            startConfigurationBtn = new Button();
            panel2 = new Panel();
            loadHalfangBotBtn = new Button();
            loadBazaarReagentBot = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(editSettingsBtn);
            panel1.Controls.Add(manaAmountLabel);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(772, 62);
            panel1.TabIndex = 0;
            // 
            // editSettingsBtn
            // 
            editSettingsBtn.Location = new Point(654, 15);
            editSettingsBtn.Margin = new Padding(2, 3, 2, 3);
            editSettingsBtn.Name = "editSettingsBtn";
            editSettingsBtn.Size = new Size(112, 33);
            editSettingsBtn.TabIndex = 1;
            editSettingsBtn.Text = "Settings";
            editSettingsBtn.UseVisualStyleBackColor = true;
            editSettingsBtn.Click += editSettingsBtn_Click;
            // 
            // manaAmountLabel
            // 
            manaAmountLabel.AutoSize = true;
            manaAmountLabel.Location = new Point(85, 15);
            manaAmountLabel.Margin = new Padding(4, 0, 4, 0);
            manaAmountLabel.Name = "manaAmountLabel";
            manaAmountLabel.Size = new Size(79, 25);
            manaAmountLabel.TabIndex = 3;
            manaAmountLabel.Text = "100/200";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 15);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 2;
            label2.Text = "Mana:";
            // 
            // startConfigurationBtn
            // 
            startConfigurationBtn.Location = new Point(18, 88);
            startConfigurationBtn.Margin = new Padding(4, 5, 4, 5);
            startConfigurationBtn.Name = "startConfigurationBtn";
            startConfigurationBtn.Size = new Size(228, 62);
            startConfigurationBtn.TabIndex = 1;
            startConfigurationBtn.Text = "Start Configuration";
            startConfigurationBtn.UseVisualStyleBackColor = true;
            startConfigurationBtn.Click += startConfigurationBtn_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(279, 88);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(483, 333);
            panel2.TabIndex = 2;
            // 
            // loadHalfangBotBtn
            // 
            loadHalfangBotBtn.Location = new Point(18, 160);
            loadHalfangBotBtn.Margin = new Padding(4, 5, 4, 5);
            loadHalfangBotBtn.Name = "loadHalfangBotBtn";
            loadHalfangBotBtn.Size = new Size(228, 62);
            loadHalfangBotBtn.TabIndex = 3;
            loadHalfangBotBtn.Text = "Load Halfang Bot";
            loadHalfangBotBtn.UseVisualStyleBackColor = true;
            loadHalfangBotBtn.Click += loadHalfangBotBtn_Click;
            // 
            // loadBazaarReagentBot
            // 
            loadBazaarReagentBot.Location = new Point(18, 232);
            loadBazaarReagentBot.Margin = new Padding(4, 5, 4, 5);
            loadBazaarReagentBot.Name = "loadBazaarReagentBot";
            loadBazaarReagentBot.Size = new Size(228, 62);
            loadBazaarReagentBot.TabIndex = 4;
            loadBazaarReagentBot.Text = "Load Reagent Bot";
            loadBazaarReagentBot.UseVisualStyleBackColor = true;
            loadBazaarReagentBot.Click += loadBazaarReagentBot_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(772, 432);
            Controls.Add(loadBazaarReagentBot);
            Controls.Add(loadHalfangBotBtn);
            Controls.Add(panel2);
            Controls.Add(startConfigurationBtn);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            MaximumSize = new Size(796, 494);
            Name = "Main";
            Text = "Main";
            Load += Main_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label manaAmountLabel;
        private Label label2;
        private Button editSettingsBtn;
        private Button startConfigurationBtn;
        private Panel panel2;
        private Button loadHalfangBotBtn;
        private Button loadBazaarReagentBot;
    }
}