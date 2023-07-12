using System;
using System.Windows.Forms;
using System.Threading;

namespace Thread_04
{
    public partial class Form1 : Form
    {
        delegate void SafeCall(string str);
        Thread[] myThreads = { null, null };
        int sum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 確保在任何執行緒上調用 safeControl 方法時，都能在 UI 執行緒上安全地修改 textBox1 的內容
        /// </summary>
        void safeControl()
        {
            /* 表示目前執行緒不是 UI 執行緒, 如果不是 UI 的執行緒, 就執行以下程式內容*/
            if (textBox1.InvokeRequired)
            {
                sum++;
                if (sum > int.MaxValue)
                    sum = 0;
                /* 宣告一個無引數與回傳值的委派類型*/
                MethodInvoker ivk = new MethodInvoker(safeControl);
                /* 確保委派代表的程式碼在 UI 執行緒上執行*/
                textBox1.Invoke(ivk, new object[] { });
            }
            else
                textBox1.AppendText("myThread[1]: " + sum.ToString() + "\r\n");
        }

        /// <summary>
        /// 執行 safeControl func
        /// </summary>
        void myFunc()
        {
            while (true)
            {
                safeControl();
                Thread.Sleep(500);
            }
        }

        /// <summary>
        /// 確保在任何執行緒上調用 safeControl_param 方法時，都能在 UI 執行緒上安全地修改 textBox1 的內容
        /// </summary>
        /// <param name="str"></param>
        void safeControl_param(string str)
        {
            /* 表示目前執行緒不是 UI 執行緒, 如果不是 UI 的執行緒, 就執行以下程式內容*/
            if (textBox1.InvokeRequired)
            {
                /* 宣告一個有引數, 但沒有回傳值的委派函式*/
                SafeCall ivk = new SafeCall(safeControl_param);
                /* 確保委派代表的程式碼在 UI 執行緒上執行*/
                textBox1.Invoke(ivk, new object[] { str });
            }
            else
                textBox1.AppendText(str + "\r\n");
        }

        /// <summary>
        /// 宣告一個 method, 隨機產生 1~100 的亂數
        /// </summary>
        void myFunc_param()
        {
            Random rd = new Random();
            int num;

            while (true)
            {
                num = rd.Next(1, 101);
                safeControl_param("myThread[0]: " + num.ToString());
                Thread.Sleep(200);
            }
        }

        /// <summary>
        /// 啟動 myFunc_param func
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Para_btn_Click(object sender, EventArgs e)
        {
            Thread thd;

            /* 如果 myThreads[0] 已有執行緒, 那就先把它中止並結束*/
            if (myThreads[0] != null)
            {
                myThreads[0].Abort();
                myThreads[0].Join();
            }

            /* 產生一個新的執行緒*/
            thd = new Thread(new ThreadStart(myFunc_param));
            myThreads[0] = thd;

            /* 開始執行*/
            thd.Start();
        }

        /// <summary>
        /// 啟動 myFunc func
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Non_btn_Click(object sender, EventArgs e)
        {
            Thread thd;

            /* 如果 myThreads[0] 已有執行緒, 那就先把它中止並結束*/
            if (myThreads[1] != null)
            {
                myThreads[1].Abort();
                myThreads[1].Join();
            }

            /* 產生一個新的執行緒*/
            thd = new Thread(new ThreadStart(myFunc));
            myThreads[1] = thd;

            /* 開始執行*/
            thd.Start();
        }

        /// <summary>
        /// 當視窗關閉時, 需要把所有執行緒釋放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var item in myThreads)
                if (item != null)
                    item.Abort();
        }
    }
}
