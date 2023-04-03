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
        private Ferramentas ferramenta;
        private Drills drills;
        private bool isEditMode;
        public DrillsForm(Form1 form1, Ferramentas ferramentas, Ferramentas ferramenta, Pitch_principal.Peca peca, Drills drills)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ferramentas = ferramentas;
            this.peca = peca;
            this.drills = drills;
            this.ferramenta = ferramenta;
            this.isEditMode = ferramenta != null;
            drill_UserControl1.Atsumi = peca.z;
            if (ferramenta != null )
            {
                if(ferramenta is Drills drill)
                {
                    drill_UserControl1.LoadData(drill);

                    }
                colors_UserControl1.LoadColor(ferramenta);
                lado_UserControl1.LoadLado(ferramenta);
                mentori_Frente1.LoadMentori(ferramenta, false);
                mentori_Frente2.LoadMentori(ferramenta, true);
                if (ferramenta.Mentori_F_Bool) { mentori_Frente1.Visible = true; }
                if (ferramenta.Mentori_B_Bool) { mentori_Frente2.Visible = true; }

                Coordenadas.LoadCoordinates(ferramenta, dataGridView1);
            }

            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;
            lado_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterar;
            drill_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterarkei;
            drill_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterarkei;

        }

        public bool mentorifrentevisible;
        private void lado_UserControl1_Load(object sender, EventArgs e)
        {
            
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
  
            if (radioButton1.Checked)
            { 
                if(dataGridView1.Rows.Count <= 1) { MessageBox.Show("Add coordenadas"); return; }
            }
            if(radioButton2.Checked)
            { 
            if (dataGridView2.Rows.Count <= 1) { MessageBox.Show("Add coordenadas"); return; }
            }
            if (!isEditMode)
            {
                drills.CriarDrills(ferramentas,drill_UserControl1,lado_UserControl1,mentori_Frente1,mentori_Frente2,colors_UserControl1, dataGridView1,dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);   
        
            }


            if(isEditMode)
            { 
                if(ferramenta is Drills drill)
                { 
                drills.EditarDrills(ferramentas, drill, drill_UserControl1, lado_UserControl1, mentori_Frente1, mentori_Frente2, colors_UserControl1, dataGridView1, dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);
                }
                Coordenadas.SaveChanges(ferramenta, dataGridView1);
            }
            form1.panel_update();
            this.Close();

        }

        private void DrillsForm_Load(object sender, EventArgs e)
        {

        }
        public void AtualizarDGV(Ferramentas tool)
        {
            Coordenadas.LoadCoordinates(tool, dataGridView1);
        }
        private void mentori_Frente1_Load(object sender, EventArgs e)
        {
            mentori_Frente1.men_frente_tam_tb.Text = "0.3";
            mentori_Frente1.men_frente_z_tb.Text = "-1.5";
            mentori_Frente1.men_frente_tipo_combo.SelectedIndex = 0;
        }

        private void mentori_Frente2_Load(object sender, EventArgs e)
        {

            mentori_Frente2.men_frente_tam_tb.Text = "0.3";
            mentori_Frente2.men_frente_z_tb.Text = "-1.5";
            mentori_Frente2.men_frente_tipo_combo.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.panel_update();
            form1.DGV_Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CoordenadaCopyForm coordenadaCopyForm = new CoordenadaCopyForm(ferramentas, this);
            coordenadaCopyForm.ShowDialog();
        }
    }
}
