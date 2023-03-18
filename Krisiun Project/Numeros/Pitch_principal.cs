using Krisiun_Project.Dados_Aleatorios1;
using Krisiun_Project.Numeros;
using System;
using System.Windows.Forms;

namespace Krisiun_Project
{
    public class Pitch_principal : Panel
    {

        public class Pitch : Panel
        {
            private Bools _bools;
            private Shindashi shin;
            private Peca peca;
            public Pitch(Bools bools)
            {
                _bools = bools;
            }

            public float PontoInicialX()
            {
                int centerX = 1000 / 2;
                float cx = (float)Convert.ToDouble(centerX);
                return cx;
            }

            public float PontoInicialY()
            {

                int lado = 700;
                if (_bools.bool_lado == true) { lado = 450; }
                if (_bools.bool_lado == false) { lado = 700; }
                int centerY = lado / 2;
                float cy = (float)Convert.ToDouble(centerY);
                return cy;
            }
            public float PontoInicialZ()
            {
                int centerX = 250 / 2;
                float cx = (float)Convert.ToDouble(centerX);
                return cx;
            }
            public void calculo_de_base(Shindashi shin, Peca peca, float textBoxx, float textboxy)
            {
                float pitch = textBoxx;
                float pitchy = textboxy;
                //if (float.TryParse(textBoxx.Text, out pitch)) 
                //if (float.TryParse(textboxy.Text, out pitchy))  

                pitch = pitch * peca.scale;
                pitchy = pitchy * peca.scale;
                float pitchinv = pitch * -1;
                float pitchinvy = pitchy * -1;


                this.shin = shin;
                this.peca = peca;
                float carx = peca.width / 2;
                float cary = peca.height / 2;
                float xxx = PontoInicialX();
                float yyy = PontoInicialY();
                float shinx = 0;
                float shinxinvx = 0;
                float shiny = 0;
                float shininvy = 0;
                carx = xxx - carx;
                cary = yyy - cary;
                if (pitch >= 0) { shinx = carx + pitch; }
                if (pitch < 0) { shinx = carx + peca.width; shinx += pitch; }

                if (pitchy < 0) { shiny = cary - pitchy; }
                if (pitchy >= 0) { shiny = cary + peca.height; shiny -= pitchy; }


                //pitch inverso:
                if (pitchinv >= 0) { shinxinvx = carx + pitchinv; }
                if (pitchinv < 0) { shinxinvx = carx + peca.width; shinxinvx += pitchinv; }

                if (pitchinvy < 0) { shininvy = cary - pitchinvy; }
                if (pitchinvy >= 0) { shininvy = cary + peca.height; shininvy -= pitchinvy; }


                shin.x = shinx;
                shin.y = shiny;
                shin.x1 = shinxinvx;
                shin.y1 = shininvy;

                //tamanho real na peça:

                float real_x1 = pitch / peca.scale;
                if (pitch < 0) { real_x1 *= -1; }
                float real_x2 = peca.width / peca.scale - real_x1;
                float real_y1 = pitchy / peca.scale;
                if (pitchy < 0) { real_y1 *= -1; }
                float real_y2 = peca.height / peca.scale - real_y1;

                if (pitch >= 0)
                {
                    shin.realx1 = real_x1;
                    shin.realx2 = real_x2;
                }
                if (pitch < 0)
                {
                    shin.realx1 = real_x2;
                    shin.realx2 = real_x1;
                }
                if (pitchy >= 0)
                {
                    shin.realy1 = real_y2;
                    shin.realy2 = real_y1;
                }
                if (pitchy < 0)
                {
                    shin.realy1 = real_y1;
                    shin.realy2 = real_y2;
                }

            }


        }
        public class Peca
        {
            public float width;
            public float sizex;
            public float sizey;
            public float sizez;
            public float height;
            public float z;
            public float scale;
            public float basex;
            public float basey;
            public string zuban;
            public string hinmei;
            public int omote;
            public int ura;
            public bool xinv;
            public bool yinv;
            public Material Material;

            public Peca()
            {
                this.scale = 1f;

                this.width = 100;
                this.height = 100;
                this.z = 40;
                this.basex = 50;
                this.basey = 50;
                this.omote = 1;
                this.ura = 2;
                xinv = true;
            }

            public void UpdateSize(float x, float y, float z)
            {


                this.width = x * scale;
                this.height = y * scale;
                this.z = z * scale;


            }
        }

        public class Shindashi
        {
            private Pitch pitch;
            public float x;
            public float y;

            public float x1;//inverso
            public float y1;//inverso
            public float realx1;
            public float realy1;
            public float realx2;
            public float realy2;
            public Shindashi(Pitch pitch)
            {
                this.pitch = pitch;
                this.x = pitch.PontoInicialX();

                this.x1 = pitch.PontoInicialX();
                this.y = pitch.PontoInicialY();
                this.y1 = pitch.PontoInicialY();


            }

            public void calculox2(float x, Peca peca)
            {
                float largura = peca.width;
                this.realx2 = largura - x;


            }
            public void UpdateShindashi(TextBox xx, TextBox yy)
            {
                string valorx = xx.Text;
                string valory = yy.Text;
                float xxx;
                float yyy;
                if (float.TryParse(valorx, out xxx))
                {
                    this.x = xxx;
                }
                if (float.TryParse(valory, out yyy))
                {
                    this.y = yyy;
                }
            }
        }


    }

}
