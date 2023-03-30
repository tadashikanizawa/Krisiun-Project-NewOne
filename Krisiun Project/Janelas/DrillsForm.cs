using Krisiun_Project.Dados_Aleatorios1;
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
        private Drills drills;
        public DrillsForm(Form1 form1, Ferramentas ferramentas, Pitch_principal.Peca peca, Drills drills)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ferramentas = ferramentas;
            this.peca = peca;
            this.drills = drills;

            mentori_Frente1.Visible = false;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;
            lado_UserControl1.OnAlterarPropriedades1 += mentori_Tras1.alterar;

        }

        public bool mentorifrentevisible;
        private void lado_UserControl1_Load(object sender, EventArgs e)
        {
                drill_UserControl1.peca = this.peca;
            
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            xy_panel.BringToFront();
        }

        private void drill_UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pcd_panel.BringToFront();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drills.CriarDrills(ferramentas,drill_UserControl1,lado_UserControl1,mentori_Frente1,mentori_Tras1,colors_UserControl1, dataGridView1,dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);   
            form1.panel_update();
            this.Close();

        }

 
    }
}
