using System;
using System.Collections.Generic;
using ArchProj2.Entities;

namespace ArchProj2.DAL
{
    public interface ITriangleRepo
    {
        Triangle Add(Triangle triangle);

        Triangle Update(int id, Triangle triangle);

        List<Triangle> GetAll();

        Boolean Delete(int id);

    }
}
