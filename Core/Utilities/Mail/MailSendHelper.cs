using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Helpers.MailHelper;
using Core.Utilities.Results.Concrete;
using Core.Entities.Concrete;

namespace Core.Utilities.Mail
{
    public class MailSendHelper:IMailSendHelper
    {
        ISmtpClient _smtpClient;
        public MailSendHelper(ISmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }
        public IResult SendMail(User user,string securityCode)
        {
            var subject = "NoNeedForAWaiter password change request ";
            var body = "Your one-time code is = " + securityCode;
            _smtpClient.Host = "smtp.gmail.com";
            _smtpClient.Port = 587;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new NetworkCredential("noneedforawaiter@gmail.com","Darkteam54?");
            _smtpClient.Send("noneedforawaiter@gmail.com", user.Email, subject, body);
            return new SuccessResult();

        }
        public string CreateRandomSecurityCode()
        {
            Random random = new Random();
            int _firstRandomNumber=0, _secondRandomNumber=0, _thirdRandomNumber=0;
            int _firstRandomLetter, _secondRandomLetter;
            _firstRandomNumber = random.Next(1, 9);
            _secondRandomNumber = random.Next(1, 9);
            _thirdRandomNumber = random.Next(1, 9);
            _firstRandomLetter = random.Next(65, 91);
            _secondRandomLetter = random.Next(65, 91);

            string securityCode = _firstRandomNumber.ToString() + _secondRandomNumber.ToString() + _firstRandomLetter.ToString() + _thirdRandomNumber.ToString() + _secondRandomLetter.ToString();
            return securityCode;
        }
    }
}
