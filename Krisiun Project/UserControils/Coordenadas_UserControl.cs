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
    public partial class Coordenadas_UserControl : UserControl
    {
        public Coordenadas_UserControl()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            xy_panel.BringToFront();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pcd_panel.BringToFront();
        }
    }
}
