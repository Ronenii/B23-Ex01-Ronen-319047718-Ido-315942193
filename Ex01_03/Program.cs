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
        public static void RunExpertDiamond()
        {
            bool inputValidation = false;
            int parsedIntegerInput = 0;
            Console.WriteLine("Please Enter amount of rows");
            while (!inputValidation)
            {
                string userInput = Console.ReadLine();
                inputValidation = isUserInputIsValid(userInput, out parsedIntegerInput);
            }
            Ex01_02.Program.PrintDiamond(parsedIntegerInput);
        }

        private static bool isUserInputIsValid(string i_UserInput, out int i_ParsedIntegerInput)
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
