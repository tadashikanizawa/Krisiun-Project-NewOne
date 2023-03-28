using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project.Dados_Aleatorios1
{
    public class TipoDeDrills

    {
        public string Name { get; set; }
        public float KaitenValue { get; set; }
        public bool Sentan { get; set; }
        public string Resfriamento { get; set; }
        public bool OAIR { get; set; }
        public string Corte { get; set; }
        public static List<TipoDeDrills> ListaDeTiposdeDrills = new List<TipoDeDrills>();

        public TipoDeDrills(string name, float kaitenValue, bool sentan, string resfriamento, bool oair, string corte)
        {
            Name = name;
            KaitenValue = kaitenValue;
            Sentan = sentan;
            Resfriamento = resfriamento;
            OAIR = oair;
            Corte = corte;
        }

        public static void LoadListdeDrills()
        {
            ListaDeTiposdeDrills = LoadDrills();
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
                    string Corte = parts[5];
                    listaDeDrills.Add(new TipoDeDrills(name, kaitenValue, Sentan, Resfriamento, OAIR, Corte));
                }
            }

            return listaDeDrills;
        }
    }
   }
