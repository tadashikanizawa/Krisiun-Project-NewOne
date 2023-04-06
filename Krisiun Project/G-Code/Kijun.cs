using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Krisiun_Project.Ferramentas.Endmills
{
    public class Kijunmen
    {

        public string KijunNome { get; set; }
        public string KijunTipo { get; set; }
        public float KijunHaba { get; set; }
        public float KijunY { get; set; }
        public float KijunZ { get; set; }
        public float KijunAnzen { get; set; }
        public float KijunKei { get; set; }
        public float KijunChuushin { get; set; }
        public float KijunFukasa { get; set; }
        public float KijunKaiten { get; set; }
        public float KijunOkuri { get; set; }
        public float KijunRd { get; set; }
        public int KijunShiage { get; set; }

        //O do chatgpt
        public static StringBuilder GerarGCode(float diametroPeca, float diametroEndmill, float angulo, float profundidadePorPasso, int passagensAcabamento, float margemSeguranca)
        {
            float raioPeca = diametroPeca / 2;
            float raioEndmill = diametroEndmill / 2;
            double anguloRadianos = angulo * Math.PI / 180;

            StringBuilder gcode = new StringBuilder();

            float profundidadeAtual = profundidadePorPasso;

            while (profundidadeAtual <= raioPeca)
            {
                float raioEfetivo = raioPeca + raioEndmill - profundidadeAtual;
                float x = raioEfetivo * (float)Math.Cos(anguloRadianos);
                float y = raioEfetivo * (float)Math.Sin(anguloRadianos);

                gcode.AppendLine($"G01 X{x + margemSeguranca} Y0 F100"); // Movimento inicial com margem de segurança
                gcode.AppendLine($"G01 X{x} Y0 F100"); // Movimento inicial
                gcode.AppendLine($"G01 X{x} Y{y} F100"); // Movimento até o topo
                gcode.AppendLine($"G01 X{x} Y{-y} F100"); // Movimento até a base
                gcode.AppendLine($"G01 X{x + margemSeguranca} Y{-y} F100"); // Movimento final com margem de segurança

                profundidadeAtual += profundidadePorPasso;
            }

            // Passagens de acabamento
            for (int i = 0; i < passagensAcabamento; i++)
            {
                float raioEfetivo = raioPeca + raioEndmill - raioPeca;
                float x = raioEfetivo * (float)Math.Cos(anguloRadianos);
                float y = raioEfetivo * (float)Math.Sin(anguloRadianos);

                gcode.AppendLine($"G01 X{x + margemSeguranca} Y0 F100"); // Movimento inicial com margem de segurança
                gcode.AppendLine($"G01 X{x} Y0 F100"); // Movimento inicial
                gcode.AppendLine($"G01 X{x} Y{y} F100"); // Movimento até o topo
                gcode.AppendLine($"G01 X{x} Y{-y} F100"); // Movimento até a base
                gcode.AppendLine($"G01 X{x + margemSeguranca} Y{-y} F100"); // Movimento final com margem de segurança
            }

            return gcode;
        }
        public static List<PointF> CalcularTrajetoria(float diametroPeca, float diametroEndmill, float angulo)
        {
            float raioPeca = diametroPeca / 2;
            float raioEndmill = diametroEndmill / 2;
            float raioEfetivo = raioPeca + raioEndmill - 1; // Subtraia 1 mm para a fresagem

            double anguloRadianos = angulo * Math.PI / 180;

            float x = raioEfetivo * (float)Math.Cos(anguloRadianos);
            float y = raioEfetivo * (float)Math.Sin(anguloRadianos);

            List<PointF> pontos = new List<PointF>
        {
            new PointF(x, y),
            new PointF(x, -y)
        };

            return pontos;
        }
        public void DesenharTrajetoria(Graphics g, List<PointF> trajetoria, float offsetX, float offsetY)
        {
            // Ajusta a escala da trajetória
            float escala = 3;

            // Desenha a trajetória
            using (Pen pen = new Pen(Color.Black, 2))
            {
                for (int i = 0; i < trajetoria.Count - 1; i++)
                {
                    PointF pontoInicial = new PointF(trajetoria[i].X * escala + offsetX, trajetoria[i].Y * escala + offsetY);
                    PointF pontoFinal = new PointF(trajetoria[i + 1].X * escala + offsetX, trajetoria[i + 1].Y * escala + offsetY);
                    g.DrawLine(pen, pontoInicial, pontoFinal);
                }
            }
        }
        //O meu
        public static StringBuilder kijunkakou(Kijunmen kijunmen, Pitch_principal.Peca peca, RadioButton front, RadioButton back, RadioButton right, RadioButton left)
        {
            StringBuilder kijun_code = new StringBuilder();
            float haba = kijunmen.KijunHaba/ 2;
            float anzen = kijunmen.KijunAnzen;
            float kei = kijunmen.KijunKei / 2;
            float y = kijunmen.KijunHaba;
            float z = kijunmen.KijunZ;
            float okuri = kijunmen.KijunOkuri;
            float rb = kijunmen.KijunRd;
            float seihin = peca.height / 2;
            float pontodepartidax = haba + anzen + kei;
            float pontodepartiday = seihin + anzen + kei;
            float iniciodocorte = seihin + kei; //positivo
            y += kei;
            int shiage = kijunmen.KijunShiage;

            string s_pontodepartidax = pontodepartidax.ToString();
            string s_pontodepartiday = pontodepartiday.ToString();
            string s_z = z.ToString();
            string inicioy = iniciodocorte.ToString();
            string s_y = y.ToString();
            if (pontodepartidax % 1 == 0) { s_pontodepartidax = s_pontodepartidax + "."; }
            if (pontodepartiday % 1 == 0) { s_pontodepartiday = s_pontodepartiday + "."; }
            if (z % 1 == 0) { s_z = s_z + "."; }
            if (iniciodocorte % 1 == 0) { inicioy += "."; }
            if (y % 1 == 0) { s_y += "."; }

            if (front.Checked)
            {
                while (iniciodocorte > y)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X" + s_pontodepartidax + "Y-" + s_pontodepartiday + "\r\n" +
                                   "X" + s_pontodepartidax + "Y-" + s_pontodepartiday + "Z-" + s_z + "\r\n" +
                                   "G01X" + s_pontodepartidax + "Y-" + inicioy + "F500" + "\r\n" +
                                   "G01X-" + s_pontodepartidax + "Y-" + inicioy + "F" + okuri.ToString() + "\r\n" +
                                   "G0X-" + s_pontodepartidax + "Y-" + s_pontodepartiday + "\r\n" +
                                   "G0Z85." + "\r\n");
                    iniciodocorte = iniciodocorte - rb;

                };

                for (int i = 0; i < shiage; i++)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X" + s_pontodepartidax + "Y-" + s_pontodepartiday + "\r\n" +
                                   "X" + s_pontodepartidax + "Y-" + s_pontodepartiday + "Z-" + s_z + "\r\n" +
                                   "G01X" + s_pontodepartidax + "Y-" + s_y + "F500" + "\r\n" +
                                   "G01X-" + s_pontodepartidax + "Y-" + s_y + "F" + okuri.ToString() + "\r\n" +
                                   "G0X-" + s_pontodepartidax + "Y-" + s_pontodepartiday + "\r\n" +
                                   "G0Z85." + "\r\n");
                }
            }
            if (back.Checked)
            {
                while (iniciodocorte > y)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X-" + s_pontodepartidax + "Y" + s_pontodepartiday + "\r\n" +
                                   "X-" + s_pontodepartidax + "Y" + s_pontodepartiday + "Z-" + s_z + "\r\n" +
                                   "G01X-" + s_pontodepartidax + "Y" + inicioy + "F500" + "\r\n" +
                                   "G01X" + s_pontodepartidax + "Y" + inicioy + "F" + okuri.ToString() + "\r\n" +
                                   "G0X" + s_pontodepartidax + "Y" + s_pontodepartiday + "\r\n" +
                                   "G0Z85." + "\r\n");
                    iniciodocorte = iniciodocorte - rb;

                };

                for (int i = 0; i < shiage; i++)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X-" + s_pontodepartidax + "Y" + s_pontodepartiday + "\r\n" +
                                   "X-" + s_pontodepartidax + "Y" + s_pontodepartiday + "Z-" + s_z + "\r\n" +
                                   "G01X-" + s_pontodepartidax + "Y" + s_y + "F500" + "\r\n" +
                                   "G01X" + s_pontodepartidax + "Y" + s_y + "F" + okuri.ToString() + "\r\n" +
                                   "G0X" + s_pontodepartidax + "Y" + s_pontodepartiday + "\r\n" +
                                   "G0Z85." + "\r\n");
                }
            }
            if (right.Checked)
            {
                while (iniciodocorte > y)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X" + s_pontodepartiday + "Y" + s_pontodepartidax + "\r\n" +
                                   "X" + s_pontodepartiday + "Y" + s_pontodepartidax + "Z-" + s_z + "\r\n" +
                                   "G01X" + inicioy + "Y" + s_pontodepartidax + "F500" + "\r\n" +
                                   "G01X" + inicioy + "Y-" + s_pontodepartidax + "F" + okuri.ToString() + "\r\n" +
                                   "G0X" + s_pontodepartiday + "Y-" + s_pontodepartidax + "\r\n" +
                                   "G0Z85." + "\r\n");
                    iniciodocorte = iniciodocorte - rb;

                };

                for (int i = 0; i < shiage; i++)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X" + s_pontodepartiday + "Y" + s_pontodepartidax + "\r\n" +
                                   "X" + s_pontodepartiday + "Y" + s_pontodepartidax + "Z-" + s_z + "\r\n" +
                                   "G01X" + s_y + "Y" + s_pontodepartidax + "F500" + "\r\n" +
                                   "G01X" + s_y + "Y-" + s_pontodepartidax + "F" + okuri.ToString() + "\r\n" +
                                   "G0X" + s_pontodepartiday + "Y-" + s_pontodepartidax + "\r\n" +
                                   "G0Z85." + "\r\n");
                }
            }
            if (left.Checked)
            {
                while (iniciodocorte > y)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X-" + s_pontodepartiday + "Y-" + s_pontodepartidax + "\r\n" +
                                   "X-" + s_pontodepartiday + "Y-" + s_pontodepartidax + "Z-" + s_z + "\r\n" +
                                   "G01X-" + inicioy + "Y-" + s_pontodepartidax + "F500" + "\r\n" +
                                   "G01X-" + inicioy + "Y" + s_pontodepartidax + "F" + okuri.ToString() + "\r\n" +
                                   "G0X-" + s_pontodepartiday + "Y" + s_pontodepartidax + "\r\n" +
                                   "G0Z85." + "\r\n");
                    iniciodocorte = iniciodocorte - rb;

                };

                for (int i = 0; i < shiage; i++)
                {
                    s_pontodepartiday = pontodepartiday.ToString();
                    inicioy = iniciodocorte.ToString();
                    if (iniciodocorte % 1 == 0) { inicioy += "."; }
                    if (pontodepartiday % 1 == 0) { s_pontodepartiday += "."; }
                    kijun_code.AppendLine("X-" + s_pontodepartiday + "Y-" + s_pontodepartidax + "\r\n" +
                                   "X-" + s_pontodepartiday + "Y-" + s_pontodepartidax + "Z-" + s_z + "\r\n" +
                                   "G01X-" + s_y + "Y-" + s_pontodepartidax + "F500" + "\r\n" +
                                   "G01X-" + s_y + "Y" + s_pontodepartidax + "F" + okuri.ToString() + "\r\n" +
                                   "G0X-" + s_pontodepartiday + "Y" + s_pontodepartidax + "\r\n" +
                                   "G0Z85." + "\r\n");
                }



            }
            return kijun_code;
        }
    }
}
