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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.inBattleText = new System.Windows.Forms.Label();
            this.battleWonText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.joiningDungeonText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 2);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 38);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start Bot";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "State";
            // 
            // botState
            // 
            this.botState.AutoSize = true;
            this.botState.Location = new System.Drawing.Point(72, 166);
            this.botState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.botState.Name = "botState";
            this.botState.Size = new System.Drawing.Size(59, 25);
            this.botState.TabIndex = 2;
            this.botState.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "In Battle";
            // 
            // inBattleText
            // 
            this.inBattleText.AutoSize = true;
            this.inBattleText.ForeColor = System.Drawing.Color.Red;
            this.inBattleText.Location = new System.Drawing.Point(95, 70);
            this.inBattleText.Name = "inBattleText";
            this.inBattleText.Size = new System.Drawing.Size(48, 25);
            this.inBattleText.TabIndex = 4;
            this.inBattleText.Text = "false";
            // 
            // battleWonText
            // 
            this.battleWonText.AutoSize = true;
            this.battleWonText.ForeColor = System.Drawing.Color.Red;
            this.battleWonText.Location = new System.Drawing.Point(116, 105);
            this.battleWonText.Name = "battleWonText";
            this.battleWonText.Size = new System.Drawing.Size(48, 25);
            this.battleWonText.TabIndex = 6;
            this.battleWonText.Text = "false";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Battle Won";
            // 
            // joiningDungeonText
            // 
            this.joiningDungeonText.AutoSize = true;
            this.joiningDungeonText.ForeColor = System.Drawing.Color.Red;
            this.joiningDungeonText.Location = new System.Drawing.Point(166, 35);
            this.joiningDungeonText.Name = "joiningDungeonText";
            this.joiningDungeonText.Size = new System.Drawing.Size(48, 25);
            this.joiningDungeonText.TabIndex = 8;
            this.joiningDungeonText.Text = "false";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Joining Dungeon";
            // 
            // HalfangFarmingBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 312);
            this.Controls.Add(this.joiningDungeonText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.battleWonText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.inBattleText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.botState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HalfangFarmingBot";
            this.Text = "HalfangFarmingBot";
            this.Load += new System.EventHandler(this.HalfangFarmingBot_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

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