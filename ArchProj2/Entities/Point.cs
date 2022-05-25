using System;
using System.Collections.Generic;
using System.Text;

namespace ArchProj2.Entities
{
    [Serializable]
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public Point(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Point()
        {

        }
        public override String ToString()
        {
            return "(" + this.x + "," + this.y + "," + this.z + ")";
        }
        public static double operator -(Point point1, Point point2)
        {
            return Math.Sqrt(Math.Pow((point1.x - point2.x), 2) + Math.Pow((point1.y - point2.y), 2) + Math.Pow((point1.z - point2.z), 2));
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Point p = (Point)obj;
                return (x == p.x) && (y == p.y) && (z == p.z);
            }
        }
    }
}
