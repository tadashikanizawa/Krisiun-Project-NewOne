using Krisiun_Project.Dados_Aleatorios1;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Krisiun_Project.G_Code
{
    public class Tap : Ferramentas
    {
        public string TapNome { get; set; }
        public List<TiposdeTap> TapMM { get; set; }

        public Tap(Pitch_principal.Peca peca): base(peca)
        {
            TapMM = new List<TiposdeTap>();
        }
    

    }
}
