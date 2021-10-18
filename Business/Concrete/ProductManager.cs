using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _urunDal;
        public ProductManager(IProductDal urunDal)
        {
            _urunDal = urunDal;
        }
        public IResult Add(Product urun)
        {
            _urunDal.Add(urun);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product urun)
        {
            _urunDal.Delete(urun);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_urunDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllProductsByCategoryId(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_urunDal.GetAll(u => u.CategoryId == categoryId),Messages.ProductsListedByCurrentCategory);
        }

        public IResult Update(Product urun)
        {
            _urunDal.Update(urun);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
