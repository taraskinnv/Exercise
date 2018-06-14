using System;
using System.Net.Sockets;
using System.Text;

namespace ChatServer
{
    public class ClientObject
    {
        protected internal string Id { get; private set; }
        protected internal NetworkStream stream { get; private set; }
        string userName;
        TcpClient client;
        ServerObject server;

        public ClientObject(TcpClient client, ServerObject serverObject)
        {
            Id = Guid.NewGuid().ToString();
            this.client = client;
            server = serverObject;
            serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                stream = client.GetStream();
                string message = GetMessage();
                userName = message;

                message = userName + " вошел в чат";

                server.BroadcastMessage(message, this.Id);
                Console.WriteLine(message);

                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = String.Format("{0}: {1}", userName, message);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        message = String.Format("{0}: покинул нас =(", userName);
                        Console.WriteLine(message);
                        server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                server.RemoveConnection(this.Id);
                Close();
            }
        }

        private string GetMessage()
        {
            byte[] data = new byte[64];
            StringBuilder builder = new StringBuilder();
            int bytes = 0;

            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
            } while (stream.DataAvailable);

            return builder.ToString();
        }

        protected internal void Close()
        {
            if (stream != null)
                stream.Close();
            if (client != null)
                client.Close();
        }
    }
}
