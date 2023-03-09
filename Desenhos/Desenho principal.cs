using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;
using static Krisiun_Project.Pitch_principal;
using Krisiun_Project.janela_principal;

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
            float linhaextra =10;
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
                g.DrawRectangle(pen,x,z,sizex, sizez);

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
                if(yyy == true) { basey = shin.y1; }
              //  float linhaextra = 10;
                float x1 = pitchinicialX() - linhaextra;
                float x2 = x1 + peca.width + linhaextra + linhaextra;
                float y1 = pitchinicialY() - linhaextra;
                float y2 = y1+ peca.height + linhaextra + linhaextra;

                //arrumar o sinalizador da Base
                string b = "B";
                SizeF b_size = g.MeasureString(b, font);

                SizeF retangulo = new SizeF(b_size.Width + 2, b_size.Height + 2);
                float ret_x = retangulo.Width / 2;
                float ret_y = retangulo.Height / 2;
                //B do Lado com retangulo
                g.DrawRectangle(pen1, x1 - retangulo.Width, basey - ret_y, retangulo.Width,retangulo.Height);
                g.DrawString(b, font, brush, x1 - retangulo.Width + 2, basey - ret_y + 2); //B de do lado.

                g.DrawRectangle(pen1, basex - ret_x, y2, retangulo.Width,retangulo.Height);
                g.DrawString(b, font, brush, basex - ret_x + 2, y2 + 2); //B de cima.
                string debugx = "X"+ basex.ToString();
                string debugy = "Y"+ basey.ToString();
                string wololo = "TESTE: " + t.x;
       
                g.DrawString(debugx, font, brush, 10, 30);
                g.DrawString(debugy, font, brush, 10, 40);
                g.DrawString(wololo, font, brush, 10, 50);


 
                g.DrawLine(pen, basex,y1, basex, y2);
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
                if(xxx== true)
                {
                    g.DrawString(valor_de_x2, font, brush, ponto4);
                    g.DrawString(valor_de_x1, font, brush, ponto5);
                }
                if(yyy == false)
                {
                    g.DrawString(valor_de_y1, font, brush, ponto6);
                    g.DrawString(valor_de_y2, font, brush, ponto7);
                }
                if(yyy == true)
                {
                    g.DrawString(valor_de_y2, font, brush, ponto6);
                    g.DrawString(valor_de_y1, font, brush, ponto7);
                }
  
                g.DrawLine(pen, ponto1.X, ponto1.Y, ponto1.X, ponto1.Y - linhaextra); //linha canto superior esquerdo (para X)
                g.DrawLine(pen, ponto2.X, ponto2.Y, ponto2.X, ponto2.Y - linhaextra); //linha canto superior direito (para X)
                g.DrawLine(pen, ponto2.X, ponto2.Y, ponto2.X + linhaextra, ponto2.Y); // linha canto superior direito (para Y)
                g.DrawLine(pen, ponto3.X, ponto3.Y, ponto3.X+ linhaextra, ponto3.Y); //linha canto inferior direito (para Y)
            }
        }

    }
}
