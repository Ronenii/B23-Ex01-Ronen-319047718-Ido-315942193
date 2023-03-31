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

        /// <summary>
        /// The main process of the exercise, print a diamond with user input size
        /// by using PrintDiamond from the other project using his assembly. 
        /// </summary>
        public static void RunExpertDiamond()
        {
            bool inputValidation = false;
            int parsedIntegerInput = 0;
            Console.WriteLine("Please Enter amount of rows");
            while (!inputValidation)
            {
                string userInput = Console.ReadLine();
                inputValidation = tryParseUserInput(userInput, out parsedIntegerInput);
            }
            Ex01_02.Program.PrintDiamond(parsedIntegerInput);
        }

        /// <summary>
        /// validate the user input, in addition we send as out param the parsed user input.
        /// </summary>
        /// <param name="i_UserInput">The user given user</param>
        /// <param name="i_ParsedIntegerInput">an out param of the parsed integer</param>
        /// <returns></returns>
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
