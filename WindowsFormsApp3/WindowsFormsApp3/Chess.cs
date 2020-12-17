using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Chess
    {
        private int x;
        private int y;
        private string color;
        public Chess(int xx,int yy,string colorr)
        {
            x = xx;
            y = yy;
            color = colorr;
        }
        public int GetX()
        {
            return x;
        }
        public int GetY()
        {
            return y;
        }
        public string GetColor()
        {
            return color;
        }
        public void SetX(int xx)
        {
            x = xx;
        }
        public void SetY(int yy)
        {
            y = yy;
        }
        public void SetColor(string colorr)
        {
            color = colorr;
        }

    }
}
