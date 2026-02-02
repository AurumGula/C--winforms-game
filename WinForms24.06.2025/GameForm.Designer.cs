namespace WinForms24._06._2025
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            Hero = new PictureBox();
            lblScore = new Label();
            panel1 = new Panel();
            lblHP = new Label();
            panel2 = new Panel();
            lblHighScore = new Label();
            ((System.ComponentModel.ISupportInitialize)Hero).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // Hero
            // 
            Hero.BackColor = Color.Transparent;
            Hero.Image = (Image)resources.GetObject("Hero.Image");
            Hero.Location = new Point(610, 142);
            Hero.Name = "Hero";
            Hero.Size = new Size(149, 126);
            Hero.SizeMode = PictureBoxSizeMode.StretchImage;
            Hero.TabIndex = 0;
            Hero.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Dock = DockStyle.Left;
            lblScore.Font = new Font("Segoe Print", 36F, FontStyle.Bold);
            lblScore.Location = new Point(0, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(237, 85);
            lblScore.TabIndex = 1;
            lblScore.Text = "Счёт: 0";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Brown;
            panel1.Controls.Add(lblHP);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(898, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(96, 604);
            panel1.TabIndex = 2;
            // 
            // lblHP
            // 
            lblHP.BackColor = Color.SeaGreen;
            lblHP.Dock = DockStyle.Fill;
            lblHP.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 204);
            lblHP.ForeColor = SystemColors.ButtonHighlight;
            lblHP.Location = new Point(0, 0);
            lblHP.Name = "lblHP";
            lblHP.Size = new Size(96, 604);
            lblHP.TabIndex = 0;
            lblHP.Text = "100";
            lblHP.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblHighScore);
            panel2.Controls.Add(lblScore);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(898, 85);
            panel2.TabIndex = 3;
            // 
            // lblHighScore
            // 
            lblHighScore.AutoSize = true;
            lblHighScore.BackColor = SystemColors.Control;
            lblHighScore.Dock = DockStyle.Right;
            lblHighScore.Font = new Font("Segoe Print", 36F, FontStyle.Bold);
            lblHighScore.Location = new Point(623, 0);
            lblHighScore.Name = "lblHighScore";
            lblHighScore.Size = new Size(275, 85);
            lblHighScore.TabIndex = 2;
            lblHighScore.Text = "Рекорд: 0";
            // 
            // Subform1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.Control;
            ClientSize = new Size(994, 604);
            ControlBox = false;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Hero);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Subform1";
            Text = "Subform1";
            KeyDown += Subform1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)Hero).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox Hero;
        private Label lblScore;
        private Panel panel1;
        private Label lblHP;
        private Panel panel2;
        private Label lblHighScore;
    }
}