using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.G_Code
{
        public class Tap : Ferramentas
        {
            private Programas prog;
            public int Index { get; set; }
            public string NomeTap { get; set; }
            public bool FrenteReal { get; set; }
            public List<Ferramentas> teste;
            public List<Tap> ListTap { get; set; }

            public ObservableCollection<Drills> test { get; set; }

            public ObservableCollection<Tap> test1 { get; set; }
            public Tap()
            {
                this.prog = new Programas();
                ListTap = new List<Tap>();
            }

            public void adddinamica()
            {
                string nome = prog.Numeros.ToString().PadLeft(4, '0');
                Tap tap = new Tap();
                tap.Index = prog.Numeros;
                tap.Nome = nome;
                //    tap.Frente = true;
                ListTap.Add(tap);
                //  if (tap.Frente) { ListFrente.Add(tap); }
                //    else { MessageBox.Show("deu não"); }
                prog.Numeros++;
            }
        }
}
