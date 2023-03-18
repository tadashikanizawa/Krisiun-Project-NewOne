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
        public void tejuncapa(int num, string lado, string pic)
        {
            string nomeArquivo = "Cabeca.txt";
            string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);
            string hinmei = peca.hinmei;
            string zuban = peca.zuban;
            string subtitulo = num.ToString() + "-" + lado;
            string imagem1 = Path.Combine(pastas.CaminhoRaiz, pic);
            //  MessageBox.Show(imagem);
            string imagemBase64 = "";
            int tamanhodaimagem = 500;
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

                html = html.Replace("{IMAGEN}", "data:image/jpeg;base64," + imagemBase64);
                // Adicione o atributo style com a largura desejada na tag <img> do arquivo HTML

                string pasta = pastas.CaminhoRaiz;
                string nomeArquivo1 = subtitulo + " - 手順書" + ".html";
                string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
                if (!string.IsNullOrEmpty(html))
                {   // Criar tabela HTML com base na lista de objetos
                    StringBuilder tabelaHtml = new StringBuilder();
                    tabelaHtml.Append("<table>");
                    tabelaHtml.Append("<tr><th style=\"width: 50px;\">ツール番号</th>" +
                        "<th style=\"width: 50px;\">ツール</th>" +
                        "<th style=\"width: 50px;\">径</th>" +
                        "<th style =\"width: 50px;\">深さ</th>" +

                        "<th style =\"width: 150px;\">加工案内</th></tr>"

                        );

                    if(lado == "表加工") { 
                    foreach (var objeto in ferramentas.ListFrente)
                    {
                        tabelaHtml.Append("<tr>");

                        tabelaHtml.Append($"<td>{objeto.ToolNumber}</td>");
                        tabelaHtml.Append($"<td>{objeto.ToolName}</td>");
                        tabelaHtml.Append($"<td>{"φ" + objeto.Kei}</td>");

                        tabelaHtml.Append($"<td>{objeto.Fukasa}</td>");

                            tabelaHtml.Append("<td><table style=\"border: 1px solid black;\"><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                            tabelaHtml.Append($"{"S" + objeto.Kaiten}</td></tr><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                            tabelaHtml.Append($"{"F" + objeto.Okuri}</td></tr></table></td>");
                            tabelaHtml.Append(" </tr>");
                        }

                    tabelaHtml.Append("</table>");

                    // Substituir marcador {TABELA} com a tabela HTML gerada
                    html = html.Replace("{TABELA}", tabelaHtml.ToString());
                    }
                    if (lado == "裏加工")
                    {
                        foreach (var objeto in ferramentas.ListTras)
                        {
                            tabelaHtml.Append("<tr>");

                            tabelaHtml.Append($"<td>{objeto.ToolNumber}</td>");
                            tabelaHtml.Append($"<td>{objeto.ToolName}</td>");
                            tabelaHtml.Append($"<td>{"φ" + objeto.Kei}</td>");

                            tabelaHtml.Append($"<td>{objeto.Fukasa}</td>");
                            tabelaHtml.Append("<td><table style=\"border: 1px solid black;\"><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                            tabelaHtml.Append($"{"S" + objeto.Kaiten}</td></tr><tr><td style=\"border: 1px solid black; font-size: 8px;\">");
                            tabelaHtml.Append($"{"F" + objeto.Okuri}</td></tr></table></td>");
                            tabelaHtml.Append(" </tr>");
                        }

                        tabelaHtml.Append("</table>");

                        // Substituir marcador {TABELA} com a tabela HTML gerada
                        html = html.Replace("{TABELA}", tabelaHtml.ToString());
                    }
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
