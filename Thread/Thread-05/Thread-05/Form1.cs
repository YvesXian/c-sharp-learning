using System;
using System.Windows.Forms;
using System.Threading;

/// <summary>
/// 使用 lock 實現 threads 互斥鎖的功能
/// </summary>
namespace Thread_05
{
    public partial class Form1 : Form
    {
        Thread thd1 = null, thd2 = null;
        object locker = new object();
        bool fg1 = false, fg2 = false;

        /// <summary>
        /// 如果表單關閉, 使用 Abort() 關閉執行緒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (thd1 != null)
                thd1.Abort();

            if (thd2 != null)
                thd2.Abort();
        }

        /// <summary>
        /// 程式啟動時, thd1 與 thd1 開始執行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            thd1 = new Thread(func1);
            thd2 = new Thread(func2);

            thd1.Start();
            thd2.Start();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!fg1)
                fg1 = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!fg2)
                fg2 = true;
        }

        /// <summary>
        /// 使用 thread1 顯示10次"Thread 1"
        /// </summary>
        void func1()
        {
            while (true)
            {
                if (fg1)
                    lock (locker)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            /* 確保委派代表的程式碼在 UI 執行緒上執行*/
                            /* Action 為委派的實例*/
                            textBox1.Invoke(new Action(() =>
                            {
                                textBox1.AppendText("Thread 1 \r\n");
                            }));
                            Thread.Sleep(500);
                        }
                        fg1 = false;
                    }
            }
        }

        /// <summary>
        /// 使用 thread2 顯示10次"Thread 2"
        /// </summary>
        void func2()
        {
            while (true)
            {
                if (fg2)
                    lock (locker)
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            /* 確保委派代表的程式碼在 UI 執行緒上執行*/
                            textBox1.Invoke(new Action(() =>
                            {
                                textBox1.AppendText("Thread 2 \r\n");
                            }));
                            Thread.Sleep(500);
                        }
                        fg2 = false;
                    }
            }
        }
    }
}
