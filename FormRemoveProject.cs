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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Project tmp = new Project(textBox.Text.Trim());
            string msg = parent.projectRepo.Add(tmp, out int id);
            if (id < 0)
            {
                MessageBox.Show(msg, "Attention");
                return;
            }
            MessageBox.Show($"{tmp.Name} added to projects.");
            this.Close();
        }

        private void FormCreateProject_Load(object sender, EventArgs e)
        {
            CenterToParent();
            parent = (FormMain)this.Owner;
        }
    }
}
