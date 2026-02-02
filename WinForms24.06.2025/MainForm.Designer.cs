
namespace WinForms24._06._2025
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel3 = new Panel();
            panel2 = new Panel();
            label1 = new Label();
            panelForSubForms = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 119, 182);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 541);
            panel1.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(2, 100, 200);
            button3.Dock = DockStyle.Top;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            button3.ForeColor = SystemColors.ButtonHighlight;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(0, 214);
            button3.Name = "button3";
            button3.Size = new Size(226, 57);
            button3.TabIndex = 4;
            button3.Text = "ВЫХОД";
            button3.UseVisualStyleBackColor = false;
            button3.Click += ExitClcl;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(2, 100, 200);
            button2.Dock = DockStyle.Top;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe Script", 14F, FontStyle.Bold);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(0, 157);
            button2.Name = "button2";
            button2.Size = new Size(226, 57);
            button2.TabIndex = 3;
            button2.Text = "ИГРАТЬ";
            button2.UseVisualStyleBackColor = false;
            button2.Click += GameStartClck;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(2, 100, 200);
            button1.Dock = DockStyle.Top;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe Script", 14F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 100);
            button1.Name = "button1";
            button1.Size = new Size(226, 57);
            button1.TabIndex = 2;
            button1.Text = "УПРАВЛЕНИЕ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += ShowControlClck;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(3, 4, 94);
            panel3.BackgroundImage = (Image)resources.GetObject("panel3.BackgroundImage");
            panel3.BackgroundImageLayout = ImageLayout.Center;
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(226, 100);
            panel3.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(35, 5, 84);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(226, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(805, 100);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.BackColor = Color.FromArgb(2, 62, 138);
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Papyrus", 24F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(805, 100);
            label1.TabIndex = 0;
            label1.Text = "Dragon's fireball shooting game";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelForSubForms
            // 
            panelForSubForms.BackColor = Color.FromArgb(0, 180, 216);
            panelForSubForms.Dock = DockStyle.Fill;
            panelForSubForms.Location = new Point(226, 100);
            panelForSubForms.Name = "panelForSubForms";
            panelForSubForms.Size = new Size(805, 441);
            panelForSubForms.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(90, 24, 154);
            ClientSize = new Size(1031, 541);
            Controls.Add(panelForSubForms);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            Text = "Game";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }



        #endregion
        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Button button1;
        private Button button3;
        private Button button2;
        private Panel panelForSubForms;
        private Label label1;
    }
}
