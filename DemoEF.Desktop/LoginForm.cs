using Demo.BAL.Implementations;
using Demo.BAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Demo.Desktop
{
    public partial class LoginForm : Form
    {
       
        public readonly ILoginService _loginService;
        public LoginForm(ILoginService loginService)
        {
            _loginService = loginService;
            InitializeComponent();
            InitiallizeFormComponent();
            var getDict= GetKeyValuePairs();
            var getValue = getDict[2];
            Console.WriteLine(getValue);

            var result = getDict
                        .Where(x => x.Key == 1)
                        .Select(x => x.Value);
            Console.WriteLine(result);

            var result2 = getDict
                        .FirstOrDefault(x => x.Key == 1)
                        .Value;
            Console.WriteLine(result2);


        }
        public Dictionary<int, string> GetKeyValuePairs()
        {
            var dict = new Dictionary<int, string>();
            dict.Add(1, "Prakash");
            dict.Add(2, "Suvana");
            return dict;
        }          

        private void InitiallizeFormComponent()
        {
            lblUserNameError.Visible = false;
            lblPasswordError.Visible = false;
            txtPassword.PasswordChar = '*';
            txtUserName.TabIndex = 0;
            txtPassword.TabIndex = 1;
            btnLogin.TabIndex = 2;
            btnCancel.TabIndex = 3;
            this.AcceptButton = btnLogin;
            KeyPreview = true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
             await loginAsync();
        }

        private async Task loginAsync()
        {
            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            bool isSuccess = ValidateLogin(userName, password);

            if (!isSuccess) return;

            if (await _loginService.LoginAsync(userName,password))
            {
                var studentForm=Program.ServiceProvider.GetService<StudentForm>();
                studentForm.Show();
                this.Hide();
                return;

            }

            MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValidateLogin(string userName, string password)
        {

            if (String.IsNullOrWhiteSpace(userName))
            {
                lblUserNameError.Visible = true;

            }
            else
            {
                lblUserNameError.Visible = false;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                lblPasswordError.Visible = true;
            }
            else
            {
                lblPasswordError.Visible = false;
            }
            bool result = !String.IsNullOrWhiteSpace(userName) && !String.IsNullOrWhiteSpace(password);
            return result;


        }

        private void lblUserNameError_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            if (!String.IsNullOrWhiteSpace(userName))
            {
                lblUserNameError.Visible = false;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            if (!String.IsNullOrWhiteSpace(password))
            {
                lblPasswordError.Visible = false;
            }
        }

        private void lblPasswordError_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Clear();
            txtPassword.Clear();
            txtUserName.Focus();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private async void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.NumLock)
            {
                await loginAsync();
            }
            else if (e.KeyCode == Keys.F2)
            {
                Application.Exit();
            }
        }
    }
}
