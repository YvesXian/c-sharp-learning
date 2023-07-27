using System;

namespace Delegate_01
{
    class Program
    {
        delegate string Dgate(string str);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();

            /* 2. 建立委派*/
            Dgate DelFunc;

            /* 3. 宣告委派型別的變數*/
            DelFunc = program.HiMary;
            /* 4. 將函式設定給委派變數*/
            Console.WriteLine(DelFunc("Mary"));

            DelFunc = program.HiJohn;
            Console.WriteLine(DelFunc("John"));

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string HiMary(string str)
        {
            return "Hello, 早安，" + str + "\r\n";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string HiJohn(string str)
        {
            return "Hello, 午安，" + str + "\r\n";
        }
    }
}
