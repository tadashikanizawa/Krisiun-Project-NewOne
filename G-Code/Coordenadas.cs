﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.G_Code
{
    public class Coordenadas
    {
        public float x;
        public float y;
        public List<Coordenadas> Pitch;
        public Coordenadas() { Pitch = new List<Coordenadas>(); }
    }
    
    
}
