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
using System.Drawing;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Data.Entity;


namespace ClientWpf
{

    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>


    public partial class Registration : Window
    {
        private delegate void ChatEvent(string content);
        private Socket _serverSocketR;
        private Thread listenThreadR;
        //  private string _host = "127.0.0.1";//169.254.45.249
        //private string _host = "192.168.56.1";
        // private int _port = 2222;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        public static string RnameUser;
        public static string RpassUser;
        Random rand = new Random();
        public static string IndefNum;//переменная для хранения рандомного id
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public Registration()
        {   
            InitializeComponent();
            MouseDown += Window_MouseDown;
            IPAddress temp = IPAddress.Parse(ConnectionData._host);
            _serverSocketR = new Socket(temp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _serverSocketR.Connect(new IPEndPoint(temp, ConnectionData._port));
            if (_serverSocketR.Connected)
            {
               
                listenThreadR = new Thread(listner);
                listenThreadR.IsBackground = true;
                listenThreadR.Start();
            }
        }

        private void CurrentContent()
        {
            RnameUser = UsernameBox.Text;
            RpassUser = Convert.ToString(UserPasswordBox.Password);

            Login.nam = RnameUser;
            Login.pass = Convert.ToString(UserPasswordBox.Password);
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Close();
            mw.Show();
            Application.Current.MainWindow = mw;
            Send("#sock");
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            Application.Current.MainWindow.Close();
            log.Show();
            Application.Current.MainWindow = log;
        }

        public void handleCommand(string cmd)
        {

            string[] commands = cmd.Split('#');

            int countCommands = commands.Length;
            for (int i = 0; i < countCommands; i++)
            {
                try
                {
                    string currentCommand = commands[i];

                    if (currentCommand.Contains("regfailed"))
                    {
                        MessageBox.Show("Данный пользователь занят");
                        UsernameBox.Dispatcher.Invoke(delegate {UsernameBox.Text = null; });
                        UserPasswordBox.Dispatcher.Invoke(delegate { UserPasswordBox.Password = null; });
                        UserPasswordBoxConfirm.Dispatcher.Invoke(delegate { UserPasswordBoxConfirm.Password = null; });
                        continue;
                    }

                    if (currentCommand.Contains("setnamesuccess"))
                    {
 
                       test.Dispatcher.Invoke(delegate { CurrentContent(); /*button1.IsEnabled = true; button1.Opacity = 1;*/ });

                    }
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Error with handleCommand: " + exp.Message);
                }
            }
        }






        public void listner()
        {
            try
            {
                while (_serverSocketR.Connected)
                {

                    byte[] buffer = new byte[2048];
                    int bytesReceive = _serverSocketR.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                }
            }
            catch
            {
                MessageBox.Show("Связь с сервером прервана");
            }
        }


        public void Send(byte[] buffer)
        {
            try
            {
                _serverSocketR.Send(buffer);
            }
            catch { }
        }



        public void Send(string Buffer)
        {
            try
            {
                _serverSocketR.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }


        private void datacheck_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.Length > 0)
            {
                if (UserPasswordBox.Password.Length > 0)
                {
                    if (UserPasswordBoxConfirm.Password.Length > 0)
                    {
                        if (UserPasswordBox.Password == UserPasswordBoxConfirm.Password)
                        {

                            for (int i = 0; i < 9; i++)
                            {
                                IndefNum = Convert.ToString(rand.Next());//рандомное создание 9-ти значного id
                            }

                            string NewUser = UsernameBox.Text + ")" + Convert.ToString(UserPasswordBox.Password) + ")";
                            if (string.IsNullOrEmpty(NewUser))
                                return;

                            Send($"#addnewuser|{NewUser}");


                        }

                        else
                        {
                            MessageBox.Show("Пароли не совпадают!");
                            UserPasswordBoxConfirm.Password = null;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Подтвердите пароль!");
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль!");
                }
            }
            else
            {
                MessageBox.Show("Заполните поле логина!");
            }
        }

        private void ChangeBrush(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = closeBtn.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        private void ChangeBrush2(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = backButton.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush("Resources/close12.png");
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush("Resources/close1.png");
        }

        private void backButton_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush2("Resources/arrow-back2.png");

        }

        private void backButton_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush2("Resources/arrow-back.png");

        }

        private void test_MouseEnter(object sender, MouseEventArgs e)
        {
            test.Opacity = 1;
        }

        private void test_MouseLeave(object sender, MouseEventArgs e)
        {
            test.Opacity = 0.5;
        }
    }
}
