using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanAnalysis.Model
{
    public class Report
    {
        public string Name { get; set; }
        public LoanProfile LoanProfile { get; set; }
        public ReportType Type { get; set; }
        public DataTable Data { get; set; }
    }
    public enum ReportType
    {
        POKOKBULANAN,
        BUNGABULANAN,
        BUNGATAHUNAN,
        OUTSTANDINGTAHUNAN
    }
}