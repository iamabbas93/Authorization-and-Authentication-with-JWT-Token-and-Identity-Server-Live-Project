using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblLocation
    {
        public TblLocation()
        {
            TblDevices = new HashSet<TblDevice>();
        }

        public int LocId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int? LcDeviceId { get; set; }

        public virtual ICollection<TblDevice> TblDevices { get; set; }
    }
}
