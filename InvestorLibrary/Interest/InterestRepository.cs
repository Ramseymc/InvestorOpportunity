using InvestorLibrary.Investment;
using InvestorLibrary.InvestPledge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InvestorLibrary.Interest
{
      public interface IInterestRepository
    {
        Task<IEnumerable<InterestRateModel>> GetAllRates();
        Task<IEnumerable<InterestViewModel>> GetPledgesRateSummary(InterestQuery model);
        Task<IEnumerable<InterestViewModel>> GetInvestmentsRateSummary(InterestQuery model);
        Task UpdateInvestmentRates(IEnumerable<InterestViewModel> model, string date);
        Task UpdatePledgeRates(IEnumerable<InterestViewModel> model, string date);
    }

    public class InterestRepository : IInterestRepository
    {
        private readonly IDataAccessRepository _dataRepository;

        public InterestRepository()
        {
            _dataRepository = (IDataAccessRepository)ContainerConfig.ServiceProvider.GetService(typeof(IDataAccessRepository));
        }

        public async Task<IEnumerable<InterestRateModel>> GetAllRates()
        {
            var param = new QueryParams();
            param.Query = "spInterestRates_GetList";

            var modelData = await _dataRepository.GetAll<InterestRateModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InterestViewModel>> GetInvestmentsRateSummary(InterestQuery model)
        {
            var param = new QueryParams();
            param.Query = "spInterestRates_GetByRateSummary_Investments";
            param.Records.Add(new RecordValue { Name = _interest.InterestRate, Value = model.InterestRate });
            param.Records.Add(new RecordValue { Name = _interest.EffectiveDate, Value = model.EffectiveDate });

            var modelData = await _dataRepository.GetWhere<InterestViewModel>(param);

            return modelData;
        }


        public async Task<IEnumerable<InterestViewModel>> GetPledgesRateSummary(InterestQuery model)
        {
            var param = new QueryParams();
            param.Query = "spInterestRates_GetByRateSummary_Pledges";
            param.Records.Add(new RecordValue { Name = _interest.InterestRate, Value = model.InterestRate });
            param.Records.Add(new RecordValue { Name = _interest.EffectiveDate, Value = model.EffectiveDate });

            var modelData = await _dataRepository.GetWhere<InterestViewModel>(param);

            return modelData;
        }

        public async Task UpdateInvestmentRates(IEnumerable<InterestViewModel> model, string date)
        {
            foreach (var item in model)
            {
                if (item.Selected == true)
                {
                    var param = new QueryParams();
                    param.Query = "spInvestments_Create";

                    var investModel = new InvestmentModel(item);
                    investModel.investment_amount = item.Amount * -1;
                    investModel.release_date = DateTime.Parse(date);
                    investModel.investment_interest_rate = item.InterestRate;

                    var modelData = await _dataRepository.Create<InvestmentModel>(param, investModel);

                    investModel = new InvestmentModel(item);

                    investModel.investment_amount = item.Amount;
                    investModel.release_date = DateTime.Parse(date);
                    investModel.investment_interest_rate = item.NewInterestRate;

                    modelData = await _dataRepository.Create<InvestmentModel>(param, investModel);
                }
            }
        }


        public async Task UpdatePledgeRates(IEnumerable<InterestViewModel> model, string date)
        {
            foreach (var item in model)
            {
                if (item.Selected == true)
                {
                    var param = new QueryParams();
                    param.Query = "spInvestPledges_Create";

                    var pledgeModel = new InvestPledgeModel(item);
                    pledgeModel.investment_amount = item.Amount * -1;
                    pledgeModel.deposit_date = DateTime.Parse(date);
                    pledgeModel.trust_interest_rate = item.InterestRate;

                    var modelData = await _dataRepository.Create<InvestPledgeModel>(param, pledgeModel);

                    pledgeModel = new InvestPledgeModel(item);

                    pledgeModel.investment_amount = item.Amount;
                    pledgeModel.deposit_date = DateTime.Parse(date);
                    pledgeModel.trust_interest_rate = item.NewInterestRate;

                    modelData = await _dataRepository.Create<InvestPledgeModel>(param, pledgeModel);
                }
            }
        }


    }

}
