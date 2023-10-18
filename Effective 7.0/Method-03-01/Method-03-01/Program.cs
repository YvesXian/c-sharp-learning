using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_03_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Address a1 = new Address("222 S. Main", "", "Anytown", "IL", 62222);

            /* 建立一個 address: */
            Address a2 = new Address("111 S. Main", "", "Anytown", "IL", 61111);
            Console.WriteLine("建立一個 address");
            Console.WriteLine("Line1: " + a2.Line1 + " " + "City: " + a2.City + " " +
                "State: " + a2.State + " " + "ZipCode: " + a2.ZipCode.ToString() + "\r\n");

            /* address 更改, 重新初始化: */
            a2 = new Address(a1.Line1,
                a1.Line2, "Ann Arbor", "MI", 48103);
            Console.WriteLine("修改 address");
            Console.WriteLine("Line1: " + a2.Line1 + " " + "City: " + a2.City + " " +
                "State: " + a2.State + " " + "ZipCode: " + a2.ZipCode.ToString() + "\r\n");

            Console.ReadKey();
        }

        /* 
         * 這些屬性都是只讀的，這意味著它們的值在結構創建後不能被修改。
         * 這是因為在結構的建構函數中，這些屬性的值被初始化，之後不再改變。
         */
        public struct Address
        {
            public string Line1 { get; }
            public string Line2 { get; }
            public string City { get; }
            public string State { get; }
            public int ZipCode { get; }

            public Address(string line1,
                string line2,
                string city,
                string state,
                int zipcode) :
                this()
            {
                Line1 = line1;
                Line2 = line2;
                City = city;
                State = state;
                ZipCode = zipcode;
            }
        }
    }
}
