using System;
using System.Linq;

namespace PLINQApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = Enumerable.Range(1, 500).ToList();

            var newArray = array.AsParallel().Where(x => x % 2 == 0);

            newArray.ToList().ForEach(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
