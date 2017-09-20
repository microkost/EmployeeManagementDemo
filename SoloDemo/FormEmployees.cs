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

        public FormEmployees()
        {
            InitializeComponent();
            empRepo = new EmployerRepository(); //contains data            
            RefreshGui();
        }

        public void RefreshGui()
        {
            

            if (empRepo != null)
            {
                var departments = empRepo.GetAll();                
                empDataGridView.DataSource = departments; //adds data to DataGridView by columns, makes troubles later, but works...
                empDataGridView.Columns[0].DataPropertyName = "ID";
                empDataGridView.Columns[1].DataPropertyName = "Name1";
                empDataGridView.Columns[2].DataPropertyName = "Name2";
                empDataGridView.Columns[3].DataPropertyName = "Name3";
                empDataGridView.Columns[4].DataPropertyName = "IDdmp";
                empDataGridView.Columns[5].DataPropertyName = "Email";
                empDataGridView.Columns[6].DataPropertyName = "Department";
                empDataGridView.Columns[6].Visible = false;                
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
