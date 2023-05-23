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
using TelecomТeoSvyaz.Model;

namespace TelecomТeoSvyaz.PagesApp
{
    /// <summary>
    /// Логика взаимодействия для Авторизация.xaml
    /// </summary>
    public partial class Авторизация : Page
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        CallCenterEntities1 db = new CallCenterEntities1();
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberTxb.Text, out int convertNumber) && int.TryParse(CodeTxb.Text, out int convertCode) && !string.IsNullOrEmpty(Passbox.Password))
            {
                var user = db.users.FirstOrDefault(x => x.number == convertNumber && x.code == convertCode && x.password == Passbox.Password);
                if (user == null)
                {
                    MessageBox.Show("Пользователя нет в базе данных");
                }
                else
                {
                    MessageBox.Show("Вход выполнен");
                    //NavigationService.Navigate();
                }
                
            }
            else
            {
                MessageBox.Show("Введите данные");
            }
        }

        private void Update_KeyDown(object sender, MouseButtonEventArgs e)
        {
            NumberTxb.Text = "";
            CodeTxb.Text = "";
            Passbox.Password = "";
        }
    }
}
