using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.ComponentModel;

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
        public string GenerateGCode(BindingList<Ferramentas> ferramentasList, Ferramentas ferramentas, bool omote, bool ura)
        {
            if (ferramentasList.Count == 0)
            {
                //MessageBox.Show("Não há objetos na lista");
                return null;
            }
            StringBuilder gCode56 = new StringBuilder();
            StringBuilder gCode46 = new StringBuilder();
            StringBuilder gcodeokk = new StringBuilder();
            StringBuilder gCode56F = new StringBuilder();
            StringBuilder gCode46F = new StringBuilder();
            StringBuilder gCodeokkF = new StringBuilder();

            // Cabeçalho do GCode
            StringBuilder comeco = new StringBuilder();
            StringBuilder comecookk = new StringBuilder();
            StringBuilder comecoF = new StringBuilder();
            StringBuilder comecoF2 = new StringBuilder();
            comeco = comecodoprograma(omote, ura, false, false, ferramentas);
            comecookk = comecodoprograma(omote, ura, true, false, ferramentas);
            comecoF = comecodoprograma(omote, ura, false, true, ferramentas);
            gCode56.Append(comeco);
            gCode46.Append(comeco);
            gcodeokk.Append(comecookk);
            gCode56F.Append(comecoF);
            gCode46F.Append(comecoF);
            gCodeokkF.Append(comecoF);
            int num = 1;
            // Gerar GCode para objetos na ListaMista
            foreach (object ferramenta in ferramentasList)
            {
                if (ferramenta is Drills drill)
                {
                     //Kanizawa Style
                    gCode56.Append(inicio_osp(false, false, drill, num, false));
                    gCode46.Append(inicio_osp(true, false, drill, num, false));
                    gcodeokk.Append(inicio_osp(false, true, drill, num, false));
                    gCode56F.Append(inicio_osp(false, false, drill, num, true));
                    gCode46F.Append(inicio_osp(true, false, drill, num, true));
                    gCodeokkF.Append(inicio_osp(false, true, drill, num, true));

                    gCode46.Append(GenerateGCodeForDrill(drill, omote, ura, false, false));
                    gCode56.Append(GenerateGCodeForDrill(drill, omote, ura, false, false));
                    gcodeokk.Append(GenerateGCodeForDrill(drill, omote, ura, true, false));
                    gCode46F.Append(GenerateGCodeForDrill(drill,omote, ura, false, true));
                    gCode56F.Append(GenerateGCodeForDrill(drill,omote, ura, false, true));
                    gCodeokkF.Append(GenerateGCodeForDrill(drill,omote, ura, true, true));
                   // gCode56.Append(GenerateGElipse(-26.752, 87.502,12,500,22,22));
                }
                else if (ferramenta is Tap tap)
                {
                    // Adicione o GCode específico para o objeto Tap.
                }
                else if( ferramenta is Mentori mentori)
                {
                    gCode56.Append(inicio_osp(false, false, mentori, num, false));
                    gCode46.Append(inicio_osp(true, false, mentori, num, false));
                    gcodeokk.Append(inicio_osp(false, true, mentori, num, false));
                    gCode56F.Append(inicio_osp(false, false, mentori, num, true));
                    gCode46F.Append(inicio_osp(true, false, mentori, num, true));
                    gCodeokkF.Append(inicio_osp(false, true, mentori, num, true));
                    
                    foreach (Ferramentas ferramentas1 in ferramentasList)
                    {   
                        if (omote==true)
                        {
                            if (ferramentas1.Mentori_F_Bool == true)
                            {
                                if (ferramentas1.Mentori.TipoDeCutter == mentori.TipoDeCutter)
                                {

                                    gCode56.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, false, false));
                                    gCode46.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, false, false));
                                    gcodeokk.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, true, true));
                                    gCode56F.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, true, true));
                                    gCode46F.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, true, true));
                                    gCodeokkF.Append(GcodeMentori(mentori, null, ferramentas1, omote, ura, true, true));
                                }

                            }
                        }
                        

                    }
                }
                else if (ferramenta is MentoriB mentorib)
                {
                    gCode56.Append(inicio_osp(false, false, mentorib, num, false));
                    gCode46.Append(inicio_osp(true, false, mentorib, num, false));
                    gcodeokk.Append(inicio_osp(false, true, mentorib, num, false));
                    gCode56F.Append(inicio_osp(false, false, mentorib, num, true));
                    gCode46F.Append(inicio_osp(true, false, mentorib, num, true));
                    gCodeokkF.Append(inicio_osp(false, true, mentorib, num, true));

                    foreach (Ferramentas ferramentas2 in ferramentasList)
                    {
                        if (ura == true)
                        {
                            if (ferramentas2.Mentori_B_Bool == true)
                            {
                                if (ferramentas2.MentoriB.TipoDeCutter == mentorib.TipoDeCutter)
                                {

                                    gCode56.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, false, false));
                                    gCode46.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, false, false));
                                    gcodeokk.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, true, false));
                                    gCode56F.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, false, true));
                                    gCode46F.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, false, true));
                                    gCodeokkF.Append(GcodeMentori(null, mentorib, ferramentas2, omote, ura, true, true));
                                }

                            }
                        }

                    }
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
            gcodeokk.AppendLine("M2");
            gCode46.Append(final());
            gCode56.Append(final());
            gCode46F.Append(final());
            gCode56F.Append(final());
            string nome = "herbocinetica";
            if (omote == true) { nome += "frente.txt"; }
            if (ura == true) { nome += "tras.txt"; }
            SaveStringBuilderToFile(gCode56, gCode46, gcodeokk,gCode56F,gCode46F,gCodeokkF, nome);
            return gCode56.ToString();
        }
        public StringBuilder comecodoprograma(bool omote, bool ura, bool okk, bool Kanizawa, Ferramentas ferramentas)
        {
            string zuban = peca.zuban;
            string hinmen = peca.hinmei;
            string lado = "";
            int num = 1;
            int numpro = 1;
            
            if(omote == true) {lado = "- 表 / OMOTE"; num = peca.omote; }
            if(ura == true) { lado = "- 裏 / URA"; num = peca.ura; }
            StringBuilder inicio = new StringBuilder();
            inicio.AppendLine("01");
            if(okk == true)
            {
                inicio.AppendLine("#600=54");
            }
            inicio.AppendLine("(" + hinmen + "/" + zuban + ")");
            inicio.AppendLine("("+ num.ToString().PadLeft(2,'0') + lado + ")");

            if (okk == false && Kanizawa == false)
            {
            inicio.AppendLine("G0Z500.");
            inicio.AppendLine("G15H1");
            inicio.AppendLine("M369");
            }
            if(okk == true)
            {
                inicio.AppendLine("G90G#600");
                inicio.AppendLine("M05");
                inicio.AppendLine("G91G28Z0");
            }

            if(Kanizawa == true)
            {
                if (omote == true)
                {
                    foreach (object ferramenta in ferramentas.ListFrente)
                    {
                        if(ferramenta is Drills drill)
                        {
                            inicio.AppendLine("CALL ON" + numpro.ToString().PadLeft(2, '0') + " PH=1 ("+drill.Nome + ")");
                        }


                        numpro++;
                    }
                }
                if (ura == true)
                {
                    foreach (object ferramenta in ferramentas.ListTras)
                    {
                        if (ferramenta is Drills drill)
                        {
                            inicio.AppendLine("CALL ON" + numpro.ToString().PadLeft(2, '0') + " PH=1 (" + drill.Nome + ")");
                        }


                        numpro++;
                    }
                }
                inicio.AppendLine("M2");
            }

            return inicio;
        }
        public StringBuilder inicio_osp(bool kousoki, bool okk, object ferramenta, int num, bool Kanizawa)
        {
            StringBuilder cabeca = new StringBuilder();


            int numpro = num;
            int toolnum = 0;
            float kei = 0;
            string tipo = null;
            string troca = "M06";
            string resfriamento = "M08";
            int kaiten = 0;
            // numero da ferramenta



            //Adicione mais tipos de ferramentas conforme necessário.

            if (ferramenta is Drills drill)
            {
                toolnum = drill.ToolNumber;
                if (kousoki == true) { toolnum = drill.ToolNumberK; troca = "M207"; }
                kei = drill.Kei;
                tipo = drill.ToolName;
                resfriamento = drill.Resfriamento;
                kaiten = drill.Kaiten;
            }
            else if (ferramenta is Tap tap)
            {
                // Atribua as propriedades do objeto Tap.
            }
            else if (ferramenta is Mentori mentori)
            {
                toolnum = mentori.ToolNumber;
                if (kousoki == true) { toolnum = mentori.ToolNumberK; troca = "M207"; }
                kei = mentori.Kei;
                tipo = mentori.ToolName.Replace("(","-").Replace(")","-");
                resfriamento = "M08";
                kaiten = mentori.Kaiten;

            }

            string numpro1 = numpro.ToString().PadLeft(2, '0');
            string toolnum1 = toolnum.ToString().PadLeft(2, '0');
            string kei1 = kei.ToString();
            if (okk == true)
            {
                if (resfriamento == "M51") { resfriamento = "M58G04X3."; }
            }
            //tipo
            if (Kanizawa == true)
            {
                cabeca.AppendLine("/");
                cabeca.AppendLine("ON" + numpro1);
                cabeca.AppendLine("G15H=PH");
            }
            cabeca.AppendLine("N00" + numpro1);
            if (okk == true)
            {
                cabeca.AppendLine("G90G#600");
            }
            if (ferramenta is Drills || ferramenta is Mentori) 
            {
                cabeca.AppendLine("(N00" + numpro1 + "- T" + toolnum1 + " -" + tipo + "- φ" + kei1 + ")");
            }
      
            cabeca.AppendLine("G0Z500.");
            cabeca.AppendLine("T" + toolnum1);
            cabeca.AppendLine(troca);
            cabeca.AppendLine("G0X0.Y0.");
            if (okk == true)
            {
                cabeca.AppendLine("G0G43Z85.H" + toolnum1);
            }
            else { 
                  cabeca.AppendLine("G0G56Z85.H" + toolnum1);
                 }
            cabeca.AppendLine(resfriamento);
            cabeca.AppendLine("G17G90G00");
            cabeca.AppendLine("G71Z85.M53");
            cabeca.AppendLine("(INICIO)");
            cabeca.AppendLine("S"+kaiten.ToString() + "M03");
            
            return cabeca;

        
        
        }
       
      
        private StringBuilder GenerateGCodeForDrill(Drills drill, bool frente, bool tras, bool okk, bool Kanizawa)
        {
            StringBuilder gCodeForDrill = new StringBuilder();
            int spindleSpeed = drill.Kaiten;
            string corte = drill.TipoDrill.Corte;
            string restodoprimeiro = "";
            if(corte == "G81") { restodoprimeiro = "R5.0Z"; }
            else if(corte == "G86") { restodoprimeiro = "P1.R5.0Z"; }
            else if(corte == "G83") { restodoprimeiro = "Q1.K2.R.5Z"; }
            float senta = 0f;
            float fukasa = drill.Fukasa;
            if (fukasa < 0) { fukasa *= -1; }
            double graus = 20;
            bool xinv = peca.xinv;
            bool yinv = peca.yinv;
            if(tras == false) { xinv = false; yinv = false; }
            double radianos = graus * (Math.PI / 180);
            double raio = drill.Kei / 2;
            
            if (drill.Sentan == true)
            {
                senta = (float)(Math.Tan(radianos) * raio);
                fukasa += (float)Math.Round(senta,3);
                drill.TamSentan = senta;
                drill.Z = fukasa;
                
            }
            if (fukasa > 0) { fukasa *= -1; }
            // Velocidade de rotação
            
            // Comando G81
            PointF primeiraCoordenada = drill.CoordenadasList[0];
            float xCoordValuep = xinv ? -primeiraCoordenada.X : primeiraCoordenada.X;

            // Multiplica a coordenada Y por -1 se yinv for verdadeiro
            float yCoordValuep = yinv ? -primeiraCoordenada.Y : primeiraCoordenada.Y;
            string xCoordp = xCoordValuep % 1 == 0 ? $"{xCoordValuep}.":$"{xCoordValuep}";
            string yCoordp = yCoordValuep % 1 == 0 ? $"{yCoordValuep}.":$"{yCoordValuep}";

            gCodeForDrill.AppendLine($"{corte}X{xCoordp}Y{yCoordp}{restodoprimeiro}{fukasa}F{drill.Okuri}");

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
            if(okk == false && drill.TipoDrill.OAIR == true){ gCodeForDrill.AppendLine("CALL OAIR2"); }
            gCodeForDrill.AppendLine("(FIM DO FURADOR)");
            if(Kanizawa ==true)
            { gCodeForDrill.AppendLine("RTS"); }

            return gCodeForDrill;
        }

        public StringBuilder GcodeMentori(Mentori mentori, MentoriB mentorib, Ferramentas ferramenta, bool frente, bool tras, bool okk, bool Kanizawa)
        {
            StringBuilder gCode = new StringBuilder();
            int kaiten = mentori.Kaiten;
            int okuri = mentori.Okuri;
            float z = ferramenta.Mentori.Z;
            if (z < 0)
            {
                z = z * -1;
            }
            float ponta = mentori.Kei;
            float diaburaco = ferramenta.Mentori.MenKei;
            float C = ferramenta.Mentori.C * 2;
            float Dansa = ferramenta.Mentori.Dansa;
            if (Dansa < 0)
            {
                Dansa = Dansa * -1;
            }

            float kei = diaburaco + C - z;
            float valorz = z + Dansa;
            valorz *= -1;
            ferramenta.Mentori.Z2 = valorz;
            bool xinv = peca.xinv;
            bool yinv = peca.yinv;

            gCode.AppendLine("("+ferramenta.ToolName.ToString()+ "-Ø"+ferramenta.Kei +")");
            for (int i = 0; i < ferramenta.CoordenadasList.Count; i++)
            {// Multiplica a coordenada X por -1 se xinv for verdadeiro


                PointF coordenada = ferramenta.CoordenadasList[i];
                float xCoordValue = xinv ? -coordenada.X : coordenada.X;
                float yCoordValue = yinv ? -coordenada.Y : coordenada.Y;
                gCode.Append(Mentori.GenerateMentori(xCoordValue, yCoordValue, valorz, kei, ponta, okuri, 10));
            }
            gCode.AppendLine("G0Z500.");
            return gCode;
        }

        public static string GenerateGElipse(double centerX, double centerY, double endMillDiameter, int feedRate, double ellipseWidth, double ellipseHeight)
        {
            string gCode = "";

            int numArcs = 8;
            double angleIncrement = 360.0 / numArcs;

            double prevX = centerX - (ellipseWidth / 2) - (endMillDiameter / 2);
            double prevY = centerY;

            gCode += $"G90 G01 X{prevX} Y{prevY} Z-8.5 F{feedRate}" + Environment.NewLine;

            for (int i = 1; i <= numArcs; i++)
            {
                double startAngle = (i - 1) * angleIncrement;
                double endAngle = i * angleIncrement;

                double startX = centerX + (ellipseWidth / 2) * Math.Cos(startAngle * Math.PI / 180);
                double startY = centerY + (ellipseHeight / 2) * Math.Sin(startAngle * Math.PI / 180);

                double endX = centerX + (ellipseWidth / 2) * Math.Cos(endAngle * Math.PI / 180);
                double endY = centerY + (ellipseHeight / 2) * Math.Sin(endAngle * Math.PI / 180);

                double angleOffset = Math.Atan2(endY - startY, endX - startX);
                double offsetX = (endMillDiameter / 2) * Math.Cos(angleOffset);
                double offsetY = (endMillDiameter / 2) * Math.Sin(angleOffset);

                double arcCenterX = startX + offsetX;
                double arcCenterY = startY + offsetY;

                double iValue = arcCenterX - prevX;
                double jValue = arcCenterY - prevY;

                gCode += $"G03 X{endX} Y{endY} I{iValue} J{jValue} F{feedRate}" + Environment.NewLine;

                prevX = endX;
                prevY = endY;
            }

            return gCode;
        }

        public  void SaveStringBuilderToFile(StringBuilder okuma56, StringBuilder okuma46, StringBuilder OKK76, StringBuilder okuma56f, StringBuilder okuma46f, StringBuilder okkf, string nome)
            {
                // Converte o StringBuilder em uma string
                string contentAsString56 = okuma56.ToString();
                string contentAsString46 = okuma46.ToString();
                string contentAsString76 = OKK76.ToString();
                string contentAsString56f = okuma56f.ToString();
                string contentAsString46f = okuma46f.ToString();
                string contentAsStringokkf = okkf.ToString();

                string filePath1 = pastas.CaminhoO56.ToString();
                string filePath2 = pastas.CaminhoO46.ToString();    
                string filePath3 = pastas.CaminhoOKK.ToString();
                string filePath4 = pastas.CaminhoO56F.ToString();
                string filePath5 = pastas.CaminhoO46F.ToString();
                string filePath6 = pastas.CaminhoOKKF.ToString();
                string path1 = Path.Combine(filePath1, nome);
                string path2 = Path.Combine(filePath2, nome);
                string path3 = Path.Combine(filePath3, nome);
                string path4 = Path.Combine(filePath4, nome);
                string path5 = Path.Combine(filePath5, nome);
                string path6 = Path.Combine(filePath6, nome);

            // Salva a string em um arquivo .txt
            File.WriteAllText(path1, contentAsString56);
            File.WriteAllText(path2, contentAsString46);
            File.WriteAllText(path3, contentAsString76);
            File.WriteAllText(path4, contentAsString56f);
            File.WriteAllText(path5, contentAsString46f);
            File.WriteAllText(path6, contentAsStringokkf);
            }

        public StringBuilder final()
        {
            StringBuilder final = new StringBuilder();
            final.AppendLine("/");
            final.AppendLine("OAIR2(M206)");
            final.AppendLine("M132");
            final.AppendLine("G0Z1000M339");
            final.AppendLine("M5");
            final.AppendLine("G4P7");
            final.AppendLine("M133");
            final.AppendLine("RTS");
            return final;
        }
    }
}
