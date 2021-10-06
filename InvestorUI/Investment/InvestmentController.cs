using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.Investor;
using InvestorLibrary.Opportunity;
using InvestorLibrary.Shared;
using InvestorLibrary.TransactionType;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    class InvestmentController
    {
        private readonly ISharedRepository _sharedRepository;
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IInvestorRepository _investorRepository;
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        InvestmentForm _form;
        public InvestmentController(InvestmentForm form)
        {
            _sharedRepository = (ISharedRepository)ContainerConfig.ServiceProvider.GetService(typeof(ISharedRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));
            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));
            _transactionTypeRepository = (ITransactionTypeRepository)ContainerConfig.ServiceProvider.GetService(typeof(ITransactionTypeRepository));

            _form = form;
        }

        public void LoadFormData(InvestmentViewModel model)
        {
            LoadFormFields(model);

            _form.comboInvestor.SelectItemByValue(model.investor_id.ToString());
            _form.comboOpportunity.SelectItemByValue(model.opportunity_id.ToString());
            _form.comboTransactionType.SelectItemByValue(model.transaction_type.ToString());

            //_form.comboRollover.SelectItemByValue(model.userId.ToString())
            //_form.LoadRolloverOpportunityCombo.SelectItemByValue(model.userId.ToString())
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
            var model = await _investmentRepository.GetByInvestor(Id);

            _form.gridInvestments.AutoGenerateColumns = false;

            _form.gridInvestments.DataSource = model.OrderBy(x => x.CodeInvestor).ThenBy(x => x.release_date).ToList();
            _form.gridInvestments.Refresh();
        }


        public async Task GetInvestment()
        {
            var row = (DataGridViewRow)_form.gridInvestments.CurrentRow;

            var recordId = row.Cells[_investment.investment_id].Value;

            var result = await _investmentRepository.GetById(recordId.ToString());

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

        public async void LoadRolloverCombo()
        {
            var result = await _sharedRepository.GetInvestmentActions();

            _form.comboRollover.DataSource = result.OrderBy(x => x.Description).ToList();
            _form.comboRollover.DisplayMember = _investmentAction.Description;
            _form.comboRollover.ValueMember = _investmentAction.Id;

            _form.comboRollover.SelectedItem = null;
        }


        public async void LoadRolloverOpportunityCombo()
        {
            var result = await _opportunityRepository.GetAllList();

            _form.comboRolloverOpportunity.DataSource = result.Where(x => x.blocked == false).OrderBy(x => x.CodeName).ToList();
            _form.comboRolloverOpportunity.DisplayMember = _opportunity.CodeName;
            _form.comboRolloverOpportunity.ValueMember = _opportunity.opportunity_id;

            _form.comboRolloverOpportunity.SelectedItem = null;
        }


        public async void LoadTransactionTypeCombo()
        {
            var result = await _transactionTypeRepository.GetAllList();

            _form.comboTransactionType.DataSource = result.OrderBy(x => x.Description).ToList();
            _form.comboTransactionType.DisplayMember = _transactionType.Description;
            _form.comboTransactionType.ValueMember = _transactionType.Id;

            _form.comboTransactionType.SelectedItem = null;
        }


        public void LoadFormFields(InvestmentViewModel model)
        {
            _form.textRecordId.Text = model.investment_id.ToString();
            _form.comboInvestor.SelectedItem = model.investor_id;
            _form.comboOpportunity.SelectedItem = model.opportunity_id;
            _form.comboTransactionType.SelectedItem = model.transaction_type;

            if (model.investment_amount.HasValue)
            {
                _form.textInvestmentAmount.Text = string.Format("{0:N2}", double.Parse(model.investment_amount.ToString()));
            }
            else
            {
                _form.textInvestmentAmount.Text = string.Format("{0:N2}", 0);
            }

            if (model.investment_interest_rate.HasValue)
            {
                _form.textInterestRate.Text = string.Format("{0:N2}", double.Parse(model.investment_interest_rate.ToString()));
            }
            else
            {
                _form.textInterestRate.Text = string.Format("{0:N2}", 0);
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
            _form.comboTransactionType.SelectedItem = null;

            _form.textInvestmentAmount.Text = string.Format("{0:N2}", 0);
            _form.textInterestRate.Text = string.Format("{0:N2}", 0);

            _form.dateReleaseDate.Value = _form.dateReleaseDate.MinDate;
            _form.dateReleaseDate.Format = DateTimePickerFormat.Custom;
            _form.dateReleaseDate.CustomFormat = " ";

            _form.dateEndDate.Value = _form.dateEndDate.MinDate;
            _form.dateEndDate.Format = DateTimePickerFormat.Custom;
            _form.dateEndDate.CustomFormat = " ";

            _form.dateRolloverDate.Value = _form.dateRolloverDate.MinDate;
            _form.dateRolloverDate.Format = DateTimePickerFormat.Custom;
            _form.dateRolloverDate.CustomFormat = " ";

            _form.checkBlocked.CheckState = CheckState.Unchecked;
        }


        public InvestmentModel GetFormFields()
        {
            var investor = new InvestorListModel();
            var opportunity = new OpportunityListModel();
            var rollover = new InvestmentActionModel();
            var transationType = new TransactionTypeListModel();

            var releaseDate = new DateTime?();
            var endDate = new DateTime?();

            if (_form.dateReleaseDate.Value != _form.dateReleaseDate.MinDate)
            {
                releaseDate = _form.dateReleaseDate.Value;
            }

            if (_form.dateEndDate.Value != _form.dateEndDate.MinDate)
            {
                endDate = _form.dateEndDate.Value;
            }

            if (_form.comboInvestor.SelectedItem.IsNotNullObject())
            {
                investor = (InvestorListModel)_form.comboInvestor.SelectedItem;
            }

            if (_form.comboOpportunity.SelectedItem.IsNotNullObject())
            {
                opportunity = (OpportunityListModel)_form.comboOpportunity.SelectedItem;
            }

            if (_form.comboRollover.SelectedItem.IsNotNullObject())
            {
                rollover = (InvestmentActionModel)_form.comboRollover.SelectedItem;
            }

            if (_form.comboTransactionType.SelectedItem.IsNotNullObject())
            {
                transationType = (TransactionTypeListModel)_form.comboTransactionType.SelectedItem;
            }

            return new InvestmentModel(
                 _form.textRecordId.Text.GetNumberOrNull(),
                 investor.investor_id,
                 opportunity.opportunity_id,
                 _form.textInvestmentAmount.Text.GetDoubleOrNull(),
                 rollover.Id.GetNumberOrNull(),
                 releaseDate,
                 endDate,
                 _form.textInterestRate.Text.GetDoubleOrNull(),
                 transationType.Id,
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



        public RolloverModel GetRolloverFields()
        {
            var rollover = new InvestmentActionModel();
            var investor = new InvestorListModel();
            var opportunity = new OpportunityListModel();
            var org_opportunity  = new OpportunityListModel();
            var rollDate = new DateTime?();

            if (_form.comboRollover.SelectedItem.IsNotNullObject())
            {
                rollover = (InvestmentActionModel)_form.comboRollover.SelectedItem;
            }

            if (_form.comboInvestor.SelectedItem.IsNotNullObject())
            {
                investor = (InvestorListModel)_form.comboInvestor.SelectedItem;
            }

            if (_form.comboRolloverOpportunity.SelectedItem.IsNotNullObject())
            {
                opportunity = (OpportunityListModel)_form.comboRolloverOpportunity.SelectedItem;
            }

            if (_form.comboOpportunity.SelectedItem.IsNotNullObject())
            {
                org_opportunity = (OpportunityListModel)_form.comboOpportunity.SelectedItem;
            }

            if (_form.dateRolloverDate.Value != _form.dateRolloverDate.MinDate)
            {
                rollDate = _form.dateRolloverDate.Value;
            }

            return new RolloverModel(
                investor.investor_id,
                opportunity.opportunity_id,
                _form.textRolloverAmount.Text.GetDoubleOrNull(),
                _form.textRolloverInterest.Text.GetDoubleOrNull(),
                rollDate,
                rollover.Id.GetNumberOrNull(),
                org_opportunity.opportunity_id,
                _form.textInterestRate.Text.GetDoubleOrNull()
                );
        }



        public (bool success, List<string> errors) IsValidRollover()
        {
            var rollover = (InvestmentActionModel)_form.comboRollover.SelectedItem;

            var Errors = new List<string>();

            if (_form.textRecordId.IsNullObject())
            {
                Errors.Add("Select an investment to rollover.");
            }


            if (_form.comboInvestor.SelectedItem.IsNullObject())
            {
                Errors.Add("Select a valid investor to rollover from.");
            }


            if (_form.comboOpportunity.SelectedItem.IsNullObject())
            {
                Errors.Add("Select a valid opportunity to rollover from.");
            }


            if (_form.comboRolloverOpportunity.SelectedItem.IsNullObject() && rollover.Id == "1")
            {
                Errors.Add("Select the opportunity to rollover to.");
            }


            if (_form.textRolloverAmount.Text.GetDoubleOrNull() == 0 || 
                _form.textRolloverAmount.Text.GetDoubleOrNull() > _form.textInvestmentAmount.Text.GetDoubleOrNull())
            {
                Errors.Add("Select the amount for the rollover, smaller than the total investment.");
            }


            if (!_form.textRolloverAmount.Text.IsDouble())
            {
                Errors.Add("Select the interest rate for the rollover");
            }


            if (_form.dateRolloverDate.Value == _form.dateRolloverDate.MinDate)
            {
                Errors.Add("Select a date for the rollover.");
            }


            if (_form.comboRollover.SelectedItem.IsNullObject())
            {
                Errors.Add("Select the type of Rollover.");
            }


            if (Errors.Count > 0)
            {
                return (false, Errors);
            }

            return (true, Errors);
        }


    }

}
