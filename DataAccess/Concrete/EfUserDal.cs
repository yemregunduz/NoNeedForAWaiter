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
                             join ui in context.USERIMAGES
                             on u.Id equals ui.UserId into gj1
                             from ui in gj1.DefaultIfEmpty()
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
                                 Status = u.Status,
                                 UserImagePath = ui.UserImagePath,
                                 UserImageId = ui.Id,
                                 DateOfBirth = u.DateOfBirth,
                                 DateOfDismissal = u.DateOfDismissal,
                                 DateOfRecruitment = u.DateOfRecruitment,
                                 FixedPhoneNumber = u.FixedPhoneNumber,
                                 MobilePhoneNumber = u.MobilePhoneNumber,
                                 TcNo = u.TcNo
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public UserDetailDto GetUserDetailDto(Expression<Func<UserDetailDto, bool>> filter = null)
        {
            using (var context = new NoNeedForAWaiterContext())
            {
                var result = from u in context.USERS
                             join ui in context.USERIMAGES
                             on u.Id equals ui.UserId into gj1
                             from ui in gj1.DefaultIfEmpty()
                             join r in context.RESTAURANTS
                             on u.RestaurantId equals r.Id
                             join t in context.TITLES
                             on u.TitleId equals t.Id
                             select new UserDetailDto
                             {
                                 Id = u.Id,
                                 RestaurantId = r.Id,
                                 RestaurantName = r.RestaurantName,
                                 UserImageId = ui.Id,
                                 UserImagePath = ui.UserImagePath,
                                 TitleId = t.Id,
                                 Title = t.Title_,
                                 Salary = u.Salary,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 Email = u.Email,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Status = u.Status,
                                 DateOfBirth = u.DateOfBirth,
                                 DateOfDismissal = u.DateOfDismissal,
                                 DateOfRecruitment = u.DateOfRecruitment,
                                 FixedPhoneNumber = u.FixedPhoneNumber,
                                 MobilePhoneNumber = u.MobilePhoneNumber,
                                 TcNo = u.TcNo
                             };
                return result.SingleOrDefault(filter);
            }
        }

    }
}
