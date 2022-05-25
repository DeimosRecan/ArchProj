using System;
using ArchProj2.Entities;
using ArchProj2.DAL;
using ArchProj2.BLL;
using ArchProj2.PLL;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ArchProj2
{

    public class Program
    {
        static void Main(string[] args)
        {
            ITriangleRepo TriangleRepo = new TriangleInMemoryRepo();
            ITriangleLogic triangleLogic = new TriangleLogicImpl(TriangleRepo);
            ConsoleInterface consoleInterface = new ConsoleInterface(triangleLogic);
            consoleInterface.Start();

            /*Triangle triangle = triangleLogic.Create(new Point(-1, 2, 4), new Point(2, 5, 8), new Point(3, 5, 8));
            string jsonString = JsonSerializer.Serialize(triangle);
            Console.WriteLine(jsonString);
            Triangle triangle1 = JsonSerializer.Deserialize<Triangle>(jsonString);
            Console.WriteLine();
            Console.WriteLine(triangle1.ToString());*/
        }
    }
}