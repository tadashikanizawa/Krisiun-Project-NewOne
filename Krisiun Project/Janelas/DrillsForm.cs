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
            drills.Frente = lado_UserControl1.Bool_Frente;
            drills.Tras = lado_UserControl1.Bool_Tras;
            ferramentas.ListTotal.Add(drills);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                float x, y;
                if (row.Cells[0].Value != null && row.Cells[1].Value != null && float.TryParse(row.Cells[0].Value.ToString(), out x) && float.TryParse(row.Cells[1].Value.ToString(), out y))
                {
                    PointF coordenadas = new PointF(x, y);
                    drills.CoordenadasList.Add(coordenadas);
                }
            }


        }
    }
}
