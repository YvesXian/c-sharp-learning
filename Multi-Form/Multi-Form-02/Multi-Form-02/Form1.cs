using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multi_Form_02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            DialogResult result;

            result = form2.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    Console.WriteLine("Form2 按下了 OK");
                    break;
                case DialogResult.Cancel:
                    Console.WriteLine("Form2 按下了 Cancel");
                    break;
                default:
                    Console.WriteLine(result.ToString());
                    break;
            }
        }
    }
}
