using Krisiun_Project.Dados_aleatorios;
using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.G_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.UserControils
{
    public partial class Drill_UserControl : UserControl
    {
      
        public float atsumi;
        public Drill_UserControl()
        {
            InitializeComponent();

            
            drill_combobox.DataSource = TipoDeDrills.ListaDeTiposdeDrills;
            drill_combobox.DisplayMember = "Name";
            drill_combobox.ValueMember = "Name";
      
        }
        public TipoDeDrills DrillTipo
        {
            get { return (TipoDeDrills)drill_combobox.SelectedItem; }
            set { drill_combobox.SelectedItem = value; }
        }
        public string DrillNumber
        {
            get { return tool_tb.Text; }
            set { tool_tb.Text = value; }
        }
        public string DrillKei
        {
            get { return drill_kei_tb.Text; }
            set { drill_kei_tb.Text = value; }
        }
        public string DrillZ
        {
            get { return drill_z_tb.Text; }
            set { drill_z_tb.Text = value; }
        }
        public bool Sentan
        {
            get { return sentan_check.Checked; }
            set { sentan_check.Checked = value; }
        }

     
        public string DrillKakouAnnai
        {
            get { return Kakou_Annai_tb.Text; }
            set { Kakou_Annai_tb.Text = value; }
        }
        public float Atsumi
        {
            get { return atsumi; } 
            set { atsumi = value; }
        }
        public void LoadData(Drills drill)
        {
            if (drill != null)
            {
                DrillNumber = drill.ToolNumber.ToString();
                DrillKei = drill.Kei.ToString();
                DrillZ = drill.Fukasa.ToString();
                Sentan = drill.Sentan;
                DrillKakouAnnai = drill.Description;
                DrillTipo = drill.TipoDrill;
                
                // Adicione outras propriedades conforme necessário
            }
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
               

            float kei = 0;
            float.TryParse(drill_kei_tb.Text, out kei);
            Kougu numero = Kougu.ListadeKougu.Find(x => x.DrillKei == kei);
            if (numero != null)
            {
                tool_tb.Text = numero.DrillNumber.ToString();
                drill_combobox.Text = numero.DrillName.ToString();
            }
            else
            {
                tool_tb.Text = ToolNumber.contador();
            }

        }

        private void drill_z_tb_TextChanged(object sender, EventArgs e)
        {

            string valor = drill_z_tb.Text.ToString().Replace("-", "");
            float z;
            float kei;

            if (float.TryParse(drill_kei_tb.Text, out kei))
            {
                if (float.TryParse(valor, out z))
                {
                    if (drill_combobox.SelectedIndex == 0)
                    {
                        NSB x = NSB.NSBs.Find(n => n.Dia == kei);
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

        private void Drill_UserControl_Load(object sender, EventArgs e)
        {

        }

    }
}
