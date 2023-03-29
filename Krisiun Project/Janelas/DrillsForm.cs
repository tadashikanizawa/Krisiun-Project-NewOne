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
        public DrillsForm(Form1 form1, Ferramentas ferramentas, Pitch_principal.Peca peca)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ferramentas = ferramentas;
            this.peca = peca;

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
            Drills drills = new Drills(peca);
            drills.Frente = lado_UserControl1.Bool_Frente;
            drills.Tras = lado_UserControl1.Bool_Tras;
            ferramentas.ListTotal.Add(drills);

            if(radioButton1.Checked == true)
            { 
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
            if(radioButton2.Checked == true)
            {
                float raio;
                PointF pontoCentral;
                float pontoCentralX;
                float pontoCentralY;

                if (float.TryParse(textBox1.Text, out raio) && float.TryParse(textBox2.Text, out pontoCentralX) && float.TryParse(textBox3.Text, out pontoCentralY))

                {
                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        float angulo;
                        if (row.Cells[0].Value != null && float.TryParse(row.Cells[0].Value.ToString(), out angulo))
                        {
                            float radianos = (float)(Math.PI / 180.0) * angulo;
                            float x = pontoCentralX + raio * (float)Math.Cos(radianos);
                            float y = pontoCentralY + raio * (float)Math.Sin(radianos);
                            x = (float)Math.Round(x, 3);
                            y = (float)Math.Round(y, 3);
                            PointF coordenadas = new PointF(x, y);
                            drills.CoordenadasList.Add(coordenadas);
                        }
                    }
                }
            }
            form1.panel_update();
            this.Close();

        }

 
    }
}
