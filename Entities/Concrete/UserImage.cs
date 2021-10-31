using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class UserImage : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserImagePath { get; set; }
        public DateTime Date { get; set; }
        public UserImage()
        {
            Date = DateTime.Now;
        }
    }
}
