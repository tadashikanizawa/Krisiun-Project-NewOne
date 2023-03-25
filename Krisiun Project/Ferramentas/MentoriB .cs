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
    public class MentoriB : Ferramentas
    {

        public TiposdeMentori TipoDeCutter { get; set; }
        public float Z { get; set; }    
        public float Z2 { get; set; }
        public float MenKei { get; set; }
        public float C { get; set; }
        public float Dansa { get; set; }
        public float Diametro { get; set; }
        public float Profundidade { get; set; }
        public int Largura { get;set; }

        
        public MentoriB(Pitch_principal.Peca peca) : base(peca)
        {
            this.peca = peca;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            MentoriB other = (MentoriB)obj;
            
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



 
}
