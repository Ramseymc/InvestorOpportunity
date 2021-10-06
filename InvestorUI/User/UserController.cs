using InvestorLibrary;
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
    class UserController
    {
        private readonly IUserRepository _userRepository;

        UserForm _form;
        public UserController(UserForm form)
        {
            _userRepository = (IUserRepository)ContainerConfig.ServiceProvider.GetService(typeof(IUserRepository));

            _form = form;
        }


        public void LoadFormData(UserViewModel model)
        {
            LoadFormFields(model);
        }


        public async void LoadSearchList()
        {
            var model = await _userRepository.GetAllList();

            _form.comboSearchList.DataSource = model.OrderBy(x => x.Username).ToList();
            _form.comboSearchList.DisplayMember = _user.Username;
            _form.comboSearchList.ValueMember = _user.Id;

            _form.comboSearchList.SelectedItem = null;
        }


        public void LoadFormFields(UserViewModel model)
        {
            _form.textRecordId.Text = model.Id.ToString();
            _form.textUsername.Text = model.Username;
            _form.textFirstName.Text = model.FirstName;
            _form.textLastName.Text = model.LastName;
            _form.checkBlocked.Checked = model.Blocked.Value;
        }

        public void ResetFields()
        {
            _form.textRecordId.Text = "";
            _form.textUsername.Text = "";
            _form.textFirstName.Text = "";
            _form.textLastName.Text = "";
            _form.checkBlocked.CheckState = CheckState.Unchecked;
        }


        public UserModel GetFormFields()
        {
            return new UserModel(
              _form.textRecordId.Text.GetNumberOrNull(),
              _form.textUsername.Text,
              _form.textFirstName.Text,
              _form.textLastName.Text,
              _form.checkBlocked.Checked
              );
        }


        public (bool success, List<string> errors) IsValidFields()
        {
            var Errors = new List<string>();

            if (_form.textUsername.Text.IsNullorWhiteSpace())
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



