using Krisiun_Project.G_Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.janela_principal
{
    public class DGV_Codes
    {
        Form1 form1;
        Pitch_principal.Peca peca;
        public DGV_Codes(Form1 form1, Pitch_principal.Peca peca)
        { this.form1 = form1;
            this.peca = peca;
        }

        public void RemoverFerramenta(DataGridView dataGridView, BindingList<Ferramentas> lista, DataGridViewCellEventArgs e)
        {
            string delete = "Delete1";
            if(dataGridView.Name == "dataGridView2") { delete = "Delete2"; }

            if (dataGridView.Name == "dataGridView3") { delete = "Delete3"; }
            // Obtenha o objeto selecionado da lista
            Ferramentas ferramentaSelecionada = dataGridView.Rows[e.RowIndex].DataBoundItem as Ferramentas;
            
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView.Columns[delete].Index)
            {
                DialogResult result = MessageBox.Show("削除します、OK?", "Confirmação", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    // Remova o objeto da lista
                    lista.Remove(ferramentaSelecionada);
                    ferramentaSelecionada.Frente = false;

                    // Atualize a exibição da DGV
                    dataGridView.Refresh();
                }
            }
        }
        public void SelecionarFerramenta(DataGridView dataGridView, DataGridViewCellEventArgs e, List<TextBox>textBoxs, List<CheckBox>checkBoxes, List<Panel>panels)
        {
            // Verifique se o usuário clicou em uma célula válida (não em cabeçalhos de coluna ou linhas vazias)
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtenha o objeto selecionado da lista
                Ferramentas ferramentaSelecionada = dataGridView.Rows[e.RowIndex].DataBoundItem as Ferramentas;

                // Preencha os TextBoxes com as propriedades do objeto selecionado
                if (ferramentaSelecionada != null)
                {
                    foreach (TextBox textBox in textBoxs)
                    {
                        //textBoxs[0].Text = ferramentaSelecionada.Nome;
                        
                        //textBoxs[1].Text = ferramentaSelecionada.kei.ToString();
                        //textBoxs[2].Text = ferramentaSelecionada.fukasa.ToString();
                       // textBoxs[3].Text = ferramentaSelecionada.MenF_tam.ToString();
                      //  textBoxs[4].Text = ferramentaSelecionada.MenF_Kei.ToString();
                        //textBoxs[5].Text = ferramentaSelecionada.MenF_Z.ToString();
                        //textBoxs[6].Text = ferramentaSelecionada.MenF_Dan.ToString();
                        //textBoxs[7].Text = ferramentaSelecionada.MenT_tam.ToString();
                        //textBoxs[8].Text = ferramentaSelecionada.MenT_Kei.ToString();
                        //textBoxs[9].Text = ferramentaSelecionada.MenT_Z.ToString();
                        //textBoxs[10].Text = ferramentaSelecionada.MenT_Dan.ToString();

                    }
                    foreach (CheckBox checkbox in checkBoxes)
                    {
                        checkBoxes[0].Checked = ferramentaSelecionada.Frente;
                        checkBoxes[1].Checked = ferramentaSelecionada.Tras;
                      //  checkBoxes[2].Checked = ferramentaSelecionada.Sentan;
                    }
                    //frente.Checked = ferramentaSelecionada.Frente;
                    //tras.Checked = ferramentaSelecionada.Tras;
               
                    foreach(Panel panel in panels)
                    {
                        if(ferramentaSelecionada.Tipo == Tipo_de_Corte.ボーリング孔)
                        {
                            panels[0].Visible = true;
                            //panels[1].Visible = false;
                        }
                    }
                
                }
            }      
        }
        public void AtualizarTextBoxEPainel(Ferramentas ferramentaSelecionada, List<TextBox> textBoxs, List<CheckBox> checkBoxes, List<Panel> panels)
        {
            if (ferramentaSelecionada != null)
            {
                foreach (TextBox textBox in textBoxs)
                {
                    textBoxs[0].Text = ferramentaSelecionada.Nome; //num_pro_text;
                }
                foreach (CheckBox checkbox in checkBoxes)
                {
                    checkBoxes[0].Checked = ferramentaSelecionada.Frente;
                    checkBoxes[1].Checked = ferramentaSelecionada.Tras;
                }
                foreach (Panel panel in panels)
                {
                    panel.Visible = ferramentaSelecionada.Tipo == Tipo_de_Corte.ボーリング孔;
                }
            }
        }
    }
}
