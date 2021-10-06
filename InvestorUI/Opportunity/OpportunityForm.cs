using InvestorLibrary;
using InvestorLibrary.Interest;
using InvestorLibrary.Investment;
using InvestorLibrary.Opportunity;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    public partial class OpportunityForm : Form
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IInvestmentRepository _investmentRepository;

        private OpportunityViewModel dataModel;
        private OpportunityController _opportunityController;
        public OpportunityForm()
        {
            InitializeComponent();

            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));

            dataModel = new OpportunityViewModel();
            _opportunityController = new OpportunityController(this);
        }

        private void WindowMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void WindowMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void WindowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            _opportunityController.ResetFields();

            comboSearchList.SelectedItem = null;

            textCode.Focus();

            ButtonActions(FormAction.AddEdit);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_opportunityController.IsValidFields().success)
                {
                    var record = await _opportunityRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _opportunityController.GetFormFields();

                        dataModel = await _opportunityRepository.Update(model);
                    }
                    else
                    {
                        var model = _opportunityController.GetFormFields();

                        dataModel = await _opportunityRepository.Add(model);

                        textRecordId.Text = dataModel.opportunity_id.ToString();
                    }

                    _opportunityController.LoadSearchList();

                    ButtonActions(FormAction.Save);
                }
                else
                {
                    foreach (var item in _opportunityController.IsValidFields().errors)
                    {
                        MessageBox.Show(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding\\Editing Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            _opportunityController.LoadFormData(dataModel);

            _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());

            _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());

            ButtonActions(FormAction.Undo);
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _opportunityRepository.Remove(textRecordId.Text);

                _opportunityController.ResetFields();

                _opportunityController.LoadInvestmentsList("0");

                _opportunityController.LoadSearchList();

                ButtonActions(FormAction.Delete);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error Deleting Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FirstButton_Click(object sender, EventArgs e)
        {
            var dataList = await _opportunityRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.opportunity_code).FirstOrDefault();

            _opportunityController.LoadFormData(dataModel);

            _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());

            ButtonActions(FormAction.Other);
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            var dataList = await _opportunityRepository.GetAll();

            dataModel = dataList.OrderByDescending(d => d.opportunity_code).SkipWhile(x => x.opportunity_code != textCode.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _opportunityController.LoadFormData(dataModel);

                _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.opportunity_code).FirstOrDefault();

                _opportunityController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            var dataList = await _opportunityRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.opportunity_code).SkipWhile(x => x.opportunity_code != textCode.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _opportunityController.LoadFormData(dataModel);

                _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.opportunity_code).LastOrDefault();

                _opportunityController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void LastButton_Click(object sender, EventArgs e)
        {
            var dataList = await _opportunityRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.opportunity_code).LastOrDefault();

            _opportunityController.LoadFormData(dataModel);

            _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());

            ButtonActions(FormAction.Other);
        }

        private async void comboSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = new OpportunityListModel();

            if (comboSearchList.SelectedItem.IsNotNullObject())
            {
                selected = (OpportunityListModel)comboSearchList.SelectedItem;

                dataModel = await _opportunityRepository.GetById(selected.opportunity_id.ToString());

                _opportunityController.LoadFormData(dataModel);

                _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());
            }

            textCode.Focus();

            comboSearchList.SelectedItem = null;

            ButtonActions(FormAction.Selected);
        }



        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new OpportunityListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (OpportunityListModel)comboSearchList.SelectedItem;

            //    dataModel = await _opportunityRepository.GetById(selected.opportunity_id.ToString());

            //    _opportunityController.LoadFormData(dataModel);
            //}         

            //textCode.Focus();

            //comboSearchList.SelectedItem = null;

            //ButtonActions(FormAction.Selected);
        }


        private void comboSearchList_KeyDown(object sender, KeyEventArgs e)
        {
            //Works also when user select and click on autocomplete list.
            if (e.KeyCode == Keys.Enter && comboSearchList.SelectedItem != null)
                comboSearchList_SelectionChangeCommitted(sender, e);
        }


        private void ButtonActions(string action)
        {
            switch (action)
            {
                case FormAction.Selected:

                    AddButton.Enabled = true;
                    SaveButton.Enabled = true;
                    UndoButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    FirstButton.Enabled = true;
                    BackButton.Enabled = true;
                    ForwardButton.Enabled = true;
                    LastButton.Enabled = true;
                    break;

                case FormAction.Save:

                    AddButton.Enabled = true;
                    SaveButton.Enabled = false;
                    UndoButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    FirstButton.Enabled = true;
                    BackButton.Enabled = true;
                    ForwardButton.Enabled = true;
                    LastButton.Enabled = true;
                    break;

                case FormAction.AddEdit:

                    AddButton.Enabled = false;
                    SaveButton.Enabled = true;
                    UndoButton.Enabled = true;
                    DeleteButton.Enabled = false;
                    FirstButton.Enabled = false;
                    BackButton.Enabled = false;
                    ForwardButton.Enabled = false;
                    LastButton.Enabled = false;
                    break;

                case FormAction.Undo:

                    AddButton.Enabled = true;
                    SaveButton.Enabled = false;
                    UndoButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    FirstButton.Enabled = true;
                    BackButton.Enabled = true;
                    ForwardButton.Enabled = true;
                    LastButton.Enabled = true;
                    break;

                case FormAction.Delete:

                    AddButton.Enabled = true;
                    SaveButton.Enabled = false;
                    UndoButton.Enabled = false;
                    DeleteButton.Enabled = false;
                    FirstButton.Enabled = true;
                    BackButton.Enabled = true;
                    ForwardButton.Enabled = true;
                    LastButton.Enabled = true;
                    break;

                default:

                    AddButton.Enabled = true;
                    SaveButton.Enabled = true;
                    UndoButton.Enabled = true;
                    DeleteButton.Enabled = true;
                    FirstButton.Enabled = true;
                    BackButton.Enabled = true;
                    ForwardButton.Enabled = true;
                    LastButton.Enabled = true;
                    break;
            }

        }

        private void OpportunityForm_Load(object sender, EventArgs e)
        {
            _opportunityController.ResetFields();

            _opportunityController.LoadSearchList();

            _opportunityController.LoadCategoryCombo();

            _opportunityController.LoadInvestmentActionCombo();

            _opportunityController.LoadOpportunityCombo();
        }

        private void textAmountRequired_Leave(object sender, EventArgs e)
        {
            if (textAmountRequired.Text.IsDouble())
            {
                textAmountRequired.Text = string.Format("{0:N2}", double.Parse(textAmountRequired.Text));
            }
        }

        private void textInterestRate_Leave(object sender, EventArgs e)
        {
            if (textInterestRate.Text.IsDouble())
            {
                textInterestRate.Text = string.Format("{0:N2}", double.Parse(textInterestRate.Text));
            }
        }

        private void textCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textCode.Text.Length >= 5)
            {
                e.Handled = true;
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textName.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textCode_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textAmountRequired_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textInterestRate_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void dateStartDate_ValueChanged(object sender, EventArgs e)
        {
            dateStartDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void dateEndDate_ValueChanged(object sender, EventArgs e)
        {
            dateEndDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void comboTransfer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void dateTransferDate_ValueChanged(object sender, EventArgs e)
        {
            dateTransferDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void checkBlocked_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textAmountRequired_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textTransferRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textTransferRate_Leave(object sender, EventArgs e)
        {
            if (textTransferRate.Text.IsDouble())
            {
                textTransferRate.Text = string.Format("{0:N2}", double.Parse(textTransferRate.Text));

                var model = (IEnumerable<InvestmentRolloverListModel>)gridInvestments.DataSource;

                foreach (var item in model)
                {
                    if (item.ReleaseInterest == null)
                    {
                        item.ReleaseInterest = double.Parse(textTransferRate.Text);
                        item.ReleaseAmount = item.Amount;
                    }

                    item.Selected = true;
                }

                gridInvestments.DataSource = model;
                gridInvestments.Refresh();
            }
        }

        private void dateChangeDate_ValueChanged(object sender, EventArgs e)
        {
            dateChangeDate.Format = DateTimePickerFormat.Short;
        }

        private void dateChangeDate_Leave(object sender, EventArgs e)
        {
            if (dateChangeDate.Value.ToString().IsDate())
            {
                var model = (IEnumerable<InvestmentRolloverListModel>)gridInvestments.DataSource;

                foreach (var item in model)
                {
                    if (item.ReleaseDate == null)
                    {
                        item.ReleaseDate = DateTime.Parse(dateChangeDate.Value.ToString()).ToString("dd/MM/yyyy");
                    }
                }

                gridInvestments.DataSource = model;
                gridInvestments.Refresh();
            }
        }


        private void gridInvestments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var currentColumn = gridInvestments.Columns[e.ColumnIndex].Name;

            if (currentColumn == _investment.investment_exit_rollover)
            {
                var selected = (string)gridInvestments.CurrentRow.Cells[_investment.investment_exit_rollover].Value;

                if (selected == "1")
                {
                    gridInvestments.CurrentRow.Cells[_investment.opportunity_id].ReadOnly = false;

                    gridInvestments.CurrentRow.Cells[_investment.ReleaseInterest].ReadOnly = false;
                }
                else
                {
                    gridInvestments.CurrentRow.Cells[_investment.opportunity_id].Value = null;
                    gridInvestments.CurrentRow.Cells[_investment.opportunity_id].ReadOnly = true;

                    gridInvestments.CurrentRow.Cells[_investment.ReleaseInterest].Value = null;
                    gridInvestments.CurrentRow.Cells[_investment.ReleaseInterest].ReadOnly = true;
                }
            }


            if (currentColumn == _investment.ReleaseAmount)
            {
                var result = gridInvestments.CurrentRow.Cells[_investment.ReleaseAmount].Value;

                if (result != null)
                {
                    if (result.ToString().IsNumeric())
                    {
                        gridInvestments.CurrentRow.Cells[_investment.ReleaseAmount].Value = decimal.Parse(result.ToString()).ToString("N2");
                    }
                }
            }


            if (currentColumn == _investment.ReleaseInterest)
            {
                var result = gridInvestments.CurrentRow.Cells[_investment.ReleaseInterest].Value;

                if (result != null)
                {
                    if (result.ToString().IsNumeric())
                    {
                        gridInvestments.CurrentRow.Cells[_investment.ReleaseInterest].Value = decimal.Parse(result.ToString()).ToString("N2");
                    }
                }
            }


            if (currentColumn == _investment.ReleaseDate)
            {
                var result = gridInvestments.CurrentRow.Cells[_investment.ReleaseDate].Value;

                if (result != null)
                {
                    if (result.ToString().IsDate())
                    {
                        gridInvestments.CurrentRow.Cells[_investment.ReleaseDate].Value = DateTime.Parse(result.ToString()).ToString("dd/MM/yyyy");
                    }
                }
            }


        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Confirm transfer of investments.  This action cannot be undone.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.OK)
                {
                    var model = (IEnumerable<InvestmentRolloverListModel>)gridInvestments.DataSource;

                    await _investmentRepository.UpdateInvestmentTransfers(model);

                    _opportunityController.LoadInvestmentsList(dataModel.opportunity_id.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Records: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gridInvestments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
