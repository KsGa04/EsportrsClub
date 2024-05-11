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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EsportrsClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        Users Users = new Users();
        int Id;
        public AddUser(int id)
        {
            InitializeComponent();
            if (id != 0)
            {
                Id = id;
                Users = db.Users.Where(x => x.id_user == id).FirstOrDefault();
                DataContext = Users;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Id != 0)
            {
                Users.email = email.Text;
                Users.login = login.Text;
                Users.password = password.Text;
            }
            else
            {
                Users Users = new Users();
                Users.email = email.Text;
                Users.login = login.Text;
                Users.password = password.Text;
                db.Users.Add(Users);
            }
            db.SaveChanges();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
