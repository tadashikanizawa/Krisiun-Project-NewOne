using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Krisiun_Project.G_Code
{
    public class Tap : Ferramentas
    {
        private Programas prog;
        public string TapNome { get; set; }
        public bool FrenteReal { get; set; }
        public List<Ferramentas> teste;
        public List<Tap> ListTap { get; set; }

        public ObservableCollection<Drills> test { get; set; }

        public ObservableCollection<Tap> test1 { get; set; }
        public Tap(Pitch_principal.Peca peca): base(peca)
        {
            this.prog = new Programas();
            ListTap = new List<Tap>();
        }
    

    }
}
