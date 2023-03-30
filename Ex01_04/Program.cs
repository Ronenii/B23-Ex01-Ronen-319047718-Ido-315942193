using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            RunStringCheck();
            Console.Read();
        }

        public static void RunStringCheck()
        {
            string userInputString = getUserInput();
            Console.WriteLine();

            if (isNumber(userInputString))
            {
                printDivisibleByThree(userInputString);
            }
            else
            {
                printNumOfUppercaseLettersInStr(userInputString);
            }
        }

        private static bool isNumber(string i_UserInputString)
        {
            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (!char.IsDigit(i_UserInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isEnglishLetterStr(string i_UserInputString)
        {
            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (!char.IsLetter(i_UserInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isValidString(string i_UserInputString)
        {
            return (i_UserInputString.Length == 6) && xor(isEnglishLetterStr(i_UserInputString), isNumber(i_UserInputString));
        }

        private static bool xor(bool i_Val1, bool i_Val2)
        {
            return (!i_Val1 && i_Val2) || (i_Val1 && !i_Val2);
        }

        private static string getUserInput()
        {
            Console.WriteLine("Please enter a 6 char string: ");
            string retUserString = Console.ReadLine();

            while (!isValidString(retUserString))
            {
                Console.WriteLine("Invalid input, try again: ");
                retUserString = Console.ReadLine();
            }

            return retUserString;
        }

        private static bool isDivisibleByThree(string i_UserInputString)
        {
            return (int.Parse(i_UserInputString) % 3) == 0;
        }

        private static void printDivisibleByThree(string i_UserInputString)
        {
            string stateStr = string.Empty;

            if (!isDivisibleByThree(i_UserInputString))
            {
                stateStr = "not";
            }

            Console.WriteLine("The number {0} is {1}divisible by 3.", i_UserInputString, stateStr);
        }

        private static int findNumOfUppercaseLettersInStr(string i_UserInputString)
        {
            int retNumOfUppercase = 0;

            for (int i = 0; i < i_UserInputString.Length; i++)
            {
                if (char.IsUpper(i_UserInputString[i]))
                {
                    retNumOfUppercase++;
                }
            }

            return retNumOfUppercase;
        }

        private static void printNumOfUppercaseLettersInStr(string i_UserInputString)
        {
            int numOfUppercase = findNumOfUppercaseLettersInStr(i_UserInputString);
            string pluralChar = string.Empty;
            if(numOfUppercase != 1)
            {
                pluralChar = "s";
            }

            Console.WriteLine("The string {0} contains {1} uppercase letter{2}.", i_UserInputString, numOfUppercase, pluralChar);
        }
    }
}
