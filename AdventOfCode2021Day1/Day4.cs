
namespace AdventOfCode2021Day1
{
    public static class Day4
    {
        private static readonly string[] text = System.IO.File.ReadAllLines(@"D:\Programs\AdventOfCode2021Day4.txt");
        public static void Part1()
        {
            var numbersToDraw = text[0].Split(',');

            var boards = new Dictionary<int[,], bool[,]>();
            foreach (var line in text)
            {
                if (line.Length <= 15 && !string.IsNullOrEmpty(line)) 
                {
                    var nums = line.Split(' ');
                    nums.ToList().ForEach(x => boards.Add(new int[5, 5]);
                }

            }

        }
    }
}
