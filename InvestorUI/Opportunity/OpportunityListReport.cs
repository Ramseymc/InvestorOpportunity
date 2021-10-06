using InvestorLibrary;
using InvestorLibrary.Opportunity;
using InvestorLibrary.OpportunityCategory;
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

namespace InvestorUI.Opportunity
{
    public partial class OpportunityListReport : Form
    {
        private readonly IOpportunityCategoryRepository _opportunityCategoryRepository;
        private readonly IOpportunityRepository _opportunityRepository;

        private OpportunityReportQuery queryModel;

        public OpportunityListReport()
        {
            InitializeComponent();

            _opportunityCategoryRepository = (IOpportunityCategoryRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityCategoryRepository));
            _opportunityRepository = (IOpportunityRepository)ContainerConfig.ServiceProvider.GetService(typeof(IOpportunityRepository));

            queryModel = new OpportunityReportQuery();
        }

        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            await GetParameters();

            //Set the processing mode for the ReportViewer to Local
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            if (checkCategory.Checked)
            {
                var result = await _opportunityRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.Category).ThenBy(x => x.opportunity_code).DTOToDataTable();

                OpportunityReport1(dtResult);
            }
            else
            {
                var result = await _opportunityRepository.ReportGetWhere(queryModel);

                var dtResult = result.OrderBy(x => x.opportunity_code).DTOToDataTable();

                OpportunityReport2(dtResult);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpportunityListReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            LoadCategoriesFrom();

            LoadCategoriesTo();

            LoadOpportunityFrom();

            LoadOpportunityTo();

           // queryModel = new ReportQuery();
        }



        private void OpportunityReport1(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Opportunity.OpportunityListCategory.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("OpportunityReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }

        private void OpportunityReport2(DataTable table)
        {
            ////Set the processing mode for the ReportViewer to Local
            //reportViewer1.ProcessingMode = ProcessingMode.Local;

            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Opportunity.OpportunityList.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("OpportunityReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }


        public async void LoadCategoriesFrom()
        {
            var model = await _opportunityCategoryRepository.GetAllList();

            comboCategoryFrom.DataSource = model.OrderBy(x => x.Description).ToList();
            comboCategoryFrom.DisplayMember = _opportunityCategory.Description;
            comboCategoryFrom.ValueMember = _opportunityCategory.Description;
            comboCategoryFrom.SelectedItem = null;

            queryModel.CategoryCodeFrom = model.FirstOrDefault().Description;
        }


        public async void LoadCategoriesTo()
        {
            var model = await _opportunityCategoryRepository.GetAllList();

            comboCategoryTo.DataSource = model.OrderBy(x => x.Description).ToList();
            comboCategoryTo.DisplayMember = _opportunityCategory.Description;
            comboCategoryTo.ValueMember = _opportunityCategory.Description;
            comboCategoryTo.SelectedItem = null;

            queryModel.CategoryCodeTo = model.LastOrDefault().Description;
        }


        public async void LoadOpportunityFrom()
        {
            var model = await _opportunityRepository.GetAllList();

            comboCodeFrom.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboCodeFrom.DisplayMember = _opportunity.CodeName;
            comboCodeFrom.ValueMember = _opportunity.opportunity_code;
            comboCodeFrom.SelectedItem = null;

            queryModel.OpportunityCodeFrom = model.FirstOrDefault().opportunity_code;
        }


        public async void LoadOpportunityTo()
        {
            var model = await _opportunityRepository.GetAllList();

            comboCodeTo.DataSource = model.OrderBy(x => x.CodeName).ToList();
            comboCodeTo.DisplayMember = _opportunity.CodeName;
            comboCodeTo.ValueMember = _opportunity.opportunity_code;
            comboCodeTo.SelectedItem = null;

            queryModel.OpportunityCodeTo = model.LastOrDefault().opportunity_code;
        }


        private void comboCategoryFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityCategoryListModel)comboCategoryFrom.SelectedItem;
            var resultTo = (OpportunityCategoryListModel)comboCategoryTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.Description, resultTo.Description) > 0)
                {
                    comboCategoryFrom.SelectItemByValue(resultTo.Description);
                }
            }
        }

        private void comboCategoryTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityCategoryListModel)comboCategoryFrom.SelectedItem;
            var resultTo = (OpportunityCategoryListModel)comboCategoryTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.Description, resultTo.Description) > 0)
                {
                    comboCategoryTo.SelectItemByValue(resultFrom.Description);
                }
            }
        }


        private void comboCodeFrom_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityListModel)comboCodeFrom.SelectedItem;
            var resultTo = (OpportunityListModel)comboCodeTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.opportunity_code, resultTo.opportunity_code) > 0)
                {
                    comboCodeFrom.SelectItemByValue(resultTo.opportunity_code);
                }
            }
        }

        private void comboCodeTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var resultFrom = (OpportunityListModel)comboCodeFrom.SelectedItem;
            var resultTo = (OpportunityListModel)comboCodeTo.SelectedItem;

            if (resultFrom != null && resultTo != null)
            {
                if (string.Compare(resultFrom.opportunity_code, resultTo.opportunity_code) > 0)
                {
                    comboCodeTo.SelectItemByValue(resultFrom.opportunity_code);
                }
            }
        }



        private async Task GetParameters()
        {
            var categoryModel = await _opportunityCategoryRepository.GetAllList();

            var categoryFrom = (OpportunityCategoryListModel)comboCategoryFrom.SelectedItem;

            categoryModel = categoryModel.OrderBy(x => x.Description);

            if (categoryFrom.IsNullObject())
            {
                queryModel.CategoryCodeFrom = categoryModel.FirstOrDefault().Description;
                comboCategoryFrom.SelectItemByValue(categoryModel.FirstOrDefault().Description);
            }
            else
            {
                queryModel.CategoryCodeFrom = categoryFrom.Description;
            }

            var categoryTo = (OpportunityCategoryListModel)comboCategoryTo.SelectedItem;

            if (categoryTo.IsNullObject())
            {
                queryModel.CategoryCodeTo = categoryModel.LastOrDefault().Description;
                comboCategoryTo.SelectItemByValue(categoryModel.LastOrDefault().Description);
            }
            else
            {
                queryModel.CategoryCodeTo = categoryTo.Description;
            }

            var opportunityModel = await _opportunityRepository.GetAllList();

            var codeFrom = (OpportunityListModel)comboCodeFrom.SelectedItem;

            opportunityModel = opportunityModel.OrderBy(x => x.opportunity_code);

            if (codeFrom.IsNullObject())
            {
                queryModel.OpportunityCodeFrom = opportunityModel.FirstOrDefault().opportunity_code;
                comboCodeFrom.SelectItemByValue(opportunityModel.FirstOrDefault().opportunity_code);
            }
            else
            {
                queryModel.OpportunityCodeFrom = codeFrom.opportunity_code;
            }

            var codeTo = (OpportunityListModel)comboCodeTo.SelectedItem;

            if (codeTo.IsNullObject())
            {
                queryModel.OpportunityCodeTo = opportunityModel.LastOrDefault().opportunity_code;
                comboCodeTo.SelectItemByValue(opportunityModel.LastOrDefault().opportunity_code);
            }
            else
            {
                queryModel.OpportunityCodeTo = codeTo.opportunity_code;
            }

        }


    }
}


