﻿using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.UserControils;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
    public class Tap : Ferramentas
    {
        public string TapNome { get; set; }
        public TiposdeTap Tipo { get; set; }
        public string Unidade { get; set; }
        public float Q { get; set; }
        public float K { get; set; }
        public bool Zpro { get;set; }
        public float TapYama { get; set; }

        public bool BoolMM { get; set;  }
        public bool BoolInch { get; set; }
        public Tap(Pitch_principal.Peca peca): base(peca)
        {

            CoordenadasList = new List<PointF>();
        }





    }
}
