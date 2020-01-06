using System;

namespace Exercise_3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
            MyStruct myStruct = new MyStruct();

            myClass.change = "не изменено";
            myStruct.change = "не изменено";
            


            ClassTaker(myClass);
            StructTaker(myStruct);

            Console.WriteLine(myClass.change);
            Console.WriteLine(myStruct.change);

            /*
             при передачи в class передается ссылка на объект, а struct передается копия значения
             */
        }

        public static void ClassTaker(MyClass myClass)
        {
            myClass.change = "изменено";
        }

        public static void StructTaker(MyStruct myStruct)
        {
            myStruct.change = "изменено";
        }
    }

    public class MyClass
    {
        public string change;
    }

    struct MyStruct
    {
        public string change;
    }
}
