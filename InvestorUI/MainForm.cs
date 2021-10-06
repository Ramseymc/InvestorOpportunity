using Investor;
using Investor.Investment;
using Investor.Investor;
using InvestorUI.Investment;
using InvestorUI.Investor;
using InvestorUI.Opportunity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            stripDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            stripVersion.Text = " V " + Application.ProductVersion;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void portalUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new UserForm();

            form.Show();
            form.MdiParent = this;
        }

        private void investorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new InvestorForm();

            form.Show();
            form.MdiParent = this;
        }

        private void reportsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OpportunityCategoryForm();

            form.Show();
            form.MdiParent = this;
        }

        private void opportunityToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new OpportunityForm();

            form.Show();
            form.MdiParent = this;
        }

        private void reportsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new OpportunityListReport();

            form.Show();
            form.MdiParent = this;
        }

        private void investPledgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestPledgeForm();

            form.Show();
            form.MdiParent = this;
        }

        private void transactionTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new TransactionTypeForm();

            form.Show();
            form.MdiParent = this;
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var form = new InventoryReportForm();

            //form.Show();
            //form.MdiParent = this;
        }

        private void investmentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new InvestmentForm();

            form.Show();
            form.MdiParent = this;
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void interestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InterestUpdateForm();

            form.Show();
            form.MdiParent = this;
        }

        private void investorListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestorListReport();

            form.Show();
            form.MdiParent = this;
        }

        private void investorStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestorStatementReport();

            form.Show();
            form.MdiParent = this;
        }

        private void investmentListingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestmentListReport();

            form.Show();
            form.MdiParent = this;
        }

        private void investmentUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestmentUpdateReport();

            form.Show();
            form.MdiParent = this;
        }

        private void quickReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new InvestmentUpdateReport();
            // create a quick report form to launch here 

            form.Show();
            form.MdiParent = this;
        }
    }
}
