using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRestaurantService
    {
        IResult Add(Restaurant restaurant);
        IResult Delete(Restaurant restaurant);
        IResult Update(Restaurant restaurant);
        IDataResult<List<Restaurant>> GetAll();
    }
}
