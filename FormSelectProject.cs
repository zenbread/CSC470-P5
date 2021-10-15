using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace P5
{
    public partial class FormSelectProject : Form
    {
        public Project ReturnProject;
        public FormSelectProject()
        {
            InitializeComponent();
        }

        private void SelectProjectForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
            FormMain parent = (FormMain)this.Owner;
            List<Project> projects = parent.projectRepo.GetAll();

            listBoxProjects.DataSource = projects;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            ReturnProject = (Project)listBoxProjects.SelectedItem;
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
