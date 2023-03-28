using Krisiun_Project.G_Code;
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
    public partial class Mentori_Frente : UserControl
    {
        public Mentori_Frente()
        {
            InitializeComponent();
            men_frente_tipo_combo.DataSource = TiposdeMentori.ListadeMentoriCutterF;
            men_frente_tipo_combo.DisplayMember = "Tool";
            men_frente_tipo_combo.ValueMember = "Tool";
            //men_frente_tipo_combo.SelectedIndex = 0;

        }
        public float tamcutter;
        public string Kei
        {
            get{ return men_frente_kei_tb.Text; }
            set { men_frente_kei_tb.Text = value; }
        }
        private void Mentori_Frente_Load(object sender, EventArgs e)
        {

        }

        private void men_frente_tipo_combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TiposdeMentori selectedMentori = men_frente_tipo_combo.SelectedItem as TiposdeMentori;

            // Verificar se o objeto selecionado não é nulo
            if (selectedMentori != null)
            {
                // Atualize a TextBox com o valor da propriedade
                tamcutter = selectedMentori.Profundidade;
            }
        }

        private void men_frente_z_tb_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(men_frente_z_tb.Text, out float valor))
            {
                if (valor > tamcutter)
                {
                    if (valor < 0) { valor *= -1; }
                    MessageBox.Show("このカッターの刃長は" + tamcutter.ToString() + "ので。大丈夫でしょうか？");
                }

            }
        }

        private void men_frente_tam_tb_TextChanged(object sender, EventArgs e)
        {

        }
        //private void MentorConfigs()
        //{
        //    var selecionado = GetSelectedObject();
        //    Mentori mentori = new Mentori(peca);
        //    MentoriB mentorib = new MentoriB(peca);
        //    TiposdeMentori selectedMentori = men_frente_tipo_combo.SelectedItem as TiposdeMentori;
        //    TiposdeMentori selectedMentoriB = men_tras_tipo_combo.SelectedItem as TiposdeMentori;

        //    mentori.TipoDeCutter = selectedMentori;
        //    mentori.ToolName = selectedMentori.Tool;
        //    mentori.ToolNumber = selectedMentori.MenCutterToolNum;
        //    mentori.Nome = selectedMentori.Tool;
        //    mentori.Kei = selectedMentori.Diametro;
        //    mentori.Kaiten = selectedMentori.Kaiten;
        //    mentori.Okuri = selectedMentori.Okuri;

        //    mentori.Index = 0;
        //    mentori.Frente = true;

        //    mentorib.TipoDeCutter = selectedMentoriB;
        //    mentorib.ToolName = selectedMentoriB.Tool;
        //    mentorib.ToolNumber = selectedMentoriB.MenCutterToolNum;
        //    mentorib.Nome = selectedMentoriB.Tool;
        //    mentorib.Kei = selectedMentoriB.Diametro;
        //    mentorib.Kaiten = selectedMentoriB.Kaiten;
        //    mentorib.Okuri = selectedMentoriB.Okuri;
        //    mentorib.Index = 1;
        //    mentorib.Tras = true;

        //    selecionado.Mentori_F_Bool = men_frente_checkbox.Checked;
        //    selecionado.Mentori_B_Bool = men_tras_checkbox.Checked;
        //    int ativoF = ferramentas.ListTotal.Count(x => x.Mentori_F_Bool);
        //    bool BoolativoF = ativoF > 0;
        //    int ativo1F = ferramentas.ListFrente.Count(x => x.Mentori_F_Bool);
        //    bool Boolativo1F = ativo1F > 0;
        //    int ativoB = ferramentas.ListTotal.Count(x => x.Mentori_B_Bool);
        //    bool BoolativoB = ativoB > 0;
        //    int ativo1B = ferramentas.ListTras.Count(x => x.Mentori_B_Bool);
        //    bool Boolativo1B = ativo1B > 0;




        //    if (BoolativoF == true)
        //    {
        //        if (ferramentas.ListTotal.Contains(mentori) == false) { ferramentas.ListTotal.Add(mentori); }
        //        if (ferramentas.ListFrente.Contains(mentori) == false) { ferramentas.ListFrente.Add(mentori); }
        //        // if (ferramentas.MentoriFrente.Contains(selecionado) == false) { ferramentas.MentoriFrente.Add(selecionado); }
        //        dataGridView3.Refresh();
        //    }
        //    else
        //    {
        //        if (ferramentas.ListFrente.Contains(mentori) == true) { ferramentas.ListFrente.Remove(mentori); }
        //        if (ferramentas.ListTotal.Contains(mentori) == true) { ferramentas.ListTotal.Remove(mentori); }
        //        // if (ferramentas.MentoriFrente.Contains(selecionado) == true) { ferramentas.MentoriFrente.Remove(selecionado); }
        //        dataGridView3.Refresh();
        //    }

        //    if (BoolativoB == true)
        //    {
        //        if (ferramentas.ListTotal.Contains(mentorib) == false) { ferramentas.ListTotal.Add(mentorib); }
        //        if (ferramentas.ListTras.Contains(mentorib) == false) { ferramentas.ListTras.Add(mentorib); }
        //        //  if (ferramentas.MentoriTras.Contains(selecionado) == false) { ferramentas.MentoriTras.Add(selecionado); }
        //        dataGridView3.Refresh();
        //    }
        //    else
        //    {
        //        if (ferramentas.ListTotal.Contains(mentorib) == true) { ferramentas.ListTotal.Remove(mentorib); }
        //        if (ferramentas.ListTras.Contains(mentorib) == true) { ferramentas.ListTras.Remove(mentorib); }
        //        //if (ferramentas.MentoriTras.Contains(selecionado) == true) { ferramentas.MentoriTras.Remove(selecionado); }
        //        dataGridView3.Refresh();
        //    }
        //    selecionado.Mentori = mentori;
        //    selecionado.MentoriB = mentorib;
        //    //drill.Mentori.MentoriCutter = selectedMentori;

        //    if (float.TryParse(men_frente_kei_tb.Text, out float menkei))
        //    {
        //        selecionado.Mentori.MenKei = menkei;
        //    }
        //    if (float.TryParse(men_frente_tam_tb.Text, out float tam))
        //    {
        //        selecionado.Mentori.C = tam;
        //    }
        //    if (float.TryParse(men_frente_dan_tb.Text, out float dan))
        //    {
        //        selecionado.Mentori.Dansa = dan;
        //    }
        //    if (float.TryParse(men_frente_z_tb.Text, out float z))
        //    {
        //        selecionado.Mentori.Z = z;
        //    }
        //    //daqui pra tras é de tras
        //    if (float.TryParse(men_tras_kei.Text, out float s))
        //    {
        //        selecionado.MentoriB.MenKei = s;
        //    }
        //    if (float.TryParse(men_tras_tam.Text, out float tam2))
        //    {
        //        selecionado.MentoriB.C = tam2;
        //    }
        //    if (float.TryParse(men_tras_dan.Text, out float dan2))
        //    {
        //        selecionado.MentoriB.Dansa = dan2;
        //    }
        //    if (float.TryParse(men_tras_z.Text, out float z2))
        //    {
        //        selecionado.MentoriB.Z = z2;
        //    }
        //    dataGridView3.Update();

        //    foreach (Ferramentas item in ferramentas.ListFrente)
        //    {
        //        if (item.Mentori_F_Bool == true)
        //        {
        //            if (ferramentas.MentoriFrente.Contains(item) == false)
        //            {
        //                ferramentas.MentoriFrente.Add(item);
        //            }
        //        }
        //    }
        //    foreach (Ferramentas item in ferramentas.ListTras)
        //    {
        //        if (item.Mentori_B_Bool == true)
        //        {
        //            if (ferramentas.MentoriTras.Contains(item) == false)
        //            {
        //                ferramentas.MentoriTras.Add(item);
        //            }
        //        }
        //    }
        //    foreach (Ferramentas item in ferramentas.MentoriFrente)
        //    {
        //        if (item.Mentori_F_Bool != true)
        //        { ferramentas.MentoriFrente.Remove(item); }
        //    }
        //    foreach (Ferramentas item in ferramentas.MentoriTras)
        //    {
        //        if (item.Mentori_B_Bool != true)
        //        { ferramentas.MentoriTras.Remove(item); }
        //    }

        //}

    }
}
