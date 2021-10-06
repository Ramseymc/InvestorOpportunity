using InvestorLibrary;
using InvestorLibrary.Shared;
using InvestorLibrary.User;
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
    public partial class UserForm : Form
    {
        private readonly IUserRepository _userRepository;

        private UserViewModel dataModel;
        private UserController _userController;
        public UserForm()
        {
            InitializeComponent();

            _userRepository = (IUserRepository)ContainerConfig.ServiceProvider.GetService(typeof(IUserRepository));

            dataModel = new UserViewModel();
            _userController = new UserController(this);
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
            _userController.ResetFields();

            comboSearchList.SelectedItem = null;

            textUsername.Focus();

            ButtonActions(FormAction.AddEdit);
        }


        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_userController.IsValidFields().success)
                {
                    var record = await _userRepository.GetById(textRecordId.Text);

                    if (record != null)
                    {
                        var model = _userController.GetFormFields();

                        dataModel = await _userRepository.Update(model);
                    }
                    else
                    {
                        var model = _userController.GetFormFields();

                        dataModel = await _userRepository.Add(model);

                        textRecordId.Text = dataModel.Id.ToString();
                    }

                    _userController.LoadSearchList();

                    ButtonActions(FormAction.Save);
                }
                else
                {
                    foreach (var item in _userController.IsValidFields().errors)
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
            _userController.LoadFormData(dataModel);

            ButtonActions(FormAction.Undo);
        }

        private async void DeleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                await _userRepository.Remove(textRecordId.Text);

                _userController.ResetFields();

                _userController.LoadSearchList();

                ButtonActions(FormAction.Delete);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Deleting Record: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void FirstButton_Click(object sender, EventArgs e)
        {
            var dataList = await _userRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Username).FirstOrDefault();

            _userController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void BackButton_Click(object sender, EventArgs e)
        {
            var dataList = await _userRepository.GetAll();

            dataModel = dataList.OrderByDescending(d => d.Username).SkipWhile(x => x.Username != textUsername.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _userController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.Username).FirstOrDefault();

                _userController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void ForwardButton_Click(object sender, EventArgs e)
        {
            var dataList = await _userRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Username).SkipWhile(x => x.Username != textUsername.Text).Skip(1).FirstOrDefault();

            if (dataModel != null)
            {
                _userController.LoadFormData(dataModel);
            }
            else
            {
                dataModel = dataList.OrderBy(d => d.Username).LastOrDefault();

                _userController.LoadFormData(dataModel);
            }

            ButtonActions(FormAction.Other);
        }

        private async void LastButton_Click(object sender, EventArgs e)
        {
            var dataList = await _userRepository.GetAll();

            dataModel = dataList.OrderBy(d => d.Username).LastOrDefault();

            _userController.LoadFormData(dataModel);

            ButtonActions(FormAction.Other);
        }

        private async void comboSearchList_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selected = new UserListModel();

            if (comboSearchList.SelectedItem.IsNotNullObject())
            {
                selected = (UserListModel)comboSearchList.SelectedItem;

                dataModel = await _userRepository.GetById(selected.Id.ToString());

                _userController.LoadFormData(dataModel);
            }

            textUsername.Focus();

            comboSearchList.SelectedItem = null;

            ButtonActions(FormAction.Selected);
        }

        private void comboSearchList_Leave(object sender, EventArgs e)
        {
            //var selected = new UserListModel();

            //if (comboSearchList.SelectedItem.IsNotNullObject())
            //{
            //    selected = (UserListModel)comboSearchList.SelectedItem;

            //    dataModel = await _userRepository.GetById(selected.Id.ToString());

            //    _userController.LoadFormData(dataModel);
            //}

            //textUsername.Focus();

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

        private void UserForm_Load(object sender, EventArgs e)
        {
            _userController.LoadSearchList();
        }

        private void textUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textUsername.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textFirstName.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textLastName.Text.Length >= 100)
            {
                e.Handled = true;
            }
        }

        private void textUsername_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textFirstName_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void textLastName_TextChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

        private void checkBlocked_CheckedChanged(object sender, EventArgs e)
        {
            ButtonActions(FormAction.Other);
        }

      
    }

}




