using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode2021Day1
{
    public static class Day2
    {
        public static void Day2Go()
        {
            string[] text = System.IO.File.ReadAllLines(@"<path to puzzle input>");

            var h = 0;
            var d = 0;
            var aim = 0;

            foreach(var line in text)
            {
                string[] instruction = line.Split(' ');
                switch (instruction[0])
                {
                    case "forward":
                        h += Int32.Parse(instruction[1]);
                        d += (aim * Int32.Parse(instruction[1]));
                        break;
                    case "down":
                        aim+= Int32.Parse(instruction[1]);
                        break;
                    case "up":
                        aim-= Int32.Parse(instruction[1]);
                        break;
                }
            }

            Console.WriteLine(h*d);
        }
    }
}
