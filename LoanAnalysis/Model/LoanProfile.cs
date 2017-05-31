using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class LoanProfile : ICloneable
    {
        public string Name { get; set; }
        public List<Loan> Loans { get; set; }

        public object Clone()
        {
            LoanProfile profile = new LoanProfile();
            profile.Name = Name;
            profile.Loans = new List<Loan>();
            profile.Loans.AddRange(Loans);

            return profile;
        }
    }
}
