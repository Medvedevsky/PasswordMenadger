using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using PasswordsMenadger.Contexts;
using PasswordsMenadger.Models;

namespace PasswordsMenadger.Views
{
    /// <summary>
    /// Логика взаимодействия для PasswordsCardView.xaml
    /// </summary>
    public partial class PasswordsCardView : Window
    {
        private GlobalContext _context;
        private User users;
        public PasswordsCardView(GlobalContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void Relaod()
        {
            //var data = from sites in _context.Users.ToList()
            //           where sites.Id == users.SiteId
            //           select sites;


            passwordsList.ItemsSource = data.ToList();
            
        }
        private void passwordsList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
                Relaod();
        }
    }
}
