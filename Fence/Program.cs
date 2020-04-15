using System;
using System.Text.RegularExpressions;

namespace Fence
{
    public class Program
    {
        public const int RibWidth = 45;
        public const int PreferedSpace = 70;

        public static void Main(string[] args)
        {
            var totalRibs = 0;

            foreach (var sectionWidth in Sections.Data)
            {
                var ribs = CalculateNumberOfRibs(sectionWidth);
                var space = CalculateActualSpace(sectionWidth, ribs);
                var cc = (double)sectionWidth / 2;
                totalRibs += ribs;

                Console.WriteLine($"Ribs: {ribs}, Space: {space}, CC: {cc}");
            }

            Console.WriteLine($"Total amount of ribs: {totalRibs}");
        }

        private static int CalculateNumberOfRibs(int sectionWidth)
        {
            var x = (double)(sectionWidth - ((2 * PreferedSpace) + RibWidth)) / (RibWidth + PreferedSpace);

            return (int)Math.Round(x) + 1;
        }

        private static double CalculateActualSpace(int sectionWidth, int numberOfRibs)
        {
            var x = sectionWidth - ((numberOfRibs - 1) * (RibWidth + PreferedSpace)) - RibWidth;
            var difference = (PreferedSpace * 2) - x;
            var space = (double)difference / (numberOfRibs - 1);

            return Math.Round(PreferedSpace + space, 1);
        }
    }
}
