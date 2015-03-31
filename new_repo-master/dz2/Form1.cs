using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz2
{
    public partial class Form1 : Form
    {
        //public delegate void del();
        //
        //public event del My_Event;
      
        public class Bank
        {
            int money;
            string name;
            int percent;

            public Bank(int m, string n, int p)
            {
                money = m;
                name = n;
                percent = p;
            }

            public int MONEY
            {
                set { money = value; FileWrite(); }
                get { return money; }
                
            }
            public string NAME
            {
                set { name = value; FileWrite(); }
                get { return name; }
            }
            public int PERCENT
            {
                set { percent = value; FileWrite(); }
                get { return percent; }
            }

            public void FileWrite()
            {
                try
                {
                    StreamWriter sw = new StreamWriter("Log.txt", true);
                    sw.WriteLine("Properties has been changed {0}\n", DateTime.Now);
                    sw.WriteLine("New values:\nMoney: {0};\nName: {1};\nPercent: {2}", MONEY, NAME, PERCENT);
                    sw.Close();
                    MessageBox.Show("Log Saved");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(method_1));
            t.Start();
            
        }
        public void method_1()
        {
            this.Width = 293;
            Bank b = new Bank(0, "Noname", 0);
            b.MONEY = Convert.ToInt32(tbxMoney.Text);
            b.NAME = tbxName.Text;
            b.PERCENT = Convert.ToInt32(tbxPercent.Text);
        }

        private void btnReadLog_Click(object sender, EventArgs e)
        {
            this.Width = 650;
            ReadLog();
        }
        public void ReadLog()
        {
            StreamReader sr = new StreamReader("Log.txt");
            string line;
            line = sr.ReadLine();
            while (line != null)
            {
                textBox1.Text += line;
                line = sr.ReadLine();
            }
            
            sr.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
		NIGGA t6hyhyh5y
        }

        
    }
}
