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
        public IDataResult<List<User>> GetAllUsersByRestaurantIdAndStatus(int restaurantId,bool status)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.RestaurantId == restaurantId && u.Status == status));
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
        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(UserValidator),Priority =2)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult UpdateUserStatus(User user)
        {
            _userDal.UpdateUserStatus(user);
            return new SuccessResult(Messages.UserStatusUpdated);
        }

    }
}
