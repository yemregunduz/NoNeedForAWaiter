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
    public class RestaurantManager : IRestaurantService
    {
        IRestaurantDal _restaurantDal;
        public RestaurantManager(IRestaurantDal restaurantDal)
        {
            _restaurantDal = restaurantDal;
        }
        public IResult Add(Restaurant restaurant)
        {
            _restaurantDal.Add(restaurant);
            return new SuccessResult(Messages.RestaurantAdded);
        }

        public IResult Delete(Restaurant restaurant)
        {
            _restaurantDal.Delete(restaurant);
            return new SuccessResult(Messages.RestaurantDeleted);
        }

        public IDataResult<List<Restaurant>> GetAll()
        {
            return new SuccessDataResult<List<Restaurant>>(_restaurantDal.GetAll(), Messages.RestaurantListed);
        }

        public IResult Update(Restaurant restaurant)
        {
            _restaurantDal.Update(restaurant);
            return new SuccessResult(Messages.RestaurantUpdated);
        }
    }
}
