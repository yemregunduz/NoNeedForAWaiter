using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;
        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
        }
        [SecuredOperation("productimage.add,admin",Priority =1)]
        [ValidationAspect(typeof(ProductImageValidator),Priority =2)]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Add(IFormFile file, ProductImage productImage)
        {
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new SuccessResult(imageResult.Message);
            }
            productImage.ProductImagePath = imageResult.Message;
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }
        [SecuredOperation("productimage.add,admin",Priority =1)]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Delete(ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageIsNull(productImage));
            if (result != null)
            {
                return result;
            }
            FileHelper.Delete(productImage.ProductImagePath);
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheAspect]
        public IDataResult<List<ProductImage>> GetAllProductImagesByProductId(int productId)
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.ProductId == productId));
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheAspect]
        public IDataResult<ProductImage> GetProductImageByImageId(int id)
        {
            return new SuccessDataResult<ProductImage>(_productImageDal.Get(p => p.Id == id)); ;
        }
        [SecuredOperation("productimage.add,admin", Priority = 1)]
        [ValidationAspect(typeof(ProductImageValidator), Priority = 2)]
        [CacheRemoveAspect("IProductImageService.Get")]
        public IResult Update(IFormFile file, ProductImage productImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageIsNull(productImage));
            if (result != null)
            {
                return result;
            }
            var updatedFile = FileHelper.Update(file, productImage.ProductImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            productImage.ProductImagePath = updatedFile.Message;
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.UserImageUpdated);
        }

        //businessRules

        private IResult CheckIfImageIsNull(ProductImage productImage)
        {
            var productImageToDeleted = GetProductImageByImageId(productImage.Id).Data;
            if (productImageToDeleted == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            return new SuccessResult();
        }
    }
}
