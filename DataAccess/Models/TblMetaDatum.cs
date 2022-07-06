using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblMetaDatum
    {
        public TblMetaDatum()
        {
            TblFacilities = new HashSet<TblFacility>();
        }

        public int MetaDataId { get; set; }
        public int? LcMyMetaData { get; set; }
        public int? IkFacilityId { get; set; }
        public int? LcFacilityId { get; set; }

        public virtual ICollection<TblFacility> TblFacilities { get; set; }
    }
}
