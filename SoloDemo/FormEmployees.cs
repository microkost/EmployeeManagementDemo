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
            empRepo = new EmployerRepository(); //contains data            
            dpmRepo = new DepartmentRepository(); //contains data FK
            RefreshGui();
        }

        public void RefreshGui()
        {           
            if (empRepo != null)
            {
                List<SoloEmployer> employees = empRepo.GetAll().ToList();
                var departments = dpmRepo.GetAll();

                //empDataGridView.Columns NEEDS TO BE FLUSHED before adding new VALUES!

                DataGridViewColumn d1 = new DataGridViewTextBoxColumn();
                d1.HeaderText = "ID employee";
                DataGridViewColumn d2 = new DataGridViewTextBoxColumn();
                d2.HeaderText = "First name";
                DataGridViewColumn d3 = new DataGridViewTextBoxColumn();
                d3.HeaderText = "Middle name";
                DataGridViewColumn d4 = new DataGridViewTextBoxColumn();
                d3.HeaderText = "Last name";
                DataGridViewColumn d5 = new DataGridViewTextBoxColumn();
                d3.HeaderText = "Email contact";
                DataGridViewColumn d6 = new DataGridViewComboBoxColumn();
                d3.HeaderText = "Department";                
                empDataGridView.Columns.AddRange(d1, d2, d3, d4, d5, d6);
            
                foreach (SoloEmployer emp in employees)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.ID});
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name1 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name2 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Name3 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = emp.Email });

                    string nameOfDepartmentForCB = "mock dep"; //TODO
                    //dpmRepo.getComboBoxSource().DataMember
                    row.Cells.Add(new DataGridViewComboBoxCell { DisplayMember = nameOfDepartmentForCB, ValueMember = emp.Department.ToString() });
                    empDataGridView.Rows.Add(row);
                }

                /*
                empDataGridView.Columns[0].DataPropertyName = "ID";
                empDataGridView.Columns[0].HeaderText = "ID employee";
                empDataGridView.Columns[1].DataPropertyName = "Name1";
                empDataGridView.Columns[2].DataPropertyName = "Name2";
                empDataGridView.Columns[3].DataPropertyName = "Name3";
                empDataGridView.Columns[4].DataPropertyName = "IDdmp";
                empDataGridView.Columns[5].DataPropertyName = "Email";
                empDataGridView.Columns[6].DataPropertyName = "Department";                
                empDataGridView.Columns[6].Visible = false;                
                */
            }
        }

        

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //flush previous?
            RefreshGui();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            empRepo.Save();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form FormEmployeesEdit = new FormEmployeesEdit();
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
            Form FormEmployeesEdit = new FormEmployeesEdit(empRepo, selectedRowDBindex());
            FormEmployeesEdit.ShowDialog();
            empRepo.Save();            
            RefreshGui();

        }

        private void FormDepartment_OnClose(object sender, EventArgs e)
        {
            empRepo.Save();
            empRepo.Dispose();
        }
    }
}
