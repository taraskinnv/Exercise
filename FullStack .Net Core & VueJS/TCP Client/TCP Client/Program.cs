using System;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите адрес http веб-страницы: ");
            String mes = Console.ReadLine();
            mes = GetDomein(mes);
            Console.WriteLine("tcp client started");
            var message = $"GET / HTTP/1.0\nHost: {mes}\n\n";
            try
            {
                var port = 80;
                var serverAddress = mes;
                var client = new TcpClient(serverAddress, port);
                var data = System.Text.Encoding.ASCII.GetBytes(message);
                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);
                stream.Flush();
                Console.WriteLine($"Sent {message}");

                var responseData = new byte[256];
                //StringBuilder response = new StringBuilder();
                String responseMessage = String.Empty;
                do
                {
                    int butesRead = stream.Read(responseData, 0, responseData.Length);
                    responseMessage += System.Text.Encoding.ASCII.GetString(responseData, 0, responseData.Length);
                    //response.Append(System.Text.Encoding.ASCII.GetString(responseData, 0, responseData.Length));
                } while (stream.DataAvailable);



                //Console.WriteLine($"Received {response}");
                stream.Close();
                client.Close();
                responseMessage = Cut.CutHeders(responseMessage);
                SaveFile.Save(responseMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                throw;
            }
        }

        public static String GetDomein(String mes)
        {
            mes = mes.Trim();
            string[] array = mes.Split(new Char[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            if (array[0] == "http:")
            {
                return array[1];
            }
            return array[0];
        }
    }


}
