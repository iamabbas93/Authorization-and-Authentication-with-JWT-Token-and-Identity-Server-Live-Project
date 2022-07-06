using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblHealthDatum
    {
        public int HdId { get; set; }
        public string LcPatientId { get; set; }
        public int? CreatedAt { get; set; }
        public int? SecondaryId { get; set; }
        public int? LcDeviceId { get; set; }
        public int? Btid { get; set; }
        public string Pulse { get; set; }
        public string Oxygen { get; set; }
        public string Sys { get; set; }
        public string Dia { get; set; }
    }
}
