using InvestorLibrary;
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
    class OpportunityCategoryController
    {
        private readonly IOpportunityCategoryRepository _opportunityCategoryRepository;

        OpportunityCategoryForm _form;
        public OpportunityCategoryController(OpportunityCategoryForm form)
        {
            _opportunityCategoryRepository = (IOpportunityCategoryRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityCategoryRepository));

            _form = form;
        }


        public void LoadFormData(OpportunityCategoryViewModel model)
        {
            LoadFormFields(model);
        }


        public async void LoadSearchList()
        {
            var model = await _opportunityCategoryRepository.GetAllList();

            _form.comboSearchList.DataSource = model.OrderBy(x => x.Description).ToList();
            _form.comboSearchList.DisplayMember = _opportunityCategory.Description;
            _form.comboSearchList.ValueMember = _opportunityCategory.Id;

            _form.comboSearchList.SelectedItem = null;
        }


        public void LoadFormFields(OpportunityCategoryViewModel model)
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


        public OpportunityCategoryModel GetFormFields()
        {
            return new OpportunityCategoryModel(
                 _form.textRecordId.Text.GetNumberOrNull(),
                 _form.textDescription.Text,
                 _form.checkBlocked.Checked
                 );
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
