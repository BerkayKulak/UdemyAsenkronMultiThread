using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPLCancelletionForm
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource ct;

        private int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ct = new CancellationTokenSource();
            List<string> urls = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",

            };


            HttpClient client = new HttpClient();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = ct.Token;

            Task.Run(() =>
            {
                try
                {
                    Parallel.ForEach<string>(urls, parallelOptions, (url) =>
                    {
                        string content = client.GetStringAsync(url).Result;

                        string data = $"{url}:{content.Length}";

                        ct.Token.ThrowIfCancellationRequested();

                        listBox1.Invoke((MethodInvoker)delegate { listBox1.Items.Add(data); });


                    });
                }
                catch (Exception exception)
                {
                    MessageBox.Show("işlem iptal edildi" + exception.Message);
                }
               

            });


        }

        private void button3_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = counter++.ToString();
        }
    }
}
