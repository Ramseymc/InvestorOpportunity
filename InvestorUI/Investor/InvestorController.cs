using InvestorLibrary;
using InvestorLibrary.Investor;
using InvestorLibrary.Shared;
using InvestorLibrary.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    public class InvestorController
    {
        public readonly IInvestorRepository _investorRepository;
        private readonly IUserRepository _userRepository;

        InvestorForm _form;
        public InvestorController(InvestorForm form)
        {
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));
            _userRepository = (IUserRepository)ContainerConfig.ServiceProvider.GetService(typeof(IUserRepository));

            _form = form;
        }


        public void LoadFormData(InvestorViewModel model)
        {
            LoadFormFields(model);

            _form.comboUser.SelectItemByValue(model.userId.ToString());
        }

        public DataTable GenerateInvestorReport()
        {
            DataTable dt = new DataTable();
            // either Development or Production
            string connString = ContainerConfig.DBConnection; 
            string query = "EXEC spGenerateInvestorReport";

            // start loader
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query the database and return the result to the datatable
            da.Fill(dt);

            // end loader

            conn.Close();
            da.Dispose();
            return dt;
        }

      

        public async void LoadSearchList()
        {
            var model = await _investorRepository.GetAllList();         

            if (_form.radioCode.Checked)
            {
                var result = model.OrderBy(x => x.CodeName).ToList();
                _form.comboSearchList.DataSource = result;
                _form.comboSearchList.DisplayMember = _investor.CodeName;
            }
            else
            {
                var result = model.OrderBy(x => x.NameCode).ToList();
                _form.comboSearchList.DataSource = result;
                _form.comboSearchList.DisplayMember = _investor.NameCode;
            }

            _form.comboSearchList.ValueMember = _investor.investor_id;

            _form.comboSearchList.SelectedItem = null;
        }


        public async void LoadUserCombo()
        {
            var result = await _userRepository.GetAllList();

            _form.comboUser.DataSource = result.OrderBy(x => x.Username).ToList();
            _form.comboUser.DisplayMember = _user.Username;
            _form.comboUser.ValueMember = _user.Id;

            _form.comboUser.SelectedItem = null;
        }


        public void LoadFormFields(InvestorViewModel model)
        {
            _form.textRecordId.Text = model.investor_id.ToString();
            _form.textAccountNumber.Text = model.investor_acc_number;
            _form.textName.Text = model.investor_name;
            _form.textSurname.Text = model.investor_surname;
            _form.textReferenceNumber.Text = model.investor_id_number;
            _form.textOrganisation.Text = model.investor_organisation;
            _form.textEmail.Text = model.investor_email;
            _form.textMobile.Text = model.investor_mobile;
            _form.textLandline.Text = model.investor_landline;
            _form.textExternalReference.Text = model.investor_reference;

            if (model.blocked.HasValue)
            {
                _form.checkBlocked.Checked = model.blocked.Value;
            }
            else
            {
                _form.checkBlocked.CheckState = CheckState.Unchecked;
            }

            if (model.investor_ficaDate.HasValue)
            {
                _form.dateFicaDate.Format = DateTimePickerFormat.Short;
                _form.dateFicaDate.Value = model.investor_ficaDate.Value;
            }
            else
            {
                _form.dateFicaDate.Value = _form.dateFicaDate.MinDate;
                _form.dateFicaDate.Format = DateTimePickerFormat.Custom;
                _form.dateFicaDate.CustomFormat = " ";
            }

            if (model.investor_fica.HasValue)
            {
                _form.checkFicaComplete.Checked = model.investor_fica.Value;
            }
            else
            {
                _form.checkFicaComplete.CheckState = CheckState.Unchecked;
            }

            _form.textPhysicalStreet.Text = model.investor_physical_street;
            _form.textPhysicalSuburb.Text = model.investor_physical_suburb;
            _form.textPhysicalProvince.Text = model.investor_physical_province;
            _form.textPhysicalCountry.Text = model.investor_physical_country;
            _form.textPhysicalCode.Text = model.investor_physical_postal_code;
            _form.textPostalBox.Text = model.investor_postal_street_box;
            _form.textPostalSuburb.Text = model.investor_postal_suburb;
            _form.textPostalProvince.Text = model.investor_postal_province;
            _form.textPostalCountry.Text = model.investor_postal_country;
            _form.textPostalCode.Text = model.investor_postal_postal_code;
        }


        public void ResetFields()
        {
            _form.textRecordId.Text = "";
            _form.textAccountNumber.Text = "";
            _form.textName.Text = "";
            _form.textSurname.Text = "";
            _form.textReferenceNumber.Text = "";
            _form.textOrganisation.Text = "";
            _form.textEmail.Text = "";
            _form.textMobile.Text = "";
            _form.textLandline.Text = "";
            _form.textExternalReference.Text = "";

            _form.checkBlocked.CheckState = CheckState.Unchecked;

            _form.dateFicaDate.Value = _form.dateFicaDate.MinDate;
            _form.dateFicaDate.Format = DateTimePickerFormat.Custom;
            _form.dateFicaDate.CustomFormat = " ";

            _form.checkFicaComplete.CheckState = CheckState.Unchecked;

            _form.textPhysicalStreet.Text = "";
            _form.textPhysicalSuburb.Text = "";
            _form.textPhysicalProvince.Text = "";
            _form.textPhysicalCountry.Text = "";
            _form.textPhysicalCode.Text = "";
            _form.textPostalBox.Text = "";
            _form.textPostalSuburb.Text = "";
            _form.textPostalProvince.Text = "";
            _form.textPostalCountry.Text = "";
            _form.textPostalCode.Text = "";
        }


        public InvestorModel GetFormFields()
        {
            var user = new UserListModel();
            var FicaDate = new DateTime?();

            if (_form.comboUser.SelectedItem.IsNotNullObject())
            {
                user = (UserListModel)_form.comboUser.SelectedItem;
            }

            if (_form.dateFicaDate.Value != _form.dateFicaDate.MinDate)
            {
                FicaDate = _form.dateFicaDate.Value;
            }           


            return new InvestorModel(
                 _form.textRecordId.Text.GetNumberOrNull(),
                 _form.textAccountNumber.Text,
                 _form.textName.Text,
                 _form.textSurname.Text,
                 _form.textOrganisation.Text,
                 _form.textReferenceNumber.Text,
                 _form.textEmail.Text,
                 _form.textMobile.Text,
                 _form.textLandline.Text,
                 _form.textPhysicalStreet.Text,
                 _form.textPhysicalSuburb.Text,
                 _form.textPhysicalProvince.Text,
                 _form.textPhysicalCountry.Text,
                 _form.textPhysicalCode.Text,                 
                 _form.textPostalBox.Text,
                 _form.textPostalSuburb.Text,
                 _form.textPostalProvince.Text,
                 _form.textPostalCountry.Text,               
                 _form.textPostalCode.Text,
                 _form.checkFicaComplete.Checked, 
                 FicaDate,
                 _form.textExternalReference.Text,
                 user.Id,
                 _form.checkBlocked.Checked
                 );
        }



        public (bool success, List<string> errors) IsValidFields()
        {
            var Errors = new List<string>();

            if (_form.textAccountNumber.Text.IsNullorWhiteSpace())
            {
                Errors.Add("This code cannot be empty.");
            }

            if (_form.textName.Text.IsNullorWhiteSpace())
            {
                Errors.Add("This name cannot be empty.");
            }

            if (_form.textSurname.Text.IsNullorWhiteSpace())
            {
                Errors.Add("This surname cannot be empty.");
            }

            if (Errors.Count > 0)
            {
                return (false, Errors);
            }

            return (true, Errors);
        }


    }
}
