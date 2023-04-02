using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;

namespace sfml_list_example
{
    public static class MathLib2D
    {
        public static double TWO_PI = 6.2831853071795865;
        public static double RAD_TO_DEG = 57.2957795130823209;
        public static double bearing(Vector2f from, Vector2f to, bool radian=true)
        {
            if (from.X == to.X && from.Y == to.Y)
                throw new ArgumentException("from and to are the same. Cannot calculate a bearing between the same two points.");
            double theta = Math.Atan2(to.X - from.X, from.Y - to.Y);
            if (theta < 0.0)
                theta += TWO_PI;
            if (radian)
                return theta;
            return theta * RAD_TO_DEG;

        }

        public static double distance(Vector2f from, Vector2f to)
        {
            return Math.Sqrt(Math.Pow(to.X - from.X, 2) + Math.Pow(to.Y - from.Y, 2));
        }
    }
}
