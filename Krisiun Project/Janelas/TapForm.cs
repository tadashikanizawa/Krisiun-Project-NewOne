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
    }
}
