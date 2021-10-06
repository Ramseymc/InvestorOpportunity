using InvestorLibrary;
using InvestorLibrary.Interest;
using InvestorLibrary.Investment;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestorUI
{
    class InterestUpdateController
    {
        private readonly ISharedRepository _sharedRepository;
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IInvestPledgeRepository _investPledgeRepository;
        private readonly IInterestRepository _interestRepository;

        InterestUpdateForm _form;
        public InterestUpdateController(InterestUpdateForm form)
        {
            _sharedRepository = (ISharedRepository)ContainerConfig.ServiceProvider.GetService(typeof(ISharedRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));
            _investPledgeRepository = (IInvestPledgeRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestPledgeRepository));
            _interestRepository = (IInterestRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInterestRepository));

            _form = form;
        }

        //public void LoadFormData(InvestmentViewModel model)
        //{
        //    LoadFormFields(model);

        //    _form.comboInvestor.SelectItemByValue(model.investor_id.ToString());
        //    _form.comboOpportunity.SelectItemByValue(model.opportunity_id.ToString());
        //    _form.comboTransactionType.SelectItemByValue(model.transaction_type.ToString());

        //    //_form.comboRollover.SelectItemByValue(model.userId.ToString())
        //    //_form.LoadRolloverOpportunityCombo.SelectItemByValue(model.userId.ToString())
        //}


        //public async void LoadSearchList()
        //{
        //    var model = await _interestRepository.GetAllRates();

        //    var result = model.ToList();
        //    _form.comboSearchList.DataSource = result;
        //    _form.comboSearchList.DisplayMember = _interest.InterestRate;
           
        //    _form.comboSearchList.ValueMember = _interest.InterestRate;

        //    _form.comboSearchList.SelectedItem = null;
        //}


        public async void UpdateInvestmentData()
        {
            var queryModel = new InterestQuery();

            //    var result = await _interestRepository.GetInvestmentsRateSummary(selected.investment_interest_rate.ToString());

            var rate = _form.textOldInterestRate.Text.GetDoubleValue();

            queryModel.InterestRate = rate.ToString();
            queryModel.EffectiveDate = _form.dateChangeDate.Value.ToString("yyyy-MM-dd");

            await LoadInvestmentRateList(queryModel);

            await LoadInvestPledgesRateList(queryModel);
        }


        public async Task LoadInvestmentRateList(InterestQuery model)
        {
            var result = await _interestRepository.GetInvestmentsRateSummary(model);

            if (result != null)
            {
                result = result.Where(x => x.Amount > 0).ToList();

                _form.gridInvestments.AutoGenerateColumns = false;

                _form.gridInvestments.DataSource = result.OrderBy(x => x.investor_acc_number).ToList();
                _form.gridInvestments.Refresh();
            }

        }


        public async Task LoadInvestPledgesRateList(InterestQuery model)
        {
            var result = await _interestRepository.GetPledgesRateSummary(model);

            if (result != null)
            {
                result = result.Where(x => x.Amount > 0).ToList();

                _form.gridInvestPledges.AutoGenerateColumns = false;

                _form.gridInvestPledges.DataSource = result.OrderBy(x => x.investor_acc_number).ToList();
                _form.gridInvestPledges.Refresh();
            }

        }


    }
}




