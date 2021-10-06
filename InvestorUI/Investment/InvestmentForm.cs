using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.Investor;
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
    public partial class InvestmentForm : Form
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IInvestorRepository _investorRepository;

        private InvestmentViewModel dataModel;
        private InvestorViewModel investorModel;
        private InvestmentController _investmentController;
        public InvestmentForm()
        {
            InitializeComponent();

            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));

            dataModel = new InvestmentViewModel();
            investorModel = new InvestorViewModel();

            _investmentController = new InvestmentController(this);
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
            _investmentController.ResetFields();

            comboSearchList.SelectedItem = null;

            comboInvestor.Focus();

            ButtonActions(FormAction.AddEdit);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_investmentController.IsValidFields().success)
                {
                    var record = await _investmentRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _investmentController.GetFormFields();

                        dataModel = await _investmentRepository.Update(model);
                    }
                    else
                    {
                        var model = _investmentController.GetFormFields();

                        dataModel = await _investmentRepository.Add(model);

                        textRecordId.Text = dataModel.investment_id.ToString();
                    }

                    var result = await _investorRepository.GetById(dataModel.investor_id.ToString());

                    await _investmentController.LoadInvestmentsList(result.investor_id.ToString());

                    _investmentController.LoadSearchList();

                    ButtonActions(FormAction.Save);
                }
                else
                {
                    foreach (var item in _investmentController.IsValidFields().errors)
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
            //_investmentController.LoadFormData(dataModel);

            //ButtonActions(FormAction.Undo);
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

                await _investmentRepository.Remove(textRecordId.Text);

                await _investmentController.LoadInvestmentsList(investor.investor_id.ToString());
                
                _investmentController.ResetFields();

                _investmentController.LoadSearchList();

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
            await _investmentController.LoadInvestmentsList(investorModel.investor_id.ToString());

            _investmentController.ResetFields();

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

                await _investmentController.LoadInvestmentsList(investorModel.investor_id.ToString());
            }

            comboInvestor.Focus();

            comboSearchList.SelectedItem = null;

            _investmentController.ResetFields();

            ButtonActions(FormAction.Selected);
        }


        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new InvestorListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (InvestorListModel)comboSearchList.SelectedItem;

            //    var result = await _investorRepository.GetById(selected.investor_id.ToString());

            //    _investmentController.LoadInvestmentsList(result.investor_id.ToString());
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

        private void InvestmentForm_Load(object sender, EventArgs e)
        {
            radioCode.Checked = true;

            _investmentController.ResetFields();

            _investmentController.LoadSearchList();

            _investmentController.LoadInvestorCombo();

            _investmentController.LoadOpportunityCombo();

            _investmentController.LoadRolloverCombo();

            _investmentController.LoadRolloverOpportunityCombo();

            _investmentController.LoadTransactionTypeCombo();

        }

        private void textInvestmentAmount_Leave(object sender, EventArgs e)
        {
            if (textInvestmentAmount.Text.IsDouble())
            {
                textInvestmentAmount.Text = string.Format("{0:N2}", double.Parse(textInvestmentAmount.Text));
            }
        }

        private void textInterestRate_Leave(object sender, EventArgs e)
        {
            if (textInterestRate.Text.IsDouble())
            {
                textInterestRate.Text = string.Format("{0:N2}", double.Parse(textInterestRate.Text));
            }
        }

        private void textRolloverAmount_Leave(object sender, EventArgs e)
        {
            if (textRolloverAmount.Text.IsNumeric())
            {
                textRolloverAmount.Text = string.Format("{0:N2}", double.Parse(textRolloverAmount.Text));
            }
        }

        private void radioCode_CheckedChanged(object sender, EventArgs e)
        {
            _investmentController.LoadSearchList();
        }

        private void radioName_CheckedChanged(object sender, EventArgs e)
        {
            _investmentController.LoadSearchList();
        }

        private void textInvestmentAmount_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textInterestRate_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void dateReleaseDate_ValueChanged(object sender, EventArgs e)
        {
            dateReleaseDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void dateEndDate_ValueChanged(object sender, EventArgs e)
        {
            dateEndDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void comboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void comboOpportunity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void comboInvestor_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void checkBlocked_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textInvestmentAmount_KeyPress(object sender, KeyPressEventArgs e)
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

        private async void gridInvestments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            await _investmentController.GetInvestment();

            comboInvestor.Focus();

            ButtonActions(FormAction.Other);
        }

        private async void buttonExitRollover_Click(object sender, EventArgs e)
        {
            try
            {
                var selected = new InvestorListModel();

                if (comboInvestor.SelectedItem.IsNotNullObject())
                {
                    selected = (InvestorListModel)comboInvestor.SelectedItem;
                }

                if (_investmentController.IsValidRollover().success)
                {
                    var model = _investmentController.GetRolloverFields();

                    await _investmentRepository.CreateRollover(model);

                    await _investmentController.LoadInvestmentsList(selected.investor_id.ToString());

                    _investmentController.LoadSearchList();
                }
                else
                {
                    foreach (var item in _investmentController.IsValidRollover().errors)
                    {
                        MessageBox.Show(item);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating rollover: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void dateRolloverDate_ValueChanged(object sender, EventArgs e)
        {
            dateRolloverDate.Format = DateTimePickerFormat.Short;
        }

        private void comboRollover_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = (InvestmentActionModel)comboRollover.SelectedItem;

            if (selected.Id == "1")
            {
                comboRolloverOpportunity.Enabled = true;
                textRolloverInterest.Enabled = true;
            }
            else
            {
                comboRolloverOpportunity.Enabled = false;
                textRolloverInterest.Enabled = false;
            }

        }
    }
}
