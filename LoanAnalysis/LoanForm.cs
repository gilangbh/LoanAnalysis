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

        private void ProcessCalculateLoan()
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

            DateTime currentDate = Loan.StartDate;

            List<Penarikan> penarikans = new List<Penarikan>();
            foreach (DataGridViewRow item in dataGridViewPenarikan.Rows)
            {
                if (item.Cells[0].Value != null && item.Cells[1].Value != null)
                {
                    double jumlah = Double.Parse(item.Cells[0].Value.ToString());
                    DateTime tanggal = DateTime.Parse(item.Cells[1].Value.ToString());
                    Penarikan p = new Penarikan() { Jumlah = jumlah, Tanggal = tanggal };
                    penarikans.Add(p);
                    penarikans.OrderBy(x => x.Tanggal);
                }
            }
            Loan.ListPenarikan = new List<Penarikan>();
            Loan.ListPenarikan.AddRange(penarikans);

            DataTable table = new DataTable();
            table.Columns.Add("Tanggal", typeof(DateTime));
            table.Columns.Add("Penarikan", typeof(double));
            table.Columns.Add("Saldo Akhir Hutang", typeof(double));
            table.Columns.Add("Tanggal Jatuh Tempo", typeof(DateTime));
            table.Columns.Add("Jumlah Hari", typeof(int));
            table.Columns.Add("% JIBOR", typeof(double));
            table.Columns.Add("% Bunga", typeof(double));
            table.Columns.Add("Perhitungan Bunga", typeof(double));
            table.Columns.Add("Pokok", typeof(double));
            table.Columns.Add("Pembayaran Bunga", typeof(double));
            table.Columns.Add("Total", typeof(double));

            DateTime End = Loan.StartDate.AddYears(Loan.Tenor);

            while (currentDate < End)
            {
                DateTime jatuhtempo = currentDate;

                int daydiff = 0;
                if (currentDate != Loan.StartDate)
                {
                    daydiff = (currentDate - currentDate.AddMonths(-1)).Days;
                }

                double penarikan = 0;
                if (penarikans.Any(x => x.Tanggal == currentDate))
                {
                    penarikan = penarikans.Single(x => x.Tanggal == currentDate).Jumlah;
                }
                table.Rows.Add(currentDate, 0, 0, currentDate, daydiff, numericInterestRate.Value, numericInterestRate.Value + numericMargin.Value, 0, 0, 0, 0);

                currentDate = currentDate.AddMonths(1);
            }

            if (penarikans.Count > 0)
            {
                int totalTenor = Loan.Tenor * 12;
                int firstRepayment = Loan.GracePeriod + 6;
                int repaymentspreading = ((totalTenor - firstRepayment) / Loan.RepaymentMonth) + 1;

                double pokok = Loan.Limit / repaymentspreading;

                DateTime firstRepaymentDate = penarikans[0].Tanggal.AddMonths(firstRepayment);

                List<DateTime> jadwalBayarPokok = new List<DateTime>();
                //jadwalBayarPokok.Add(firstRepaymentDate);

                for (int i = 0; i < repaymentspreading; i++)
                {
                    jadwalBayarPokok.Add(firstRepaymentDate.AddMonths(i * Loan.RepaymentMonth));
                }

                foreach (var item in penarikans)
                {
                    int dueDay = Loan.StartDate.Day;
                    int penarikanDay = item.Tanggal.Day;
                    DateTime targetInsertRowDate;

                    if (penarikanDay < dueDay)
                    {
                        targetInsertRowDate = new DateTime(item.Tanggal.Year, item.Tanggal.Month, Loan.StartDate.Day);
                    }
                    else
                    {
                        targetInsertRowDate = new DateTime(item.Tanggal.Year, item.Tanggal.Month + 1, Loan.StartDate.Day);
                    }
                    DataRow[] FoundRows;
                    FoundRows = table.Select("[Tanggal Jatuh Tempo] = '" + targetInsertRowDate + "'");

                    if (FoundRows.Count() > 0)
                    {
                        DataRow foundRow = FoundRows.FirstOrDefault();
                        int pos = table.Rows.IndexOf(foundRow);
                        //0table.Columns.Add("Tanggal", typeof(DateTime));
                        //1table.Columns.Add("Penarikan", typeof(double));
                        //2table.Columns.Add("Saldo Akhir Hutang", typeof(double));
                        //3table.Columns.Add("Tanggal Jatuh Tempo", typeof(DateTime));
                        //4table.Columns.Add("Jumlah Hari", typeof(int));
                        //5table.Columns.Add("% JIBOR", typeof(double));
                        //6table.Columns.Add("% Bunga", typeof(double));
                        //7table.Columns.Add("Perhitungan Bunga", typeof(double));
                        //8table.Columns.Add("Pokok", typeof(double));
                        //9table.Columns.Add("Akumulasi Bunga", typeof(double));
                        //10table.Columns.Add("Total", typeof(double));

                        int daydiff = 0;
                        daydiff = (item.Tanggal - DateTime.Parse(table.Rows[pos - 1][3].ToString())).Days;

                        double jumlahNew = (double)table.Rows[pos - 1][2] + item.Jumlah;
                        double persenBunga = (double)numericInterestRate.Value + (double)numericMargin.Value;
                        double perhitunganBunga = Math.Round(persenBunga * jumlahNew * daydiff / 360);

                        DataRow row = table.NewRow();
                        row[0] = item.Tanggal;
                        row[1] = item.Jumlah;
                        row[2] = jumlahNew;
                        row[3] = item.Tanggal;
                        row[4] = daydiff;
                        row[5] = numericInterestRate.Value;
                        row[6] = persenBunga;
                        row[7] = perhitunganBunga;
                        row[8] = 0;
                        row[9] = 0;
                        row[10] = 0;

                        table.Rows.InsertAt(row, pos);

                        for (int i = pos + 1; i < table.Rows.Count; i++)
                        {
                            if (jadwalBayarPokok.Any(x => x == DateTime.Parse(table.Rows[i][3].ToString())))
                            {
                                table.Rows[i][8] = pokok;
                            }
                            jumlahNew = (double)table.Rows[i - 1][2] + (double)table.Rows[i][1] - (double)table.Rows[i][8];
                            daydiff = (DateTime.Parse(table.Rows[i][3].ToString()) - DateTime.Parse(table.Rows[i - 1][3].ToString())).Days;
                            table.Rows[i][2] = jumlahNew;
                            table.Rows[i][4] = daydiff;
                            table.Rows[i][7] = Math.Round(persenBunga * jumlahNew * daydiff / 360);
                            table.Rows[i][10] = (double)table.Rows[i][8] + (double)table.Rows[i][7];
                        }
                    }
                }
            }

            Loan.LoanDetails = table;
        }

        private void ProcessCalculateLoanNew()
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

            DataTable table = new DataTable();
            table.Columns.Add("Tanggal", typeof(DateTime));
            table.Columns.Add("Penarikan", typeof(double));
            table.Columns.Add("Saldo Akhir Hutang", typeof(double));
            table.Columns.Add("Tanggal Jatuh Tempo", typeof(DateTime));
            table.Columns.Add("Jumlah Hari", typeof(int));
            table.Columns.Add("% JIBOR", typeof(double));
            table.Columns.Add("% Bunga", typeof(double));
            table.Columns.Add("Perhitungan Bunga", typeof(double));
            table.Columns.Add("Pokok", typeof(double));
            table.Columns.Add("Pembayaran Bunga", typeof(double));
            table.Columns.Add("Total", typeof(double));

            //int daydiff = (currentDate - LoanProfile.StartDate).Days;
            //table.Rows.Add(currentDate, 0, 0, currentDate, daydiff, numericInterestRate.Value, numericInterestRate.Value + numericMargin.Value, 0, 0, 0, 0);

            if (Loan.ListPenarikan.Count > 0)
            {
                int totalTenor = Loan.Tenor * 12;
                int firstPokokRepayment = Loan.GracePeriod + 6;
                int pokokRepaymentSpreading = ((totalTenor - firstPokokRepayment) / Loan.RepaymentMonth) + 1;
                int interestRepaymentSpreading = (int)Math.Ceiling((double)(totalTenor / Loan.InterestMonth)) + 1;

                double pokok = Loan.Limit / pokokRepaymentSpreading;

                DateTime firstRepaymentDate = Loan.ListPenarikan[0].Tanggal.AddMonths(firstPokokRepayment);

                List<DateTime> jadwalBayarPokok = new List<DateTime>();

                for (int i = 0; i < pokokRepaymentSpreading; i++)
                {
                    jadwalBayarPokok.Add(firstRepaymentDate.AddMonths(i * Loan.RepaymentMonth));
                }

                DateTime firstInterestRepaymentDate = Loan.ListPenarikan[0].Tanggal.AddMonths(Loan.RepaymentMonth);
                List<DateTime> jadwalBayarInterest = new List<DateTime>();

                for (int i = 0; i < interestRepaymentSpreading; i++)
                {
                    jadwalBayarInterest.Add(firstInterestRepaymentDate.AddMonths(i * Loan.InterestMonth));
                }

                DateTime end = Loan.ListPenarikan[0].Tanggal.AddYears(Loan.Tenor);

                //Generate row
                int tanggalPatokan = Loan.StartDate.Day;

                List<DateTime> rowDates = new List<DateTime>();

                int beforeFirstPenarikan = Math.Abs(currentDate.TotalMonths(Loan.ListPenarikan[0].Tanggal));

                for (int i = 0; i < beforeFirstPenarikan; i++)
                {
                    rowDates.Add(currentDate.AddMonths(i));
                }

                tanggalPatokan = Loan.ListPenarikan[0].Tanggal.Day;
                currentDate = Loan.ListPenarikan[0].Tanggal;

                for (int i = 0; i < Loan.Tenor * 12; i++)
                {
                    rowDates.Add(currentDate.AddMonths(i));
                }

                foreach (var item in Loan.ListPenarikan)
                {
                    rowDates.Add(item.Tanggal);
                }

                rowDates.Sort();
                rowDates = rowDates.Distinct().ToList();

                foreach (var item in rowDates)
                {
                    double jumlahPenarikan = 0;
                    double saldoakhirhutang = 0;
                    double persenBunga = (double)numericInterestRate.Value + (double)numericMargin.Value;
                    int jmlhHari = 0;


                    if (Loan.ListPenarikan.Any(x => x.Tanggal == item))
                    {
                        Penarikan p = Loan.ListPenarikan.SingleOrDefault(x => x.Tanggal == item);
                        jumlahPenarikan = p.Jumlah;
                    }

                    bool bayarPokok = jadwalBayarPokok.Any(x => x == item);
                    double currentPokok = bayarPokok ? pokok : 0;

                    if (table.Rows.Count == 0)
                    {
                        jmlhHari = (item - Loan.StartDate).Days;
                        saldoakhirhutang = jumlahPenarikan;
                    }
                    else
                    {
                        jmlhHari = (item - DateTime.Parse(table.Rows[table.Rows.Count - 1][3].ToString())).Days;
                        saldoakhirhutang = (double)table.Rows[table.Rows.Count - 1][2] + jumlahPenarikan - currentPokok;
                    }

                    double perhitunganBunga = persenBunga * saldoakhirhutang * jmlhHari / 360 / 100;
                    bool bayarBunga = jadwalBayarInterest.Any(x => x == item);
                    double currentBunga = 0;

                    if (bayarBunga)
                    {
                        currentBunga += perhitunganBunga;
                        for(int i = 1; i < Loan.InterestMonth; i++)
                        {
                            currentBunga += (double)table.Rows[table.Rows.Count - i][7];
                        }
                    }

                    DataRow row = table.NewRow();
                    row[0] = item;
                    row[1] = jumlahPenarikan;
                    row[2] = Math.Round(saldoakhirhutang,2);
                    row[3] = item;
                    row[4] = jmlhHari;
                    row[5] = numericInterestRate.Value;
                    row[6] = persenBunga;
                    row[7] = Math.Round(perhitunganBunga,2);
                    row[8] = Math.Round(currentPokok,2);
                    row[9] = Math.Round(currentBunga,2);
                    row[10] = Math.Round(currentPokok + perhitunganBunga,2);

                    table.Rows.Add(row);
                }
            }

            Loan.LoanDetails = table;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
