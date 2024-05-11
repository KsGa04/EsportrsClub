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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EsportrsClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для PrivateAcc.xaml
    /// </summary>
    public partial class PrivateAcc : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        Users Users = new Users();
        public PrivateAcc()
        {
            InitializeComponent();
            Users = db.Users.Where(x => x.id_user == Auth.UserID).FirstOrDefault();
            DataContext = Users;
            ListViewLoad();
        }
        public void ListViewLoad()
        {
                var books = db.Book.ToList();

                book.ItemsSource = books;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Users.phone = phone.Text;
            Users.name_user = name_user.Text;
            Users.email = email.Text;
            db.SaveChanges();
            MessageBox.Show("Данные сохранены");
        }
    }
}
