namespace ProjectMaelstrom
{
    partial class HalfangFarmingBot
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
            button1.Location = new Point(348, 2);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(128, 46);
            button1.TabIndex = 0;
            button1.Text = "Start/Stop Bot";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 199);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(59, 30);
            label1.TabIndex = 1;
            label1.Text = "State";
            // 
            // botState
            // 
            botState.AutoSize = true;
            botState.Location = new Point(86, 199);
            botState.Margin = new Padding(5, 0, 5, 0);
            botState.Name = "botState";
            botState.Size = new Size(68, 30);
            botState.TabIndex = 2;
            botState.Text = "label2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 84);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(90, 30);
            label2.TabIndex = 3;
            label2.Text = "In Battle";
            // 
            // inBattleText
            // 
            inBattleText.AutoSize = true;
            inBattleText.ForeColor = Color.Red;
            inBattleText.Location = new Point(114, 84);
            inBattleText.Margin = new Padding(4, 0, 4, 0);
            inBattleText.Name = "inBattleText";
            inBattleText.Size = new Size(56, 30);
            inBattleText.TabIndex = 4;
            inBattleText.Text = "false";
            // 
            // battleWonText
            // 
            battleWonText.AutoSize = true;
            battleWonText.ForeColor = Color.Red;
            battleWonText.Location = new Point(139, 126);
            battleWonText.Margin = new Padding(4, 0, 4, 0);
            battleWonText.Name = "battleWonText";
            battleWonText.Size = new Size(56, 30);
            battleWonText.TabIndex = 6;
            battleWonText.Text = "false";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 126);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(115, 30);
            label4.TabIndex = 5;
            label4.Text = "Battle Won";
            // 
            // joiningDungeonText
            // 
            joiningDungeonText.AutoSize = true;
            joiningDungeonText.ForeColor = Color.Red;
            joiningDungeonText.Location = new Point(199, 42);
            joiningDungeonText.Margin = new Padding(4, 0, 4, 0);
            joiningDungeonText.Name = "joiningDungeonText";
            joiningDungeonText.Size = new Size(56, 30);
            joiningDungeonText.TabIndex = 8;
            joiningDungeonText.Text = "false";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 42);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(171, 30);
            label5.TabIndex = 7;
            label5.Text = "Joining Dungeon";
            // 
            // HalfangFarmingBot
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
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
            Margin = new Padding(5, 6, 5, 6);
            Name = "HalfangFarmingBot";
            Text = "HalfangFarmingBot";
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