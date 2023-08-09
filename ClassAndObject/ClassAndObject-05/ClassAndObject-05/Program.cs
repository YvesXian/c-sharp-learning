using System;

/// <summary>
/// 建立類別繼承
/// </summary>
namespace ClassAndObject_05
{
    class Program
    {
        static void Main(string[] args)
        {
            classB myB = new classB();

            myB.b1 = 10;
            Console.WriteLine("classB.b1 = " + myB.b1);
            Console.WriteLine("classB.a1 = " + myB.a1);
            Console.WriteLine(myB.ShowMsg());
        }
    }

    /// <summary>
    /// classA 為父類別
    /// </summary>
    class classA
    {
        public int a1 { get; set; }
        private int a2;
        protected int a3 { get; set; }
        public static int a4 { get; set; }

        public classA()
        {
            a1 = 5;
        }

        public string ShowMsg()
        {
            return "來自classA";
        }
    }

    /// <summary>
    /// classB 為子類別
    /// </summary>
    class classB : classA
    {
        public int b1 { get; set; }
    }
}
