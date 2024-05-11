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
        public MainWindow()
        {
            InitializeComponent();
            if (Auth.Role == "Организация")
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
            MainFrame.Navigate(new Pages.Tournament());
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
