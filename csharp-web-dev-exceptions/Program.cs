using System;
using System.Collections.Generic;

namespace csharp_web_dev_exceptions
{
    internal class Program
    {

        static double Divide(double x, double y)
        {
            if (y == 0.0)
            {
                throw new ArgumentOutOfRangeException("y", "You cannot divide by zero!");
            }
            else
            {
                return x / y;
            }
        }

        static int CheckFileExtension(string fileName)
        {
            if (fileName == null || fileName == "")
            {
                throw new ArgumentNullException("fileName", "Student did not submit any work!");
            }
            else
            {
                if (fileName[^3..] == ".cs")
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }



        static void Main(string[] args)
        {
            double num1 = 100;
            double num2 = 0;
            try
            {
                Divide(num1, num2);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            // Test out your CheckFileExtension() function here!
            Dictionary<string, string> students = new Dictionary<string, string>();
            students.Add("Carl", "Program.cs");
            students.Add("Brad", "");
            students.Add("Elizabeth", "MyCode.cs");
            students.Add("Stefanie", "CoolProgram.cs");

            foreach (KeyValuePair<string, string> kvp in students)
            {
                int points = 0;
                try
                {
                    points = CheckFileExtension(kvp.Value);
                }
                catch (ArgumentNullException e)
                {
                    Console.Write(e.Message);
                }
                finally
                {
                    Console.WriteLine($"{kvp.Key} got {points} point{(points == 0 ? "s" : "")}.");
                }
            }
        }
    }
}
