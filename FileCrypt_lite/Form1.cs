using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;


namespace FileCrypt_lite
{
    public partial class Form1 : Form
    {
        string File_name;
        int i=0;



        public Form1()
        {
            InitializeComponent();
            LoadListview();
          
        }
       
        public void openFile()
        {
            
            if (listView1.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listView1.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                String text = listView1.Items[intselectedindex].Text;
                textBox2.Text = text;
                try
                {
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Storage\\"+text);
                    toolStripStatusLabel1.Text = "File " + text + " was opened";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void LoadListview()
        {
            listView1.Clear();

            DirectoryInfo dis = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Storage\\");
            FileInfo[] Files = dis.GetFiles("*");
 
            foreach (FileInfo di in Files)
            {
                File_name = di.FullName;
                File_name = Path.GetExtension(File_name).ToLower();
                switch (File_name)
                {
                    case ".doc": i = 0;
                        break;
                    case ".docx": i = 0;
                        break;
                    case ".jpg": i = 2;
                        break;
                    case ".jpeg": i = 2;
                        break;
                    case ".pdf": i = 3;
                        break;
                    case ".png": i = 4;
                        break;
                    case ".txt": i = 5;
                        break;
                    case ".ppt": i = 6;
                        break;
                    case ".pptx": i = 6;
                        break;
                    case ".xls": i = 7;
                        break;
                    case ".xlsx": i = 5;
                        break;
                    default: i=1;
                        break;
                }
              listView1.Items.Add(di.Name, i);
                
            }
        }

        private void AddFile()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            var str = openFileDialog1.FileName.Split(new[] { '\\' }).Last();
                            File.Copy(openFileDialog1.FileName, AppDomain.CurrentDomain.BaseDirectory + "/../../Storage/" + str);
                            LoadListview();
                            toolStripStatusLabel1.Text = "File " + openFileDialog1.SafeFileName + " was added";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    toolStripStatusLabel1.Text = "Error! File " + openFileDialog1.SafeFileName + " was not added";
                }
            } 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddFile();
        }

        private void listView1_MouseDoubleClick(object sender, EventArgs e)
        {
            openFile();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            LoadListview();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
           
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0) 
            
            { MessageBox.Show("Error!"); 
              return; 
            }
           
            File_name = listView1.Items[listView1.SelectedIndices[0]].Text;
            FolderBrowserDialog fld = new FolderBrowserDialog();
            fld.ShowDialog();
            string chosenFolder = fld.SelectedPath;
            File.Move(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Storage\\" + File_name, chosenFolder+"\\"+File_name);
            LoadListview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count <= 0)
            {
                MessageBox.Show("Error!");
                return;
            }

            File_name = listView1.Items[listView1.SelectedIndices[0]].Text;
            string ask = "Are you sure that you would like to delite " + File_name + "?";
            var result = MessageBox.Show(ask, " Delition...", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) ;
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\Storage\\" + File_name);
            LoadListview();
        }

    }
}
