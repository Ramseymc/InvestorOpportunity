using InvestorLibrary.Interest;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace InvestorLibrary.Investment
{
    public static class _investment
    {
        public const string investment_id = "investment_id";
        public const string investor_id = "investor_id";
        public const string opportunity_id = "opportunity_id";
        public const string investment_exit_rollover = "investment_exit_rollover";
        public const string release_date = "release_date";
        public const string end_date = "end_date";
        public const string investment_interest_rate = "investment_interest_rate";
        public const string transaction_type = "transaction_type";
        public const string blocked = "blocked";

        public const string rollover_amount = "rollover_amount";
        public const string rollover_date = "rollover_date";
        public const string ReleaseDate = "ReleaseDate";
        public const string ReleaseAmount = "ReleaseAmount";
        public const string ReleaseInterest = "ReleaseInterest";
    }

    public class InvestmentModel : BaseModel
    {
        public long? investment_id { get; set; }
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public double? investment_amount { get; set; }
        public long? investment_exit_rollover { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? investment_interest_rate { get; set; }
        public long? transaction_type { get; set; }
        public bool? blocked { get; set; }

        public InvestmentModel()
        {
        }

        public InvestmentModel(long? _investment_id, long? _investor_id, long? _opportunity_id, double? _investment_amount, long? _investment_exit_rollover, DateTime? _release_date, DateTime? _end_date, double? _investment_interest_rate, long? _transaction_type, bool _blocked)
        {
            investment_id = _investment_id;
            investor_id = _investor_id;
            opportunity_id = _opportunity_id;
            investment_amount = _investment_amount;
            investment_exit_rollover = _investment_exit_rollover;
            release_date = _release_date;
            end_date = _end_date;
            investment_interest_rate = _investment_interest_rate;
            transaction_type = _transaction_type;
            blocked = _blocked;
        }

        public InvestmentModel(InvestmentViewModel model)
        {
            investment_id = model.investment_id;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = model.investment_amount;
            investment_exit_rollover = model.investment_exit_rollover;
            release_date = model.release_date;
            end_date = model.end_date;
            investment_interest_rate = model.investment_interest_rate;
            transaction_type = model.transaction_type;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }


        public InvestmentModel(InterestViewModel model)
        {
            investment_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = null;
            investment_exit_rollover = null;
            release_date = null;
            end_date = null;
            investment_interest_rate = null;
            transaction_type = 6;
            blocked = true;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }


        public InvestmentModel(RolloverModel model)
        {
            investment_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.org_opportunity;
            investment_amount = null;
            investment_exit_rollover = null;
            release_date = null;
            end_date = null;
            investment_interest_rate = null;
            transaction_type = null;
            blocked = true;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }


        public InvestmentModel(InvestmentRolloverListModel model)
        {
            investment_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.org_opportunity_id;
            investment_amount = null;
            investment_exit_rollover = null;
            release_date = null;
            end_date = null;
            investment_interest_rate = null;
            transaction_type = null;
            blocked = true;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }



        public InvestmentModel(InvestPledgeModel model)
        {
            investment_id = null;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = model.investment_amount;
            investment_exit_rollover = null;
            release_date = model.release_date;
            end_date = model.end_date;
            investment_interest_rate = model.investment_interest_rate;
            transaction_type = null;
            blocked = true;
            DateCreated = DateTime.Now;
            LastUpdated = DateTime.Now;
        }

    }


    public class InvestmentViewModel : BaseModel
    {
        public long? investment_id { get; set; }
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public double? investment_amount { get; set; }
        public long? investment_exit_rollover { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? investment_interest_rate { get; set; }
        public long? transaction_type { get; set; }
        public bool? blocked { get; set; }



        public InvestmentViewModel()
        {
        }


        public InvestmentViewModel(InvestmentModel model)
        {
            investment_id = model.investment_id;
            investor_id = model.investor_id;
            opportunity_id = model.opportunity_id;
            investment_amount = model.investment_amount;
            investment_exit_rollover = model.investment_exit_rollover;
            release_date = model.release_date;
            end_date = model.end_date;
            investment_interest_rate = model.investment_interest_rate;
            transaction_type = model.transaction_type;
            blocked = model.blocked;
            DateCreated = model.DateCreated;
            LastUpdated = model.LastUpdated;
        }
    }


    public class InvestmentListModel
    {
        public long? investment_id { get; set; }
        public long? investor_id { get; set; }
        public string Account { get; set; }
        public string Investor { get; set; }

        public long? opportunity_id { get; set; }
        public string Code { get; set; }
        public string Opportunity { get; set; }

        public double? investment_amount { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public double? investment_interest_rate { get; set; }

        public string ExitRollover { get; set; }
        public string TransactionType { get; set; }
        public bool? blocked { get; set; }

        public string CodeInvestor => $"{Account} {Investor}";
        public string CodeOpportunity => $"{Code} {Opportunity}";
    }


    public class RolloverModel
    {
        public long? investor_id { get; set; }
        public long? opportunity_id { get; set; }
        public double? rollover_amount { get; set; }
        public double? rollover_interestRate { get; set; }
        public DateTime? rollover_date { get; set; }
        public long? exit_rollover { get; set; }
        public long? org_opportunity { get; set; }
        public double? org_interestRate { get; set; }

        public RolloverModel()
        {
        }

        public RolloverModel(long? _investor_id, long? _opportunity_id, double? _rollover_amount, double? _rollover_interestRate, DateTime? _rollover_date, long? _exit_rollover, long? _org_opportunity, double? _org_interestRate)
        {
            investor_id = _investor_id;
            opportunity_id = _opportunity_id;
            rollover_amount = _rollover_amount;
            rollover_interestRate = _rollover_interestRate;
            rollover_date = _rollover_date;
            exit_rollover = _exit_rollover;
            org_opportunity = _org_opportunity;
            org_interestRate = _org_interestRate;
        }

    }




    public class InvestmentRolloverListModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string Investor { get; set; }

        public long? org_opportunity_id { get; set; }
        public double? Amount { get; set; }
        public double? investment_interest_rate { get; set; }


        public string CodeInvestor => $"{investor_acc_number} {Investor}";
        public string CodeOpportunity => $"{Code} {Opportunity}";


        public string ExitRollover { get; set; }
        public long? opportunity_id { get; set; }
        public string Code { get; set; }
        public string Opportunity { get; set; }

        public string ReleaseDate { get; set; }
        public double? ReleaseAmount { get; set; }
        public double? ReleaseInterest { get; set; }
        public bool? Selected { get; set; }
    }



    public class InvestmentReportModel
    {
        public string Type { get; set; }
        public long? investment_id { get; set; }
        public long? investor_id { get; set; }

        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }

        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }

        public double? investment_amount { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? deposit_date { get; set; }
        public DateTime? release_date { get; set; }
        public DateTime? end_date { get; set; }
        public DateTime? lastUpdated { get; set; }
        public double? investment_interest_rate { get; set; }


        public double? opportunity_amount_required { get; set; }
        public DateTime? opportunity_start_date { get; set; }
        public DateTime? opportunity_end_date { get; set; }
        public double? opportunity_interest_rate { get; set; }

        public string NameSurname => $"{investor_name} {investor_surname}";
    }


    public class InvestorStatementModel
    {
        public long? investor_id { get; set; }
        public string investor_acc_number { get; set; }
        public string investor_name { get; set; }
        public string investor_surname { get; set; }

        public long? opportunity_id { get; set; }
        public string opportunity_code { get; set; }
        public string opportunity_name { get; set; }

        public DateTime? Date { get; set; }
        public double? Amount { get; set; }
        public string Type { get; set; }
        public double? InterestRate { get; set; }
        public long? Days { get; set; }
        public double? CapitalBalance { get; set; }
        public double? InterestBalance { get; set; }
        public double? TotalBalance { get; set; }

        public string NameSurname => $"{investor_name} {investor_surname}";
    }



    public class InvestmentReportQuery
    {
        public string OpportunityCodeFrom { get; set; }
        public string OpportunityCodeTo { get; set; }
        public string InvestorCodeFrom { get; set; }
        public string InvestorCodeTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }


}

