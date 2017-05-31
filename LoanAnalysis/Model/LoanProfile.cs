using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class LoanProfile
    {
        public string Name { get; set; }
        public List<Loan> Loans { get; set; }
    }
}
