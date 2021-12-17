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
            int deger = 0;

            Parallel.ForEach(Enumerable.Range(1, 100000).ToList(), (x) =>
            {
                deger = x;
            });

            Console.WriteLine(deger);

        }

    }
}
