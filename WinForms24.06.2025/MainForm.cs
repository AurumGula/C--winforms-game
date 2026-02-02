namespace WinForms24._06._2025
{
    public partial class MainForm : Form
    {
        private ControlFrom subform;
        private GameForm subform1;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ClearAllFormsFromPanel()
        {
            if (panelForSubForms == null)
            {           
                return; 
            }

            var forms = panelForSubForms.Controls.OfType<Form>().ToList();

            foreach (var form in forms)
            {
                panelForSubForms.Controls.Remove(form);

                if (!form.IsDisposed)
                {
                    form.Hide();
                    form.Close();
                    form.Dispose();
                }
            }
            panelForSubForms.Controls.Clear();
        }
        private void ShowControlClck(object sender, EventArgs e)
        {
            ClearAllFormsFromPanel();

            subform = new ControlFrom();
            subform.TopLevel = false;
            panelForSubForms.Controls.Add(subform);
            subform.FormBorderStyle = FormBorderStyle.None;
            subform.Dock = DockStyle.Fill;
            subform.Show();
        }
        private void GameStartClck(object sender, EventArgs e)
        {
            ClearAllFormsFromPanel();

            subform1 = new GameForm();
            subform1.TopLevel = false;
            panelForSubForms.Controls.Add(subform1);
            subform1.FormBorderStyle = FormBorderStyle.None;
            subform1.Dock = DockStyle.Fill;
            subform1.Show();
            subform1.Focus();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ExitClcl(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
