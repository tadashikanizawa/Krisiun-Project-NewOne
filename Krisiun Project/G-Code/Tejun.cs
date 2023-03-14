using Krisiun_Project.Janelas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.UI.HtmlControls;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
    internal class Tejun
    {
        private Ferramentas ferramentas;
        private Form5 form5;
        private Pitch_principal.Peca peca;
        private Pastas pastas;


        public Tejun(Ferramentas ferramentas, Form5 form5, Pitch_principal.Peca peca, Pastas pastas)
        {
            this.ferramentas = ferramentas;
            this.form5 = form5;
            this.peca = peca;
            this.pastas = pastas;
  
        }
        public void teste()
        {
            string nomeArquivo = "Untitled-5.txt";
            string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);
            string hinmei = peca.hinmei;
            string zuban = peca.zuban;
            string imagem1 = Path.Combine(pastas.CaminhoRaiz, "Front.jpeg");
            //  MessageBox.Show(imagem);
            string imagemBase64 = "";
            using (Image imagem = Image.FromFile(imagem1))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imagem.Save(ms, imagem.RawFormat);
                    byte[] imagemBytes = ms.ToArray();
                    imagemBase64 = Convert.ToBase64String(imagemBytes);
                }
            }
            if (File.Exists(caminhoCompleto))
            {
                string html = File.ReadAllText(caminhoCompleto);
                html = html.Replace("{HINMEI}", hinmei);
                html = html.Replace("{ZUBAN}", zuban);
                html = html.Replace("{IMAGEN}", "data:image/jpeg;base64," + imagemBase64);
                string pasta = pastas.CaminhoRaiz;
                string nomeArquivo1 = "teste4.html";
                string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
                if (!string.IsNullOrEmpty(html))
                {
                    using (StreamWriter sw = File.CreateText(caminhoCompleto1))
                    {
                        sw.Write(html);
                    }
                }
            }
        }


        //public void teste()
        //{
        //    //string html = "<!DOCTYPE html>";
        //    //html += "<html>";
        //    //html += "<head>";
        //    //html += "<meta charset=\"UTF-8\">";
        //    //html += "<title>" + peca.hinmei + " - " + peca.zuban + "</title>";
        //    //html += "<style type=\"text/css\">";
        //    string html = "";
        //    string nomeArquivo = "Untitled-5";
        //    string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
        //    string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);

        //    if (File.Exists(caminhoCompleto))
        //    {
        //         html = File.ReadAllText(caminhoCompleto);
        //        // Use a string html como desejar
        //    }
        //    string pasta = pastas.CaminhoRaiz; 
        //    string nomeArquivo1 = "teste4.html";

        //    string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
        //    using (StreamWriter sw = File.CreateText(caminhoCompleto1))
        //    {
        //        sw.Write(html); // html é uma string contendo o conteúdo HTML que você quer salvar
        //    }

        //}
    }


}
