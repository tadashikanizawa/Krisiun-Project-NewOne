using System.Collections.Generic;
using System.Drawing;

namespace Krisiun_Project.G_Code
{
    internal class Grupos
    {
        public List<Grupos> Lista { get; set; }
        public List<PointF> Points { get; set; }
        public int Numero { get; set; }
        public string Nome;
        public bool Frente;
        public bool Tras;
        public bool Broca;
        public bool Tap;
        public bool Naikei;
        public bool Kijun;
        public Color Color;

        public Dictionary<string, Grupos> grupdict = new Dictionary<string, Grupos>();
        public Grupos()
        {
            Lista = new List<Grupos>();
            grupdict = new Dictionary<string, Grupos>();
        }
        public int num = 0;
        public void adddinamica()

        {
            string nome = num.ToString().PadLeft(4, '0');
            Grupos grupo = new Grupos();
            grupo.Numero = num;
            grupo.Nome = nome;

            grupdict.Add(nome, grupo);
            Lista.Add(grupo);
            num++;
        }

    }
}
