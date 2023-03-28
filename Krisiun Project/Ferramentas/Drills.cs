using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System;
using Krisiun_Project.Dados_Aleatorios1;
using System.Globalization;
using System.IO;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.G_Code
{
    public class Drills : Ferramentas
    {
        public float Z { get; set; }
     
        public string DrillTipo { get; set; }
        public float TamSentan { get; set; }
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



