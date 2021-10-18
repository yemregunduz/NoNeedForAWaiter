using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IResult Add(Product product);
        IResult Delete(Product product);
        IResult Update(Product product);
        IDataResult<List<Product>> GetAllProductsByCategoryIdAndRestaurantId(int categoryId,int restaurantId);
        IDataResult<List<Product>> GetAllProductsByRestaurantId(int restaurantId);
    }
}
