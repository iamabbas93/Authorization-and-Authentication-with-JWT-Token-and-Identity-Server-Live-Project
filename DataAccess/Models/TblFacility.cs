using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblFacility
    {
        public TblFacility()
        {
            TblPhysicians = new HashSet<TblPhysician>();
        }

        public int IkFacilityId { get; set; }
        public string LcFacilityId { get; set; }
        public int? LcAcountId { get; set; }
        public string NameOfFacility { get; set; }
        public string FacilityType { get; set; }
        public string PhoneNumber { get; set; }
        public string BillingEmail { get; set; }
        public bool? Help { get; set; }
        public bool? Aide { get; set; }
        public bool? Medical { get; set; }
        public bool? IsMain { get; set; }
        public int? CreatedAt { get; set; }
        public int? CreatedAtMills { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedAtMills { get; set; }
        public int? AddressId { get; set; }
        public int? MetaDataId { get; set; }

        public virtual TblAddress Address { get; set; }
        public virtual TblMetaDatum MetaData { get; set; }
        public virtual ICollection<TblPhysician> TblPhysicians { get; set; }
    }
}
