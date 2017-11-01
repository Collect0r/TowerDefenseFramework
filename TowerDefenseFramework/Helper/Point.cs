using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework.Helper
{
    class Point
    {
        public int Xi { get; private set; }
        public int Yi { get; private set; }
        public double Xd { get; private set; }
        public double Yd { get; private set; }

        public Point(double x, double y)
        {
            Xd = x;
            Yd = y;
            Xi = (int)Math.Round(x);
            Yi = (int)Math.Round(y);
        }
    }
}
