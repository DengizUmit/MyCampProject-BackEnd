using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {

        List<Product> _products;
        public InMemoryProductDal()
        {
            // Oracle, SqlServer, Postgres, MongoDb
            _products = new List<Product> {

                new Product {ProductId = 1, CategoryId = 1, ProductName = "Surahi", UnitPrice = 15, UnitsInStock = 18},
                new Product {ProductId = 2, CategoryId = 2, ProductName = "Camera", UnitPrice = 200, UnitsInStock = 32},
                new Product {ProductId = 3, CategoryId = 3, ProductName = "Telephone", UnitPrice = 3000, UnitsInStock = 3},
                new Product {ProductId = 4, CategoryId = 3, ProductName = "Mouse", UnitPrice = 70, UnitsInStock = 100},
                new Product {ProductId = 5, CategoryId = 3, ProductName = "Airpods", UnitPrice = 600, UnitsInStock =5}
            };
        }


        public void Add(Product product)
        {
            _products.Add(product);
        }


        public void Delete(Product product)
        {

            //Product productToDelete = null;

            //foreach (var p in _products)
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}


            // LINQ : Language Integrated Query

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
        }


        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            productToUpdate.UnitPrice = product.UnitPrice;
        }
    }
}
