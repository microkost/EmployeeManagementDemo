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
    public partial class FormDepartment : Form
    {

        private DepartmentRepository dpmRepo;        

        public FormDepartment()
        {
            InitializeComponent();
            dpmRepo = new DepartmentRepository(); //contains data
            RefreshGui();
        }

        public void RefreshGui()
        {
            if (dpmRepo != null)
            {
                var departments = dpmRepo.GetAll();                
                dpmDataGridView.DataSource = departments; //adds data to DataGridView by columns, makes troubles later, but works...
                dpmDataGridView.Columns[0].DataPropertyName = "IDdpm";
                dpmDataGridView.Columns[1].DataPropertyName = "Name";
                dpmDataGridView.Columns[2].DataPropertyName = "Employees";
                dpmDataGridView.Columns[2].Visible = false; //foreign key is not showing to user                
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            //flush previous?
            RefreshGui();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            /*for(int i = 0; i< dpmDataGridView.ColumnCount; i++) //obviously not nessesarry
            {                               
                SoloDepartment sd = new SoloDepartment();
                sd.IDdpm = int.Parse(dpmDataGridView.Rows[i].Cells["IDdpm"].Value.ToString());
                sd.Name = dpmDataGridView.Rows[i].Cells["Name"].Value.ToString();
                dpmRepo.Update(sd);                            
            }*/
            dpmRepo.Save();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SoloDepartment sd = new SoloDepartment();
            sd.Name = textBoxAdd.Text.ToString();
            dpmRepo.Insert(sd);
            dpmRepo.Save();
            textBoxAdd.Text = "";
            RefreshGui();            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
           if (dpmDataGridView.SelectedRows.Count == 0)
            {
                return;
            } 

            dpmRepo.Delete(selectedRowDBindex()); 
            dpmRepo.Save();
            RefreshGui();
        }

        private int selectedRowDBindex() //multiselection not implemented
        {
            try
            { 
                return Int32.Parse(dpmDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {
                return Int32.MaxValue; //TODO: WRONG!
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {            
            Form FormDepartementEdit = new FormDepartmentEdit(dpmRepo, selectedRowDBindex());
            FormDepartementEdit.ShowDialog(); //dialog waits for respond!
            dpmRepo.Save();            
            RefreshGui();

        }

        private void FormDepartment_OnClose(object sender, EventArgs e)
        {
            dpmRepo.Save();
            dpmRepo.Dispose();
        }
    }
}
