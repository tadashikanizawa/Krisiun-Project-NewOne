using Krisiun_Project.G_Code;
using System.Collections.Generic;

namespace Krisiun_Project.Numeros
{
    internal class Listas
    {
        public List<Drills> Brocas { get; set; }
        public List<Ferramentas> Frente { get; set; }
        public List<Ferramentas> Tras { get; set; }

        public Listas()
        {
            Brocas = new List<Drills>();
            Frente = new List<Ferramentas>();
            Tras = new List<Ferramentas>();

        }
    }
}
