using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IKonnect_LiveCare.Dtos.Requests
{

    public class DrChrono
    {
        public string address { get; set; }
        public AutoAccidentInsurance auto_accident_insurance { get; set; }
        public string cell_phone { get; set; }
        public string chart_id { get; set; }
        public string city { get; set; }
        public string copay { get; set; }
        public List<CustomDemographic> custom_demographics { get; set; }
        public string date_of_birth { get; set; }
        public string date_of_first_appointment { get; set; }
        public string date_of_last_appointment { get; set; }
        public string default_pharmacy { get; set; }
        public bool disable_sms_messages { get; set; }
        public int doctor { get; set; }
        public string email { get; set; }
        public string emergency_contact_name { get; set; }
        public string emergency_contact_phone { get; set; }
        public string emergency_contact_relation { get; set; }
        public string employer { get; set; }
        public string employer_address { get; set; }
        public string employer_city { get; set; }
        public string employer_state { get; set; }
        public string employer_zip_code { get; set; }
        public string ethnicity { get; set; }
        public string first_name { get; set; }
        public string gender { get; set; }
        public string home_phone { get; set; }
        public int id { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string nick_name { get; set; }
        public string office_phone { get; set; }
        public List<int> offices { get; set; }
        public List<PatientFlag> patient_flags { get; set; }
        public List<PatientFlagsAttached> patient_flags_attached { get; set; }
        public string patient_payment_profile { get; set; }
        public string patient_photo { get; set; }
        public string patient_photo_date { get; set; }
        public string patient_status { get; set; }
        public string preferred_language { get; set; }
        public string primary_care_physician { get; set; }
        public PrimaryInsurance primary_insurance { get; set; }
        public string race { get; set; }
        public ReferringDoctor referring_doctor { get; set; }
        public string referring_source { get; set; }
        public string responsible_party_email { get; set; }
        public string responsible_party_name { get; set; }
        public string responsible_party_phone { get; set; }
        public string responsible_party_relation { get; set; }
        public SecondaryInsurance secondary_insurance { get; set; }
        public string social_security_number { get; set; }
        public string state { get; set; }
        public TertiaryInsurance tertiary_insurance { get; set; }
        public string updated_at { get; set; }
        public WorkersCompInsurance workers_comp_insurance { get; set; }
        public string zip_code { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AutoAccidentInsurance
    {
        public string auto_accident_case_number { get; set; }
        public string auto_accident_claim_rep_address { get; set; }
        public string auto_accident_claim_rep_city { get; set; }
        public bool auto_accident_claim_rep_is_insurer { get; set; }
        public string auto_accident_claim_rep_name { get; set; }
        public string auto_accident_claim_rep_state { get; set; }
        public string auto_accident_claim_rep_zip { get; set; }
        public string auto_accident_company { get; set; }
        public string auto_accident_date_of_accident { get; set; }
        public string auto_accident_disabled_from_date { get; set; }
        public string auto_accident_disabled_to_date { get; set; }
        public bool auto_accident_had_similar_condition { get; set; }
        public bool auto_accident_is_subscriber_the_patient { get; set; }
        public string auto_accident_notes { get; set; }
        public string auto_accident_patient_relationship_to_subscriber { get; set; }
        public string auto_accident_payer_address { get; set; }
        public string auto_accident_payer_city { get; set; }
        public string auto_accident_payer_id { get; set; }
        public string auto_accident_payer_state { get; set; }
        public string auto_accident_payer_zip { get; set; }
        public string auto_accident_policy_number { get; set; }
        public string auto_accident_return_to_work_date { get; set; }
        public string auto_accident_significant_injury { get; set; }
        public string auto_accident_significant_injury_notes { get; set; }
        public string auto_accident_similar_condition_date { get; set; }
        public string auto_accident_similar_condition_notes { get; set; }
        public string auto_accident_state_of_occurrence { get; set; }
        public bool auto_accident_still_under_care { get; set; }
        public string auto_accident_subscriber_address { get; set; }
        public string auto_accident_subscriber_city { get; set; }
        public string auto_accident_subscriber_date_of_birth { get; set; }
        public string auto_accident_subscriber_first_name { get; set; }
        public string auto_accident_subscriber_last_name { get; set; }
        public string auto_accident_subscriber_middle_name { get; set; }
        public string auto_accident_subscriber_phone_number { get; set; }
        public string auto_accident_subscriber_social_security { get; set; }
        public string auto_accident_subscriber_state { get; set; }
        public string auto_accident_subscriber_suffix { get; set; }
        public string auto_accident_subscriber_zip_code { get; set; }
        public string auto_accident_treatment_duration { get; set; }
        public bool auto_accident_will_require_therapy { get; set; }
        public string auto_accident_will_require_therapy_rec { get; set; }
    }

    public class CustomDemographic
    {
        public int field_type { get; set; }
        public string updated_at { get; set; }
        public string value { get; set; }
    }

    public class PatientFlag
    {
        public bool archived { get; set; }
        public string color { get; set; }
        public string created_at { get; set; }
        public int doctor { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
        public string updated_at { get; set; }
    }

    public class PatientFlagsAttached
    {
        public bool archived { get; set; }
        public string created_at { get; set; }
        public string flag_text { get; set; }
        public int flag_type { get; set; }
        public int id { get; set; }
        public string updated_at { get; set; }
    }

    public class PrimaryInsurance
    {
        public string insurance_claim_office_number { get; set; }
        public string insurance_company { get; set; }
        public string insurance_group_name { get; set; }
        public string insurance_group_number { get; set; }
        public string insurance_id_number { get; set; }
        public string insurance_payer_id { get; set; }
        public string insurance_plan_name { get; set; }
        public string insurance_plan_type { get; set; }
        public bool is_subscriber_the_patient { get; set; }
        public string patient_relationship_to_subscriber { get; set; }
        public string photo_back { get; set; }
        public string photo_front { get; set; }
        public string subscriber_address { get; set; }
        public string subscriber_city { get; set; }
        public string subscriber_country { get; set; }
        public string subscriber_date_of_birth { get; set; }
        public string subscriber_first_name { get; set; }
        public string subscriber_gender { get; set; }
        public string subscriber_last_name { get; set; }
        public string subscriber_middle_name { get; set; }
        public string subscriber_social_security { get; set; }
        public string subscriber_state { get; set; }
        public string subscriber_suffix { get; set; }
        public string subscriber_zip_code { get; set; }
    }

    public class ReferringDoctor
    {
        public string address { get; set; }
        public string email { get; set; }
        public string fax { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string npi { get; set; }
        public string phone { get; set; }
        public string provider_number { get; set; }
        public string provider_qualifier { get; set; }
        public string specialty { get; set; }
        public string suffix { get; set; }
    }

 

    public class SecondaryInsurance
    {
        public string insurance_claim_office_number { get; set; }
        public string insurance_company { get; set; }
        public string insurance_group_name { get; set; }
        public string insurance_group_number { get; set; }
        public string insurance_id_number { get; set; }
        public string insurance_payer_id { get; set; }
        public string insurance_plan_name { get; set; }
        public string insurance_plan_type { get; set; }
        public bool is_subscriber_the_patient { get; set; }
        public string patient_relationship_to_subscriber { get; set; }
        public string photo_back { get; set; }
        public string photo_front { get; set; }
        public string subscriber_address { get; set; }
        public string subscriber_city { get; set; }
        public string subscriber_country { get; set; }
        public string subscriber_date_of_birth { get; set; }
        public string subscriber_first_name { get; set; }
        public string subscriber_gender { get; set; }
        public string subscriber_last_name { get; set; }
        public string subscriber_middle_name { get; set; }
        public string subscriber_social_security { get; set; }
        public string subscriber_state { get; set; }
        public string subscriber_suffix { get; set; }
        public string subscriber_zip_code { get; set; }
    }

    public class TertiaryInsurance
    {
        public string insurance_claim_office_number { get; set; }
        public string insurance_company { get; set; }
        public string insurance_group_name { get; set; }
        public string insurance_group_number { get; set; }
        public string insurance_id_number { get; set; }
        public string insurance_payer_id { get; set; }
        public string insurance_plan_name { get; set; }
        public string insurance_plan_type { get; set; }
        public bool is_subscriber_the_patient { get; set; }
        public string patient_relationship_to_subscriber { get; set; }
        public string photo_back { get; set; }
        public string photo_front { get; set; }
        public string subscriber_address { get; set; }
        public string subscriber_city { get; set; }
        public string subscriber_country { get; set; }
        public string subscriber_date_of_birth { get; set; }
        public string subscriber_first_name { get; set; }
        public string subscriber_gender { get; set; }
        public string subscriber_last_name { get; set; }
        public string subscriber_middle_name { get; set; }
        public string subscriber_social_security { get; set; }
        public string subscriber_state { get; set; }
        public string subscriber_suffix { get; set; }
        public string subscriber_zip_code { get; set; }
    }

    public class WorkersCompInsurance
    {
        public string property_and_casualty_agency_claim_number { get; set; }
        public string workers_comp_carrier_code { get; set; }
        public string workers_comp_case_number { get; set; }
        public string workers_comp_company { get; set; }
        public string workers_comp_date_of_accident { get; set; }
        public string workers_comp_group_name { get; set; }
        public string workers_comp_group_number { get; set; }
        public string workers_comp_notes { get; set; }
        public string workers_comp_payer_address { get; set; }
        public string workers_comp_payer_city { get; set; }
        public string workers_comp_payer_id { get; set; }
        public string workers_comp_payer_state { get; set; }
        public string workers_comp_payer_zip { get; set; }
        public string workers_comp_state_of_occurrence { get; set; }
        public string workers_comp_wcb { get; set; }
        public string workers_comp_wcb_rating_code { get; set; }
    }


}
