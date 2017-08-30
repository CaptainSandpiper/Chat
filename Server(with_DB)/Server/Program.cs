using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{

    class Program
    {
        static List<Messages> oz { get; set; }
        static List<Content> oz2 { get; set; }
        static void Bdclear()
        {

            MessengerEntities4 bds = new MessengerEntities4();
            foreach (Messages message in bds.Messages)
            {

                oz = bds.Messages.ToList();
                var idi = oz.Where(n => n.create_at.Value.Month == (DateTime.Now.Month-1)).Select(n => n.id).ToList();
                                
                    
                int col = 0;
                foreach (var i in idi)
                {
                    var idi2 = bds.Messages.Find(int.Parse(idi[col].ToString()));
                   
                    bds.Messages.Remove(idi2);
                
                    oz2 = bds.Content.ToList();
                    var idi3 = oz2.Where(n => n.id == idi2.id).Select(n => n.id).ToList();
                    var idi4 = bds.Content.Find(int.Parse(idi[col].ToString()));
                    bds.Content.Remove(idi4);
                        
                
                    col++;
                    
                }


            }
            bds.SaveChanges();
        }
        
        static void Main(string[] args)
        {
            IPAddress address = IPAddress.Parse(Server.Host);
            Server.ServerSocket = new Socket(address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Server.ServerSocket.Bind(new IPEndPoint(address, Server.Port));
            Server.ServerSocket.Listen(100);
            Console.WriteLine($"Server has been started on {Server.Host}:{Server.Port}");
            Console.WriteLine("Waiting connections...");
           Bdclear();
            while (Server.Work)
            {
                Socket handle = Server.ServerSocket.Accept();
               // Console.WriteLine($"New connection: {handle.RemoteEndPoint.ToString()}");
                new User(handle);

            }
            Console.WriteLine("Server is disabled...");

        }

    }
}
