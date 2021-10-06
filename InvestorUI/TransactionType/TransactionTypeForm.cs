using InvestorLibrary;
using InvestorLibrary.Shared;
using InvestorLibrary.TransactionType;
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
    public partial class TransactionTypeForm : Form
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        private TransactionTypeViewModel dataModel;
        private TransactionTypeController _transactionTypeController;

        public TransactionTypeForm()
        {
            InitializeComponent();

            _transactionTypeRepository = (ITransactionTypeRepository)ContainerConfig.ServiceProvider.GetService(typeof(ITransactionTypeRepository));

            dataModel = new TransactionTypeViewModel();
            _transactionTypeController = new TransactionTypeController(this);
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
            _transactionTypeController.ResetFields();

            comboSearchList.SelectedItem = null;

            textDescription.Focus();

            ButtonActions(FormAction.AddEdit);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_transactionTypeController.IsValidFields().success)
                {
                    var record = await _transactionTypeRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _transactionTypeController.GetFormFields();

                        dataModel = await _transactionTypeRepository.Update(model);
                    }
                    else
                    {
                        var model = _transactionTypeController.GetFormFields();

                        dataModel = await _transactionTypeRepository.Add(model);

                        textRecordId.Text = dataModel.Id.ToString();
                    }

                    _transactionTypeController.LoadSearchList();

                    ButtonActions(FormAction.Save);
                }
                else
                {
                    foreach (var item in _transactionTypeController.IsValidFields().errors)
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
            _transactionTypeController.LoadFormData(dataModel);

            ButtonActions(FormAction.Undo);
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _transactionTypeRepository.Remove(textRecordId.Text);

                _transactionTypeController.ResetFields();

                _transactionTypeController.LoadSearchList();

                ButtonActions(FormAction.Delete);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FirstButton_Click(object sender, EventArgs e)
        {
            var dataList = await _transactionTypeRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Description).FirstOrDefault();

            _transactionTypeController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            var dataList = await _transactionTypeRepository.GetAll();

            dataModel = dataList.OrderByDescending(d => d.Description).SkipWhile(x => x.Description != textDescription.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _transactionTypeController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.Description).FirstOrDefault();

               _transactionTypeController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            var dataList = await _transactionTypeRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Description).SkipWhile(x => x.Description != textDescription.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
               _transactionTypeController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.Description).LastOrDefault();

               _transactionTypeController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void LastButton_Click(object sender, EventArgs e)
        {
            var dataList = await _transactionTypeRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Description).LastOrDefault();

            _transactionTypeController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void comboSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = new TransactionTypeListModel();
            
            if (comboSearchList.SelectedItem.IsNotNullObject())
            {
                selected = (TransactionTypeListModel)comboSearchList.SelectedItem;

                dataModel = await _transactionTypeRepository.GetById(selected.Id.ToString());

                _transactionTypeController.LoadFormData(dataModel);
            }

            textDescription.Focus();

            comboSearchList.SelectedItem = null;

           ButtonActions(FormAction.Selected);
        }

        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new TransactionTypeListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (TransactionTypeListModel)comboSearchList.SelectedItem;

            //    dataModel = await _transactionTypeRepository.GetById(selected.Id.ToString());

            //    _transactionTypeController.LoadFormData(dataModel);
            //}

            //textDescription.Focus();

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

        private void TransactionTypeForm_Load(object sender, EventArgs e)
        {
            _transactionTypeController.LoadSearchList();
        }

        private void textDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textDescription.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textDescription_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void checkBlocked_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

       
    }
}
