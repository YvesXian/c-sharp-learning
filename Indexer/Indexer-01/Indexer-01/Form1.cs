using System;
using System.Windows.Forms;

namespace Indexer_01
{
    public partial class Form1 : Form
    {
        MyClass myclass;
        Random rd = new Random();

        public Form1()
        {
            InitializeComponent();

            myclass = new MyClass(10);

            /* 透過索引子設定 number 屬性*/
            for (int i = 0; i < 10; i++)
                myclass[i] = rd.Next(100);
        }

        /// <summary>
        /// 透過索引子讀取 number 屬性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                textBox1.AppendText(myclass[i].ToString() + "\r\n");
        }

        /// <summary>
        /// 直接讀取 myclass 物件的 number 屬性
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
                textBox1.AppendText(myclass.number[i].ToString() + "\r\n");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class MyClass
    {
        public int[] number;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        public MyClass(int num)
        {
            if (num <= 0)
                num = 10;
            number = new int[num];
        }

        /// <summary>
        /// 產生 MyClass 類別之後, 就可以使用此類別的索引子設定 number 變數
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public int this[int i]
        {
            get => number[i];
            set => number[i] = value;
        }
    }
}
