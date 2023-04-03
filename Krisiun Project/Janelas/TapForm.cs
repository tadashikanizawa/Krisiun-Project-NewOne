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
                tap_q_tb.Text = TiposdeTap.getQ(selectedTap.Diametro).ToString();
                tap_k_tb.Text = selectedTap.K.ToString();

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
    }
}
