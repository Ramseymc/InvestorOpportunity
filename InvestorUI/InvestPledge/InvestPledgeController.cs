using InvestorLibrary;
using InvestorLibrary.Investor;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Opportunity;
using InvestorLibrary.Shared;
using InvestorLibrary.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    class InvestPledgeController
    {
        private readonly IInvestPledgeRepository _investPledgeRepository;
        private readonly IUserRepository _userRepository;
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IInvestorRepository _investorRepository;

        InvestPledgeForm _form;
        public InvestPledgeController(InvestPledgeForm form)
        {
            _investPledgeRepository = (IInvestPledgeRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestPledgeRepository));
            _userRepository = (IUserRepository)ContainerConfig.ServiceProvider.GetService(typeof(IUserRepository));
            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));

            _form = form;
        }


        public void LoadFormData(InvestPledgeViewModel model)
        {
            LoadFormFields(model);

            _form.comboInvestor.SelectItemByValue(model.investor_id.ToString());
            _form.comboOpportunity.SelectItemByValue(model.opportunity_id.ToString());
        }


        public async void LoadSearchList()
        {
            var model = await _investorRepository.GetAllList();          

            if (_form.radioCode.Checked)
            {
                var result = model.Where(x => x.blocked == false).OrderBy(x => x.CodeName).ToList();
                _form.comboSearchList.DataSource = result;
                _form.comboSearchList.DisplayMember = _investor.CodeName;
            }
            else
            {
                var result = model.Where(x => x.blocked == false).OrderBy(x => x.NameCode).ToList();
                _form.comboSearchList.DataSource = result;
                _form.comboSearchList.DisplayMember = _investor.NameCode;
            }

            _form.comboSearchList.ValueMember = _investor.investor_id;

            _form.comboSearchList.SelectedItem = null;
        }


        public async Task LoadInvestmentsList(string Id)
        {
            var model = await _investPledgeRepository.GetByInvestor(Id, _form.checkIncludeTransferred.Checked);

            _form.gridInvestments.AutoGenerateColumns = false;

            _form.gridInvestments.DataSource = model.OrderBy(x => x.Code).ThenBy(x => x.deposit_date).ToList();
            _form.gridInvestments.Refresh();
        }


        public async Task GetInvestment()
        {
            var row = (DataGridViewRow)_form.gridInvestments.CurrentRow;

            var recordId = row.Cells[_investPledge.pledge_id].Value;

            var result = await _investPledgeRepository.GetById(recordId.ToString());

            LoadFormData(result);
        }



        public async void LoadInvestorCombo()
        {
            var result = await _investorRepository.GetAllList();

            _form.comboInvestor.DataSource = result.Where(x => x.blocked == false).OrderBy(x => x.CodeName).ToList();
            _form.comboInvestor.DisplayMember = _investor.CodeName;
            _form.comboInvestor.ValueMember = _investor.investor_id;

            _form.comboInvestor.SelectedItem = null;
        }


        public async void LoadOpportunityCombo()
        {
            var result = await _opportunityRepository.GetAllList();

            _form.comboOpportunity.DataSource = result.Where(x => x.blocked == false).OrderBy(x => x.CodeName).ToList();
            _form.comboOpportunity.DisplayMember = _opportunity.CodeName;
            _form.comboOpportunity.ValueMember = _opportunity.opportunity_id;

            _form.comboOpportunity.SelectedItem = null;
        }


        public void LoadContractPeriodCombo()
        {
            var result = new List<KeyValueModel>();

            result.Add(new KeyValueModel("6", "6 Months"));
            result.Add(new KeyValueModel("12", "12 Months"));
            result.Add(new KeyValueModel("18", "18 Months"));
            result.Add(new KeyValueModel("24", "24 Months"));

            _form.comboContractPeriod.DataSource = result;
            _form.comboContractPeriod.DisplayMember = "Value";
            _form.comboContractPeriod.ValueMember = "Key";

            _form.comboContractPeriod.SelectedIndex = 3;
        }


        public void LoadFormFields(InvestPledgeViewModel model)
        {
            _form.textRecordId.Text = model.pledge_id.ToString();

            if (model.investment_amount.HasValue)
            {
                _form.textInvestmentAmount.Text = string.Format("{0:N2}", double.Parse(model.investment_amount.ToString()));
            }
            else
            {
                _form.textInvestmentAmount.Text = string.Format("{0:N2}", 0);
            }

            if (model.trust_interest_rate.HasValue)
            {
                _form.textTrustInterestRate.Text = string.Format("{0:N2}", double.Parse(model.trust_interest_rate.ToString()));
            }
            else
            {
                _form.textTrustInterestRate.Text = string.Format("{0:N2}", 0);
            }

            if (model.investment_interest_rate.HasValue)
            {
                _form.textInvestmentInterestRate.Text = string.Format("{0:N2}", double.Parse(model.investment_interest_rate.ToString()));
            }
            else
            {
                _form.textInvestmentInterestRate.Text = string.Format("{0:N2}", 0);
            }

            if (model.contract_signed_date.HasValue)
            {
                _form.dateContractDate.Format = DateTimePickerFormat.Short;
                _form.dateContractDate.Value = model.contract_signed_date.Value;
            }
            else
            {
                _form.dateContractDate.Value = _form.dateContractDate.MinDate;
                _form.dateContractDate.Format = DateTimePickerFormat.Custom;
                _form.dateContractDate.CustomFormat = " ";
            }

            if (model.deposit_date.HasValue)
            {
                _form.dateDepositDate.Format = DateTimePickerFormat.Short;
                _form.dateDepositDate.Value = model.deposit_date.Value;
            }
            else
            {
                _form.dateDepositDate.Value = _form.dateDepositDate.MinDate;
                _form.dateDepositDate.Format = DateTimePickerFormat.Custom;
                _form.dateDepositDate.CustomFormat = " ";
            }

            if (model.release_date.HasValue)
            {
                _form.dateReleaseDate.Format = DateTimePickerFormat.Short;
                _form.dateReleaseDate.Value = model.release_date.Value;
            }
            else
            {
                _form.dateReleaseDate.Value = _form.dateReleaseDate.MinDate;
                _form.dateReleaseDate.Format = DateTimePickerFormat.Custom;
                _form.dateReleaseDate.CustomFormat = " ";
            }

            if (model.end_date.HasValue)
            {
                _form.dateEndDate.Format = DateTimePickerFormat.Short;
                _form.dateEndDate.Value = model.end_date.Value;
            }
            else
            {
                _form.dateEndDate.Value = _form.dateEndDate.MinDate;
                _form.dateEndDate.Format = DateTimePickerFormat.Custom;
                _form.dateEndDate.CustomFormat = " ";
            }

            if (model.investment_transferred.HasValue)
            {
                _form.checkTransferred.Checked = model.investment_transferred.Value;
            }
            else 
            {
                _form.checkTransferred.CheckState = CheckState.Unchecked;
            }

            if (model.blocked.HasValue)
            {
                _form.checkBlocked.Checked = model.blocked.Value;
            }
            else
            {
                _form.checkBlocked.CheckState = CheckState.Unchecked;
            }

        }

        public void ResetFields()
        {
            _form.textRecordId.Text = "";
            _form.comboInvestor.SelectedItem = null;
            _form.comboOpportunity.SelectedItem = null;

            _form.textInvestmentAmount.Text = string.Format("{0:N2}", 0);
            _form.textTrustInterestRate.Text = string.Format("{0:N2}", 0);
            _form.textInvestmentInterestRate.Text = string.Format("{0:N2}", 0);

            _form.dateContractDate.Value = _form.dateContractDate.MinDate;
            _form.dateContractDate.Format = DateTimePickerFormat.Custom;
            _form.dateContractDate.CustomFormat = " ";

            _form.dateDepositDate.Value = _form.dateDepositDate.MinDate;
            _form.dateDepositDate.Format = DateTimePickerFormat.Custom;
            _form.dateDepositDate.CustomFormat = " ";
            
            _form.dateReleaseDate.Value = _form.dateReleaseDate.MinDate;
            _form.dateReleaseDate.Format = DateTimePickerFormat.Custom;
            _form.dateReleaseDate.CustomFormat = " ";

            _form.dateEndDate.Value = _form.dateEndDate.MinDate;
            _form.dateEndDate.Format = DateTimePickerFormat.Custom;
            _form.dateEndDate.CustomFormat = " ";

            _form.comboContractPeriod.SelectedItem = null;

            _form.checkTransferred.CheckState = CheckState.Unchecked;

            _form.checkBlocked.CheckState = CheckState.Unchecked;
        }


        public InvestPledgeModel GetFormFields()
        {
            var investor = new InvestorListModel();
            var opportunity = new OpportunityListModel();
            var contractDate = new DateTime?();
            var depositDate = new DateTime?();
            var releaseDate = new DateTime?();
            var endDate = new DateTime?();

            if (_form.comboInvestor.SelectedItem.IsNotNullObject())
            {
                investor = (InvestorListModel)_form.comboInvestor.SelectedItem;
            }

            if (_form.comboOpportunity.SelectedItem.IsNotNullObject())
            {
                opportunity = (OpportunityListModel)_form.comboOpportunity.SelectedItem;
            }

            if (_form.dateContractDate.Value != _form.dateContractDate.MinDate)
            {
                contractDate = _form.dateContractDate.Value;
            }

            if (_form.dateDepositDate.Value != _form.dateDepositDate.MinDate)
            {
                depositDate = _form.dateDepositDate.Value;
            }

            if (_form.dateReleaseDate.Value != _form.dateReleaseDate.MinDate)
            {
                releaseDate = _form.dateReleaseDate.Value;
            }

            if (_form.dateEndDate.Value != _form.dateEndDate.MinDate)
            {
                endDate = _form.dateEndDate.Value;
            }


            return new InvestPledgeModel(
                 _form.textRecordId.Text.GetNumberOrNull(),
                 investor.investor_id,
                 opportunity.opportunity_id,
                 _form.textInvestmentAmount.Text.GetDoubleOrNull(),
                 contractDate,
                 depositDate,
                 releaseDate,
                 endDate,
                 _form.textTrustInterestRate.Text.GetDoubleOrNull(),
                 _form.textInvestmentInterestRate.Text.GetDoubleOrNull(),
                 _form.checkTransferred.Checked,
                 _form.checkBlocked.Checked
                 );
        }


        public (bool success, List<string> errors) IsValidFields()
        {
            var Errors = new List<string>();

            if (_form.comboInvestor.SelectedItem.IsNullObject())
            {
                Errors.Add("An investor much be selected.");
            }

            if (_form.comboOpportunity.SelectedItem.IsNullObject())
            {
                Errors.Add("An opportunity much be selected.");
            }

            if (Errors.Count > 0)
            {
                return (false, Errors);
            }

            return (true, Errors);
        }


    }

}
