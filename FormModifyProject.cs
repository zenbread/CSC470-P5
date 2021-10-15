using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormModifyProject : Form
    {
        FormMain parent;
        public FormModifyProject()
        {
            InitializeComponent();
        }

        private void FormRemoveProject_Load(object sender, EventArgs e)
        {
            CenterToParent();
            parent = (FormMain)this.Owner;
            textBox.Text = parent.selected.Name;
            ActiveControl = textBox;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            Project tmp = new Project(parent.selected.Id, textBox.Text.Trim());
            string msg = parent.projectRepo.Modify(parent.selected.Id, tmp);

            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Project modified successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }
    }
}
