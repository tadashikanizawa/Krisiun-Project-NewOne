using Krisiun_Project;
using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Addtextbox
    {
        private Tests _tests;
        private Coordenadas _coordenadas;
        //private Form1 form =new Form1();
        private Pitch_principal.Peca peca;
        public int row = 1;
        const int textBoxWidth = 50;
        const int textBoxHeight = 20;
        const int textBoxSpacing = 5;
        const int panelPadding = 20;
        public int index = 2;
        public List<TextBox> textBoxesx = new List<TextBox>();
        public List<TextBox> textBoxesy = new List<TextBox>();
        public Addtextbox(Tests tests, Coordenadas xy)
        {
            _tests = tests;
            _coordenadas = xy;
            // this.form = new Form1();
        }

        public void CriarTextBoxesIniciais(Panel panel)
        {


            // Cria a primeira coluna de TextBoxes com uma única linha

            var xTextBox = new TextBox();
            xTextBox.Name = "X_1_1";
            xTextBox.Left = panelPadding;
            xTextBox.Top = panelPadding + ((row - 1) * (textBoxHeight + textBoxSpacing));
            xTextBox.Width = textBoxWidth;
            xTextBox.Height = textBoxHeight;


            xTextBox.Leave += (sender, e) => AdicionarNovaLinhaDeTextBoxes(panel);
            xTextBox.TextChanged += TextBoxX_TextChanged;

            xTextBox.TabIndex = 0;
            panel.Controls.Add(xTextBox);
            textBoxesx.Add(xTextBox);
            //  index++;
            var yTextBox = new TextBox();
            yTextBox.Name = "Y_1_1";
            yTextBox.Left = panelPadding + textBoxWidth + textBoxSpacing;
            yTextBox.Top = panelPadding + ((row - 1) * (textBoxHeight + textBoxSpacing));
            yTextBox.Width = textBoxWidth;
            yTextBox.Height = textBoxHeight;
            yTextBox.TextChanged += TextBoxY_TextChanged;
            yTextBox.TabIndex = 1;
            panel.Controls.Add(yTextBox);
            textBoxesy.Add(yTextBox);
        }





        public void AdicionarNovaLinhaDeTextBoxes(Panel panel)
        {

            //MessageBox.Show(row.ToString());
            // Verifica se a última linha está vazia
            var lastXTextBox = panel.Controls.Find("X_" + (row) + "_1", true).FirstOrDefault() as TextBox;
            var lastYTextBox = panel.Controls.Find("Y_" + (row) + "_1", true).FirstOrDefault() as TextBox;

            if (lastXTextBox != null && string.IsNullOrEmpty(lastXTextBox.Text)
                && lastYTextBox != null && string.IsNullOrEmpty(lastYTextBox.Text))
            {
                return;
            }
            row++;
            // float x, y;
            //if (!float.TryParse(lastXTextBox.Text, out x) || !float.TryParse(lastYTextBox.Text, out y))
            //{
            // Se os valores não puderem ser convertidos para float, mostra uma mensagem de erro
            //   MessageBox.Show("Valores inválidos para coordenada.");
            //  return;
            // }
            //var novaCoordenada = new Coordenadas { x = x, y = y };

            // Adiciona a coordenada a uma lista ou dicionário
            //_coordenadas.Pitch.Add(novaCoordenada);
            // Cria uma nova linha de TextBoxes na primeira coluna (X)
            var xTextBox = new TextBox();
            xTextBox.Name = "X_" + row + "_1";
            xTextBox.Left = panelPadding;
            xTextBox.Top = panelPadding + ((row - 1) * (textBoxHeight + textBoxSpacing));
            xTextBox.Width = textBoxWidth;
            xTextBox.Height = textBoxHeight;
            xTextBox.Leave += (sender, e) => AdicionarNovaLinhaDeTextBoxes(panel);
            xTextBox.TextChanged += TextBoxX_TextChanged;

            xTextBox.TabIndex = index++;
            textBoxesx.Add(xTextBox);

            panel.Controls.Add(xTextBox);

            // Cria uma nova linha de TextBoxes na segunda coluna (Y)
            var yTextBox = new TextBox();
            yTextBox.Name = "Y_" + row + "_1";
            yTextBox.Left = panelPadding + textBoxWidth + textBoxSpacing;
            yTextBox.Top = panelPadding + ((row - 1) * (textBoxHeight + textBoxSpacing));
            yTextBox.Width = textBoxWidth;
            yTextBox.Height = textBoxHeight;

            yTextBox.TextChanged += TextBoxY_TextChanged;
            yTextBox.TabIndex = index++;
            panel.Controls.Add(yTextBox);
            textBoxesy.Add(yTextBox);
            if (row == 1)
            {
                xTextBox.Select();
            }
            else
            {
                yTextBox.KeyDown += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Tab)
                    {
                        e.SuppressKeyPress = true;
                        if (yTextBox.TabIndex == (row * 2) + 1)
                        {
                            var nextXTextBox = panel.Controls.Find("X_" + (row + 1) + "_1", true).FirstOrDefault() as TextBox;
                            if (nextXTextBox != null)
                            {
                                nextXTextBox.Select();
                            }
                        }
                        else
                        {
                            var nextYTextBox = panel.Controls.Find("Y_" + row + "_2", true).FirstOrDefault() as TextBox;
                            if (nextYTextBox != null)
                            {
                                nextYTextBox.Select();
                            }
                        }
                    }
                };
            }
        }


        private void TextBoxX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            int index = GetTextBoxIndex(textBox);
   



        }

        private void TextBoxY_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string texte = textBoxesy.Count.ToString();
            //string test2 = "nashinashi";
            this._tests.x = texte;
            //  MessageBox.Show(this.tests.x);
            // Código para lidar com o evento TextChanged da TextBox com nome Y_i
        }
        private int GetTextBoxIndex(TextBox textBox)
        {
            string[] nameParts = textBox.Name.Split('_');

            if (nameParts.Length < 3)
            {
                // O nome da TextBox não está no formato esperado, retornar -1
                return -1;
            }

            int index;
            if (!int.TryParse(nameParts[1], out index))
            {
                // O índice não é um número válido, retornar -1
                return -1;
            }

            return index;
        }



    }

}
