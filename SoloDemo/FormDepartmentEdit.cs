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
using SoloDemoData;

namespace SoloDemo
{
    public partial class FormDepartementEdit : Form
    {
        private SoloDepartment sd;
        private DepartmentRepository departmentRepository;
        private int SelectedIndex;

        public FormDepartementEdit(DepartmentRepository departmentRepository, int v)
        {
            InitializeComponent();
            this.departmentRepository = departmentRepository;
            this.SelectedIndex = v;

            sd = new SoloDepartment();
            labelID.Text = String.Format("ID of department: {0}", SelectedIndex);
            sd = departmentRepository.SelectById(SelectedIndex);
            textBoxOLD.Text = sd.Name.ToString();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (departmentRepository != null)
            {
                sd.Name = textBoxName.Text.ToString();
                departmentRepository.Update(sd);
                departmentRepository.Save();
                Close();
            }
        }
    }
}
