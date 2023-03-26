using Krisiun_Project.G_Code;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.Dados_Aleatorios1
{
    public class Material
    {
        public string Name { get; set; }

        public Material(string name)
        {
            Name = name;
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
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "Material.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                 reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string name = parts[0];
                   // float kaitenValue = float.Parse(parts[1], CultureInfo.InvariantCulture);

                    materials.Add(new Material(name));
                }
            }

            return materials;
        }
    }
    
}
