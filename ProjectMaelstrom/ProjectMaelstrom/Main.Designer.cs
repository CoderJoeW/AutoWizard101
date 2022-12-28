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
            this.panel1 = new System.Windows.Forms.Panel();
            this.editSettingsBtn = new System.Windows.Forms.Button();
            this.manaAmountLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.resolutionSelector = new System.Windows.Forms.ComboBox();
            this.startConfigurationBtn = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editSettingsBtn);
            this.panel1.Controls.Add(this.manaAmountLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.resolutionSelector);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(545, 37);
            this.panel1.TabIndex = 0;
            // 
            // editSettingsBtn
            // 
            this.editSettingsBtn.Location = new System.Drawing.Point(458, 9);
            this.editSettingsBtn.Margin = new System.Windows.Forms.Padding(2);
            this.editSettingsBtn.Name = "editSettingsBtn";
            this.editSettingsBtn.Size = new System.Drawing.Size(78, 20);
            this.editSettingsBtn.TabIndex = 1;
            this.editSettingsBtn.Text = "Settings";
            this.editSettingsBtn.UseVisualStyleBackColor = true;
            this.editSettingsBtn.Click += new System.EventHandler(this.editSettingsBtn_Click);
            // 
            // manaAmountLabel
            // 
            this.manaAmountLabel.AutoSize = true;
            this.manaAmountLabel.Location = new System.Drawing.Point(292, 12);
            this.manaAmountLabel.Name = "manaAmountLabel";
            this.manaAmountLabel.Size = new System.Drawing.Size(48, 15);
            this.manaAmountLabel.TabIndex = 3;
            this.manaAmountLabel.Text = "100/200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mana:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Resolution";
            // 
            // resolutionSelector
            // 
            this.resolutionSelector.FormattingEnabled = true;
            this.resolutionSelector.Items.AddRange(new object[] {
            "1024x768",
            "1280x720",
            "2256x1504"});
            this.resolutionSelector.Location = new System.Drawing.Point(115, 9);
            this.resolutionSelector.Name = "resolutionSelector";
            this.resolutionSelector.Size = new System.Drawing.Size(113, 23);
            this.resolutionSelector.TabIndex = 0;
            this.resolutionSelector.Text = "1024x768";
            this.resolutionSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // startConfigurationBtn
            // 
            this.startConfigurationBtn.Location = new System.Drawing.Point(12, 53);
            this.startConfigurationBtn.Name = "startConfigurationBtn";
            this.startConfigurationBtn.Size = new System.Drawing.Size(160, 37);
            this.startConfigurationBtn.TabIndex = 1;
            this.startConfigurationBtn.Text = "Start Configuration";
            this.startConfigurationBtn.UseVisualStyleBackColor = true;
            this.startConfigurationBtn.Click += new System.EventHandler(this.startConfigurationBtn_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(244, 59);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(258, 172);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 274);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.startConfigurationBtn);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(565, 323);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private ComboBox resolutionSelector;
        private Label manaAmountLabel;
        private Label label2;
        private Button editSettingsBtn;
        private Button startConfigurationBtn;
        private RichTextBox richTextBox1;
    }
}