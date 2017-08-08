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

namespace LoanAnalysis
{
    public partial class JiborListForm : Form
    {
        AppData data;
        public JiborListForm(AppData source)
        {
            InitializeComponent();
            this.data = source;

            CalendarColumn col = new CalendarColumn();
            col.HeaderText = "Tanggal";
            col.CellTemplate.Style.Format = "yyyy-MM-dd";

            DataGridViewCellStyle ds = new DataGridViewCellStyle();
            ds.Format = "N2";

            dataGridViewJiborList.Columns.Add(col);
            dataGridViewJiborList.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = "Rate JIBOR", Width = 180, DefaultCellStyle = ds });
            dataGridViewJiborList.EditMode = DataGridViewEditMode.EditOnF2;
            //dataGridViewJiborList.AllowUserToAddRows = false;
            dataGridViewJiborList.AllowUserToOrderColumns = false;

            //List<Jibor> jiborList = data.JiborList.ToList();

            foreach (DataGridViewRow row in this.dataGridViewJiborList.Rows)
            {
                row.Cells[0].Value = null;
            }
            //dataGridViewJiborList.RowCount = 1;

        }
    }
}