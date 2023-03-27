using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Krisiun_Project.Dados_Aleatorios1
{
    public class TiposdeTap
    {
        public string Unidade { get; set; }
        public int ToolNumber { get; set; }
        public string Descricao { get; set; }
        public float Diametro { get; set; }
        public float Pitch { get; set; }
        public float ShitaAna { get; set; }
        public int Kaiten { get; set; }
        public int Okuri { get; set; }
        public float Q { get; set; }
        public float K { get; set; }

        public static List<TiposdeTap> TapMM { get; set; } = new List<TiposdeTap>();
       
        public static List<TiposdeTap> TapInch { get; set; } = new List<TiposdeTap>();

        public TiposdeTap(int tool, string unidade, string descricao, float diametro, float pitch, float shitaAna, int kaiten, int okuri, float q, float k)
        {
            ToolNumber = tool;
            Unidade = unidade;
            Descricao = descricao;
            Diametro = diametro;
            Pitch = pitch;
            ShitaAna = shitaAna;
            Kaiten = kaiten;
            Okuri = okuri;
            Q = q;
            K = k;

        }
        public static void CriarListas()
        {
            TapMM = LoadTapList("mm", "tapmm.csv");
            TapInch = LoadTapList("inch", "tapinch.csv");
        }
        public static List<TiposdeTap> LoadTapList(string unidade, string file)
        {
            List<TiposdeTap> listaDeTap = new List<TiposdeTap>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = file;
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                reader.ReadLine();
                int okuri = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    int tool = int.Parse(parts[0], CultureInfo.InvariantCulture);
                    string descricao = parts[1].ToString();
                    float diametro = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    float pitch = float.Parse(parts[3], CultureInfo.InvariantCulture);
                    float shitaana = float.Parse(parts[4], CultureInfo.InvariantCulture);
                    int kaiten = int.Parse(parts[5], CultureInfo.InvariantCulture);
                    if(unidade == "mm")
                    {
                        okuri = int.Parse(parts[6], CultureInfo.InvariantCulture);
                    }
                    if(unidade == "inch")
                    {
                        string[] tipo = parts[1].Split(new char[] { '-' });
                        string valorinch = tipo[1].ToString();
                        string valorinchSomenteNumeros = Regex.Replace(valorinch, @"[^\d.]", "");
                        float inchpich = float.Parse(valorinchSomenteNumeros);
                        inchpich = (float)Math.Round(25.4f / inchpich, 3);
                        inchpich = kaiten * inchpich;
                        okuri = Convert.ToInt32(inchpich);
                    }
                    float q = float.Parse(parts[7], CultureInfo.InvariantCulture);
                    float k = float.Parse(parts[8], CultureInfo.InvariantCulture);
                    //  MessageBox.Show(tool + "," + diametro.ToString() +"," + profundidade.ToString() + "," + kaiten.ToString() + "," + okuri.ToString() + "," + kataban + "," + largura.ToString() + "," + tsukidashi.ToString() );
                    listaDeTap.Add(new TiposdeTap(tool, unidade,descricao, diametro, pitch, shitaana, kaiten, okuri,q,k));
                }

            }

            //MessageBox.Show($"Número de elementos na listaDeMentori: {listaDeMentori.Count}");
            //for (int i = 0; i < listaDeMentori.Count; i++)
            //{ 
            //MessageBox.Show(listaDeMentori[i].Tool + "," + listaDeMentori[i].Diametro.ToString() + "," + listaDeMentori[i].Profundidade.ToString() + "," + listaDeMentori[i].Kaiten.ToString() + "," + listaDeMentori[i].Okuri.ToString() + "," + listaDeMentori[i].Kataban + "," + listaDeMentori[i].Largura.ToString() + "," + listaDeMentori[i].TsukidashiMax.ToString());
            //}
            return listaDeTap;
        }


    }

}
