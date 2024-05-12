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
    /// Логика взаимодействия для AboutTournament.xaml
    /// </summary>
    public partial class AboutTournament : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        public AboutTournament(int id)
        {
            InitializeComponent();
            Tournament tournament = db.Tournament.Where(x => x.id_tournament == id).FirstOrDefault();
            DataContext = tournament;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Booking((sender as Button).DataContext as Tournament, null));
        }
    }
}
