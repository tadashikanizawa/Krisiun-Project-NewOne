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
    public partial class Mentori_Tras : UserControl
    {
        public Mentori_Tras()
        {
            InitializeComponent();
            men_tras_tipo_combo.DataSource = TiposdeMentori.ListadeMentoriCutterB;
            men_tras_tipo_combo.DisplayMember = "Tool";
            men_tras_tipo_combo.ValueMember = "Tool";
         //   men_tras_tipo_combo.SelectedIndex = 0;
        }
        public string Kei
        {
            get { return men_tras_kei.Text; }
            set { men_tras_kei.Text = value; }
        }

        private void Mentori_Tras_Load(object sender, EventArgs e)
        {

        }
        float tamcutter = 0;
        private void men_tras_tipo_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiposdeMentori selectedMentori = men_tras_tipo_combo.SelectedItem as TiposdeMentori;

            // Verificar se o objeto selecionado não é nulo
            if (selectedMentori != null)
            {
                // Atualize a TextBox com o valor da propriedade
                tamcutter = selectedMentori.Profundidade;
            }
        }

        private void men_tras_z_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(men_tras_z.Text, out float valor))
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
