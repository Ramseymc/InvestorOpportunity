using InvestorLibrary.Investor;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Opportunity;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Investment
{
    
    public interface IInvestmentRepository
    {
        Task<IEnumerable<InvestmentViewModel>> GetAllList();
        Task<IEnumerable<InvestmentViewModel>> GetAll();
        Task<IEnumerable<InvestmentViewModel>> GetWhere(string filter, string id);
        Task<InvestmentViewModel> GetById(string Id);
        Task<InvestmentViewModel> Add(InvestmentModel model);
        Task<InvestmentViewModel> Update(InvestmentModel model);
        Task<InvestmentViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<InvestmentModel> model);
        Task<IEnumerable<InvestmentListModel>> GetByInvestor(string Id);
        Task<IEnumerable<InvestmentListModel>> GetByOpportunity(string Id);
        Task<IEnumerable<InvestmentRolloverListModel>> GetByOpportunitySummary(string Id);
        Task CreateRollover(RolloverModel model);
        Task<IEnumerable<InvestmentReportModel>> ReportGetWhere(InvestmentReportQuery model);
        Task<IEnumerable<InvestorStatementModel>> ReportStatementsGetWhere(InvestmentReportQuery model);
        Task<IEnumerable<InvestmentReportModel>> ReportWithDates();
        Task<IEnumerable<OpportunityTotalModel>> GetOpportunityTotals();
        Task UpdateInvestmentTransfers(IEnumerable<InvestmentRolloverListModel> model);
    }


    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IDataAccessRepository _dataRepository;
        private readonly IInvestPledgeRepository _investPledgeRepository;

        public InvestmentRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
            _investPledgeRepository = (IInvestPledgeRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestPledgeRepository));
        }


        public async Task<IEnumerable<InvestmentViewModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetAllList";

            var modelData = await _dataRepository.GetAll<InvestmentViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestmentViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetAll";

            var modelData = await _dataRepository.GetAll<InvestmentViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestmentViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<InvestmentViewModel>(param);

            return modelData;
        }


        public async Task<InvestmentViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetById";
            param.Records.Add(new RecordValue { Name = _investment.investment_id, Value = Id });

            var modelData = await _dataRepository.GetById<InvestmentViewModel>(param);

            return modelData;
        }


        public async Task<InvestmentViewModel> Add(InvestmentModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_Create";

            var modelData = await _dataRepository.Create<InvestmentModel>(param, model);

            return new InvestmentViewModel(modelData);
        }

        public async Task<InvestmentViewModel> Update(InvestmentModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_Update";
            param.Records.Add(new RecordValue { Name = _investment.investment_id, Value = model.investment_id.ToString() });

            var modelData = await _dataRepository.Update<InvestmentModel>(param, model);

            return new InvestmentViewModel(modelData);
        }

        public async Task<InvestmentViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_Delete";
            param.Records.Add(new RecordValue { Name = _investment.investment_id, Value = id });

            var modelData = await _dataRepository.Delete<InvestmentModel>(param);

            return new InvestmentViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<InvestmentModel> model)
        {
            foreach (var item in model)
            {
                if (item.investment_id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spInvestments_Create";
                    await _dataRepository.Create<InvestmentModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spInvestments_Update";
                    await _dataRepository.Update<InvestmentModel>(param, item);
                }
            }

        }


        public async Task<IEnumerable<InvestmentListModel>> GetByInvestor(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetByInvestor";
            param.Records.Add(new RecordValue { Name = _investment.investor_id, Value = Id });

            var modelData = await _dataRepository.GetWhere<InvestmentListModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestmentListModel>> GetByOpportunity(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetByOpportunity";
            param.Records.Add(new RecordValue { Name = _investment.opportunity_id, Value = Id });

            var modelData = await _dataRepository.GetWhere<InvestmentListModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestmentRolloverListModel>> GetByOpportunitySummary(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestments_GetByOpportunitySummary";
            param.Records.Add(new RecordValue { Name = _investment.opportunity_id, Value = Id });

            var modelData = await _dataRepository.GetWhere<InvestmentRolloverListModel>(param);

            return modelData;
        }



        public async Task CreateRollover(RolloverModel model)
        {
            if (model.exit_rollover == 1)
            {
                var param = new QueryParams();
                param.Query = "spInvestments_Create";

                var investModel = new InvestmentModel(model);

                investModel.investment_amount = model.rollover_amount * -1;
                investModel.investment_interest_rate = model.org_interestRate;
                investModel.release_date = model.rollover_date;
                investModel.end_date = model.rollover_date;
                investModel.investment_exit_rollover = 1;
                investModel.transaction_type = 1;

                await _dataRepository.Create<InvestmentModel>(param, investModel);


                var pledgeParam = new QueryParams();
                pledgeParam.Query = "spInvestPledges_Create";

                var pledgeModel = new InvestPledgeModel(model);

                pledgeModel.opportunity_id = model.opportunity_id;
                pledgeModel.investment_amount = model.rollover_amount;
                pledgeModel.trust_interest_rate = model.rollover_interestRate;
                pledgeModel.deposit_date = model.rollover_date;

                await _dataRepository.Create<InvestPledgeModel>(pledgeParam, pledgeModel);
            }
            else
            {
                var param = new QueryParams();
                param.Query = "spInvestments_Create";

                var investModel = new InvestmentModel(model);

                investModel.investment_amount = model.rollover_amount * -1;
                investModel.investment_interest_rate = model.org_interestRate;
                investModel.release_date = model.rollover_date;
                investModel.end_date = model.rollover_date;
                investModel.investment_exit_rollover = 2;
                investModel.transaction_type = 4;

                await _dataRepository.Create<InvestmentModel>(param, investModel);
            }

        }



        public async Task<IEnumerable<InvestmentReportModel>> ReportGetWhere(InvestmentReportQuery model)
        {
            var param = new QueryParams();
            param.Query = "rpOpportunities_WithInvestors";
            param.Records.Add(new RecordValue { Name = _opportunity.OpportunityCodeFrom, Value = model.OpportunityCodeFrom });
            param.Records.Add(new RecordValue { Name = _opportunity.OpportunityCodeTo, Value = model.OpportunityCodeTo });
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeFrom, Value = model.InvestorCodeFrom });
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeTo, Value = model.InvestorCodeTo });

            var modelData = await _dataRepository.GetWhere<InvestmentReportModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestorStatementModel>> ReportStatementsGetWhere(InvestmentReportQuery model)
        {
            var param = new QueryParams();
            param.Query = "rpInvestors_Statements";
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeFrom, Value = model.InvestorCodeFrom });
            param.Records.Add(new RecordValue { Name = _investor.InvestorCodeTo, Value = model.InvestorCodeTo });

            var modelData = await _dataRepository.GetWhere<InvestorStatementModel>(param);

            return modelData;
        }



        public async Task<IEnumerable<InvestmentReportModel>> ReportWithDates()
        {
            var param = new QueryParams();
            param.Query = "rpInvestors_WithDates";

            var modelData = await _dataRepository.GetAll<InvestmentReportModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<OpportunityTotalModel>> GetOpportunityTotals()
        {
            var param = new QueryParams();
            param.Query = "spInvestments_OpportunityTotals";

            var modelData = await _dataRepository.GetAll<OpportunityTotalModel>(param);

            return modelData;
        }


        public async Task UpdateInvestmentTransfers(IEnumerable<InvestmentRolloverListModel> model)
        {
            foreach (var item in model)
            {
                if (item.Selected == true)
                {
                    if (item.ExitRollover == "1")
                    {
                        var paramInvest = new QueryParams();
                        paramInvest.Query = "spInvestments_Create";

                        var investModel = new InvestmentModel(item);

                        investModel.investment_amount = item.ReleaseAmount * -1;
                        investModel.release_date = DateTime.Parse(item.ReleaseDate);
                        investModel.end_date = DateTime.Parse(item.ReleaseDate);
                        investModel.investment_interest_rate = item.investment_interest_rate;
                        investModel.investment_exit_rollover = long.Parse(item.ExitRollover);
                        investModel.transaction_type = 1;

                        var investData = await _dataRepository.Create<InvestmentModel>(paramInvest, investModel);

                        // Update the pledges with money being transferred.
                        var pledgeModel = new InvestPledgeModel(item);

                        pledgeModel.investment_amount = item.ReleaseAmount;
                        pledgeModel.deposit_date = DateTime.Parse(item.ReleaseDate);
                        pledgeModel.trust_interest_rate = item.ReleaseInterest;

                        var pledgeData = await _investPledgeRepository.Add(pledgeModel);
                    }
                    else
                    {
                        var paramInvest = new QueryParams();
                        paramInvest.Query = "spInvestments_Create";

                        var investModel = new InvestmentModel(item);

                        investModel.investment_amount = item.ReleaseAmount * -1;
                        investModel.release_date = DateTime.Parse(item.ReleaseDate);
                        investModel.end_date = DateTime.Parse(item.ReleaseDate);
                        investModel.investment_interest_rate = item.investment_interest_rate;
                        investModel.investment_exit_rollover = long.Parse(item.ExitRollover);
                        investModel.transaction_type = 2;

                        var investData = await _dataRepository.Create<InvestmentModel>(paramInvest, investModel);
                    }

                }
            }

        }



    }

}





