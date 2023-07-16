using System;
using System.Windows.Forms;
using System.Threading;

namespace Thread_07
{
    public partial class Form1 : Form
    {
        Semaphore smphore;
        Thread[] thds = new Thread[5];
        delegate void SafeControl(string str);

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 宣告一個 func, 要給委派使用
        /// </summary>
        /// <param name="str"></param>
        void safeControl(string str)
        {
            textBox1.AppendText(str);
        }

        /// <summary>
        /// 撰寫繳費的流程 : 排隊 -> 繳費 -> 結束
        /// </summary>
        /// <param name="param"></param>
        void func(object param)
        {
            int no = (int)param;
            string str;
            /* 新增一委派變數 ivk*/
            SafeControl ivk = new SafeControl(safeControl);

            str = String.Format("第{0}位在排隊 ...\r\n", no);
            textBox1.Invoke(ivk, new Object[] { str });
            /* 等待並取得號誌(Semaphore)*/
            smphore.WaitOne();

            str = String.Format("第{0}位正在繳費 ...\r\n", no);
            textBox1.Invoke(ivk, new Object[] { str });
            Thread.Sleep(1000);

            str = String.Format("第{0}位繳費結束 ...\r\n", no);
            textBox1.Invoke(ivk, new Object[] { str });
            /* 釋放號誌(Semaphore)*/
            smphore.Release();
        }

        /// <summary>
        /// 宣告號誌目前最高上限有三個號誌可以取得
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            smphore = new Semaphore(0, 3);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            /* 先把全部的執行緒新增出物件*/
            for (int i = 0; i < thds.Length; i++)
            {
                /* 在 thread 要執行的 method*/
                thds[i] = new Thread(new ParameterizedThreadStart(func));
            }

            /* 讓所有執行緒開始執行*/
            for (int i = 0; i < thds.Length; i++)
            {
                thds[i].Start(i + 1);
            }

            textBox1.AppendText("尚未開始營業 ...\r\n");
            Thread.Sleep(3000);

            textBox1.AppendText("開始營業 ...\r\n");
            smphore.Release(3);
        }
    }
}
