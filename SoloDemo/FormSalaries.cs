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
    public partial class FormSalaries : Form
    {
        private SalaryRepository salRepo;
        private EmployerRepository empRepo;
        private const string dateTimeFormat = "d.MM.yyyy";   // Use this format.

        public FormSalaries()
        {
            InitializeComponent();

            salRepo = new SalaryRepository(); //contains data          
            empRepo = new EmployerRepository(); //contains data FK

            RefreshGui();
        }

        public void RefreshGui()
        {
            salRepo = new SalaryRepository(); //contains data            
            salRepo.GetAll();

            
            if (empRepo != null && salRepo != null)
            {
                List<SoloSalary> salaries = salRepo.GetAll().ToList();
                var employees = empRepo.GetAll();

                int selectedRowComfortGui; //for user comfort                
                try
                {
                    selectedRowComfortGui = salDataGridView.CurrentCell.RowIndex;
                }
                catch
                {
                    selectedRowComfortGui = 0;
                }

                salDataGridView.ClearSelection(); //cleaning previos search
                salDataGridView.Columns.Clear(); //cleaning previous content
                salDataGridView.Rows.Clear();  //cleaning previous content

                //columns headers
                DataGridViewColumn d1 = new DataGridViewTextBoxColumn();
                d1.HeaderText = "ID";
                d1.Visible = false;
                d1.SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewColumn d2 = new DataGridViewTextBoxColumn();
                d2.HeaderText = "Employee";
                d2.SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewColumn d3 = new DataGridViewTextBoxColumn();
                d3.HeaderText = "Amount €";
                d3.SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewColumn d4 = new DataGridViewTextBoxColumn();
                d4.HeaderText = "Earn from";
                d4.SortMode = DataGridViewColumnSortMode.Automatic;
                DataGridViewColumn d5 = new DataGridViewTextBoxColumn();
                d5.HeaderText = "Earn to";
                d5.SortMode = DataGridViewColumnSortMode.Automatic;                
                salDataGridView.Columns.AddRange(d1, d2, d3, d4, d5);

                foreach (SoloSalary sal in salaries)
                {
                    var row = new DataGridViewRow();
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = sal.IDsal });
                    SoloEmployer se = empRepo.GetByID(sal.IDemp);
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = se.Name1 + " " + se.Name2 + " " + se.Name3 });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = sal.Amount });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = sal.validFrom.ToString(dateTimeFormat) });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = sal.validUntil.ToString(dateTimeFormat) });                    
                    salDataGridView.Rows.Add(row); //finalize row
                }

                salDataGridView.Rows[selectedRowComfortGui].Selected = true;                
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshGui();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            salRepo.Save();
            RefreshGui();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form FormSalariesEdit = new FormSalariesEdit(empRepo);
            FormSalariesEdit.ShowDialog();
            salRepo.Save();
            RefreshGui();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (salDataGridView.SelectedRows.Count == 0)
            {
                return;
            }

            salRepo.Delete(selectedRowDBindex());
            salRepo.Save();
            RefreshGui();
        }

        private int selectedRowDBindex() //multiselection not implemented
        {
            try
            {
                return Int32.Parse(salDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch
            {
                return Int32.MaxValue; //TODO: WRONG!
            }

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Form FormSalariesEdit = new FormSalariesEdit(salRepo, empRepo, selectedRowDBindex());
            FormSalariesEdit.ShowDialog();
            salRepo.Save();
            RefreshGui();

        }

        private void FormDepartment_OnClose(object sender, EventArgs e)
        {
            salRepo.Save();
            salRepo.Dispose();
        }


        private void button1_Click(object sender, EventArgs e) //SEARCH IN DATAGRIDVIEW IN C#
        {
            /* if refactor, then this should be in some library, already code duplication...*/

            int selectedItems = 0;
            salDataGridView.ClearSelection(); //cleaning previos search            
            salDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            salDataGridView.MultiSelect = true;            

            foreach (DataGridViewRow row in salDataGridView.Rows) //algorithm is checking cells in column order in every row in table
            {                
                for (int columnIndex = 0; columnIndex < salDataGridView.Columns.Count; columnIndex++) //columns listing
                {
                    if (row.Cells[columnIndex] is DataGridViewTextBoxCell) //cant look for Combobox and others, only textboxes
                    {
                        if (row.Cells[columnIndex].Value.ToString().ToLower().Contains(textBoxSearch.Text.ToLower())) //removes case sensibility
                        {
                            columnIndex = row.Index;
                            salDataGridView.Rows[columnIndex].Selected = true;
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

