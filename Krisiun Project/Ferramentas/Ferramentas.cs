using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Krisiun_Project.G_Code
{
    public class Ferramentas
    {
        private Programas prog;
        public int Index { get; set; } //0
        public string Nome { get; set; }
        public Tipo_de_Corte Tipo { get; set; } //1
        public int ToolNumber { get; set; } //2
        public int ToolNumberK { get; set;}
        public string ToolName { get; set; } //3
        public float Kei { get; set; } //4
        public float Fukasa { get; set; }
        public bool Frente { get; set; }
        public bool Tras { get; set; }
        public bool Lado1 { get; set; }
        public bool Lado2 { get; set; }
        public bool Mentori_F_Bool { get; set; }
        public bool Mentori_B_Bool { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }
        //public Coordenadas Coordenadas { get; set; }
        public PointF CoordenadasP { get; set; }
        public List<PointF> CoordenadasList { get; set; }
        public BindingList<Ferramentas> ListTotal { get; set; }
        public BindingList<Ferramentas> ListFrente { get; set; }
        public BindingList<Ferramentas> ListTras { get; set; }
        public BindingList<Drills> ListDrills { get; set; }
        private Dictionary<int, Coordenadas> coordenadas = new Dictionary<int, Coordenadas>();
        public int numlado { get;set; }

        public Ferramentas()
        {
            this.prog = new Programas();
            ListTotal = new BindingList<Ferramentas>();
            ListFrente = new BindingList<Ferramentas>();
            ListTras = new BindingList<Ferramentas>();
            ListDrills = new BindingList<Drills>();
            numlado = 0; 
           // XYList = new List<PointF>();

        
        }

        public void addtoolnumberK()
        {
            if (ListFrente.Count != 0)
            { 
            {
                for (int i = 0; i < ListFrente.Count; i++)
                {
                    // Aqui você pode definir o valor da propriedade com base na posição do objeto
                    // Neste exemplo, estamos atribuindo o índice do objeto (posição) como o novo valor de ToolNumberK
                    ListFrente[i].ToolNumberK = i + 1;
                }
            }
            }
            if (ListTras.Count != 0)
            { 
            {
                for (int i = 0; i < ListTras.Count; i++)
                {
                    // Aqui você pode definir o valor da propriedade com base na posição do objeto
                    // Neste exemplo, estamos atribuindo o índice do objeto (posição) como o novo valor de ToolNumberK
                    ListTras[i].ToolNumberK = i + 1;
                }

            }
            }
        }

        public void AddCoordenadas(int index, Coordenadas coordenadas)
        {
            this.coordenadas[index] = coordenadas;
        }

        public void RemoveCoordenadas(int index)
        {
            this.coordenadas.Remove(index);
        }

        public Coordenadas GetCoordenadas(int index)
        {
            return this.coordenadas[index];
        }



        #region adicionador velho
    
        public void addferramenta1(Tipo_de_Corte tipo_De_Corte, DataGridView dgvCoordenadas)
        {

            if (tipo_De_Corte == Tipo_de_Corte.ボーリング孔)
            { //tool.Nome = tipo_De_Corte.ToString() + "φ" + tool.kei.ToString(); }
                Drills tool = new Drills();
                tool.Index = prog.Numeros;
                tool.Tipo = tipo_De_Corte;
                tool.Kei = 1;
                tool.Color = Color.LightGray;
                ListDrills.Add(tool);
                tool.CoordenadasList = new List<PointF>();

                // Preenche a lista de coordenadas do objeto com os valores das células do DataGridView
                foreach (DataGridViewRow row in dgvCoordenadas.Rows)
                {
                    float x, y;
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null && float.TryParse(row.Cells[0].Value.ToString(), out x) && float.TryParse(row.Cells[1].Value.ToString(), out y))
                    {
                        PointF coordenadas = new PointF(x, y);
                        tool.CoordenadasList.Add(coordenadas);
                    }
                }


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

        #endregion




    }
    public enum Tipo_de_Corte
    {
        ボーリング孔,
        タープ,

    }
}
