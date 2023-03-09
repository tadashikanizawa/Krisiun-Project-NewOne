using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project
{
    internal class ToolNumber
    {
      
        public int toolnumber;
        public ToolNumber() { this.toolnumber = 01; }
        public string contador()
        { 
            string n = toolnumber.ToString().PadLeft(2,'0');
            return n;
        }
    }
    internal class NumTextBox
    {
        public int num;
        public NumTextBox() { this.num = 1;}
    }

    public class Bools
    {
        public bool bool_lado = true;
        public bool Form2_Frente = true;
        public bool Form3_Tras = false;
        
        public Bools()
        { this.bool_lado = true;
            this.Form2_Frente = true;
            this.Form3_Tras = false;
        }
        public bool dbool_lado() { bool s = this.bool_lado; return s; }
        
        //public void bools_update(bool b) { bool_lado = b;}
    }
    public class Programas
    {
        public int Numeros;
            public Programas() { this.Numeros = 1;} 

    
    }

}
        