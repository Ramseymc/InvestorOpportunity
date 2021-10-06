using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InvestorLibrary.Opportunity
{
    public static class _opportunity
    {
        public const string opportunity_id = "opportunity_id";
        public const string opportunity_code = "opportunity_code";
        public const string opportunity_name = "opportunity_name";
        public const string opportunity_amount_required = "opportunity_amount_required";
        public const string opportunity_start_date = "opportunity_start_date";
        public const string opportunity_end_date = "opportunity_end_date";
        public const string opportunity_interest_rate = "opportunity_interest_rate";
        public const string transfer_date = "transfer_date";
        public const string transfer_type = "transfer_type";
        public const string categoryId = "categoryId";
        public const string blocked = "blocked";

        public const string CodeName = "CodeName";

        public const string OpportunityCodeFrom = "OpportunityCodeFrom";
        public const string OpportunityCodeTo = "OpportunityCodeTo";
    }

    public class OpportunityModel : BaseModel
    {
        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }
        public double? opportunity_amount_required { get; set; }
        public DateTime? opportunity_start_date { get; set; }
        public DateTime? opportunity_end_date { get; set; }
        public double? opportunity_interest_rate { get; set; }
        public DateTime? transfer_date { get; set; }
        public long? transfer_type { get; set; }
        public long? categoryId { get; set; }
        public bool? blocked { get; set; }

        public OpportunityModel()
        {
        }

        public OpportunityModel(long? _opportunity_id, string _opportunity_code, string _opportunity_name, double? _opportunity_amount_required, DateTime? _opportunity_start_date, DateTime? _opportunity_end_date, double? _opportunity_interest_rate, DateTime? _transfer_date, long? _transfer_type, long? _categoryId, bool _blocked)
        {
            opportunity_id = _opportunity_id;
            opportunity_code = _opportunity_code;
            opportunity_name = _opportunity_name;
            opportunity_amount_required = _opportunity_amount_required;
            opportunity_start_date = _opportunity_start_date;
            opportunity_end_date = _opportunity_end_date;
            opportunity_interest_rate = _opportunity_interest_rate;
            transfer_date = _transfer_date;
            transfer_type = _transfer_type;
            categoryId = _categoryId;
            blocked = _blocked;
        }

        public OpportunityModel(OpportunityViewModel model)
        {
            opportunity_id = model.opportunity_id;
            opportunity_code = model.opportunity_code;
            opportunity_name = model.opportunity_name;
            opportunity_amount_required = model.opportunity_amount_required;
            opportunity_start_date = model.opportunity_start_date;
            opportunity_end_date = model.opportunity_end_date;
            opportunity_interest_rate = model.opportunity_interest_rate;
            transfer_date = model.transfer_date;
            transfer_type = model.transfer_type;
            categoryId = model.categoryId;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class OpportunityViewModel : BaseModel
    {
        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }
        public double? opportunity_amount_required { get; set; }
        public DateTime? opportunity_start_date { get; set; }
        public DateTime? opportunity_end_date { get; set; }
        public double? opportunity_interest_rate { get; set; }
        public DateTime? transfer_date { get; set; }
        public long? transfer_type { get; set; }
        public long? categoryId { get; set; }
        public bool? blocked { get; set; }


        public OpportunityViewModel()
        {
        }


        public OpportunityViewModel(OpportunityModel model)
        {
            opportunity_id = model.opportunity_id;
            opportunity_code = model.opportunity_code;
            opportunity_name = model.opportunity_name;
            opportunity_amount_required = model.opportunity_amount_required;
            opportunity_start_date = model.opportunity_start_date;
            opportunity_end_date = model.opportunity_end_date;
            opportunity_interest_rate = model.opportunity_interest_rate;
            transfer_date = model.transfer_date;
            transfer_type = model.transfer_type;
            categoryId = model.categoryId;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class OpportunityListModel
    {
        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }
        public bool? blocked { get; set; }

        public string CodeName => $"{opportunity_code} {opportunity_name}";
    }


    public class OpportunityReportModel
    {
        public long? categoryId { get; set; }
        public string Category { get; set; }
        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }
        public double? opportunity_amount_required { get; set; }
        public DateTime? opportunity_start_date { get; set; }
        public DateTime? opportunity_end_date { get; set; }
        public double? opportunity_interest_rate { get; set; }

    }


    public class OpportunityReportQuery
    {
        public string CategoryCodeFrom { get; set; }
        public string CategoryCodeTo { get; set; }
        public string OpportunityCodeFrom { get; set; }
        public string OpportunityCodeTo { get; set; }
    }


    public class OpportunityTotalModel
    {
        public long opportunity_id { get; set; }
        public double Amount { get; set; }
    }


}

