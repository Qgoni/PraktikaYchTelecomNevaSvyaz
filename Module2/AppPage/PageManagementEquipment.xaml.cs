﻿using Module2.Model;
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

namespace Module2.AppPage
{
    /// <summary>
    /// Логика взаимодействия для PageManagementEquipment.xaml
    /// </summary>
    public partial class PageManagementEquipment : Page
    {
        public PageManagementEquipment()
        {
            InitializeComponent();
            DataGridManagment.ItemsSource = CallCentersEntities2.GetContext().Transponder.ToList();
        }


    }
}
