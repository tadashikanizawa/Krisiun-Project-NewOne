using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

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
        public StringBuilder comecodoprograma(bool omote, bool ura, bool okk)
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
            if(okk == false) { 
            inicio.AppendLine("G15H1");
            inicio.AppendLine("M369");
            }



            return inicio;
        }
        public StringBuilder inicio_osp(bool kousoki, bool okk, object ferramenta, int num)
        {
            StringBuilder cabeca= new StringBuilder();

         
                int numpro =num;
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
            if(ferramenta is Drills)
            { 
            cabeca.AppendLine("(N00" + numpro1 +  "- T" + toolnum1 + " -" + tipo + "- φ"+ kei1 + ")");
            }
            cabeca.AppendLine("G0Z500.");
            cabeca.AppendLine("T"+toolnum1);
            cabeca.AppendLine(troca);
            cabeca.AppendLine("G0X0.Y0.");
            cabeca.AppendLine("G0G56Z85.H" + toolnum1);
            cabeca.AppendLine(resfriamento);
            cabeca.AppendLine("G17G90G00");
            cabeca.AppendLine("G71Z85.M53");
            cabeca.AppendLine("(INICIO)");
            
            return cabeca;

        
        
        }
        public string GenerateGCodeFrente(Ferramentas ferramentas)
        {
            if(ferramentas.ListFrente.Count == 0)
            {
                //MessageBox.Show("Não há objetos na lista");
                return null;
            }
            StringBuilder gCode56 = new StringBuilder();
            StringBuilder gCode46 = new StringBuilder();

            // Cabeçalho do GCode
            StringBuilder comeco = new StringBuilder();
            comeco = comecodoprograma(true, false, false);
            gCode56.Append(comeco);
            gCode46.Append(comeco);
            int num = 1;
            // Gerar GCode para objetos na ListaMista
            foreach (object ferramenta in ferramentas.ListFrente)
            {
                if (ferramenta is Drills drill)
                {  StringBuilder inicio56 = new StringBuilder();
                    StringBuilder gcodedrill = new StringBuilder();
                    StringBuilder inicio46 = new StringBuilder();
                    inicio56 = inicio_osp(false, false, drill, num);
                    inicio46 = inicio_osp(true, false, drill, num);
                    gcodedrill = GenerateGCodeForDrill(drill,false);
                    gCode56.Append(inicio56);
                    gCode46.Append(inicio46);
                    gCode46.Append(gcodedrill);
                    gCode56.Append(gcodedrill);

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
                num++;
            }

           

            // Rodapé do GCode
            gCode56.AppendLine("M2");
            gCode46.AppendLine("M2");

            SaveStringBuilderToFile(gCode56,gCode46, gCode56, "teste.txt");
            return gCode56.ToString();
        }
        
        private StringBuilder GenerateGCodeForDrill(Drills drill, bool tras)
        {
            StringBuilder gCodeForDrill = new StringBuilder();
            int spindleSpeed = drill.Kaiten;
            float senta = 0f;
            float fukasa = drill.Fukasa;
            double graus = 20;
            bool xinv = peca.xinv;
            bool yinv = peca.yinv;
            if(tras == false) { xinv = false; yinv = false; }
            double radianos = graus * (Math.PI / 180);
            double raio = drill.Kei / 2;
            if (drill.Sentan == true)
            {
                senta = (float)(Math.Tan(radianos) * raio);
                fukasa += senta;
            }
            MessageBox.Show(senta.ToString());
            // Velocidade de rotação
            gCodeForDrill.AppendLine($"S{spindleSpeed} M03");

            // Comando G81
            PointF primeiraCoordenada = drill.CoordenadasList[0];
            float xCoordValuep = xinv ? -primeiraCoordenada.X : primeiraCoordenada.X;

            // Multiplica a coordenada Y por -1 se yinv for verdadeiro
            float yCoordValuep = yinv ? -primeiraCoordenada.Y : primeiraCoordenada.Y;
            string xCoordp = xCoordValuep % 1 == 0 ? $"{xCoordValuep}.":$"{xCoordValuep}";
            string yCoordp = yCoordValuep % 1 == 0 ? $"{yCoordValuep}.":$"{yCoordValuep}";

            gCodeForDrill.AppendLine($"G81X{xCoordp}Y{yCoordp}R5.0Z{fukasa}F{drill.Okuri}");

            // Coordenadas restantes
            for (int i = 1; i < drill.CoordenadasList.Count; i++)
            {// Multiplica a coordenada X por -1 se xinv for verdadeiro
              

                PointF coordenada = drill.CoordenadasList[i];
                float xCoordValue = xinv ? -coordenada.X : coordenada.X;

                // Multiplica a coordenada Y por -1 se yinv for verdadeiro
                float yCoordValue = yinv ? -coordenada.Y : coordenada.Y;
                string xCoord = xCoordValue % 1 == 0 ? $"{xCoordValue}.":$"{xCoordValue}";
                string yCoord = yCoordValue % 1 == 0 ? $"{yCoordValue}.":$"{yCoordValue}";
                gCodeForDrill.AppendLine($"X{xCoord}Y{yCoord}");
            }
            gCodeForDrill.AppendLine("G0Z85.");
            gCodeForDrill.AppendLine("G0Z500.");
            gCodeForDrill.AppendLine("(FIM DO FURADOR)");

            return gCodeForDrill;
        }


        public  void SaveStringBuilderToFile(StringBuilder okuma56, StringBuilder okuma46, StringBuilder OKK76, string nome)
            {
                // Converte o StringBuilder em uma string
                string contentAsString56 = okuma56.ToString();
                string contentAsString46 = okuma46.ToString();
                string contentAsString76 = OKK76.ToString();
            string filePath1 = pastas.CaminhoO56.ToString();
            string filePath2 = pastas.CaminhoO46.ToString();    
            string filePath3 = pastas.CaminhoOKK.ToString();
                string path1 = Path.Combine(filePath1, nome);
            string path2 = Path.Combine(filePath2, nome);

            string path3 = Path.Combine(filePath3, nome);
            // Salva a string em um arquivo .txt
            File.WriteAllText(path1, contentAsString56);
            File.WriteAllText(path2, contentAsString46);
            File.WriteAllText(path3, contentAsString76);
            }
        
    }
}
