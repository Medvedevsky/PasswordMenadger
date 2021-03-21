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

namespace PasswordsManager.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();

            MainController controller = new MainController(dataGridView);

            Load += controller.MainView_Load;
            addToolStripButton.Click += controller.addToolStripButton_Click;
            deleteToolStripButton.Click += controller.deleteToolStripButton_Click;
            changeDataToolStripButton.Click += controller.changeDataToolStripButton_Click;
            updateToolStripButton.Click += controller.updateToolStripButton_Click;
            copyToolStripButton.Click += controller.copyToolStripButton_Click;
            exitToolStripButton.Click += controller.exitToolStripButton_Click;
        }

    
    }
}
