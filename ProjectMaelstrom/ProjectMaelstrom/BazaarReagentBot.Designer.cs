namespace ProjectMaelstrom
{
    partial class BazaarReagentBot
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBox1;
        private Label label1;
        private Button btn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            label1 = new Label();
            btn = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.Dock = DockStyle.Left;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(0, 0);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(245, 450);
            listBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(251, 9);
            label1.Name = "label1";
            label1.Size = new Size(231, 25);
            label1.TabIndex = 1;
            label1.Text = "Select Reagents To Scan For";
            // 
            // btn
            // 
            btn.Location = new Point(251, 59);
            btn.Name = "btn";
            btn.Size = new Size(100, 40);
            btn.TabIndex = 2;
            btn.Text = "Start Bot";
            btn.UseVisualStyleBackColor = true;
            btn.Click += startButton_Click;
            // 
            // BazaarReagentBot
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(btn);
            Name = "BazaarReagentBot";
            Text = "BazaarReagentBot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
