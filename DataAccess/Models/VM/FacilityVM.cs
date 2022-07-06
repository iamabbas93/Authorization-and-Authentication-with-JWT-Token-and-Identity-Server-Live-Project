using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.VM
{
    public class FacilityVM
    {
        public string status { get; set; }

        public string responseMessage { get; set; }

        public List<facility> data { get; set; }
    }



    public class facility
    {
        public string facilityID { get; set; }
        public string accountID { get; set; }
        public string nameOfFacility { get; set; }
        public string facilityType { get; set; }
        public string phoneNumber { get; set; }
        public string billingEmail { get; set; }
        public AddressVM address { get; set; }
        public bool help { get; set; }
        public bool aide { get; set; }
        public bool medical { get; set; }
        public bool isMain { get; set; }


        public MetaDataVM metaData { get; set; }

        public long createdAt { get; set; }
        public long createdAtMills { get; set; }
        public long updatedAt { get; set; }
        public long updatedAtMills { get; set; }

        public List<string> users { get; set; }


    }
}
