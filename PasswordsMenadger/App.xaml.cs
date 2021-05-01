using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using PasswordsMenadger.Contexts;
using PasswordsMenadger.Views;

namespace PasswordsMenadger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        protected override void OnStartup(StartupEventArgs e)
        {
            GlobalContext globalContext = new GlobalContext(new DbContextOptions<GlobalContext>());
            PasswordsGridView mainView = new PasswordsGridView();
            mainView.Show();
            base.OnStartup(e);
        }
    }
}
