using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    public class User
    {
        private Thread _userThread;
        private string _userName;
        private bool AuthSuccess = false;
        private bool registr = false;
        private bool loginch = false;
        private string passwordB;
        private string nuid;
      
        Random rand = new Random();
        public string Username
        {
            get { return _userName; }
        }
        private Socket _userHandle;


        public User(Socket handle)
        {
            _userHandle = handle;
            _userThread = new Thread(listner);
            _userThread.IsBackground = true;
            _userThread.Start();
        }

        private void sendToBD(string Target,string Message)
        {
            
            string TargetName = Target;
            string ContentMsg = Message;
            User targetUser = Server.GetUser(TargetName);

            int maxMesId = 0;
            DateTime Time = DateTime.Now;
            ////////////////////////////////////////////////////////////////// ////////////////////////////////////////////////////////////////

            MessengerEntities4 bds = new MessengerEntities4();

            Users iam = new Users();
            Users b = new Users();
            Messages mes = new Messages();
            Content con = new Content();

            iam = bds.Users.FirstOrDefault(us => us.name == Username);
            b = bds.Users.FirstOrDefault(us => us.name == TargetName);//проверка на наличие схожих имен в БД 


            foreach (Messages message in bds.Messages)
            {

                if (message.id >= maxMesId)
                {
                    maxMesId = message.id;
                }

            }
            maxMesId++;

            con.id = maxMesId;
            con.content1 = ContentMsg;
            bds.Content.Add(con);
            bds.SaveChanges();

            mes.id = maxMesId;
            mes.to_id = b.id;
            mes.from_id = iam.id;
            mes.content_id = maxMesId;
            mes.create_at = Time;
            bds.Messages.Add(mes);
            bds.SaveChanges();
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        }

        private void listner()
        {
            try
            {
                while (_userHandle.Connected)
                {
                    byte[] buffer = new byte[4096];
                    int bytesReceive = _userHandle.Receive(buffer);
                    handleCommand(Encoding.Unicode.GetString(buffer, 0, bytesReceive));
                }
            }
            catch { Server.EndUser(this); }
        }




        private bool setName(string Name)
        {
            
            string[] dataUser = Name.Split(')');
            _userName = dataUser[0];
            passwordB = dataUser[1];


            MessengerEntities4 db = new MessengerEntities4();
            Users IE = new Users();
            IE = db.Users.FirstOrDefault(us => us.name == _userName && us.password == passwordB);
            if (IE != null)
            {
                if (loginch == true || registr == true)
                {
                   
                    Server.NewUser2(this);
                    
                }
                else
                {
                    Server.NewUser(this);
                }
                AuthSuccess = true;
                return true;

            }
            else
            {
                return false;

            }

        }

        private bool AU(string Info)
        {

            string[] NewUserData = Info.Split(')');
            _userName = NewUserData[0];
            passwordB = NewUserData[1];


            MessengerEntities4 db = new MessengerEntities4();
            Users user = new Users();
            Users b = new Users();
            b = db.Users.FirstOrDefault(us => us.name == _userName);
            if (b == null)
            {
                start:
                for (int i = 0; i < 9; i++)
                {
                    nuid = Convert.ToString(rand.Next());//рандомное создание 9-ти значного id
                }
                Users IE = new Users();
                IE = db.Users.FirstOrDefault(us => us.id == nuid);
                if (IE == null)
                {
                    user.id = nuid;
                    user.name = _userName;
                    user.password = passwordB;
                    db.Users.Add(user);
                    db.SaveChanges();
                    
                    registr = true;
                    setName(Info);
                }
                else
                {
                    goto start;
                }
                return true;

            }
            else { return false; }
        }


        private void handleCommand(string cmd)
        {
            try
            {
                string[] commands = cmd.Split('#');
                int countCommands = commands.Length;
                for (int i = 0; i < countCommands; i++)
                {
                    string currentCommand = commands[i];
                    if (string.IsNullOrEmpty(currentCommand))
                        continue;
                    if (!AuthSuccess)
                    {
                        if (currentCommand.Contains("logcheck"))
                        {
                            loginch = true;
                            
                            if (setName(currentCommand.Split('|')[1]+")l"))
                                Send("#setnamesuccess");
                            else
                                Send("#setnamefailed");
                        }
                        if (currentCommand.Contains("setname"))
                        {
                            
                            if (setName(currentCommand.Split('|')[1]))
                                Send("#setnamesuccess");
                            else
                                Send("#setnamefailed");
                        }

                        if (currentCommand.Contains("addnewuser"))
                        {
                           
                            if (AU(currentCommand.Split('|')[1]))
                            {
                                Send("#setnamesuccess");
                            }
                            else
                            {
                                
                                Send("#regfailed");
                            }
                        }
                        continue;

                    }
                    if (currentCommand.Contains("yy"))
                    {
                        string id = currentCommand.Split('|')[1];
                        Server.FileD file = Server.GetFileByID(int.Parse(id));
                        if (file.ID == 0)
                        {
                            SendMessage("Ошибка при передаче файла...");
                            continue;
                        }
                        Send(file.fileBuffer);
                        Server.Files.Remove(file);
                    }////////////////////////////////////////////////////////////////////////////////////////////////////
                    if (currentCommand.Contains("message"))
                    {
                        int IntGlobId = 0;
                        MessengerEntities4 bds = new MessengerEntities4();
                        string[] Arguments = currentCommand.Split('|');
                        Server.SendGlobalMessage($"[{_userName}]: {Arguments[1]}" + " (" + DateTime.Now + ")");
                        Global NewGlobal = new Global();
                        foreach (Global glob in bds.Global)
                        {
                            IntGlobId++;
                        }
                        NewGlobal.id = IntGlobId;
                        NewGlobal.message = _userName + "/" + Arguments[1]+" ("+DateTime.Now+")";
                        bds.Global.Add(NewGlobal);
                        bds.SaveChanges();

                        continue;
                    }
                    if (currentCommand.Contains("global"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        MessengerEntities4 bds = new MessengerEntities4();
                        foreach (Global glob in bds.Global)
                        {
                            string [] Cont = glob.message.Split('/');
                            Server.SendGlobalMessage2($"[{Cont[0]}]: {Cont[1]}",Arguments[1]);
                        }

                    }
                        if (currentCommand.Contains("endsession"))
                    {
                        Server.EndUser(this);
                        return;
                    }
                    if (currentCommand.Contains("sock"))
                    {
                        Server.EndUser2(this);
                        return;
                    }
                    if (currentCommand.Contains("sendfileto"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string TargetName = Arguments[1];
                        int FileSize = int.Parse(Arguments[2]);
                        string FileName = Arguments[3];
                        byte[] fileBuffer = new byte[FileSize];
                        _userHandle.Receive(fileBuffer);
                        User targetUser = Server.GetUser(TargetName);
                        
                        if (targetUser == null)
                        {
                            SendMessage($"Пользователь {targetUser} не найден!");
                            continue;
                        }
                        Server.FileD newFile = new Server.FileD()
                        {
                            ID = Server.Files.Count + 1,
                            FileName = FileName,
                            From = Username,
                            fileBuffer = fileBuffer,
                            FileSize = fileBuffer.Length
                        };
                        Server.Files.Add(newFile);
                        sendToBD(TargetName,FileName);
                        targetUser.SendFile(newFile, targetUser);
                    }
                    if (currentCommand.Contains("read"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string TargetName = Arguments[1];
                        
                        User targetUser = Server.GetUser(TargetName);

                        MessengerEntities4 bds = new MessengerEntities4();

                        Users iam = new Users();
                        Users b = new Users();
                        Messages mes = new Messages();
                        Content con = new Content();

                        iam = bds.Users.FirstOrDefault(us => us.name == Username);
                        b = bds.Users.FirstOrDefault(us => us.name == TargetName);//проверка на наличие схожих имен в БД 

                        foreach (Messages message in bds.Messages)
                        {
                            if (message.from_id == iam.id && message.to_id == b.id)
                            {

                                foreach (Content cont in bds.Content)
                                {
                                    if (message.content_id == cont.id)
                                    { 
                                        if (cont.content1.Contains(".jpg") || cont.content1.Contains(".png") || cont.content1.Contains(".bmp") || cont.content1.Contains(".ico"))
                                        {
                                            SendMessage($"{cont.content1}|-[to][{TargetName}]:");
                                        }
                                        else
                                        {
                                            SendMessage($"-[to][{TargetName}]: {cont.content1}" + " (" + message.create_at + ")");
                                        }
                                    }
                                   

                                }
                            }
                            if (message.from_id == b.id && message.to_id == iam.id)
                            {
                                foreach (Content cont in bds.Content)
                                {
                                    if (message.content_id == cont.id)
                                    {

                                        if (cont.content1.Contains(".jpg") || cont.content1.Contains(".png") || cont.content1.Contains(".bmp") || cont.content1.Contains(".ico"))
                                        {
                                            //Console.WriteLine(cont.content1);
                                            SendMessage($"{cont.content1}|-[from][{TargetName}]:");
                                        }
                                        else
                                        {
                                            SendMessage($"-[from][{TargetName}]: {cont.content1}" + " (" + message.create_at + ")");
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                    if (currentCommand.Contains("private"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string TargetName = Arguments[1];
                        string ContentMsg = Arguments[2];


                        User targetUser = Server.GetUser(TargetName);
                        
                        DateTime Time = DateTime.Now;
                        sendToBD(TargetName, ContentMsg);
                       
                        if (targetUser == null)
                        {
                            SendMessage($"Пользователь {TargetName} не найден!");
                            continue;
                        }
                        SendMessage($"-[to][{TargetName}]: {ContentMsg}" + " (" + Time + ")");
                        targetUser.SendMessage($"-[from][{Username}]: {ContentMsg}" + " (" + Time + ")");
                        continue;
                    }
                    if (currentCommand.Contains("letsmeet"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];

                        User targetUser = Server.GetUser(second);

                        targetUser.Send($"#howaboutmeet|{first}|{second}");
                    }

                    if (currentCommand.Contains("agree"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];

                        User targetUser = Server.GetUser(first);

                        targetUser.Send($"#okay|{first}|{second}");
                    }

                    if (currentCommand.Contains("notagre"))
                    {
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];
                        User targetUser = Server.GetUser(first);
                        targetUser.Send($"#nope|{first}|{second}");

                    }

                    if (currentCommand.Contains("ycan"))
                    {
                        //Console.WriteLine("Зашло в ycan ");
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[1];
                        string second = Arguments[2];

                        User targetUser = Server.GetUser(second);
                        targetUser.Send($"#choice");

                    }

                    if (currentCommand.Contains("dates"))
                    {
                        //Console.WriteLine("Зашло в dates ");
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[2];
                        string second = Arguments[3];
                        string SecondDates;
                        SecondDates = "";
                        SecondDates = Arguments[1];
                        User targetUser = Server.GetUser(first);
                        if (targetUser == null)
                        {
                            SendMessage($"Пользователь {first} не найден!");
                            continue;
                        }

                        targetUser.Send($"SecDat|{SecondDates}|{first}|{second}");
                        //SecondDates = "";
                        continue;

                    }

                    if (currentCommand.Contains("endofmeet"))
                    {
                        //Console.WriteLine("Зашло в endofmeet");
                        string[] Arguments = currentCommand.Split('|');
                        string first = Arguments[2];
                        string second = Arguments[3];
                        User TargetUser1 = Server.GetUser(first);
                        User TargetUser2 = Server.GetUser(second);
                        string enddates;
                       // Console.WriteLine(Arguments[1]);
                        if (Arguments[1] != "")
                        {
                            enddates = Arguments[1];
                            TargetUser1.Send($"theend|{enddates}");
                            TargetUser2.Send($"theend|{enddates}");
                        }
                        else
                        {
                            TargetUser1.Send($"noresults");
                            TargetUser2.Send($"noresults");

                        }

                    }
                }

            }
            catch (Exception exp) { Console.WriteLine("Error with handleCommand: " + exp.Message); }
        }




        public void SendFile(Server.FileD fd, User To)
        {
            byte[] answerBuffer = new byte[48];
            Console.WriteLine($"Sending {fd.FileName} from {fd.From} to {To.Username}");
            To.Send($"#gfile|{fd.FileName}|{fd.From}|{fd.fileBuffer.Length}|{fd.ID}");
        }

        public void SendGlob(string content)
        {
            Send($"#glchat|{content}");
        }

        public void SendMessage(string content)
        {
            Send($"#msg|{content}");
        }

        public void Send(byte[] buffer)
        {
            try
            {
                _userHandle.Send(buffer);
            }
            catch { }
        }


        public void Send(string Buffer)
        {
            try
            {
                _userHandle.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }


        public void End()
        {
            try
            {
                _userHandle.Close();
            }
            catch { }

        }
    }
}
