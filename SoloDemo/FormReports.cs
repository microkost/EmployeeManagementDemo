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
        private const string dateTimeFormat = "d.MM.yyyy";   // Use this format

        public FormReports()
        {
            InitializeComponent();
            dpmRepo = new DepartmentRepository();
            empRepo = new EmployerRepository();
            salRepo = new SalaryRepository();
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
                foreach(SoloSalary ssa in salaries) //woraround, SELECT WHERE IDemp is not implicitely working
                {
                    if(ssa.IDemp == emp.ID)
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

        /*
        private int selectedRowDBindex() //multiselection not implemented
        {
            try
            {
                return Int32.Parse(repDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {
                return Int32.MaxValue; //TODO: WRONG!
            }

        }
        */


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

