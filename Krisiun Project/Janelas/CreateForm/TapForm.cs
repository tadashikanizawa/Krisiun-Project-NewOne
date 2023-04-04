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
        public Drills drills;
        public Form1 form;
        public TiposdeTap TapCombobox
        {
            get { return (TiposdeTap)tap_tool_combobox.SelectedItem; }
            set { tap_tool_combobox.SelectedItem = value; }
        }
        private bool isEditMode;
        public TapForm(Form1 form, Ferramentas ferramentas, Ferramentas ferramenta, Pitch_principal.Peca peca, Drills drills )
        {
            InitializeComponent();
            this.ferramentas = ferramentas;
            this.form = form;
            this.ferramenta = ferramenta;
            this.peca = peca;
            this.drills = drills;
            this.isEditMode = ferramenta != null;
            tap_tool_combobox.DataSource = TiposdeTap.TapMM;
            tap_tool_combobox.DisplayMember = "Descricao";
            tap_tool_combobox.ValueMember = "Descricao";

            drill_UserControl1.Atsumi = peca.z;
            lado_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterar;
            lado_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterar;
            drill_UserControl1.OnAlterarPropriedades += mentori_Frente1.alterarkei;
            drill_UserControl1.OnAlterarPropriedades1 += mentori_Frente2.alterarkei;
            if(isEditMode)
            {
                if(ferramenta is Tap tap)
                {
                    LoadTap(tap);
                }
                colors_UserControl1.LoadColor(ferramenta);
                lado_UserControl1.LoadLado(ferramenta);
                mentori_Frente1.LoadMentori(ferramenta, false);
                mentori_Frente2.LoadMentori(ferramenta, true);
                Coordenadas.LoadCoordinates(ferramenta, dataGridView1);
                shitaana_checkbox.Visible = false;
            }
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

            if (radioButton1.Checked)
            {
                if (dataGridView1.Rows.Count <= 1) { MessageBox.Show("Add coordenadas"); return; }
            }
            if (radioButton2.Checked)
            {
                if (dataGridView2.Rows.Count <= 1) { MessageBox.Show("Add coordenadas"); return; }
            }
           if(!isEditMode)
            {
                GerarTap();
            }
            else { EditarTap(); }
            form.panel_update();
            this.Close();
        }
        public void GerarTap()
        {
            TiposdeTap selectedTap = (TiposdeTap)tap_tool_combobox.SelectedItem;
            float q;
            float k;
            float fukasa;
            int tool;

            Tap tap = new Tap(peca);

            tap.Index = Programas.Index();
            tap.Nome = tap.Index.ToString() + "-" + tap_tool_combobox.Text;
            tap.ToolName = tap_tool_combobox.Text;
            tap.Tipo = (TiposdeTap)tap_tool_combobox.SelectedItem;
            tap.Kei = selectedTap.Diametro;

            if (float.TryParse(tap_q_tb.Text, out q)) { tap.Q = q; }
            if (float.TryParse(tap_k_tb.Text, out k)) { tap.K = k; }
            if (float.TryParse(tap_z_tb.Text, out fukasa)) { tap.Fukasa = fukasa; }

            tap.Description = selectedTap.Descricao;
            tap.Resfriamento = "M09";
            if (checkBox1.Checked) { tap.Resfriamento = "M08"; }
            if (int.TryParse(tap_tool_tb.Text, out tool)) { tap.ToolNumber = tool; }

            tap.Frente = lado_UserControl1.Bool_Frente;
            tap.Tras = lado_UserControl1.Bool_Tras;
            Color colorselecionada = (Color)colors_UserControl1.comboBox1.SelectedItem;
            tap.Color = colorselecionada;
            tap.numlado = 0;

            Ferramentas.DGVtoCoordenadasList(tap, dataGridView1, dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);
            Mentori.CriarMentori(ferramentas.ListTotal, ferramentas.ListFrente, ferramentas.ListTras, tap, peca, mentori_Frente1, mentori_Frente2);

            ferramentas.ListTotal.Add(tap);
            if (tap.Frente) { ferramentas.ListFrente.Add(tap); }
            if (tap.Tras) { ferramentas.ListTras.Add(tap); }
            if (!shitaana_checkbox.Checked)
            {
                if (tap.Mentori_F_Bool) { ferramentas.MentoriFrente.Add(tap); }
                if (tap.Mentori_B_Bool) { ferramentas.MentoriTras.Add(tap); }
            }
            if (shitaana_checkbox.Checked)
            {
                drills.CriarDrills(ferramentas, drill_UserControl1, lado_UserControl1, mentori_Frente1, mentori_Frente2, colors_UserControl1, dataGridView1, dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);
                tap.Mentori_B_Bool = false;
                tap.Mentori_F_Bool = false;
            }
        }
        public void EditarTap()
        {
            TiposdeTap selectedTap = (TiposdeTap)tap_tool_combobox.SelectedItem;
            float q;
            float k;
            float fukasa;
            int tool;
            if (ferramenta is Tap tap)
            {

                tap.Index = Programas.Index();
                tap.Nome = tap.Index.ToString() + "-" + tap_tool_combobox.Text;
                tap.ToolName = tap_tool_combobox.Text;
                tap.Tipo = (TiposdeTap)tap_tool_combobox.SelectedItem;
                tap.Kei = selectedTap.Diametro;

                if (float.TryParse(tap_q_tb.Text, out q)) { tap.Q = q; }
                if (float.TryParse(tap_k_tb.Text, out k)) { tap.K = k; }
                if (float.TryParse(tap_z_tb.Text, out fukasa)) { tap.Fukasa = fukasa; }

                tap.Description = selectedTap.Descricao;
                tap.Resfriamento = "M09";
                if (checkBox1.Checked) { tap.Resfriamento = "M08"; }
                if (int.TryParse(tap_tool_tb.Text, out tool)) { tap.ToolNumber = tool; }

                tap.Frente = lado_UserControl1.Bool_Frente;
                tap.Tras = lado_UserControl1.Bool_Tras;
                Color colorselecionada = (Color)colors_UserControl1.comboBox1.SelectedItem;
                tap.Color = colorselecionada;


                Ferramentas.DGVtoCoordenadasList(tap, dataGridView1, dataGridView2, radioButton1, radioButton2, textBox1, textBox2, textBox3);
                Mentori.CriarMentori(ferramentas.ListTotal, ferramentas.ListFrente, ferramentas.ListTras, tap, peca, mentori_Frente1, mentori_Frente2);

                if(!tap.Frente && !tap.Tras)
                {
                    if(ferramentas.ListTotal.Contains(tap))
                    {
                        ferramentas.ListTotal.Remove(tap);
                    }
                }
                if (!tap.Frente)
                {
                    if (ferramentas.ListFrente.Contains(tap))
                    {
                        ferramentas.ListFrente.Remove(tap);
                    }
                }
                if (!tap.Tras)
                {
                    if (ferramentas.ListTras.Contains(tap))
                    {
                        ferramentas.ListTras.Remove(tap);
                    }
                }

            }
        }   
        public void LoadTap(Tap tap)
        {
            TapCombobox = tap.Tipo;         
            tap_tool_tb.Text = tap.ToolNumber.ToString();
            tap_q_tb.Text = tap.Q.ToString();
            tap_k_tb.Text = tap.K.ToString();
            tap_z_tb.Text = tap.Fukasa.ToString();
            lado_UserControl1.Bool_Frente = tap.Frente;
            lado_UserControl1.Bool_Tras = tap.Tras;
            colors_UserControl1.comboBox1.SelectedItem = tap.Color;
           
        }
        private void drill_UserControl1_Load(object sender, EventArgs e)
        {
            drill_UserControl1.drill_z_tb.Text = "-15";
        }
    }
}
