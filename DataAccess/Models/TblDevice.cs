using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblDevice
    {
        public int IkDeviceId { get; set; }
        public int? LcDeviceId { get; set; }
        public string LcFacilityId { get; set; }
        public string LcAcountId { get; set; }
        public string LcPatientId { get; set; }
        public string SimNumber { get; set; }
        public string SerialNumber { get; set; }
        public int? BatteryLevel { get; set; }
        public int? BatteryUpdatedOn { get; set; }
        public string Status { get; set; }
        public int? CreatedAt { get; set; }
        public int? CreatedAtMills { get; set; }
        public int? CreatedAtMillis { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedAtMills { get; set; }
        public int? UpdatedAtMillis { get; set; }
        public int? LocId { get; set; }
        public string Btmac { get; set; }
        public string Btname { get; set; }
        public string Type { get; set; }

        public virtual TblLocation Loc { get; set; }
    }
}
