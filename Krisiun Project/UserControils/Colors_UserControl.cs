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
using Krisiun_Project.Desenhos;
using Krisiun_Project.G_Code;

namespace Krisiun_Project.UserControils
{
    public partial class Colors_UserControl : UserControl
    {
        public Colors_UserControl()
        {
            InitializeComponent();
            comboBox1.DataSource = ColorList.ListadeCores;

        }
        public void LoadColor(Ferramentas ferramenta)
        {
            comboBox1.SelectedItem = ferramenta.Color;
        }
        Color corAtual = Color.Black;
        private void selecionarCor(object sender, EventArgs e)
        {
            ColorItem itemCor = (ColorItem)comboBox1.SelectedItem;
            corAtual = itemCor.Color; // Definindo a cor atual para a cor selecionada
        }
        private void Colors_UserControl_Load(object sender, EventArgs e)
        {

        }
    }
}
