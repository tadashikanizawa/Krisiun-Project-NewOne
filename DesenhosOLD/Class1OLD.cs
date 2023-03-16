using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krisiun_Project
{
    internal class Desenhartela: PictureBox
    {
        class Drawer
        {
            public void DrawSquare(Graphics g, Pen pen, int x, int y, int width, int height)
            {
                g.DrawRectangle(pen, x, y, width, height);
            }
        }
    }
}
