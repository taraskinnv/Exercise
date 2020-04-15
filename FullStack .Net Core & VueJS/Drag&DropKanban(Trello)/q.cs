Skip to content
Search or jump to…

Pull requests
Issues
Marketplace
Explore
 
@taraskinnv 
AlexAgoshkov
/
TcpChat
1
00
 Code Issues 0 Pull requests 0 Actions Projects 0 Wiki Security Insights
TcpChat/ServerNetFrame/ConsoleApp1/Program.cs
@AlexAgoshkov AlexAgoshkov Client and Server
c268f61 20 days ago
141 lines (121 sloc)  4.16 KB
  
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static string Read(List<User> clients)
        {
            string result = "";

            var bytes = new byte[256];

            foreach (var item in clients)
            {
                NetworkStream network = item.Client.GetStream();
                if (network.DataAvailable)
                {
                    var bytesReadCount = network.Read(bytes, 0, bytes.Length);
                    result = item.Name + ": ";
                    result += Encoding.ASCII.GetString(bytes, 0, bytesReadCount);

                    if (IsDisconnect(result))
                    {
                        item.Client.Close();
                        network.Close();
                        clients.Remove(item);
                        result = "";
                    }

                    network.Flush();
                    break;
                }
            }

            return result;
        }

        public static void Send(List<User> clients, string mess)
        {
            Console.WriteLine(mess);
            foreach (var item in clients)
            {
                if (!mess.StartsWith(item.Name))
                {
                    NetworkStream network = item.Client.GetStream();
                    var response = Encoding.ASCII.GetBytes(mess);
                    network.Write(response, 0, response.Length);
                }
            }
        }

        public static bool IsExsitUser(List<User> users, User user)
        {
            bool result = false;

            foreach (var item in users)
            {
                if (user.Name == item.Name)
                {
                    result = true;
                }
            }

            return result;
        }

        public static bool IsDisconnect(string message)
        {
            bool result = false;

            if (message.EndsWith(".quit"))
            {
                result = true;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Server");
            List<User> users = new List<User>();
            try
            {
                var port = 19539;
                var localAddr = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(localAddr, port);
                server.Start();
                var bytes = new byte[256];

                while (true)
                {
                    if (server.Pending())
                    {
                        Console.WriteLine("waiting for connection");

                        var client = server.AcceptTcpClient();
                        NetworkStream stream = client.GetStream();
                        Console.WriteLine($"Accepted connection from {client.Client.RemoteEndPoint}");

                        var bytesReadCount = stream.Read(bytes, 0, bytes.Length);
                        string name = Encoding.ASCII.GetString(bytes, 0, bytesReadCount);
                        stream.Flush();
                        var user = new User() { Client = client, Name = name };

                        if (IsExsitUser(users, user))
                        {
                            byte[] respon = Encoding.ASCII.GetBytes("Incorrect nickname");
                            stream.Write(respon, 0, respon.Length);
                            client.Close();
                            stream.Close();
                        }
                        else
                        {
                            users.Add(user);
                        }
                       
                        Console.WriteLine(users.Count);
                    }

                    string data = Read(users);
                    if (!string.IsNullOrWhiteSpace(data))
                    {
                        Send(users, data);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception {e}");
            }
        }
    }
}
