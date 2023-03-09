using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;

namespace Krisiun_Project.G_Code
{
    public class Drills : Ferramentas
    {
        private Programas prog;
        public string DrillTipo { get; set; }
        public float Tool_Cump { get; set; }
        public float Z { get; set; }
        public bool Sentan { get; set; }
        public List<PointF> pointFsD { get; set; }

        public Drills()
        {
            this.prog = new Programas();
            CoordenadasList = new List<PointF>();


        }
        public void adddrill()
        {
            Drills drills = new Drills();
            drills.Nome = "wololo";
            drills.Sentan = true;
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
