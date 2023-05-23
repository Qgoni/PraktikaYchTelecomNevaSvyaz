using Module2.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для PageAbonent.xaml
    /// </summary>
    public partial class PageAbonent : Page
    {
        
        public PageAbonent()
        {            
            InitializeComponent();
        }
        CallCentersEntities2 db = new CallCentersEntities2();
        private void DataGridAbonents_Loaded(object sender, RoutedEventArgs e)
        {
            db.Abonents.Load();
            DataGridAbonents.ItemsSource = db.Abonents.Local.ToBindingList();
            db.SaveChanges();
        }
    }
}
