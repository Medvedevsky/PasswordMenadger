using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using PasswordsMenadger.DBContent;
using PasswordsMenadger.Views;

namespace PasswordsMenadger
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            GlobalContext context = new GlobalContext();
            PasswordsCardView mainView = new PasswordsCardView(context);
            app.Run(mainView);
        }
    }
}
