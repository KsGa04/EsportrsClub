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
using EsportrsClub.Class;
namespace EsportrsClub
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        EsportsClubEntities db = new EsportsClubEntities();
        public Authorization()
        {
            InitializeComponent();
            Auth.IsAuth = false;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (db.Users.Where(x => x.login == UsernameTextBox.Text || x.password ==PasswordTextBox.Password).Any())
            {
                Users users = db.Users.Where(x => x.login == UsernameTextBox.Text || x.password == PasswordTextBox.Password).FirstOrDefault();
                Auth.UserID = users.id_user;
                Auth.Role = users.Role.name_role;
                Auth.IsAuth = true;
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Данный пользователь отсутсвует");
                Auth.IsAuth = false;
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Hide();
        }
    }
}
