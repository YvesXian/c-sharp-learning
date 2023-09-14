using System;

namespace ClassAndObject_09
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Options Number: 1.一般情形 2.明確介面");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    MyClass1 my1 = new MyClass1();
                    IfaceA fa1 = my1;
                    IfaceB fb1 = my1;

                    Console.WriteLine(fa1.ShowInfo());
                    Console.WriteLine(fb1.ShowInfo());
                    break;
                case "2":
                    MyClass2 my2 = new MyClass2();
                    IfaceA fa2 = my2;
                    IfaceB fb2 = my2;

                    Console.WriteLine(fa2.ShowInfo());
                    Console.WriteLine(fb2.ShowInfo());
                    break;
            }

            Console.ReadKey();
        }
    }

    interface IfaceA
    {
        string ShowInfo();
    }

    interface IfaceB
    {
        string ShowInfo();
    }

    class MyClass1 : IfaceA, IfaceB
    {
        public string ShowInfo()
        {
            return "ShowInfo";
        }
    }

    class MyClass2 : IfaceA, IfaceB
    {
        string IfaceA.ShowInfo()
        {
            return "ShowInfo for IfaceA";
        }

        string IfaceB.ShowInfo()
        {
            return "ShowInfo for IfaceB";
        }
    }
}
