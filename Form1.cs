using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urok_5___1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Enabled = false;
                progressBar1.Visible = false;
                FileInfo file = new FileInfo(openFileDialog1.FileName);
                label1.Text = file.FullName;
                MessageBox.Show($"{file.Name}\n{file.CreationTime}\n{file.Attributes}", "Files data") ;
            }
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            progressBar1.Visible = true;
            timer1.Enabled = true;
        }

        private void Folder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                progressBar1.Visible = true;
                timer2.Enabled = true;
            }
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value++;
            }
            else
            {
                timer2.Enabled = false;
                progressBar1.Visible = false;
                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                label1.Text = dir.FullName;
                var files = dir.GetFiles();
                string txt = "";
                foreach (FileInfo file in files)
                {
                    txt = txt + file.Name + "\n";
                }
                MessageBox.Show(txt,"Files in the directory");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = folderBrowserDialog1.SelectedPath + @"\" + textBox1.Text;
            FileInfo file = new FileInfo(path);
            FileStream stream = file.Create();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string path = folderBrowserDialog1.SelectedPath + @"\" + textBox1.Text;
            FileInfo file = new FileInfo(path);
            file.Delete();
        }
    }
}
