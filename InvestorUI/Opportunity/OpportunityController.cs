using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Opportunity;
using InvestorLibrary.OpportunityCategory;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    class OpportunityController
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityCategoryRepository _opportunityCategoryRepository;
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IInvestPledgeRepository _investPledgeRepository;
        private readonly ISharedRepository _sharedRepository;

        public IEnumerable<OpportunityListModel> opportunityModel { get; set; }
        public IEnumerable<InvestmentActionModel> actionModel { get; set; }

        OpportunityForm _form;
        public OpportunityController(OpportunityForm form)
        {
            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));
            _opportunityCategoryRepository = (IOpportunityCategoryRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityCategoryRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));
            _investPledgeRepository = (IInvestPledgeRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestPledgeRepository));
            _sharedRepository = (ISharedRepository)ContainerConfig.ServiceProvider.GetService(typeof(ISharedRepository));

            _form = form;
        }


        public void LoadFormData(OpportunityViewModel model)
        {
            LoadFormFields(model);

            _form.comboCategory.SelectItemByValue(model.categoryId.ToString());

         //   _form.gridInvestments.Columns[7].DefaultCellStyle.Format = "dd/mm/yyyy";
        }


        public async void LoadSearchList()
        {
            var model = await _opportunityRepository.GetAllList();

            var result = model.OrderBy(x => x.opportunity_code).ToList();

            _form.comboSearchList.DataSource = result;
            _form.comboSearchList.DisplayMember = _opportunity.CodeName;
            _form.comboSearchList.ValueMember = _opportunity.opportunity_id;

            _form.comboSearchList.SelectedItem = null;
        }

        public async void LoadInvestmentsList(string Id)
        {
            var model = await _investmentRepository.GetByOpportunitySummary(Id);

            _form.gridInvestments.DataSource = null;
            _form.gridInvestments.Rows.Clear();
            _form.gridInvestments.AutoGenerateColumns = false;

            _form.gridInvestments.DataSource = model;

            
            
            _form.gridInvestments.Columns[_investment.ReleaseDate].DefaultCellStyle.Format = "dd/MM/yyyy";
        }


        public async void LoadInvestmentActionCombo()
        {
            actionModel = await _sharedRepository.GetInvestmentActions();

            var colInventory = ((DataGridViewComboBoxColumn)_form.gridInvestments.Columns[5]);

            colInventory.DataSource = actionModel.OrderBy(x => x.Description).ToList();
            colInventory.DisplayMember = _investmentAction.Description;
            colInventory.ValueMember = _investmentAction.Id;
            colInventory.DataPropertyName = _investmentAction.ExitRollover;
        }


        public async void LoadOpportunityCombo()
        {
            opportunityModel = await _opportunityRepository.GetAllList();

            var colInventory = ((DataGridViewComboBoxColumn)_form.gridInvestments.Columns[8]);

            colInventory.DataSource = opportunityModel.OrderBy(x => x.CodeName).ToList();
            colInventory.DisplayMember = _opportunity.CodeName;
            colInventory.ValueMember = _opportunity.opportunity_id;
            colInventory.DataPropertyName = _opportunity.opportunity_id;
        }


        public async void LoadCategoryCombo()
        {
            var result = await _opportunityCategoryRepository.GetAllList();

            _form.comboCategory.DataSource = result.OrderBy(x => x.Description).ToList();
            _form.comboCategory.DisplayMember = _opportunityCategory.Description;
            _form.comboCategory.ValueMember = _opportunityCategory.Id;

            _form.comboCategory.SelectedItem = null;
        }


        public async void LoadFormFields(OpportunityViewModel model)
        {
            _form.textRecordId.Text = model.opportunity_id.ToString();
            _form.textCode.Text = model.opportunity_code;
            _form.textName.Text = model.opportunity_name;
            _form.checkBlocked.Checked = model.blocked.Value;

            if (model.opportunity_amount_required.HasValue)
            {
                _form.textAmountRequired.Text = string.Format("{0:N2}", double.Parse(model.opportunity_amount_required.ToString()));
            }
            else
            {
                _form.textAmountRequired.Text = string.Format("{0:N2}", 0);
            }

            if (model.opportunity_interest_rate.HasValue)
            {
                _form.textInterestRate.Text = string.Format("{0:N2}", double.Parse(model.opportunity_interest_rate.ToString()));
            }
            else
            {
                _form.textInterestRate.Text = string.Format("{0:N2}", 0);
            }


            if (model.opportunity_start_date.HasValue)
            {
                _form.dateStartDate.Format = DateTimePickerFormat.Short;
                _form.dateStartDate.Value = model.opportunity_start_date.Value;
            }
            else
            {
                _form.dateStartDate.Value = _form.dateStartDate.MinDate;
                _form.dateStartDate.Format = DateTimePickerFormat.Custom;
                _form.dateStartDate.CustomFormat = " ";
            }

            if (model.opportunity_end_date.HasValue)
            {
                _form.dateEndDate.Format = DateTimePickerFormat.Short;
                _form.dateEndDate.Value = model.opportunity_end_date.Value;
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


            var investTotals = await _investmentRepository.GetOpportunityTotals();

            var pledgeTotals = await _investPledgeRepository.GetOpportunityTotals();

            var investResult = investTotals.Where(x => x.opportunity_id == model.opportunity_id).SingleOrDefault();

            var pledgeResult = pledgeTotals.Where(x => x.opportunity_id == model.opportunity_id).SingleOrDefault();

            double investAmount = 0;
            double pledgeAmount = 0;

            if (investResult.IsNotNullObject())
            {
                investAmount = investResult.Amount;
            }

            if (pledgeResult.IsNotNullObject())
            {
                pledgeAmount = pledgeResult.Amount;
            }

            var outstandingAmount = Math.Round(model.opportunity_amount_required.Value - investAmount - pledgeAmount, 2);

            _form.labelOutstanding.Text = outstandingAmount.ToString("N2");
            _form.labelInvestments.Text = investAmount.ToString("N2");
            _form.labelPledges.Text = pledgeAmount.ToString("N2");

        }


        public void ResetFields()
        {
            _form.textRecordId.Text = "";
            _form.textCode.Text = "";
            _form.textName.Text = "";
            _form.checkBlocked.CheckState = CheckState.Unchecked;

            _form.textAmountRequired.Text = string.Format("{0:N2}", 0);
            _form.textInterestRate.Text = string.Format("{0:N2}", 0);

            _form.dateStartDate.Value = _form.dateStartDate.MinDate;
            _form.dateStartDate.Format = DateTimePickerFormat.Custom;
            _form.dateStartDate.CustomFormat = " ";

            _form.dateEndDate.Value = _form.dateEndDate.MinDate;
            _form.dateEndDate.Format = DateTimePickerFormat.Custom;
            _form.dateEndDate.CustomFormat = " ";

            _form.labelOutstanding.Text = "";
            _form.labelInvestments.Text = "";
            _form.labelPledges.Text = "";

            _form.comboTransfer.SelectedItem = null;

            _form.dateTransferDate.Value = _form.dateTransferDate.MinDate;
            _form.dateTransferDate.Format = DateTimePickerFormat.Custom;
            _form.dateTransferDate.CustomFormat = " ";
        }


        public OpportunityModel GetFormFields()
        {
            var category = new OpportunityCategoryListModel();
            var startDate = new DateTime?();
            var endDate = new DateTime?();
            var transferDate = new DateTime?();

            if (_form.comboCategory.SelectedItem.IsNotNullObject())
            {
                category = (OpportunityCategoryListModel)_form.comboCategory.SelectedItem;
            }

            if (_form.dateStartDate.Value != _form.dateStartDate.MinDate)
            {
                startDate = _form.dateStartDate.Value;
            }

            if (_form.dateEndDate.Value != _form.dateEndDate.MinDate)
            {
                endDate = _form.dateEndDate.Value;
            }

            if (_form.dateTransferDate.Value != _form.dateTransferDate.MinDate)
            {
                transferDate = _form.dateTransferDate.Value;
            }


            return new OpportunityModel(
           _form.textRecordId.Text.GetNumberOrNull(),
           _form.textCode.Text,
           _form.textName.Text,
           _form.textAmountRequired.Text.GetDoubleOrNull(),
           startDate,
           endDate,
           _form.textInterestRate.Text.GetDoubleOrNull(),
           transferDate,
           null,
           category.Id,
           _form.checkBlocked.Checked
           );
        }


        public (bool success, List<string> errors) IsValidFields()
        {
            var Errors = new List<string>();

            if (_form.comboCategory.SelectedItem.IsNullObject())
            {
                Errors.Add("A category code is required.");
            }

            if (_form.textCode.Text.IsNullorWhiteSpace())
            {
                Errors.Add("This code cannot be empty.");
            }

            if (_form.textCode.Text.Length > 5)
            {
                Errors.Add("This code cannot be longer that 6 characters.");
            }

            if (_form.textName.Text.IsNullorWhiteSpace())
            {
                Errors.Add("This description cannot be empty.");
            }

            if (Errors.Count > 0)
            {
                return (false, Errors);
            }

            return (true, Errors);
        }


    }

}
