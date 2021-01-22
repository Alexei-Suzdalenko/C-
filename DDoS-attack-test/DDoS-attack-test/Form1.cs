using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DDoS_attack_test
{
    public partial class Form1 : Form
    {
        private string APP_NAME = "DDos attack ";
        private readonly string PREDICTION_PATCH = $"{Environment.CurrentDirectory}\\prediction.json";
        private string[] _predictions;
        private Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private async void myClickButton(object sender, EventArgs e)
        {
            button1.Enabled = false;
            await Task.Run(() =>
            {
                for (int i = 1; i <= 100; i++)
                {
                   this.Invoke(new Action(() =>
                    {
                        updateProgressBar(i);
                    }));
                    
                    Thread.Sleep(10);
                }

            });

            var index = _random.Next(_predictions.Length);
            var prediction = _predictions[index];

            MessageBox.Show(prediction);
            progressBar.Value = 0;
            this.Text = "End";
            button1.Enabled = true;
        }

        private void updateProgressBar(int i)
        {
            if(i == progressBar.Maximum)
            {
                progressBar.Maximum = i + 1;
                progressBar.Value = i + 1;
                progressBar.Maximum = i;
            } else
            {
                progressBar.Value = i + 1;
            }
            this.Text = APP_NAME + " " + i + " %";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = APP_NAME;
            try
            {
                var data = File.ReadAllText(PREDICTION_PATCH);
                _predictions = JsonConvert.DeserializeObject<string[]>(data);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
