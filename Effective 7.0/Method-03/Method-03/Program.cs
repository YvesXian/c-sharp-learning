using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Address a1 = new Address();
            /* 通常 Address 中會把 City, State, ZipCode 當作一組資料*/
            a1.Line1 = "111 S. Main";
            a1.City = "Anytown";
            a1.State = "IL";
            a1.ZipCode = 61111;
            Console.WriteLine("第一次設定完成以後, City or State 會對的起來");
            Console.WriteLine("Line1: " + a1.Line1 + " " + "City: " + a1.City + " " +
                "State: " + a1.State + " " + "ZipCode: " + a1.ZipCode.ToString() + "\r\n");

            /* 執行到此只有替換 City, ZipCode 與 State 沒有更新*/
            a1.City = "Ann Arbor";
            Console.WriteLine("如果只有替換 City 的話, 各個資料會對不起來");
            Console.WriteLine("City 更新了, 但 ZipCode 與 State 還沒有更新");
            Console.WriteLine("Line1: " + a1.Line1 + " " + "City: " + a1.City + " " +
                "State: " + a1.State + " " + "ZipCode: " + a1.ZipCode.ToString() + "\r\n");
            
            /* 剩 State 沒有更新*/
            a1.ZipCode = 48013;
            Console.WriteLine("City 與 ZipCode 更新了, 但 State 還沒有更新");
            Console.WriteLine("Line1: " + a1.Line1 + " " + "City: " + a1.City + " " +
                "State: " + a1.State + " " + "ZipCode: " + a1.ZipCode.ToString() + "\r\n");

            /* 全部更新*/
            a1.State = "MI";
            Console.WriteLine("全部更新完成！");
            Console.WriteLine("Line1: " + a1.Line1 + " " + "City: " + a1.City + " " +
                "State: " + a1.State + " " + "ZipCode: " + a1.ZipCode.ToString() + "\r\n");

            Console.ReadKey();
        }

        public struct Address
        {
            private string state;
            private int zipCode;
            public string Line1 { get; set; }
            public string Line2 { get; set; }
            public string City { get; set; }
            public string State
            {
                get => state;
                set 
                {
                    /* Validate State */
                    state = value;
                }
            }
            public int ZipCode
            {
                get => zipCode;
                set
                {
                    /* Validate ZipCode */
                    zipCode = value;
                }
            }
        }
    }
}
