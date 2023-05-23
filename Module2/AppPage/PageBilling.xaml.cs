using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Drawing.Imaging;
using System.Printing;
using Rectangle = System.Drawing.Rectangle;
using System.Collections.Generic;
using System.Linq;

namespace Module2.AppPage
{
    /// <summary>
    /// Логика взаимодействия для PageBilling.xaml
    /// </summary>
    public partial class PageBilling : Page
    {
        public PageBilling()
        {
            InitializeComponent();
            List<Service> services = new List<Service>()
            {
                new Service("Интернет", "Стандарт", "15 Мбит/с", "100"),
                new Service("Интернет", "Оптима", "45 Мбит/с", "200"),
                new Service("Интернет", "Супер", "100 Мбит/с", "600"),
                new Service("Видеонаблюдение", "Базовый", "2 точки наблюдения", "200"),
                new Service("Видеонаблюдение", "Базовый Плюс", "2 точки наблюдения, хранение записи 1 месяц", "400"),
                new Service("Видеонаблюдение", "Оптимальный", "4 точки наблюдения", "400"),
                new Service("Видеонаблюдение", "Оптимальный Плюс", "4 точки наблюдения, хранение записи 1 месяц", "600"),
                new Service("Телевидение", "Чуть-чуть смотри", "10 каналов", "200"),
                new Service("Телевидение", "Побольше смотри", "20 каналов", "315"),
                new Service("Телевидение", "Много смотри", "100 каналов", "400"),
                new Service("Телевидение", "Смотри и овощи", "150 каналов", "500"),
                new Service("Мобильная связь", "Никому не звони", "10 минут, 20 SMS", "49,9"),
                new Service("Мобильная связь", "Звони только маме", "50 минут, 20 SMS", "67,9"),
                new Service("Мобильная связь", "Звони родным", "120 минут, 20 SMS", "78,99"),
                new Service("Мобильная связь", "Болтай без умолку", "1000 минут, 20 SMS", "400,91")
            };
            serviceComboBox.ItemsSource = services.Select(s => s.Usluga).Distinct();
            tariffComboBox.ItemsSource = services.Select(s => s.NazvanieTarifa).Distinct();
            conditionsComboBox.ItemsSource = services.Select(s => s.Usloviya).Distinct();
            priceComboBox.ItemsSource = services.Select(s => s.Stoimost).Distinct();

        }
        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
           
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                PrintQueue printer = printDialog.PrintQueue;
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, args) =>
                {                    
                    UIElement pageContent = Papo; 
                    System.Windows.Size pageSize = new System.Windows.Size(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                    pageContent.Measure(pageSize);
                    pageContent.Arrange(new Rect(pageSize));
                  
                    DrawingVisual visual = new DrawingVisual();
                    using (DrawingContext drawingContext = visual.RenderOpen())
                    {
                        drawingContext.DrawRectangle(new VisualBrush(pageContent), null, new Rect(pageSize));
                    }
                    RenderTargetBitmap bitmap = new RenderTargetBitmap((int)pageSize.Width, (int)pageSize.Height, 96, 96, PixelFormats.Pbgra32);
                    bitmap.Render(visual);
                    args.Graphics.DrawImage(bitmap.ConvertToBitmap(), 0, 0);
                };
                
                printDocument.PrinterSettings.PrinterName = printer.FullName;
                printDocument.Print();
            }
        }
    }
    public static class BitmapExtensions
    {
        public static Bitmap ConvertToBitmap(this BitmapSource bitmapSource)
        {
            Bitmap bitmap = new Bitmap(bitmapSource.PixelWidth, bitmapSource.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bitmap.LockBits(new Rectangle(System.Drawing.Point.Empty, bitmap.Size), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            bitmapSource.CopyPixels(Int32Rect.Empty, data.Scan0, data.Height * data.Stride, data.Stride);
            bitmap.UnlockBits(data);
            return bitmap;
        }
    }
    public class Service
    {
        public string Usluga { get; set; }
        public string NazvanieTarifa { get; set; }
        public string Usloviya { get; set; }
        public string Stoimost { get; set; }

        public Service(string usluga, string nazvanieTarifa, string usloviya, string stoimost)
        {
            Usluga = usluga;
            NazvanieTarifa = nazvanieTarifa;
            Usloviya = usloviya;
            Stoimost = stoimost;
        }
    }
}


