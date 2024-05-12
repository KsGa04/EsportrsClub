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
using EsportrsClub.Class;

namespace EsportrsClub
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EsportsClubEntities db = new EsportsClubEntities();
        public MainWindow()
        {
            InitializeComponent();
            if (Auth.Role == "Администратор")
            {
                MainFrame.Navigate(new Pages.AdminPanel());
                home.IsEnabled = false;
                computer.IsEnabled = false;
                tournament.IsEnabled = false;
                about.IsEnabled = false;
            }
            else
            {
                MainFrame.Navigate(new Pages.Home());
            }
            CheckAndUpdateComputerStatus();
        }
        public void CheckAndUpdateComputerStatus()
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime currentDate = currentDateTime.Date;

            foreach (Computer computer in db.Computer.ToList())
            {
                var activeBookings = db.Book
                    .Where(b => b.id_computer == computer.id_computer)
                    .ToList();

                bool isComputerBusy = activeBookings.Any(b =>
                    b.date_book <= currentDate
                    && b.date_book.Add(TimeSpan.FromHours(b.duration)) > currentDate);

                if (isComputerBusy)
                {
                    if (computer.Status.name_status != "Занят")
                    {
                        Computer computer1 = db.Computer.Where(x => x.id_computer == computer.id_computer).FirstOrDefault();
                        computer1.id_status = 2;
                        db.SaveChanges();
                    }
                }
                else
                {
                    if (computer.Status.name_status != "Свободен")
                    {
                        Computer computer1 = db.Computer.Where(x => x.id_computer == computer.id_computer).FirstOrDefault();
                        computer1.id_status = 1;
                        db.SaveChanges();
                    }
                }
            }
        }
        private void home_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Home());
        }

        private void computer_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Computers());
        }

        private void tournament_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.Tournaments());
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.About());
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Auth.IsAuth == false)
            {
                Authorization authorization = new Authorization();
                authorization.Show();
                this.Hide();
            }
            else {
                MainFrame.Navigate(new Pages.PrivateAcc());
            }
        }
    }
}
