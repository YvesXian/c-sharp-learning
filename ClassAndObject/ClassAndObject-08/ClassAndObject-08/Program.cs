using System;

namespace ClassAndObject_08
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            float price;
            string name;

            Console.Write("Please input price: ");
            input = Console.ReadLine();
            price = float.Parse(input);

            Console.Write("Please input object name: ");
            input = Console.ReadLine();
            name = input;

            Items usb = new Items(price, name);
            Console.Write("Please input object number: ");
            input = Console.ReadLine();
            usb.number = int.Parse(input);

            Console.WriteLine("Total: " + usb.GetAmount() + "$");

            Console.ReadKey();
        }
    }

    interface Iface
    {
        float price { get; set; }
        int number { get; set; }
        string name { get; }

        float GetAmount();
    }

    class Items : Iface
    {
        public float price { get; set; }
        public int number { get; set; }
        public string name { get; }

        public Items(float p = 0, string str = "")
        {
            this.price = p;
            this.name = str;
            this.number = 0;
        }

        public float GetAmount()
        {
            return this.price * this.number;
        }
    }
}
