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
            //Data Transformation Object
            ProductTest();
            //loading... IoC
            //CategoryTest();

            Console.ReadLine();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            //ProductManager productManager = new ProductManager(new InMemoryProductDal());
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetProductDetails())
            {
                Console.WriteLine(product.ProductName+ "/" +product.CategoryName);
            }

            Console.WriteLine("\n");

            foreach (var product in productManager.GetByUnitPrice(30, 50))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
