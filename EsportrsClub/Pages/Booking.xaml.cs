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

namespace EsportrsClub.Pages
{
    /// <summary>
    /// Логика взаимодействия для Booking.xaml
    /// </summary>
    public partial class Booking : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        double total_price = 0;
        public Booking(Tournament tournaments = null, Computer computers = null)
        {
            InitializeComponent();
            foreach (var d in db.Tournament)
            {
                tournament.Items.Add(d.name_tournament);
            }
            foreach (var d in db.Computer)
            {
                computer.Items.Add(d.name_computer);
            }
            if (tournaments != null)
            {
                tournament.SelectedIndex = tournaments.id_tournament - 1;
            }
            if (computers != null)
            {
                computer.SelectedIndex = computers.id_computer - 1;
            }
            DurationSlider.ValueChanged += DurationSlider_ValueChanged;
        }

        private void Book_Click(object sender, RoutedEventArgs e)
        {
            if (Auth.UserID == 0 && Auth.IsAuth == false)
            {
                MessageBox.Show("Необходима авторизация");
                this.NavigationService.GoBack();

                // Закрываем фрейм, если он есть
                if (this.Parent is Frame)
                {
                    (this.Parent as Frame).Content = null;
                }

                // Закрываем главное окно
                if (this.Parent is Window)
                {
                    (this.Parent as Window).Close();
                }
            }
            else
            {
                string selectedTime = (string)((ComboBoxItem)TimePicker.SelectedItem).Content;

                // Преобразовать строку в TimeSpan
                TimeSpan timeSpan = TimeSpan.Parse(selectedTime);

                Book book = new Book();
                book.date_book = (DateTime)DatePicker.SelectedDate;
                book.time_book = timeSpan;
                book.duration = (int)DurationSlider.Value;
                book.service_drink = checkDrink.IsChecked;
                book.service_food = checkFood.IsChecked;
                book.id_computer = computer.SelectedIndex + 1;
                if (tournament.SelectedIndex != -1)
                {
                    book.id_tournament = tournament.SelectedIndex + 1;
                }
                book.total_price = (decimal)total_price;
                book.id_user = Auth.UserID;
                db.Book.Add(book);
                db.SaveChanges();
                MessageBox.Show("Компьютер забронирован");
            }

        }

        private void DurationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (computer != null)
            {
                var selectedComputer = db.Computer.FirstOrDefault(x => x.name_computer == computer.SelectedItem.ToString());
                if (selectedComputer != null)
                {
                    double price = (double)selectedComputer.price;
                    total_price = price * DurationSlider.Value;
                    RentalCost.Text = total_price.ToString() + " руб.";

                }
                else
                {
                    RentalCost.Text = "0 руб.";
                }
            }
        }

        private void checkFood_Checked(object sender, RoutedEventArgs e)
        {
            total_price += 350;
            RentalCost.Text = total_price.ToString() + " руб.";
        }

        private void checkFood_Unchecked(object sender, RoutedEventArgs e)
        {
            total_price -= 350;
            RentalCost.Text = total_price.ToString() + " руб.";
        }

        private void checkDrink_Checked(object sender, RoutedEventArgs e)
        {
            total_price += 270;
            RentalCost.Text = total_price.ToString() + " руб.";
        }

        private void checkDrink_Unchecked(object sender, RoutedEventArgs e)
        {
            total_price -= 270;
            RentalCost.Text = total_price.ToString() + " руб.";
        }
    }
}
