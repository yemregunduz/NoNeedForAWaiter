using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserImageManager : IUserImageService
    {
        IUserImageDal _userImageDal;
        public UserImageManager(IUserImageDal userImageDal)
        {
            _userImageDal = userImageDal;
        }
        public IResult Add(IFormFile file, UserImage userImage)
        {
            var imageResult = FileHelper.Upload(file);
            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            userImage.UserImagePath = imageResult.Message;
            _userImageDal.Add(userImage);
            return new SuccessResult(Messages.UserImageAdded);
        }

        public IResult Delete(UserImage userImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageIsNull(userImage));
            if (result!=null)
            {
                return result;
            }
            FileHelper.Delete(userImage.UserImagePath);
            _userImageDal.Delete(userImage);
            return new SuccessResult(Messages.UserImageDeleted);
        }

        public IDataResult<UserImage> Get(int id)
        {
            return new SuccessDataResult<UserImage>(_userImageDal.Get(u => u.Id == id));
        }

        public IDataResult<List<UserImage>> GetAllUserImagesByUserId(int userId)
        {
            return new SuccessDataResult<List<UserImage>>(_userImageDal.GetAll(u => u.UserId == userId));
        }

        public IResult Update(IFormFile file, UserImage userImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageIsNull(userImage));
            if (result!=null)
            {
                return result;
            }
            var updatedFile = FileHelper.Update(file, userImage.UserImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            userImage.UserImagePath = updatedFile.Message;
            _userImageDal.Update(userImage);
            return new SuccessResult(Messages.UserImageUpdated);
        }
        //businessRules
        private IResult CheckIfImageLimitExceeded(int userId)
        {
            var countOfUserImages = GetAllUserImagesByUserId(userId).Data.Count;
            if (countOfUserImages>=5)
            {
                return new ErrorResult(Messages.UserImageLimitExceeded);
            }
            return new SuccessResult();
        }
        private IResult CheckIfImageIsNull(UserImage userImage)
        {
            var userImageToDeleted = Get(userImage.Id).Data;
            if (userImageToDeleted==null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            return new SuccessResult();
        }
    }
}
