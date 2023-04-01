using System;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            RunStringCheck();
            Console.Read();
        }

        // The method responsible for receiving input from user, and prints the required output based
        // on if the input str is a number or a collection of letters.
        public static void RunStringCheck()
        {
            string userInputString = getUserInput();

            printIfPalindrome(userInputString);
            if (isNumber(userInputString))
            {
                printDivisibleByThree(userInputString);
            }
            else
            {
                printNumOfUppercaseLettersInStr(userInputString);
            }
        }

        // Returns true if the given str is a number
        // Otherwise returns false.
        private static bool isNumber(string i_UserInputString)
        {
            bool retIsNumber = int.TryParse(i_UserInputString, out int temp);
            return retIsNumber;
        }

        // Returns true if the given str is a collection of letters
        // Otherwise returns false.
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

        // Returns true if the string is 6 chars long and is either a number or a collection of letters
        private static bool isValidString(string i_UserInputString)
        {
            return (i_UserInputString.Length == 6) && xor(isEnglishLetterStr(i_UserInputString), isNumber(i_UserInputString));
        }

        // Xor comparing function based on 2 given bools.
        private static bool xor(bool i_Val1, bool i_Val2)
        {
            return (!i_Val1 && i_Val2) || (i_Val1 && !i_Val2);
        }

        // Prom[ts the user to input a string, validates the string, returns the string if valid.
        // Otherwise repeatedly prompts the user to input the string again until its valid.
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

        public static bool isPalindrome(string i_UserInputString)
        {
            int strLength = i_UserInputString.Length;
            if (strLength == 1 || strLength == 0)
            {
                return true;
            }
            else if (i_UserInputString[0] != i_UserInputString[strLength - 1])
            {
                return false;
            }
            else
            {
                return isPalindrome(i_UserInputString.Substring(1, strLength - 2));
            }
        }

        private static void printIfPalindrome(string i_UserInputString)
        {
            string stateStr = string.Empty;

            if (!isPalindrome(i_UserInputString))
            {
                stateStr = "n't";
            }

            string output = string.Format("The string \"{0}\" is{1} a palindrome.", i_UserInputString, stateStr);
            Console.WriteLine(output);
        }

        // Returns true of the number is divisible by 3.
        // Otherwise returns false.
        private static bool isDivisibleByThree(string i_UserInputString)
        {
            return (int.Parse(i_UserInputString) % 3) == 0;
        }

        // Prints out if the number is or is not divisible by 3.
        private static void printDivisibleByThree(string i_UserInputString)
        {
            string stateStr = string.Empty;

            if (!isDivisibleByThree(i_UserInputString))
            {
                stateStr = "n't";
            }

            string output = string.Format("The number {0} is{1} divisible by 3.", i_UserInputString, stateStr);
            Console.WriteLine(output);
        }

        // Returns the number of uppercase letters in the given str.
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

        // Prints out the number of uppercase letters in the string.
        // The output changes based on if it should be in plural or singular.
        private static void printNumOfUppercaseLettersInStr(string i_UserInputString)
        {
            int numOfUppercase = findNumOfUppercaseLettersInStr(i_UserInputString);
            string pluralChar = string.Empty;
            if (numOfUppercase != 1)
            {
                pluralChar = "s";
            }

            string output = string.Format(
                "The string {0} contains {1} uppercase letter{2}.",
                i_UserInputString,
                numOfUppercase,
                pluralChar);
            Console.WriteLine(output);
        }
    }
}
