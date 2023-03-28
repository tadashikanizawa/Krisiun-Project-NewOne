using Krisiun_Project.Dados_aleatorios;
using Krisiun_Project.Dados_Aleatorios1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.UserControils
{
    public partial class Drill_UserControl : UserControl
    {
        public Mentori_Frente mentorifrente;
        public Mentori_Tras mentoritras;
        public Pitch_principal.Peca peca;
        public Drill_UserControl()
        {
            InitializeComponent();
            drill_combobox.DataSource = TipoDeDrills.ListaDeTiposdeDrills;
            drill_combobox.DisplayMember = "Name";
            drill_combobox.ValueMember = "Name";
        }

        private void drill_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drill_combobox.SelectedIndex <= 2) { Resfri_Combobox.SelectedIndex = 2; }
            else { Resfri_Combobox.SelectedIndex = 0; }
        }

        public bool atualizarportextbox = false;
        private void drill_kei_tb_TextChanged(object sender, EventArgs e)
        {

            if (atualizarportextbox) { return; }
            mentorifrente.Kei = drill_kei_tb.Text;
            mentoritras.Kei = drill_kei_tb.Text;

            float kei = 0;
            float.TryParse(drill_kei_tb.Text, out kei);
            Kougu numero = Kougu.ListadeKougu.Find(x => x.DrillKei == kei);
            if (numero != null)
            {
                tool_tb.Text = numero.DrillNumber.ToString();
            }
            else
            {
                tool_tb.Text = ToolNumber.contador();
            }

        }

        private void drill_z_tb_TextChanged(object sender, EventArgs e)
        {

            float atsumi = peca.z;
            string valor = drill_z_tb.Text.ToString().Replace("-", "");
            float z;
            float kei;

            var nsb = NSBLoader.Load();
            if (float.TryParse(drill_kei_tb.Text, out kei))
            {
                if (float.TryParse(valor, out z))
                {
                    if (drill_combobox.SelectedIndex == 0)
                    {
                        NSB x = nsb.Find(n => n.Dia == kei);
                        if (x != null)
                        {
                            if (x.Hachou < z)
                            {
                                DialogResult result = MessageBox.Show("Moldinoソリッドドリル5Dの刃長は" + x.Hachou.ToString() + "mm.\n\nもっと長いドリルを追加するか？", "確認", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    MessageBox.Show("teste-Drill");
                                }
                            }
                        }
                    }
                    if (drill_combobox.SelectedIndex == 1)
                    {
                        kei *= 5.15f;
                        if (kei < z)
                        {
                            DialogResult result = MessageBox.Show("イスカルドリル5Dの長さは" + kei.ToString() + "mm.\n\nもっと長いドリルを追加するか？", "確認", MessageBoxButtons.YesNo);

                            if (result == DialogResult.Yes)
                            {
                                MessageBox.Show("teste-Cam");
                            }
                        }
                    }


                }
            }

        }
    }
}
