using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{

    class Program
    {
        private async static Task Main(string[] args)
        {
            long FileByte = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string picturesPath =
                "C:\\Users\\Excalibur\\source\\repos\\UdemyAsenkronMultiThread\\TaskConsoleApp\\resim";

            var files = Directory.GetFiles(picturesPath);

            Parallel.ForEach(files, (item) =>
            {
                Console.WriteLine("Thread no: " + Thread.CurrentThread.ManagedThreadId);
                Image img = new Bitmap(item);

                FileInfo f = new FileInfo(item);

                Interlocked.Add(ref FileByte, f.Length);

            });


            Console.WriteLine("toplam boyut: " + FileByte.ToString());

        }

    }
}
