using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krisiun_Project.G_Code;

namespace Krisiun_Project.Janelas
{
    public partial class CoordenadaCopyForm : Form
    {
        public Ferramentas FerramentaSelecionada { get; set; }

        private Ferramentas ferramenta;
        private DrillsForm drillform;
        private TapForm tapForm;
        public CoordenadaCopyForm(Ferramentas ferramentas, Form form)
        {
            InitializeComponent();
            this.ferramenta = ferramentas;
            dataGridView1.DataSource = ferramentas.ListTotal;
            if(form is DrillsForm)
            { 
            this.drillform = (DrillsForm)form;
            }
            if(form is TapForm)
            {
                              this.tapForm = (TapForm)form;
            }
        }

        private void CoordenadaCopyForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FerramentaSelecionada != null)
            {
                // Faça algo com a ferramenta selecionada, como exibir suas propriedades
                if (drillform != null)
                { 
                drillform.AtualizarDGV(FerramentaSelecionada);
                }
                if (tapForm != null)
                {
                    tapForm.AtualizarDGV(FerramentaSelecionada);
                }
            }

            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedIndex = dataGridView1.SelectedRows[0].Index;
                FerramentaSelecionada = (Ferramentas)dataGridView1.Rows[selectedIndex].DataBoundItem;
            }
            else
            {
                FerramentaSelecionada = null;
            }
        }
    }
}
