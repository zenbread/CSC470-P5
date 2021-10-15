using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormMain : Form
    {
        private AppUser appUser;
        private Project project;
        public FakeProjectRepository projectRepo;
        public Project selected;
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            projectRepo = new FakeProjectRepository();
            CenterToScreen();
            appUser = login();
            project = projectSelect(true);

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

        private Project projectSelect(bool first)
        {
            FormSelectProject formSelect = new FormSelectProject();
            DialogResult res;

            do
            {
                res = formSelect.ShowDialog(this);
                if (res != DialogResult.OK)
                {
                    if (first)
                    {
                        formSelect.Dispose();
                        this.Close();
                        break;
                    }
                    formSelect.Dispose();
                    return project;
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
            project = projectSelect(false);
            SetText();
        }

        private void createProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateProject formCreate = new FormCreateProject();

            formCreate.ShowDialog(this);
        }

        private void removeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = projectSelect(false);
            if (selected == project)
            {
                MessageBox.Show("Cannot remove your current session.", "Attention");
                return;
            }
            FormRemoveProject formRemove = new FormRemoveProject();
            formRemove.ShowDialog(this);
        }

        private void modifyProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            selected = projectSelect(false);
            if (selected == project)
            {
                MessageBox.Show("Cannot modify your current session.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FormModifyProject formModify = new FormModifyProject();
            formModify.ShowDialog(this);
        }
    }
}
