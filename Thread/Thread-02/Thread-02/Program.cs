using System;
using System.Threading;

namespace Thread_02
{
    class Program
    {
        Int32 sum;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Please Enter Options Number: 1.Global Parameter 2.Reference Parameter");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Thread thd = new Thread(program.count);

                    program.sum = 0;
                    Console.WriteLine("執行緒開始執行...");

                    thd.Start();
                    Console.WriteLine("使用 Join() 方法，所以必須等待執行緒執行結束...");
                    thd.Join();
                    Console.WriteLine("sum = " + program.sum.ToString());
                    break;
                case "2":
                    Thread thread = new Thread(program.count_param);
                    Int32[] sum1 = { 0 };

                    Console.WriteLine("執行緒開始執行...");
                    thread.Start(sum1);
                    Console.WriteLine("使用 Join() 方法，所以必須等待執行緒結束...");
                    thread.Join();
                    Console.WriteLine("sum1 = " + sum1[0].ToString());
                    break;
                default:
                    Console.WriteLine("No has Option !");
                    break;
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 提供一個無參數的 func，此 func 會一直累加到 int 的最大值
        /// </summary>
        void count()
        {
            while (sum < int.MaxValue)
                sum++;
        }

        /// <summary>
        /// 某些變數型態若被當成參數傳遞時，自動以參考呼叫的方式處理。 例如: 陣列、類別、物件等
        /// </summary>
        /// <param name="param"></param>
        void count_param(object param)
        {
            Int32[] pp = (Int32[])param;

            while (pp[0] < int.MaxValue)
                pp[0]++;
        }
    }
}
