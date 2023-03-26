using Krisiun_Project.Janelas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            string tamanho = "品物のサイズ:" + peca.sizex.ToString() + "-" + peca.sizey + "-" + peca.sizez;
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
                html = html.Replace("{ZAIROU}", tamanho);
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
        public void tejunlista(BindingList<Ferramentas> ferramentaslist, BindingList<Ferramentas> mentorilist, int num, string lado, bool kousoki)
        {
            string nomeArquivo = "TejunLista.html";
            string pastadosoft = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
            string caminhoCompleto = Path.Combine(pastadosoft, nomeArquivo);
            string hinmei = peca.hinmei;
            string zuban = peca.zuban;
            string subtitulo = num.ToString() + "-" + lado;
         


            // Agrupar mentorilist por TipoDeCutter
            var groupedMentoriList = mentorilist.GroupBy(x => x.Mentori.TipoDeCutter);

            // Dicionário para armazenar os menores valores e seus pares para cada TipoDeCutter
            Dictionary<TiposdeMentori, Tuple<float, float>> minValuesByType = new Dictionary<TiposdeMentori, Tuple<float, float>>();

            // Encontrar o menor valor de Z2 e o seu par (Z) para cada grupo
            foreach (var group in groupedMentoriList)
            {
                var minZ2Item = group.Aggregate((minItem, nextItem) => nextItem.Mentori.Z2 < minItem.Mentori.Z2 ? nextItem : minItem);

                float minZ2 = minZ2Item.Mentori.Z2;
                float minZ = minZ2Item.Mentori.Z;

                minValuesByType.Add(group.Key, Tuple.Create(minZ2, minZ));
            }


        

            int numpro = 1;
            int kosuu = 0;

            if (File.Exists(caminhoCompleto))
            {
                string html = File.ReadAllText(caminhoCompleto);
                html = html.Replace("{HINMEI}", hinmei);
                html = html.Replace("{ZUBAN}", zuban);
                html = html.Replace("{SUBTITULO}", subtitulo);
                // Adicione o atributo style com a largura desejada na tag <img> do arquivo HTML

                string pasta = pastas.CaminhoRaiz;
                string nomeArquivo1 = subtitulo + " - 手順書Pag2" + ".html";
                if (kousoki == true) { nomeArquivo1 = subtitulo + " - 手順書Pag2" + " - 高速" + ".html"; }
                string caminhoCompleto1 = Path.Combine(pasta, nomeArquivo1);
                if (!string.IsNullOrEmpty(html))
                {   // Criar tabela HTML com base na lista de objetos
                    StringBuilder tabelaHtml = new StringBuilder();
                    tabelaHtml.Append("<table class=\"small-table\">");
                    tabelaHtml.Append("<tr><th style=\"width: 50px;\">N</th>" + //1
                        "<th style=\"width: 30px;\">個数</th>" + //2
                         "<th style=\"width: 30px;\">ツール番号</th>" +//3
                        "<th style=\"width: 50px;\">ツール</th>" + //4
                        "<th style=\"width: 50px;\">径</th>" + //5
                        "<th style=\"width: 150px;\">加工案内</th>" + //6
                        "<th style =\"width: 50px;\">深さ</th>" + //7

                        "<th style =\"width: 150px;\">条件-" + peca.Material.Name.ToString() + "</th></tr>" //8

                        );

                    foreach (var objeto in ferramentaslist)
                    {
                        if (objeto.CoordenadasList != null)
                        {
                            kosuu = objeto.CoordenadasList.Count();
                        }
                        tabelaHtml.Append("<tr>");
                        tabelaHtml.Append($"<td>{numpro}</td>");//1

                        tabelaHtml.Append($"<td>{kosuu}</td>");//2
                        if (kousoki == true)
                        {
                            tabelaHtml.Append($"<td>{"T" + objeto.ToolNumberK}</td>");//3
                        }
                        else
                        {
                            tabelaHtml.Append($"<td>{"T" + objeto.ToolNumber}</td>");
                        }//3
                        tabelaHtml.Append($"<td>{objeto.ToolName}</td>");//4
                        tabelaHtml.Append($"<td>{"φ" + objeto.Kei}</td>");//5
                        tabelaHtml.Append("<td>"); // Início da célula da coluna 加工案内
                        if (objeto is Mentori mentori)
                        {
                            tabelaHtml.Append("<table style=\"border: none;\">"); // Tabela para informações do objeto Mentori
                            foreach (var item in mentorilist)
                            {
                                tabelaHtml.Append("<tr><td style=\"border: none; font-size: 8px;\">");
                                if(item.Mentori.TipoDeCutter == mentori.TipoDeCutter) { 
                                tabelaHtml.Append($"{"Ø" + item.Kei + "/(" + item.Mentori.MenKei + ") - C" + item.Mentori.C + "/ Z" + item.Mentori.Z + "(+" + item.Mentori.Dansa + ")"}</td></tr>");
                                }
                            }
                            tabelaHtml.Append("</table>"); // Fim da tabela para informações do objeto Mentori
                        }
                        if (objeto is MentoriB mentorib)
                        {
                            tabelaHtml.Append("<table style=\"border: none;\">"); // Tabela para informações do objeto Mentori
                            foreach (var item in mentorilist)
                            {
                                tabelaHtml.Append("<tr><td style=\"border: none; font-size: 8px;\">");
                                if(item.MentoriB.TipoDeCutter == mentorib.TipoDeCutter)
                                { 
                                tabelaHtml.Append($"{"Ø" + item.Kei + "/(" + item.MentoriB.MenKei + ") - C" + item.MentoriB.C + "/ Z" + item.MentoriB.Z + "(+" + item.MentoriB.Dansa + ")"}</td></tr>");
                                }
                            }
                            tabelaHtml.Append("</table>"); // Fim da tabela para informações do objeto Mentori
                        }
                        else
                        {
                            tabelaHtml.Append($"{objeto.Description}");
                        }
                        tabelaHtml.Append("</td>"); // Fim da célula da coluna 加工案内
                        if (objeto is Drills drills)
                        {
                            tabelaHtml.Append($"<td>{drills.Fukasa + "(" + drills.Z + ")"}</td>"); //7
                        }
                        else if(objeto is Mentori mentoric )
                        {
                            var minValues = minValuesByType[mentoric.TipoDeCutter];
                            tabelaHtml.Append($"<td>{minValues.Item2 + "(" + minValues.Item1 + ")"}</td>");

                        }
                        else if (objeto is MentoriB mentorid)
                        {
                            var minValues = minValuesByType[mentorid.TipoDeCutter];
                            tabelaHtml.Append($"<td>{minValues.Item2 + "(" + minValues.Item1 + ")"}</td>");

                        }
                        else
                        {
                            tabelaHtml.Append($"<td>{objeto.Fukasa}</td>");//7
                        }
                        tabelaHtml.Append("<td><table style=\"border: 1px solid black;\"><tr><td style=\"border: 1px solid black; font-size: 8px;\">");//8
                        tabelaHtml.Append($"{"S" + objeto.Kaiten}</td></tr><tr><td style=\"border: 1px solid black; font-size: 8px;\">");//8
                        tabelaHtml.Append($"{"F" + objeto.Okuri}</td></tr></table></td>");//8
                        tabelaHtml.Append(" </tr>");
                        numpro++;
                    }

                    tabelaHtml.Append("</table>");

                    // Substituir marcador {TABELA} com a tabela HTML gerada
                    html = html.Replace("{TABELA}", tabelaHtml.ToString());



                    using (StreamWriter sw = File.CreateText(caminhoCompleto1))
                    {
                        sw.Write(html);
                    }
                }
            }
        }

  
    }


}
