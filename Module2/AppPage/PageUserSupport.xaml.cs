using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для PageUserSupport.xaml
    /// </summary>
    public partial class PageUserSupport : Page
    {
        public PageUserSupport()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int sum = 0; sum <= 100; sum++)
            {
                ProgressBar.Value = sum;
                await Task.Delay(50); 

                if (ProgressBar.Value >= 100)
                {
                    ProgressBar.Value = 0;
                }
            }
            MessageBox.Show($"\n Заявка добавлена! Номер абонента: {SubscriberNumberTextBox.Text}" +
                $"\n Лицевой счет: {AccountNumberTextBox.Text} " +
                $"\n Услуга: {ServiceComboBox.Text} " +
                $"\n Вид услуги: {ServiceTypeComboBox.Text} " +
                $"\n Тип проблемы: {ProblemTypeComboBox.Text} " +
                $"\n Описание проблемы: {DescriptionTextBox.Text}");           
        }
    }
}
