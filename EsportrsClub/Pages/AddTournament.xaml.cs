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
    /// Логика взаимодействия для AddTournament.xaml
    /// </summary>
    public partial class AddTournament : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        Tournament tournament = new Tournament();
        int Id;
        public AddTournament(int id)
        {
            InitializeComponent();
            if (id != 0)
            {
                Id = id;
                tournament = db.Tournament.Where(x => x.id_tournament == id).FirstOrDefault();
                DataContext = tournament;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (Id != 0)
            {
                tournament.name_tournament = name_tournament.Text;
                tournament.game = game.Text;
                tournament.date_tournament = (DateTime)date_tournament.SelectedDate;
            }
            else
            {
                Tournament tournament = new Tournament();
                tournament.name_tournament = name_tournament.Text;
                tournament.game = game.Text;
                tournament.date_tournament = (DateTime)date_tournament.SelectedDate;
                db.Tournament.Add(tournament);
            }
            db.SaveChanges();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
