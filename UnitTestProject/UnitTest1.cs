using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArchProj2.Entities;
using ArchProj2.BLL;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using System;

namespace TestProject
{
    [TestClass]

    public class UnitTest1
    {
        public TriangleLogicImpl _triangleLogic = new TriangleLogicImpl();

        [TestMethod]
        public void IsTriangleTest() 
        {
            Triangle testTriangle = new Triangle(new Point(1, 4, 8), new Point(1, 4, 8), new Point(2, 5, 0));
            bool isTriangle = _triangleLogic.isTriangle(testTriangle);
            Assert.IsFalse(isTriangle);
        }
        [TestMethod]
        public void PerimeterTest() 
        {
            Triangle testTriangle = new Triangle(new Point(2, 1, 3), new Point(2, 0, 5), new Point(5, -1, 10));
            double ExpectedP = 16.026;
            double P = _triangleLogic.getPerimeter(testTriangle);
            Assert.AreEqual(ExpectedP, Math.Round(P, 3));
        }
        [TestMethod]
        public void AreaTest() 
        {
            Triangle testTriangle = new Triangle(new Point(-2, 1, 2), new Point(3, -3, 4), new Point(1, 0, 9));
            double ExpectedS = 19.786;
            double S = _triangleLogic.getArea(testTriangle);
            Assert.AreEqual(ExpectedS, Math.Round(S,3));
        }

        Triangle triangleTestObj; 
        String serializedTestString;

        [TestInitialize]
        public void Setup()
        {
            triangleTestObj = new Triangle(new Point(-1, 2, 4), new Point(2, 5, 8), new Point(3, 5, 8));
            serializedTestString =
            @"{""Id"":0,""a"":{""x"":-1,""y"":2,""z"":4},""b"":{""x"":2,""y"":5,""z"":8},""c"":{""x"":3,""y"":5,""z"":8}}";
        }
        [TestMethod]
        public void SerializeTest()
        {
            string jsonString = JsonSerializer.Serialize(triangleTestObj);
            //Console.WriteLine(jsonString);
            JToken actual = JToken.Parse(jsonString);
            JToken expected = JToken.Parse(serializedTestString);
            Assert.IsTrue(JToken.DeepEquals(actual, expected));
        }

        [TestMethod]
        public void DeserializeTest()
        {
            Triangle deserializedTriangle = JsonSerializer.Deserialize<Triangle>(serializedTestString)!;
            Console.WriteLine(deserializedTriangle);
            Assert.AreEqual(triangleTestObj, deserializedTriangle);
        }
    }
}