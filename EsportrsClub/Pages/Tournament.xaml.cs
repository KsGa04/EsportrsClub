﻿using System;
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
    /// Логика взаимодействия для Tournament.xaml
    /// </summary>
    public partial class Tournament : Page
    {
        EsportsClubEntities db = new EsportsClubEntities();
        public Tournament()
        {
            InitializeComponent();
            DataContext = db.Tournament.ToList();
        }
    }
}
