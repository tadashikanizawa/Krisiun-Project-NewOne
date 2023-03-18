using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using Krisiun_Project.Numeros;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Krisiun_Project.Janelas
{
    public partial class Form3 : Form
    {
        private Pitch_principal.Peca peca;
        private Pitch_principal.Pitch principal;
        private Pitch_principal.Shindashi shindashi;
        private Bools bools;
        private Form1 form1;
        private Bugs.Bugs_Txb bugs;

        public Form3(Pitch_principal.Peca peca, Form1 form1, Pitch_principal.Pitch principal, Pitch_principal.Shindashi shindashi, Bugs.Bugs_Txb bugs, Bools bools)
        {
            InitializeComponent();
            this.shindashi = shindashi;
            this.peca = peca;
            this.principal = principal;
            this.bugs = bugs;
            this.form1 = form1;
            this.bools = bools;
            LoadDrills();
        }
        private void LoadDrills()
        {
            List<Material> Materiais = Material.LoadMaterialsFromFile();

            comboBox1.DataSource = Materiais;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Name";
        }
        private void sizex_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sizex.Text)) { return; }
            bugs.sohnums(sizex, e);
            //    t.teste(sizex.Text);


            if (float.TryParse(sizex.Text, out float x) &&
                float.TryParse(sizey.Text, out float y) &&
                float.TryParse(sizez.Text, out float z))
            {
                if (maru_rb.Checked)
                { peca.width = x; peca.height = x; peca.z = z; sizey.Enabled = false; basex_tb.Enabled = false; basex_tb.Text = (x / 2).ToString(); basey_tb.Enabled = false; basey_tb.Text = (x / 2).ToString(); sizey.Text = sizex.Text; }
                if (shikaku_rd.Checked)
                {
                    peca.width = x; peca.height = y; peca.z = z; basex_tb.Enabled = true; basey_tb.Enabled = true; sizey.Enabled = true;
                    float p = peca.width / 2;
                    basex_tb.Text = p.ToString();
                }
                peca.sizex = x; peca.sizey = y; peca.sizez = z;
            }

        }

        private void sizey_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sizey.Text)) { return; }
            bugs.sohnums(sizey, e);

            if (float.TryParse(sizex.Text, out float x) &&
                float.TryParse(sizey.Text, out float y) &&
                float.TryParse(sizez.Text, out float z))
            {
                peca.width = x; peca.height = y; peca.z = z;

                peca.sizex = x; peca.sizey = y; peca.sizez = z;
            }
            float p = peca.height / 2;
            basey_tb.Text = p.ToString();
        }

        private void sizez_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(sizez.Text)) { return; }
            bugs.sohnums(sizey, e);

            if (float.TryParse(sizex.Text, out float x) &&
                float.TryParse(sizey.Text, out float y) &&
                float.TryParse(sizez.Text, out float z))
            {
                peca.width = x; peca.height = y; peca.z = z;

                peca.sizex = x; peca.sizey = y; peca.sizez = z;
            }
        }

        private void maru_rb_CheckedChanged(object sender, EventArgs e)
        {
            sizey.Enabled = false;

            if (maru_rb.Checked) { bools.Maru = true; }
            if (maru_rb.Checked == false) { bools.Maru = false; }

        }


        private void shikaku_rd_CheckedChanged(object sender, EventArgs e)
        {

            if (shikaku_rd.Checked) { sizey.Enabled = true; bools.Shikaku = true; }
            if (shikaku_rd.Checked == false) { bools.Shikaku = false; }

        }

        private void basex_tb_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(basex_tb.Text)) { return; };
            bugs.sohnums(basex_tb, e);
            bugs.sohnums(basey_tb, e);
            if (float.TryParse(basex_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
                float.TryParse(basey_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
            {
                peca.basex = x;
                peca.basey = y;
                principal.calculo_de_base(shindashi, peca, x, y);


            }
            else
            {
                // o valor não é um número válido
            }
        }

        private void basey_tb_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(basey_tb.Text)) { return; };
            bugs.sohnums(basey_tb, e);
            if (float.TryParse(basex_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
                float.TryParse(basey_tb.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out float y))
            {
                peca.basex = x;
                peca.basey = y;
                principal.calculo_de_base(shindashi, peca, x, y);


            }
            else
            {
                // o valor não é um número válido
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            form1.panel_update();
            this.Close();
        }

        private void himen_tb_TextChanged(object sender, EventArgs e)
        {
            peca.hinmei = himen_tb.Text;
        }

        private void zuban_tb_TextChanged(object sender, EventArgs e)
        {
            peca.zuban = zuban_tb.Text;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            peca.Material = (Material)comboBox1.SelectedItem;
        }
    }
}
