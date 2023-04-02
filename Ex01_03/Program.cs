using System;

namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            RunExpertDiamond();
            Console.Read();
        }

        /// The main process of the exercise, print a diamond with user input size
        /// by using PrintDiamond from the other project using his assembly. 
        public static void RunExpertDiamond()
        {
            bool inputValidation = false;
            int parsedIntegerInput = 0;
            Console.Write("Please Enter amount of rows: ");
            while (!inputValidation)
            {
                string userInput = Console.ReadLine();
                inputValidation = tryParseUserInput(userInput, out parsedIntegerInput);
            }

            int numberOfRows = getRightNumberOfRows(parsedIntegerInput);
            Ex01_02.Program.PrintDiamond(numberOfRows);
        }

        private static int getRightNumberOfRows(int i_UserInputNumber)
        {
            return (i_UserInputNumber / 2) + 1;
        }

        /// validate the user input, in addition we send as out param the parsed user input.
        private static bool tryParseUserInput(string i_UserInput, out int i_ParsedIntegerInput)
        {
            bool isNumber = int.TryParse(i_UserInput, out i_ParsedIntegerInput);
            if (!isNumber || i_ParsedIntegerInput <= 0)
            {
                Console.WriteLine("Invalid input");
                return false;
            }

            return true;
        }
    }
}
