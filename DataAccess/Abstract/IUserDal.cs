using Core.DataAccess.Abstract;
using Core.Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
        List<OperationClaim> GetAllClaims(User user);
        void UpdateUserStatus(User user);
        List<UserDetailDto> GetAllUsersDetailDto(Expression<Func<UserDetailDto, bool>> filter = null);
        UserDetailDto GetUserDetailDto(Expression<Func<UserDetailDto, bool>> filter = null);
        void UpdateUserWithoutPassword(User user);
    }
}
