using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
    internal class Mentori : Ferramentas
    {
        public Mentori(Pitch_principal.Peca peca) : base(peca)
        {
            
        }
    }

    public class TiposdeMentori
    {
        string Tool { get; set; }
        float Diametro { get; set; }
        float Profundidade { get; set; }
        int Kaiten { get; set; }
        int Okuri { get; set; }


        public TiposdeMentori(string tool, float diametro, float profundidade, int kaiten, int okuri)
        {
            Tool = tool;
            Diametro = diametro;
            Profundidade = profundidade;
            Kaiten = kaiten;
            Okuri = okuri;
        }

        public static List<TiposdeMentori> LoadMentoriCuter()
        {
            List<TiposdeMentori> listaDeMentori = new List<TiposdeMentori>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "ListadeMentori.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                // reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string tool = parts[0];
                    float diametro = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    float profundidade = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    int kaiten = int.Parse(parts[3]);
                    int okuri = int.Parse(parts[4]);
                    listaDeMentori.Add(new TiposdeMentori(tool, diametro, profundidade, kaiten, okuri));
                }
            }

            return listaDeMentori;
        }

    }
}
