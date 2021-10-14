using System;
using System.Windows.Forms;

namespace P5
{
    public partial class FormLogin : Form
    {
        public AppUser ReturnUser { get; set; }

        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CenterToParent();

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(this.textBoxUserName.Text) || string.IsNullOrEmpty(this.textBoxPass.Text))
            {
                MessageBox.Show("Please Enter Username and Password.", "Error");
                return;
            }
            string user = this.textBoxUserName.Text.ToString();
            string pass = this.textBoxPass.Text.ToString();

            FakeAppUserRepository repo = new FakeAppUserRepository();
            bool auth = repo.Login(user, pass);
            if (!auth)
            {
                MessageBox.Show("Incorrect Username or Password.", "Attention");
                return;
            }

            repo.SetAuthentication(user, true);
            this.ReturnUser = repo.GetByUserName(user);
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
