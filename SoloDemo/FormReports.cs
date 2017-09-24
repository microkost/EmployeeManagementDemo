using SoloDemoData;
using SoloDemoDomain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoloDemo
{
    public partial class FormReports : Form
    {
        private DepartmentRepository dpmRepo;
        private EmployerRepository empRepo;
        private SalaryRepository salRepo;
        private List<HumanItem> people;
        private const string dateTimeFormat = "d.MM.yyyy";   // Use this format

        public FormReports()
        {
            InitializeComponent();
            dpmRepo = new DepartmentRepository();
            empRepo = new EmployerRepository();
            salRepo = new SalaryRepository();
            people = new List<HumanItem>();
            RefreshGui();
        }

        public void RefreshGui()
        {
            dpmRepo.GetAll();
            List<SoloDepartment> departments = dpmRepo.GetAll().ToList();

            empRepo.GetAll();
            List<SoloEmployer> employees = empRepo.GetAll().ToList();

            salRepo.GetAll();
            List<SoloSalary> salaries = salRepo.GetAll().ToList();

            if (empRepo == null && dpmRepo == null && salRepo == null)
            {
                return; //negated protection as in other forms
            }

            int selectedRowComfortGui; //for user comfort                
            try
            {
                //multiselect should be take in account
                selectedRowComfortGui = repDataGridView.CurrentCell.RowIndex;
            }
            catch
            {
                selectedRowComfortGui = 0;
            }

            repDataGridView.ClearSelection(); //cleaning previos search
            repDataGridView.Columns.Clear(); //cleaning previous content
            repDataGridView.Rows.Clear();  //cleaning previous content

            /*
             * I dont want to refactor this code, but better way how to use object model is shown in part Refresh stats
             */

            //columns headers
            DataGridViewColumn d1 = new DataGridViewTextBoxColumn();
            d1.HeaderText = "ID employee";
            d1.ReadOnly = true;
            d1.Visible = false;
            d1.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewColumn d2 = new DataGridViewTextBoxColumn();
            d2.HeaderText = "First name";
            d2.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewColumn d3 = new DataGridViewTextBoxColumn();
            d3.HeaderText = "Middle name";
            d3.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewColumn d4 = new DataGridViewTextBoxColumn();
            d4.HeaderText = "Last name";
            d4.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewColumn d5 = new DataGridViewTextBoxColumn();
            d5.HeaderText = "Email contact";
            d5.SortMode = DataGridViewColumnSortMode.Automatic;
            d5.Visible = false;
            DataGridViewColumn d6 = new DataGridViewComboBoxColumn();
            d6.HeaderText = "Department";
            d6.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn d7 = new DataGridViewTextBoxColumn();
            d7.HeaderText = "Salary value";
            d7.SortMode = DataGridViewColumnSortMode.Automatic;
            DataGridViewColumn d8 = new DataGridViewTextBoxColumn();
            d8.HeaderText = "Valid from";
            d8.SortMode = DataGridViewColumnSortMode.Automatic;

            DataGridViewColumn d9 = new DataGridViewTextBoxColumn();
            d9.HeaderText = "Valid to";
            d9.SortMode = DataGridViewColumnSortMode.Automatic;

            repDataGridView.Columns.AddRange(d1, d2, d3, d4, d5, d6, d7, d8, d9);

            foreach (SoloEmployer emp in employees)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.ID });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name1 });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name2 });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name3 });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Email });

                DataGridViewComboBoxCell dgvCB = new DataGridViewComboBoxCell();
                dgvCB.DataSource = dpmRepo.getComboBoxSource();
                dgvCB.Value = emp.IDdmp;
                dgvCB.ValueMember = "IDdpm";
                dgvCB.DisplayMember = "Name";
                row.Cells.Add(dgvCB); //comboBox to building row

                SoloSalary sa = new SoloSalary();
                foreach (SoloSalary ssa in salaries) //woraround, SELECT WHERE IDemp is not implicitely working
                {
                    if (ssa.IDemp == emp.ID)
                    {
                        sa = ssa;
                    }
                }
                row.Cells.Add(new DataGridViewTextBoxCell { Value = sa.Amount });

                DateTime validFrom = sa.validFrom, validTo = sa.validUntil; //parsing datetime to be showed
                string validFromUI, validToUI;
                if (validFrom == DateTime.MinValue || validTo == DateTime.MinValue)
                {
                    validFromUI = "";
                    validToUI = "";
                }
                else
                {
                    validFromUI = validFrom.ToString(dateTimeFormat);
                    validToUI = validTo.ToString(dateTimeFormat);
                }

                row.Cells.Add(new DataGridViewTextBoxCell { Value = validFromUI });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = validToUI });

                repDataGridView.Rows.Add(row); //finalize row
            }

            repDataGridView.Rows[selectedRowComfortGui].Selected = true;

            RefreshStats();
        }
        private void RefreshStats()
        {
            /* finally proper way how to use object approach */

            if (empRepo == null && dpmRepo == null && salRepo == null)
            {
                return; //protection //needed - initialized in ctor
            }

            people = HumanItem.MakeHumans(empRepo.GetAll().ToList(), dpmRepo.GetAll().ToList(), salRepo.GetAll().ToList());

            tbStats.Clear();
            tbStats.AppendText("Number of employees: " + people.Count() + "\r\n");
            tbStats.AppendText("Employees per departments: \r\n");

            /*var query = people.SelectMany(x => x.NameDpm).GroupBy(s => s).Select(g => new { Namedpm = g.Key, Count = g.Count() });            
            foreach (var result in query) //LAMBDA is not working, idea: return count of employees peer departements
            {
                tbStats.AppendText(String.Format("  Name: {0}, Count: {1}\r\n", result, result.Count));
            }*/

            Dictionary<string, int> emploPerDeparts = new Dictionary<string, int>();
            foreach (HumanItem hu in people)
            {
                try
                {
                    emploPerDeparts.Add(hu.NameDpm, 0);
                }
                catch
                { }
                finally
                {
                    emploPerDeparts[hu.NameDpm] += 1;
                }
            }
            foreach (KeyValuePair<string, int> kvp in emploPerDeparts)
            {
                tbStats.AppendText(String.Format("  > {0}, employees: {1}\r\n", kvp.Key, kvp.Value)); //should be sorted
            }

            //average salary per months
            DateTime oldest = DateTime.Now;
            DateTime newest = DateTime.MinValue; //.ToString(dateTimeFormats)

            foreach (HumanItem hi in people)
            {
                foreach (SoloSalary ss in hi.ListSalaries)
                {
                    if (ss.validFrom < oldest)
                    {
                        oldest = ss.validFrom;
                    }
                    if (ss.validUntil > newest)
                    {
                        newest = ss.validUntil;
                    }
                }
            }

            tbSalaStats.AppendText(String.Format("Salaries from {0} to {1}\r\n", oldest.ToString(dateTimeFormat), newest.ToString(dateTimeFormat))); //should be sorted

            //income per month
            Dictionary<DateTime, List<double>> salariesPerMonth = new Dictionary<DateTime, List<double>>();
            foreach (DateTime dt in monthsBetween(oldest, newest))
            {
                foreach (HumanItem hi in people)
                {
                    foreach (SoloSalary ss in hi.ListSalaries)
                    {
                        if ((dt > ss.validFrom) && (dt < ss.validUntil))
                        {
                            try
                            {
                                salariesPerMonth.Add(dt, new List<Double>());
                            }
                            catch
                            {
                                //if datetime already exist
                            }
                            finally
                            {
                                salariesPerMonth[dt].Add(ss.Amount);
                            }
                        }
                    }
                }
            }

            foreach (KeyValuePair<DateTime, List<double>> kvp in salariesPerMonth)
            {
                double average = 0;
                if(kvp.Value.Count > 0)
                {
                    average = kvp.Value.Average();
                }

                tbSalaStats.AppendText(String.Format("  > {0}, average €: {1}\r\n", kvp.Key.ToString("MM.yyyy"), Math.Round(average, 2)));
            }

        }

        static IEnumerable<DateTime> monthsBetween(DateTime d0, DateTime d1)
        {
            return Enumerable.Range(0, (d1.Year - d0.Year) * 12 + (d1.Month - d0.Month + 1))
                             .Select(m => new DateTime(d0.Year, d0.Month, 1).AddMonths(m));
        }
        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGui();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            empRepo.Save();
            RefreshGui();
        }

        private void FormDepartment_OnClose(object sender, EventArgs e)
        {
            empRepo.Save();
            empRepo.Dispose();
        }


        private void button1_Click(object sender, EventArgs e) //SEARCH IN DATAGRIDVIEW IN C#
        {
            /* if refactor, then this should be in some library, already code duplication...*/

            int selectedItems = 0;
            repDataGridView.ClearSelection(); //cleaning previos search            
            repDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            repDataGridView.MultiSelect = true;

            foreach (DataGridViewRow row in repDataGridView.Rows) //algorithm is checking cells in column order in every row in table
            {
                for (int columnIndex = 0; columnIndex < repDataGridView.Columns.Count; columnIndex++) //columns listing
                {
                    if (row.Cells[columnIndex] is DataGridViewTextBoxCell) //cant look for Combobox and others, only textboxes
                    {
                        if (row.Cells[columnIndex].Value.ToString().ToLower().Contains(textBoxSearch.Text.ToLower())) //removes case sensibility
                        {
                            columnIndex = row.Index;
                            repDataGridView.Rows[columnIndex].Selected = true;
                            selectedItems++;
                            columnIndex++;
                            break;
                        }
                    }
                }
            }

            if (selectedItems == 0)
            {
                MessageBox.Show("Sorry, query '" + textBoxSearch.Text + "' wasn't found", "Search results");
            }

        }
    }
}

