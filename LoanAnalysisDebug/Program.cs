using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysisDebug
{
    class Program
    {
        static void Main(string[] args)
        {

            double jumlahNew = 1000;
            double persenBunga = 7.5433;
            double perhitunganBunga = (double)((double)(16 / 360) * jumlahNew * persenBunga);
            double perhitunganBaru = persenBunga * jumlahNew * 16 / 360;
        }
    }
}
