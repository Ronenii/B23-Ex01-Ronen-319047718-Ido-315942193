using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {

        }

        public void RunStringCheck()
        {
            string userInputString = getUserInput();

            if(isNumber(userInputString))
            {

            }
        }

        private static bool isNumber(string i_UserInputString)
        {
            for(int i = 0; i < i_UserInputString.Length; i++)
            {
                if(!char.IsDigit(i_UserInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isEnglishLetterStr(string i_UserInputString)
        {
            for(int i = 0; i < i_UserInputString.Length; i++)
            {
                if(!char.IsLetter(i_UserInputString[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isValidString(string i_UserInputString)
        {
            return (i_UserInputString.Length == 6) && xor(isEnglishLetterStr(i_UserInputString),isNumber(i_UserInputString));
        }

        private static bool xor(bool i_Val1, bool i_Val2)
        {
            return (!i_Val1 && i_Val2) || (i_Val1 && !i_Val2);
        }

        private static string getUserInput()
        {
            Console.WriteLine("Please enter a 6 char string: ");
            string retUserString = Console.ReadLine();

            while(!isValidString(retUserString))
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
            string stateStr;

            if(isDivisibleByThree(i_UserInputString))
            {
                stateStr = "";
            }
            else
            {
                stateStr = "not";
            }

            
        }
    }
}
