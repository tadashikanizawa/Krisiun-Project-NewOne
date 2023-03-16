using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.janela_principal
{
    internal class Bugs
    {
        public class Bugs_Txb
            {
            public void sohnums(object sender, EventArgs e)
            {
                TextBox textBox = (TextBox)sender;
                string text = textBox.Text;
                string validChars = "-.,0123456789"; // caracteres válidos
                string newText = string.Concat(text.Where(c => validChars.Contains(c))); // remove os caracteres inválidos
                if (text != newText)
                {
                    int selectionStart = textBox.SelectionStart - (text.Length - newText.Length); // corrige a posição do cursor
                    textBox.Text = newText;
                    textBox.SelectionStart = selectionStart; // reposiciona o cursor
                }
                else
                {
                    if (float.TryParse(newText, out var value))
                    {
                        // fazer algo com o valor
                    }
                    else
                    {
                        // o valor não é um número válido
                    }
                }
            }

        }
    }
}
