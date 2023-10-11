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
        public AuthorizationView()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var controller = new AuthorizationController();
                labelWrong.Visible = false;
                var login = textBoxLogin.Text;
                var password = textBoxPassword.Text;
                var resultCheck = controller.AuthorizeAndRetrievePrivileges(login, password);
                controller.SetPrivileges(resultCheck);

                Hide();
                MenuView menuView = new MenuView();
                menuView.FormClosed += MenuView_FormClosed;
                menuView.Show();
            }
            catch (UnauthorizedAccessException)
            {
                labelWrong.Visible = true;
            }
        }

        private void MenuView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
