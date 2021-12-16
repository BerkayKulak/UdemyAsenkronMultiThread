using System;
using System.Collections.Generic;
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
        private async static Task Main(string[] args)
        {

            var myTask = Task.Factory.StartNew((Obj) =>
            {
                Console.WriteLine("myTask çalıştı");
                var status = Obj as Status;
                status.ThreadId = Thread.CurrentThread.ManagedThreadId;
            }, new Status()
            {
                date = DateTime.Now
            });

            await myTask;

            Status s = myTask.AsyncState as Status;
            Console.WriteLine(s.date);
            Console.WriteLine(s.ThreadId);

        }
    }
}
