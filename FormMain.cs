using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            FormLogin formLogin = new FormLogin();
            DialogResult res;
            AppUser appUser;

            do
            {
                res = formLogin.ShowDialog();
                if (res != DialogResult.OK)
                {
                    formLogin.Dispose();
                    this.Close();
                    break;

                }
                appUser = formLogin.ReturnUser;

            }
            while (res == DialogResult.OK && !appUser.isAuthenticated);

            SetText();
        }

        private void SetText()
        {
            Text = "Main - No Project Selected";
        }

    }
}
