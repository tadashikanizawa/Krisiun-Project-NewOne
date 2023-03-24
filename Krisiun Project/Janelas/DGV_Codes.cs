using Krisiun_Project.G_Code;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace Krisiun_Project.janela_principal
{
    public class DGV_Codes
    {
        Form1 form1;
        Pitch_principal.Peca peca;
        public DGV_Codes(Form1 form1, Pitch_principal.Peca peca)
        {
            this.form1 = form1;
            this.peca = peca;
        }

        public void RemoverFerramenta(DataGridView dataGridView, BindingList<Ferramentas> lista, DataGridViewCellEventArgs e)
        {
            string delete = "Delete1";
            if (dataGridView.Name == "dataGridView2") { delete = "Delete2"; }

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

        public void SelecionarFerramenta4(DataGridView dataGridView, DataGridViewCellEventArgs e, List<ComboBox> comboBoxes, List<TextBox> textBoxs, List<CheckBox> checkBoxes, List<Panel> panels, DataGridView dgvCoordenadas)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                Ferramentas ferramentaSelecionada = dataGridView.Rows[e.RowIndex].DataBoundItem as Ferramentas;

                if (ferramentaSelecionada != null)
                {
                    if(!(ferramentaSelecionada is Mentori))
                    { 
                    textBoxs[4].Text = ferramentaSelecionada.Mentori.MenKei.ToString();
                    textBoxs[5].Text = ferramentaSelecionada.Mentori.Z.ToString();
                    textBoxs[3].Text = ferramentaSelecionada.Mentori.C.ToString();
                    textBoxs[6].Text = ferramentaSelecionada.Mentori.Dansa.ToString();

                    checkBoxes[3].Checked = ferramentaSelecionada.Mentori_F_Bool;
                    checkBoxes[4].Checked = ferramentaSelecionada.Mentori_B_Bool;
                        TiposdeMentori selectedMentori = (TiposdeMentori)ferramentaSelecionada.Mentori.MentoriCutter;

                        // Encontre o índice do item selecionado na ComboBox.
                        int selectedIndex = comboBoxes[2].Items.IndexOf(selectedMentori);

                        // Defina o SelectedIndex da ComboBox para o índice encontrado.
                        if (selectedIndex != -1)
                        {
                            comboBoxes[2].SelectedIndex = selectedIndex;
                        }

                    }
                    //BindingList<PointF> novaLista = new BindingList<PointF>();
                    if (ferramentaSelecionada is Drills)
                    {
                        Drills drillSelecionado = ferramentaSelecionada as Drills;
                      
                            textBoxs[7].Text = drillSelecionado.ToolNumber.ToString(); //7
                            textBoxs[1].Text = drillSelecionado.Kei.ToString(); //1
                            textBoxs[2].Text = drillSelecionado.Fukasa.ToString(); //2
                            textBoxs[0].Text = drillSelecionado.Description.ToString();
                           
                        
                            comboBoxes[0].Text = drillSelecionado.DrillTipo;
                            comboBoxes[1].SelectedIndex = comboBoxes[1].FindStringExact(drillSelecionado.Color.Name);

                        
                            checkBoxes[0].Checked = drillSelecionado.Frente;
                            checkBoxes[1].Checked = drillSelecionado.Tras;
                            checkBoxes[2].Checked = drillSelecionado.Sentan;
                        

                        // carrega as coordenadas do drill
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {
                            // Obtém o objeto selecionado na DataGridView principal
                            var selectedObject = dataGridView.Rows[e.RowIndex].DataBoundItem as Ferramentas;

                            // Verifica se o objeto selecionado é uma instância de Drills ou Taps
                            if (selectedObject is Drills drills)
                            {
                                // Cria uma BindingList<PointF> com a lista de pontos do objeto selecionado
                                var pointsList = new BindingList<PointF>(drills.CoordenadasList);

                                // Atribui a BindingList<PointF> a DataGridView separada
                                dgvCoordenadas.DataSource = pointsList;
                            }
                            
                            else
                            {
                                // Se o objeto selecionado não tiver uma lista de pontos, limpe a DataGridView separada
                                dgvCoordenadas.DataSource = null;
                            }
                        }
                    }
                    else if (ferramentaSelecionada is Tap)
                    {
                        Tap tapSelecionado = ferramentaSelecionada as Tap;
                        // carrega valores para endmills
                    }

                    // adicione outros casos para outros tipos específicos de ferramentas
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
                // carrega as coordenadas do drill
              
            }
        }
    }
}
