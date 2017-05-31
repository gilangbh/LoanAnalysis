using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class LoanRow
    {
        public double Penarikan { get; set; }
        public double SaldoAkhirHutang { get; set; }
        public DateTime TglJatuhTempo { get; set; }
        public int JumlahHari { get; set; }
        public double Bunga { get; set; }
        public double PerhitunganBunga { get; set; }
        public double Pokok { get; set; }
        public double AkumulasiBunga { get; set; }
        public double Total { get; set; }
    }
}
