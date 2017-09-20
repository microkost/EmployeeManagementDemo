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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            Form employees = new FormEmployees();
            employees.ShowDialog();
        }

        private void buttonDepartements_Click(object sender, EventArgs e)
        {
            Form departement = new FormDepartment();
            departement.ShowDialog();
        }
    }
}
