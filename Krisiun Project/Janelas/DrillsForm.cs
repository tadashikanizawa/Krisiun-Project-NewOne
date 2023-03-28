using Krisiun_Project.UserControils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace Krisiun_Project.Janelas
{
    public partial class DrillsForm : Form
    {
        public Lado_UserControl lado;
        public Mentori_Frente mentorifrente;
        public DrillsForm()
        {
            InitializeComponent();

            Mentori_Frente.OnChangeVisibility += UserControl1_OnChangeVisibility;
        }

        private void UserControl1_OnChangeVisibility(bool visible)
        {
            Mentori_Frente visible;
        }
        private void lado_UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
