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
        public static void DrawLineForSeg(Bitmap bmp, Color color,  int x1, int y1, int x2, int y2)
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
            float x = x1, y = y1;
            for (int i = 0; i <= L; i++)
            {
                x += dx;
                y += dy;
                DrawLine(bmp, color, x1, (int)y, (int)x, (int)y);
            }
        }
        public static void DrawPieBrPart1(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, int arc)
        {
            int x = 0, y = R, gap = 0, delta = (2 - 2 * R);
            double n = 0;
            while (y >= 0)
            {                
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0) 
                {
                    x++;
                    delta += 2 * x + 1;
                    n++;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    n++;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                n++;
                y--;
            }
            double alf = n / 90;
            double something_n = 0;
            if(arc>=0)
            {
                something_n = alf * arc;
                DrawPieBrFirst(bmp, color, color2, x1, y1, R, something_n);
                if(arc>=90)
                {
                    something_n -= n; 
                    DrawPieBrSecond(bmp, color, color2, x1, y1, R, something_n);
                    if(arc>=180)
                    {
                        something_n -= n;
                        DrawPieBrThird(bmp, color, color2, x1, y1, R, something_n);
                        if(arc>=270)
                        {
                            something_n -= n;
                            DrawPieBrForth(bmp, color, color2, x1, y1, R, something_n);
                        }
                    }
                }
            }
        }
        public static void DrawPieBrFirst(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, double n)
        {
            int x = 0, y = R, gap = 0, delta = (2 - 2 * R);
            while ((n >= 0) && (y >= 0))
            {
                bmp.SetPixel(x1 + x, y1 - y, color);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    n--;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    n--;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                n--;
                y--;
            }
        }
        public static void DrawPieBrSecond(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, double n)
        {
            int x = R, y = 0, gap = 0, delta = (2 - 2 * R);
            while ((n >= 0) && (x >= 0))
            {
                bmp.SetPixel(x1 + x+2, y1 + y, color);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x--;
                    delta += 2 * x + 1;
                    n--;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y++;
                    delta -= 2 * y + 1;
                    n--;
                    continue;
                }
                x--;
                delta += 2 * ( x - y );
                n--;
                y++;
            }
        }
        public static void DrawPieBrThird(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, double n)
        {
            int x = 0, y = R, gap = 0, delta = (2 - 2 * R);
            while ((n >= 0) && (y >= 0))
            {
                bmp.SetPixel(x1 - x, y1 + y, color);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    n--;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    n--;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                n--;
                y--;
            }
        }
        public static void DrawPieBrForth(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, double n)
        {
            int x = R, y = 0, gap = 0, delta = (2 - 2 * R);
            while ((n >= 0) && (x >= 0))
            {
                bmp.SetPixel(x1 - x-3, y1 - y, color);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x--;
                    delta += 2 * x + 1;
                    n--;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y++;
                    delta -= 2 * y + 1;
                    n--;
                    continue;
                }
                x--;
                delta += 2 * (x - y);
                n--;
                y++;
            }
        }
        public static void DrawPieBrPart2(Bitmap bmp, Color color, Color color2, int x1, int y1, int R, int arc)
        {
            int x = 0, y = R, gap = 0, delta = (2 - 2 * R);
            while (y >= 0)
            {
                
                bmp.SetPixel(x1 + x, y1 - y, color);
                bmp.SetPixel(x1 + x, y1 + y, color);        
                bmp.SetPixel(x1 - x, y1 + y, color);
                bmp.SetPixel(x1 - x, y1 - y, color);
                gap = 2 * (delta + y) - 1;
                if (delta < 0 && gap <= 0)
                {
                    x++;
                    delta += 2 * x + 1;
                    continue;
                }
                if (delta > 0 && gap > 0)
                {
                    y--;
                    delta -= 2 * y + 1;
                    continue;
                }
                x++;
                delta += 2 * (x - y);
                y--;
            }
        }
        public static void DrawPieDDA(Bitmap bmp, Color color, Color color2, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            double delta = b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                (_y - 1 / 2) * (_y - 1 / 2) - a_sqr * b_sqr;
            while (a_sqr * (_y - 1 / 2) > b_sqr * (_x + 1))
            {
                DrawLine(bmp, color2, x, y + _y, x + _x , y + _y - 1);
                if (delta < 0)
                {
                    _x++;
                    delta = delta + b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    delta = delta - 2 * a_sqr * (_y - 1) + b_sqr * (2 * _x + 3);
                    _y--;
                }
            }
            DrawLineForSeg(bmp, color2, x, y, x + _x - 2, y + _y);
        }
        public static void DrawPieBy(Bitmap bmp, Color color, Color color2, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                DrawLine(bmp, color2, x, y + _y, x + _x-1, y + _y-1);
                if (delta < 0)
                {
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    bmp.SetPixel(x + _x, y + _y, Color.Gray);
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;
                    bmp.SetPixel(x + _x - 1, y + _y, Color.Gray);
                }
            }
            DrawLineForSeg(bmp, color2, x, y, x + _x-2, y + _y);
        }
        public static void FillEllipse(Bitmap bmp, int x, int y, int _x, int _y, Color color)
        {                       
            for (int i = x - _x+1; i < x + _x; i++)
            {
                bmp.SetPixel(i, y - _y + 1, color);
                bmp.SetPixel(i, y + _y - 1, color);
            }
        }
        public static void UseForEllipse(Bitmap bmp, int x, int y, int _x, int _y, Color color)
        {
            bmp.SetPixel(x + _x, y + _y, color);
            bmp.SetPixel(x + _x, y - _y, color);
            bmp.SetPixel(x - _x, y - _y, color);
            bmp.SetPixel(x - _x, y + _y, color);
        }
        public static void DrawEllipseBr(Bitmap bmp, Color color, Color color2, int x, int y, int a, int b)
        {
            int _x = 0; 
            int _y = b; 
            int a_sqr = a * a; 
            int b_sqr = b * b; 
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1)) 
            {
                FillEllipse(bmp, x, y, _x, _y, color2);
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
                FillEllipse(bmp, x, y, _x, _y, color2);
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
        public static void DrawEllipseDDA(Bitmap bmp, Color color, Color color2, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            double delta = b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                (_y - 1/2) * (_y - 1/2) - a_sqr * b_sqr;
            while (a_sqr * (_y - 1/2) > b_sqr * (_x + 1))
            {
                FillEllipse(bmp, x, y, _x, _y, color2);
                if (delta < 0)
                {
                    _x++;
                    delta = delta + b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    delta = delta - 2 * a_sqr * (_y - 1) + b_sqr * (2 * _x + 3);
                    _y--;
                }
            }
            delta = b_sqr * (_x + 1/2) * (_x + 1/2) + a_sqr *
                    (_y + 1) * (_y + 1) - a_sqr * b_sqr;
            while (_y + 1 != 0)
            {
                FillEllipse(bmp, x, y, _x, _y, color2);
                if (delta < 0)
                {
                    _y--;
                    delta = delta + a_sqr * (2 * _y + 3);
                }
                else
                {
                    _y--;
                    delta = delta - 2 * b_sqr * (_x + 1) +  a_sqr * (2 * _y + 3);
                    _x++;
                }
            }
        }
        public static void DrawEllipseBy(Bitmap bmp, Color color, Color color2, int x, int y, int a, int b)
        {
            int _x = 0;
            int _y = b;
            int a_sqr = a * a;
            int b_sqr = b * b;
            int delta = 4 * b_sqr * ((_x + 1) * (_x + 1)) + a_sqr *
                ((2 * _y - 1) * (2 * _y - 1)) - 4 * a_sqr * b_sqr;
            while (a_sqr * (2 * _y - 1) > 2 * b_sqr * (_x + 1))
            {
                FillEllipse(bmp, x, y, _x+2, _y, color);           
                if (delta < 0)
                {                    
                    _x++;
                    delta += 4 * b_sqr * (2 * _x + 3);
                }
                else
                {
                    _x++;
                    UseForEllipse(bmp, x, y, _x+1, _y-1, Color.Gray);
                    delta = delta - 8 * a_sqr * (_y - 1) + 4 * b_sqr * (2 * _x + 3);
                    _y--;                  
                }
            }
            delta = b_sqr * ((2 * _x + 1) * (2 * _x + 1)) + 4 * a_sqr *
                    ((_y + 1) * (_y + 1)) - 4 * a_sqr * b_sqr;
            while (_y + 1 != 0)
            {
                FillEllipse(bmp, x, y, _x+2, _y, color);
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
                    UseForEllipse(bmp, x, y, _x+1, _y, Color.Gray);
                }
            }
        }
    }
}
