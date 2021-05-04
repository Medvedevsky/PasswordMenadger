using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PasswordsMenadger.DBContent;

namespace PasswordsMenadger.Views
{
    /// <summary>
    /// Логика взаимодействия для PasswordsCardView.xaml
    /// </summary>
    public partial class PasswordsCardView : Window
    {
        private GlobalContext _context;
        public PasswordsCardView(GlobalContext context)
        {
            InitializeComponent();
            _context = context;
        }
        
        private void Reload()
        {
            var data = _context.Sites.Join(_context.Users,
                s => s.IdUser,
                u => u.Id,
                (s, u) => new
                {
                    Title = s.Title,
                    Login = u.Login,
                    Password = u.Password,
                    UrlPath = s.UrlPath
                });

            passwordsGrid.ItemsSource = data.ToList();
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (IsVisible)
                Reload();
        }

        private void passwordsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
