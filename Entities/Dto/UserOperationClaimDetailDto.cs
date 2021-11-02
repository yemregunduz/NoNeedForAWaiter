using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class UserOperationClaimDetailDto:IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }
    }
}
