﻿using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Krisiun_Project.G_Code
{
    internal class Mentori : Ferramentas
    {

        public TiposdeMentori Tipo { get; set; }
        public Ferramentas Lugar { get; set; }
        public float Z { get; set; }    
        public float Kei { get; set; }  
        public float C { get; set; }
        public float Dansa { get; set; }
        public float Diametro { get; set; }
        public float Profundidade { get; set; }
        public int Largura { get;set; }
        public List<Ferramentas> MenFrente { get; set; }
        public List<Ferramentas> MenTras { get;set; }
        
        public Mentori(Pitch_principal.Peca peca) : base(peca)
        {
            MenFrente = new List<Ferramentas> { };
            MenTras = new List<Ferramentas> { };
        }
    }

    public class TiposdeMentori
    {
        public string Tool { get; set; }
        public float Diametro { get; set; }
        public float Profundidade { get; set; }
        public int Kaiten { get; set; }
        public int Okuri { get; set; }
        public string Kataban { get;set; }
        public int Largura { get; set; }
        public float TsukidashiMax { get; set; }


        public TiposdeMentori(string tool, float diametro, float profundidade, int kaiten, int okuri, string kataban, int largura, float tsukidashiMax)
        {
            Tool = tool;
            Diametro = diametro;
            Profundidade = profundidade;
            Kaiten = kaiten;
            Okuri = okuri;
            Kataban = kataban;
            Largura = largura;
            TsukidashiMax = tsukidashiMax;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            TiposdeMentori other = (TiposdeMentori)obj;
            return Tool.Equals(other.Tool);
        }

        public override int GetHashCode()
        {
            return Tool.GetHashCode();
        }

        public static List<TiposdeMentori> LoadMentoriCuter()
        {
            List<TiposdeMentori> listaDeMentori = new List<TiposdeMentori>();
            string dir = Path.GetDirectoryName(Application.ExecutablePath);
            string ar = "ListadeMentori.csv";
            string filePath = Path.Combine(dir, ar);
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Pule o cabeçalho, se houver
                // reader.ReadLine();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');

                    string tool = parts[0].ToString();
                    float diametro = float.Parse(parts[1], CultureInfo.InvariantCulture);
                    float profundidade = float.Parse(parts[2], CultureInfo.InvariantCulture);
                    int kaiten = int.Parse(parts[3], CultureInfo.InvariantCulture);
                    int okuri = int.Parse(parts[4], CultureInfo.InvariantCulture);
                    string kataban = parts[5].ToString();
                    int largura = int.Parse(parts[6], CultureInfo.InvariantCulture);
                    float tsukidashi = float.Parse(parts[7], CultureInfo.InvariantCulture);

                    //  MessageBox.Show(tool + "," + diametro.ToString() +"," + profundidade.ToString() + "," + kaiten.ToString() + "," + okuri.ToString() + "," + kataban + "," + largura.ToString() + "," + tsukidashi.ToString() );
                    listaDeMentori.Add(new TiposdeMentori(tool, diametro, profundidade, kaiten, okuri, kataban, largura, tsukidashi));
                }

            }

            //MessageBox.Show($"Número de elementos na listaDeMentori: {listaDeMentori.Count}");
            //for (int i = 0; i < listaDeMentori.Count; i++)
            //{ 
            //MessageBox.Show(listaDeMentori[i].Tool + "," + listaDeMentori[i].Diametro.ToString() + "," + listaDeMentori[i].Profundidade.ToString() + "," + listaDeMentori[i].Kaiten.ToString() + "," + listaDeMentori[i].Okuri.ToString() + "," + listaDeMentori[i].Kataban + "," + listaDeMentori[i].Largura.ToString() + "," + listaDeMentori[i].TsukidashiMax.ToString());
            //}
            return listaDeMentori;
        }

    }
}
