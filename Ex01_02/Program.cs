using System;

namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            const int k_RowsAmount = 5;
            PrintDiamond(k_RowsAmount);
            Console.Read();
        }

        public static void PrintDiamond(int i_NumberOfRows)
        {
            printDiamondWrapper(i_NumberOfRows, 0);
        }

        private static void printDiamondWrapper(int i_NumberOfRows, int i_WorkingLine)
        {
            if (i_NumberOfRows <= 0)
            {
                return;
            }

            int numberOfSpaces = i_NumberOfRows - 1;
            int starsAmount = calculateAmountOfStars(i_WorkingLine);
            printShspeLine(numberOfSpaces, starsAmount);
            printDiamondWrapper(--i_NumberOfRows, i_WorkingLine + 1);
            numberOfSpaces = i_NumberOfRows + 1;
            starsAmount -= 2;
            printShspeLine(numberOfSpaces, starsAmount);
        }

        private static int calculateAmountOfStars(int i_WorkingLine)
        {
            return i_WorkingLine * 2 + 1;
        }

        private static void printShspeLine(int i_NumberOfSpaces, int i_StarsAmount)
        {
            for (int i = 0; i < i_NumberOfSpaces; i++)
                Console.Write(" ");
            for (int i = 0; i < i_StarsAmount; i++)
                Console.Write("*");
            Console.WriteLine("");
        }
    }
}