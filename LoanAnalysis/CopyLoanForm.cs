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
    public partial class CopyLoanForm : Form
    {
        public List<string> loanprofilenames;
        public string selectedProfile;

        public CopyLoanForm()
        {
            InitializeComponent();    
        }

        public CopyLoanForm(List<string> loanprofilenames)
        {
            InitializeComponent();

            comboBoxProfiles.DataSource = loanprofilenames;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxProfiles.SelectedValue != null)
            {
                selectedProfile = comboBoxProfiles.SelectedValue.ToString();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Please choose a valid profile name", "No valid profile", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
