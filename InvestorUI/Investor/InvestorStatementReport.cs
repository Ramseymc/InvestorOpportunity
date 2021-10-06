using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.Investor;
using InvestorLibrary.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investor.Investor
{
    public partial class InvestorStatementReport : Form
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly IInvestmentRepository _investmentRepository;

        private InvestmentReportQuery queryModel;

        public InvestorStatementReport()
        {
            InitializeComponent();

            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));

            queryModel = new InvestmentReportQuery();
        }

        private void InvestorStatementReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            LoadInvestorFrom();

            LoadInvestorTo();
        }


        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await GetParameters();

            ////Set the processing mode for the ReportViewer to Local
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            var result = await _investmentRepository.ReportStatementsGetWhere(queryModel);

            var dtResult = result.OrderBy(x => x.investor_acc_number).DTOToDataTable();

            InvestmentReport(dtResult);
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InvestmentReport(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investor.InvestorStatement.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("InvestmentReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }


        public async void LoadInvestorFrom()
        {
            var model = await _investorRepository.GetAllList();

            comboInvestorFrom.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboInvestorFrom.DisplayMember = _investor.CodeName;
            comboInvestorFrom.ValueMember = _investor.investor_acc_number;
            comboInvestorFrom.SelectedItem = null;

            queryModel.InvestorCodeFrom = model.FirstOrDefault().investor_acc_number;
        }


        public async void LoadInvestorTo()
        {
            var model = await _investorRepository.GetAllList();

            comboInvestorTo.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboInvestorTo.DisplayMember = _investor.CodeName;
            comboInvestorTo.ValueMember = _investor.investor_acc_number;
            comboInvestorTo.SelectedItem = null;

            queryModel.InvestorCodeTo = model.LastOrDefault().investor_acc_number;
        }



        private void comboInvestorFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (InvestorListModel)comboInvestorFrom.SelectedItem;
            var resultTo = (InvestorListModel)comboInvestorTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.investor_acc_number, resultTo.investor_acc_number) > 0)
                {
                    comboInvestorFrom.SelectItemByValue(resultTo.investor_acc_number);
                }
            }
        }

        private void comboInvestorTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (InvestorListModel)comboInvestorFrom.SelectedItem;
            var resultTo = (InvestorListModel)comboInvestorTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.investor_acc_number, resultTo.investor_acc_number) > 0)
                {
                    comboInvestorTo.SelectItemByValue(resultFrom.investor_acc_number);
                }
            }
        }



        private async Task GetParameters()
        {
            var investorModel = await _investorRepository.GetAllList();

            var investorFrom = (InvestorListModel)comboInvestorFrom.SelectedItem;

            investorModel = investorModel.OrderBy(x => x.investor_acc_number);

            if (investorFrom.IsNullObject())
            {
                queryModel.InvestorCodeFrom = investorModel.FirstOrDefault().investor_acc_number;
                comboInvestorFrom.SelectItemByValue(investorModel.FirstOrDefault().investor_acc_number);
            }
            else
            {
                queryModel.InvestorCodeFrom = investorFrom.investor_acc_number;
            }

            var investorTo = (InvestorListModel)comboInvestorTo.SelectedItem;

            if (investorTo.IsNullObject())
            {
                queryModel.InvestorCodeTo = investorModel.LastOrDefault().investor_acc_number;
                comboInvestorTo.SelectItemByValue(investorModel.LastOrDefault().investor_acc_number);
            }
            else
            {
                queryModel.InvestorCodeTo = investorTo.investor_acc_number;
            }
        }

    }
}
