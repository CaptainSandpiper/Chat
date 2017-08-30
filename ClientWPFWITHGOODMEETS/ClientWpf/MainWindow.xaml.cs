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
//using System.Drawing;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Data.Entity;
using Microsoft.Win32;

//...


namespace ClientWpf
{

    public partial class MainWindow : Window
    {

        

        /////////////////////////////////////////////////
        private delegate void ChatEvent(string content);
        private ChatEvent _addMessage;
        private Socket _serverSocket;
        private Thread listenThread;
        bool IsSender = false;
        private string messageContent;
        string nunado, nunado2;
        bool indentdates = false;
        static public string mydate, yourdate;
        bool IsPrivate = false;

        public static string ss = "";
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        //////////////////////////////////////////////////////

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Smiles.Opacity = 100;
            Rec.Opacity = 0;
            b1.Opacity = 0;
            b2.Opacity = 0;
            b3.Opacity = 0;
            b4.Opacity = 0;
            b5.Opacity = 0;
            b6.Opacity = 0;
            b7.Opacity = 0;
            b8.Opacity =0;
            b9.Opacity = 0;
            b10.Opacity = 0;
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        public MainWindow()
        {
            InitializeComponent();
            Confirm.IsEnabled = false;
            MouseDown += Window_MouseDown;

            _addMessage = new ChatEvent(AddMessage);
            IPAddress temp = IPAddress.Parse(ConnectionData._host);
            _serverSocket = new Socket(temp.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            _serverSocket.Connect(new IPEndPoint(temp, ConnectionData._port));
            if (_serverSocket.Connected)
            {
                listenThread = new Thread(listner);
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            { AddMessage("Communication with server is not installed."); }
            string nickNameUser = Login.nam;
            string pas = Convert.ToString(Login.pass);
            Nik.Text = nickNameUser.ToUpper();
            string nickName = nickNameUser + ')' + pas + ')';
            if (string.IsNullOrEmpty(nickName))
                return;

            Send($"#setname|{nickName.ToUpper()}");
            Send($"#global|{Login.nam.ToUpper()}");
        }

        private void AddMessage(string Contentt)
        {
            ChatBox.Dispatcher.Invoke((ThreadStart)delegate { ChatBox.AppendText(Contentt + Environment.NewLine); });
        }



        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            string msgData = messageContent + OurMessageBox.Text;
            if (string.IsNullOrEmpty(msgData))
                return;
            if (msgData[0] == '"')
            {
                string temp = msgData.Split(' ')[0];
                string content = msgData.Substring(temp.Length + 1);
                temp = temp.Replace("\"", string.Empty);
                Send($"#private|{temp}|{content}");
                OurMessageBox.Text = string.Empty;
            }
            else
            {
                Send($"#message|{msgData}");
                OurMessageBox.Text = string.Empty;
            }

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_serverSocket.Connected)
                    Send("#endsession");
                Environment.Exit(0);
            }
            catch (Exception eee)
            {
                MessageBox.Show(eee.Message);
            }
        }

        /////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////


        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
        }



        public void Send(byte[] buffer)
        {
            try
            {
                _serverSocket.Send(buffer);
            }
            catch { }
        }



        public void Send(string Buffer)
        {
            try
            {
                _serverSocket.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
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

                    if (currentCommand.Contains("userlist"))
                    {
                        string[] Users = currentCommand.Split('|')[1].Split(',');
                        int countUsers = Users.Length;
                        USERSBOX.Dispatcher.Invoke((ThreadStart)delegate { USERSBOX.Items.Clear(); });
                        for (int j = 0; j < countUsers; j++)
                        {
                            USERSBOX.Dispatcher.Invoke((ThreadStart)delegate { USERSBOX.Items.Add(Users[j]); });
                        }
                        continue;
                    }


                    if (currentCommand.Contains("glchat"))
                    {

                        string[] Arguments = currentCommand.Split('|');

                        ChatBox.Dispatcher.Invoke(delegate { AddMessage(Arguments[1]); });


                    }

                    if (currentCommand.Contains("msg"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        if (Arguments[1].Contains(".jpg") || Arguments[1].Contains(".png") || Arguments[1].Contains(".bmp") || Arguments[1].Contains(".ico"))
                        {
                            ChatBox.Dispatcher.Invoke(delegate { setImage(Arguments[1], Arguments[2]); });
                        }
                        else
                        {
                            if ((Arguments[1].Contains("-[to]") || Arguments[1].Contains("-[from]")) && IsPrivate == true)
                            {

                                ChatBox.Dispatcher.Invoke(delegate { AddMessage(Arguments[1]); });

                            }
                            if (IsPrivate == false)
                            {
                                AddMessage(Arguments[1]);
                            }
                        }

                    }
                    if (currentCommand.Contains("gfile"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string fileName = Arguments[1];
                        string FromName = Arguments[2];
                        string FileSize = Arguments[3];
                        string idFile = Arguments[4];
                        if (fileName.Contains("jpg") || fileName.Contains("png") || fileName.Contains("bmp") || fileName.Contains("ico"))
                        {
                            Thread.Sleep(1000);
                            Send("#yy|" + idFile);
                            byte[] fileBuffer = new byte[int.Parse(FileSize)];
                            _serverSocket.Receive(fileBuffer);

                            File.WriteAllBytes(fileName, fileBuffer);
                            Thread.Sleep(1000);

                            ChatBox.Dispatcher.Invoke(delegate { IsSender = false; setImage(fileName, FromName); });
                        }
                        else
                        {
                            //MessageBoxResult Result = MessageBox.Show($"Do you want to accept the file { fileName} the size {FileSize} from {FromName}", "File", MessageBoxButton.YesNo);
                            //if (Result == MessageBoxResult.Yes)
                            //{
                            Thread.Sleep(1000);
                            Send("#yy|" + idFile);
                            byte[] fileBuffer = new byte[int.Parse(FileSize)];
                            _serverSocket.Receive(fileBuffer);

                            File.WriteAllBytes(fileName, fileBuffer);
                            Thread.Sleep(1000);
                            MessageBox.Show($"File {fileName} by {FromName} was accepted.");
                            ChatBox.Dispatcher.Invoke(delegate { ChatBox.AppendText("FILE " + fileName + " ACCEPTED." + Environment.NewLine); });
                            string commandText = fileName;
                            var proc = new System.Diagnostics.Process();
                            proc.StartInfo.FileName = commandText;
                            proc.StartInfo.UseShellExecute = true;
                            proc.Start();
                            //}

                            //else
                            //{
                            //    ChatBox.Dispatcher.Invoke(delegate { ChatBox.AppendText("FILE " + fileName + " WAS SENT BUT NOT ACCEPTED." + Environment.NewLine); });
                            //    Send("nn");
                            //}
                            continue;
                        }
                    }


                    if (currentCommand.Contains("choice"))
                    {
                       
                        this.Dispatcher.Invoke((ThreadStart)delegate
                        {
                            SelectDate SD = new SelectDate();
                            SD.Show();
                        });
                        Confirm.Dispatcher.Invoke((ThreadStart)delegate { Confirm.IsEnabled = true; });
                    }


                    if (currentCommand.Contains("howaboutmeet"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];
                        MessageBoxResult Result = MessageBox.Show($"Do you want to arrange a meeting with  {first} ?", "MEET?", MessageBoxButton.YesNo);
                        if (Result == MessageBoxResult.Yes)
                        {
                            indentdates = true;
                            nunado = first;
                            nunado2 = second;
                            Send($"#agree|{first}|{second}");
                            MessageBox.Show("Wait for " + first + " to choose the dates");

                        }
                        else
                            Send($"#notagre|{first}|{second}");
                        continue;
                    }

                    if (currentCommand.Contains("okay"))
                    {
                       
                        this.Dispatcher.Invoke((ThreadStart)delegate
                        {
                            SelectDate SD = new SelectDate();
                            SD.Show();
                        });
                        Confirm.Dispatcher.Invoke((ThreadStart)delegate { Confirm.IsEnabled = true; });
                    }


                    if (currentCommand.Contains("nope"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];
                        MessageBox.Show("User " + second + " refused to create a meeting", "Answer");

                    }

                    if (currentCommand.Contains("SecDat"))
                    {
                 
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[2];
                        string second = Arguments[3];
                        yourdate = Arguments[1];
                        mydate = SelectDate.datesofvisit;
                        string[] YD = yourdate.Split(')');
                        string[] FD = mydate.Split(')');
                        string alldd = "";

                        IEnumerable<string> Tog = FD.Intersect(YD);
                        foreach (string datttes in Tog)
                        {
                            alldd += datttes + "\n";
                        };
                        string alld = alldd.Substring(0, alldd.Length-1);
                        Send($"#endofmeet|{alld}|{first}|{second}");
                        SelectDate.datesofvisit = "";
                    }


                    if (currentCommand.Contains("theend"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string s = Arguments[1];
                        string[] k = s.Split('\n');
                        for (int l = 0; l < k.Count()-1; l++)
                        {
                           
                            ss += k[l] + ")";
                        }
                        this.Dispatcher.Invoke((ThreadStart)delegate 
                        {
                            Result aaa = new Result();
                            aaa.Show();
                            ss = "";
                        });
                    }


                    if (currentCommand.Contains("noresult"))
                    {
                        MessageBox.Show("You haven't got common dates for a meeting");
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
                while (_serverSocket.Connected)
                {
                    byte[] buffer = new byte[4096];
                    int bytesReceive = _serverSocket.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                   

                }
            }
            catch
            {
                MessageBox.Show("Связь с сервером прервана");
               
            }
        }


        private void messageData_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SendBtn_Click(sender, e);
            }

        }


        private void Grid_Initialized(object sender, EventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        public void setImage(string FileNam,string SendName)
        {
            if (!(System.IO.File.Exists(FileNam)))
            {
                ChatBox.AppendText("FILE " + FileNam + " WAS DAMNED OR DELETED FROM SOURCE!" + Environment.NewLine);
            }
            else
            {
                System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                image.Stretch = Stretch.UniformToFill;
                BitmapImage bmp = new BitmapImage(new Uri(FileNam, UriKind.Relative));

                image.Width = 380;
                image.Source = bmp;
                Paragraph block = new Paragraph();
                block.Margin = new Thickness(2);
                block.Inlines.Add(image);
                ChatBox.AppendText(SendName);
                ChatBox.Document.Blocks.Add(block);
            }
        }

        private void ChatBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ChatBox.ScrollToEnd();
           
        }

        private void SendFile_Click(object sender, RoutedEventArgs e)
        {
            if (USERSBOX.SelectedItem == " ")
            {
                return;
            }

            OpenFileDialog ofp = new OpenFileDialog();
            ofp.ShowDialog();
            if (!File.Exists(ofp.FileName))
            {
                MessageBox.Show($"No selected files!");
                return;
            }
            FileInfo fi = new FileInfo(ofp.FileName);
            byte[] buffer = File.ReadAllBytes(ofp.FileName);
            Send($"#sendfileto|{USERSBOX.SelectedItem}|{buffer.Length}|{fi.Name}");//g
            Thread.Sleep(1000);
            Send(buffer);
            Thread.Sleep(1000);
            if (fi.Name.Contains(".jpg") || fi.Name.Contains(".png") || fi.Name.Contains(".bmp") || fi.Name.Contains(".ico"))
            {
                File.WriteAllBytes(fi.Name, buffer);
                setImage(fi.Name, Login.nam.ToUpper());
            }
            else
            {
                ChatBox.AppendText("FILE " + fi.Name + " WAS SENT." + Environment.NewLine);
            }
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (USERSBOX.SelectedItem != " ")
            {
                IsPrivate = true;
                privateBtn.Opacity = 1;
                globalBtn.Opacity = 0.5;
                changeLb.Content = "PRIVATE CHAT";
                ChatBox.Document.Blocks.Clear();
                Paragraph block = new Paragraph();
                block.Margin = new Thickness(2);
                ChatBox.Document.Blocks.Add(block);
                messageContent = $"\"{USERSBOX.SelectedItem} ";
                string temp = messageContent;
                temp = temp.Replace("\"", string.Empty);
                Send($"#read|{temp}");

            }
        }

       

        public void letsgo()
        {
            string first = Login.nam;
            string second = Convert.ToString(USERSBOX.SelectedItem);
            Send($"#ycan|{first}|{second}");
        }

      
   

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (indentdates)
            {
                string first = nunado;
                string second = nunado2;
                string ddates = SelectDate.datesofvisit;
                Send($"dates|{ddates}|{first}|{second}");
                SelectDate.datesofvisit = "";
                indentdates = false;
            }
            else
            {
                letsgo();
              
            }
            Confirm.Dispatcher.Invoke(delegate { Confirm.IsEnabled = false; });
           

        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            IsPrivate = false;
            ChatBox.Document.Blocks.Clear();
            Paragraph block = new Paragraph();
            block.Margin = new Thickness(2);
            ChatBox.Document.Blocks.Add(block);
            privateBtn.Opacity = 0.5;
            globalBtn.Opacity = 1;
            changeLb.Content = "GLOBAL CHAT";
            messageContent = null;
            Send($"#global|{Login.nam.ToUpper()}");
            USERSBOX.SelectedIndex = -1;
        }


      
        private void Meet(object sender, RoutedEventArgs e)
        {
            //if (indentdates == false)
            //{
                if (USERSBOX.SelectedItem == null)
                {
                    return;
                }
                else
                {
                    string first = Login.nam;
                    string second = Convert.ToString(USERSBOX.SelectedItem);
                    Send($"#letsmeet|{first.ToUpper()}|{second}");
                }
           // }
            SelectDate.datesofvisit = "";
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
            ImageBrush content = MinimizeBtn.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        private void ChangeBrush3(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = SendFile.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        private void ChangeBrush4(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = Smiles.Background as ImageBrush;
            content.ImageSource = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
        }
        private void ChangeBrush5(string ImgPath)
        {
            string imageRelativePath = ImgPath;
            string imagePath = System.IO.Path.Combine(baseDirectory, imageRelativePath);
            ImageBrush content = SendBtn.Background as ImageBrush;
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

        private void SendFile_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush3("Resources/file2.png");

        }

        private void SendFile_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush3("Resources/file.png");
        }

        private void Smiles_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush4("Resources/smile2.png");
        }

        private void Smiles_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush4("Resources/smile.png");
        }

        private void SendBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            ChangeBrush5("Resources/send2.png");

        }

        private void SendBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            ChangeBrush5("Resources/send.png");
        }


        string[] smiles = {
                           "( ^_^)",
                           "( U_U)",
                           "( ¬_¬)",
                           "( >_<)",
                           "( о_О)",
                           "( $v$)",
                           "( @_@)",
                           "( ^_-)",
                          "( *^_^)",
                            "( *^)3"
};
        public void Smile(int index)
        {
            OurMessageBox.Text += smiles[index];
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Rec.Opacity = 100;
            b1.Opacity = 100;
            b2.Opacity = 100;
            b3.Opacity = 100;
            b4.Opacity = 100;
            b5.Opacity = 100;
            b6.Opacity = 100;
            b7.Opacity = 100;
            b8.Opacity = 100;
            b9.Opacity = 100;
            b10.Opacity = 100;
            Smiles.Opacity = 0;
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            Smile(0);
        }

        private void b2_Click(object sender, RoutedEventArgs e)
        {
            Smile(1);
        }

        private void b3_Click(object sender, RoutedEventArgs e)
        {
            Smile(2);
        }

        private void b4_Click(object sender, RoutedEventArgs e)
        {
            Smile(3);
        }

        private void b5_Click(object sender, RoutedEventArgs e)
        {
            Smile(4);
        }

        private void b6_Click(object sender, RoutedEventArgs e)
        {
            Smile(5);
        }

        private void b7_Click(object sender, RoutedEventArgs e)
        {
            Smile(6);
        }

        private void b8_Click(object sender, RoutedEventArgs e)
        {
            Smile(7);
        }

        private void b9_Click(object sender, RoutedEventArgs e)
        {
            Smile(8);
        }

        private void b10_Click(object sender, RoutedEventArgs e)
        {
            Smile(9);
        }
    }


   
}
