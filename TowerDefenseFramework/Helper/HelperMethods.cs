using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefenseFramework.Helper
{
    static class HelperMethods
    {
        public static double distanceSq_double(Point A, Point B)
        {
            double dX = B.Xd - A.Xd;
            double dY = B.Yd - A.Yd;
            return dX * dX + dY * dY;
        }

        public static double distanceSq_int(Point A, Point B)
        {
            int dX = B.Xi - A.Xi;
            int dY = B.Yi - A.Yi;
            return dX * dX + dY * dY;
        }

        public static double distance_double(Point A, Point B)
        {
            double dX = B.Xd - A.Xd;
            double dY = B.Yd - A.Yd;
            return Math.Sqrt(dX * dX + dY * dY);
        }

        public static Point moveInDirection(Point currentPosition, double[] direction_normed, int speed, double timeDelta)
        {
            return new Point(currentPosition.Xd * speed * timeDelta * direction_normed[0], currentPosition.Yd * speed * timeDelta * direction_normed[1]);

        }

        public static double[] calcDirectionVector(Point from, Point to)
        {
            double dX = to.Xd - from.Xd;
            double dY = to.Yd - from.Yd;
            double length = Math.Sqrt(dX * dX + dY * dY);
            return new double[2] { dX / length, dY / length };
        }
    }
}
