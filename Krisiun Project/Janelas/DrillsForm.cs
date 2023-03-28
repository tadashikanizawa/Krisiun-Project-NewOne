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
        Lado_UserControl lado;
        Mentori_Frente mentorifrente;
        //public bool MentoriFrenteVisible
        //{
        //    get { return mentorifrente.Visible; }
        //    set { mentorifrente.Visible = value; }
        //}
        
        public DrillsForm()
        {
            InitializeComponent();
     
            mentori_Frente1.Visible = false;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;

        }

        public bool mentorifrentevisible;
        private void lado_UserControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
