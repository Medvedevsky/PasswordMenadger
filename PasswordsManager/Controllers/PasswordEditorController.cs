using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordsManager.Views;
using PasswordsManager.Models;

namespace PasswordsManager.Controllers
{
    public class PasswordEditorController
    {
        private TextBox _loginTextBox;
        private TextBox _passwordTextBox;


        private UserData _data;
        public PasswordEditorController(TextBox loginTextBox, TextBox passwordTextBox, UserData data)
        {
            _loginTextBox = loginTextBox;
            _passwordTextBox = passwordTextBox;

            _data = data;
          
        }

        

        public void PasswordEditorView_Load(object sender, EventArgs e)
        {
            if (_data == null)
                _data = new UserData();

            _loginTextBox.Text = _data.Login;
            _passwordTextBox.Text = _data.Password;
        }

        public void applyButton_Click(object sender, EventArgs e)
        {
            if (_data == null)
                _data = new UserData();

            _data.Login = _loginTextBox.Text;
            _data.Password = _passwordTextBox.Text;

        }

        public void cancelButton_Click(object sender, EventArgs e)
        {

        }
    }
}


