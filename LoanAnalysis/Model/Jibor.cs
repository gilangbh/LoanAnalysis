using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class Jibor : ICloneable
    {
        public DateTime Tanggal { get; set; }
        public double Rate { get; set; }

        public object Clone()
        {
            Jibor jibor = new Jibor();
            jibor.Tanggal = this.Tanggal;
            jibor.Rate = this.Rate;

            return jibor;
        }
    }
}
