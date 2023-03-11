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
    }
}
