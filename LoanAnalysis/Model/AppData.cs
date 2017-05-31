using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class AppData
    {
        public BindingList<Loan> Loans { get; set; }
        public Loan SelectedLoan { get; set; }
        public BindingList<LoanProfile> LoanProfiles { get; set; }
    }
}
