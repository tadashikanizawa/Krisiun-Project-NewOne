namespace Krisiun_Project
{
    internal class ToolNumber
    {

        public int toolnumber;
        public ToolNumber() { this.toolnumber = 01; }
        public string contador()
        {
            string n = toolnumber.ToString().PadLeft(2, '0');
            return n;
        }
    }
    internal class NumTextBox
    {
        public int num;
        public NumTextBox() { this.num = 1; }
    }

    public class Programas
    {
        public int Numeros;
        public Programas() { this.Numeros = 1; }


    }

}
