using System;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            RunNumberStats();
            Console.Read();
        }

        // The method responsible for receiving input from user, validates said input
        // and prints out the required statistics.
        public static void RunNumberStats()
        {
            string userInput = getUserInput();
            printStats(userInput);
        }

        // Prompts the user to input a string and validates it. If the string is invalid
        // the method will prompt the user to input it again until it is valid.
        // Once valid the method will return the string.
        private static string getUserInput()
        {
            Console.WriteLine("Please Enter a 6 digit number: ");
            string retUserInput = Console.ReadLine();

            while (!isValidInput(retUserInput))
            {
                Console.WriteLine("Invalid input, try again: ");
                retUserInput = Console.ReadLine();
            }

            return retUserInput;
        }

        // Checks for the string's validity (i.e if the string is 6 char long and only contains numbers).
        // Returns true if so, false otherwise. 
        private static bool isValidInput(string i_UserInputStr)
        {
            return (i_UserInputStr.Length == 6) && hasOnlyNumbers(i_UserInputStr);
        }

        // Check if the given string contains only numbers.
        // Returns true if so, false otherwise. 
        private static bool hasOnlyNumbers(string i_UserInputString)
        {
            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (!char.IsNumber(i_UserInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        // Counts and returns the number of digits smaller than the least significant digit.
        private static int getNumOfDigitsLargerThanLastDigit(string i_UserInputString)
        {
            int lastDigitIndex = i_UserInputString.Length - 1;
            int lastDigit = int.Parse(i_UserInputString[lastDigitIndex].ToString());
            int retLargerThanLastDig = 0;

            for (int i = 0; i < lastDigitIndex; i++)
            {
                if (int.Parse(i_UserInputString[i].ToString()) > lastDigit)
                {
                    retLargerThanLastDig++;
                }
            }

            return retLargerThanLastDig;
        }

        // Returns the smallest digit in the given string.
        private static int findMinDigit(string i_UserInputString)
        {
            int minDigit = int.Parse(i_UserInputString[0].ToString());

            for (int i = 1; i < i_UserInputString.Length; i++)
            {
                int currentDig = int.Parse(i_UserInputString[i].ToString());
                if (currentDig < minDigit)
                {
                    minDigit = currentDig;
                }
            }

            return minDigit;
        }

        // Counts and returns the number of digits divisible by 3 in the given string.
        private static int getNumOfDigitsDivisibleByThree(string i_UserInputString)
        {
            int retNumOfDigitsDivisibleByThree = 0;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                int currentDig = int.Parse(i_UserInputString[i].ToString());
                if (currentDig % 3 == 0)
                {
                    retNumOfDigitsDivisibleByThree++;
                }
            }

            return retNumOfDigitsDivisibleByThree;
        }

        // Calculates the average of all digits in the given string.
        private static float avgOfDigits(string i_UserInputString)
        {
            float sumOfDigits = 0f;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                float currentDig = float.Parse(i_UserInputString[i].ToString());
                sumOfDigits += currentDig;
            }

            return sumOfDigits / i_UserInputString.Length;
        }

        // Prints the required statistics.
        private static void printStats(string i_UserInputString)
        {
            float avg = avgOfDigits(i_UserInputString);
            int numOfDigitsDivisibleByThree = getNumOfDigitsDivisibleByThree(i_UserInputString);
            int minDigit = findMinDigit(i_UserInputString);
            int numOfDigitsLargerThanLastDigit = getNumOfDigitsLargerThanLastDigit(i_UserInputString);

            Console.WriteLine("Statistics");
            Console.WriteLine("--------------");
            printStat("Number of digits lager than last digit: {0} ", numOfDigitsLargerThanLastDigit);
            printStat("Minimal Digit: {0} ", minDigit);
            printStat("Number of digits divisible by 3 : {0} ", numOfDigitsDivisibleByThree);
            printStat("Average of all digits: {0} ", avg);
        }

        // Prints the given stat prompt with the given integer value
        private static void printStat(string i_StatPrompt, int i_StatValue)
        {
            string output = string.Format(i_StatPrompt, i_StatValue);
            Console.WriteLine(output);
        }

        // Prints the given stat prompt with the given float value
        private static void printStat(string i_StatPrompt, float i_StatValue)
        {
            string output = string.Format(i_StatPrompt, i_StatValue);
            Console.WriteLine(output);
        }
    }
}
