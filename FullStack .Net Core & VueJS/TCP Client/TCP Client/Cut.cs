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
            int finishIndexOf = message.LastIndexOf("</html>");
            return message.Substring(startIndexOf, finishIndexOf - startIndexOf + "</html>".Length);
        }

        public static String CutHeders(StringBuilder message)
        {
            String str = message.ToString();

            int startIndexOf = str.IndexOf("<html");
            int finishIndexOf = str.LastIndexOf("</html>");
            return str.Substring(startIndexOf, finishIndexOf - startIndexOf + "</html>".Length);
        }
    }
}
