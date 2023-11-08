using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MedicalExamination.Controllers;


namespace MedicalExamination.Views
{
    public partial class AuthorizationView : Form
    {
        AuthorizationController controller = new AuthorizationController();
        public AuthorizationView()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                labelWrong.Visible = false;
                var login = textBoxLogin.Text;
                var password = textBoxPassword.Text;

                if (login == string.Empty || password == string.Empty)
                    return;
                
                var resultCheck = controller.AuthorizeAndRetrievePrivileges(login, password);
                controller.SetPrivileges(resultCheck);

                Hide();
                MenuView menuView = new MenuView();
                if (menuView.ShowDialog() == DialogResult.Abort)
                {
                    textBoxPassword.Text = string.Empty;
                    Show(); 
                    return;
                }
                Close();
            }
            catch (UnauthorizedAccessException)
            {
                labelWrong.Visible = true;
            }
        }

    }
}
