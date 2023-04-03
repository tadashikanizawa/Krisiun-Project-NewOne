using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.G_Code;

namespace Krisiun_Project.Janelas
{
    public partial class TapForm : Form
    {
        public Ferramentas ferramentas;
        public Ferramentas ferramenta;
        public Pitch_principal.Peca peca;
        public TapForm(Form1 form, Ferramentas ferramentas, Ferramentas ferramenta, Pitch_principal.Peca peca )
        {
            InitializeComponent();
            this.ferramentas = ferramentas;
            this.ferramenta = ferramenta;
            this.peca = peca;
            tap_tool_combobox.DataSource = TiposdeTap.TapMM;
            tap_tool_combobox.DisplayMember = "Descricao";
            tap_tool_combobox.ValueMember = "Descricao";

            drill_UserControl1.Atsumi = peca.z;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;
            lado_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterar;
            drill_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterarkei;
            drill_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterarkei;
        }

        private void TapForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CoordenadaCopyForm coordenadaCopyForm = new CoordenadaCopyForm(ferramentas, this);
            coordenadaCopyForm.ShowDialog();
        }
        public void AtualizarDGV(Ferramentas tool)
        {
            Coordenadas.LoadCoordinates(tool, dataGridView1);
        }
        private void tap_mm_rb_CheckedChanged(object sender, EventArgs e)
        {
            if(tap_mm_rb.Checked)
            {
                tap_tool_combobox.DataSource = TiposdeTap.TapMM;
                tap_tool_combobox.DisplayMember= "Descricao";
                tap_tool_combobox.ValueMember = "Descricao";
            }
            if(tap_inch_rb.Checked)
            {
                tap_tool_combobox.DataSource = TiposdeTap.TapInch;
                tap_tool_combobox.DisplayMember = "Descricao";
                tap_tool_combobox.ValueMember = "Descricao";
            }
        }

        private void tap_tool_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tap_tool_combobox.SelectedItem != null)
            {
                TiposdeTap selectedTap = (TiposdeTap)tap_tool_combobox.SelectedItem;
                tap_tool_tb.Text = selectedTap.ToolNumber.ToString();
                tap_pitch_tb.Text = selectedTap.Pitch.ToString();
                mentori_Frente1.men_frente_kei_tb.Text = selectedTap.Diametro.ToString();
                mentori_Frente2.men_frente_kei_tb.Text = selectedTap.Diametro.ToString();
                tap_q_tb.Text = selectedTap.Q.ToString();
                tap_k_tb.Text = selectedTap.K.ToString();
                drill_UserControl1.drill_kei_tb.Text = selectedTap.ShitaAna.ToString();
                tap_kaiten_tb.Text = selectedTap.Kaiten.ToString();
                drill_UserControl1.DrillKakouAnnai = "下孔(" + selectedTap.Descricao + ")";

                if(selectedTap.Diametro > 8)
                {
                    tap_z_tb.Text = "-15";
                }
                else
                {
                    tap_z_tb.Text = "-10";
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(tap_mm_rb.Checked)
            { 
               if(checkBox1.Checked)
               {
                     tap_tool_combobox.DataSource = TiposdeTap.ZPro;
                    tap_tool_combobox.DisplayMember = "Descricao";
                    tap_tool_combobox.ValueMember = "Descricao";
                }
               else
               {
                    tap_tool_combobox.DataSource = TiposdeTap.TapMM;
                    tap_tool_combobox.DisplayMember = "Descricao";
                    tap_tool_combobox.ValueMember = "Descricao";
                }
            }
        }

        private void mentori_Frente1_Load(object sender, EventArgs e)
        {
            mentori_Frente1.men_frente_tam_tb.Text = "0.5";
            mentori_Frente1.men_frente_z_tb.Text = "-1.5";
            mentori_Frente1.men_frente_tipo_combo.SelectedIndex = 0;
        }

        private void mentori_Frente2_Load(object sender, EventArgs e)
        {
            mentori_Frente2.men_frente_tam_tb.Text = "0.5";
            mentori_Frente2.men_frente_z_tb.Text = "-1.5";
            mentori_Frente2.men_frente_tipo_combo.SelectedIndex = 0;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { avan_panel.Visible = true; }
            else{ avan_panel.Visible = false; }

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (shitaana_checkbox.Checked) { drill_UserControl1.Visible = true; }
            else { drill_UserControl1.Visible= false; }
        }

        private void tap_z_tb_TextChanged(object sender, EventArgs e)
        {
            float z;
            float drillz = 0;
            if(float.TryParse(tap_z_tb.Text, out z))
            {
                if(z < 0) { z*=-1; }
                drillz = (z + 5)*-1;

                drill_UserControl1.drill_z_tb.Text = drillz.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            float kei;
            float fukasa;
            int tool;
            Tap tap = new Tap(peca);
            tap.Index = Programas.Index();
            tap.Nome = drills.Index.ToString() + "-" + drill.drill_combobox.Text;
            tap.ToolName = drill.drill_combobox.Text;
            tap.ipoDrill = (TipoDeDrills)drill.drill_combobox.SelectedItem;
            if (float.TryParse(drill.drill_kei_tb.Text, out kei))
            {
                tap.Kei = kei;
            }
            if (float.TryParse(drill.drill_z_tb.Text, out fukasa))
            {
                drills.Fukasa = fukasa;
            }
            drills.Sentan = drill.sentan_check.Checked;
            drills.Description = drill.Kakou_Annai_tb.Text;
            drills.Resfriamento = drill.Resfri_Combobox.Text;
            if (int.TryParse(drill.tool_tb.Text, out tool)) { drills.ToolNumber = tool; }

            drills.Frente = lado.Bool_Frente;
            drills.Tras = lado.Bool_Tras;
            Color colorselecionada = (Color)color.comboBox1.SelectedItem;
            drills.Color = colorselecionada;
            drills.numlado = 0;

            Ferramentas.DGVtoCoordenadasList(drills, xy_dgv, pcd_dgv, xyradiobutton, pcdradiobutton, PCDRaio, pontoinicialX, pontoinicialY);
            Mentori.CriarMentori(ferramentas.ListTotal, ferramentas.ListFrente, ferramentas.ListTras, drills, peca, MentoriF, MentoriT);

            ferramentas.ListTotal.Add(drills);
            if (drills.Frente) { ferramentas.ListFrente.Add(drills); }
            if (drills.Tras) { ferramentas.ListTras.Add(drills); }
            if (drills.Mentori_F_Bool) { ferramentas.MentoriFrente.Add(drills); }
            if (drills.Mentori_B_Bool) { ferramentas.MentoriTras.Add(drills); }

        }
    }
}
