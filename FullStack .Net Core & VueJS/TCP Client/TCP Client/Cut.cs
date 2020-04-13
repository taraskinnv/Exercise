using System;
using System.Collections.Generic;
using System.Text;

namespace TCP_Client
{
    public static class Cut
    {
        public static String CutHeders(string message)
        {
            int startIndexOf = message.IndexOf("<html");
            //message = message.Remove(0, startIndexOf);
            int finishIndexOf = message.LastIndexOf("</html>");// + "</html>".Length;
            //message = message.Remove(finishIndexOf);


            return message.Substring(startIndexOf, finishIndexOf - startIndexOf + "</html>".Length);
        }
    }
}
