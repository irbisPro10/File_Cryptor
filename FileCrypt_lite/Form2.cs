using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace FileCrypt_lite
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AES aesCrypt = new AES();
            string password = aesCrypt.DecryptPassword(File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "FileCrypt_lite.loc"));
            if (password != textBox1.Text)
            {
                MessageBox.Show("Password wasn't changed. Current password incorrect", "Error");
                textBox1.Text = null;
                textBox2.Text = null;
            }
            else 
            {
                string newPas = textBox2.Text;

                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory+"FileCrypt_lite.loc", aesCrypt.EncryptPassword(newPas));

                MessageBox.Show("Your password successfully changed", "Success!");
            }
            
           
        }
    }
}
