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
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(160, 290);
            button1.Name = "button1";
            button1.Size = new Size(172, 46);
            button1.TabIndex = 0;
            button1.Text = "Start/Stop Bot";
            button1.UseVisualStyleBackColor = true;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 20);
            label1.Name = "label1";
            label1.Size = new Size(110, 20);
            label1.TabIndex = 1;
            label1.Text = "Bot State:";
            label1.Font = new Font(label1.Font.FontFamily, 10);
            // 
            // botState
            // 
            botState.AutoSize = true;
            botState.Location = new Point(160, 20);
            botState.Name = "botState";
            botState.Size = new Size(80, 20);
            botState.TabIndex = 2;
            botState.Text = "Idle";
            botState.Font = new Font(botState.Font.FontFamily, 10);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 50);
            label2.Name = "label2";
            label2.Size = new Size(100, 20);
            label2.TabIndex = 3;
            label2.Text = "In Battle:";
            label2.Font = new Font(label2.Font.FontFamily, 10);
            // 
            // inBattleText
            // 
            inBattleText.AutoSize = true;
            inBattleText.ForeColor = Color.Red;
            inBattleText.Location = new Point(160, 50);
            inBattleText.Name = "inBattleText";
            inBattleText.Size = new Size(30, 20);
            inBattleText.TabIndex = 4;
            inBattleText.Text = "No";
            inBattleText.Font = new Font(inBattleText.Font.FontFamily, 10);
            // 
            // battleWonText
            // 
            battleWonText.AutoSize = true;
            battleWonText.ForeColor = Color.Red;
            battleWonText.Location = new Point(160, 80);
            battleWonText.Name = "battleWonText";
            battleWonText.Size = new Size(30, 20);
            battleWonText.TabIndex = 6;
            battleWonText.Text = "No";
            battleWonText.Font = new Font(battleWonText.Font.FontFamily, 10);
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 80);
            label4.Name = "label4";
            label4.Size = new Size(110, 20);
            label4.TabIndex = 5;
            label4.Text = "Battle Won:";
            label4.Font = new Font(label4.Font.FontFamily, 10);
            //
            // joiningDungeonText
            //
            joiningDungeonText.AutoSize = true;
            joiningDungeonText.ForeColor = Color.Red;
            joiningDungeonText.Location = new Point(240, 110);
            joiningDungeonText.Name = "joiningDungeonText";
            joiningDungeonText.Size = new Size(30, 20);
            joiningDungeonText.TabIndex = 8;
            joiningDungeonText.Text = "No";
            joiningDungeonText.Font = new Font(joiningDungeonText.Font.FontFamily, 10);
            //
            // label5
            //
            label5.AutoSize = true;
            label5.Location = new Point(40, 110);
            label5.Name = "label5";
            label5.Size = new Size(190, 20);
            label5.TabIndex = 7;
            label5.Text = "Joining Dungeon:";
            label5.Font = new Font(label5.Font.FontFamily, 10);
            //
            // HalfangFarmingBot
            //
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 374);
            Controls.Add(joiningDungeonText);
            Controls.Add(label5);
            Controls.Add(battleWonText);
            Controls.Add(label4);
            Controls.Add(inBattleText);
            Controls.Add(label2);
            Controls.Add(botState);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(4, 4, 4, 4);
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
    }
}
