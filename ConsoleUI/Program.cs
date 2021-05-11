using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    // SOLID
    // Open Closed Principle
    class Program
    {
        static void Main(string[] args)
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAllByCategoryId(3))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("\n");

            foreach (var product in productManager.GetByUnitPrice(30, 50))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        }
    }
}
