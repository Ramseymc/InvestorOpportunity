using InvestorLibrary.Interest;
using InvestorLibrary.Investment;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace InvestorLibrary.InvestPledge
{
    public static class _investPledge
    {
        public const string pledge_id = "pledge_id";
        public const string investor_id = "investor_id";
        public const string opportunity_id = "opportunity_id";
        public const string investment_amount = "investment_amount";
        public const string contract_signed_date = "contract_signed_date";
        public const string deposit_date = "deposit_date";
        public const string release_date = "release_date";
        public const string end_date = "end_date";
        public const string trust_interest_rate = "trust_interest_rate";
        public const string investment_interest_rate = "investment_interest_rate";
        public const string investment_transferred = "investment_transferred";
        public const string blocked = "blocked";
    }


    public class InvestPledgeModel : BaseModel
    {
        public long? pledge_id { get; set; }
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public double? investment_amount { get; set; }
        public DateTime? contract_signed_date { get; set; }
        public DateTime? deposit_date { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? trust_interest_rate { get; set; }
        public double? investment_interest_rate { get; set; }
        public bool? investment_transferred { get; set; }
        public bool? blocked { get; set; }

        public InvestPledgeModel()
        {
        }


        public InvestPledgeModel(long? _pledge_id, long? _investor_id, long? _opportunity_id, double? _investment_amount, DateTime? _contract_signed_date, DateTime? _deposit_date, DateTime? _release_date, DateTime? _end_date, double? _trust_interest_rate, double? _investment_interest_rate, bool _investment_transferred, bool _blocked)
        {
            pledge_id = _pledge_id;
            investor_id = _investor_id;
            opportunity_id = _opportunity_id;
            investment_amount = _investment_amount;
            contract_signed_date = _contract_signed_date;
            deposit_date = _deposit_date;
            release_date = _release_date;
            end_date = _end_date;
            trust_interest_rate = _trust_interest_rate;
            investment_interest_rate = _investment_interest_rate;
            investment_transferred = _investment_transferred;
            blocked = _blocked;
        }

        public InvestPledgeModel(InvestPledgeViewModel model)
        {
            pledge_id = model.pledge_id;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = model.investment_amount;
            contract_signed_date = model.contract_signed_date;
            deposit_date = model.deposit_date;
            release_date = model.release_date;
            end_date = model.end_date;
            trust_interest_rate = model.trust_interest_rate;
            investment_interest_rate = model.investment_interest_rate;
            investment_transferred = model.investment_transferred;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }


        public InvestPledgeModel(InterestViewModel model)
        {
            pledge_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = null;
            contract_signed_date = null;
            deposit_date = null;
            release_date = null;
            end_date = null;
            trust_interest_rate = null;
            investment_interest_rate = null;
            investment_transferred = false;
            blocked = true;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }


        public InvestPledgeModel(RolloverModel model)
        {
            pledge_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.org_opportunity;
            investment_amount = null;
            contract_signed_date = null;
            deposit_date = null;
            release_date = null;
            end_date = null;
            trust_interest_rate = null;
            investment_interest_rate = null;
            investment_transferred = false;
            blocked = false;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }


        public InvestPledgeModel(InvestmentRolloverListModel model)
        {
            pledge_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = null;
            contract_signed_date = null;
            deposit_date = null;
            release_date = null;
            end_date = null;
            trust_interest_rate = null;
            investment_interest_rate = null;
            investment_transferred = false;
            blocked = false;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

    }


    public class InvestPledgeViewModel : BaseModel
    {
        public long? pledge_id { get; set; }
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public double? investment_amount { get; set; }
        public DateTime? contract_signed_date { get; set; }
        public DateTime? deposit_date { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? trust_interest_rate { get; set; }
        public double? investment_interest_rate { get; set; }
        public bool? investment_transferred { get; set; }
        public bool? blocked { get; set; }


        public InvestPledgeViewModel()
        {
        }

        public InvestPledgeViewModel(InvestPledgeModel model)
        {
            pledge_id = model.pledge_id;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = model.investment_amount;
            contract_signed_date = model.contract_signed_date;
            deposit_date = model.deposit_date;
            release_date = model.release_date;
            end_date = model.end_date;
            trust_interest_rate = model.trust_interest_rate;
            investment_interest_rate = model.investment_interest_rate;
            investment_transferred = model.investment_transferred;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class InvestPledgeListModel
    {
        public long? pledge_id { get; set; }
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public string Code { get; set; }
        public string Opportunity { get; set; }

        public double? investment_amount { get; set; }
        public DateTime? contract_signed_date { get; set; }
        public DateTime? deposit_date { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? trust_interest_rate { get; set; }
        public double? investment_interest_rate { get; set; }
        public bool? investment_transferred { get; set; }
        public bool? blocked { get; set; }
    }



}








