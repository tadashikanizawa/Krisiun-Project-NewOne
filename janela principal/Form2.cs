using Krisiun_Project.G_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.janela_principal
{
    public partial class Form2 : Form
    {
        public int contador = 0;
     //   private Grupos grupos;
        private Ferramentas tools;
        private Form1 form1;
        private Bools bools;
        public Form2(Form1 form1, Ferramentas tools, Bools bools)
        {
            InitializeComponent();
           
       //    this.grupos = new Grupos();
            this.tools = tools;
            this.form1 = form1;
            this.bools = bools;
            comboBox1.DataSource = Enum.GetValues(typeof(Tipo_de_Corte));
            comboBox1.DisplayMember = "ToString";
            comboBox1.SelectedIndex = 0;
            frente_checkbox.Checked = bools.Form2_Frente ;
            tras_checkbox.Checked = bools.Form3_Tras;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool frente = false;
            bool tras = false;
            if(frente_checkbox.Checked == true) { frente = true; }
            if(tras_checkbox.Checked == true) { tras = true; }
            //tools.addferramenta(frente, tras);
            tools.addferramenta1();
            //form1.bindingSource.ResetBindings(false);
          //  form1.dataGridView1.Refresh();
           // form1.dataGridView2.Refresh();
            this.Close();

            
      
        }


        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            //int i = grupos.num;
           // form1.setvalortextc(grupos.Lista[i].Nome);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void frente_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (frente_checkbox.Checked) { bools.Form2_Frente = true; }
            else { this.bools.Form2_Frente = false; }
        }

        private void tras_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (tras_checkbox.Checked) { bools.Form3_Tras = true; }
            else { this.bools.Form3_Tras= false; }
        }
    }
}
