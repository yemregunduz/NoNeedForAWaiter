using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal:IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDetailDto> GetAllUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter = null);
    }
}
