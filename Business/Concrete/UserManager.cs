using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;

using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
      
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
            
        }
        [SecuredOperation("user.add,admin", Priority = 1)]
        [ValidationAspect(typeof(UserValidator), Priority = 2)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }
        [SecuredOperation("admin",Priority =1)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        [SecuredOperation("admin",Priority =1)]
        [CacheAspect]
        public IDataResult<List<UserDetailDto>> GetAllUsersByRestaurantIdAndStatus(int restaurantId,bool status)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUsersDetailDto(u => u.RestaurantId == restaurantId && u.Status == status));
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetAllClaims(user),Messages.ClaimsListed);
        }
        [CacheAspect]
        public IDataResult<User> GetUserByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }
        [CacheAspect]
        public IDataResult<UserDetailDto> GetUserDetailDtoByUserId(int userId)
        {
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetailDto(u => u.Id == userId),Messages.UserDetailsListed);
        }
        [CacheRemoveAspect("IUserService.Get")]
        [SecuredOperation("admin",Priority =1)]
        [ValidationAspect(typeof(UserValidator),Priority =2)]
        public IResult UpdateUserWithoutPassword(User user)
        {
            _userDal.UpdateUserWithoutPassword(user);
            return new SuccessResult(Messages.UserUpdated);
        }

        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(UserValidator),Priority =2)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateUserStatus(User user)
        {
            _userDal.UpdateUserStatus(user);
            return new SuccessResult(Messages.UserStatusUpdated);
        }
        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
    }
}
