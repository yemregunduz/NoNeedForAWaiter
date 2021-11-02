using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, NoNeedForAWaiterContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDetailDto> GetAllUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from u in context.USERS

                             join uoc in context.USEROPERATIONCLAIMS
                             on u.Id equals uoc.UserId into gj
                             from uoc in gj.DefaultIfEmpty()
                             join oc in context.OPERATIONCLAIMS
                             on uoc.OperationClaimId equals oc.Id
                             select new UserOperationClaimDetailDto
                             {
                                 Id = uoc.Id,
                                 OperationClaimId = oc.Id,
                                 OperationClaimName = oc.Name,
                                 UserId = u.Id
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
