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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            /* Setting button1 is OK*/
            button1.DialogResult = DialogResult.OK;
            /* Setting button2 is Cancel*/
            button2.DialogResult = DialogResult.Cancel;
        }
    }
}
