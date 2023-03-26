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
        public int DrillKei { get; set; }
        public string DrillName { get; set; }
        public int DrillNumber { get; set; }
        public Kougu(int drillkei, string drillname, int drillnumber)
        {
            DrillKei = drillkei;
            DrillName = drillname;
            DrillNumber = drillnumber;
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
                // reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    int tool = int.Parse(parts[0], CultureInfo.InvariantCulture);
                    float diametro = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    float profundidade = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    int kaiten = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    int okuri = int.Parse(parts[4], CultureInfo.InvariantCulture);
                    string kataban = parts[5].ToString();
                    int largura = int.Parse(parts[6], CultureInfo.InvariantCulture);
                    float tsukidashi = float.Parse(parts[7], CultureInfo.InvariantCulture);
                    int menCutterToolNum = int.Parse(parts[8], CultureInfo.InvariantCulture);

                    //  MessageBox.Show(tool + "," + diametro.ToString() +"," + profundidade.ToString() + "," + kaiten.ToString() + "," + okuri.ToString() + "," + kataban + "," + largura.ToString() + "," + tsukidashi.ToString() );
                    //listaDeMentori.Add(new TiposdeMentori(tool, diametro, profundidade, kaiten, okuri, kataban, largura, tsukidashi, menCutterToolNum));
                }
                return listaDeKougu;



            }

        }
    }
}
