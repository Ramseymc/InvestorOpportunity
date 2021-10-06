using InvestorLibrary.Investment;
using InvestorLibrary.Opportunity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.InvestPledge
{
    public interface IInvestPledgeRepository
    {
        Task<IEnumerable<InvestPledgeViewModel>> GetAllList();
        Task<IEnumerable<InvestPledgeViewModel>> GetAll();
        Task<IEnumerable<InvestPledgeViewModel>> GetWhere(string filter, string id);
        Task<InvestPledgeViewModel> GetById(string Id);
        Task<InvestPledgeViewModel> Add(InvestPledgeModel model);
        Task<InvestPledgeViewModel> Update(InvestPledgeModel model);
        Task<InvestPledgeViewModel> Remove(string id);
        Task AddUpdateBulk(IEnumerable<InvestPledgeModel> model);
        Task<IEnumerable<InvestPledgeListModel>> GetByInvestor(string Id, bool status);
        Task<InvestPledgeViewModel> TransferPledge(string Id);
        Task<IEnumerable<OpportunityTotalModel>> GetOpportunityTotals();
    }


    public class InvestPledgeRepository : IInvestPledgeRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public InvestPledgeRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }


        public async Task<IEnumerable<InvestPledgeViewModel>> GetAllList()
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_GetAllList";

            var modelData = await _dataRepository.GetAll<InvestPledgeViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestPledgeViewModel>> GetAll()
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_GetAll";

            var modelData = await _dataRepository.GetAll<InvestPledgeViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InvestPledgeViewModel>> GetWhere(string field, string val)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_GetWhere";
            param.Records.Add(new RecordValue { Name = "FilterBy", Value = field });
            param.Records.Add(new RecordValue { Name = field, Value = val });

            var modelData = await _dataRepository.GetWhere<InvestPledgeViewModel>(param);


            return modelData;
        }


        public async Task<InvestPledgeViewModel> GetById(string Id)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_GetById";
            param.Records.Add(new RecordValue { Name = _investPledge.pledge_id, Value = Id });

            var modelData = await _dataRepository.GetById<InvestPledgeViewModel>(param);

            return modelData;
        }


        public async Task<InvestPledgeViewModel> Add(InvestPledgeModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_Create";

            var modelData = await _dataRepository.Create<InvestPledgeModel>(param, model);

            return new InvestPledgeViewModel(modelData);
        }

        public async Task<InvestPledgeViewModel> Update(InvestPledgeModel model)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_Update";
            param.Records.Add(new RecordValue { Name = _investPledge.pledge_id, Value = model.pledge_id.ToString() });

            var modelData = await _dataRepository.Update<InvestPledgeModel>(param, model);

            return new InvestPledgeViewModel(modelData);
        }

        public async Task<InvestPledgeViewModel> Remove(string id)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_Delete";
            param.Records.Add(new RecordValue { Name = _investPledge.pledge_id, Value = id });

            var modelData = await _dataRepository.Delete<InvestPledgeModel>(param);

            return new InvestPledgeViewModel(modelData);
        }

        public async Task AddUpdateBulk(IEnumerable<InvestPledgeModel> model)
        {
            foreach (var item in model)
            {
                if (item.pledge_id <= 0)
                {
                    var param = new QueryParams();
                    param.Query = "spInvestPledges_Create";
                    await _dataRepository.Create<InvestPledgeModel>(param, item);
                }
                else
                {
                    var param = new QueryParams();
                    param.Query = "spInvestPledges_Update";
                    await _dataRepository.Update<InvestPledgeModel>(param, item);
                }
            }

        }


        public async Task<IEnumerable<InvestPledgeListModel>> GetByInvestor(string Id, bool status)
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_GetByInvestor";
            param.Records.Add(new RecordValue { Name = _investPledge.investor_id, Value = Id });
            param.Records.Add(new RecordValue { Name = _investPledge.investment_transferred, Value = status.ToString() });

            var modelData = await _dataRepository.GetWhere<InvestPledgeListModel>(param);

            return modelData;
        }

        public async Task<InvestPledgeViewModel> TransferPledge(string Id)
        {
            var result = await GetById(Id);

            var pledgeModel = new InvestPledgeModel(result);

            pledgeModel.investment_transferred = true;

            var modelData = await Update(pledgeModel);

            // Cancel the original pledge.            
            var pledgeParam = new QueryParams();
            pledgeParam.Query = "spInvestPledges_Create";

            pledgeModel.investment_amount = pledgeModel.investment_amount * -1;
            pledgeModel.deposit_date = pledgeModel.release_date;
            pledgeModel.contract_signed_date = null;
            pledgeModel.end_date = null;
            pledgeModel.investment_interest_rate = null;
            pledgeModel.blocked = true;

            await _dataRepository.Create<InvestPledgeModel>(pledgeParam, pledgeModel);

            // Create a new investment with the investment interest rate.
            var param = new QueryParams();
            param.Query = "spInvestments_Create";

            var pledgeModel2 = new InvestPledgeModel(result);

            var investModel = new InvestmentModel(pledgeModel2);

            investModel.investment_exit_rollover = null;
            investModel.transaction_type = 2;

            await _dataRepository.Create<InvestmentModel>(param, investModel);

            return modelData;
        }



        public async Task<IEnumerable<OpportunityTotalModel>> GetOpportunityTotals()
        {
            var param = new QueryParams();
            param.Query = "spInvestPledges_OpportunityTotals";

            var modelData = await _dataRepository.GetAll<OpportunityTotalModel>(param);

            return modelData;
        }


    }
}
