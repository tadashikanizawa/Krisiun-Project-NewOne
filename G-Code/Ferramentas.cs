using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.G_Code
{
    public class Ferramentas
      {
        private Programas prog;
        public int Index { get; set; }
        public Tipo_de_Corte Tipo { get; set; }
        public string Nome { get; set; }
        public bool Frente { get; set; }
        public bool Tras { get; set; }
        public bool Lado1 { get; set; }
        public bool Lado2 { get; set; }
        public bool Mentori_F_Bool { get; set; }
        public bool Mentori_B_Bool { get; set; }    
        public Drills drills { get; set; }
        public Tap Taptap { get; set; }
        public BindingList<Ferramentas> ListTotal { get; set; }
        public BindingList<Ferramentas> ListFrente { get; set; }
        public BindingList<Ferramentas> ListTras { get; set; }
        public Ferramentas()
        {
            this.prog = new Programas();
            ListTotal = new BindingList<Ferramentas>();
            ListFrente = new BindingList<Ferramentas>();
            ListTras = new BindingList<Ferramentas>();


        }

        public void addferramenta(bool frente, bool tras)
        {
            string nome = prog.Numeros.ToString().PadLeft(4, '0');
            Ferramentas tool = new Ferramentas();
            tool.Index = prog.Numeros;
            tool.Nome = nome;
            tool.Frente = frente;
            tool.Tras = tras;
            tool.drills = drills;

            ListTotal.Add(tool);

            if (tool.Frente) { ListFrente.Add(tool); }
            if (tool.Tras) { ListTras.Add(tool); }
            prog.Numeros++;

        }
        public void addferramenta1()
        {
            string nome = prog.Numeros.ToString().PadLeft(4, '0');
            Ferramentas tool = new Ferramentas();
            tool.Index = prog.Numeros;
            tool.Nome = nome;
            tool.drills = drills;

            ListTotal.Add(tool);

            // Verifica se a nova ferramenta deve ser adicionada à lista ListFrente
            if (tool.Frente && !ListFrente.Contains(tool))
            {
                ListFrente.Add(tool);
            }

            // Verifica se a nova ferramenta deve ser adicionada à lista ListTras
            if (tool.Tras && !ListTras.Contains(tool))
            {
                ListTras.Add(tool);
            }

            prog.Numeros++;

        }


    }
    public enum Tipo_de_Corte
    {
        ボーリング孔,
        タープ,

    }
}
