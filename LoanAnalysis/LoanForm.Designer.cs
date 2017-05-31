namespace LoanAnalysis
{
    partial class LoanForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridViewPembayaran = new System.Windows.Forms.DataGridView();
            this.dataGridViewPenarikan = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.numericMargin = new System.Windows.Forms.NumericUpDown();
            this.numericInterestRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericRepayment = new System.Windows.Forms.NumericUpDown();
            this.numericGracePeriod = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericInterest = new System.Windows.Forms.NumericUpDown();
            this.numericTenor = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numericLimit = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.textBoxBankName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPembayaran)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPenarikan)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMargin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterestRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGracePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTenor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLimit)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 571);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 211);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 315);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Properties";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label11, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewPembayaran, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.dataGridViewPenarikan, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(686, 296);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(463, 6);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Pelunasan Percepat";
            // 
            // dataGridViewPembayaran
            // 
            this.dataGridViewPembayaran.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPembayaran.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPembayaran.Location = new System.Drawing.Point(346, 28);
            this.dataGridViewPembayaran.Name = "dataGridViewPembayaran";
            this.tableLayoutPanel3.SetRowSpan(this.dataGridViewPembayaran, 2);
            this.dataGridViewPembayaran.Size = new System.Drawing.Size(337, 265);
            this.dataGridViewPembayaran.TabIndex = 1;
            // 
            // dataGridViewPenarikan
            // 
            this.dataGridViewPenarikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPenarikan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPenarikan.Location = new System.Drawing.Point(3, 28);
            this.dataGridViewPenarikan.Name = "dataGridViewPenarikan";
            this.tableLayoutPanel3.SetRowSpan(this.dataGridViewPenarikan, 2);
            this.dataGridViewPenarikan.Size = new System.Drawing.Size(337, 265);
            this.dataGridViewPenarikan.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Jadwal Penarikan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(692, 202);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loan Details";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.numericMargin, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.numericInterestRate, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 6);
            this.tableLayoutPanel2.Controls.Add(this.numericRepayment, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.numericGracePeriod, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.numericInterest, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.numericTenor, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.numericLimit, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePickerStartDate, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxProfileName, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBoxBankName, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(686, 183);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // numericMargin
            // 
            this.numericMargin.DecimalPlaces = 4;
            this.numericMargin.Location = new System.Drawing.Point(343, 159);
            this.numericMargin.Name = "numericMargin";
            this.numericMargin.Size = new System.Drawing.Size(120, 20);
            this.numericMargin.TabIndex = 35;
            // 
            // numericInterestRate
            // 
            this.numericInterestRate.DecimalPlaces = 4;
            this.numericInterestRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericInterestRate.Location = new System.Drawing.Point(113, 159);
            this.numericInterestRate.Name = "numericInterestRate";
            this.numericInterestRate.Size = new System.Drawing.Size(114, 20);
            this.numericInterestRate.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(233, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Margin (%)";
            // 
            // numericRepayment
            // 
            this.numericRepayment.Location = new System.Drawing.Point(343, 133);
            this.numericRepayment.Name = "numericRepayment";
            this.numericRepayment.Size = new System.Drawing.Size(120, 20);
            this.numericRepayment.TabIndex = 33;
            // 
            // numericGracePeriod
            // 
            this.numericGracePeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericGracePeriod.Location = new System.Drawing.Point(113, 133);
            this.numericGracePeriod.Name = "numericGracePeriod";
            this.numericGracePeriod.Size = new System.Drawing.Size(114, 20);
            this.numericGracePeriod.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Interest Rate (%)";
            // 
            // numericInterest
            // 
            this.numericInterest.Location = new System.Drawing.Point(343, 107);
            this.numericInterest.Name = "numericInterest";
            this.numericInterest.Size = new System.Drawing.Size(120, 20);
            this.numericInterest.TabIndex = 31;
            // 
            // numericTenor
            // 
            this.numericTenor.Location = new System.Drawing.Point(113, 107);
            this.numericTenor.Name = "numericTenor";
            this.numericTenor.Size = new System.Drawing.Size(114, 20);
            this.numericTenor.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Grace Period (bulan)";
            // 
            // numericLimit
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.numericLimit, 2);
            this.numericLimit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericLimit.Location = new System.Drawing.Point(113, 81);
            this.numericLimit.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this.numericLimit.Name = "numericLimit";
            this.numericLimit.Size = new System.Drawing.Size(224, 20);
            this.numericLimit.TabIndex = 29;
            this.numericLimit.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(233, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Pokok (bulan)";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Tenor (tahun)";
            // 
            // dateTimePickerStartDate
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.dateTimePickerStartDate, 2);
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(113, 55);
            this.dateTimePickerStartDate.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(224, 20);
            this.dateTimePickerStartDate.TabIndex = 28;
            this.dateTimePickerStartDate.Value = new System.DateTime(2017, 3, 1, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Limit (Rupiah)";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Name";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "Date";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Interest (bulan)";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Loan Name";
            // 
            // textBoxProfileName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxProfileName, 3);
            this.textBoxProfileName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProfileName.Location = new System.Drawing.Point(113, 3);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(570, 20);
            this.textBoxProfileName.TabIndex = 37;
            // 
            // textBoxBankName
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.textBoxBankName, 3);
            this.textBoxBankName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxBankName.Location = new System.Drawing.Point(113, 29);
            this.textBoxBankName.Name = "textBoxBankName";
            this.textBoxBankName.Size = new System.Drawing.Size(570, 20);
            this.textBoxBankName.TabIndex = 38;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
            this.flowLayoutPanel1.Controls.Add(this.buttonSave);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 532);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(692, 36);
            this.flowLayoutPanel1.TabIndex = 30;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(614, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(533, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Jumlah";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tanggal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // LoanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 571);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(714, 610);
            this.Name = "LoanForm";
            this.Text = "New Loan Profile";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPembayaran)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPenarikan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMargin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterestRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericRepayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGracePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericTenor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLimit)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridView dataGridViewPembayaran;
        private System.Windows.Forms.DataGridView dataGridViewPenarikan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.NumericUpDown numericMargin;
        private System.Windows.Forms.NumericUpDown numericInterestRate;
        private System.Windows.Forms.NumericUpDown numericRepayment;
        private System.Windows.Forms.NumericUpDown numericGracePeriod;
        private System.Windows.Forms.NumericUpDown numericInterest;
        private System.Windows.Forms.NumericUpDown numericTenor;
        private System.Windows.Forms.NumericUpDown numericLimit;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.TextBox textBoxBankName;
    }
}