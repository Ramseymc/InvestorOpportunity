using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Investor
{
    public static class _investor
    {
        public const string investor_id = "investor_id";
        public const string investor_acc_number = "investor_acc_number";
        public const string investor_name = "investor_name";
        public const string investor_surname = "investor_surname";
        public const string investor_organisation = "investor_organisation";
        public const string investor_id_number = "investor_id";
        public const string investor_email = "investor_email";
        public const string investor_mobile = "investor_mobile";
        public const string investor_landline = "investor_landline";
        public const string investor_physical_street = "investor_physical_street";
        public const string investor_physical_suburb = "investor_physical_suburb";
        public const string investor_physical_province = "investor_physical_province";
        public const string investor_physical_country = "investor_physical_country";
        public const string investor_physical_postal_code = "investor_physical_postal_code";
        public const string investor_postal_street_box = "investor_postal_street_box";
        public const string investor_postal_suburb = "investor_postal_suburb";
        public const string investor_postal_province = "investor_postal_province";
        public const string investor_postal_country = "investor_postal_country";
        public const string investor_postal_postal_code = "investor_postal_postal_code";
        public const string investor_password = "investor_password";
        public const string investor_fica = "investor_fica";
        public const string investor_ficaDate = "investor_ficaDate";
        public const string investor_reference = "investor_reference";
        public const string userId = "userId";
        public const string blocked = "blocked";

        public const string CodeName = "CodeName";
        public const string NameCode = "NameCode";

 
        public const string InvestorCodeFrom = "InvestorCodeFrom";
        public const string InvestorCodeTo = "InvestorCodeTo";
    }


    public class InvestorModel : BaseModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }
        public string investor_organisation { get; set; }
        public string investor_id_number { get; set; }
        public string investor_email { get; set; }
        public string investor_mobile { get; set; }
        public string investor_landline { get; set; }
        public string investor_physical_street { get; set; }
        public string investor_physical_suburb { get; set; }
        public string investor_physical_province { get; set; }
        public string investor_physical_country { get; set; }
        public string investor_physical_postal_code { get; set; }
        public string investor_postal_street_box { get; set; }
        public string investor_postal_suburb { get; set; }
        public string investor_postal_province { get; set; }
        public string investor_postal_country { get; set; }
        public string investor_postal_postal_code { get; set; }
        public bool? investor_fica { get; set; }
        public DateTime? investor_ficaDate { get; set; }
        public string investor_reference { get; set; }
        public long? userId { get; set; }
        public bool? blocked { get; set; }

        public InvestorModel()
        {
        }


        public InvestorModel(long? _investor_id, string _investor_acc_number, string _investor_name, string _investor_surname, string _investor_organisation, string _investor_id_number, string _investor_email, string _investor_mobile, string _investor_landline, string _investor_physical_street, string _investor_physical_suburb, string _investor_physical_province, string _investor_physical_country, string _investor_physical_postal_code, string _investor_postal_street_box, string _investor_postal_suburb, string _investor_postal_province, string _investor_postal_country, string _investor_postal_postal_code, bool _investor_fica, DateTime? _investor_ficaDate, string _investor_reference, long? _userId, bool _blocked)
        {
            investor_id = _investor_id;
            investor_acc_number = _investor_acc_number;
            investor_name = _investor_name;
            investor_surname = _investor_surname;
            investor_organisation = _investor_organisation;
            investor_id_number = _investor_id_number;
            investor_email = _investor_email;
            investor_mobile = _investor_mobile;
            investor_landline = _investor_landline;
            investor_physical_street = _investor_physical_street;
            investor_physical_suburb = _investor_physical_suburb;
            investor_physical_province = _investor_physical_province;
            investor_physical_country = _investor_physical_country;
            investor_physical_postal_code = _investor_physical_postal_code;
            investor_postal_street_box = _investor_postal_street_box;
            investor_postal_suburb = _investor_postal_suburb;
            investor_postal_province = _investor_postal_province;
            investor_postal_country = _investor_postal_country;
            investor_postal_postal_code = _investor_postal_postal_code;
            investor_fica = _investor_fica;
            investor_ficaDate = _investor_ficaDate;
            investor_reference = _investor_reference;
            userId = _userId;
            blocked = _blocked;
        }


        public InvestorModel(InvestorViewModel model)
        {
            investor_id = model.investor_id;
            investor_acc_number = model.investor_acc_number;
            investor_name = model.investor_name;
            investor_surname = model.investor_surname;
            investor_organisation = model.investor_organisation;
            investor_id_number = model.investor_id_number;
            investor_email = model.investor_email;
            investor_mobile = model.investor_mobile;
            investor_landline = model.investor_landline;
            investor_physical_street = model.investor_physical_street;
            investor_physical_suburb = model.investor_physical_suburb;
            investor_physical_province = model.investor_physical_province;
            investor_physical_country = model.investor_physical_country;
            investor_physical_postal_code = model.investor_physical_postal_code;
            investor_postal_street_box = model.investor_postal_street_box;
            investor_postal_suburb = model.investor_postal_suburb;
            investor_postal_province = model.investor_postal_province;
            investor_postal_country = model.investor_postal_country;
            investor_postal_postal_code = model.investor_postal_postal_code;
            investor_fica = model.investor_fica;
            investor_ficaDate = model.investor_ficaDate;
            investor_reference = model.investor_reference;
            userId = model.userId;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class InvestorViewModel : BaseModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }
        public string investor_organisation { get; set; }
        public string investor_id_number { get; set; }
        public string investor_email { get; set; }
        public string investor_mobile { get; set; }
        public string investor_landline { get; set; }
        public string investor_physical_street { get; set; }
        public string investor_physical_suburb { get; set; }
        public string investor_physical_province { get; set; }
        public string investor_physical_country { get; set; }
        public string investor_physical_postal_code { get; set; }
        public string investor_postal_street_box { get; set; }
        public string investor_postal_suburb { get; set; }
        public string investor_postal_province { get; set; }
        public string investor_postal_country { get; set; }
        public string investor_postal_postal_code { get; set; }
        public bool? investor_fica { get; set; }
        public DateTime? investor_ficaDate { get; set; }
        public string investor_reference { get; set; }
        public long? userId { get; set; }
        public bool? blocked { get; set; }


        public InvestorViewModel()
        {
        }


        public InvestorViewModel(InvestorModel model)
        {
            investor_id = model.investor_id;
            investor_acc_number = model.investor_acc_number;
            investor_name = model.investor_name;
            investor_surname = model.investor_surname;
            investor_organisation = model.investor_organisation;
            investor_id_number = model.investor_id_number;
            investor_email = model.investor_email;
            investor_mobile = model.investor_mobile;
            investor_landline = model.investor_landline;
            investor_physical_street = model.investor_physical_street;
            investor_physical_suburb = model.investor_physical_suburb;
            investor_physical_province = model.investor_physical_province;
            investor_physical_country = model.investor_physical_country;
            investor_physical_postal_code = model.investor_physical_postal_code;
            investor_postal_street_box = model.investor_postal_street_box;
            investor_postal_suburb = model.investor_postal_suburb;
            investor_postal_province = model.investor_postal_province;
            investor_postal_country = model.investor_postal_country;
            investor_postal_postal_code = model.investor_postal_postal_code;
            investor_fica = model.investor_fica;
            investor_ficaDate = model.investor_ficaDate;
            investor_reference = model.investor_reference;
            userId = model.userId;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class InvestorListModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public bool? blocked { get; set; }

        public string CodeName => $"{investor_acc_number} {investor_name}";
        public string NameCode => $"{investor_name} {investor_acc_number}";
    }


    public class InvestorReportModel
    {
        public long? userId { get; set; }
        public string Username { get; set; }

        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }
        public string investor_organisation { get; set; }
        public string investor_id_number { get; set; }
        public string investor_email { get; set; }
        public string investor_mobile { get; set; }
        public string investor_landline { get; set; }
        public string investor_physical_street { get; set; }
        public string investor_physical_suburb { get; set; }
        public string investor_physical_province { get; set; }
        public string investor_physical_country { get; set; }
        public string investor_physical_postal_code { get; set; }
        public string investor_postal_street_box { get; set; }
        public string investor_postal_suburb { get; set; }
        public string investor_postal_province { get; set; }
        public string investor_postal_country { get; set; }
        public string investor_postal_postal_code { get; set; }
        public bool? investor_fica { get; set; }
        public DateTime? investor_ficaDate { get; set; }
        public string investor_reference { get; set; }

        public string NameSurname => $"{investor_name} {investor_surname}";

    }



    public class InvestorReportQuery
    {
        public string InvestorCodeFrom { get; set; }
        public string InvestorCodeTo { get; set; }
        public string UserCodeFrom { get; set; }
        public string UserCodeTo { get; set; }

    }


}


