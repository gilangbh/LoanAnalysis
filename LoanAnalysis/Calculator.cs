using LoanAnalysis.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis
{
    public static class Calculator
    {
        public static DataTable CalculateLoanDetails(Loan Loan)
        {
            DateTime currentDate = Loan.StartDate;

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
                    double persenBunga = Loan.InterestRate + Loan.Margin;
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
                        for (int i = 1; i < Loan.InterestMonth; i++)
                        {
                            currentBunga += (double)table.Rows[table.Rows.Count - i][7];
                        }
                    }

                    DataRow row = table.NewRow();
                    row[0] = item;
                    row[1] = jumlahPenarikan;
                    row[2] = Math.Round(saldoakhirhutang, 2);
                    row[3] = item;
                    row[4] = jmlhHari;
                    row[5] = Loan.InterestRate;
                    row[6] = persenBunga;
                    row[7] = Math.Round(perhitunganBunga, 2);
                    row[8] = Math.Round(currentPokok, 2);
                    row[9] = Math.Round(currentBunga, 2);
                    row[10] = Math.Round(currentPokok + perhitunganBunga, 2);

                    table.Rows.Add(row);
                }
            }

            return table;
        }

        public static DataTable CalculateReportBungaBulanan(LoanProfile LoanProfile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Sisa Pokok");

            List<int> years = new List<int>();

            foreach (Loan loan in LoanProfile.Loans)
            {
                table.Columns.Add(loan.Name);

                foreach (DataRow loanRow in loan.LoanDetails.Rows)
                {
                    if (!years.Any(x => x == Convert.ToDateTime(loanRow[0]).Year))
                    {
                        years.Add(Convert.ToDateTime(loanRow[0]).Year);
                    }
                }
            }
            
            foreach (int year in years)
            {
                for (int i = 1; i < 13; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i.ToString("00") + "/" + year.ToString();

                    foreach (Loan loan in LoanProfile.Loans)
                    {
                        double bunga = 0;

                        if (loan.LoanDetails != null)
                        {
                            List<DataRow> rows = loan.LoanDetails.AsEnumerable().Where(x => DateTime.Parse(x[0].ToString()).Month == i && DateTime.Parse(x[0].ToString()).Year == year).ToList();
                            
                            foreach (DataRow insertedRow in rows)
                            {
                                bunga += (double)insertedRow[7];
                            }
                        }
                        int position = 1 + LoanProfile.Loans.IndexOf(loan);

                        row[position] = bunga;
                    }

                    table.Rows.Add(row);
                }

                DataRow summaryRow = table.NewRow();
                summaryRow[0] = year.ToString();
                
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        int pos = i;
                        double result = 0;
                        for (int j = table.Rows.Count - 12; j < table.Rows.Count; j++)
                        {
                            result += Convert.ToDouble(table.Rows[j][pos]);
                        }
                        summaryRow[pos] = result;
                    }
                }
                table.Rows.Add(summaryRow);
            }

            return table;
        }

        public static DataTable CalculateReportBungaTahunan(LoanProfile LoanProfile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Kreditur");
            table.Columns.Add("Tahun Kredit");
            table.Columns.Add("Limit Fasilitas");

            List<int> years = new List<int>();

            foreach (var loan in LoanProfile.Loans)
            {
                foreach (DataRow loanRow in loan.LoanDetails.Rows)
                {
                    if (!years.Any(x => x == Convert.ToDateTime(loanRow[0]).Year))
                    {
                        years.Add(Convert.ToDateTime(loanRow[0]).Year);
                        table.Columns.Add(Convert.ToDateTime(loanRow[0]).Year.ToString());
                    }
                }
            }

            foreach (var loan in LoanProfile.Loans)
            {
                DataRow row = table.NewRow();
                row[0] = loan.BankName;
                row[1] = loan.Year;
                row[2] = loan.Limit;

                foreach (var year in years)
                {
                    double result = 0;
                    foreach (DataRow loanRow in loan.LoanDetails.Rows)
                    {
                        if (Convert.ToDateTime(loanRow[0]).Year == year)
                        {
                            result += Convert.ToDouble(loanRow[9].ToString());
                            //continue;
                        }
                    }
                    int yearposition = 3 + years.IndexOf(year);
                    row[yearposition] = result;
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CalculateReportOutstandingLoanTahunan(LoanProfile LoanProfile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Kreditur");
            table.Columns.Add("Tahun Kredit");
            table.Columns.Add("Limit Fasilitas");

            List<int> years = new List<int>();

            foreach (var loan in LoanProfile.Loans)
            {
                foreach (DataRow loanRow in loan.LoanDetails.Rows)
                {
                    if (!years.Any(x => x == Convert.ToDateTime(loanRow[0]).Year))
                    {
                        years.Add(Convert.ToDateTime(loanRow[0]).Year);
                        table.Columns.Add(Convert.ToDateTime(loanRow[0]).Year.ToString());
                    }
                }
            }

            foreach (var loan in LoanProfile.Loans)
            {
                DataRow row = table.NewRow();
                row[0] = loan.BankName;
                row[1] = loan.Year;
                row[2] = loan.Limit;

                foreach (var year in years)
                {
                    foreach (DataRow loanRow in loan.LoanDetails.Rows)
                    {
                        double result = 0;
                        if (Convert.ToDateTime(loanRow[0]).Year == year && Convert.ToDateTime(loanRow[0]).Month == 12)
                        {
                            result = Convert.ToDouble(loanRow[2].ToString());
                            int yearposition = 3 + years.IndexOf(year);
                            row[yearposition] = result;

                            //continue;
                        }
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CalculateReportPokokBulanan(LoanProfile LoanProfile)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Sisa Pokok");

            List<int> years = new List<int>();

            foreach (Loan loan in LoanProfile.Loans)
            {
                table.Columns.Add(loan.Name);
                foreach (DataRow loanRow in loan.LoanDetails.Rows)
                {
                    if (!years.Any(x => x == Convert.ToDateTime(loanRow[0]).Year))
                    {
                        years.Add(Convert.ToDateTime(loanRow[0]).Year);
                    }
                }
            }
            foreach (int year in years)
            {
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (i > 0)
                    {

                    }
                }

                for (int i = 1; i < 13; i++)
                {
                    DataRow row = table.NewRow();
                    row[0] = i.ToString("00") + "/" + year.ToString();

                    foreach (Loan loan in LoanProfile.Loans)
                    {
                        double bunga = 0;

                        if (loan.LoanDetails != null)
                        {
                            List<DataRow> rows = loan.LoanDetails.AsEnumerable().Where(x => DateTime.Parse(x[0].ToString()).Month == i && DateTime.Parse(x[0].ToString()).Year == year).ToList();

                            foreach (DataRow insertedRow in rows)
                            {
                                bunga += (double)insertedRow[8];
                            }
                        }
                        int position = 1 + LoanProfile.Loans.IndexOf(loan);

                        row[position] = bunga;
                    }

                    table.Rows.Add(row);
                }

                DataRow summaryRow = table.NewRow();
                summaryRow[0] = year.ToString();

                for (int i = 0; i < table.Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        int pos = i;

                        string loanName = table.Columns[pos].ColumnName;
                        double pokok = 0;

                        if (table.Rows.Count == 12)
                        {
                            Loan loan = LoanProfile.Loans.SingleOrDefault(x => x.Name == loanName);
                            pokok = loan.Limit;
                        }
                        else
                        {
                            pokok = Convert.ToDouble(table.Rows[table.Rows.Count - 13][pos]);
                        }

                        double result = 0;
                        for (int j = table.Rows.Count - 12; j < table.Rows.Count; j++)
                        {
                            result += Convert.ToDouble(table.Rows[j][pos]);
                        }
                        summaryRow[pos] = pokok - result;
                    }
                }
                table.Rows.Add(summaryRow);
            }

            return table;
        }
    }
}