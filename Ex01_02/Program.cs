using System;

namespace Ex01_02
{
    class Program
    {
        public static void Main()
        {
            int ROWS_AMOUNT = 5;
            PrintDiamond(ROWS_AMOUNT);
            Console.Read();
        }

        public static void PrintDiamond(int i_NumberOfRows)
        {
            printDiamondWrapper(i_NumberOfRows, 0);
        }

        private static void printDiamondWrapper(int i_NumberOfRows, int i_WorkingLine)
        {
            int i, numberOfSpaces;
            int starsAmount = -1;

            if (i_NumberOfRows <= 0)
            {
                return;
            }

            numberOfSpaces = i_NumberOfRows - 1;
            starsAmount = calculateAmountOfStars(i_WorkingLine);
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