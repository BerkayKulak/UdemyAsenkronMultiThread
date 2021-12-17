using System;
using System.Collections.Generic;
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
            Console.WriteLine("1. adım");

            var task = GetContent();

            Console.WriteLine("2. adım");

            var content =   await task;

            Console.WriteLine("3. adım" + content.Length);

        }

        public static async Task<string> GetContent()
        {
            var content = await new HttpClient().GetStringAsync("https://www.google.com");

            return content;
        }
    }
}
