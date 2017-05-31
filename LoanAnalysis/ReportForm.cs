using LoanAnalysis.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

namespace LoanAnalysis
{
    public partial class ReportForm : Form
    {
        public Report Report { get; set; }
        public ReportForm()
        {
            InitializeComponent();
        }

        public ReportForm(Report Report)
        {
            InitializeComponent();

            this.Report = Report;
            dataGridView1.DataSource = Report.Data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = Report.Data;
            wb.Worksheets.Add(dt, "Report");

            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files|*.xlsx",
                Title = "Save an Excel File"
            };

            saveFileDialog.ShowDialog();

            if (!String.IsNullOrWhiteSpace(saveFileDialog.FileName))
                wb.SaveAs(saveFileDialog.FileName);

            MessageBox.Show("File saved successfully","Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
