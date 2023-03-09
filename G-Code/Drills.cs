using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Krisiun_Project.Numeros;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.G_Code
{
        public class Drills: Ferramentas
    {
        private Programas prog;
        public List<Drills> ListDrills { get; set; }
        public ObservableCollection<Drills> test { get; set; }
        public int Index { get; set; }
        public TipoDrill Tipo { get; set; }
        public List<PointF>Pitch{ get; set; }
        public float Diametro { get; set; }
        public float Tool_Cump { get; set; }
        public float Z { get; set; }
        public bool sentan { get; set; }
   
        public string Resfriamento { get;set ; }
        public Color Color { get; set; }

        public Drills()
            { Pitch = new List<PointF> { };
            this.prog = new Programas();
            ListDrills= new List<Drills>();
        }

        public void Ferramenta(int numero, TipoDrill tipo, float diametro, float comprimento)
        {
            Index = numero;
            Tipo = tipo;
            Diametro = diametro;
            Tool_Cump = comprimento;

        }
        public void adddinamica()
        {
            string nome = prog.Numeros.ToString().PadLeft(4, '0');
            Drills drill = new Drills();
            drill.Index = prog.Numeros;
            drill.Nome = nome;
            drill.Frente = true;
            ListDrills.Add(drill);
            
            if (drill.Frente) { ListFrente.Add(drill); }
            else { MessageBox.Show("deu não"); }
           prog.Numeros++;
        }
    }

   
    public enum TipoDrill
    {
        ソリッドドリル,
        カムドリル,
        イスカルドリル,
        ハイスドリル,
        センタードリル,
        アクアフラット,
        NK,
    }

}
