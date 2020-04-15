using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;


namespace TCPClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("tcp client started");
                var port = 13000;
                Console.Write("Your server Address: ");
                String serverAddress = Console.ReadLine();
                var client = new TcpClient(serverAddress, port);
                NetworkStream stream = client.GetStream();

                Console.Write("Your name: ");

                var name = Console.ReadLine();

                var dataReg = Encoding.ASCII.GetBytes(name);

                stream.Write(dataReg, 0, dataReg.Length);
                stream.Flush();

                String response;
                while (true)
                {
                    if (stream.DataAvailable)
                    {
                        response = ReadNetworkStream(client.GetStream());
                        break;
                    }
                }

                if (response == name)
                {
                    while (true)
                    {
                        if (Console.KeyAvailable)
                        {
                            string mes = Console.ReadLine();
                            var data = Encoding.ASCII.GetBytes(mes);
                            stream.Write(data, 0, data.Length);
                            stream.Flush();
                            if (mes == ".quit")
                            {
                                break;
                            }
                        }
                        if (stream.DataAvailable)
                        {
                            Console.WriteLine(ReadNetworkStream(stream));
                        }
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    Console.WriteLine(response);
                }

                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
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
    }
}
