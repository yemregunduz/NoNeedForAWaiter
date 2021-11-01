using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 2)]
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.add,admin",Priority =1)]
        public IDataResult<Product> Add(Product product)
        {
            _productDal.Add(product);
            return new SuccessDataResult<Product>(product,Messages.ProductAdded);
        }
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("product.delete,admin", Priority = 1)]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetAllProductDetailsDtoByCategoryIdAndRestaurantId(int categoryId, int restaurantId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllProductDetailsDto(p=>p.CategoryId == categoryId && p.RestaurantId==restaurantId), Messages.ProductsListedByCurrentCategory);
        }
        [CacheAspect]
        public IDataResult<List<ProductDetailDto>> GetAllProductDetailsDtoByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllProductDetailsDto(p => p.RestaurantId == restaurantId),Messages.ProductsListed);
        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAllProductsByCategoryIdAndRestaurantId(int categoryId, int restaurantId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId && p.RestaurantId == restaurantId),Messages.ProductsListedByCurrentCategory);
        }
        [CacheAspect]
        public IDataResult<List<Product>> GetAllProductsByRestaurantId(int restaurantId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.RestaurantId == restaurantId),Messages.ProductsListed);
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 2)]
        [SecuredOperation("product.update,admin", Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
