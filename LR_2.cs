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
            DrawLogic.DrawEllipseBr(bmp, Color.Black, Color.BlueViolet, 110, 60, 100, 50);
            DrawLogic.DrawEllipseDDA(bmp, Color.Black, Color.Orange, 325, 60, 100, 50);
            DrawLogic.DrawEllipseBy(bmp, Color.Black, Color.Orange, 550, 60, 100, 50);
            DrawLogic.DrawPieBrPart1(bmp, Color.Black, Color.Red, 110, 170, 100, 300);
            /*DrawLogic.DrawPieDDA(bmp, Color.Black, Color.Red, 325, 150, 100, 50, 3);
            DrawLogic.DrawPieBy(bmp, Color.Black, Color.Red, 550, 150, 100, 50, 3);*/
        }
        private void LR_2_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, e.ClipRectangle);
        }

        private void LR_2_Load(object sender, EventArgs e)
        {

        }
    }
}
