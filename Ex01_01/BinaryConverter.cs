using System;
using System.Text;

namespace Ex01_01
{
    public class BinaryConverter
    {
        // The function that operates the entire task requirements: user input, converting + printing the user input
        // and printing the required statistics.
        public static void RunBinary()
        {
            string binaryNumber1Str = getSingleStringNumberFromUser(1);
            string binaryNumber2Str = getSingleStringNumberFromUser(2);
            string binaryNumber3Str = getSingleStringNumberFromUser(3);

            int decimalNumber1 = convertBinaryStrToDecimalInt(binaryNumber1Str);
            int decimalNumber2 = convertBinaryStrToDecimalInt(binaryNumber2Str);
            int decimalNumber3 = convertBinaryStrToDecimalInt(binaryNumber3Str);

            printDescendingOrder(decimalNumber1, decimalNumber2, decimalNumber3);

            Console.WriteLine();
            Console.WriteLine("Statistics");
            Console.WriteLine("----------------");
            printAverageOfZerosAndOnes(binaryNumber1Str, binaryNumber2Str, binaryNumber3Str);
            printQuantityOfDividedByFour(decimalNumber1, decimalNumber2, decimalNumber3);
            printQuantityOfDescendingOrderNumbers(decimalNumber1, decimalNumber2, decimalNumber3);
            printQuantityOfPalindromeNumbers(decimalNumber1, decimalNumber2, decimalNumber3);
        }

        // Prints out the given input params in descending order.
        private static void printDescendingOrder(int i_BinaryNumber1, int i_BinaryNumber2, int i_BinaryNumber3)
        {
            Console.WriteLine("Descending order: ");
            if (i_BinaryNumber1 > i_BinaryNumber2 && i_BinaryNumber1 > i_BinaryNumber3)
            {
                if (i_BinaryNumber2 > i_BinaryNumber3)
                {
                    printNumberOrderByFormat(i_BinaryNumber1, i_BinaryNumber2, i_BinaryNumber3);
                }
                else
                {
                    printNumberOrderByFormat(i_BinaryNumber1, i_BinaryNumber3, i_BinaryNumber2);
                }
            }

            if (i_BinaryNumber2 > i_BinaryNumber1 && i_BinaryNumber2 > i_BinaryNumber3)
            {
                if (i_BinaryNumber1 > i_BinaryNumber3)
                {
                    printNumberOrderByFormat(i_BinaryNumber2, i_BinaryNumber1, i_BinaryNumber3);
                }
                else
                {
                    printNumberOrderByFormat(i_BinaryNumber2, i_BinaryNumber3, i_BinaryNumber1);
                }
            }
            
            if (i_BinaryNumber3 > i_BinaryNumber1 && i_BinaryNumber3 > i_BinaryNumber2)
            {
                if (i_BinaryNumber1 > i_BinaryNumber2)
                {
                    printNumberOrderByFormat(i_BinaryNumber3, i_BinaryNumber1, i_BinaryNumber2);
                }
                else
                {
                    printNumberOrderByFormat(i_BinaryNumber3, i_BinaryNumber2, i_BinaryNumber1);
                }
            }
        }

        // Calculates the average of the quantity of zeros in the 3 binary number strings
        private static float calculateAverageOfZeros(string i_BinaryNumber1Str, string i_BinaryNumber2Str, string i_BinaryNumber3Str)
        {
            int totalNumberOfZeros = 0;
            
            StringBuilder collectiveBinaryNumber = new StringBuilder();
            collectiveBinaryNumber.Append(i_BinaryNumber1Str).Append(i_BinaryNumber2Str).Append(i_BinaryNumber3Str);
            for (int i = 0; i < collectiveBinaryNumber.Length; i++)
            {
                if (collectiveBinaryNumber[i] == '0')
                {
                    totalNumberOfZeros++;
                }
            }

            return (float)totalNumberOfZeros / (float)collectiveBinaryNumber.Length;
        }

        // Prints out the average of zeros and ones in the 3 binary number strings
        private static void printAverageOfZerosAndOnes(string i_BinaryNumber1Str, string i_BinaryNumber2Str, string i_BinaryNumber3Str)
        {
            float avgOfZeros = calculateAverageOfZeros(i_BinaryNumber1Str, i_BinaryNumber2Str, i_BinaryNumber3Str);
            float avgOfOnes = 1 - avgOfZeros;
            Console.WriteLine("Average number of zeroes: " + avgOfZeros);
            Console.WriteLine("Average number of ones: " + avgOfOnes);
        }

        // Prints out the quantity of given decimal numbers divisible by 4 
        private static void printQuantityOfDividedByFour(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int quantityOfNumbersDivisibleByFour = isDivisibleByFour(i_DecimalNumber1) + isDivisibleByFour(i_DecimalNumber2) + isDivisibleByFour(i_DecimalNumber3);
            Console.WriteLine("Quantity of numbers divisible by four: " + quantityOfNumbersDivisibleByFour);
        }

        // Returns 1 if the number is divisible by 4 and 0 if not
        private static int isDivisibleByFour(int i_DecimalNumber)
        {
            if(i_DecimalNumber % 4 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        // Returns 1 if the given decimal number is a descending order number, otherwise returns 0
        private static int isDescendingOrderNumber(int i_DecimalNumber)
        {
            int currentComparingNumber = i_DecimalNumber % 10;

            i_DecimalNumber /= 10;
            while (i_DecimalNumber != 0)
            {
                if(currentComparingNumber >= i_DecimalNumber % 10)
                {
                    return 0;
                }

                i_DecimalNumber /= 10;
            }

            return 1;
        }

        // Prints out the quantity of given decimal numbers that are descending order numbers
        private static void printQuantityOfDescendingOrderNumbers(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int quantityOfDescendingOrderNumbers = isDescendingOrderNumber(i_DecimalNumber1) + isDescendingOrderNumber(i_DecimalNumber2) + isDescendingOrderNumber(i_DecimalNumber3);
            Console.WriteLine("Quantity of descending order numbers: " + quantityOfDescendingOrderNumbers);
        }
        
        // Returns 1 if the given decimal number is a palindrome, otherwise returns 0
        private static int isPalindrome(int i_DecimalNumber)
        {
            int reverseNumber = 0;
            int tempDecimalNumber = i_DecimalNumber;
            while (tempDecimalNumber > 0)
            {
                int remainder = tempDecimalNumber % 10;
                tempDecimalNumber = tempDecimalNumber / 10; 
                reverseNumber = (reverseNumber * 10) + remainder;
            }

            if (i_DecimalNumber == reverseNumber)
            {
                return 1;
            }

            return 0;
        }

        // Prints out the quantity of given decimal numbers divided by 4 
        private static void printQuantityOfPalindromeNumbers(int i_DecimalNumber1, int i_DecimalNumber2, int i_DecimalNumber3)
        {
            int quantityOfPalindromeNumbers = isPalindrome(i_DecimalNumber1) + isPalindrome(i_DecimalNumber2) + isPalindrome(i_DecimalNumber3);
            Console.WriteLine("Quantity of palindrome numbers: " + quantityOfPalindromeNumbers);
        }

        // Prints out the given numbers from biggest to smallest according to the format.
        private static void printNumberOrderByFormat(int i_BiggestNumber, int i_MiddleNumber, int i_SmallestNumber)
        {
            Console.WriteLine(i_BiggestNumber + "," + i_MiddleNumber + "," + i_SmallestNumber);
        }

        private static bool validateUserInput(string i_UserInput)
        {
            int userInputLength = i_UserInput.Length;
            if (userInputLength == 8)
            {
                for (int i = 0; i < userInputLength; i++)
                {
                    if(i_UserInput[i] != '0' && i_UserInput[i] != '1')
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        // Asks the user to write a byte and validates that it is in fact, a byte
        private static string getSingleStringNumberFromUser(int i_NumberIndex)
        {
            Console.WriteLine("Please enter binary number #" + i_NumberIndex + ": ");
            string binaryNumberStr = Console.ReadLine();
            while (!validateUserInput(binaryNumberStr))
            {
                Console.WriteLine("Invalid input, please try again:");
                binaryNumberStr = Console.ReadLine();
            }

            return binaryNumberStr;
        }

        // Converts the given byte string to a decimal number
        private static int convertBinaryStrToDecimalInt(string i_BinaryStringNumber)
        {
            double retDecimalNumber = 0;
            int binaryNumberLength = i_BinaryStringNumber.Length;
            for (int i = 0; i < binaryNumberLength; i++)
            {
                if(i_BinaryStringNumber[i] == '1')
                {
                    retDecimalNumber += Math.Pow(2, binaryNumberLength - i - 1);
                }
            }

            return (int)retDecimalNumber;
        }
    }
}
