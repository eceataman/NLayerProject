﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public Product GetByID(int id)
        {
            return _productDal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productDal.GetList();
        }

        public void TDelete(Product t)
        {
           _productDal.Delete(t);
        }

        public void TInsert(Product t)
        {
           _productDal.Insert(t);
        }

        public void TUpdate(Product t)
        {
            _productDal.Update(t);
        }
    }
}
