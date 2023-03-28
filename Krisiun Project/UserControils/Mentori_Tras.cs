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
            men_tras_tipo_combo.SelectedIndex = 0;
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
    }
}
