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
    public partial class FormEmployeesEdit : Form
    {
        private SoloEmployer se;        
        private EmployerRepository employerRepository;

        private DepartmentRepository dpmRepo;        

        private int SelectedIndex;

        public FormEmployeesEdit() //adding
        {
            InitializeComponent();
            employerRepository = new EmployerRepository();
            se = new SoloEmployer();
            dpmRepo = new DepartmentRepository(); //contains data

            comboBoxDep.DataSource = PrepareComboBox();
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "IDdpm";
        }

        public FormEmployeesEdit(EmployerRepository employerRepository, int index) //editing
        {
            InitializeComponent();            
            this.SelectedIndex = index;
            employerRepository = new EmployerRepository();
            se = new SoloEmployer();
            dpmRepo = new DepartmentRepository(); //contains data

            se = employerRepository.SelectById(SelectedIndex);            
            labelID.Text = String.Format("ID of emloyer: {0}", SelectedIndex);
            textBoxName1.Text = se.Name1;
            textBoxName2.Text = se.Name2;
            textBoxName3.Text = se.Name3;
            textBoxEmail.Text = se.Email;
            comboBoxDep.DataSource = PrepareComboBox();
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "IDdpm";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (employerRepository != null)
            {
                se.Name1 = textBoxName1.Text.ToString();
                se.Name2 = textBoxName2.Text.ToString();
                se.Name3 = textBoxName3.Text.ToString();
                se.Email = textBoxEmail.Text.ToString();
                se.IDdmp = Int32.Parse(comboBoxDep.SelectedValue.ToString());

                employerRepository.Update(se);
                employerRepository.Save();
                Close();
            }
        }

        private BindingSource PrepareComboBox()
        {            
            if (dpmRepo == null)
            {
                return null;
            }
                                                            
            BindingSource bindingSource1 = new BindingSource(); //saves space in code    
            bindingSource1.DataSource = dpmRepo.GetAll().ToList();
            return bindingSource1;                     
        }
    }
}
