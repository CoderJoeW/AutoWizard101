namespace ProjectMaelstrom
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startBtn = new System.Windows.Forms.Button();
            this.resolutionSelector = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.availableReagents = new System.Windows.Forms.ListBox();
            this.purchaseReagents = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(288, 58);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(75, 40);
            this.startBtn.TabIndex = 0;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // resolutionSelector
            // 
            this.resolutionSelector.FormattingEnabled = true;
            this.resolutionSelector.Items.AddRange(new object[] {
            "800x600"});
            this.resolutionSelector.Location = new System.Drawing.Point(158, 6);
            this.resolutionSelector.Name = "resolutionSelector";
            this.resolutionSelector.Size = new System.Drawing.Size(121, 23);
            this.resolutionSelector.TabIndex = 1;
            this.resolutionSelector.Text = "800x600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose Game Resolution";
            // 
            // availableReagents
            // 
            this.availableReagents.FormattingEnabled = true;
            this.availableReagents.ItemHeight = 15;
            this.availableReagents.Items.AddRange(new object[] {
            "Amethyst",
            "Bone",
            "Tin"});
            this.availableReagents.Location = new System.Drawing.Point(12, 58);
            this.availableReagents.Name = "availableReagents";
            this.availableReagents.Size = new System.Drawing.Size(106, 229);
            this.availableReagents.TabIndex = 3;
            this.availableReagents.SelectedIndexChanged += new System.EventHandler(this.availableReagents_SelectedIndexChanged);
            // 
            // purchaseReagents
            // 
            this.purchaseReagents.FormattingEnabled = true;
            this.purchaseReagents.ItemHeight = 15;
            this.purchaseReagents.Location = new System.Drawing.Point(158, 58);
            this.purchaseReagents.Name = "purchaseReagents";
            this.purchaseReagents.Size = new System.Drawing.Size(106, 229);
            this.purchaseReagents.TabIndex = 4;
            this.purchaseReagents.SelectedIndexChanged += new System.EventHandler(this.purchaseReagents_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Reagents";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Purchase Reagents";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Press F1 to stop bot";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 298);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.purchaseReagents);
            this.Controls.Add(this.availableReagents);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resolutionSelector);
            this.Controls.Add(this.startBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button startBtn;
        private ComboBox resolutionSelector;
        private Label label1;
        private ListBox availableReagents;
        private ListBox purchaseReagents;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}