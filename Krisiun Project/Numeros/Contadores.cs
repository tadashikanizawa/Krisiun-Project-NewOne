namespace Krisiun_Project
{
    internal class ToolNumber
    {

        public static int Toolnumber = 0;
        public ToolNumber() { }
        public static string contador()
        {
            string n = Toolnumber.ToString().PadLeft(2, '0');
            Toolnumber++;
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
