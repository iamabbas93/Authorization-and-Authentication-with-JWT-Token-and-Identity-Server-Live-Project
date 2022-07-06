using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblPhysician
    {
        public int PhysicianId { get; set; }
        public int? LcAcountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CreatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public string MiddleName { get; set; }
        public string LcUserId { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int? UpdatedAt { get; set; }
        public int? AddressId { get; set; }

        public virtual TblAddress Address { get; set; }
        public virtual TblFacility LcAcount { get; set; }
    }
}
