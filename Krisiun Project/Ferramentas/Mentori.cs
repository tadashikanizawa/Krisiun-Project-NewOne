using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Krisiun_Project.G_Code
{
    public class Mentori : Ferramentas
    {

        public TiposdeMentori TipoDeCutter { get; set; }
        public TiposdeMentori TipodeCutterB { get; set; }
        public float Z { get; set; }    
        public float ZB { get; set; }
        public float Z2 { get; set; }
        public float Z2B { get; set; }
        public float MenKei { get; set; }
        public float MenKeiB { get; set; }
        public float C { get; set; }
        public float CB { get; set; }
        public float Dansa { get; set; }
        public float DansaB { get; set; }
        public float Diametro { get; set; }
        public float DiamentroB { get; set; }
        public float Profundidade { get; set; }
        public float ProfundidadeB { get; set; }
        public int Largura { get;set; }
        public int LarguraB { get; set; }

        
        public Mentori(Pitch_principal.Peca peca) : base(peca)
        {
            this.peca = peca;
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


        public static StringBuilder GenerateMentori(float x, float y, float z, float arcDiameter, float toolDiameter, int Okuri, float extraAngle)
        {
            StringBuilder gCode = new StringBuilder();
            double radius = arcDiameter / 2;
            double toolRadius = toolDiameter / 2;
            double effectiveRadius = radius - toolRadius;

            string xinicial = x % 1 == 0 ? $"{x}." : $"{x}";
            string yinicial = y % 1 == 0 ? $"{y}." : $"{y}";
            if(z > 0) { z*= -1; }
            string zinicial = z % 1 == 0 ? $"{z}." : $"{z}";

            double centerX = x;
            double centerY = Math.Round(y - effectiveRadius,3);
            string centerxstring = centerX % 1 == 0 ? $"{centerX}." : $"{centerX}";
            string centerystring = centerY % 1 == 0 ? $"{centerY}." : $"{centerY}";


            double initialAngleRadians = 3 * Math.PI / 2; // 270 graus em radianos
            double initialX = Math.Round(centerX + effectiveRadius * Math.Cos(initialAngleRadians),3);
            double initialY = Math.Round(centerY + effectiveRadius * Math.Sin(initialAngleRadians), 3);

            double valorJ = Math.Round(centerY - initialY,3);
            double valorI = Math.Round(centerX - initialX,3);
            string valorJstring = valorJ % 1 == 0 ? $"{valorJ}." : $"{valorJ}";
            string valorIstring = valorI % 1 == 0 ? $"{valorI}." : $"{valorI}";

            double totalAngle = 360 + extraAngle;
            double totalAngleRadians = (270 + totalAngle) * Math.PI / 180;

            double x2 = x + centerX + effectiveRadius * Math.Cos(totalAngleRadians);
            double y2 = y + centerY + effectiveRadius * Math.Sin(totalAngleRadians);

            double hayaiokuri = centerY + toolRadius + 0.2;
            string hayaiokuristring = hayaiokuri % 1 == 0 ? $"{hayaiokuri}." : $"{hayaiokuri}";

            x2 = Math.Round(x2 / 2,3);
            y2= Math.Round(y2 / 2, 3);

            string x2string = x2 % 1 == 0 ? $"{x2}." : $"{x2}";
            string y2string = y2 % 1 == 0 ? $"{y2}." : $"{y2}";

            gCode.AppendLine($"G0X{xinicial}Y{yinicial}");
             gCode.AppendLine($"G0X{xinicial}Y{yinicial}Z{zinicial}");
            gCode.AppendLine($"G0X{xinicial}Y{hayaiokuristring}");
            gCode.AppendLine($"G01X{centerxstring}Y{centerystring}F100");
            gCode.AppendLine($"G03 X{centerxstring} Y{centerystring} I{valorIstring} J{valorJstring} F{Okuri}");
            gCode.AppendLine($"G03 X{x2string} Y{y2string} I{valorIstring} J{valorJstring} F{Okuri}");
            gCode.AppendLine("G0Z85.");

            return gCode;
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
        public int MenCutterToolNum { get; set; }


        public TiposdeMentori(string tool, float diametro, float profundidade, int kaiten, int okuri, string kataban, int largura, float tsukidashiMax, int menCutterToolNum)
        {
            Tool = tool;
            Diametro = diametro;
            Profundidade = profundidade;
            Kaiten = kaiten;
            Okuri = okuri;
            Kataban = kataban;
            Largura = largura;
            TsukidashiMax = tsukidashiMax;
            MenCutterToolNum = menCutterToolNum;
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
                    int menCutterToolNum = int.Parse(parts[8], CultureInfo.InvariantCulture);

                    //  MessageBox.Show(tool + "," + diametro.ToString() +"," + profundidade.ToString() + "," + kaiten.ToString() + "," + okuri.ToString() + "," + kataban + "," + largura.ToString() + "," + tsukidashi.ToString() );
                    listaDeMentori.Add(new TiposdeMentori(tool, diametro, profundidade, kaiten, okuri, kataban, largura, tsukidashi, menCutterToolNum));
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
