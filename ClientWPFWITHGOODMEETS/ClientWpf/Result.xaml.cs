using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
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
using System.Threading;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Data.Entity;
using Microsoft.Win32;
namespace ClientWpf
{
    /// <summary>
    /// Логика взаимодействия для Result.xaml
    /// </summary>
    public partial class Result : Window
    {

        int day;
        int mounth;
        int year;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public Result()
        {
            MouseDown += Window_MouseDown;
            InitializeComponent();



            string[] ddd = MainWindow.ss.Split(')');
            for (int u = 0; u < ddd.Count() - 1; u++)
            {
                string[] k = ddd[u].Split('.');
                year = Convert.ToInt32(k[2]);
                mounth = Convert.ToInt32(k[1]);
                day = Convert.ToInt32(k[0]);

                calendar.Dispatcher.Invoke(delegate { calendar.SelectedDates.Add(new DateTime(year, mounth, day)); });
            }
        }

        private void accept_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        private void SDChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void ChangeBrush2(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = MinimizeBtn.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }


        private void MinimizeBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MinimizeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush2("Resources/min2.png");
        }

        private void MinimizeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush2("Resources/min.png");

        }

    }
}
