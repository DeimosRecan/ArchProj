using System;
using System.Collections.Generic;
using ArchProj2.DAL;
using ArchProj2.Entities;

namespace ArchProj2.BLL
{
    public class TriangleLogicImpl : ITriangleLogic
    {
        private readonly ITriangleRepo _triangleRepo;

        public TriangleLogicImpl() { }
        public TriangleLogicImpl(ITriangleRepo triangleRepo)
        {
            this._triangleRepo = triangleRepo;
        }

        public Triangle Create(Point a, Point b, Point c)
        {
            Triangle triangle = new Triangle(a, b, c);
            if (isTriangle(triangle))
            {
                return _triangleRepo.Add(triangle);
            }
            else
            {
                throw new Exception("NOT A TRIANGLE");
            }
        }

        public List<Triangle> FindAll()
        {
            return _triangleRepo.GetAll();
        }

        public Triangle Update(int Id, Point a, Point b, Point c)
        {
            Triangle triangleTemplate = new Triangle(a, b, c);
            return _triangleRepo.Update(Id, triangleTemplate);
        }

        public bool Delete(int Id)
        {
            return _triangleRepo.Delete(Id);
        }

        public Triangle Find(int Id)
        {
            List<Triangle> triangles = _triangleRepo.GetAll();
            foreach (Triangle item in triangles)
            {
                if (item.Id == Id)
                {
                    return item;
                }
            }

            return null;
        }

        public bool isTriangle(Triangle triangle)
        {
            Point[] mas = { triangle.a, triangle.b, triangle.c };
            double line1 = mas[0] - mas[1];
            double line2 = mas[1] - mas[2];
            double line3 = mas[2] - mas[0];            
            if (line1 + line2 > line3 && line1 + line3 > line2 && line2 + line3 > line1)
            {
                return true;
            }
            return false;
        }

        public double getPerimeter(Triangle triangle)
        {
            Point[] mas = { triangle.a, triangle.b, triangle.c };
            double line1 = mas[0] - mas[1];
            double line2 = mas[1] - mas[2];
            double line3 = mas[2] - mas[0];
            double P = line1 + line2 + line3;
            return P ;
        }

        public double getArea(Triangle triangle)
        {
            Point[] mas = { triangle.a, triangle.b, triangle.c };
            double line1 = mas[0] - mas[1];
            double line2 = mas[1] - mas[2];
            double line3 = mas[2] - mas[0];
            double p = getPerimeter(triangle) / 2;
            double s = Math.Sqrt(p*(p - line1)*(p - line2)*(p - line3));
            return s;
        }
    }
}