using System.Drawing;
using System.Windows.Forms;

namespace Krisiun_Project
{
    internal class Desenhartela : PictureBox
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
