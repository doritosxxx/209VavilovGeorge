using System;
using System.Linq;
using System.Collections.Generic;

namespace task4
{
    class Robot
    {
        int x, y;

        public void Right() { x++; }
        public void Left() { x--; }
        public void Forward() { y++; }
        public void Backward() { y--; }

        public string Position()
        {
            return $"The Robot position: x={x}, y={y}";
        }
    }
    class Program
    {
        delegate void Steps();

        static void Main(string[] args)
        {
            Robot robot = new Robot();

            // Main task.

            string encodedPath = Console.ReadLine();
            Steps path = null;

            foreach (char command in encodedPath)
                path += command switch {
                    'R' => robot.Right,
                    'L' => robot.Left,
                    'F' => robot.Forward,
                    'B' => robot.Backward,
                    _   => throw new ArgumentException("bruh")
                };

            Console.WriteLine(robot.Position());
            path();
            Console.WriteLine(robot.Position());

        }
    }
}
