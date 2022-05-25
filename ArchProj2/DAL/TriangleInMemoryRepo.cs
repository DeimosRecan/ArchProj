using System;
using System.Collections.Generic;
using ArchProj2.Entities;

namespace ArchProj2.DAL
{
    public class TriangleInMemoryRepo : ITriangleRepo
    {
        private readonly List<Triangle> _triangles;
        private int _counter;

        public TriangleInMemoryRepo()
        {
            _triangles = new List<Triangle>();
            _counter = 0;
        }

        public Triangle Add(Triangle triangle)
        {
            if (triangle.Id.Equals(0))
            {
                triangle.Id = ++_counter;
                _triangles.Add(triangle);
                return triangle;
            }
            else
            {
                throw new Exception("Triangle already exists");
            }
        }

        public List<Triangle> GetAll()
        {
            return _triangles;
        }

        public Triangle Update(int Id, Triangle triangle)
        {
            foreach (Triangle b in _triangles)
            {
                if (b.Id == Id)
                {
                    b.Update(triangle);
                    return b;
                }
            }

            throw new Exception("Triangle is not found");
        }

        public bool Delete(int Id)
        {
            for (int i = 0; i < _triangles.Count; ++i)
            {
                if (_triangles[i].Id == Id)
                {
                    _triangles.RemoveAt(i);
                    --_counter;
                    return true;
                }
            }

            return false;
        }

    }
}