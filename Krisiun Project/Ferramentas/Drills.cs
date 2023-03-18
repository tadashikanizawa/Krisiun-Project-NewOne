using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;
using Krisiun_Project.Dados_Aleatorios1;
using System.Globalization;
using System.IO;

namespace Krisiun_Project.G_Code
{
    public class Drills : Ferramentas
    {
        public float Z { get; set; }
        public string DrillTipo { get; set; }
        public bool Sentan { get; set; } 

        public Drills()
        {
            CoordenadasList = new List<PointF>();


        }
        
        protected override void UpdateKaitenAndOkuri()
        {
            if (!string.IsNullOrEmpty(_toolName) && _kei > 0)
            {// Busque o dicionário de valores de Kaiten para o TipoDrill selecionado

            
                float valorkaiten = 15500 / _kei;
                Kaiten = Convert.ToInt32(valorkaiten);

                float valorokuri = valorkaiten * 0.1f;

                Okuri = Convert.ToInt32(valorokuri);

            }
        }


    }
    public class ListaDeDrills
 
    {
        public string Name { get; set; }
        public float KaitenValue { get; set; }
        public bool Sentan { get; set; }

        public ListaDeDrills(string name, float kaitenValue, bool sentan)
        {
            Name = name;
            KaitenValue = kaitenValue;
            Sentan = sentan;
        }



        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            ListaDeDrills other = (ListaDeDrills)obj;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static List<ListaDeDrills> LoadDrills()
        {
            List<ListaDeDrills> listaDeDrills = new List<ListaDeDrills>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "ListadeDrills.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                // reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                    float kaitenValue = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    bool Sentan = bool.Parse(parts[2]);

                    listaDeDrills.Add(new ListaDeDrills(name, kaitenValue, Sentan));
                }
            }

            return listaDeDrills;
        }
    }
    public enum TipoDrill
    {
        ソリッドドリル, //0
        カムドリル, //1
        イスカルドリル, //2
        ハイスドリル, //3
        センタードリル, //4
        アクアフラット, //5
        NK, //6
    }

}
