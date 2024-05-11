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
        public Tournaments()
        {
            InitializeComponent();
            DataContext = db.Tournament.ToList();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
