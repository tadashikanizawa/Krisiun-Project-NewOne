using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.Janelas
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
        private void AdicionarEventosDeTextChanged(Panel panel)
        {
            for (int i = 1; i <= 20; i++)
            {
                TextBox xTextBox = panel.Controls.Find("X_" + i, true).FirstOrDefault() as TextBox;
                TextBox yTextBox = panel.Controls.Find("Y_" + i, true).FirstOrDefault() as TextBox;

                if (xTextBox != null && yTextBox != null)
                {
                    // xTextBox.TextChanged += CoordenadaTextBox_TextChanged;
                    //yTextBox.TextChanged += CoordenadaTextBox_TextChanged;
                }
            }
        }
        private void tamanhopainel(Panel panel)
        {
            panel.MaximumSize = new Size(150, 500);
            // Definir a altura do painel para acomodar todos os objetos
            int panelHeight = panel.Controls.Cast<Control>().Sum(c => c.Height + c.Margin.Vertical);
            panel.Height = panelHeight;

            // Verificar se o conteúdo do painel está saindo da área visível
            if (panel.DisplayRectangle.Height < panel.Height)
            {
                // Exibir barra de rolagem
                panel.AutoScroll = true;
            }
            else
            {
                // Ocultar barra de rolagem
                panel.AutoScroll = false;
            }

        }
    }
}
