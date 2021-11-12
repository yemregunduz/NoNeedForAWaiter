using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class UserForPasswordChangeDto:IDto
    {
        public string Email { get; set; }
        public string PreviousPassword { get; set; }
        public string SecurityCode { get; set; }
        public string Password { get; set; }
    }
}
