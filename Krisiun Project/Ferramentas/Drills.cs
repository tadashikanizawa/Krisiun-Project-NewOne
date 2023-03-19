using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;
using Krisiun_Project.Dados_Aleatorios1;
using System.Globalization;
using System.IO;
using static Krisiun_Project.G_Code.TipoDeDrills;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.G_Code
{
    public class Drills : Ferramentas
    {
        public float Z { get; set; }
     
        public string DrillTipo { get; set; }
        public TipoDeDrills TipoDrill {get;set;}
        public Dictionary<DrillMaterialKey, float> KaitenValues{get; set;}

        public bool Sentan { get; set; } 

        public Drills(Peca peca):base (peca)
        {
            CoordenadasList = new List<PointF>();
            KaitenValues = LoadKaitenValuesFromCsv();
  
        }
  

        protected override void UpdateKaitenAndOkuri()
        {
         
            if (!string.IsNullOrEmpty(_toolName) && _kei > 0)
            {// Busque o dicionário de valores de Kaiten para o TipoDrill selecionado

                TipoDeDrills.UpdateKaitenValueBasedOnMaterial(TipoDrill, peca, KaitenValues);
          
                float valorkaiten = TipoDrill.KaitenValue / _kei;
                Kaiten = Convert.ToInt32(valorkaiten);

                float valorokuri = valorkaiten * 0.1f;
                if(valorokuri > 300) { valorokuri = 300; }

                Okuri = Convert.ToInt32(valorokuri);

            }
        }
        public Dictionary<DrillMaterialKey, float> LoadKaitenValuesFromCsv()
        {
            Dictionary<DrillMaterialKey, float> kaitenValues = new Dictionary<DrillMaterialKey, float>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "Drill_Kaiten_Value.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                reader.ReadLine(); // Pula o cabeçalho

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string materialName = parts[0];
                    string drillTypeName = parts[1];
                    float kaitenValue = float.Parse(parts[2]);

                    DrillMaterialKey key = new DrillMaterialKey(drillTypeName, materialName);
                    kaitenValues[key] = kaitenValue;
                }
            }
            return kaitenValues;
        }

    }
    public class TipoDeDrills
 
    {
        public string Name { get; set; }
        public float KaitenValue { get; set; }
        public bool Sentan { get; set; }
        public string Resfriamento { get; set; }
        public bool OAIR { get; set; }

        public TipoDeDrills(string name, float kaitenValue, bool sentan, string resfriamento, bool oair)
        {
            Name = name;
            KaitenValue = kaitenValue;
            Sentan = sentan;
            Resfriamento = resfriamento;
            OAIR = oair;
        }

        public static void UpdateKaitenValueBasedOnMaterial(TipoDeDrills tipodedrill, Peca peca, Dictionary<DrillMaterialKey, float> kaitenValues)
        {
            if (peca == null)
            {
                // Algum objeto não foi inicializado corretamente
                return;
            }
            if (peca.Material != null)
            {
                DrillMaterialKey key = new DrillMaterialKey(tipodedrill.Name, peca.Material.Name);
                if (kaitenValues.TryGetValue(key, out float newKaitenValue))
                {
                    tipodedrill.KaitenValue = newKaitenValue;
                
                }
            }
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TipoDeDrills other = (TipoDeDrills)obj;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static List<TipoDeDrills> LoadDrills()
        {
            List<TipoDeDrills> listaDeDrills = new List<TipoDeDrills>();
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
                    string Resfriamento = parts[3];
                    bool OAIR = bool.Parse(parts[4]);

                    listaDeDrills.Add(new TipoDeDrills(name, kaitenValue, Sentan, Resfriamento, OAIR));
                }
            }

            return listaDeDrills;
        }
      

    }
    public class DrillMaterialKey
    {
        public string DrillTypeName { get; set; }
        public string MaterialName { get; set; }
        public Dictionary<DrillMaterialKey, float> KaitenValues { get; private set; }

        public DrillMaterialKey(string drillTypeName, string materialName)
        {
            DrillTypeName = drillTypeName;
            MaterialName = materialName;
         //   KaitenValues = LoadKaitenValuesFromCsv();
        }

        public override bool Equals(object obj)
        {
            if (obj is DrillMaterialKey other)
            {
                return DrillTypeName == other.DrillTypeName && MaterialName == other.MaterialName;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (DrillTypeName, MaterialName).GetHashCode();
        }



     

    }

}
