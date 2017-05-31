using LoanAnalysis.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanAnalysis
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoanProfileListForm());
        }

        public static void UpdateDatabase(AppData data)
        {
            string json = JsonConvert.SerializeObject(data);

            File.WriteAllText(@"Data\db.json", json);
        }
        public static AppData InitializeDatabase()
        {
            AppData dbData = new AppData();
            Directory.CreateDirectory("Data");
            if (!File.Exists(@"Data\db.json"))
            {
                var myFile = File.CreateText(@"Data\db.json");
                myFile.Close();
                //dbData.Loans = new BindingList<Loan>();
                dbData.LoanProfiles = new BindingList<LoanProfile>();
                //dbData.SelectedLoan = new Loan();
                string json = JsonConvert.SerializeObject(dbData);
                File.WriteAllText(@"Data\db.json", json);
            }
            else
            {
                try
                {
                    string json = File.ReadAllText(@"Data\db.json");
                    dbData = JsonConvert.DeserializeObject<AppData>(json);
                }
                catch (Exception)
                {
                    string newFileName = "corrupt-" + String.Format("{0:u}", DateTime.Now) + "-db.json";
                    newFileName = newFileName.Replace(':', '-');
                    File.Copy(@"Data\db.json", @"Data\" + newFileName);
                    File.Delete(@"Data\db.json");

                    var myFile = File.CreateText(@"Data\db.json");
                    myFile.Close();
                    //dbData.Loans = new BindingList<Loan>();
                    dbData.LoanProfiles = new BindingList<LoanProfile>();
                    dbData.SelectedLoan = new Loan();
                    string json = JsonConvert.SerializeObject(dbData);
                    File.WriteAllText(@"Data\db.json", json);

                    MessageBox.Show("Current database has been corrupted. Corrupted file has now been renamed as \"" + newFileName + "\". Please send the file to developer for further investigation.", "Database corrupted!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("New database initialized!");
                }
            }
            return dbData;
        }
    }
}
