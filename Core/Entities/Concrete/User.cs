using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TcNo { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FixedPhoneNumber { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public DateTime? DateOfRecruitment { get; set; }
        public DateTime? DateOfDismissal { get; set; }
        public string Email { get; set; }
        public int TitleId { get; set; }
        public decimal Salary { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
