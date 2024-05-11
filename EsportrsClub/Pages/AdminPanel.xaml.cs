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

        }

        private void EditTournament_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteTournament_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchComputer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchTournament_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SearchUser_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
