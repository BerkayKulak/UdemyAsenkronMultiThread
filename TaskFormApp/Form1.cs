using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string data = await ReadFileAsync();

            richTextBoxDosya.Text = data;
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = Counter++.ToString();
        }

        private void richTextBoxDosya_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxCounter_TextChanged(object sender, EventArgs e)
        {

        }

        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.TXT"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();
            }

            return data;

        }

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.TXT"))
            {
                Task<string> mytask = s.ReadToEndAsync();

                await Task.Delay(5000);

                data = await mytask;
                return data;
            }
        }
    }
}
