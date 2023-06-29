using System;
using System.Threading;
using System.Diagnostics;

namespace Thread_01
{
    class Program
    {
        bool fgDone;
        Int32 sum;
        int guess;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program program = new Program();
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Please Enter Options Number: 1.Non Tread 2.Tread 3.Parameters Thread");
            string option = Console.ReadLine();

            sw.Reset();
            sw.Start();
            switch (option)
            {
                case "1":
                    Console.WriteLine("開始計算\r\n");
                    program.sum = 0;
                    while (program.sum < int.MaxValue)
                        program.sum++;
                    
                    sw.Stop();
                    TimeSpan elapsedTime = sw.Elapsed;

                    Console.WriteLine("計算完畢, sum = " + program.sum.ToString() + "\r\n");
                    Console.WriteLine("耗時: " + elapsedTime.ToString("fff") + "ms");
                    break;
                case "2":
                    ThreadStart thdStart = new ThreadStart(program.count);
                    Thread thd = new Thread(thdStart);

                    program.sum = 0;
                    program.fgDone = false;
                    Console.WriteLine("執行緒開始執行");
                    thd.Start();
                    while (!program.fgDone)
                    {
                        Console.WriteLine("...");
                    }

                    sw.Stop();
                    elapsedTime = sw.Elapsed;
                    Console.WriteLine("耗時: " + elapsedTime.ToString("fff") + "ms");
                    break;
                case "3":
                    /*
                     * 使用 thread 的關係, 所以量測出來的時間會很不準
                     */
                    int num = 78;
                    ParameterizedThreadStart paramStart =
                        new ParameterizedThreadStart(program.count_para);
                    Thread paramThd = new Thread(paramStart);

                    program.fgDone = false;
                    program.guess = -1;
                    paramThd.Start(num);

                    while (!program.fgDone)
                    {
                        Thread.Sleep(100);
                        Console.WriteLine(program.guess.ToString());
                    }
                    sw.Stop();
                    elapsedTime = sw.Elapsed;

                    Console.WriteLine("找到了");
                    Console.WriteLine("耗時: " + elapsedTime.ToString("fff") + "ms");
                    break;
                default:
                    Console.WriteLine("No has Option !");
                    break;
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 執行 int 型別的數值累加
        /// </summary>
        void count()
        {
            while (sum < int.MaxValue)
                sum++;

            fgDone = true;
            
            Console.WriteLine("計算完畢, sum = " + sum.ToString() + "\r\n");
        }

        /// <summary>
        /// 猜變數 num 數字
        /// </summary>
        /// <param name="num"></param>
        void count_para(object num)
        {
            Random rd = new Random();

            while (guess != (int)num)
            {
                guess = rd.Next(1, 101);
                Thread.Sleep(100);
            }

            fgDone = true;
        }
    }
}
