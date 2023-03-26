using Krisiun_Project.G_Code;
using Krisiun_Project.Numeros;
using System;
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
            if(!angulo)
            { 
                 if(dataGridView1.Rows.Count == 1)
                  {
                      MessageBox.Show("Nenhuma ferramenta foi adicionada");
                      return;
                   }
            }
            if(angulo)
            {
                if(dataGridView2.Rows.Count == 1 && textBox1.Text == null)
                {
                    MessageBox.Show("Nenhuma ferramenta foi adicionada");
                    return;
                }
            }
            tools.addferramenta1((Tipo_de_Corte)comboBox1.SelectedItem, dataGridView1, angulo, dataGridView2, textBox1, textBox2, textBox3);

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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            textBox1.Text = "0";
            textBox2.Text = "0";   
            textBox3.Text = "0";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.BringToFront();
            if(radioButton1.Checked ) { angulo = false; }
            else { angulo = true; }

        }
        public bool angulo = false;

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel2.BringToFront();
       if(radioButton2.Checked ) { angulo = true; }
            else { angulo = false; }
        }
        
    }
}
