using System;
using System.Linq;
using PLINQApp.Models;

namespace PLINQApp
{
    class Program
    {
        
        static void Main(string[] args)
        {
            AdventureWorks2017Context context = new AdventureWorks2017Context();

            context.Products.Take(10).ToList().ForEach(x =>
            {
                Console.WriteLine(x.Name);
            });
        }
    }
}
