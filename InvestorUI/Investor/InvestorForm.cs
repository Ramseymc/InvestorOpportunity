using InvestorLibrary;
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
    public partial class InvestorForm : Form
    {
        private readonly IInvestorRepository _investorRepository;

        private InvestorViewModel dataModel;
        private InvestorController _investorController;
        public InvestorForm()
        {
            InitializeComponent();

            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));

            dataModel = new InvestorViewModel();
            _investorController = new InvestorController(this);
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
            _investorController.ResetFields();

            comboSearchList.SelectedItem = null;

            comboUser.SelectedItem = null;

            textAccountNumber.Focus();

            ButtonActions(FormAction.AddEdit);
        }
        public async void GenerateInvestorReport(object sender, EventArgs e)
        {
            _investorController.GenerateInvestorReport();
        }

            private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_investorController.IsValidFields().success)
                {
                    var record = await _investorRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _investorController.GetFormFields();

                        dataModel = await _investorRepository.Update(model);
                    }
                    else
                    {
                        var model = _investorController.GetFormFields();

                        dataModel = await _investorRepository.Add(model);

                        textRecordId.Text = dataModel.investor_id.ToString();
                    }

                    _investorController.LoadSearchList();

                    ButtonActions(FormAction.Save);
                }
                else
                {
                    foreach (var item in _investorController.IsValidFields().errors)
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
            _investorController.LoadFormData(dataModel);

            ButtonActions(FormAction.Undo);
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _investorRepository.Remove(textRecordId.Text);

                _investorController.ResetFields();

                _investorController.LoadSearchList();

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

            dataModel = dataList.OrderBy(d => d.investor_acc_number).FirstOrDefault();

            _investorController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            dataModel = dataList.OrderByDescending(d => d.investor_acc_number).SkipWhile(x => x.investor_acc_number != textAccountNumber.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _investorController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.investor_acc_number).FirstOrDefault();

                _investorController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.investor_acc_number).SkipWhile(x => x.investor_acc_number != textAccountNumber.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _investorController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.investor_acc_number).LastOrDefault();

                _investorController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void LastButton_Click(object sender, EventArgs e)
        {
            var dataList = await _investorRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.investor_acc_number).LastOrDefault();

            _investorController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void comboSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = new InvestorListModel();

            if (comboSearchList.SelectedItem.IsNotNullObject())
            {
                selected = (InvestorListModel)comboSearchList.SelectedItem;

                dataModel = await _investorRepository.GetById(selected.investor_id.ToString());

                _investorController.LoadFormData(dataModel);
            }

            textAccountNumber.Focus();

            comboSearchList.SelectedItem = null;

            ButtonActions(FormAction.Selected);
        }


        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new InvestorListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (InvestorListModel)comboSearchList.SelectedItem;

            //    dataModel = await _investorRepository.GetById(selected.investor_id.ToString());

            //    _investorController.LoadFormData(dataModel);
            //}

            //textAccountNumber.Focus();

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

        private void InvestorForm_Load(object sender, EventArgs e)
        {
            radioCode.Checked = true;

            _investorController.ResetFields();
            
            _investorController.LoadSearchList();

            _investorController.LoadUserCombo();
        }

        private void radioCode_CheckedChanged(object sender, EventArgs e)
        {
            _investorController.LoadSearchList();
        }

        private void radioName_CheckedChanged(object sender, EventArgs e)
        {
            _investorController.LoadSearchList();
        }

        private void textAccountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textAccountNumber.Text.Length >= 6)
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

        private void textSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textSurname.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textReferenceNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textReferenceNumber.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textOrganisation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textOrganisation.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textEmail.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textMobile.Text.Length >= 25)
            {
                e.Handled = true;
            }

            if (!e.KeyChar.InputIsNumber())
            {
                e.Handled = true;
            }
        }

        private void textLandline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textLandline.Text.Length >= 25)
            {
                e.Handled = true;
            }

            if (!e.KeyChar.InputIsNumber())
            {
                e.Handled = true;
            }
        }

        private void textExternalReference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textExternalReference.Text.Length >= 25)
            {
                e.Handled = true;
            }
        }

        private void textPhysicalStreet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPhysicalStreet.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPhycialSuburb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPhysicalSuburb.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPhysicalProvince_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPhysicalProvince.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPhysicalCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPhysicalCountry.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPhysicalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPhysicalCode.Text.Length >= 6)
            {
                e.Handled = true;
            }
        }

        private void textPostalBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPostalBox.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPostalSuburb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPostalSuburb.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPostalProvince_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPostalProvince.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPostalCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPostalCountry.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textPostalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textPostalCode.Text.Length >= 6)
            {
                e.Handled = true;
            }
        }

        private void textAccountNumber_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textSurname_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textReferenceNumber_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textOrganisation_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textMobile_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textLandline_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void dateFicaDate_ValueChanged(object sender, EventArgs e)
        {
            dateFicaDate.Format = DateTimePickerFormat.Short;
            ButtonActions(FormAction.Other);
        }

        private void textExternalReference_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPhysicalStreet_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPhysicalSuburb_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPhysicalProvince_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPhysicalCountry_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPhysicalCode_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPostalBox_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPostalSuburb_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPostalProvince_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPostalCountry_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textPostalCode_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void checkBlocked_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void checkFicaComplete_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void comboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

       
    }
}
