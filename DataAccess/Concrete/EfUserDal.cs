using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, NoNeedForAWaiterContext>, IUserDal
    {
        public List<OperationClaim> GetAllClaims(User user)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from oc in context.OPERATIONCLAIMS
                             join uoc in context.USEROPERATIONCLAIMS
                             on oc.Id equals uoc.OperationClaimId
                             where uoc.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = oc.Id,
                                 Name = oc.Name
                             };
                return result.ToList();
            }
        }

        public void UpdateUserStatus(User user)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                context.Attach(user);
                var status = context.Entry(user).Property(u => u.Status);
                status.IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
