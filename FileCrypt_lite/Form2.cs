using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileCrypt_lite
{
    public delegate void ValueSetter(bool v);
    public partial class Form2 : Form
    {
      ValueSetter setValue;
        public Form2(ValueSetter v)
        {
            setValue = v;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { setValue(true); } else setValue(false);
            if (radioButton2.Checked) { }
        }
    }
}
