using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SoloDemoData;
using SoloDemoDomain;

namespace SoloDemo
{
    public partial class FormSalariesEdit : Form
    {
        private SoloSalary ss;
        private int SelectedSalIndex;
        private SalaryRepository salRepo;
        private EmployerRepository empRepo;

        public FormSalariesEdit(EmployerRepository repositoryOfEmployee)
        {
            InitializeComponent();

            salRepo = new SalaryRepository();
            ss = new SoloSalary();
            this.empRepo = repositoryOfEmployee;            
            monthCalendarUntil.SetDate(DateTime.Today.AddYears(1)); //add default end date
            comboBoxEmp.DataSource = empRepo.getComboBoxSource();            
            comboBoxEmp.DisplayMember = "Name3"; //changing by event
            comboBoxEmp.ValueMember = "ID";
            comboBoxEmp.SelectedIndex = -1; //not implicitely touch other users
        }

        private void ComboBoxFormat(object sender, ListControlConvertEventArgs e) //changing surname to full name in combobox 
        {            
            string first = ((SoloEmployer)e.ListItem).Name1;
            string middle = ((SoloEmployer)e.ListItem).Name2;
            string family = ((SoloEmployer)e.ListItem).Name3;
            e.Value = first + " " + middle + " " + family;
        }

        public FormSalariesEdit(SalaryRepository salariesRepo, EmployerRepository employeesRepo, int v)
        {
            InitializeComponent();
            this.salRepo = salariesRepo;
            this.empRepo = employeesRepo;
            this.SelectedSalIndex = v;
            ss = new SoloSalary();
            ss = salRepo.SelectById(SelectedSalIndex);
            
            labelID.Text = String.Format("ID of salary record: {0}", SelectedSalIndex);

            comboBoxEmp.DataSource = empRepo.getComboBoxSource();
            comboBoxEmp.DisplayMember = "Name3"; //changing to full name by event
            comboBoxEmp.ValueMember = "ID";
            comboBoxEmp.SelectedValue = empRepo.SelectById(ss.IDemp).ID; //select ID where sal.IDemp = emp.IDemp

            numericUpDownAm.Value = (decimal)ss.Amount;
            monthCalendarFrom.SetDate(ss.validFrom);
            monthCalendarUntil.SetDate(ss.validUntil);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            ss.Amount = (double)numericUpDownAm.Value;
            ss.validFrom = monthCalendarFrom.SelectionRange.Start;
            ss.validUntil = monthCalendarUntil.SelectionRange.Start;
            ss.IDemp = Int32.Parse(comboBoxEmp.SelectedValue.ToString());

            salRepo.Update(ss);
            salRepo.Save();
            Close();
        }
    }
}
