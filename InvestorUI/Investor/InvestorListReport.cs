using InvestorLibrary;
using InvestorLibrary.Investor;
using InvestorLibrary.Shared;
using InvestorLibrary.User;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI.Investor
{
    public partial class InvestorListReport : Form
    {
        private readonly IUserRepository _userRepository;
        private readonly IInvestorRepository _investorRepository;

        private InvestorReportQuery queryModel;

        public InvestorListReport()
        {
            InitializeComponent();

            _userRepository = (IUserRepository)ContainerConfig.ServiceProvider.GetService(typeof(IUserRepository));
            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));

            queryModel = new InvestorReportQuery();
        }


        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await GetParameters();

            //Set the processing mode for the ReportViewer to Local
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            if (checkCategory.Checked)
            {
                var result = await _investorRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.Username).DTOToDataTable();

                InvestorReport1(dtResult);
            }
            else
            {
                var result = await _investorRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.investor_acc_number).DTOToDataTable();

                InvestorReport2(dtResult);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InvestorListReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            LoadUserFrom();

            LoadUserTo();

            LoadInvestorFrom();

            LoadInvestorTo();
        }



        private void InvestorReport1(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investor.InvestorListUser.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("InvestorReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }

        private void InvestorReport2(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investor.InvestorList.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("InvestorReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }


        public async void LoadUserFrom()
        {
            var model = await _userRepository.GetAllList();

            comboCategoryFrom.DataSource = model.OrderBy(x => x.Username).ToList();
            comboCategoryFrom.DisplayMember = _user.Username;
            comboCategoryFrom.ValueMember = _user.Username;
            comboCategoryFrom.SelectedItem = null;

            queryModel.UserCodeFrom = model.FirstOrDefault().Username;
        }


        public async void LoadUserTo()
        {
            var model = await _userRepository.GetAllList();

            comboCategoryTo.DataSource = model.OrderBy(x => x.Username).ToList();
            comboCategoryTo.DisplayMember = _user.Username;
            comboCategoryTo.ValueMember = _user.Username;
            comboCategoryTo.SelectedItem = null;

            queryModel.UserCodeTo = model.LastOrDefault().Username;
        }


        public async void LoadInvestorFrom()
        {
            var model = await _investorRepository.GetAllList();

            comboCodeFrom.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboCodeFrom.DisplayMember = _investor.CodeName;
            comboCodeFrom.ValueMember = _investor.investor_acc_number;
            comboCodeFrom.SelectedItem = null;

            queryModel.InvestorCodeFrom = model.FirstOrDefault().investor_acc_number;
        }


        public async void LoadInvestorTo()
        {
            var model = await _investorRepository.GetAllList();

            comboCodeTo.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboCodeTo.DisplayMember = _investor.CodeName;
            comboCodeTo.ValueMember = _investor.investor_acc_number;
            comboCodeTo.SelectedItem = null;

            queryModel.InvestorCodeTo = model.LastOrDefault().investor_acc_number;
        }


        private void comboCategoryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (UserListModel)comboCategoryFrom.SelectedItem;
            var resultTo = (UserListModel)comboCategoryTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.Username, resultTo.Username) > 0)
                {
                    comboCategoryFrom.SelectItemByValue(resultTo.Username);
                }
            }
        }

        private void comboCategoryTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (UserListModel)comboCategoryFrom.SelectedItem;
            var resultTo = (UserListModel)comboCategoryTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.Username, resultTo.Username) > 0)
                {
                    comboCategoryTo.SelectItemByValue(resultFrom.Username);
                }
            }
        }


        private void comboCodeFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (InvestorListModel)comboCodeFrom.SelectedItem;
            var resultTo = (InvestorListModel)comboCodeTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.investor_acc_number, resultTo.investor_acc_number) > 0)
                {
                    comboCodeFrom.SelectItemByValue(resultTo.investor_acc_number);
                }
            }
        }

        private void comboCodeTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (InvestorListModel)comboCodeFrom.SelectedItem;
            var resultTo = (InvestorListModel)comboCodeTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.investor_acc_number, resultTo.investor_acc_number) > 0)
                {
                    comboCodeTo.SelectItemByValue(resultFrom.investor_acc_number);
                }
            }
        }



        private async Task GetParameters()
        {
            var categoryModel = await _userRepository.GetAllList();

            var categoryFrom = (UserListModel)comboCategoryFrom.SelectedItem;

            categoryModel = categoryModel.OrderBy(x => x.Username);

            if (categoryFrom.IsNullObject())
            {
                queryModel.UserCodeFrom = categoryModel.FirstOrDefault().Username;
                comboCategoryFrom.SelectItemByValue(categoryModel.FirstOrDefault().Username);
            }
            else
            {
                queryModel.UserCodeFrom = categoryFrom.Username;
            }

            var categoryTo = (UserListModel)comboCategoryTo.SelectedItem;

            if (categoryTo.IsNullObject())
            {
                queryModel.UserCodeTo = categoryModel.LastOrDefault().Username;
                comboCategoryTo.SelectItemByValue(categoryModel.LastOrDefault().Username);
            }
            else
            {
                queryModel.UserCodeTo = categoryTo.Username;
            }

            var investorModel = await _investorRepository.GetAllList();

            var codeFrom = (InvestorListModel)comboCodeFrom.SelectedItem;

            investorModel = investorModel.OrderBy(x => x.investor_acc_number);

            if (codeFrom.IsNullObject())
            {
                queryModel.InvestorCodeFrom = investorModel.FirstOrDefault().investor_acc_number;
                comboCodeFrom.SelectItemByValue(investorModel.FirstOrDefault().investor_acc_number);
            }
            else
            {
                queryModel.InvestorCodeFrom = codeFrom.investor_acc_number;
            }

            var codeTo = (InvestorListModel)comboCodeTo.SelectedItem;

            if (codeTo.IsNullObject())
            {
                queryModel.InvestorCodeTo = investorModel.LastOrDefault().investor_acc_number;
                comboCodeTo.SelectItemByValue(investorModel.LastOrDefault().investor_acc_number);
            }
            else
            {
                queryModel.InvestorCodeTo = codeTo.investor_acc_number;
            }

        }
    }
}
