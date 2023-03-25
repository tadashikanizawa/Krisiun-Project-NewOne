namespace Krisiun_Project.Numeros
{
    public class Bools
    {
        public bool bool_lado = true;
        public bool Form2_Frente = true;
        public bool Form3_Tras = false;
        public bool Maru;
        public bool Shikaku;
        public Bools()
        {
            this.bool_lado = false;
            this.Form2_Frente = true;
            this.Form3_Tras = false;
            this.Maru = false;
            this.Shikaku = false;
        }
        public bool dbool_lado() { bool s = this.bool_lado; return s; }
    }
}
