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
        /// <summary>
        /// The recursive function for printing a diamond shape
        /// </summary>
        /// <param name="i_NumberOfRows">The number of lines of the shape</param>
        public static void PrintDiamond(int i_NumberOfRows)
        {
            printDiamondWrapper(i_NumberOfRows, 0);
        }
        /// <summary>
        /// The wrapper recursive method for print the diamond shape by the given format
        /// </summary>
        /// <param name="i_NumberOfRows">The number of the shape rows</param>
        /// <param name="i_WorkingLine">The working line index, used for count the spaces we should add</param>
        private static void printDiamondWrapper(int i_NumberOfRows, int i_WorkingLine)
        {
            if (i_NumberOfRows <= 0)
            {
                return;
            }

            int numberOfSpaces = i_NumberOfRows - 1;
            int starsAmount = calculateAmountOfStars(i_WorkingLine);
            printShapeLine(numberOfSpaces, starsAmount);
            printDiamondWrapper(--i_NumberOfRows, i_WorkingLine + 1);
            numberOfSpaces = i_NumberOfRows + 1;
            starsAmount -= 2;
            printShapeLine(numberOfSpaces, starsAmount);
        }
        /// <summary>
        /// Calculate how many stars we should print
        /// </summary>
        /// <param name="i_WorkingLine"></param>
        /// <returns></returns>
        private static int calculateAmountOfStars(int i_WorkingLine)
        {
            return i_WorkingLine * 2 + 1;
        }
        /// <summary>
        /// Print the format of the shape.
        /// </summary>
        /// <param name="i_NumberOfSpaces">The number of spaces in the given row</param>
        /// <param name="i_StarsAmount">The amount of stars in the given row</param>
        private static void printShapeLine(int i_NumberOfSpaces, int i_StarsAmount)
        {
            for (int i = 0; i < i_NumberOfSpaces; i++)
                Console.Write(" ");
            for (int i = 0; i < i_StarsAmount; i++)
                Console.Write("*");
            Console.WriteLine("");
        }
    }
}