using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAllProductsByCategoryIdAndRestaurantId(int categoryId,int restaurantId);
        IDataResult<List<Product>> GetAllProductsByRestaurantId(int restaurantId);
        IDataResult<List<ProductDetailDto>> GetAllProductDetailsDtoByCategoryIdAndRestaurantId(int categoryId, int restaurantId);
        IDataResult<List<ProductDetailDto>> GetAllProductDetailsDtoByRestaurantId(int restaurantId);
    }
}
