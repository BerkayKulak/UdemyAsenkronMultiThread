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

            //var product = (from p in context.Products.AsParallel()
            //    where p.ListPrice > 10M
            //    select p).Take(10);

            //product.ForAll(x =>
            //{
            //    Console.WriteLine(x.Name);
            //});

            var product2 = (from p in context.Products
                where p.ListPrice > 10M
                select p).Take(10);

            product2.ToList().ForEach(x =>
            {
                Console.WriteLine(x.Name);
            });

        }
    }
}
