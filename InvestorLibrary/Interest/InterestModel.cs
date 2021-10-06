using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Interest
{
    public static class _interest
    {
        public const string InterestRate = "InterestRate";
        public const string investment_interest_rate = "investment_interest_rate";

        //public const string OldInterestRate = "oldRate";
        //public const string NewInterestRate = "newRate";
        //public const string InterestChangeDate = "changeDate";

        public const string Selected = "Selected";
        public const string NewInterestRate = "NewInterestRate";
        public const string EffectiveDate = "EffectiveDate";
    }

    public class InterestRateModel
    {
        public double interest_rate { get; set; }

        public string InterestRate => string.Format("{0:N2}", double.Parse(interest_rate.ToString()));
    }



    public class InterestViewModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }

        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }

        public double? Amount { get; set; }
        public double? InterestRate { get; set; }

        public string Investor => $"{investor_name} {investor_surname}";

        public string Opportunity => $"{opportunity_code} {opportunity_name}";

        public double? NewInterestRate { get; set; }
        public bool? Selected { get; set; }
    }


    public class InterestQuery
    {
        public string InterestRate { get; set; }
        public string EffectiveDate { get; set; }
    }




}
