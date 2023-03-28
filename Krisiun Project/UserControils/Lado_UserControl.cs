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
        public Mentori_Frente mentorifrente;
        public Mentori_Tras mentoritras;
        public DrillsForm drillsform;
        public Lado_UserControl()
        {
            InitializeComponent();
        }

        private void frente_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(frente_checkBox.Checked) {  }
            else { mentorifrente.Visible = false; }
        }

    }
}
