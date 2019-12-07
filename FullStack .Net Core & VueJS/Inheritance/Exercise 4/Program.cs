using System;

namespace Exercise_4
{
    class Program
    {
        private const String exp = "exp";
        private const String pro = "pro";
        static void Main(string[] args)
        {
            DocumentWorker documentWorker;
            do
            {
                Console.Write("Введите ключ: ");
                String key = Console.ReadLine();

                switch (key)
                {
                    case exp:
                        documentWorker = new ExpertDocumentWorker();
                        break;
                    case pro:
                        documentWorker = new ProDocumentWorker();
                        break;
                    default:
                        documentWorker = new DocumentWorker();
                        break;
                }

                Boolean b = true;
                Console.WriteLine("1 - Open Document");
                Console.WriteLine("2 - Edit Document");
                Console.WriteLine("3 - Save Document");
                Console.WriteLine("4 - Exit");
                do
                {
                    Int32 res = 0;
                    try
                    {
                        res = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }

                    switch (res)
                    {
                        case 1:
                            documentWorker.OpenDocument();
                            break;
                        case 2:
                            documentWorker.EditDocument();
                            break;
                        case 3:
                            documentWorker.SaveDocument();
                            break;
                        default:
                            b = false;
                            break;

                    }
                } while (b);


            } while (true);
        }
    }
}
