using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblAlarm
    {
        public int AlarmId { get; set; }
        public double? LessThan { get; set; }
        public string Type { get; set; }
        public string DiffDays { get; set; }
        public double? GreaterThan { get; set; }
        public string LastReading { get; set; }
    }
}
