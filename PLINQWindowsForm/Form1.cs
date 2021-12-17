using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PLINQWindowsForm
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource ct;
        public Form1()
        {
            InitializeComponent();
            ct = new CancellationTokenSource();
        }

        private bool Hesapla(int x)
        {
            Thread.SpinWait(50000);
            return x % 12 == 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Task.Run(() =>
                {
                    Enumerable.Range(1, 100000).AsParallel().WithCancellation(ct.Token).Where(Hesapla)
                        .ToList().ForEach(x =>
                        {
                            Thread.Sleep(100);
                            listBox1.Invoke((MethodInvoker) delegate { listBox1.Items.Add(x); });
                        });
                });
            }
            catch(OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
