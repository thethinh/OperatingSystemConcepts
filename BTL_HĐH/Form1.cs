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
using System.Threading;

namespace BTL_HĐH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessBar()
        {
            try
            {
                int n = int.Parse(txtSoHang.Text);
                int m = int.Parse(txtSoCot.Text);
                for (int i = 1; i <= (n * m); ++i)
                {
                    progressBar1.Invoke(new MethodInvoker(() =>
                    {
                        progressBar1.Maximum = (n * m);
                        progressBar1.Value = (i);
                    }));
                }              
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void inputMatrix()
        {
            try
            {
                Thread pro = new Thread(new ThreadStart(ProcessBar));
                pro.Start();
                int[,] arr = new int[10000, 10000];
                using (StreamWriter sw = new StreamWriter("mydata.txt"))
                {
                    StreamWriter sw1 = new StreamWriter("mydata2.txt");
                    Random ran = new Random();
                    for (int i = 1; i <= int.Parse(txtSoHang.Text); ++i)
                    {
                        //sw.Write("\t");
                        for (int j = 1; j <= int.Parse(txtSoCot.Text); ++j)
                        {
                            arr[i, j] = ran.Next(1, 10);
                            sw.Write(arr[i, j] + " ");
                            sw1.Write(arr[i, j] + " ");
                            
                        }
                        sw.WriteLine();
                        sw1.WriteLine();
                    }
                    sw.Close();
                    sw1.Close();
                    MessageBox.Show("Input complete !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            progressBar1.Invoke(new MethodInvoker(() =>
            {
                
                progressBar1.Value = 0;
            }));
            try
            {
                using (StreamReader sr = new StreamReader("mydata.txt"))
                {
                   
                    string line;
                    line = sr.ReadToEnd();
                    richTextBox1.Invoke(new MethodInvoker(() =>
                    {
                        richTextBox1.SelectionIndent = 20;
                        richTextBox1.Text = line;
                    }));
                    //richTextBox1.SelectionIndent = 20;
                    //richTextBox1.Text = line;

                    sr.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Invoke(new MethodInvoker(() =>
                {
                    richTextBox1.Clear();
                }));
                Thread th1 = new Thread(new ThreadStart(inputMatrix));
                th1.Start();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Search()
        {
            try
            {              
                StreamReader sr = new StreamReader("mydata2.txt");
                int number = 0;
                string s = "";
                int o;
                s = sr.ReadToEnd();
                int[,] a = new int[10000, 10000];

                listBox1.Invoke(new MethodInvoker(() =>
                {
                    listBox1.Items.Clear();
                }));
                string[] text = s.Trim().Split(' ');
                for (int i = 0; i < text.Length; ++i)
                {
                    o = int.Parse(text[i]);
                    if (o == (int.Parse(txtK.Text)))
                    {
                        
                        ++number;
                        listBox1.Invoke(new MethodInvoker(() =>
                        {
                            listBox1.Items.Add("number+1 : " + number);
                        }));
                    }
                }
                MessageBox.Show("Số phần tử giống với K : " + number);

                sr.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Thread th2 = new Thread(new ThreadStart(Search));
                th2.Start();
                //Search();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
  
    }
}
