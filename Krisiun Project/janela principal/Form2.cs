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
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //tools.addferramenta(frente, tras);
            tools.addferramenta1((Tipo_de_Corte)comboBox1.SelectedItem);
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

    
    }
}
