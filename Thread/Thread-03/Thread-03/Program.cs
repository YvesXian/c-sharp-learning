using System;
using System.Threading;

namespace Thread_03
{
    class Program
    {
        bool fgDone_a, fgDone_b;
        int guess_a, guess_b;
        Thread th_a = null;
        bool fgRun;
        int num_a = 78, num_b = 50;

        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("Please Enter Options Number: 1.Thread1 2.Abort 3.Interrupt 4.Thread2 5.Global Variable");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Thread thd = new Thread(program.count_a);

                    program.th_a = thd;
                    program.fgDone_a = false;
                    program.guess_a = -1;
                    thd.Start();
                    break;
                case "2":
                    Console.WriteLine("使用 Abort() 中止執行緒");
                    program.th_a.Abort();
                    break;
                case "3":
                    Console.WriteLine("使用 Interrupt() 中斷執行緒");
                    program.th_a.Interrupt();
                    break;
                case "4":
                    Thread thd_b = new Thread(program.count_b);

                    program.fgDone_b = false;
                    program.guess_b = -1;
                    program.fgRun = true;
                    thd_b.Start();
                    break;
                case "5":
                    program.fgRun = false;
                    break;
                default:
                    Console.WriteLine("No has Option !");
                    break;
            }

            Console.CancelKeyPress += (sender, e) =>
            {
                Console.WriteLine("應用程式關閉中...");
                if (program.th_a != null)
                    program.th_a.Abort();

                program.fgRun = false;
            };

            Console.ReadKey();
        }

        /// <summary>
        /// 
        /// </summary>
        void count_a()
        {
            Random rd = new Random();
            try
            {
                while (guess_a != num_a)
                {
                    guess_a = rd.Next(1, 101);
                    Thread.Sleep(100);

                    Console.WriteLine(guess_a.ToString());
                }

                fgDone_a = true;
                Console.WriteLine("找到了");
            }
            catch (ThreadAbortException ex)
            {
                Console.WriteLine("exception message: " + ex.ToString());
            }
            catch (ThreadInterruptedException ex)
            {
                Console.WriteLine("exception message: " + ex.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void count_b()
        {
            Random rd = new Random();

            while (guess_b != num_b && fgRun)
            {
                guess_b = rd.Next(1, 101);
                Thread.Sleep(100);

                Console.WriteLine(guess_b.ToString());

            }

            fgDone_b = true;
            if (!fgRun)
                Console.WriteLine("結束執行緒");
            else
                Console.WriteLine("找到了");
        }
    }
}
