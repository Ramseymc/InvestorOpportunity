using InvestorLibrary;
using InvestorLibrary.Shared;
using InvestorLibrary.TransactionType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    class TransactionTypeController
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;

        TransactionTypeForm _form;
        public TransactionTypeController(TransactionTypeForm form)
        {
            _transactionTypeRepository = (ITransactionTypeRepository)ContainerConfig.ServiceProvider.GetService(typeof(ITransactionTypeRepository));

            _form = form;
        }


        public void LoadFormData(TransactionTypeViewModel model)
        {
            LoadFormFields(model);
        }


        public async void LoadSearchList()
        {
            var model = await _transactionTypeRepository.GetAllList();

            _form.comboSearchList.DataSource = model.OrderBy(x => x.Description).ToList();
            _form.comboSearchList.DisplayMember = _transactionType.Description;
            _form.comboSearchList.ValueMember = _transactionType.Id;

            _form.comboSearchList.SelectedItem = null;
        }


        public void LoadFormFields(TransactionTypeViewModel model)
        {
            _form.textRecordId.Text = model.Id.ToString();
            _form.textDescription.Text = model.Description;
            _form.checkBlocked.Checked = model.Blocked.Value;
        }

        public void ResetFields()
        {
            _form.textRecordId.Text = "";
            _form.textDescription.Text = "";
            _form.checkBlocked.CheckState = CheckState.Unchecked;
        }


        public TransactionTypeModel GetFormFields()
        {
            return new TransactionTypeModel(
                 _form.textRecordId.Text.GetNumberOrNull(),
                 _form.textDescription.Text,
                 _form.checkBlocked.Checked);
        }


        public (bool success, List<string> errors) IsValidFields()
        {
            var Errors = new List<string>();

            if (_form.textDescription.Text.IsNullorWhiteSpace())
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
