using Krisiun_Project.G_Code;
using Krisiun_Project.janela_principal;
using Krisiun_Project.Numeros;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using static Krisiun_Project.Pitch_principal;

namespace Krisiun_Project
{
    internal class Zairyo
    {
        public class Desenho
        {
            private Peca peca;
            private Pitch meio;
            private Shindashi shin;
            private Tests t;
            float linhaextra = 10;
            public Desenho(Bools bools)
            {

                this.peca = new Peca();
                this.meio = new Pitch(bools);
                this.t = new Tests();
            }
            public float pitchinicialX()
            {
                float xx = peca.width;
                xx = xx / 2;
                float xxx = meio.PontoInicialX();
                float posicaox = xxx - xx;
                return posicaox;
            }

            public float pitchinicialY()
            {
                float yy = peca.height;
                yy = yy / 2;
                float yyy = meio.PontoInicialY();
                float posicaoy = yyy - yy;
                return posicaoy;
            }
            public float pitchinicialZ()
            {
                float zz = peca.z;
                zz = zz / 2;
                float zzz = meio.PontoInicialZ();
                float posicaoz = zzz - zz;
                return posicaoz;
            }
            public void linha(PaintEventArgs e)
            {

                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Gray);
                g.DrawLine(pen, 500, 0, 500, 700);
                g.DrawLine(pen, 0, 350, 1000, 350);
            }

            public void zaryoelipse(PaintEventArgs e, Pitch_principal.Peca peca)
            {
                this.peca = peca;
                float sizex = peca.width;
                float sizey = peca.height;
                float x = pitchinicialX();
                float y = pitchinicialY();
                float kei = peca.width / peca.scale;
                string kei1 = kei.ToString();
                //float linhaex = 10; 


                //calcular o risco
                float cx = meio.PontoInicialX(); // coordenada x do centro da circunferência
                float cy = meio.PontoInicialY(); // coordenada y do centro da circunferência
                float r = kei / 2; // raio da circunferência
                float a = (float)Convert.ToDouble(Math.PI / 4); // ângulo em radianos (45 graus)
                                                                //     float b = (float)Convert.ToDouble(Math.PI / 4) * 3; // ângulo em radianos (45 graus)

                float xxx = cx + r * (float)Math.Cos(a) * peca.scale;
                float yyy = cy + r * (float)Math.Sin(a) * peca.scale;

                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Black, 1);
                Pen pen1 = new Pen(Color.Gray);
                Font font = new Font("Arial", 7);
                Brush brush = new SolidBrush(Color.Black);
                g.DrawEllipse(pen, x, y, sizex, sizey);
                g.DrawString(kei1, font, brush, x - 10, y - 10);
                g.DrawLine(pen1, xxx, yyy, x, y);
            }
            public void zaryoretangulo(PaintEventArgs e, Pitch_principal.Peca peca)
            {
                this.peca = peca;
                float sizex = peca.width;
                float sizey = peca.height;
                float x = pitchinicialX();
                float y = pitchinicialY();
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Black, 1);
                g.DrawRectangle(pen, x, y, sizex, sizey);

            }
            public void lado(PaintEventArgs e, Pitch_principal.Peca peca)
            {
                this.peca = peca;
                float sizex = peca.width;
                float sizez = peca.z;
                float x = pitchinicialX();
                float z = pitchinicialZ();
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Black, 1);
                Font font = new Font("Arial", 7);
                Brush brush = new SolidBrush(Color.Black);
                g.DrawString("LADO", font, brush, 10, 10);
                g.DrawRectangle(pen, x, z, sizex, sizez);

            }

            public void linhabase(PaintEventArgs e, Pitch_principal.Shindashi shin, Peca peca, Pitch meio, Tests t, bool xxx, bool yyy)
            {
                this.shin = shin;
                this.peca = peca;
                this.meio = meio;
                this.t = t;
                Font font = new Font("Arial", 7);
                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Gray, 2);
                Pen pen1 = new Pen(Color.Gray);
                Graphics g = e.Graphics;
                float basex = shin.x;
                float basey = shin.y;
                if (xxx == true) { basex = shin.x1; }
                if (yyy == true) { basey = shin.y1; }
                //  float linhaextra = 10;
                float x1 = pitchinicialX() - linhaextra;
                float x2 = x1 + peca.width + linhaextra + linhaextra;
                float y1 = pitchinicialY() - linhaextra;
                float y2 = y1 + peca.height + linhaextra + linhaextra;

                //arrumar o sinalizador da Base
                string b = "B";
                SizeF b_size = g.MeasureString(b, font);

                SizeF retangulo = new SizeF(b_size.Width + 2, b_size.Height + 2);
                float ret_x = retangulo.Width / 2;
                float ret_y = retangulo.Height / 2;
                //B do Lado com retangulo
                g.DrawRectangle(pen1, x1 - retangulo.Width, basey - ret_y, retangulo.Width, retangulo.Height);
                g.DrawString(b, font, brush, x1 - retangulo.Width + 2, basey - ret_y + 2); //B de do lado.

                g.DrawRectangle(pen1, basex - ret_x, y2, retangulo.Width, retangulo.Height);
                g.DrawString(b, font, brush, basex - ret_x + 2, y2 + 2); //B de cima.
                string debugx = "X" + basex.ToString();
                string debugy = "Y" + basey.ToString();
                string wololo = "TESTE: " + t.x;

                g.DrawString(debugx, font, brush, 10, 30);
                g.DrawString(debugy, font, brush, 10, 40);
                g.DrawString(wololo, font, brush, 10, 50);



                g.DrawLine(pen, basex, y1, basex, y2);
                g.DrawLine(pen, x1, basey, x2, basey);
            }

            public void linhabase_circulo(PaintEventArgs e, Pitch_principal.Shindashi shin, Peca peca, Pitch meio, Tests t, bool xxx, bool yyy)
            {
                this.shin = shin;
                this.peca = peca;
                this.meio = meio;
                this.t = t;
                Font font = new Font("Arial", 7);
                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(Color.Gray, 2);
                Pen pen1 = new Pen(Color.Gray);
                Graphics g = e.Graphics;
                float basex = shin.x;
                float basey = shin.y;
                if (xxx == true) { basex = shin.x1; }
                if (yyy == true) { basey = shin.y1; }
                //  float linhaextra = 10;
                float x1 = pitchinicialX() - linhaextra;
                float x2 = x1 + peca.width + linhaextra + linhaextra;
                float y1 = pitchinicialY() - linhaextra;
                float y2 = y1 + peca.height + linhaextra + linhaextra;

                g.DrawLine(pen, basex, y1, basex, y2);
                g.DrawLine(pen, x1, basey, x2, basey);
            }
            public void linhaslaterias(PaintEventArgs e, Pitch_principal.Shindashi shin, Peca peca, Pitch meio, Tests t, bool xxx, bool yyy)
            {
                this.shin = shin;
                this.peca = peca;
                this.meio = meio;
                this.t = t;
                Font font = new Font("Arial", 7);
                Brush brush = new SolidBrush(Color.Black);
                Graphics g = e.Graphics;

                Pen pen = new Pen(Color.Gray);


                //calculo da posição
                float meiox = peca.width / 2;
                float meioy = peca.height / 2;

                float x1 = meio.PontoInicialX() + meiox;
                float x2 = meio.PontoInicialX() - meiox;
                float y1 = meio.PontoInicialY() + meioy;
                float y2 = meio.PontoInicialY() - meioy;

                //valores do pitch
                string valor_de_x1 = shin.realx1.ToString();
                string valor_de_x2 = shin.realx2.ToString();
                string valor_de_y1 = shin.realy1.ToString();
                string valor_de_y2 = shin.realy2.ToString();
                SizeF tam_x1 = g.MeasureString(valor_de_x1, font);
                SizeF tam_x2 = g.MeasureString(valor_de_x2, font);
                SizeF tam_y1 = g.MeasureString(valor_de_y1, font);
                SizeF tam_y2 = g.MeasureString(valor_de_y2, font);
                float valor_de_x1_cum = tam_x1.Width / 2;
                float valor_de_x1_alt = tam_x1.Height;
                float valor_de_x2_cum = tam_x2.Width / 2;
                float valor_de_x2_alt = tam_x2.Height;
                float valor_de_y1_cum = tam_y1.Height; float valor_de_y1_alt = tam_y1.Height / 2;
                float valor_de_y2_cum = tam_y2.Height; float valor_de_y2_alt = tam_y2.Height / 2;

                PointF ponto1 = new PointF(x2, y2); // canto superior esquerdo
                PointF ponto2 = new PointF(x1, y2); // canto superior direito
                PointF ponto3 = new PointF(x1, y1); // canto inferior direito
                //PointF ponto4 = new PointF(x1, y1);
                PointF ponto4 = new PointF(x2 - valor_de_x1_cum, y2 - linhaextra - valor_de_x1_alt); // canto superior esquerdo (x da esquerda)
                PointF ponto5 = new PointF(x1 - valor_de_x2_cum, y2 - linhaextra - valor_de_x2_alt); // canto superior direito (x pra direita)
                PointF ponto6 = new PointF(x1 + linhaextra, y2 - valor_de_y1_alt); //canto superior direito (y pra cima)
                PointF ponto7 = new PointF(x1 + linhaextra, y1 - valor_de_y2_alt); // canto inferior direito (y pra baixo)


                g.DrawString("X1: " + x1.ToString(), font, brush, 10, 60);
                g.DrawString("X2: " + x2.ToString(), font, brush, 10, 70);
                g.DrawString("Y1: " + y1.ToString(), font, brush, 10, 80);
                g.DrawString("Y2: " + y2.ToString(), font, brush, 10, 90);
                g.DrawString("tamanhox:" + valor_de_x1_cum.ToString(), font, brush, 10, 100);
                g.DrawString("tamanholarg:" + valor_de_x1_alt.ToString(), font, brush, 10, 110);
                if (xxx == false)
                {
                    g.DrawString(valor_de_x1, font, brush, ponto4);
                    g.DrawString(valor_de_x2, font, brush, ponto5);
                }
                if (xxx == true)
                {
                    g.DrawString(valor_de_x2, font, brush, ponto4);
                    g.DrawString(valor_de_x1, font, brush, ponto5);
                }
                if (yyy == false)
                {
                    g.DrawString(valor_de_y1, font, brush, ponto6);
                    g.DrawString(valor_de_y2, font, brush, ponto7);
                }
                if (yyy == true)
                {
                    g.DrawString(valor_de_y2, font, brush, ponto6);
                    g.DrawString(valor_de_y1, font, brush, ponto7);
                }

                g.DrawLine(pen, ponto1.X, ponto1.Y, ponto1.X, ponto1.Y - linhaextra); //linha canto superior esquerdo (para X)
                g.DrawLine(pen, ponto2.X, ponto2.Y, ponto2.X, ponto2.Y - linhaextra); //linha canto superior direito (para X)
                g.DrawLine(pen, ponto2.X, ponto2.Y, ponto2.X + linhaextra, ponto2.Y); // linha canto superior direito (para Y)
                g.DrawLine(pen, ponto3.X, ponto3.Y, ponto3.X + linhaextra, ponto3.Y); //linha canto inferior direito (para Y)
            }

            public void DesenharFerramentas(PaintEventArgs e, IEnumerable<Ferramentas> ferramentas, bool inverterX, bool inverterY, Panel panel, Panel paneltras)
            {
                // Define um pincel e uma caneta para desenhar as ferramentas
                Pen pen = new Pen(Color.Black, 2);
                    //pen.DashStyle = DashStyle.Dot;
                    Brush brush = Brushes.Black;
                    var pen1 = Pens.DarkCyan;
                    Graphics g = e.Graphics;
                    var font  = new Font("Arial", 7);

                List<PointF> PontoX = new List<PointF>();
                List<PointF> Sohumdesenho = new List<PointF>();
                float meiox = meio.PontoInicialX();
                    float meioy = meio.PontoInicialY();
                    float halfpecax = peca.width / 2;
                    float halfpecay = peca.height / 2;
                float posicaotextoz1 = 5;
                float posicaotextoz2 = 5;   
                StringFormat stringformat = new StringFormat();
                stringformat.FormatFlags = StringFormatFlags.DirectionVertical;
                bool isFirst = true;

                // Itera sobre as ferramentas e desenha cada uma na superfície do Panel
                foreach (var ferramenta in ferramentas)
                {
                    // Verifica se a ferramenta é uma instância de Drills
                    if (ferramenta is Drills drills)
                    {
                        // Obtém as coordenadas do Drills
                        var coordenadas = drills.CoordenadasList;

                        // Itera sobre as coordenadas do Drills e desenha cada ponto na superfície do Panel
                        foreach (var point in coordenadas)
                        {
                            //var x = inverterX ? panel.ClientSize.Width - point.X : point.X;
                            //var y = inverterY ? panel.ClientSize.Height - point.Y : point.Y;
                            var x = point.X;
                            var y = point.Y;
                            var shinx = shin.x;
                            var shiny = shin.y;
                            bool frente = drills.Frente;
                            bool tras = drills.Tras;
                            float fukasa = drills.Fukasa * peca.scale;
                            SolidBrush brush1 = new SolidBrush(drills.Color);
                            if (inverterX == true)
                            {
                                x *= -1;
                                shinx = shin.x1;
                            }
                            if(inverterY == true)
                            {
                                y *= -1;
                                    shiny = shin.y1;
                            }
                            float kei = drills.Kei * peca.scale;
                            float halfkei = kei / 2;
                            x *= peca.scale;
                            x = x + shinx - halfkei;
                            y *= peca.scale;
                            y = shiny - y - halfkei;

                            //sobre as linhas
                            var linhax1 = x + halfkei;
                            var linhax2 = meiox + halfpecax + linhaextra ; // lado direito
                            var linhax3 = meiox - halfpecax - linhaextra; //lado esquerdo
                            var linhay1 = y + halfkei;
                            var linhay2 = meioy - halfpecay - linhaextra;
                            var linhay3 = meioy + halfpecay + linhaextra;
                          

                            //sobre as escritas
                            string pitchx = point.X.ToString();
                            string pitchy = point.Y.ToString();
                            SizeF tamx = g.MeasureString(pitchx, font);
                            SizeF tamy = g.MeasureString(pitchy, font);
                            float vx1 = tamx.Width; //pitchx
                            float vy1= tamx.Height;//pitchx
                            float vx2 = tamy.Width;//pitchy
                            float vy2 = tamy.Height;//pitchy
                            float pontox = linhax2; //ladi direito
                            float pontox1 = linhax3 - vx2; //lado esquerto
                            float pontoy = linhay1 - vy1/2; //lado de cima
                            float pontoy1 = linhay2 - vy2;



                            // Desenha o ponto na superfície do Panel
                            Pen pen2 = new Pen(Color.Black, 3);
                      
                        
                                if (panel.Name == "paneld_f"&&drills.Tras == true && drills.Frente==false && fukasa < peca.sizez)
                                {
                                    pen2.DashStyle = DashStyle.Dot;
                                brush1.Color = Color.FromArgb(50, drills.Color);

                                }
                            if (panel.Name == "panel_b" && drills.Tras == false && drills.Frente == true && fukasa < peca.sizez)
                            {
                                pen2.DashStyle = DashStyle.Dot;

                                brush1.Color = Color.FromArgb(50, drills.Color);
                            }
                          
                            if(panel.Name != "panel_yoko")
                            { 
                            g.DrawEllipse(pen2, x, y, kei, kei);
                            g.FillEllipse(brush1, x, y, kei, kei);//esse aparentemente funciona

                                //desnha a linha e a escrita (linha horizontal, Pitch de Y)
                           // System.Diagnostics.Debug.WriteLine("x = " + x);
                            if (x <= shin.x)
                            {
                                g.DrawLine(pen1, linhax1, linhay1, linhax3, linhay1);
                                g.DrawString(pitchy, font, brush, pontox1, pontoy);
                            }
                            if (x > shin.x)
                            {
                                g.DrawLine(pen1, linhax1, linhay1, linhax2, linhay1);
                                g.DrawString(pitchy, font, brush, pontox, pontoy);
                            }
                            if (y <= shin.y)
                            { 
                            g.DrawLine(pen1, linhax1,linhay1,linhax1, linhay2); //linha vertical (Pitch de X)
                            g.DrawString(pitchx, font, brush, linhax1 - vy1/2, pontoy1, stringformat);
                            }
                            if (y > shin.y)
                            {
                                g.DrawLine(pen1, linhax1, linhay1, linhax1, linhay3); //linha vertical (Pitch de X)
                                g.DrawString(pitchx, font, brush, linhax1 - vy1 / 2, linhay3, stringformat);
                            }
                            }
                            if (panel.Name == "panel_yoko")
                            {
                                string valor = "φ" + drills.Kei.ToString();
                                SizeF valortam = g.MeasureString(valor, font);
                                float valorx = valortam.Width / 2;
                                float posicaotexto = x + halfkei - valorx;
       
                                brush1.Color = Color.FromArgb(100, drills.Color);

                                PointF pointF = new PointF(point.X, pitchinicialZ());
                                PointF pointF1 = new PointF(x, pitchinicialZ());
                          
                      
                                if (drills.Frente == true)
                                {
                                    if (isFirst)
                                    {

                                        if (PontoX.Contains(pointF))
                                        {
                                            posicaotextoz1 += 10;
                                        }
                                        g.DrawString(valor, font, brush, posicaotexto, pitchinicialZ() - valortam.Height - posicaotextoz1);
                                        g.DrawRectangle(pen1, x, pitchinicialZ(), kei, fukasa);
                                        g.FillRectangle(brush1, x, pitchinicialZ(), kei, fukasa);
                                        PontoX.Add(pointF);
                                        isFirst = false;
                                    }
                                    Sohumdesenho.Add(pointF1);

                                }
                                if(drills.Tras == true)
                                {
                                    g.DrawString(valor, font, brush, posicaotexto, pitchinicialZ() + peca.z + posicaotextoz2);
                                    g.DrawRectangle(pen1, x, pitchinicialZ() + peca.z - fukasa, kei, fukasa);
                                    g.FillRectangle(brush1, x, pitchinicialZ() + peca.z - fukasa, kei, fukasa);
                                }
                                    
                                if(coordenadas.Count >= 1) { return; }
                            }
                            //daqui pra baixo é o desenho do lado


                        }

                        posicaotextoz1 = 5;
                    }
                    // Verifica se a ferramenta é uma instância de Taps
                    else if (ferramenta is Tap taps)
                    {
                        // Obtém as coordenadas do Taps
                        var coordenadas = taps.CoordenadasList;

                        // Itera sobre as coordenadas do Taps e desenha cada ponto na superfície do Panel
                        foreach (var point in coordenadas)
                        {
                            // Inverte as coordenadas X e/ou Y, se necessário
                            var x = inverterX ? panel.ClientSize.Width - point.X : point.X;
                            var y = inverterY ? panel.ClientSize.Height - point.Y : point.Y;

                            //graphics.FillRectangle(brush, x, y, 10, 10);
                            g.DrawRectangle(pen, x, y, 10, 10);
                        }
                    }
                    // Adicione mais condicionais aqui para outras ferramentas

                    // ... 
                }
            }



            //bagulho velho no qual era suposto desenhar só um bagulho.
            #region codigo velho
            public void desenholado(PaintEventArgs e, IEnumerable<Ferramentas> ferramentas)
            {
                Dictionary<PointF, List<Ferramentas>> ferramentasPorCoordenada = new Dictionary<PointF, List<Ferramentas>>();
                this.peca = peca;
                float sizex = peca.width;
                float sizez = peca.z;
                float x = pitchinicialX();
                float y = pitchinicialY();
                float z = pitchinicialZ();
                Graphics g = e.Graphics;
                //Pen pen = new Pen(Color.Black, 1);
                //Font font = new Font("Arial", 7);
                //Brush brush = new SolidBrush(Color.Black);
                // g.DrawString("LADO", font, brush, 10, 10);
                //  g.DrawRectangle(pen, x, z, sizex, sizez);
                // Agrupar as ferramentas por coordenada
                foreach (var ferramenta in ferramentas)
                {
                    foreach (var coordenada in ferramenta.CoordenadasList)
                    {
                        if (ferramentasPorCoordenada.ContainsKey(coordenada))
                        {
                            ferramentasPorCoordenada[coordenada].Add(ferramenta);
                        }
                        else
                        {
                            ferramentasPorCoordenada[coordenada] = new List<Ferramentas> { ferramenta };
                        }
                    }
                }

                // Desenhar as ferramentas agrupadas por coordenada
                foreach (var kvp in ferramentasPorCoordenada)
                {
                    var coordenada = kvp.Key;
                    var ferramentasNaCoordenada = kvp.Value;

                    // Calcular a posição do primeiro objeto na coordenada
                    float offsetX = x + 5;
                    float offsetX1 = x;
                    if (ferramentasNaCoordenada.Count > 1)
                    {
                        offsetX = -(ferramentasNaCoordenada.Count - 1) * (ferramentasNaCoordenada[0].Kei + 10) / 2f;
                    }

                    // Desenhar as ferramentas na mesma coordenada no mesmo lugar
                    bool coordenadaRepetida = ferramentasNaCoordenada.Count > 1;
                    foreach (var ferramenta in ferramentasNaCoordenada)
                    {
                        float kei = ferramenta.Kei;
                        float fukasa = ferramenta.Fukasa;
                        float hankei = ferramenta.Kei / 2;
                        if (ferramenta.Tras == true)
                        { z = z + peca.sizez; }
                        if (coordenadaRepetida)
                        {

                            g.DrawRectangle(Pens.Black, coordenada.X + offsetX1, z, ferramenta.Kei, ferramenta.Fukasa);
                            // o offsetX1 é o X, o z é o Y, o Kei é o tamanho do retangulo e o Fukasa é a altura do retangulo
                        }
                        else
                        {
                            g.DrawRectangle(Pens.Black, coordenada.X + offsetX, z, ferramenta.Kei, ferramenta.Fukasa);
                            offsetX += ferramenta.Kei + 10;
                        }
                    }
                }
            }
            public void desenholado1(PaintEventArgs e, IEnumerable<Ferramentas> ferramentas)
            {
                Dictionary<PointF, List<Ferramentas>> ferramentasPorCoordenada = new Dictionary<PointF, List<Ferramentas>>();
                this.peca = peca;
                float sizex = peca.width;
                float sizez = peca.z;
                float x = pitchinicialX();
                float y = pitchinicialY();
                float z = pitchinicialZ();
                Graphics g = e.Graphics;
                //Pen pen = new Pen(Color.Black, 1);
                //Font font = new Font("Arial", 7);
                //Brush brush = new SolidBrush(Color.Black);
                // g.DrawString("LADO", font, brush, 10, 10);
                //  g.DrawRectangle(pen, x, z, sizex, sizez);
                // Agrupar as ferramentas por coordenada
                foreach (var ferramenta in ferramentas)
                {
                    foreach (var coordenada in ferramenta.CoordenadasList)
                    {
                        if (ferramentasPorCoordenada.ContainsKey(coordenada))
                        {
                            ferramentasPorCoordenada[coordenada].Add(ferramenta);
                        }
                        else
                        {
                            ferramentasPorCoordenada[coordenada] = new List<Ferramentas> { ferramenta };
                        }
                    }
                }

                // Desenhar as ferramentas agrupadas por coordenada
                foreach (var kvp in ferramentasPorCoordenada)
                {
                    var coordenada = kvp.Key;
                    var ferramentasNaCoordenada = kvp.Value;

                    // Calcular a posição do primeiro objeto na coordenada
                    float offsetX = x + 5;
                    float offsetX1 = x;
                    if (ferramentasNaCoordenada.Count > 1)
                    {
                        offsetX = -(ferramentasNaCoordenada.Count - 1) * (ferramentasNaCoordenada[0].Kei + 10) / 2f;
                    }

                    // Desenhar as ferramentas na mesma coordenada no mesmo lugar
                    bool coordenadaRepetida = ferramentasNaCoordenada.Count > 1;
                    foreach (var ferramenta in ferramentasNaCoordenada)
                    {
                        float kei = ferramenta.Kei;
                        float fukasa = ferramenta.Fukasa;
                        float hankei = ferramenta.Kei / 2;
                        if (ferramenta.Tras == true)
                        { z = z + peca.sizez; }
                        if (coordenadaRepetida)
                        {

                            g.DrawRectangle(Pens.Black, coordenada.X + offsetX1, z, ferramenta.Kei, ferramenta.Fukasa);
                            // o offsetX1 é o X, o z é o Y, o Kei é o tamanho do retangulo e o Fukasa é a altura do retangulo
                        }
                        else
                        {
                            g.DrawRectangle(Pens.Black, coordenada.X + offsetX, z, ferramenta.Kei, ferramenta.Fukasa);
                            offsetX += ferramenta.Kei + 10;
                        }
                    }
                }
            }



            #endregion
        }

    }
}
