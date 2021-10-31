using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class UserForRegisterDto:IDto
    {
        public string Email { get; set; }
        public int RestaurantId { get; set; }
        public string Password { get; set; }
        public int TitleId { get; set; }
        public decimal Salary { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserImagePath { get; set; }
        public bool Status { get; set; }
    }
}
