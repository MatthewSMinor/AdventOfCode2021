namespace AdventOfCode2021Day1
{
    public static class Day1
    {
        public static void Day1Go()
        {
            string[] text = System.IO.File.ReadAllLines(@"<Path to puzzle input>");

            int timesIncreased = 0;

            int numberOfWindows = text.Length;

            for (int i = 0; i < numberOfWindows;)
            {
                try
                {
                    int previousSum = Int32.Parse(text[i]) + Int32.Parse(text[i + 1]) + Int32.Parse(text[i + 2]);
                    int currentSum = Int32.Parse(text[i + 1]) + Int32.Parse(text[i + 2]) + Int32.Parse(text[i + 3]);
                    if (previousSum < currentSum)
                    {
                        timesIncreased++;
                    }

                    i += 1;
                }
                catch (Exception ex)
                {
                    break;
                }
            }

            Console.WriteLine(timesIncreased);
        }
    }
}
