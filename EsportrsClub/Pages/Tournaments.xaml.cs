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
    /// Логика взаимодействия для Tournaments.xaml
    /// </summary>
    public partial class Tournaments : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        List<Tournament> tournaments = new List<Tournament>();

        public Tournaments()
        {
            InitializeComponent();
            ListTournament.Items.Clear();
            tournaments = db.Tournament.ToList();
            ListTournament.ItemsSource = tournaments;
        }
        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListViewItem item)
            {
                var product = item.Content as Tournament;
                int id = product.id_tournament;
                NavigationService.Navigate(new AboutTournament(id));

            }
        }
    }
}
