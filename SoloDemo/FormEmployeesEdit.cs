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
        private EmployerRepository empRepo;
        private DepartmentRepository dpmRepo;

        public FormEmployeesEdit(DepartmentRepository repositoryOfDepartments) //adding
        {
            InitializeComponent();
            empRepo = new EmployerRepository();
            se = new SoloEmployer();
            this.dpmRepo = repositoryOfDepartments;

            comboBoxDep.DataSource = dpmRepo.getComboBoxSource();
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "IDdpm";
        }

        public FormEmployeesEdit(EmployerRepository employerRepository, DepartmentRepository repositoryOfDepartments, int index) //editing
        {
            se = new SoloEmployer();
            employerRepository = new EmployerRepository();

            InitializeComponent();
            this.SelectedEmpIndex = index;
            this.empRepo = employerRepository;
            this.dpmRepo = repositoryOfDepartments;

            se = employerRepository.SelectById(SelectedEmpIndex);
            labelID.Text = String.Format("ID of emloyer: {0}", SelectedEmpIndex);
            textBoxName1.Text = se.Name1;
            textBoxName2.Text = se.Name2;
            textBoxName3.Text = se.Name3;
            textBoxEmail.Text = se.Email;
            comboBoxDep.DataSource = dpmRepo.getComboBoxSource();
            comboBoxDep.DisplayMember = "Name";
            comboBoxDep.ValueMember = "IDdpm";
            //comboBoxDep.SelectedItem

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            se.Name1 = textBoxName1.Text.ToString();
            se.Name2 = textBoxName2.Text.ToString();
            se.Name3 = textBoxName3.Text.ToString();
            se.Email = textBoxEmail.Text.ToString();
            se.IDdmp = Int32.Parse(comboBoxDep.SelectedValue.ToString());

            empRepo.Update(se);
            empRepo.Save();
            Close();
        }


    }
}
