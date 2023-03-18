using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.Dados_Aleatorios1
{
    internal class Material
    {
        public string Name { get; set; }
        public float KaitenValue { get; set; }

        public Material(string name, float kaitenValue)
        {
            Name = name;
            KaitenValue = kaitenValue;
        }



        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Material other = (Material)obj;
            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public static List<Material> LoadMaterialsFromFile()
        {
            List<Material> materials = new List<Material>();
            string filePath = "";
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

                    materials.Add(new Material(name, kaitenValue));
                }
            }

            return materials;
        }
    }
    public enum MaterialEnum
    {
        SKD11,
        S50C,
        // Outros materiais
    }

}
