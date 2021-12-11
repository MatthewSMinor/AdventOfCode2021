using System.Collections;
using System.Text;

namespace AdventOfCode2021Day1
{
    public static class Day3
    {
        private static readonly string[] text = System.IO.File.ReadAllLines(@"D:\Programs\testing.txt");

        public static void Part1()
        {
            BitArray gammaRate = new BitArray(12);
            var oneCounter = 0;
            var zeroCounter = 0;
            for (int i =0; i<gammaRate.Length;i++)
            {
                foreach (string line in text)
                {
                    if (line[i] == '1')
                        oneCounter++;
                    else
                        zeroCounter++;
                }

                if (oneCounter > zeroCounter)
                    gammaRate[i] = true;
                else
                    gammaRate[i] = false;

                if (i == 0)
                {
                    Console.WriteLine(oneCounter);
                }

                // reset counters
                oneCounter = 0;
                zeroCounter = 0;
            }

            StringBuilder gammaString = new StringBuilder();
            foreach(var bit in gammaRate)
            {
                gammaString.Append((bool)bit ? '1' : '0');
            }

            BitArray epsilon = gammaRate.Not();
            StringBuilder epsilonString = new StringBuilder();
            foreach(var bit in epsilon)
            {
                epsilonString.Append((bool)bit ? '1' : '0');
            }

            Console.WriteLine(gammaString.ToString() + " " + epsilonString.ToString());

            var gammaD = Convert.ToInt32(gammaString.ToString(), 2);
            var epsilonD = Convert.ToInt32(epsilonString.ToString(), 2);
            Console.WriteLine(gammaD * epsilonD);
        }

        public static void Part1Cleaner()
        {
            BitArray gammaArray = new BitArray(12);
            for (int i = 0; i < 12; i++)
            {
                gammaArray[i] = text.Select(x => int.Parse(x[i].ToString())).Sum() > text.Length / 2;
            }

            StringBuilder gammaString = new StringBuilder();
            foreach (var bit in gammaArray)
            {
                gammaString.Append((bool)bit ? '1' : '0');
            }

            BitArray epsilon = gammaArray.Not();
            StringBuilder epsilonString = new StringBuilder();
            foreach (var bit in epsilon)
            {
                epsilonString.Append((bool)bit ? '1' : '0');
            }
            var gammaD = Convert.ToInt32(gammaString.ToString(), 2);
            var epsilonD = Convert.ToInt32(epsilonString.ToString(), 2);

            Console.WriteLine(gammaD * epsilonD);
        }

        public static void Part2()
        {
            var oxyList = text.ToList();
            var scrubberList = text.ToList();
            var whatDo = false;

            for (int i = 0; i < 12; i++)
            {
                whatDo = oxyList.Select(x => int.Parse(x[i].ToString())).Sum() >= oxyList.Length / 2;
                if (whatDo)
                    oxyList.RemoveAll(x => x[i] == '0');
                else
                    oxyList.RemoveAll(x => x[i] == '1');
                if (oxyList.Count <= 1)
                    break;
            }

            for (int i = 0; i < 12; i++)
            {
                whatDo = scrubberList.Select(x => int.Parse(x[i].ToString())).Sum() >= scrubberList.Length / 2;
                if (whatDo)
                    scrubberList.RemoveAll(x => x[i] == '1');
                else
                    scrubberList.RemoveAll(x => x[i] == '0');
                if (scrubberList.Count <= 1)
                    break;
            }

            Console.WriteLine(Convert.ToInt32(oxyList.First().ToString(), 2) * Convert.ToInt32(scrubberList.First().ToString(), 2));
        }
    }
}
