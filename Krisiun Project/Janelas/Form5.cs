using Krisiun_Project.G_Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Krisiun_Project.Janelas
{
    public partial class Form5 : Form
    {
        private Ferramentas ferramentas;
        private Pitch_principal.Peca peca;  
        public Form5(Ferramentas ferramentas, Pitch_principal.Peca peca, Form1 form1)
        {
            InitializeComponent();
            this.ferramentas = ferramentas; 
            this.peca = peca;
            listBox1.DataSource = ferramentas.ListFrente;
            listBox1.ValueMember = "Nome";

        }
        private void IncrementOrDecrementSelectedObjectValue(bool increment)
        {
            // obtém o objeto selecionado na ListBox
            var selectedItem = listBox1.SelectedItem as Ferramentas;

            if (selectedItem != null)
            {
                // adiciona ou remove 1 da propriedade Value do objeto
                if (increment)
                {
                    selectedItem.Index++;
                }
                else
                {
                    selectedItem.Index--;
                }
                MessageBox.Show(selectedItem.Index.ToString());
                // atualiza a ListBox e a BindingList
                listBox1.DataSource = null;
                listBox1.DataSource = ferramentas.ListFrente;
                listBox1.ValueMember = "Nome";
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            himen_tb.Text = peca.hinmei;
            zuban_tb.Text = peca.zuban;
            if (ferramentas.ListTras.Count == 0)
            {
                ura_radio.Enabled = false;
                ura_radio.Checked = false;
            }
            else { ura_radio.Enabled = true; }
            if(ferramentas.ListFrente.Count == 0)
            {
                omote_radio.Enabled = false;
                omote_radio.Checked = false;
            }
            else {  omote_radio.Enabled = true; }
        }

        private void himen_tb_TextChanged(object sender, EventArgs e)
        {
            peca.hinmei = himen_tb.Text;

        }

        private void zuban_tb_TextChanged(object sender, EventArgs e)
        {
            peca.zuban = zuban_tb.Text;
        }

        private void omote_radio_CheckedChanged(object sender, EventArgs e)
        {
            if(omote_radio.Checked) { peca.omote = 1; }
            else { peca.omote = 2; }

        }

        private void ura_radio_CheckedChanged(object sender, EventArgs e)
        {
            if(ura_radio.Checked) { peca.ura = 1; }
            else { peca.ura = 2; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IncrementOrDecrementSelectedObjectValue(true);
    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IncrementOrDecrementSelectedObjectValue(false);
        }
    }
}
