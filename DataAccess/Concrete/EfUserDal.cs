using Core.DataAccess.Concrete;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.Dto;
using System.Linq.Expressions;

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

        public List<UserDetailDto> GetAllUsersDetailDto(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from u in context.USERS
                             join r in context.RESTAURANTS
                             on u.RestaurantId equals r.Id
                             join t in context.TITLES
                             on u.TitleId equals t.Id
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 RestaurantId = r.Id,
                                 RestaurantName = r.RestaurantName,
                                 TitleId = t.Id,
                                 Title = t.Title_,
                                 Salary = u.Salary,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Status = u.Status
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public UserDetailDto GetUserDetailDto(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from u in context.USERS
                             join r in context.RESTAURANTS
                             on u.RestaurantId equals r.Id
                             join t in context.TITLES
                             on u.TitleId equals t.Id
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 RestaurantId = r.Id,
                                 RestaurantName = r.RestaurantName,
                                 TitleId = t.Id,
                                 Title = t.Title_,
                                 Salary = u.Salary,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Status = u.Status
                             };
                return result.SingleOrDefault(filter);
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

        public void UpdateUserWithoutPassword(User user)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                context.Attach(user);
                context.Entry(user).Property(u => u.FirstName).IsModified = true;
                context.Entry(user).Property(u => u.LastName).IsModified = true;
                context.Entry(user).Property(u => u.Email).IsModified = true;
                context.Entry(user).Property(u => u.RestaurantId).IsModified = true;
                context.Entry(user).Property(u => u.Salary).IsModified = true;
                context.Entry(user).Property(u => u.Status).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
