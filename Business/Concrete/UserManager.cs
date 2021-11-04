using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        IUserImageService _userImageService;
        IUserOperationClaimService _userOperationClaimService;
      
        public UserManager(IUserDal userDal, IUserImageService userImageService, IUserOperationClaimService userOperationClaimService)
        {
            _userDal = userDal;
            _userImageService = userImageService;
            _userOperationClaimService = userOperationClaimService;
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
            IResult result = BusinessRules.Run(CheckIfUserImagesAreDeleted(user), CheckIfUserOperationClaimsAreDeleted(user));
            if (result!=null)
            {
                return result;
            }
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
        [CacheAspect]
        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == userId));
        }
        public IDataResult<List<UserDetailDto>> GetAllUsersByFilterText(string filterText)
        {
            return new SuccessDataResult<List<UserDetailDto>>(_userDal.GetAllUsersDetailDto(u => u.FirstName.Contains(filterText) ||
            u.LastName.Contains(filterText) || u.Title == filterText || u.Email.Contains(filterText)), Messages.UserDetailsListed);
        }

        //businessRules
        private IResult CheckIfUserImagesAreDeleted(User user)
        {
            var userImages = _userImageService.GetAllUserImagesByUserId(user.Id).Data;
            if (userImages.Count>0)
            {
                foreach (var userImage in userImages)
                {
                    var result = _userImageService.Delete(userImage);
                    if(result.Success == false)
                    {
                        return new ErrorResult();
                    }
                }
                
            }
            return new SuccessResult();
        }
        private IResult CheckIfUserOperationClaimsAreDeleted(User user)
        {
            var userOperationClaims = _userOperationClaimService.GetAllOperationClaimsByUserId(user.Id).Data;
            if (userOperationClaims.Count>0)
            {
                foreach (var userOperationClaim in userOperationClaims)
                {
                    var result = _userOperationClaimService.Delete(userOperationClaim);
                    if (result.Success==false)
                    {
                        return new ErrorResult();
                    }
                }
            }
            return new SuccessResult();
        }

        
    }
}
