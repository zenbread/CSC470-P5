﻿using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormCreateProject : Form
    {
        FormMain parent;
        public FormCreateProject()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Project tmp = new Project(textBox.Text);
            string msg = parent.projectRepo.Add(tmp, out int id);
            if (id < 0)
            {
                MessageBox.Show(msg, "Attention");
            }
        }

        private void FormCreateProject_Load(object sender, EventArgs e)
        {
            CenterToParent();
            parent = (FormMain)this.Owner;
        }
    }
}
