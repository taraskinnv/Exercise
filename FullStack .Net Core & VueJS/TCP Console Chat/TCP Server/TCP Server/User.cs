using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace TCP_Server
{
    public class User
    {
        public String Name { get; set; }
        public TcpClient Client { get; set; }
    }
}
