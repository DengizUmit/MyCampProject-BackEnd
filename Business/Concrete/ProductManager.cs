﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Acpects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        IProductDal _productDal;
        ILogger _logger;

        public ProductManager(IProductDal productDal, ILogger logger)
        {
            _productDal = productDal;
            _logger = logger;
        }


        //[ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            _logger.Log();
            try
            {
                // business codes
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            catch (Exception exception)
            {

                _logger.Log();
            }
            return new ErrorResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            if(DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        IDataResult<List<Product>> IProductService.GetById(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
