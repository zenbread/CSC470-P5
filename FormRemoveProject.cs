using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormRemoveProject : Form
    {
        FormMain parent;
        public FormRemoveProject()
        {
            InitializeComponent();
        }

        private void FormRemoveProject_Load(object sender, EventArgs e)
        {
            CenterToParent();
            parent = (FormMain)this.Owner;
            labelProjectToRemove.Text = parent.selected.Name;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure you want to permenantly remove this project?", "Attention",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                string msg = parent.projectRepo.Remove(parent.selected.Id);
                if (!string.IsNullOrEmpty(msg))
                {
                    MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                parent.selected = null;
                MessageBox.Show("Project Removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            this.Close();
        }
    }
}
