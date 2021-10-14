using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormMain : Form
    {
        private AppUser appUser;
        private Project project;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            appUser = login();
            project = projectSelect();

            SetText();
        }

        private AppUser login()
        {
            FormLogin formLogin = new FormLogin();
            DialogResult res;

            do
            {
                res = formLogin.ShowDialog();
                if (res != DialogResult.OK)
                {
                    formLogin.Dispose();
                    this.Close();
                    break;

                }
            }
            while (res == DialogResult.OK && !formLogin.ReturnUser.isAuthenticated);

            return formLogin.ReturnUser;
        }

        private Project projectSelect()
        {
            FormSelectProject formSelect = new FormSelectProject();
            DialogResult res;

            do
            {
                res = formSelect.ShowDialog();
                if (res != DialogResult.OK)
                {
                    formSelect.Dispose();
                    this.Close();
                    break;

                }
            }
            while (res == DialogResult.OK && formSelect.ReturnProject == null);

            return formSelect.ReturnProject;

        }

        private void SetText()
        {
            Text = $"Main - {project.Name}";
        }

        private void selectProjectMenu_Click(object sender, EventArgs e)
        {
            project = projectSelect();
            SetText();
        }
    }
}
