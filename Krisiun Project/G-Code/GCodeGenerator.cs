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
        public Ferramentas ferramentas;
        public GCodeGenerator(Ferramentas ferramentas)
        {
            this.ferramentas = ferramentas;
        }

        public StringBuilder inicio_osp(bool oogaka, bool kousoki, bool frente, bool verso , object ferramenta)
        {
            StringBuilder cabeca= new StringBuilder();

         
                int numpro = 1;
                int toolnum = 0;
                 float kei = 0;
            string tipo = null;
            // numero da ferramenta



            //Adicione mais tipos de ferramentas conforme necessário.

            if (ferramenta is Drills drill)
            {
                toolnum = drill.ToolNumber;
                kei = drill.Kei;
                tipo = drill.ToolName;
            }
            else if (ferramenta is Tap tap)
            {
                // Atribua as propriedades do objeto Tap.
            }

            string numpro1 = numpro.ToString().PadLeft(2, '0');
          
            if(oogaka == true) { toolnum = ferramentas.ToolNumber; }
            if(kousoki == true) { toolnum = ferramentas.ToolNumberK; }
            string toolnum1 = toolnum.ToString().PadLeft(2, '0');
            
            //kei
           
            string kei1 = kei.ToString();
            
            //tipo
         
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
