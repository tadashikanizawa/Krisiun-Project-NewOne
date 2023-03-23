using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Krisiun_Project.G_Code
{
    public class Mentori : Ferramentas
    {

        public TiposdeMentori TipoDeCutter { get; set; }
        public Ferramentas Lugar { get; set; }
        public float Z { get; set; }    
        public float Kei { get; set; }  
        public float C { get; set; }
        public float Dansa { get; set; }
        public float Diametro { get; set; }
        public float Profundidade { get; set; }
        public int Largura { get;set; }

        public List<Ferramentas> MenFrente { get; set; }
        public List<Ferramentas> MenTras { get;set; }
        
        public Mentori(Pitch_principal.Peca peca) : base(peca)
        {
            MenFrente = new List<Ferramentas> { };
            MenTras = new List<Ferramentas> { };
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Mentori other = (Mentori)obj;
            return ToolName == other.ToolName && TipoDeCutter.Equals(other.TipoDeCutter);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + (ToolName?.GetHashCode() ?? 0);
            hash = hash * 23 + (TipoDeCutter?.GetHashCode() ?? 0);
            return hash;
        }
        public static string GenerateGCode(double x, double y, double arcDiameter, double toolDiameter, double extraAngle)
        {
            double radius = arcDiameter / 2;
            double toolRadius = toolDiameter / 2;
            double effectiveRadius = radius - toolRadius;

            double centerX = x;
            double centerY = y - effectiveRadius;

            double initialAngleRadians = 3 * Math.PI / 2; // 270 graus em radianos
            double initialX = centerX + effectiveRadius * Math.Cos(initialAngleRadians);
            double initialY = centerY + effectiveRadius * Math.Sin(initialAngleRadians);

            double totalAngle = 360 + extraAngle;
            double totalAngleRadians = (270 + totalAngle) * Math.PI / 180;

            double x2 = centerX + effectiveRadius * Math.Cos(totalAngleRadians);
            double y2 = centerY + effectiveRadius * Math.Sin(totalAngleRadians);

            string gCode = $"G01 X{initialX} Y{initialY} F100\n";
            gCode += $"G03 X{initialX} Y{initialY} I{centerX - initialX} J{centerY - initialY} F100\n";
            gCode += $"G03 X{x2} Y{y2} I{centerX - initialX} J{centerY - initialY} F100";

            return gCode;
        }
    }
}


    public class TiposdeMentori
    {
        public string Tool { get; set; }
        public float Diametro { get; set; }
        public float Profundidade { get; set; }
        public int Kaiten { get; set; }
        public int Okuri { get; set; }
        public string Kataban { get;set; }
        public int Largura { get; set; }
        public float TsukidashiMax { get; set; }


        public TiposdeMentori(string tool, float diametro, float profundidade, int kaiten, int okuri, string kataban, int largura, float tsukidashiMax)
        {
            Tool = tool;
            Diametro = diametro;
            Profundidade = profundidade;
            Kaiten = kaiten;
            Okuri = okuri;
            Kataban = kataban;
            Largura = largura;
            TsukidashiMax = tsukidashiMax;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TiposdeMentori other = (TiposdeMentori)obj;
            return Tool.Equals(other.Tool);
        }

        public override int GetHashCode()
        {
            return Tool.GetHashCode();
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

                    string tool = parts[0].ToString();
                    float diametro = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    float profundidade = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    int kaiten = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    int okuri = int.Parse(parts[4], CultureInfo.InvariantCulture);
                    string kataban = parts[5].ToString();
                    int largura = int.Parse(parts[6], CultureInfo.InvariantCulture);
                    float tsukidashi = float.Parse(parts[7], CultureInfo.InvariantCulture);

                    //  MessageBox.Show(tool + "," + diametro.ToString() +"," + profundidade.ToString() + "," + kaiten.ToString() + "," + okuri.ToString() + "," + kataban + "," + largura.ToString() + "," + tsukidashi.ToString() );
                    listaDeMentori.Add(new TiposdeMentori(tool, diametro, profundidade, kaiten, okuri, kataban, largura, tsukidashi));
                }

            }

            //MessageBox.Show($"Número de elementos na listaDeMentori: {listaDeMentori.Count}");
            //for (int i = 0; i < listaDeMentori.Count; i++)
            //{ 
            //MessageBox.Show(listaDeMentori[i].Tool + "," + listaDeMentori[i].Diametro.ToString() + "," + listaDeMentori[i].Profundidade.ToString() + "," + listaDeMentori[i].Kaiten.ToString() + "," + listaDeMentori[i].Okuri.ToString() + "," + listaDeMentori[i].Kataban + "," + listaDeMentori[i].Largura.ToString() + "," + listaDeMentori[i].TsukidashiMax.ToString());
            //}
            return listaDeMentori;
        }

    }
}
