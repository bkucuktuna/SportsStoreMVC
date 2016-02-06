using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Concrete;
using SportsStore.Domain.Abstract;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            EFDbContext context = new EFDbContext();
            foreach (Product p in context.Products)
	{
        Console.WriteLine("Name: " + p.Name);
	}
            
        }
    }
}
