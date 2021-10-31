using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class UserDetailDto : IDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string Title { get; set; }
        public string UserImagePath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
