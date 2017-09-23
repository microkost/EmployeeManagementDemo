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
    public partial class FormEmployees : Form
    {
        private EmployerRepository empRepo;
        private DepartmentRepository dpmRepo;

        public FormEmployees()
        {
            InitializeComponent();
            //empRepo = new EmployerRepository(); //contains data            
            dpmRepo = new DepartmentRepository(); //contains data FK            
            RefreshGui();
        }

        public void RefreshGui()
        {
            empRepo = new EmployerRepository(); //contains data            
            empRepo.GetAll();            

            if (empRepo != null && dpmRepo != null)
            {
                List<SoloEmployer> employees = empRepo.GetAll().ToList();
                var departments = dpmRepo.GetAll();

                int selectedRowComfortGui; //for user comfort                
                try
                {
                    selectedRowComfortGui = empDataGridView.CurrentCell.RowIndex;
                }
                catch
                {
                    selectedRowComfortGui = 0;
                }

                empDataGridView.ClearSelection(); //cleaning previos search
                empDataGridView.Columns.Clear(); //cleaning previous content
                empDataGridView.Rows.Clear();  //cleaning previous content

                //columns headers
                DataGridViewColumn d1 = new DataGridViewTextBoxColumn();
                d1.HeaderText = "ID employee";
                d1.ReadOnly = true;
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
                DataGridViewColumn d6 = new DataGridViewComboBoxColumn();
                d6.HeaderText = "Department";
                d6.SortMode = DataGridViewColumnSortMode.Automatic;
                empDataGridView.Columns.AddRange(d1, d2, d3, d4, d5, d6);

                foreach (SoloEmployer emp in employees)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.ID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name1 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name2 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name3 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Email });

                    /*
                    string nameOfDepartmentForEmp = "uknown name of departement";
                    foreach(SoloDepartment sd in departments)
                    {
                        if (sd.IDdpm == emp.IDdmp)
                        { 
                            nameOfDepartmentForEmp = sd.Name; 
                            break;
                        }
                    }
                    */

                    DataGridViewComboBoxCell dgvCB = new DataGridViewComboBoxCell();
                    dgvCB.DataSource = dpmRepo.getComboBoxSource();
                    dgvCB.Value = emp.IDdmp;
                    dgvCB.ValueMember = "IDdpm";
                    dgvCB.DisplayMember = "Name";

                    row.Cells.Add(dgvCB); //comboBox to building row
                    empDataGridView.Rows.Add(row); //finalize row
                }

                empDataGridView.Rows[selectedRowComfortGui].Selected = true;
            }
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form FormEmployeesEdit = new FormEmployeesEdit(dpmRepo);
            FormEmployeesEdit.ShowDialog();
            empRepo.Save();
            RefreshGui();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (empDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            empRepo.Delete(selectedRowDBindex());
            empRepo.Save();
            RefreshGui();
        }

        private int selectedRowDBindex() //multiselection not implemented
        {
            try
            {
                return Int32.Parse(empDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {
                return Int32.MaxValue; //TODO: WRONG!
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Form FormEmployeesEdit = new FormEmployeesEdit(empRepo, dpmRepo, selectedRowDBindex());
            FormEmployeesEdit.ShowDialog();
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
            empDataGridView.ClearSelection(); //cleaning previos search            
            empDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            empDataGridView.MultiSelect = true;            

            foreach (DataGridViewRow row in empDataGridView.Rows) //algorithm is checking cells in column order in every row in table
            {                
                for (int columnIndex = 0; columnIndex < empDataGridView.Columns.Count; columnIndex++) //columns listing
                {
                    if (row.Cells[columnIndex] is DataGridViewTextBoxCell) //cant look for Combobox and others, only textboxes
                    {
                        if (row.Cells[columnIndex].Value.ToString().ToLower().Equals(textBoxSearch.Text.ToLower())) //removes case sensibility
                        {
                            columnIndex = row.Index;
                            empDataGridView.Rows[columnIndex].Selected = true;
                            selectedItems++;
                            columnIndex++;
                            break;
                        }
                    }
                }
            }

            if(selectedItems == 0)
            {
                MessageBox.Show("Sorry, query '" + textBoxSearch.Text + "' wasn't found", "Search results");
            }
            
        }
    }
}

