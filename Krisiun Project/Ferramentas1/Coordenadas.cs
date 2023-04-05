using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krisiun_Project.G_Code
{
        public  class Coordenadas
        {
            public float X { get; set; }
            public float Y { get; set; }



        public static void LoadCoordinates(Ferramentas ferramenta, DataGridView dgv)
        {
            dgv.Rows.Clear();

            if (ferramenta != null && ferramenta.CoordenadasList != null)
            {
                foreach (PointF point in ferramenta.CoordenadasList)
                {
                    dgv.Rows.Add(point.X, point.Y);
                }
            }
        }
        public static void SaveChanges(Ferramentas ferramenta, DataGridView dgv)
        {
            // Salvar as alterações feitas nos controles nas propriedades do objeto
            // Exemplo: ferramenta.Propriedade1 = textBox1.Text;

            if (ferramenta != null)
            {
                ferramenta.CoordenadasList.Clear();
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        float x = float.Parse(row.Cells[0].Value.ToString());
                        float y = float.Parse(row.Cells[1].Value.ToString());
                        ferramenta.CoordenadasList.Add(new PointF(x, y));
                    }
                }
            }
        }


    }
    public class CoordenadasGrupo
        {
            public string Id { get; set; }
            public List<Coordenadas> Coordenadas { get; set; }

            public int cont = 1;

            public CoordenadasGrupo()
            {
            }
        }
    public class GrupoDeCoordenadas
    {
        public int Id { get; set; }
        public List<Coordenadas> Coordenadas { get; set; }
        public List<GrupoDeCoordenadas> ConverterDataGridViewParaObjeto(DataGridView dataGridView)
        {
            var grupos = new Dictionary<int, List<Coordenadas>>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var id = Convert.ToInt32(row.Cells["Id"].Value);

                if (!grupos.ContainsKey(id))
                {
                    grupos[id] = new List<Coordenadas>();
                }

                var coordenada = new Coordenadas
                {
                //   X = Convert.ToDouble(row.Cells["X"].Value),
                  //  Y = Convert.ToDouble(row.Cells["Y"].Value),
       
                };

                grupos[id].Add(coordenada);
            }

            var lista = new List<GrupoDeCoordenadas>();

            foreach (var grupo in grupos)
            {
                var objeto = new GrupoDeCoordenadas
                {
                    Id = grupo.Key,
                    Coordenadas = grupo.Value
                };

                lista.Add(objeto);
            }

            return lista;
        }
    }
   
}
