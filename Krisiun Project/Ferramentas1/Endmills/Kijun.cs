using System;
using System.Collections.Generic;
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


        public StringBuilder kijunkakou(Kijunmen kijunmen, Pitch_principal.Peca peca, RadioButton front, RadioButton back, RadioButton right, RadioButton left)
        {
            StringBuilder kijun_code = new StringBuilder();
            float haba = kijunmen.KijunHaba/ 2;
            float anzen = kijunmen.KijunAnzen;
            float kei = kijunmen.Kijunkei / 2;
            float y = kijunmen.KijunHaba;
            float z = kijunmen.KijunZ;
            float okuri = kijunmen.Kijunokuri;
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




                return kijun_code.ToString();


            }
        }
    }
}
