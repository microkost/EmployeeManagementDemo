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
        private int SelectedEmpIndex;
        private EmployerRepository employerRepository;
        private DepartmentRepository dpmRepo;        
        

        public FormEmployeesEdit() //adding
        {
            InitializeComponent();
            employerRepository = new EmployerRepository();
            se = new SoloEmployer();

            comboBoxDep.DataSource = dpmRepo.getComboBoxSource();
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "IDdpm";
        }

        public FormEmployeesEdit(EmployerRepository employerRepository, int index) //editing
        {
            InitializeComponent();            
            this.SelectedEmpIndex = index;
            employerRepository = new EmployerRepository();
            se = new SoloEmployer();            

            se = employerRepository.SelectById(SelectedEmpIndex);            
            labelID.Text = String.Format("ID of emloyer: {0}", SelectedEmpIndex);
            textBoxName1.Text = se.Name1;
            textBoxName2.Text = se.Name2;
            textBoxName3.Text = se.Name3;
            textBoxEmail.Text = se.Email;
            comboBoxDep.DataSource = dpmRepo.getComboBoxSource();
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


    }
}
