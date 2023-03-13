using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
    public class Pastas
    {
        public static string PastaRaiza;
        public static string Pasta56MB;
        public static string PastaOKK;
        public static string Pasta46;
        public string CaminhoO56 { get; set; }
        public string CaminhoO46 { get; set; }
        public string CaminhoOKK { get; set; }
        public string CaminhoRaiz { get; set; } 

        public Pastas()
        {
            PastaRaiza = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            Pasta56MB = "OkumaMB56";
            PastaOKK = "OKK76VM";
            Pasta46 = "Okuma46VA";


        }


        public  void CriarPastas(string hinnem, string zuban)
        {
            //Obtém o caminho da pasta raiz do aplicativo
            string pastaRaiz = PastaRaiza;

            //Cria uma pasta com o nome da classe MinhaClasse
            string nomePasta = hinnem + "-" +zuban + "-" + DateTime.Now.ToString("yyyyMMdd");
            string pastaMinhaClasse = Path.Combine(pastaRaiz, nomePasta);
            Directory.CreateDirectory(pastaMinhaClasse);

            //Cria as subpastas dentro da pasta MinhaClasse
            Directory.CreateDirectory(Path.Combine(pastaMinhaClasse, Pasta56MB));
            Directory.CreateDirectory(Path.Combine(pastaMinhaClasse, Pasta46));
            Directory.CreateDirectory(Path.Combine(pastaMinhaClasse, PastaOKK));
            this.CaminhoO46 = Path.Combine(pastaMinhaClasse, Pasta46).ToString();
            this.CaminhoO56 = Path.Combine(pastaMinhaClasse, Pasta56MB).ToString();
            this.CaminhoOKK = Path.Combine(pastaMinhaClasse, PastaOKK).ToString();
            this.CaminhoRaiz = nomePasta;
         
        }
    }


}
