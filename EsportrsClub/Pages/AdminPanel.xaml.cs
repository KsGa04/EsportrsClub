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
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AddComputer_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddComputer(0));
        }

        private void EditComputer_Click(object sender, RoutedEventArgs e)
        {
            if (ComputerDataGrid.SelectedIndex >= 0)
            {
                var item = ComputerDataGrid.SelectedItem as Computer;
                int id = item.id_computer;
                NavigationService.Navigate(new AddComputer(id));
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void DeleteComputer_Click(object sender, RoutedEventArgs e)
        {
            if (ComputerDataGrid.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот компьютер?", "Удалить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var item = ComputerDataGrid.SelectedItem as Computer;
                    int id = item.id_computer;
                    Computer computer = db.Computer.Where(x => x.id_computer == id).FirstOrDefault();
                    db.Computer.Remove(computer);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void AddTournament_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddTournament(0));
        }

        private void EditTournament_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationDataGrid.SelectedIndex >= 0)
            {
                var item = ReservationDataGrid.SelectedItem as Tournament;
                int id = item.id_tournament;
                NavigationService.Navigate(new AddTournament(id));
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void DeleteTournament_Click(object sender, RoutedEventArgs e)
        {
            if (ReservationDataGrid.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот турнир?", "Удалить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var item = ReservationDataGrid.SelectedItem as Tournament;
                    int id = item.id_tournament;
                    Tournament computer = db.Tournament.Where(x => x.id_tournament == id).FirstOrDefault();
                    db.Tournament.Remove(computer);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddUser(0));
        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedIndex >= 0)
            {
                var item = UserDataGrid.SelectedItem as Users;
                int id = item.id_user;
                NavigationService.Navigate(new AddUser(id));
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (UserDataGrid.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этого пользователя?", "Удалить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var item = UserDataGrid.SelectedItem as Users;
                    int id = item.id_user;
                    Users computer = db.Users.Where(x => x.id_user == id).FirstOrDefault();
                    db.Users.Remove(computer);
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали ни один элемент");
            }
        }

        private void SearchComputer_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchComputerTextBox.Text.ToLower();
            CollectionViewSource.GetDefaultView(ComputerDataGrid.ItemsSource).Filter = (item) =>
            {
                if (item is Computer computer)
                {
                    return computer.name_computer.ToLower().Contains(searchText) ||
                           computer.Status.name_status.ToLower().Contains(searchText);
                }
                return false;
            };
        }

        private void SearchTournament_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchReservationTextBox.Text.ToLower();

            // Фильтруем данные в DataGrid
            CollectionViewSource.GetDefaultView(ReservationDataGrid.ItemsSource).Filter = (item) =>
            {
                if (item is Tournament tournament)
                {
                    return tournament.name_tournament.ToLower().Contains(searchText) ||
                           tournament.d.ToLower().Contains(searchText) ||
                           tournament.Game.ToLower().Contains(searchText);
                }
                return false;
            };
        }

        private void SearchUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
