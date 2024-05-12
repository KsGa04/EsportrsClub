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
        List<Computer> compos = new List<Computer>();
        List<Tournament> tournaments = new List<Tournament>();
        List<Users> users = new List<Users>();
        public AdminPanel()
        {
            InitializeComponent();
            compos = db.Computer.ToList();
            ComputerDataGrid.ItemsSource = compos; 

            tournaments = db.Tournament.ToList();
            TournamentDataGrid.ItemsSource = tournaments;

            users = db.Users.ToList();
            UserDataGrid.ItemsSource = users;
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
            if (TournamentDataGrid.SelectedIndex >= 0)
            {
                var item = TournamentDataGrid.SelectedItem as Tournament;
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
            if (TournamentDataGrid.SelectedIndex >= 0)
            {
                var result = MessageBox.Show("Вы точно хотите удалить этот турнир?", "Удалить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    var item = TournamentDataGrid.SelectedItem as Tournament;
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

            var filteredComputers = db.Computer.Where(c =>
                c.name_computer.ToLower().Contains(searchText) ||
                c.id_computer.ToString().Contains(searchText)).ToList();

            ComputerDataGrid.ItemsSource = filteredComputers;
        }

        private void SearchTournament_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchReservationTextBox.Text.ToLower();

            var filteredTournaments = db.Tournament.Where(t =>
                t.name_tournament.ToLower().Contains(searchText) ||
                t.id_tournament.ToString().Contains(searchText) ||
                t.description.ToLower().Contains(searchText) ||
                t.game.ToLower().Contains(searchText)).ToList();

            TournamentDataGrid.ItemsSource = filteredTournaments;
        }

        private void SearchUser_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchUserTextBox.Text.ToLower();

            var filteredUsers = db.Users.Where(u =>
                u.login.ToLower().Contains(searchText) ||
                u.id_user.ToString().Contains(searchText) ||
                u.phone.Contains(searchText) ||
                u.email.ToLower().Contains(searchText) ||
                u.Role.name_role.ToLower().Contains(searchText)).ToList();

            UserDataGrid.ItemsSource = filteredUsers;
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            compos = db.Computer.ToList();
            ComputerDataGrid.ItemsSource = compos;

            tournaments = db.Tournament.ToList();
            TournamentDataGrid.ItemsSource = tournaments;

            users = db.Users.ToList();
            UserDataGrid.ItemsSource = users;
        }
    }
}
