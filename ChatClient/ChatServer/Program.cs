﻿using System;
using System.Threading;

namespace ChatServer
{
    class Program
    {
        static ServerObject server;
        static Thread listenThread;
        static void Main(string[] args)
        {
            try
            {
                server = new ServerObject();
                listenThread = new Thread(new ThreadStart(server.Listen));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                server.Disconect();
            }
        }
    }
}
