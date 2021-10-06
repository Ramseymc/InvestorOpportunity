using InvestorLibrary;
using InvestorLibrary.Investment;
using InvestorLibrary.Shared;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Investor.Investment
{
    public partial class InvestmentUpdateReport : Form
    {
        private readonly IInvestmentRepository _investmentRepository;

        private InvestmentReportQuery queryModel;

        public InvestmentUpdateReport()
        {
            InitializeComponent();

            _investmentRepository = (IInvestmentRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInvestmentRepository));

            queryModel = new InvestmentReportQuery();
        }



        private async void UpdateButton_Click(object sender, EventArgs e)
        {
            //Set the processing mode for the ReportViewer to Local
            reportViewer1.ProcessingMode = ProcessingMode.Local;

            var result = await _investmentRepository.ReportWithDates();

            if (radioStartDate.Checked)
            {
                var dtResult = result.Where(x => x.start_date >= dateFromDate.Value && x.start_date <= dateToDate.Value).OrderBy(x => x.start_date).DTOToDataTable();

                InvestmentReport(dtResult);
            }
            else
            {
                var dtResult = result.Where(x => x.lastUpdated >= dateFromDate.Value && x.start_date <= dateToDate.Value).OrderBy(x => x.lastUpdated).DTOToDataTable();

                InvestmentReport(dtResult);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void InvestmentUpdateReport_Load(object sender, EventArgs e)
        {
            reportViewer1.ZoomMode = ZoomMode.PageWidth;

            LoadFormDefaults();
        }


        private void InvestmentReport(DataTable table)
        {
            var localReport = reportViewer1.LocalReport;

            localReport.ReportEmbeddedResource = "Investor.Investment.InvestmentUpdate.rdlc";
            localReport.DataSources.Clear();
            localReport.DataSources.Add(new ReportDataSource("InvestmentReportSet", table));
            localReport.Refresh();

            reportViewer1.RefreshReport();
        }


        public void LoadFormDefaults()
        {
            radioStartDate.Checked = true;

            dateFromDate.Value = DateTime.Now.AddDays(-8);

            dateToDate.Value = DateTime.Now;
        }


        private void dateFromDate_ValueChanged(object sender, EventArgs e)
        {
            var resultFrom = dateFromDate.Value;
            var resultTo = dateToDate.Value;

            if (resultFrom != null && resultTo != null)
            {
                if (resultFrom > resultTo)
                {
                    dateFromDate.Value = dateToDate.Value;
                }
            }
        }


        private void dateToDate_ValueChanged(object sender, EventArgs e)
        {
            var resultFrom = dateFromDate.Value;
            var resultTo = dateToDate.Value;

            if (resultFrom != null && resultTo != null)
            {
                if (resultTo < resultFrom)
                {
                   dateToDate.Value = dateFromDate.Value;
                }
            }
        }


    }
}
