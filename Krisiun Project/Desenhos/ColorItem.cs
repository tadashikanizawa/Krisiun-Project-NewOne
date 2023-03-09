using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Krisiun_Project.Desenhos
{

    public class ColorItem
    {
            public Color Color { get; set; }
            public string Name { get; set; }

            public ColorItem(Color color, string name)
            {
                Color = color;
                Name = name;
            }

            public override string ToString()
            {
                return Name;
            }
        

    }
}
