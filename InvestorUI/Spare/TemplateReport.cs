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
    public partial class TemplateReport : Form
    {
        public TemplateReport()
        {
            InitializeComponent();
        }

        private void OpportunityListReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
