using CsvHelper.Configuration;
using CsvHelper;
using Krisiun_Project.Dados_aleatorios;
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
    public class Kougu
    {
        public float DrillKei { get; set; }
        public string DrillName { get; set; }
        public int DrillNumber { get; set; }
        public static List<Kougu> ListadeKougu { get; set; } = new List<Kougu>();
        public Kougu(float drillkei, string drillname, int drillnumber)
        {
            DrillKei = drillkei;
            DrillName = drillname;
            DrillNumber = drillnumber;
        }
        public static void CarregarListadeKougu()
        {
            ListadeKougu = LoadKouguList();
        }
        public static List<Kougu> LoadKouguList()
        {
            List<Kougu> listaDeKougu = new List<Kougu>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "Kougu.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    float kei = float.Parse(parts[0], CultureInfo.InvariantCulture);
                    string nome = parts[1].ToString();
                    int toolnum = int.Parse(parts[2], CultureInfo.InvariantCulture);
                    listaDeKougu.Add(new Kougu(kei, nome, toolnum));

                }
                return listaDeKougu;



            }

        }
    }
}
