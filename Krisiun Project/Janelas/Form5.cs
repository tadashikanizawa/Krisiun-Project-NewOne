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
        private Form1 form1;
        private Ferramentas ferramentas;
        private Pitch_principal.Peca peca;
        private Pastas pastas;
        private Tejun tejun;
        private GCodeGenerator gCodeGenerator;
        public Form5(Ferramentas ferramentas, Pitch_principal.Peca peca, Form1 form1, Pastas pastas, GCodeGenerator gCodeGenerator )
        {
            InitializeComponent();
            this.ferramentas = ferramentas;
            this.peca = peca;
            this.form1 = form1;
            this.pastas = pastas;
            this.gCodeGenerator = gCodeGenerator;
            listBox1.DataSource = ferramentas.ListFrente;
            listBox1.ValueMember = "Index";
            listBox1.DisplayMember = "Nome";
            listBox2.DataSource = ferramentas.ListTras;
            listBox2.ValueMember = "Index";
            listBox2.DisplayMember = "Nome";
            this.pastas = pastas;
            this.tejun = new Tejun(ferramentas, this, peca, pastas);
        }
        private void AlterarOrdemfrente(bool subir)
        {
            int selectedIndex = listBox1.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < ferramentas.ListFrente.Count)
            {
                int newIndex = selectedIndex + (subir ? -1 : 1);
                if (newIndex >= 0 && newIndex < ferramentas.ListFrente.Count)
                {
                    var item = ferramentas.ListFrente[selectedIndex];
                    ferramentas.ListFrente.RemoveAt(selectedIndex);
                    ferramentas.ListFrente.Insert(newIndex, item);
                    listBox1.DataSource = null;
                    listBox1.DataSource = ferramentas.ListFrente;
                    listBox1.SelectedIndex = newIndex;
                    listBox1.DisplayMember = "Nome";
                    listBox1.ValueMember= "Index";
                    
                }
            }
        }
        private void AlterarOrdemtras(bool subir)
        {
            int selectedIndex = listBox2.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < ferramentas.ListTras.Count)
            {
                int newIndex = selectedIndex + (subir ? -1 : 1);
                if (newIndex >= 0 && newIndex < ferramentas.ListTras.Count)
                {
                    var item = ferramentas.ListTras[selectedIndex];
                    ferramentas.ListTras.RemoveAt(selectedIndex);
                    ferramentas.ListTras.Insert(newIndex, item);
                    listBox2.DataSource = null;
                    listBox2.DataSource = ferramentas.ListTras;
                    listBox2.SelectedIndex = newIndex;
                    listBox2.DisplayMember = "Nome";
                    listBox2.ValueMember = "Index";

                }
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
            if (ferramentas.ListFrente.Count == 0 && ferramentas.ListTras.Count == 0 ) 
            {
                button1.Enabled = false;
            }

            else { button1.Enabled = true; }
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
            // IncrementOrDecrementSelectedObjectValue(true);
            AlterarOrdemfrente(true);
    
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //IncrementOrDecrementSelectedObjectValue(false);
            AlterarOrdemfrente(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AlterarOrdemtras(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AlterarOrdemtras(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pastas.CriarPastas(peca.hinmei, peca.zuban);
            ferramentas.addtoolnumberK();
            if(ferramentas.ListFrente.Count > 0 ) { 
            form1.SavePictureBoxAsJPG(form1.paneld_f, "Front.jpeg");
            }
            if(ferramentas.ListTras.Count > 0 ) { 
            form1.SavePictureBoxAsJPG(form1.panel_b, "Back.jpeg");

            }
            if(ferramentas.ListFrente.Count !=0) { tejun.tejuncapa(peca.omote, "表加工", "Front.jpeg"); tejun.tejunlista(ferramentas.ListFrente, peca.omote, "表加工"); }

            if (ferramentas.ListTras.Count != 0) { tejun.tejuncapa(peca.ura, "裏加工", "Back.jpeg"); tejun.tejunlista(ferramentas.ListTras, peca.ura, "裏加工"); }

            gCodeGenerator.GenerateGCode(ferramentas.ListFrente, ferramentas, true, false);
            gCodeGenerator.GenerateGCode(ferramentas.ListTras, ferramentas, false, true);
        }
    }
}
