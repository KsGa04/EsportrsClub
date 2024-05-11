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
    /// Логика взаимодействия для AddComputer.xaml
    /// </summary>
    public partial class AddComputer : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        Computer Computer = new Computer();
        int Id;
        public AddComputer(int id)
        {
            InitializeComponent();
            if (id != 0)
            {
                Id = id;
                Computer = db.Computer.Where(x => x.id_computer == id).FirstOrDefault();
                DataContext = Computer;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Id != 0)
            {
                Computer.name_computer = name_tournament.Text;
                Computer.id_status = game.SelectedIndex + 1;
                Computer.price = Convert.ToDecimal( price.Text);
            }
            else
            {
                Computer Computer = new Computer();
                Computer.name_computer = name_tournament.Text;
                Computer.id_status = game.SelectedIndex + 1;
                Computer.price = Convert.ToDecimal(price.Text);
                db.Computer.Add(Computer);
            }
            db.SaveChanges();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
