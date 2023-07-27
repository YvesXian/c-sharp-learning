using System;
using System.Windows.Forms;

namespace Delegate_02
{
    public partial class Form1 : Form
    {
        delegate void Dgate();

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public void PreWords()
        {
            textBox1.AppendText("今日特價商品 : ");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Item()
        {
            if (radioButton1.Checked)
                textBox1.AppendText("雙層鉛筆盒\r\n");
            else
                textBox1.AppendText("精美手工肥皂\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Sold()
        {
            Random rd = new Random();
            int num;

            num = rd.Next(1, 31);
            textBox1.AppendText("只剩下 " + num + "個\r\n");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Dgate DelFunc1 = PreWords;
            Dgate DelFunc2 = Item;
            Dgate DelFunc3 = Sold;
            Dgate AllDel;

            /* 本範例重點: 委派可以進行組合, 這種關係更像是決定函式的先後順序*/
            AllDel = DelFunc1 + DelFunc2;
            AllDel();

            AllDel -= DelFunc2;
            AllDel += DelFunc3;
            AllDel();
        }
    }
}
