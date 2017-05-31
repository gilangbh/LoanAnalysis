using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoanAnalysis.Model;
using System.IO;
using Newtonsoft.Json;

namespace LoanAnalysis
{
    public partial class LoanProfileListForm : Form
    {
        string clickedNode;
        TreeNode clickedTreeNode;

        AppData data;
        public LoanProfileListForm()
        {
            InitializeComponent();
            data = Program.InitializeDatabase();

            Loan loan = new Loan();

            DataTable table = new DataTable();
            table.Columns.Add("Tanggal", typeof(DateTime));
            table.Columns.Add("Penarikan", typeof(double));
            table.Columns.Add("Saldo Akhir Hutang", typeof(double));
            table.Columns.Add("Tanggal Jatuh Tempo", typeof(DateTime));
            table.Columns.Add("Jumlah Hari", typeof(int));
            table.Columns.Add("% JIBOR", typeof(double));
            table.Columns.Add("% Bunga", typeof(double));
            table.Columns.Add("Perhitungan Bunga", typeof(double));
            table.Columns.Add("Pokok", typeof(double));
            table.Columns.Add("Pembayaran Bunga", typeof(double));
            table.Columns.Add("Total", typeof(double));

            loan.LoanDetails = table;
            //data.SelectedLoan = loan;

            BindTreeView();
            BindSelectedLoan();
        }

        private void BindTreeView()
        {
            treeView1.Nodes.Clear();

            foreach (var profile in data.LoanProfiles.OrderBy(x => x.Name))
            {
                TreeNode profileNode = new TreeNode("Profile:" + profile.Name);
                profileNode.Tag = profile;
                profileNode.Name = "Profile:" + profile.Name;
                profileNode.Nodes.Clear();

                foreach (var loan in profile.Loans.OrderBy(x => x.Name))
                {
                    TreeNode loanNode = new TreeNode("Loan:" + loan.Name);
                    loanNode.Tag = loan;
                    loanNode.Name = "Loan:" + loan.Name;

                    profileNode.Nodes.Add(loanNode);
                }

                treeView1.Nodes.Add(profileNode);
            }

            treeView1.ExpandAll();
        }

        private void BindSelectedLoan()
        {
            if (data.SelectedLoan == null)
            {
                data.SelectedLoan = new Loan();

                textBoxLoanName.Text = "";
                textBoxBankName.Text = "";
                textBoxTenor.Text = "";
                textBoxLimit.Text = "";
            }
            else
            {
                textBoxLoanName.Text = data.SelectedLoan.Name;
                textBoxBankName.Text = data.SelectedLoan.BankName;
                textBoxTenor.Text = data.SelectedLoan.Tenor.ToString() + " tahun";
                textBoxLimit.Text = string.Format("{0:n0} Rupiah", data.SelectedLoan.Limit);
            }

            if (data.SelectedLoan.LoanDetails == null || data.SelectedLoan.LoanDetails.Rows.Count < 1)
            {
                data.SelectedLoan.LoanDetails = new DataTable();
                data.SelectedLoan.LoanDetails.Columns.Add("Tanggal", typeof(DateTime));
                data.SelectedLoan.LoanDetails.Columns.Add("Penarikan", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Saldo Akhir Hutang", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Tanggal Jatuh Tempo", typeof(DateTime));
                data.SelectedLoan.LoanDetails.Columns.Add("Jumlah Hari", typeof(int));
                data.SelectedLoan.LoanDetails.Columns.Add("% JIBOR", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("% Bunga", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Perhitungan Bunga", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Pokok", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Pembayaran Bunga", typeof(double));
                data.SelectedLoan.LoanDetails.Columns.Add("Total", typeof(double));
            }

            dataGridViewLoanProfileDetails.DataSource = data.SelectedLoan.LoanDetails;
            dataGridViewLoanProfileDetails.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewLoanProfileDetails.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridViewLoanProfileDetails.Columns[1].DefaultCellStyle.Format = "N2";
            dataGridViewLoanProfileDetails.Columns[2].DefaultCellStyle.Format = "N2";
            dataGridViewLoanProfileDetails.Columns[7].DefaultCellStyle.Format = "N2";
            dataGridViewLoanProfileDetails.Columns[8].DefaultCellStyle.Format = "N2";
            dataGridViewLoanProfileDetails.Columns[9].DefaultCellStyle.Format = "N2";
            dataGridViewLoanProfileDetails.Columns[10].DefaultCellStyle.Format = "N2";

            dataGridViewLoanProfileDetails.AllowUserToAddRows = false;
            dataGridViewLoanProfileDetails.AllowUserToOrderColumns = false;

            foreach (DataGridViewColumn item in dataGridViewLoanProfileDetails.Columns)
            {
                item.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            if (data.SelectedLoan.ListPembayaran != null)
            {
                textBoxPelunasan.Text = data.SelectedLoan.ListPembayaran.Count() + " kali";
            }
            else
            {
                textBoxPelunasan.Text = "0 kali";
            }
            if (data.SelectedLoan.ListPenarikan != null)
            {
                textBoxPenarikan.Text = data.SelectedLoan.ListPenarikan.Count() + " kali";
            }
            else
            {
                textBoxPenarikan.Text = "0 kali";
            }
        }

        private void CreateNewProfile()
        {
            ProfileForm profileForm = new ProfileForm();
            profileForm.ShowDialog();

            if (profileForm.DialogResult == DialogResult.OK)
            {
                string loanProfileName = "";
                loanProfileName = profileForm.Text;
                while (data.LoanProfiles.Any(x => x.Name == loanProfileName))
                {
                    loanProfileName = loanProfileName + "_duplicatename";
                }

                LoanProfile loanProfile = new LoanProfile();
                loanProfile.Name = loanProfileName;
                loanProfile.Loans = new List<Loan>();
                data.LoanProfiles.Add(loanProfile);
                BindTreeView();
                Program.UpdateDatabase(data);
            }

        }

        private void EditProfile(LoanProfile sourceLoanProfile)
        {
            ProfileForm profileForm = new ProfileForm(sourceLoanProfile.Name);
            profileForm.ShowDialog();

            if (profileForm.DialogResult == DialogResult.OK)
            {
                string loanProfileName = "";

                loanProfileName = profileForm.Text;

                if (data.LoanProfiles.Any(x => x.Name == loanProfileName))
                {
                    MessageBox.Show("There is already a loan profile with the selected name. Please insert a different name.", "Loan profile already exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    LoanProfile changedProfile = data.LoanProfiles.SingleOrDefault(x => x.Name == sourceLoanProfile.Name);

                    if (changedProfile != null)
                    {
                        changedProfile.Name = loanProfileName;
                        foreach (var item in changedProfile.Loans)
                        {
                            item.LoanProfileName = loanProfileName;
                        }

                        data.SelectedLoan = new Loan();
                        BindTreeView();
                        BindSelectedLoan();
                        Program.UpdateDatabase(data);
                        MessageBox.Show("Profile name has been successfully changed", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

        private Report GenerateReport(LoanProfile Profile, ReportType type)
        {
            Report report = new Report();
            report.LoanProfile = Profile;
            switch (type)
            {
                case ReportType.BUNGABULANAN:
                    report.Data = Calculator.CalculateReportBungaBulanan(Profile);
                    report.Name = Profile.Name + " Report - Bunga Bulanan";
                    break;
                case ReportType.OUTSTANDINGTAHUNAN:
                    report.Data = Calculator.CalculateReportOutstandingLoanTahunan(Profile);
                    report.Name = Profile.Name + " Report - Outstanding Tahunan";
                    break;
                case ReportType.POKOKBULANAN:
                    report.Data = Calculator.CalculateReportPokokBulanan(Profile);
                    report.Name = Profile.Name + " Report - Pokok Bulanan";
                    break;
                case ReportType.BUNGATAHUNAN:
                    report.Data = Calculator.CalculateReportBungaTahunan(Profile);
                    report.Name = Profile.Name + " Report - Bunga Tahunan";
                    break;
            }

            return report;
        }

        private void CreateNewLoan()
        {
            LoanForm loanForm = new LoanForm();
            loanForm.ShowDialog();

            if (loanForm.DialogResult == DialogResult.OK)
            {
                LoanProfile profile = data.LoanProfiles.SingleOrDefault(x => x.Name == clickedNode.Split(':')[1]);

                if (profile != null)
                {
                    if (profile.Loans != null)
                    {
                        loanForm.Loan.LoanProfileName = profile.Name;
                        profile.Loans.Add(loanForm.Loan);
                    }
                    else
                    {
                        loanForm.Loan.LoanProfileName = profile.Name;
                        profile.Loans = new List<Loan>();
                        profile.Loans.Add(loanForm.Loan);
                    }
                }

                data.SelectedLoan = loanForm.Loan;
                BindTreeView();
                BindSelectedLoan();
                Program.UpdateDatabase(data);
            }
        }

        private void EditLoan(Loan editLoan)
        {
            LoanForm loanForm = new LoanForm(editLoan);
            loanForm.ShowDialog();

            if (loanForm.DialogResult == DialogResult.OK)
            {
                Loan oldLoan = editLoan;
                Loan newLoan = loanForm.Loan;

                string loanProfileName = oldLoan.LoanProfileName;
                newLoan.LoanProfileName = loanProfileName;

                LoanProfile profile = data.LoanProfiles.SingleOrDefault(x => x.Name == loanProfileName);

                if (profile != null)
                {
                    if (profile.Loans != null)
                    {
                        Loan targetLoan = profile.Loans.Where(x => x.Name == oldLoan.Name).SingleOrDefault();

                        profile.Loans.Remove(targetLoan);
                        profile.Loans.Add(newLoan);
                    }
                    else
                    {
                        profile.Loans = new List<Loan>();
                        profile.Loans.Add(newLoan);
                    }
                }

                data.SelectedLoan = newLoan;
                BindTreeView();
                BindSelectedLoan();
                Program.UpdateDatabase(data);
            }
        }

        private void CopyLoan(Loan sourceLoan)
        {
            List<string> targetLoanProfiles = data.LoanProfiles.Where(x => x.Name != sourceLoan.LoanProfileName).Select(x => x.Name).ToList();

            if (targetLoanProfiles.Count > 0)
            {

                CopyLoanForm copyLoanForm = new CopyLoanForm(targetLoanProfiles);
                copyLoanForm.ShowDialog();

                if (copyLoanForm.DialogResult == DialogResult.OK)
                {
                    LoanProfile targetLoanProfile = data.LoanProfiles.FirstOrDefault(x => x.Name == copyLoanForm.selectedProfile);

                    if (targetLoanProfile != null)
                    {
                        Loan loan = targetLoanProfile.Loans.FirstOrDefault(x => x.Name == sourceLoan.Name);

                        if (loan != null)
                        {
                            loan = (Loan)targetLoanProfile.Loans.First(x => x.Name == sourceLoan.Name).Clone();
                            loan.Name += " copy";

                            while (targetLoanProfile.Loans.Any(x => x.Name == loan.Name))
                            {
                                loan.Name += " copy";
                            }
                        }
                        else
                        {
                            loan = (Loan)sourceLoan.Clone();
                        }

                        loan.LoanProfileName = copyLoanForm.selectedProfile;
                        targetLoanProfile.Loans.Add(loan);
                        BindSelectedLoan();
                        BindTreeView();
                        Program.UpdateDatabase(data);

                        MessageBox.Show("Loan has been copied!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("No other loan profiles available! Please add one or more profiles first before trying to copy the loan.", "No other target", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteLoan(Loan sourceLoan)
        {
            var result = MessageBox.Show("Are you sure you want to delete this loan?", "Delete loan?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                LoanProfile profile = data.LoanProfiles.SingleOrDefault(x => x.Name == sourceLoan.LoanProfileName);

                if (profile != null)
                {
                    profile.Loans.Remove(sourceLoan);

                    data.SelectedLoan = new Loan();
                    BindTreeView();
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);

                    MessageBox.Show("The loan has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #region Events:General
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clickedNode = e.Node.Name;
                clickedTreeNode = e.Node;

                if (clickedTreeNode.Level == 0)
                {
                    contextMenuStripProfile.Show(treeView1, e.Location);
                }
                else
                {
                    contextMenuStripLoan.Show(treeView1, e.Location);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                clickedNode = e.Node.Name;
                clickedTreeNode = e.Node;

                if (clickedTreeNode.Level == 0)
                {

                }
                else
                {
                    data.SelectedLoan = (Loan)e.Node.Tag;
                    data.SelectedLoan.LoanDetails = ((Loan)e.Node.Tag).LoanDetails;
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Events:Profile
        private void newLoanProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewProfile();
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            CreateNewProfile();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (clickedTreeNode.Tag is LoanProfile)
            {
                LoanProfile profile = clickedTreeNode.Tag as LoanProfile;

                ProfileForm profileForm = new ProfileForm(profile.Name);
                profileForm.ShowDialog();

                if (profileForm.DialogResult == DialogResult.OK)
                {
                    string loanProfileName = "";
                    loanProfileName = profileForm.Text;

                    LoanProfile source = data.LoanProfiles.SingleOrDefault(x => x.Name == profile.Name);

                    if (source != null)
                    {
                        while (data.LoanProfiles.Any(x => x.Name == loanProfileName))
                        {
                            loanProfileName += "_duplicate";
                        }
                        source.Name = loanProfileName;
                        foreach (var loan in source.Loans)
                        {
                            loan.LoanProfileName = loanProfileName;
                        }
                    }

                    BindTreeView();
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (clickedTreeNode.Tag is LoanProfile)
            {
                var result = MessageBox.Show("Are you sure you want to delete this loan?", "Delete loan?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    LoanProfile profile = (LoanProfile)clickedTreeNode.Tag;
                    data.LoanProfiles.Remove(profile);

                    data.SelectedLoan = new Loan();

                    BindTreeView();
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);

                    MessageBox.Show("The profile has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a loan profile", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProfile((LoanProfile)clickedTreeNode.Tag);
        }

        private void duplicateProfileStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedTreeNode.Tag is LoanProfile)
            {

                var result = MessageBox.Show("Do you want to duplicate this loan?", "Duplicate loan?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {
                    LoanProfile profile = (LoanProfile)clickedTreeNode.Tag;

                    string newName = profile.Name + "_duplicate";

                    while (data.LoanProfiles.Any(x => x.Name == newName))
                    {
                        newName += "_duplicate";
                    }

                    LoanProfile newProfile = profile.Clone() as LoanProfile;
                    newProfile.Name = newName;
                    data.LoanProfiles.Add(newProfile);

                    BindTreeView();
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);

                    MessageBox.Show("The profile has been duplicated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a loan profile", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clickedTreeNode.Tag is LoanProfile)
            {

                var result = MessageBox.Show("Are you sure you want to delete this loan?", "Delete loan?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (result == DialogResult.OK)
                {


                    LoanProfile profile = (LoanProfile)clickedTreeNode.Tag;
                    data.LoanProfiles.Remove(profile);

                    if (data.LoanProfiles.Count > 0)
                    {
                        data.SelectedLoan = data.LoanProfiles[0].Loans[0];
                    }
                    else
                    {
                        data.SelectedLoan = new Loan();
                    }
                    BindTreeView();
                    BindSelectedLoan();
                    Program.UpdateDatabase(data);

                    MessageBox.Show("The profile has been deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a loan profile", "Success", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pokokBulananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = GenerateReport((LoanProfile)clickedTreeNode.Tag, ReportType.POKOKBULANAN);

            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void bungaBulananToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = GenerateReport((LoanProfile)clickedTreeNode.Tag, ReportType.BUNGABULANAN);

            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void bungaTahunanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = GenerateReport((LoanProfile)clickedTreeNode.Tag, ReportType.BUNGATAHUNAN);

            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }

        private void outstandingLoanTahunanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Report report = GenerateReport((LoanProfile)clickedTreeNode.Tag, ReportType.OUTSTANDINGTAHUNAN);

            ReportForm reportForm = new ReportForm(report);
            reportForm.Show();
        }
        #endregion

        #region Events:Loan
        private void buttonEditLoan_Click(object sender, EventArgs e)
        {
            EditLoan(data.SelectedLoan);
        }

        private void newLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewLoan();
        }

        private void buttonCopyLoan_Click(object sender, EventArgs e)
        {
            CopyLoan(data.SelectedLoan);
        }

        private void copyLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyLoan((Loan)clickedTreeNode.Tag);
        }

        private void buttonDeleteLoan_Click(object sender, EventArgs e)
        {
            DeleteLoan(data.SelectedLoan);
        }

        private void editLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditLoan((Loan)clickedTreeNode.Tag);
        }

        private void deleteLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLoan((Loan)clickedTreeNode.Tag);
        }
        #endregion
    }
}