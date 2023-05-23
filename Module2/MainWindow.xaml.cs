using Module2.AppPage;
using System.Windows;
using Module2.Model;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;
using System.Data;
using System.Windows.Navigation;

namespace Module2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new PageAbonent();
            var de = CallCentersEntities2.GetContext().usersRole.ToList();
            RoleBoxSelect.ItemsSource = de;

        }

        private void RoleBoxSelect_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            var selectedRole = RoleBoxSelect.SelectedItem as usersRole;

            switch (selectedRole.role)
            {
                case "Руководитель отдела по работе с клиентами":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Директор по развитию.jpg", UriKind.Relative));
                    managementEquipment.IsEnabled = false;
                    break;
                case "Менеджер по работе с клиентами":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Менеджер по работе с клиентами.jpg", UriKind.Relative));
                    break;
                case "Руководитель отдела технической поддержки":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Руководитель тех отдела.png", UriKind.Relative));
                    managementEquipment.IsEnabled = true;
                    break;
                case "Специалист технической поддержки":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Специалист ТП.png", UriKind.Relative));
                    break;
                case "Бухгалтер":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Бухгалтер.jpg", UriKind.Relative));
                    break;
                case "Директор по развитию":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Директор по развитию.jpg", UriKind.Relative));
                    break;
                case "Технический департамент":
                    RoleImage.Source = new BitmapImage(new Uri("/img/Технический департамент.jpg", UriKind.Relative));
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageAbonent());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageBilling());
        }

        private void managementEquipment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageManagementEquipment());
        }

        private void AssetsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new Assets());
        }

        private void UserSupportBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageUserSupport());
        }

        private void CrmBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new PageCRM());
        }
    }
}
