using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.UserControils
{
    public partial class Mentori_Frente : UserControl
    {
        public Mentori_Frente()
        {
            InitializeComponent();
            men_frente_tipo_combo.DataSource = TiposdeMentori.ListadeMentoriCutterF;
            men_frente_tipo_combo.DisplayMember = "Tool";
            men_frente_tipo_combo.ValueMember = "Tool";
            men_frente_tipo_combo.SelectedIndex = 0;

        }
        public float tamcutter;
        public string Kei
        {
            get{ return men_frente_kei_tb.Text; }
            set { men_frente_kei_tb.Text = value; }
        }
        private void Mentori_Frente_Load(object sender, EventArgs e)
        {

        }

        private void men_frente_tipo_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiposdeMentori selectedMentori = men_frente_tipo_combo.SelectedItem as TiposdeMentori;

            // Verificar se o objeto selecionado não é nulo
            if (selectedMentori != null)
            {
                // Atualize a TextBox com o valor da propriedade
                tamcutter = selectedMentori.Profundidade;
            }
        }

        private void men_frente_z_tb_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(men_frente_z_tb.Text, out float valor))
            {
                if (valor > tamcutter)
                {
                    if (valor < 0) { valor *= -1; }
                    MessageBox.Show("このカッターの刃長は" + tamcutter.ToString() + "ので。大丈夫でしょうか？");
                }

            }
        }
    }
}
