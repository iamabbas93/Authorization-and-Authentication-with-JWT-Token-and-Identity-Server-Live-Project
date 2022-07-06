using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblThreshold
    {
        public int FacThresId { get; set; }
        public double? MaxValue { get; set; }
        public double? MinValue { get; set; }
        public int? AlarmId { get; set; }
        public int? AlarmCcId { get; set; }
        public int? AlertId { get; set; }
        public string Source { get; set; }
        public string Name { get; set; }
        public string Uom { get; set; }
        public string SetBy { get; set; }
        public string Acronym { get; set; }
        public string Type { get; set; }
        public int? LcThresholdId { get; set; }
        public string Status { get; set; }
        public int? CreatedAt { get; set; }
        public int? UpdatedAt { get; set; }
        public int? NotMerge { get; set; }
        public int? StagesId { get; set; }
        public int? LcLevelId { get; set; }
        public string LcPatientId { get; set; }
    }
}
