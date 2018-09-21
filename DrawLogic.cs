using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace LR_2
{
    class DrawLogic
    {
        public static void DrawLine(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            if (x1 > x2)
            {
                int tmp = x1; x1 = x2; x2 = tmp;
                tmp = y1; y1 = y2; y2 = tmp;
            }
            float L = Math.Max(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            int diffx = x2 - x1;
            float diffy = y2 - y1;
            float dy = diffy / L;
            float dx = diffx / L;
            float x=x1, y=y1;
            for (int i = 0; i <= L; i++)
            { 
                x += dx;
                y += dy;
                bmp.SetPixel((int)x, (int)y, color);
            }
        }
        public static void DrawPieBr(Bitmap bmp, Color color, int x1, int y1, int x2, int y2)
        {
            
        }
        public static void FillEllipse(Bitmap bmp, int x, int y, int _x, int _y)
        {
            for (int g = y - _y; g < y + _y; g++)
            {
                for (int i = x - _x; i < x + _x; i++)
                {
                    bmp.SetPixel(i, g, Color.Orange);
                }
            }
        }
        public static void UseForEllipse(Bitmap bmp, int x, int y, int _x, int _y, Color color)
        {
            bmp.SetPixel(x + _x, y + _y, color);
            bmp.SetPixel(x + _x, y - _y, color);
            bmp.SetPixel(x - _x, y - _y, color);
            bmp.SetPixel(x - _x, y + _y, color);
        }
        public static void DrawEllipseBr(Bitmap bmp, Color color, int x, int y, int a, int b)
        {
            int _x = 0; 
            int _y = b; 
            int a_sqr = a * a; 
            int b_sqr = b * b; 
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) 
            {
                UseForEllipse(bmp, x, y, _x, _y, color);
                FillEllipse(bmp, x, y, _x, _y);
                if (delta < 0) 
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else 
                {
                    _x++;
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                }
            }
            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr * 
                    ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr;
            while (_y + 1 != 0) 
            {
                UseForEllipse(bmp, x, y, _x, _y, color);
                FillEllipse(bmp, x, y, _x, _y);
                if (delta < 0)
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else 
                {
                    _y--;
                    delta = delta - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3);
                    _x++;
                }
            }
        }
        public static void DrawEllipseDDA(Bitmap bmp, Color color, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            double delta = b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                (2 * _y - 1) * (2 * _y - 1)/4 - a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                UseForEllipse(bmp, x, y, _x, _y, color);
                FillEllipse(bmp, x, y, _x, _y);
                if (delta < 0)
                {
                    _x++;
                    delta = delta/4 + b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    delta = delta/4 - 2 * a_sqr * (_y - 1) + b_sqr * (2 * _x + 3);
                    _y--;
                }
            }
            delta = b_sqr * (2 * _x + 1) * (2 * _x + 1)/4 + 4 * a_sqr *
                    (_y + 1) * (_y + 1) - a_sqr * b_sqr;
            while (_y + 1 != 0)
            {
                UseForEllipse(bmp, x, y, _x, _y, color);
                FillEllipse(bmp, x, y, _x, _y);
                if (delta < 0)
                {
                    _y--;
                    delta = delta/4 + a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--;
                    delta = delta/4 - 2 * b_sqr * (_x + 1) +  a_sqr * (2 * _y + 3);
                    _x++;
                }
            }
        }
        public static void DrawEllipseBy(Bitmap bmp, Color color, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int dx = x++;
            int dy = y--;
            int a_sqr = a * a;
            int b_sqr = b * b;
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                UseForEllipse(bmp, x, y, _x, _y, color);               
                if (delta < 0)
                {                    
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    UseForEllipse(bmp, x, y, _x, _y, Color.Gray);
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                    UseForEllipse(bmp, x, y, _x - 1, _y, Color.Gray);                   
                }
            }
            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr *
                    ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr;
            while (_y + 1 != 0)
            {
                UseForEllipse(bmp, x, y, _x, _y, color);
                if (delta < 0)
                {
                    _y--;
                    delta += 4 * a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--;
                    UseForEllipse(bmp, x, y, _x, _y, Color.Gray);
                    delta = delta - 8 * b_sqr * (_x + 1) + 4 * a_sqr * (2 * _y + 3);
                    _x++;
                    UseForEllipse(bmp, x, y, _x, _y + 1, Color.Gray);
                }
            }
        }
    }
}
