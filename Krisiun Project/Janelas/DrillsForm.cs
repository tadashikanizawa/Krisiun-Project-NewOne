﻿using Krisiun_Project.Dados_Aleatorios1;
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
        public DrillsForm(Form1 form1, Ferramentas ferramentas, Ferramentas ferramenta, Pitch_principal.Peca peca, Drills drills)
        {
            InitializeComponent();
            this.form1 = form1;
            this.ferramentas = ferramentas;
            this.peca = peca;
            this.drills = drills;
            this.ferramenta = ferramenta;
            if(ferramenta != null )
            {
                if(ferramenta is Drills drill)
                {
                    drill_UserControl1.LoadData(drill);
                    drill_UserControl1.Atsumi = peca.z;
                    }
                colors_UserControl1.LoadColor(ferramenta);
                lado_UserControl1.LoadLado(ferramenta);
            }

            mentori_Frente1.Visible = false;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;
            lado_UserControl1.OnAlterarPropriedades1 += mentori_Tras1.alterar;

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
            drills.CriarDrills(ferramentas,drill_UserControl1,lado_UserControl1,mentori_Frente1,mentori_Tras1,colors_UserControl1, dataGridView1,dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);   
            form1.panel_update();
            this.Close();

        }

        private void DrillsForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
