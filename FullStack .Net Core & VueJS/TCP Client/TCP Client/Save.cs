using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCP_Client
{
    public static class Save
    {
        public static void SaveFile(String message)
        {
            using (FileStream fstream = new FileStream($"{Directory.GetCurrentDirectory()}\\output.html", FileMode.Create))
            {
                var dataBytes = System.Text.Encoding.ASCII.GetBytes(message);

                fstream.Write(dataBytes, 0, dataBytes.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }

        public static void SaveFile(StringBuilder message)
        {
            using (FileStream fstream = new FileStream($"{Directory.GetCurrentDirectory()}\\output.html", FileMode.Create))
            {
                var dataBytes = System.Text.Encoding.Unicode.GetBytes(message.ToString());

                fstream.Write(dataBytes, 0, dataBytes.Length);
                Console.WriteLine("Текст записан в файл");
            }
        }
    }
}
