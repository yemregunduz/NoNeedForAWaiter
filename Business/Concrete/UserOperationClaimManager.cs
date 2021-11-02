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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        IUserOperationClaimDal _userOperationClaimDal;
        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }
        [SecuredOperation("admin",Priority =1)]
        [ValidationAspect(typeof(UserOperationClaimValidator),Priority =2)]
        [CacheRemoveAspect("IUserOperationClaimService.Get",Priority =3)]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            var result = BusinessRules.Run(CheckIfUserAlreadyHasThisOperationClaim(userOperationClaim));
            if (result!=null)
            {
                return result;
            }
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimAdded);
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("IUserOperationClaimService.Get",Priority =2)]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheAspect(Priority =2)]
        public IDataResult<List<UserOperationClaimDetailDto>> GetAllOperationClaimDetailsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaimDetailDto>>(_userOperationClaimDal.GetAllUserOperationClaimDetails(u => u.UserId == userId), Messages.UserOperationClaimsListed);
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheAspect(Priority = 2)]
        public IDataResult<List<UserOperationClaim>> GetAllOperationClaimsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.UserId == userId));
        }
        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(UserOperationClaimValidator), Priority = 2)]
        [CacheRemoveAspect("IUserOperationClaimService.Get", Priority = 3)]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            var result = BusinessRules.Run(CheckIfUserAlreadyHasThisOperationClaim(userOperationClaim));
            if (result!=null)
            {
                return result;
            }
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }

        //businessRules
        IResult CheckIfUserAlreadyHasThisOperationClaim(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimDal.Get(u => u.OperationClaimId == userOperationClaim.OperationClaimId && u.UserId == userOperationClaim.UserId);
            if (result!=null)
            {
                return new ErrorResult(Messages.UserAlreadyHasThisOperationClaim);
            }
            return new SuccessResult();
        }
    }
}
