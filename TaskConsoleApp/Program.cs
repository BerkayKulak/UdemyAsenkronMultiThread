using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    public class Content
    {
        public string Site { get; set; }
        public int Len { get; set; }
    }
    class Program
    {
        private async static Task Main(string[] args)
        {
            Console.WriteLine("Main Thread:"+Thread.CurrentThread.ManagedThreadId);
            List<string> urlList = new List<string>()
            {
                "https://www.google.com",
                "https://www.microsoft.com",
                "https://www.amazon.com",
                "https://www.n11.com",
                "https://www.haberturk.com"
            };

            List<Task<Content>> taskList = new List<Task<Content>>();
            urlList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            Console.WriteLine("waitAll metodundan önce");
            bool result = Task.WaitAll(taskList.ToArray(),3000);

            var firstTaskIndex = Task.WaitAny(taskList.ToArray());

           
            Console.WriteLine($"{taskList[firstTaskIndex].Result.Site} - {taskList[firstTaskIndex].Result.Len}");



        }

        public  static async Task<Content> GetContentAsync(string url)
        {
            Content c = new Content();
            var data = await new HttpClient().GetStringAsync(url);
            c.Site = url;
            c.Len = data.Length;
            Console.WriteLine("Get ContentAsync thread" + Thread.CurrentThread.ManagedThreadId);
            return c;
        }
    }


}
