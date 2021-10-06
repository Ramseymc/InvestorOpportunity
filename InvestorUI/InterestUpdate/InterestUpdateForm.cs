using InvestorLibrary;
using InvestorLibrary.Interest;
using InvestorLibrary.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestorUI
{
    public partial class InterestUpdateForm : Form
    {
        private readonly IInterestRepository _interestRepository;

        private InterestUpdateController _interestController;

        public InterestUpdateForm()
        {
            InitializeComponent();

            _interestRepository = (IInterestRepository)ContainerConfig.ServiceProvider.GetService(typeof(IInterestRepository));

            _interestController = new InterestUpdateController(this);
        }


        private void WindowMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void WindowMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void WindowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            //_investmentController.ResetFields();

            //comboSearchList.SelectedItem = null;

            //comboInvestor.Focus();

            //ButtonActions(FormAction.AddEdit);
        }



        private async void UpdateInvestments_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Confirm update of Interest Rate. Ensure that the interest rate and date of change is correct. This action cannot be undone.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.OK)
                {
                    var model = (IEnumerable<InterestViewModel>)gridInvestments.DataSource;

                    await _interestRepository.UpdateInvestmentRates(model, dateChangeDate.Value.ToString());

                    gridInvestments.DataSource = null;
                    gridInvestments.Rows.Clear();

                    textOldInterestRate.Clear();
                    textNewInterestRate.Clear();
                    dateChangeDate.Value = DateTime.Now;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Records: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void updatePledges_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = MessageBox.Show("Confirm update of Interest Rate. Ensure that the interest rate and date of change is correct. This action cannot be undone.", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.OK)
                {
                    var model = (IEnumerable<InterestViewModel>)gridInvestPledges.DataSource;

                    await _interestRepository.UpdatePledgeRates(model, dateChangeDate.Value.ToString());                    

                    gridInvestPledges.DataSource = null;
                    gridInvestPledges.Rows.Clear();

                    textOldInterestRate.Clear();
                    textNewInterestRate.Clear();
                    dateChangeDate.Value = DateTime.Now;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Records: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        
        private void dateChangeDate_Leave(object sender, EventArgs e)
        {
            dateChangeDate.Format = DateTimePickerFormat.Short;

            if (dateChangeDate.IsNotNullObject())
            {
                _interestController.UpdateInvestmentData();
            }
        }


        private void textOldInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textOldInterestRate_Leave(object sender, EventArgs e)
        {
            var result = textOldInterestRate.Text.GetDoubleValue();

            if (result != 0)
            {
                textOldInterestRate.Text = string.Format("{0:N2}", result);

                _interestController.UpdateInvestmentData();
            }
        }


        private void textNewInterestRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!e.KeyChar.InputIsDecimal())
            {
                e.Handled = true;
            }
        }

        private void textNewInterestRate_Leave(object sender, EventArgs e)
        {
            var result = textNewInterestRate.Text.GetDoubleValue();

            if (result != 0)
            {
                textNewInterestRate.Text = string.Format("{0:N2}", result);

                if (tabControl1.SelectedTab.Text == "Investments")
                {
                    var model = (IEnumerable<InterestViewModel>)gridInvestments.DataSource;

                    foreach (var item in model)
                    {
                        item.NewInterestRate = double.Parse(textNewInterestRate.Text);
                        item.Selected = true;
                    }

                    gridInvestments.DataSource = model;
                    gridInvestments.Refresh();
                }


                if (tabControl1.SelectedTab.Text == "Pledges")
                {
                    var model = (IEnumerable<InterestViewModel>)gridInvestPledges.DataSource;

                    foreach (var item in model)
                    {
                        item.NewInterestRate = double.Parse(textNewInterestRate.Text);
                        item.Selected = true;
                    }

                    gridInvestPledges.DataSource = model;
                    gridInvestPledges.Refresh();
                }

            }
        }


        private void gridInvestments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var currentColumn = gridInvestments.Columns[gridInvestments.CurrentCell.ColumnIndex].Name;

            var currentRow = gridInvestments.CurrentRow.Index;

            if (gridInvestments.CurrentCell.Value.IsNotNullObject())
            {
                if (currentColumn == _interest.Selected)
                {
                    var cellValue = bool.Parse(gridInvestments.CurrentCell.EditedFormattedValue.ToString());

                    if (cellValue == true)
                    {
                        gridInvestments.CurrentRow.Cells[_interest.NewInterestRate].Value = textNewInterestRate.Text;
                    }
                    else
                    {
                        gridInvestments.CurrentRow.Cells[_interest.NewInterestRate].Value = "";
                    }

                }

            }
        }

        private void gridInvestments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore default errors.
        }

        private void gridInvestPledges_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Ignore default errors.
        }

        private void InterestUpdateForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}


