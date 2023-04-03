using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.UserControils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
    public class Tap : Ferramentas
    {
        public string TapNome { get; set; }
        public TiposdeTap Tipo { get; set; }
        public string unidade { get; set; }
        public float Q { get; set; }
        public float K { get; set; }
        

        public Tap(Pitch_principal.Peca peca): base(peca)
        {
        }




        public void CriarTap(Ferramentas ferramentas, Drill_UserControl drill, Lado_UserControl lado, Mentori_Frente MentoriF, Mentori_Frente MentoriT, Colors_UserControl color, DataGridView xy_dgv, DataGridView pcd_dgv, RadioButton xyradiobutton, RadioButton pcdradiobutton, TextBox PCDRaio, TextBox pontoinicialX, TextBox pontoinicialY)
        {
            float kei;
            float fukasa;
            int tool;
            Drills drills = new Drills(peca);
            drills.Index = Programas.Index();
            drills.Nome = drills.Index.ToString() + "-" + drill.drill_combobox.Text;
            drills.ToolName = drill.drill_combobox.Text;
            drills.TipoDrill = (TipoDeDrills)drill.drill_combobox.SelectedItem;
            if (float.TryParse(drill.drill_kei_tb.Text, out kei))
            {
                drills.Kei = kei;
            }
            if (float.TryParse(drill.drill_z_tb.Text, out fukasa))
            {
                drills.Fukasa = fukasa;
            }
            drills.Sentan = drill.sentan_check.Checked;
            drills.Description = drill.Kakou_Annai_tb.Text;
            drills.Resfriamento = drill.Resfri_Combobox.Text;
            if (int.TryParse(drill.tool_tb.Text, out tool)) { drills.ToolNumber = tool; }

            drills.Frente = lado.Bool_Frente;
            drills.Tras = lado.Bool_Tras;
            Color colorselecionada = (Color)color.comboBox1.SelectedItem;
            drills.Color = colorselecionada;
            drills.numlado = 0;

            Ferramentas.DGVtoCoordenadasList(drills, xy_dgv, pcd_dgv, xyradiobutton, pcdradiobutton, PCDRaio, pontoinicialX, pontoinicialY);
            Mentori.CriarMentori(ferramentas.ListTotal, ferramentas.ListFrente, ferramentas.ListTras, drills, peca, MentoriF, MentoriT);

            ferramentas.ListTotal.Add(drills);
            if (drills.Frente) { ferramentas.ListFrente.Add(drills); }
            if (drills.Tras) { ferramentas.ListTras.Add(drills); }
            if (drills.Mentori_F_Bool) { ferramentas.MentoriFrente.Add(drills); }
            if (drills.Mentori_B_Bool) { ferramentas.MentoriTras.Add(drills); }

        }

    }
}
