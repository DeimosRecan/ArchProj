using System;
using System.Collections.Generic;
using ArchProj2.Entities;

namespace ArchProj2.BLL
{
    public interface ITriangleLogic
    {
        Triangle Create(Point a, Point b, Point c);

        List<Triangle> FindAll();

        Triangle Update(int Id, Point a, Point b, Point c);

        Boolean Delete(int Id);

        Triangle Find(int Id);

        double getPerimeter(Triangle triangle);

        double getArea(Triangle triangle);
    }
}