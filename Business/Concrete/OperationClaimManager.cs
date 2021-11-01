using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;
        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }
        [SecuredOperation("admin",Priority =1)]
        [ValidationAspect(typeof(OperationClaimValidator),Priority =2)]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Add(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(CheckIfOperationClaimAlreadyExist(operationClaim));
            if (result!= null)
            {
                return result;
            }
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim operationClaim)
        {
            _operationClaimDal.Delete(operationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAllOperationClaims()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll(), Messages.OperationClaimsListed);
        }
        [SecuredOperation("admin", Priority = 1)]
        [ValidationAspect(typeof(OperationClaimValidator), Priority = 2)]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Update(OperationClaim operationClaim)
        {
            IResult result = BusinessRules.Run(CheckIfOperationClaimAlreadyExist(operationClaim));
            if (result!=null)
            {
                return result;
            }
            _operationClaimDal.Update(operationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }

        //businessRules

        private IResult CheckIfOperationClaimAlreadyExist(OperationClaim operationClaim)
        {
            var operationClaimToAdded = _operationClaimDal.Get(o => o.Name == operationClaim.Name);
            if (operationClaimToAdded!=null )
            {
                return new ErrorResult(Messages.OperationClaimAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
