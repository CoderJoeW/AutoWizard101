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
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(136, 223);
            button1.Margin = new Padding(4, 4, 4, 4);
            button1.Name = "button1";
            button1.Size = new Size(229, 69);
            button1.TabIndex = 0;
            button1.Text = "Start/Stop Bot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(125, 30);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(115, 32);
            label1.TabIndex = 1;
            label1.Text = "Bot State:";
            // 
            // botState
            // 
            botState.AutoSize = true;
            botState.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            botState.Location = new Point(329, 30);
            botState.Margin = new Padding(4, 0, 4, 0);
            botState.Name = "botState";
            botState.Size = new Size(53, 32);
            botState.TabIndex = 2;
            botState.Text = "Idle";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(125, 75);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(107, 32);
            label2.TabIndex = 3;
            label2.Text = "In Battle:";
            // 
            // inBattleText
            // 
            inBattleText.AutoSize = true;
            inBattleText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            inBattleText.ForeColor = Color.Red;
            inBattleText.Location = new Point(336, 75);
            inBattleText.Margin = new Padding(4, 0, 4, 0);
            inBattleText.Name = "inBattleText";
            inBattleText.Size = new Size(46, 32);
            inBattleText.TabIndex = 4;
            inBattleText.Text = "No";
            // 
            // battleWonText
            // 
            battleWonText.AutoSize = true;
            battleWonText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            battleWonText.ForeColor = Color.Red;
            battleWonText.Location = new Point(336, 120);
            battleWonText.Margin = new Padding(4, 0, 4, 0);
            battleWonText.Name = "battleWonText";
            battleWonText.Size = new Size(46, 32);
            battleWonText.TabIndex = 6;
            battleWonText.Text = "No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(125, 120);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(136, 32);
            label4.TabIndex = 5;
            label4.Text = "Battle Won:";
            // 
            // joiningDungeonText
            // 
            joiningDungeonText.AutoSize = true;
            joiningDungeonText.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            joiningDungeonText.ForeColor = Color.Red;
            joiningDungeonText.Location = new Point(336, 165);
            joiningDungeonText.Margin = new Padding(4, 0, 4, 0);
            joiningDungeonText.Name = "joiningDungeonText";
            joiningDungeonText.Size = new Size(46, 32);
            joiningDungeonText.TabIndex = 8;
            joiningDungeonText.Text = "No";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(125, 165);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(203, 32);
            label5.TabIndex = 7;
            label5.Text = "Joining Dungeon:";
            // 
            // HalfangFarmingBot
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 336);
            Controls.Add(joiningDungeonText);
            Controls.Add(label5);
            Controls.Add(battleWonText);
            Controls.Add(label4);
            Controls.Add(inBattleText);
            Controls.Add(label2);
            Controls.Add(botState);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new Padding(5, 6, 5, 6);
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