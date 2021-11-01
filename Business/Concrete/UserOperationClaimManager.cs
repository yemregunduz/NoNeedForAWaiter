using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
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

        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        public IDataResult<List<UserOperationClaim>> GetAllOperationClaimsByUserId(int userId)
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll(u => u.UserId == userId));
        }

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
