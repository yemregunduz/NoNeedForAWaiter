using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult UpdateUserStatus(User user);
        IDataResult<User> GetUserByMail(string email);
        IDataResult<List<User>> GetAllUsersByRestaurantIdAndStatus(int restaurantId,bool status);
    }
}
