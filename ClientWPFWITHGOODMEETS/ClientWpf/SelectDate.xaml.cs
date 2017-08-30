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
using System.Windows.Shapes;
using System.Threading;


namespace ClientWpf
{
    /// <summary>
    /// Логика взаимодействия для SelectDate.xaml
    /// </summary>
    public partial class SelectDate : Window
    {
        public static string datesofvisit;
        List<string> dates = new List<string>();
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public SelectDate()
        {
            MouseDown += Window_MouseDown;
            InitializeComponent();
            button.IsEnabled = true;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                string s = Convert.ToString(dates[i]);
                string[] ss = s.Split(' ');
                datesofvisit += ss[0] + ")";


            }
            this.Close();
            MessageBox.Show("Confirm result");

        }

        private void SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cale.SelectedDate != null)
            {
                DateTime z = Convert.ToDateTime(cale.SelectedDate).Date;
                cale.SelectedDates.Add(z);
                dates.Add(Convert.ToString(z));
        
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            datesofvisit = "";
            dates.Clear();
            MessageBox.Show("Choose the dates again!");
        }



        private void ChangeBrush(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = closeBtn.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void closeBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush("Resources/close12.png");
        }


        private void closeBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush("Resources/close1.png");
        }


    }
}
