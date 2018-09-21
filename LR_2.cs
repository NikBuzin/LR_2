using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_2
{
    public partial class LR_2 : Form
    {
        Graphics g;
        public LR_2()
        {
            InitializeComponent();
        }

        public void Draw(Graphics g, Rectangle r)
        {
            Bitmap bmp = new Bitmap(r.Width, r.Height);
            DrawPicture(bmp);
            g.DrawImage(bmp, r);
            bmp.Dispose();
        }

        public void DrawPicture(Bitmap bmp)
        {
            DrawLogic.DrawEllipseBr(bmp, Color.Black, 110, 60, 100, 50);
            DrawLogic.DrawEllipseDDA(bmp, Color.Black, 300, 60, 100, 50);
            DrawLogic.DrawEllipseBy(bmp, Color.Black, 500, 60, 100, 50);
        }
        private void LR_2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, e.ClipRectangle);
        }

    }
}
