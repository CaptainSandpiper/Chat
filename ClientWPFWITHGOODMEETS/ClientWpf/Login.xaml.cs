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

namespace ClientWpf
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>

    public partial class Login : Window
    {
        private delegate void ChatEvent(string content);
        private Socket _serverSocketL;
        private Thread listenThreadL;
        static public string nam;
        static public string pass;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        public Login()
        {
            MouseDown += Window_MouseDown;
            InitializeComponent();
            IPAddress temp = IPAddress.Parse(ConnectionData._host);
            _serverSocketL = new Socket(temp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _serverSocketL.Connect(new IPEndPoint(temp, ConnectionData._port));
            if (_serverSocketL.Connected)
            {

                listenThreadL = new Thread(listner);
                listenThreadL.IsBackground = true;
                listenThreadL.Start();
            }
        }
        public void Send(byte[] buffer)
        {
            try
            {
                _serverSocketL.Send(buffer);
            }
            catch { }
        }



        public void Send(string Buffer)
        {
            try
            {
                _serverSocketL.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }




        public void listner()
        {
            try
            {
                while (_serverSocketL.Connected)
                {

                    byte[] buffer = new byte[2048];
                    int bytesReceive = _serverSocketL.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                }
            }
            catch
            {
                MessageBox.Show("Связь с сервером прервана");
            }
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



                    if (currentCommand.Contains("setnamesuccess"))
                    {
                        test.Dispatcher.Invoke((ThreadStart)delegate { CurrentFunction();});
                  
                    }
                    if (currentCommand.Contains("setnamefailed"))
                    {
                        UsernameBox.Dispatcher.Invoke((ThreadStart)delegate { UsernameBox.Clear(); });
                        UserPasswordBox.Dispatcher.Invoke((ThreadStart)delegate { UserPasswordBox.Clear(); });
                        MessageBox.Show("Логин или пароль введены неверно!");
                    }




                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error with handleCommand: " + exp.Message);
                }
            }
        }

        private void CurrentFunction()
        {
            nam = UsernameBox.Text;
            pass = Convert.ToString(UserPasswordBox.Password);

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
        
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            Registration reg = new Registration();
            Application.Current.MainWindow.Close();
            reg.Show();
            Application.Current.MainWindow = reg;
        
        }

        private void Check_Data(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.Length > 0)
            {
                if (UserPasswordBox.Password.Length > 0)
                {
                    string nickNameUser = UsernameBox.Text;
                    string pas = Convert.ToString(UserPasswordBox.Password);
                    string nickName = nickNameUser + ')' + pas + ')';
                    Send($"#logcheck|{nickName}");
                }
                else
                {
                    MessageBox.Show("Введите пароль!");
                }
            }
            else
            {
                MessageBox.Show("Введите логин!");
            }
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

