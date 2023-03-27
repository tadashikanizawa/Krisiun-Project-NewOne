using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Krisiun_Project.G_Code
{
    public class Tap : Ferramentas
    {
        public string TapNome { get; set; }
        public List<Tap> ListTap { get; set; }

        public Tap(Pitch_principal.Peca peca): base(peca)
        {
            ListTap = new List<Tap>();
        }
    

    }
}
