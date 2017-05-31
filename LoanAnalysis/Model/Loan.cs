using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class Loan : ICloneable
    {
        public string Name { get; set; }
        public string BankName { get; set; }
        public DateTime StartDate { get; set; }
        public int Year { get { return StartDate.Year; } }
        public double Limit { get; set; }
        public int Tenor { get; set; }
        public int GracePeriod { get; set; }
        public int InterestMonth { get; set; }
        public int RepaymentMonth { get; set; }
        public double InterestRate { get; set; }
        public double Margin { get; set; }
        public List<Penarikan> ListPenarikan { get; set; }
        public List<Pembayaran> ListPembayaran { get; set; }
        public LoanRow[] LoanRows { get; set; }
        public DataTable LoanDetails { get; set; }
        public string LoanProfileName { get; set; }

        public Loan()
        {
            ListPenarikan = new List<Penarikan>();
            ListPembayaran = new List<Pembayaran>();
        }

        public object Clone()
        {
            Loan loan = new Loan();
            loan.Name = Name;
            loan.BankName = BankName;
            loan.StartDate = StartDate;
            loan.Limit = Limit;
            loan.Tenor = Tenor;
            loan.GracePeriod = GracePeriod;
            loan.InterestMonth = InterestMonth;
            loan.RepaymentMonth = RepaymentMonth;
            loan.InterestRate = InterestRate;
            loan.Margin = Margin;
            loan.ListPenarikan = new List<Penarikan>();
            loan.ListPenarikan.AddRange(ListPenarikan);
            loan.ListPembayaran = new List<Pembayaran>();
            loan.ListPembayaran.AddRange(ListPembayaran);
            loan.LoanDetails = LoanDetails.Copy();
            loan.LoanProfileName = LoanProfileName;

            return loan;
            
        }
    }

    public class Penarikan
    {
        public double Jumlah { get; set; }
        public DateTime Tanggal { get; set; }
    }
    public class Pembayaran
    {
        public DateTime Tanggal { get; set; }
        public double Jumlah { get; set; }
    }
}
