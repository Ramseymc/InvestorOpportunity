using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.Investor;
using InvestorLibrary.Opportunity;
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

namespace InvestorUI.Investment
{
    public partial class InvestmentListReport : Form
    {
        private readonly IInvestorRepository _investorRepository;
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IInvestmentRepository _investmentRepository;

        private InvestmentReportQuery queryModel;


        public InvestmentListReport()
        {
            InitializeComponent();

            _investorRepository = (IInvestorRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestorRepository));
            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));
            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));

            queryModel = new InvestmentReportQuery();
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await GetParameters();

            //Set the processing mode for the ReportViewer to Local
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            if (radioInvestor.Checked)
            {
                var result = await _investmentRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.investor_acc_number).ThenBy(x => x.opportunity_code).ThenBy(x => x.release_date).DTOToDataTable();

                InvestmentReport1(dtResult);
            }
            
            if (radioOpportunity.Checked)
            {
                var result = await _investmentRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.opportunity_code).ThenBy(x => x.investor_acc_number).ThenBy(x => x.release_date).DTOToDataTable();

                InvestmentReport2(dtResult);
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InvestmentListReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            LoadInvestorFrom();

            LoadInvestorTo();

            LoadOpportunityFrom();

            LoadOpportunityTo();

            radioInvestor.Checked = true;
        }


        private void InvestmentReport1(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investment.InvestmentListByInvestor.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("InvestmentReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }

        private void InvestmentReport2(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investment.InvestmentListByOpportunity.rdlc";
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


        public async void LoadOpportunityFrom()
        {
            var model = await _opportunityRepository.GetAllList();

            comboOpportunityFrom.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboOpportunityFrom.DisplayMember = _opportunity.CodeName;
            comboOpportunityFrom.ValueMember = _opportunity.opportunity_code;
            comboOpportunityFrom.SelectedItem = null;

            queryModel.OpportunityCodeFrom = model.FirstOrDefault().opportunity_code;
        }


        public async void LoadOpportunityTo()
        {
            var model = await _opportunityRepository.GetAllList();

            comboOpportunityTo.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboOpportunityTo.DisplayMember = _opportunity.CodeName;
            comboOpportunityTo.ValueMember = _opportunity.opportunity_code;
            comboOpportunityTo.SelectedItem = null;

            queryModel.OpportunityCodeTo = model.LastOrDefault().opportunity_code;
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


        private void comboOpportunityFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityListModel)comboOpportunityFrom.SelectedItem;
            var resultTo = (OpportunityListModel)comboOpportunityTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.opportunity_code, resultTo.opportunity_code) > 0)
                {
                    comboOpportunityFrom.SelectItemByValue(resultTo.opportunity_code);
                }
            }
        }

        private void comboOpportunityTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityListModel)comboOpportunityFrom.SelectedItem;
            var resultTo = (OpportunityListModel)comboOpportunityTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.opportunity_code, resultTo.opportunity_code) > 0)
                {
                    comboOpportunityTo.SelectItemByValue(resultFrom.opportunity_code);
                }
            }
        }


        private async Task GetParameters()
        {
            var investorModel = await _investorRepository.GetAllList();

            var investorFrom = (InvestorListModel)comboInvestorFrom.SelectedItem;

            investorModel = investorModel.OrderBy(x => x.CodeName);

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

            var opportunityModel = await _opportunityRepository.GetAllList();

            var codeFrom = (OpportunityListModel)comboOpportunityFrom.SelectedItem;

            opportunityModel = opportunityModel.OrderBy(x => x.CodeName);

            if (codeFrom.IsNullObject())
            {
                queryModel.OpportunityCodeFrom = opportunityModel.FirstOrDefault().opportunity_code;
                comboOpportunityFrom.SelectItemByValue(opportunityModel.FirstOrDefault().opportunity_code);
            }
            else
            {
                queryModel.OpportunityCodeFrom = codeFrom.opportunity_code;
            }

            var codeTo = (OpportunityListModel)comboOpportunityTo.SelectedItem;

            if (codeTo.IsNullObject())
            {
                queryModel.OpportunityCodeTo = opportunityModel.LastOrDefault().opportunity_code;
                comboOpportunityTo.SelectItemByValue(opportunityModel.LastOrDefault().opportunity_code);
            }
            else
            {
                queryModel.OpportunityCodeTo = codeTo.opportunity_code;
            }

        }

    
    }
}
