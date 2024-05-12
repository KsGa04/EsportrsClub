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
    /// Логика взаимодействия для Computers.xaml
    /// </summary>
    public partial class Computers : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        List<Computer>  computers = new List<Computer>();
        public Computers()
        {
            InitializeComponent();
            ListComputer.Items.Clear();
            computers = db.Computer.ToList();
            ListComputer.ItemsSource = computers;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                var product = item.Content as Computer;
                int id = product.id_computer;
                Computer computer = db.Computer.Where(x => x.id_computer == id).FirstOrDefault();
                NavigationService.Navigate(new Booking(null, (sender as ListViewItem).DataContext as Computer));

            }
        }
    }
}
