using System;

/* 建立多型之類別成員*/
namespace ClassAndObject_07
{
    class Program
    {
        static void Main(string[] args)
        {
            Parent pt = new Parent();
            Child cd = new Child();

            Console.WriteLine("1.normal 2.polymorphism");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    pt.name = "parent類別";
                    Console.WriteLine(pt.ShowName());
                    cd.name = "child類別";
                    Console.WriteLine(cd.ShowName());
                    break;
                case "2":
                    Parent ptcd = new Child();
                    ptcd.name = "parent類別";
                    Console.WriteLine(ptcd.ShowName());
                    break;
                default:
                    Console.WriteLine("No has Option !");
                    break;
            }

            Console.ReadKey();
        }
    }

    public class Parent
    {
        public string name { get; set; }

        public virtual string ShowName()
        {
            return "From Parent: " + name;
        }
    }

    public class Child : Parent
    {
        public override string ShowName()
        {
            return "Form Child: " + name;
        }
    }
}
