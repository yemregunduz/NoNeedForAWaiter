using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Mail;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        IMailSendHelper _mailSendHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper,IMailSendHelper mailSendHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mailSendHelper = mailSendHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data;
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
        
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck.Data==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            if (userToCheck.Data.Status==false)
            {
                return new ErrorDataResult<User>(Messages.UserStatusIsInactive);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult PasswordChange(UserForPasswordChangeDto userForPasswordChangeDto)
        {
            UserForLoginDto userToCheck = new UserForLoginDto
            {
                Email = userForPasswordChangeDto.Email,
                Password = userForPasswordChangeDto.PreviousPassword
            };
            
            var resultOfLogin = Login(userToCheck);
            if (!resultOfLogin.Success)
            {
                return new ErrorResult(resultOfLogin.Message);
            }
            string securityCode = _mailSendHelper.CreateRandomSecurityCode();
            var resultOfSentMail = _mailSendHelper.SendMail(resultOfLogin.Data, securityCode);
            if (!resultOfSentMail.Success)
            {
                return new ErrorResult(resultOfSentMail.Message);
            }
            if (securityCode.CompareTo(userForPasswordChangeDto.SecurityCode)!=0)
            {
                return new ErrorResult(Messages.SecurityCodeError);
            }
            var userToUpdate = resultOfLogin.Data;
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForPasswordChangeDto.Password, out passwordHash, out passwordSalt);
            userToUpdate.PasswordSalt = passwordSalt;
            userToUpdate.PasswordHash = passwordHash;
            _userService.Update(userToUpdate);
            return new SuccessResult(Messages.PasswordChanged);
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IUserService.Get")]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            var result = UserExist(userForRegisterDto.Email);
            if (result.Success==false)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                RestaurantId= userForRegisterDto.RestaurantId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Salary = userForRegisterDto.Salary,
                TitleId = userForRegisterDto.TitleId,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
            var result = _userService.GetUserByMail(email);
            if (result.Data!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}
