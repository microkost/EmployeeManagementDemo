using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloDemo
{
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            Form employees = new FormEmployees();
            try
            {
                employees.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Connection failed, check connectivity to database or place of connection string", "Database connection message");
            }
        }

        private void buttonDepartements_Click(object sender, EventArgs e)
        {
            Form departement = new FormDepartments();
            try
            {
                departement.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Connection failed, check connectivity to database or place of connection string", "Database connection message");
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            string header = @"<connectionStrings><clear/><add name=""solodemo"" connectionString=""";
            string conns = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2}; Password={3};", textBoxDBDataSource.Text, textBoxDBcatalog.Text, textBoxDBuserID.Text, textBoxDBpass.Text);
            string footer = @""" providerName = ""System.Data.SqlClient"" /></ connectionStrings >";

            saveFileDialog1.FileName = "ConnectionString";
            saveFileDialog1.DefaultExt = "config";
            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            saveFileDialog1.Filter = "config files (*.config)|";
            saveFileDialog1.ShowDialog();
            string name = saveFileDialog1.FileName;
            File.WriteAllText(name, header + conns + footer);

            try
            {
                var conn = new SqlConnection(conns);
                conn.Open();
                MessageBox.Show("Connection is ready", "Database connection message");
                //not perfect, because there should be file location error! TODO later...
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed", "Database connection message");
            }

        }

        private void buttonSalary_Click(object sender, EventArgs e)
        {
            Form salaries = new FormSalaries();
            try
            {
                salaries.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Connection failed, check connectivity to database or place of connection string", "Database connection message");
            }
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            Form reporting = new FormReports();
            try
            {
                reporting.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Connection failed, check connectivity to database or place of connection string", "Database connection message");
            }
        }
    }
}
