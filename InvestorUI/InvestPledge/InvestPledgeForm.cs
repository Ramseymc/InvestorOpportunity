using InvestorLibrary;
using InvestorLibrary.Investor;
using InvestorLibrary.InvestPledge;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    public partial class InvestPledgeForm : Form
    {
        private readonly IInvestPledgeRepository _investPledgeRepository;
        private readonly IInvestorRepository _investorRepository;

        private InvestPledgeViewModel dataModel;
        private InvestorViewModel investorModel;
        private InvestPledgeController _investPledgeController;

        public InvestPledgeForm()
        {
            InitializeComponent();

            _investPledgeRepository = (IInvestPledgeRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestPledgeRepository));
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));

            dataModel = new InvestPledgeViewModel();
            investorModel = new InvestorViewModel();

            _investPledgeController = new InvestPledgeController(this);
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
            _investPledgeController.ResetFields();

            comboSearchList.SelectedItem = null;

            comboInvestor.Focus();

            ButtonActions(FormAction.AddEdit);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            await this.ActionSave();  
        }


        private async Task<bool> ActionSave()
        {
            try
            {
                if (_investPledgeController.IsValidFields().success)
                {
                    var record = await _investPledgeRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _investPledgeController.GetFormFields();

                        dataModel = await _investPledgeRepository.Update(model);
                    }
                    else
                    {
                        var model = _investPledgeController.GetFormFields();

                        dataModel = await _investPledgeRepository.Add(model);

                        textRecordId.Text = dataModel.pledge_id.ToString();
                    }

                    var result = await _investorRepository.GetById(dataModel.investor_id.ToString());

                    await _investPledgeController.LoadInvestmentsList(result.investor_id.ToString());

                    _investPledgeController.LoadSearchList();

                    ButtonActions(FormAction.Save);

                    return true;
                }
                else
                {
                    foreach (var item in _investPledgeController.IsValidFields().errors)
                    {
                        MessageBox.Show(item);
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Adding\\Editing Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

        }


        private void UndoButton_Click(object sender, EventArgs e)
        {
            _investPledgeController.LoadFormData(dataModel);

            ButtonActions(FormAction.Undo);
        }


        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var investor = new InvestorListModel();

                if (comboInvestor.SelectedItem.IsNotNullObject())
                {
                    investor = (InvestorListModel)comboInvestor.SelectedItem;
                }

                await _investPledgeRepository.Remove(textRecordId.Text);

                await _investPledgeController.LoadInvestmentsList(investor.investor_id.ToString());

                _investPledgeController.ResetFields();

                _investPledgeController.LoadSearchList();

                ButtonActions(FormAction.Delete);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FirstButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            investorModel = dataList.OrderBy(d => d.investor_acc_number).FirstOrDefault();

            await LoadNavigationResult();
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            investorModel = dataList.OrderByDescending(d => d.investor_acc_number).SkipWhile(x => x.investor_acc_number != investorModel.investor_acc_number).Skip(1).FirstOrDefault();            

            if (investorModel == null)
            {
                investorModel = dataList.OrderBy(d => d.investor_acc_number).FirstOrDefault();
            }

            await LoadNavigationResult();
        }


        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            investorModel = dataList.OrderBy(d => d.investor_acc_number).SkipWhile(x => x.investor_acc_number != investorModel.investor_acc_number).Skip(1).FirstOrDefault();

            if (investorModel == null)
            {
                investorModel = dataList.OrderBy(d => d.investor_acc_number).LastOrDefault();
            }

            await LoadNavigationResult();
        }


        private async void LastButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            investorModel = dataList.OrderBy(d => d.investor_acc_number).LastOrDefault();

            await LoadNavigationResult();
        }



        private async Task LoadNavigationResult()
        {
            await _investPledgeController.LoadInvestmentsList(investorModel.investor_id.ToString());

            _investPledgeController.ResetFields();

            comboSearchList.SelectItemByValue(investorModel.investor_id.ToString());

            ButtonActions(FormAction.Selected);
        }



        private async void comboSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = new InvestorListModel();

            if (comboSearchList.SelectedItem.IsNotNullObject())
            {
                selected = (InvestorListModel)comboSearchList.SelectedItem;

                investorModel = await _investorRepository.GetById(selected.investor_id.ToString());

                await _investPledgeController.LoadInvestmentsList(investorModel.investor_id.ToString());
            }

            comboInvestor.Focus();

            _investPledgeController.ResetFields();

            comboSearchList.SelectedItem = null;

            ButtonActions(FormAction.Selected);
        }


        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new InvestorListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (InvestorListModel)comboSearchList.SelectedItem;

            //    var result = await _investorRepository.GetById(selected.investor_id.ToString());

            //    _investPledgeController.LoadInvestmentsList(result.investor_id.ToString());
            //}

            //comboInvestor.Focus();

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

        private void InvestPledgeForm_Load(object sender, EventArgs e)
        {
            radioCode.Checked = true;
            checkIncludeTransferred.Checked = true;

            _investPledgeController.ResetFields();

            _investPledgeController.LoadSearchList();

            _investPledgeController.LoadInvestorCombo();

            _investPledgeController.LoadOpportunityCombo();

            _investPledgeController.LoadContractPeriodCombo();
        }

        private void textInvestmentAmount_Leave(object sender, EventArgs e)
        {
            if (textInvestmentAmount.Text.IsDouble())
            {
                textInvestmentAmount.Text = string.Format("{0:N2}", double.Parse(textInvestmentAmount.Text));
            }
        }

        private void textTrustInterestRate_Leave(object sender, EventArgs e)
        {
            if (textTrustInterestRate.Text.IsDouble())
            {
                textTrustInterestRate.Text = string.Format("{0:N2}", double.Parse(textTrustInterestRate.Text));
            }
        }

        private void textInvestmentInterestRate_Leave(object sender, EventArgs e)
        {
            if (textInvestmentInterestRate.Text.IsDouble())
            {
                textInvestmentInterestRate.Text = string.Format("{0:N2}", double.Parse(textInvestmentInterestRate.Text));
            }
        }

        private void radioCode_CheckedChanged(object sender, EventArgs e)
        {
            _investPledgeController.LoadSearchList();
        }

        private void radioName_CheckedChanged(object sender, EventArgs e)
        {
            _investPledgeController.LoadSearchList();
        }

        private void comboInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void comboOpportunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textInvestmentAmount_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textTrustInterestRate_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textInvestmentInterestRate_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void dateContractDate_ValueChanged(object sender, EventArgs e)
        {
            dateContractDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void dateDepositDate_ValueChanged(object sender, EventArgs e)
        {
            dateDepositDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void dateReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            dateReleaseDate.Format = DateTimePickerFormat.Short;

            //if (dateEndDate.Value == dateEndDate.MinDate)
            //{
            //    var period = (KeyValueModel)comboContractPeriod.SelectedItem;

            //    if (period != null)
            //    {
            //        dateEndDate.Value = dateReleaseDate.Value.AddMonths(int.Parse(period.Key));
            //    }

            //}

            ButtonActions(FormAction.Other);
        }

     
        private void dateEndDate_ValueChanged(object sender, EventArgs e)
        {
            dateEndDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void textInvestmentAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textTrustInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textInvestmentInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private async void gridInvestments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            await _investPledgeController.GetInvestment();

            comboInvestor.Focus();

            ButtonActions(FormAction.Other);
        }

        private async void buttonTransferPledge_Click(object sender, EventArgs e)
        {
            var saveResult = await this.ActionSave();

            if (saveResult)
            {
                if (checkTransferred.Checked)
                {
                    var answer = MessageBox.Show("This pledge has been transferred.  Are you sure you want to transfer it again?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (answer == DialogResult.Yes)
                    {
                        var result = await _investPledgeRepository.TransferPledge(textRecordId.Text);

                        checkTransferred.Checked = true;

                        await _investPledgeController.LoadInvestmentsList(result.investor_id.ToString());
                    }
                }
                else
                {
                    var result = await _investPledgeRepository.TransferPledge(textRecordId.Text);

                    checkTransferred.Checked = true;

                    await _investPledgeController.LoadInvestmentsList(result.investor_id.ToString());
                }
            }
            else
            {
                MessageBox.Show("This pledge was not transferred.  Error when saving record.  Fix any save errors and try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void comboContractPeriod_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dateEndDate.Format = DateTimePickerFormat.Short;

            if (dateReleaseDate.Value != dateReleaseDate.MinDate)
            {
                var period = (KeyValueModel)comboContractPeriod.SelectedItem;

                if (period != null)
                {
                    dateEndDate.Value = dateReleaseDate.Value.AddMonths(int.Parse(period.Key));
                }

            }

            ButtonActions(FormAction.Other);
        }
    }
}
