using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblAddress
    {
        public TblAddress()
        {
            TblFacilities = new HashSet<TblFacility>();
            TblPatients = new HashSet<TblPatient>();
            TblPhysicians = new HashSet<TblPhysician>();
        }

        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int? Zip { get; set; }

        public virtual ICollection<TblFacility> TblFacilities { get; set; }
        public virtual ICollection<TblPatient> TblPatients { get; set; }
        public virtual ICollection<TblPhysician> TblPhysicians { get; set; }
    }
}
