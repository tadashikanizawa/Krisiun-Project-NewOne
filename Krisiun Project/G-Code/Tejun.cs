using Krisiun_Project.Janelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public void tejuncapa(int num, string lado, string pic)
        {
            string nomeArquivo = "Cabeca.html";
            string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);
            string hinmei = peca.hinmei;
            string zuban = peca.zuban;
            string subtitulo = num.ToString() + "-" + lado;
            string imagem1 = Path.Combine(pastas.CaminhoRaiz, pic);
            //  MessageBox.Show(imagem);
            string imagemBase64 = "";
            int tamanhodaimagem = 1000;
    
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
                html = html.Replace("{TAMANHO}", tamanhodaimagem.ToString());
                html = html.Replace("{SUBTITULO}", subtitulo);
                html = html.Replace("{ZAITSU}", peca.Material.Name.ToString());
                html = html.Replace("{IMAGEN}", "data:image/jpeg;base64," + imagemBase64);
                // Adicione o atributo style com a largura desejada na tag <img> do arquivo HTML

                string pasta = pastas.CaminhoRaiz;
                string nomeArquivo1 = subtitulo + " - 手順書Pag1" + ".html";
                string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
              
                    
                
                    using (StreamWriter sw = File.CreateText(caminhoCompleto1))
                    {
                        sw.Write(html);
                    }
                
            }

        }
        public void tejunlista(BindingList<Ferramentas> ferramentaslist, int num, string lado)
        {
            string nomeArquivo = "TejunLista.html";
            string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);
            string hinmei = peca.hinmei;
            string zuban = peca.zuban;
            string subtitulo = num.ToString() + "-" + lado;
            
            //  MessageBox.Show(imagem);
 
            int numpro = 1;
            
            if (File.Exists(caminhoCompleto))
            {
                string html = File.ReadAllText(caminhoCompleto);
                html = html.Replace("{HINMEI}", hinmei);
                html = html.Replace("{ZUBAN}", zuban);
                html = html.Replace("{SUBTITULO}", subtitulo);
                // Adicione o atributo style com a largura desejada na tag <img> do arquivo HTML

                string pasta = pastas.CaminhoRaiz;
                string nomeArquivo1 = subtitulo + " - 手順書Pag2" + ".html";
                string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
                if (!string.IsNullOrEmpty(html))
                {   // Criar tabela HTML com base na lista de objetos
                    StringBuilder tabelaHtml = new StringBuilder();
                    tabelaHtml.Append("<table class=\"small-table\">");
                    tabelaHtml.Append("<tr><th style=\"width: 50px;\">N</th>" + //1
                        "<th style=\"width: 50px;\">ツール番号</th>" +  //2
                        "<th style=\"width: 50px;\">ツール</th>" + //3
                        "<th style=\"width: 50px;\">径</th>" + //4
                        "<th style=\"width: 50px;\">加工案内</th>" + //5
                        "<th style =\"width: 50px;\">深さ</th>" + //6

                        "<th style =\"width: 150px;\">条件" + peca.Material.Name.ToString() + "</th></tr>" //7

                        );


                    foreach (var objeto in ferramentaslist)
                    {
                        tabelaHtml.Append("<tr>");
                        tabelaHtml.Append($"<td>{numpro}</td>");//1
                        tabelaHtml.Append($"<td>{"T" + objeto.ToolNumber}</td>");//2
                        tabelaHtml.Append($"<td>{objeto.ToolName}</td>");//3
                        tabelaHtml.Append($"<td>{"φ" + objeto.Kei}</td>");//4
                        tabelaHtml.Append($"<td>{objeto.Description}</td>");//4

                        tabelaHtml.Append($"<td>{objeto.Fukasa}</td>");

                        tabelaHtml.Append("<td><table style=\"border: 1px solid black;\"><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                        tabelaHtml.Append($"{"S" + objeto.Kaiten}</td></tr><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                        tabelaHtml.Append($"{"F" + objeto.Okuri}</td></tr></table></td>");
                        tabelaHtml.Append(" </tr>");
                    }

                    tabelaHtml.Append("</table>");

                    // Substituir marcador {TABELA} com a tabela HTML gerada
                    html = html.Replace("{TABELA}", tabelaHtml.ToString());
                    numpro++;


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
