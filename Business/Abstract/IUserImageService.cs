using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserImageService
    {
        IResult Add(IFormFile file, UserImage userImage);
        IResult Delete(UserImage userImage);
        IResult Update(IFormFile file, UserImage userImage);
        IDataResult<UserImage> Get(int id);
        IDataResult<List<UserImage>> GetAllUserImagesByUserId(int userId);

    }
}
