using System.Collections;
using System.Text;

namespace AdventOfCode2021Day1
{
    public static class Day3
    {
        private static readonly string[] text = System.IO.File.ReadAllLines(@"D:\Programs\AdventOfCode2021Day3.txt");

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
            var ones = 0;
            var zeros = 0;
            for (int i = 0; i < 12; i++)
            {
                text.ToList().ForEach(x =>
                {
                    if (x[i] == '1')
                        ones++;
                    else
                        zeros++;
                });
                if (ones>=zeros)
                    oxyList.RemoveAll(x => x[i] == '0');
                else
                    oxyList.RemoveAll(x => x[i] == '1');
                ones = 0;
                zeros = 0;
                if (oxyList.Count <= 1)
                    break;
            }
            Console.WriteLine("Oxygen:==========");
            oxyList.ForEach(x => Console.WriteLine(x));

            ones = 0;
            zeros = 0;
            for (int i = 0; i < 12; i++)
            {
                text.ToList().ForEach(x =>
                {
                    if (x[i] == '1')
                        ones++;
                    else
                        zeros++;
                });
                if (ones >= zeros)
                    scrubberList.RemoveAll(x => x[i] == '1');
                else
                    scrubberList.RemoveAll(x => x[i] == '0');

                ones = 0;
                zeros = 0;
                if (scrubberList.Count <= 1)
                    break;
            }

            Console.WriteLine("Scrubber: ==========");
            scrubberList.ForEach(x => Console.WriteLine(x));

            Console.WriteLine(Convert.ToInt32(oxyList.First().ToString(), 2) * Convert.ToInt32(scrubberList.First().ToString(), 2));
        }
    }
}
