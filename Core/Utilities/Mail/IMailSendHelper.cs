using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Mail
{
    public interface IMailSendHelper
    {
        IResult SendMail(User user,string securityCode);
        string CreateRandomSecurityCode(); 
    }
}
