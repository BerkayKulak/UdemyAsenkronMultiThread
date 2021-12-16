using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{

    public class Status
    {
        public int ThreadId { get; set; }
        public DateTime date { get; set; }

    }

    class Program
    {
        public static string CacheData { get; set; }

        private async static Task Main(string[] args)
        {
            CacheData = await GetDataAsync();

            Console.WriteLine(CacheData);
        }

        public static Task<string> GetDataAsync()
        {
           

            if (string.IsNullOrEmpty((CacheData)))
            {
                return File.ReadAllTextAsync("dosya.TXT");

            }
            else
            {
                return Task.FromResult(CacheData);
            }
        }
    }
}
