using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Krisiun_Project.G_Code
{
    public class GCodeGenerator
       
    {
        public Ferramentas ferramentas;
        public Pastas pastas;
        public Pitch_principal.Peca peca;
        public GCodeGenerator(Ferramentas ferramentas, Pastas pastas, Pitch_principal.Peca peca)
        {
            this.ferramentas = ferramentas;
            this.pastas = pastas;
            this.peca = peca;
        }
        public StringBuilder comecodoprograma(bool omote, bool ura)
        {
            string zuban = peca.zuban;
            string hinmen = peca.hinmei;
            string lado = "";
            int num = 1;

            if(omote == true) { lado = "- 表 / OMOTE"; num = peca.omote; }
            if(ura == true) { lado = "- 裏 / URA"; num = peca.ura; }
            StringBuilder inicio = new StringBuilder();
            inicio.AppendLine("01");
            inicio.AppendLine("(" + hinmen + "/" + zuban + ")");
            inicio.AppendLine(num.ToString().PadLeft(2,'0') + lado);
            inicio.AppendLine("G0Z500.");
            inicio.AppendLine("G15H1");
            inicio.AppendLine("M369");

            return inicio;
        }
        public StringBuilder inicio_osp(bool kousoki, object ferramenta)
        {
            StringBuilder cabeca= new StringBuilder();

         
                int numpro = 1;
                int toolnum = 0;
                 float kei = 0;
            string tipo = null;
            string troca = "M06";
            string resfriamento = "M08";
            // numero da ferramenta



            //Adicione mais tipos de ferramentas conforme necessário.

            if (ferramenta is Drills drill)
            {
                toolnum = drill.ToolNumber;
                if (kousoki == true) { toolnum = drill.ToolNumberK; troca = "M207"; }
                kei = drill.Kei;
                tipo = drill.ToolName;
                resfriamento = drill.Resfriamento;
            }
            else if (ferramenta is Tap tap)
            {
                // Atribua as propriedades do objeto Tap.
            }

            string numpro1 = numpro.ToString().PadLeft(2, '0');        
            string toolnum1 = toolnum.ToString().PadLeft(2, '0');
            string kei1 = kei.ToString();
            
            //tipo
         
            cabeca.AppendLine("N00" + numpro1);
            cabeca.AppendLine("(N00" + numpro1 + ") - T" + toolnum1 + " -" + tipo + "- φ"+ kei1 );
            cabeca.AppendLine("G0Z500.");
            cabeca.AppendLine("T"+toolnum1);
            cabeca.AppendLine(troca);
            cabeca.AppendLine("G0X0.Y0.");
            cabeca.AppendLine("G0G56Z85.H" + toolnum1);
            cabeca.AppendLine(resfriamento);
            cabeca.AppendLine("(INICIO)");
            
            //SaveStringBuilderToFile(pastas.CaminhoO56, cabeca);
            return cabeca;

        
        
        }
        public string GenerateGCode(Ferramentas ferramentas)
        {
            StringBuilder gCode = new StringBuilder();

            // Cabeçalho do GCode
            StringBuilder comeco = new StringBuilder();
            comeco = comecodoprograma(true, false);
            gCode.Append(comeco);
            gCode.AppendLine("G90 G94 G17 G91.1");

            // Gerar GCode para objetos na ListaMista
            foreach (object ferramenta in ferramentas.ListFrente)
            {
                if (ferramenta is Drills drill)
                {
                    inicio_osp(false, drill); // Adicione o GCode específico para o objeto Drill.
                }
                else if (ferramenta is Tap tap)
                {
                    // Adicione o GCode específico para o objeto Tap.
                }
                //else if (ferramenta is Endmill endmill)
                //{
                //    // Adicione o GCode específico para o objeto Endmill.
                //}
                // Adicione mais tipos de ferramentas conforme necessário.
            }

           

            // Rodapé do GCode
            gCode.AppendLine("M30");
            gCode.AppendLine("%");

            return gCode.ToString();
        }

        private StringBuilder GenerateGCodeForDrill(Drills drill)
        {
            StringBuilder gCodeForDrill = new StringBuilder();

            // Velocidade de rotação
            int spindleSpeed = 1000;
            gCodeForDrill.AppendLine($"S{spindleSpeed} M03");

            // Comando G81
            PointF primeiraCoordenada = drill.CoordenadasList[0];
            float fukasa = drill.Fukasa;
            gCodeForDrill.AppendLine($"G81 X{primeiraCoordenada.X} Y{primeiraCoordenada.Y} R5.0 Z{fukasa}");

            // Coordenadas restantes
            for (int i = 1; i < drill.CoordenadasList.Count; i++)
            {
                PointF coordenada = drill.CoordenadasList[i];
                string xCoord = coordenada.X % 1 == 0 ? $"{coordenada.X}." : $"{coordenada.X}";
                string yCoord = coordenada.Y % 1 == 0 ? $"{coordenada.Y}." : $"{coordenada.Y}";
                gCodeForDrill.AppendLine($"X{xCoord} Y{yCoord}");
            }
            gCodeForDrill.AppendLine("G0Z85.");
            gCodeForDrill.AppendLine("G0Z500.");

            return gCodeForDrill;
        }


        public static void SaveStringBuilderToFile(string filePath, StringBuilder content)
            {
                // Converte o StringBuilder em uma string
                string contentAsString = content.ToString();

                // Salva a string em um arquivo .txt
                File.WriteAllText(Path.Combine(filePath, "teste.txt"), contentAsString);
            }
        
    }
}
