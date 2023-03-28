using Krisiun_Project.G_Code;
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
        private Pitch_principal.Peca peca;
        private Form1 form1;
        private Ferramentas ferramentas;
        public DrillsForm(Form1 form1, Ferramentas ferramentas)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ferramentas = ferramentas;
            mentori_Frente1.Visible = false;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;

        }

        public bool mentorifrentevisible;
        private void lado_UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Drills drills = new Drills(peca);
            drills.Mentori_F_Bool = lado_UserControl1.Mentori_F_Bool;
            ferramentas.ListTotal.Add(drills);
            
        }
    }
}
