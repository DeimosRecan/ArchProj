using System;
using System.Collections.Generic;
using System.Text;

namespace ArchProj2.Entities
{
    [Serializable]
    public class Triangle
    {
        public int Id { get; set; }
        public Point a { get; set; }
        public Point b { get; set; }
        public Point c { get; set; }

        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public Triangle()
        {

        }
        public void Update(Triangle triangle)
        {
            this.a = triangle.a ?? this.a;
            this.b = triangle.b ?? this.b;
            this.c = triangle.c ?? this.c;
        }
        public override string ToString()
        {
            return Id + " " + a + " " + b + " " + c;
        }
        public override bool Equals(object obj)
        {
            Triangle triangle = (Triangle)obj;
            return Id == triangle.Id &&
                   Equals(a, triangle.a) &&
                   Equals(b, triangle.b) &&
                   Equals(c, triangle.c);
        }
    }
}
