namespace ProjectMaelstrom
{
    partial class HalfangFarmingBot
    {
        private System.ComponentModel.IContainer components = null;

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
            button1 = new Button();
            label1 = new Label();
            botState = new Label();
            label2 = new Label();
            inBattleText = new Label();
            battleWonText = new Label();
            label4 = new Label();
            joiningDungeonText = new Label();
            label5 = new Label();
            inDungeonText = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(104, 284);
            button1.Name = "button1";
            button1.Size = new Size(191, 58);
            button1.TabIndex = 0;
            button1.Text = "Start/Stop Bot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(104, 25);
            label1.Name = "label1";
            label1.Size = new Size(95, 28);
            label1.TabIndex = 1;
            label1.Text = "Bot State:";
            // 
            // botState
            // 
            botState.AutoSize = true;
            botState.Font = new Font("Segoe UI", 10F);
            botState.Location = new Point(274, 25);
            botState.Name = "botState";
            botState.Size = new Size(44, 28);
            botState.TabIndex = 2;
            botState.Text = "Idle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(104, 62);
            label2.Name = "label2";
            label2.Size = new Size(87, 28);
            label2.TabIndex = 3;
            label2.Text = "In Battle:";
            // 
            // inBattleText
            // 
            inBattleText.AutoSize = true;
            inBattleText.Font = new Font("Segoe UI", 10F);
            inBattleText.ForeColor = Color.Red;
            inBattleText.Location = new Point(280, 62);
            inBattleText.Name = "inBattleText";
            inBattleText.Size = new Size(39, 28);
            inBattleText.TabIndex = 4;
            inBattleText.Text = "No";
            // 
            // battleWonText
            // 
            battleWonText.AutoSize = true;
            battleWonText.Font = new Font("Segoe UI", 10F);
            battleWonText.ForeColor = Color.Red;
            battleWonText.Location = new Point(280, 100);
            battleWonText.Name = "battleWonText";
            battleWonText.Size = new Size(39, 28);
            battleWonText.TabIndex = 6;
            battleWonText.Text = "No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(104, 100);
            label4.Name = "label4";
            label4.Size = new Size(112, 28);
            label4.TabIndex = 5;
            label4.Text = "Battle Won:";
            // 
            // joiningDungeonText
            // 
            joiningDungeonText.AutoSize = true;
            joiningDungeonText.Font = new Font("Segoe UI", 10F);
            joiningDungeonText.ForeColor = Color.Red;
            joiningDungeonText.Location = new Point(280, 138);
            joiningDungeonText.Name = "joiningDungeonText";
            joiningDungeonText.Size = new Size(39, 28);
            joiningDungeonText.TabIndex = 8;
            joiningDungeonText.Text = "No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(104, 138);
            label5.Name = "label5";
            label5.Size = new Size(165, 28);
            label5.TabIndex = 7;
            label5.Text = "Joining Dungeon:";
            // 
            // inDungeonText
            // 
            inDungeonText.AutoSize = true;
            inDungeonText.Font = new Font("Segoe UI", 10F);
            inDungeonText.ForeColor = Color.Red;
            inDungeonText.Location = new Point(280, 175);
            inDungeonText.Name = "inDungeonText";
            inDungeonText.Size = new Size(39, 28);
            inDungeonText.TabIndex = 10;
            inDungeonText.Text = "No";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(104, 175);
            label6.Name = "label6";
            label6.Size = new Size(118, 28);
            label6.TabIndex = 9;
            label6.Text = "In Dungeon:";
            // 
            // HalfangFarmingBot
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 354);
            Controls.Add(inDungeonText);
            Controls.Add(label6);
            Controls.Add(joiningDungeonText);
            Controls.Add(label5);
            Controls.Add(battleWonText);
            Controls.Add(label4);
            Controls.Add(inBattleText);
            Controls.Add(label2);
            Controls.Add(botState);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(4, 5, 4, 5);
            Name = "HalfangFarmingBot";
            Text = "Halfang Farming Bot";
            Load += HalfangFarmingBot_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        #endregion

        private Button button1;
        private Label label1;
        private Label botState;
        private Label label2;
        private Label inBattleText;
        private Label battleWonText;
        private Label label4;
        private Label joiningDungeonText;
        private Label label5;
        private Label inDungeonText;
        private Label label6;
    }
}