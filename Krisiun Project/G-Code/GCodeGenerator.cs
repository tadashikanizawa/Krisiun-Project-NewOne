using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace Krisiun_Project.G_Code
{
    internal class GCodeGenerator
    {
        private Ferramentas ferramentas;
        public GCodeGenerator(Ferramentas ferramentas)
        {
            this.ferramentas = ferramentas;
        }

        public StringBuilder inicio(bool oogaka, bool kousoki, bool frente, bool verso)
        {
            StringBuilder cabeca= new StringBuilder();

         
                int numpro = 1;
            // numero da ferramenta
            string numpro1 = numpro.ToString().PadLeft(2, '0');
            int toolnum = 0;
            if(oogaka == true) { toolnum = ferramentas.ToolNumber; }
            if(kousoki == true) { toolnum = ferramentas.ToolNumberK; }
            string toolnum1 = toolnum.ToString().PadLeft(2, '0');
            
            //kei
            float kei = ferramentas.Kei;
            string kei1 = kei.ToString();
            
            //tipo
            string tipo = ferramentas.ToolName;
            cabeca.AppendLine("N00" + numpro1);
            cabeca.AppendLine("(N00" + numpro1 + ") - T" + toolnum1 + " -" + tipo + "- φ"+ kei1 );
            
            return cabeca;
        
        
        }
        public string GenerateGCode(Ferramentas ferramentas)
        {
            StringBuilder gCode = new StringBuilder();

            // Cabeçalho do GCode
            gCode.AppendLine("%");
            gCode.AppendLine("G90 G94 G17 G91.1");

            // Gerar GCode para objetos na ListaMista
            foreach (object ferramenta in ferramentas.ListFrente)
            {
                if (ferramenta is Drills drill)
                {
                    // Adicione o GCode específico para o objeto Drill.
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
    }
}
