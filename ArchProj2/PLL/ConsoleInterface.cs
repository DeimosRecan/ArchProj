using System;
using System.Collections.Generic;
using System.Text;
using ArchProj2.BLL;
using ArchProj2.Entities;

namespace ArchProj2.PLL
{
    public class ConsoleInterface
    {
        private const string AddTriangle = "ADD";
        /*private static readonly string[] AddTriangleArgs = { "A_X", "A_Y", "A_Z", "B_X", "B_Y", "B_Z",
        "C_X", "C_Y", "C_Z",};*/
        private static readonly string[] AddTriangleArgs = { "A", "B", "C" };


        private const string GetPerimeter = "GETPERIMETER";
        private static readonly string[] GetP = { "ID" };

        private const string GetArea = "GETAREA";
        private static readonly string[] GetS = { "ID" };

        private const string GetTriangle = "GET";
        private static readonly string[] GetTriangleArgs = { "ID" };

        private const string GetTriangles = "GETALL";

        private const string UpdateTriangle = "UPDATE";
        private static readonly string[] UpdateTriangleArgs = { "ID", "NEW_A", "NEW_B", "NEW_C" };

        private const string DeleteTriangle = "DELETE";
        private static readonly string[] DeleteTriangleArgs = { "ID" };

        private const string Hint = "HINT";

        private const string cls = "CLS";

        private const string Exit = "EXIT";

        private const string UnknownCommand = "UNKNOWN COMMAND";
        private const string WrongArgument = "Wrong argument(s)";

        private readonly ITriangleLogic _triangleLogic;

        public ConsoleInterface(ITriangleLogic triangleLogic)
        {
            this._triangleLogic = triangleLogic;
        }

        public void Start()
        {
            Console.WriteLine(GetHint());
            for (; ; )
            {
                try
                {
                    Console.Write(">>> ");
                    List<String> arguments = new List<String>(Console.ReadLine().Split(" "));
                    string command = arguments[0].ToUpper();
                    arguments.RemoveAt(0);
                    switch (command)
                    {
                        case AddTriangle:
                            if (arguments.Count != AddTriangleArgs.Length * 3)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.Create(
                                    new Point(double.Parse(arguments[0]), double.Parse(arguments[1]), double.Parse(arguments[2])),
                                    new Point(double.Parse(arguments[3]), double.Parse(arguments[4]), double.Parse(arguments[5])),
                                    new Point(double.Parse(arguments[6]), double.Parse(arguments[7]), double.Parse(arguments[8]))));                                   
                            }

                            break;

                        case GetTriangle:
                            if (arguments.Count != GetTriangleArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.Find(Convert.ToInt32(arguments[0])));
                            }

                            break;

                        case GetTriangles:
                            Console.WriteLine(String.Join("\n", _triangleLogic.FindAll()));
                            break;
                        case UpdateTriangle:
                            if (arguments.Count != UpdateTriangleArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.Update(int.Parse(arguments[0]),
                                    new Point(double.Parse(arguments[1]), double.Parse(arguments[2]), double.Parse(arguments[3])),
                                    new Point(double.Parse(arguments[4]), double.Parse(arguments[5]), double.Parse(arguments[6])),
                                    new Point(double.Parse(arguments[7]), double.Parse(arguments[8]), double.Parse(arguments[9]))));
                            }

                            break;

                        case DeleteTriangle:
                            if (arguments.Count != GetTriangleArgs.Length)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.Delete(Convert.ToInt32(arguments[0])));
                            }

                            break;

                        case GetPerimeter:
                            if (_triangleLogic.Find(int.Parse(arguments[0])) == null)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.getPerimeter(_triangleLogic.Find(int.Parse(arguments[0]))));
                            }
                            break;

                        case GetArea:
                            if (_triangleLogic.Find(int.Parse(arguments[0])) == null)
                            {
                                Console.WriteLine(WrongArgument);
                            }
                            else
                            {
                                Console.WriteLine(_triangleLogic.getArea(_triangleLogic.Find(int.Parse(arguments[0]))));
                            }
                            break;


                        case Hint:
                            Console.WriteLine(GetHint());
                            break;
                        case Exit:
                            return;

                        case cls:
                            Console.Clear();
                            break;

                        default:
                            Console.WriteLine(UnknownCommand);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private static String GetHint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(AddTriangle).Append(": (COORDINATES OF) ").Append(String.Join(", ", AddTriangleArgs)).Append('\n');
            sb.Append(GetTriangles).Append('\n');
            sb.Append(GetTriangle).Append(": ").Append(String.Join(", ", GetTriangleArgs)).Append('\n');
            sb.Append(GetPerimeter).Append(": ").Append(String.Join(", ", GetP)).Append('\n');
            sb.Append(GetArea).Append(": ").Append(String.Join(", ", GetS)).Append('\n');
            sb.Append(UpdateTriangle).Append(": ").Append(String.Join(", ", UpdateTriangleArgs)).Append('\n');
            sb.Append(DeleteTriangle).Append(": ").Append(String.Join(", ", DeleteTriangleArgs)).Append('\n');
            ;
            sb.Append(Hint).Append('\n');
            sb.Append(cls).Append('\n');
            sb.Append(Exit).Append('\n');

            return sb.ToString();
        }
    }
}