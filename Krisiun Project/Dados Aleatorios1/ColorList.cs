using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krisiun_Project.Dados_Aleatorios1
{
    internal class ColorList
    {
        public Color Color { get; set; }
        public static List<Color> ListadeCores { get; set; } = new List<Color>();



        public static void AddColor()
        {
            ListadeCores.Add(Color.LightBlue);
            ListadeCores.Add(Color.LightCoral);
            ListadeCores.Add(Color.LightCyan);
            ListadeCores.Add(Color.LightGoldenrodYellow);
            ListadeCores.Add(Color.LightGray);
            ListadeCores.Add(Color.LightYellow);
            ListadeCores.Add (Color.LightGreen);
            ListadeCores.Add(Color.LightPink);
            ListadeCores.Add(Color.LightSalmon);
            ListadeCores.Add(Color.LightSeaGreen);
            ListadeCores.Add(Color.LightSkyBlue);
            ListadeCores.Add(Color.LightSlateGray);
            ListadeCores.Add(Color.LightSteelBlue);
            ListadeCores.Add(Color.LightYellow);
            ListadeCores.Add(Color.Lime);
            ListadeCores.Add(Color.LimeGreen);
            ListadeCores.Add(Color.Linen);
            ListadeCores.Add(Color.Magenta);
            ListadeCores.Add(Color.Maroon);
            ListadeCores.Add(Color.MediumAquamarine);
            ListadeCores.Add(Color.MediumBlue);
            ListadeCores.Add(Color.MediumOrchid);
            ListadeCores.Add(Color.MediumPurple);
            ListadeCores.Add(Color.MediumSeaGreen);
            ListadeCores.Add(Color.MediumSlateBlue);
            ListadeCores.Add(Color.MediumSpringGreen);
            ListadeCores.Add(Color.Red);
            ListadeCores.Add(Color.RosyBrown);
            ListadeCores.Add(Color.RoyalBlue);
            ListadeCores.Add(Color.SaddleBrown);
            ListadeCores.Add(Color.Salmon);
            ListadeCores.Add(Color.SandyBrown);
            ListadeCores.Add(Color.SeaGreen);


        }
    }


}
