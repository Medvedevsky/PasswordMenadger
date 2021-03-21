using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PasswordsManager.Controllers;
using PasswordsManager.Models;

namespace PasswordsManager.Views
{
    public partial class PasswordEditorView : Form
    {
        public PasswordEditorView(UserData data)
        {
            InitializeComponent();
            PasswordEditorController controller = new PasswordEditorController(loginTextBox, passwordTextBox, data);

            Load += controller.PasswordEditorView_Load;
            applyButton.Click += controller.applyButton_Click;
            cancelButton.Click += controller.cancelButton_Click;

            applyButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;

        }

    
    }
}
