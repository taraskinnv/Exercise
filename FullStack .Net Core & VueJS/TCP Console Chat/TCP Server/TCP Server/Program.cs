using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

//using  UserLibrary;

namespace TCP_Server
{
    class Program
    {

        static List<User> users = new List<User>();
        static void Main(string[] args)
        {
            Console.WriteLine("simple server");

            try
            {
                var port = 13000;
                var localAddress = IPAddress.Parse("127.0.0.1");
                var server = new TcpListener(localAddress, port);
                server.Start();
                String message = String.Empty;
                NetworkStream stream;

                while (true)
                {
                    if (server.Pending())
                    {

                        Console.WriteLine("waiting to connection");
                        var client = server.AcceptTcpClient();
                        Console.WriteLine($"Accepted connection from {client.Client.RemoteEndPoint}");

                        stream = client.GetStream();

                        if (!IsClient(client)) //проверка есть ли user в чате
                        {

                            String name = ReadNetworkStream(stream);
                            if (!IsName(name)) //если имя не совпадает, то user заходит в чат
                            {
                                User u = new User() {Name = name, Client = client};
                                users.Add(u);
                                var data = System.Text.Encoding.ASCII.GetBytes(name);
                                stream.Write(data, 0, data.Length);
                                stream.Flush();
                                WriteAll(client, $"{name} enters the chat");
                            }
                            else
                            {
                                var data = System.Text.Encoding.ASCII.GetBytes("This name used");
                                stream.Write(data, 0, data.Length);
                                stream.Flush();
                            }
                        }
                    }

                    foreach (var user1 in users)
                    {
                        NetworkStream ns = user1.Client.GetStream();
                        if (ns.DataAvailable)
                        {
                            ns = user1.Client.GetStream();
                            message = ReadNetworkStream(ns);
                            if (message == ".quit")
                            {

                                var u = users.FirstOrDefault(user => user.Client == user1.Client);
                                WriteAll(user1.Client, $"{u.Name} quit");
                                users.Remove(u);
                                ns.Close();
                                user1.Client.Close();

                                break;
                            }
                            else
                            {
                                var user = users.FirstOrDefault(user => user.Client == user1.Client);
                                WriteAll(user1.Client, $"{user.Name}: {message}");
                            }
                        }
                    }
                    Thread.Sleep(500);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static bool IsClient(TcpClient client)
        {
            foreach (var user in users)
            {
                if (user.Client == client)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsName(String name)
        {
            foreach (var user in users)
            {
                if (user.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public static string ReadNetworkStream(NetworkStream stream) //чтение сообщения из потока
        {
            var responseData = new byte[1];
            StringBuilder response = new StringBuilder();
            String responseMessage = String.Empty;
            do
            {
                int butesRead = stream.Read(responseData, 0, responseData.Length);
                response.Append(System.Text.Encoding.ASCII.GetString(responseData, 0, responseData.Length));
            } while (stream.DataAvailable);

            return response.ToString();
        }

        public static void WriteAll(TcpClient client, String message) //Отправка всем сообщения
        {
            var data = System.Text.Encoding.ASCII.GetBytes(message);

            foreach (var user in users)
            {
                if (client != user.Client)
                {
                    NetworkStream stream = user.Client.GetStream();
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }
        }





    }
}
