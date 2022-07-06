using System;
using System.Collections.Generic;

#nullable disable

namespace DataAccess.Models
{
    public partial class TblPatient
    {
        public int PtId { get; set; }
        public string LcPatientId { get; set; }
        public string LcSecondaryId { get; set; }
        public string Mrn { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }
        public string Gender { get; set; }
        public int? LcAcountId { get; set; }
        public string LcFacilityId { get; set; }
        public int? LcdeviceId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string DeviceLanguage { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Telecom { get; set; }
        public string LcUserId { get; set; }
        public bool? Subscription { get; set; }
        public int? AddressId { get; set; }
        public int? MetaDataId { get; set; }
        public int? CreatedAt { get; set; }
        public int? CreatedAtMills { get; set; }
        public int? UpdatedAt { get; set; }
        public int? UpdatedAtMills { get; set; }
        public int? CustomerConsentTimestamp { get; set; }
        public int? TermsAndConditionTimestamp { get; set; }

        public virtual TblAddress Address { get; set; }
    }
}
