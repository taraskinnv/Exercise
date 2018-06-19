using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ChatClient
{
    class Program
    {
        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 2222;
        static TcpClient client;
        static NetworkStream stream;
        static ConsoleColor name;
        static ConsoleColor message_color;
        enum Color1 { Black, Red }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя");
            userName = Console.ReadLine();
            client = new TcpClient();
            name = Color();
            message_color = Color();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();

                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                Thread thread = new Thread(new ThreadStart(ReceiveMessage));
                thread.Start();
                Console.WriteLine($"Привет, {userName}");
                SendMessage();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Disconnect();
            }
            
        }

        private static void Disconnect()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();

            Environment.Exit(0);
        }

        private static void SendMessage()
        {
            Console.WriteLine("Введите сообщение");
            while (true)
            {
                Console.ForegroundColor = name;
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }

        private static void ReceiveMessage()
        {
            while(true)
            {
                try
                {
                    byte[] data = new byte[64];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    } while (stream.DataAvailable);

                    string message = builder.ToString();
                    int i = message.IndexOf(':');
                    Console.ForegroundColor = name;
                    Console.Write(message.Substring(0,i));
                    Console.ForegroundColor = message_color;
                    Console.WriteLine(message.Substring(i+1,message.Length));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Подключение прервано!");
                    Console.Read();
                    Disconnect();
                }
            }
        }

        private static ConsoleColor Color()
        {
            ConsoleColor a;
            Console.WriteLine("Color");
           int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    a = ConsoleColor.Red;
                    break;
                case 2:
                    a = ConsoleColor.Yellow;
                    break;
                default:
                    a = ConsoleColor.White;
                    break;
            }
            return a;
        }
    }
}
