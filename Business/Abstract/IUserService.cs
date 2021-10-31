using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
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
        IResult UpdateUserWithoutPassword(User user);
        IResult UpdateUserStatus(User user);
        IDataResult<User> GetUserByMail(string email);
        IDataResult<User> GetUserById(int userId);
        IDataResult<List<UserDetailDto>> GetAllUsersByRestaurantIdAndStatus(int restaurantId,bool status);
        IDataResult<UserDetailDto> GetUserDetailDtoByUserId(int userId);

    }
}
