using System;
using System.Linq;

namespace PLINQApp
{
    class Program
    {
        private static bool islem(int x)
        {
            return x % 2 == 0;
        }
        static void Main(string[] args)
        {
            var array = Enumerable.Range(1, 500).ToList();

            var newArray = array.AsParallel().Where(islem);

            //newArray.ToList().ForEach(x =>
            //{
            //    Console.WriteLine(x);
            //});

            newArray.ForAll(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}
