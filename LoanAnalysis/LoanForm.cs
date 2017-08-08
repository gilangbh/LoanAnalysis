using LoanAnalysis.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanAnalysis
{
    public partial class LoanForm : Form
    {
        public Loan Loan { get; set; }
        public AppData data { get; set; }

        public LoanForm()
        {
            InitializeComponent();

            CalendarColumn col = new CalendarColumn();
            col.HeaderText = "Tanggal";

            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Format = "N2";

            dataGridViewPenarikan.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Jumlah", Width = 180,DefaultCellStyle = ds });
            dataGridViewPenarikan.Columns.Add(col);
            dataGridViewPenarikan.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridViewPenarikan.AllowUserToAddRows = false;
            dataGridViewPenarikan.AllowUserToOrderColumns = false;
            
            col = new CalendarColumn();
            col.HeaderText = "Tanggal";
            dataGridViewPembayaran.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Jumlah", Width = 180, DefaultCellStyle = ds });
            dataGridViewPembayaran.Columns.Add(col);
            dataGridViewPembayaran.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridViewPembayaran.AllowUserToAddRows = false;
            dataGridViewPembayaran.AllowUserToOrderColumns = false;

            foreach (DataGridViewRow row in this.dataGridViewPenarikan.Rows)
            {
                row.Cells[0].Value = null;
            }
            dataGridViewPenarikan.RowCount = 1;

            foreach (DataGridViewRow row in this.dataGridViewPembayaran.Rows)
            {
                row.Cells[0].Value = null;
            }
            dataGridViewPembayaran.RowCount = 1;
            dateTimePickerFirstRepayment.Enabled = false;

            dateTimePickerStartDate.Value = DateTime.Now;
        }

        public LoanForm(Loan loan)
        {
            InitializeComponent();
            CalendarColumn col = new CalendarColumn();
            col.HeaderText = "Tanggal";

            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Format = "N2";

            dataGridViewPenarikan.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Jumlah", Width = 180, DefaultCellStyle = ds });
            dataGridViewPenarikan.Columns.Add(col);
            dataGridViewPenarikan.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridViewPenarikan.AllowUserToAddRows = false;
            dataGridViewPenarikan.AllowUserToOrderColumns = false;

            col = new CalendarColumn();
            col.HeaderText = "Tanggal";
            dataGridViewPembayaran.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Jumlah", Width = 180, DefaultCellStyle = ds });
            dataGridViewPembayaran.Columns.Add(col);
            dataGridViewPembayaran.EditMode = DataGridViewEditMode.EditOnF2;
            dataGridViewPembayaran.AllowUserToAddRows = false;
            dataGridViewPembayaran.AllowUserToOrderColumns = false;

            if (loan.ListPenarikan == null)
            {
                loan.ListPenarikan = new List<Penarikan>();
            }

            if (loan.ListPenarikan.Count() > 0)
            {
                foreach (var penarikan in loan.ListPenarikan)
                {
                    dataGridViewPenarikan.Rows.Add(penarikan.Jumlah, penarikan.Tanggal);
                }
            }
            else
            {
                foreach (DataGridViewRow row in this.dataGridViewPenarikan.Rows)
                {
                    row.Cells[0].Value = null;
                }
                dataGridViewPenarikan.RowCount = 1;
            }
            
            foreach (DataGridViewRow row in this.dataGridViewPembayaran.Rows)
            {
                row.Cells[0].Value = null;
            }
            dataGridViewPembayaran.RowCount = 1;

            textBoxProfileName.Text = loan.Name;
            textBoxBankName.Text = loan.BankName;
            dateTimePickerStartDate.Value = loan.StartDate;
            numericGracePeriod.Value = loan.GracePeriod;
            numericInterest.Value = loan.InterestMonth;
            numericInterestRate.Value = (decimal)loan.InterestRate;
            numericLimit.Value = (decimal)loan.Limit;
            numericMargin.Value = (decimal)loan.Margin;
            numericRepayment.Value = loan.RepaymentMonth;
            numericTenor.Value = loan.Tenor;
            if (loan.FirstRepaymentDate != null && loan.IsUsingFirstRepaymentDate)
            {
                dateTimePickerFirstRepayment.Value = loan.FirstRepaymentDate;
                checkBoxUseFirstRepayment.Checked = loan.IsUsingFirstRepaymentDate;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (dataGridViewPenarikan.Focused && keyData == Keys.Tab)
            {
                if (dataGridViewPenarikan.CurrentCell.ColumnIndex == 1 && dataGridViewPenarikan.CurrentRow.Index == dataGridViewPenarikan.RowCount - 1)
                {
                    dataGridViewPenarikan.Rows.Add();
                    // we could return true; here to suppress the key
                    // but we really want to move on into the new row..!
                }
            }
            else if (dataGridViewPembayaran.Focused && keyData == Keys.Tab)
            {
                if (dataGridViewPembayaran.CurrentCell.ColumnIndex == 1 && dataGridViewPembayaran.CurrentRow.Index == dataGridViewPembayaran.RowCount - 1)
                {
                    dataGridViewPembayaran.Rows.Add();
                    // we could return true; here to suppress the key
                    // but we really want to move on into the new row..!
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Loan = new Loan();
            Loan.BankName = textBoxBankName.Text;

            Loan.StartDate = dateTimePickerStartDate.Value;
            Loan.GracePeriod = (int)numericGracePeriod.Value;
            Loan.InterestMonth = (int)numericInterest.Value;
            Loan.InterestRate = (double)numericInterestRate.Value;
            Loan.Limit = (double)numericLimit.Value;
            Loan.Margin = (double)numericMargin.Value;
            Loan.Name = textBoxProfileName.Text;
            Loan.RepaymentMonth = (int)numericRepayment.Value;
            Loan.Tenor = (int)numericTenor.Value;
            Loan.IsUsingFirstRepaymentDate = checkBoxUseFirstRepayment.Checked;
            if (Loan.IsUsingFirstRepaymentDate)
            {
                Loan.FirstRepaymentDate = dateTimePickerFirstRepayment.Value;
            }

            DateTime currentDate = Loan.StartDate;

            List<Penarikan> penarikans = new List<Penarikan>();
            foreach (DataGridViewRow item in dataGridViewPenarikan.Rows)
            {
                if (item.Cells[0].Value != null && item.Cells[1].Value != null)
                {
                    double jumlah = double.Parse(item.Cells[0].Value.ToString());
                    DateTime tanggal = DateTime.Parse(item.Cells[1].Value.ToString());
                    Penarikan p = new Penarikan() { Jumlah = jumlah, Tanggal = tanggal };
                    penarikans.Add(p);
                    penarikans.OrderBy(x => x.Tanggal);
                }
            }

            Loan.ListPenarikan = new List<Penarikan>();
            Loan.ListPenarikan.AddRange(penarikans);

            List<Pembayaran> pembayarans = new List<Pembayaran>();
            foreach (DataGridViewRow item in dataGridViewPembayaran.Rows)
            {
                if (item.Cells[0].Value != null && item.Cells[1].Value != null)
                {
                    double jumlah = double.Parse(item.Cells[0].Value.ToString());
                    DateTime tanggal = DateTime.Parse(item.Cells[1].Value.ToString());
                    Pembayaran p = new Pembayaran() { Jumlah = jumlah, Tanggal = tanggal };
                    pembayarans.Add(p);
                    pembayarans.OrderBy(x => x.Tanggal);
                }
            }

            Loan.ListPembayaran = new List<Pembayaran>();
            Loan.ListPembayaran.AddRange(pembayarans);

            Loan.LoanDetails = Calculator.CalculateLoanDetails(Loan);
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkBoxUseFirstRepayment_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbIsUsingFirstRepayment = (CheckBox)sender;
            if (cbIsUsingFirstRepayment.Checked)
            {
                dateTimePickerFirstRepayment.Enabled = true;
            }
            else
            {
                dateTimePickerFirstRepayment.Enabled = false;
            }
        }
    }
}
