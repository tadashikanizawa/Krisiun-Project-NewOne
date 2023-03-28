using Krisiun_Project.Janelas;
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
    public partial class Lado_UserControl : UserControl
    {
        public delegate void AlterarPropriedadesEventHandler(bool visible);

        // Declarando um evento usando o delegado
        public event AlterarPropriedadesEventHandler OnAlterarPropriedades;
     
        public Lado_UserControl()
        {
            InitializeComponent();
            
        }

        private void frente_checkBox_CheckedChanged(object sender, EventArgs e)
        {
        Mudarvisibilidade(frente_checkBox.Checked);
        }
     
        private void Mudarvisibilidade(bool visible)
        {
                OnAlterarPropriedades?.Invoke(visible);
            
        }
    }
}
