using EsportrsClub.Class;
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

namespace EsportrsClub
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        EsportsClubEntities db = new EsportsClubEntities();
        public Registration()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Authorization mainWindow = new Authorization();
            mainWindow.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (db.Users.Where(x => x.login == UsernameTextBox.Text || x.password == PasswordTextBox.Password || x.email == EmailTextBox.Text).Any())
            {
                MessageBox.Show("Данный пользователь уже имеется в системе");
            }
            else
            {
                Users users = new Users();
                users.login = UsernameTextBox.Text;
                users.password = PasswordTextBox.Password;
                users.email = EmailTextBox.Text;
                db.Users.Add(users);
                db.SaveChanges();
                Authorization mainWindow = new Authorization();
                mainWindow.Show();
                this.Hide();
            }
        }
    }
}
