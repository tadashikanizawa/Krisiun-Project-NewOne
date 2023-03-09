using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project
{
    public class Pitch_principal : Panel
    {
        public class Pitch : Panel
        {
            private Shindashi shin;
            private Peca peca;
            public float PontoInicialX()
            {
                int centerX = 1000 / 2;
                float cx = (float)Convert.ToDouble(centerX);
                return cx;
            }

            public float PontoInicialY()
            {
                int centerY = 700 / 2;
                float cy = (float)Convert.ToDouble(centerY);
                return cy;
            }
            public void calculo_de_base(Shindashi shin, Peca peca, TextBox textBoxx, TextBox textboxy)
            {
                float pitch = 0;
                float pitchy = 0;
                if (float.TryParse(textBoxx.Text, out pitch)) 
                if (float.TryParse(textboxy.Text, out pitchy))  

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


                shin.x= shinx;
                shin.y = shiny;
                shin.x1 = shinxinvx;
                shin.y1 = shininvy;
            }
 
         
        }
        public class Peca
        {
            public float width;
            public float height;
            public float z;
            public float scale;
            public Peca()
            {
                this.scale = 1f;

                this.width = 100;
                this.height = 100;
                this.z = -10;
            }

            public void UpdateSize(TextBox x, TextBox y, TextBox z)
            {
                float xx;
                float yy;
                float zz;
                if (float.TryParse(x.Text, out xx))
                {
                    if (float.TryParse(y.Text, out yy))
                    {

                        if (float.TryParse(z.Text, out zz))
                        {

                            this.width = xx * scale;
                            this.height = yy * scale;
                            this.z = zz;
                        }
                    }
                }
                
            }
        }

        public class Shindashi
        {
            public float x;
            public float y;
            
            public float x1;//inverso
            public float y1;//inverso
            public Shindashi()
                {this.x = 500;
                this.y = 350;
                this.x1 = 500;
                this.y1 = 350;
                    }
            public void UpdateShindashi(TextBox xx, TextBox yy)
            {
                string valorx = xx.Text;
                string valory = yy.Text;
                float xxx;
                float yyy;
                if(float.TryParse(valorx, out xxx))
                {
                    this.x = xxx;
                }
                if(float.TryParse(valory, out yyy))
                {
                    this.y = yyy;
                }
            }
        }
    

    }

}
