using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.G_Code
{
    internal class GCodeGenerator
    {
        public string GenerateGCode(Ferramentas ferramentas)
        {
            StringBuilder gCode = new StringBuilder();

            // Cabeçalho do GCode
            gCode.AppendLine("%");
            gCode.AppendLine("G90 G94 G17 G91.1");

            // Gerar GCode para Drills
            foreach (Drill drill in ferramentas.Drills)
            {
                // Aqui você adiciona o GCode específico para cada objeto Drill.
            }

            // Gerar GCode para Taps
            foreach (Tap tap in ferramentas.Taps)
            {
                // Aqui você adiciona o GCode específico para cada objeto Tap.
            }

            // Gerar GCode para CoordenadaList
            foreach (PointF ponto in ferramentas.CoordenadaList)
            {
                gCode.AppendLine($"G01 X{ponto.X} Y{ponto.Y}");
            }

            // Rodapé do GCode
            gCode.AppendLine("M30");
            gCode.AppendLine("%");

            return gCode.ToString();
        }
    }
}
