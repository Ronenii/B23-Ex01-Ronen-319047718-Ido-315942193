using System;
using System.Text;

namespace Ex01_01
{
    class BinaryConverter
    {

        public void RunBinary()
        {
            string binaryNumber1Str = getSingleStringNumberFromUser(1);
            string binaryNumber2Str = getSingleStringNumberFromUser(2);
            string binaryNumber3Str = getSingleStringNumberFromUser(3);

            int decimalNumber1 = converBinaryToDecimal(binaryNumber1Str);
            int decimalNumber2 = converBinaryToDecimal(binaryNumber2Str);
            int decimalNumber3 = converBinaryToDecimal(binaryNumber3Str);

            printDescendingOrder(decimalNumber1, decimalNumber2, decimalNumber3);

            Console.WriteLine("Statistics");
            Console.WriteLine("----------------");
            calculateAvergaeOfZerosAndOnes(binaryNumber1Str, binaryNumber2Str, binaryNumber3Str);
            printQuantityOfDividedByFour(decimalNumber1, decimalNumber2, decimalNumber3);
            printQuantityOfDescendingOrderNumbers(decimalNumber1, decimalNumber2, decimalNumber3);
            printQuantityOfPalindromeNumbers(decimalNumber1, decimalNumber2, decimalNumber3);
        }


        private void printDescendingOrder(int i_binaryNumber1, int i_binaryNumber2, int i_binaryNumber3)
        {
            Console.WriteLine("Descending order: ");
            if (i_binaryNumber1 > i_binaryNumber2 && i_binaryNumber1 > i_binaryNumber3)
            {
                if (i_binaryNumber2 > i_binaryNumber3)
                {
                    printNumberOrderByFormat(i_binaryNumber1, i_binaryNumber2, i_binaryNumber3);
                }
                else
                {
                    printNumberOrderByFormat(i_binaryNumber1, i_binaryNumber3, i_binaryNumber2);
                }
            }
            if (i_binaryNumber2 > i_binaryNumber1 && i_binaryNumber2 > i_binaryNumber3)
            {
                if (i_binaryNumber1 > i_binaryNumber3)
                {
                    printNumberOrderByFormat(i_binaryNumber2, i_binaryNumber1, i_binaryNumber3);
                }
                else
                {
                    printNumberOrderByFormat(i_binaryNumber2, i_binaryNumber3, i_binaryNumber1);
                }
            }
            if (i_binaryNumber3 > i_binaryNumber1 && i_binaryNumber3 > i_binaryNumber2)
            {
                if (i_binaryNumber1 > i_binaryNumber2)
                {
                    printNumberOrderByFormat(i_binaryNumber3, i_binaryNumber1, i_binaryNumber2);
                }
                else
                {
                    printNumberOrderByFormat(i_binaryNumber3, i_binaryNumber2, i_binaryNumber1);
                }
            }
        }

        private void calculateAvergaeOfZerosAndOnes(string i_binaryNumber1Str, string i_binaryNumber2Str, string i_binaryNumber3Str)
        {
            int totalNumberOfZeros = 0;
            
            StringBuilder collectiveBinaryNumber = new StringBuilder();
            collectiveBinaryNumber.Append(i_binaryNumber1Str).Append(i_binaryNumber2Str).Append(i_binaryNumber3Str);
            for (int i = 0; i < collectiveBinaryNumber.Length; i++)
            {
                if (collectiveBinaryNumber[i] == '0')
                {
                    totalNumberOfZeros++;
                }
            }

            float avgOfZeros = (float)totalNumberOfZeros / (float)collectiveBinaryNumber.Length;
            float avgOfOnes = 1 - avgOfZeros;
            Console.WriteLine("Average number of zeroes: " + avgOfZeros);
            Console.WriteLine("Average number of ones: " + avgOfOnes);
        }

        private void printQuantityOfDividedByFour(int i_decimalNumber1, int i_decimalNumber2, int i_decimalNumber3)
        {
            int quantityOfNumbersDisivisableByFour = isDivdedByFour(i_decimalNumber1) + isDivdedByFour(i_decimalNumber2) + isDivdedByFour(i_decimalNumber3);
            Console.WriteLine("Quantity of numbers divisable by four: " + quantityOfNumbersDisivisableByFour);
        }

        private int isDivdedByFour(int i_decimalNumber)
        {
            if(i_decimalNumber % 4 == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int isDescendingOrederNumber(int i_decimalNumber)
        {
            int currentComparingNumber = i_decimalNumber % 10;

            i_decimalNumber /= 10;
            while (i_decimalNumber != 0)
            {
                if(currentComparingNumber >= i_decimalNumber % 10)
                {
                    return 0;
                }
                i_decimalNumber /= 10;
            }
            return 1;
        }

        private void printQuantityOfDescendingOrderNumbers(int i_decimalNumber1, int i_decimalNumber2, int i_decimalNumber3)
        {
            int quantityOfDescendingOrderNumbers = isDescendingOrederNumber(i_decimalNumber1) + isDescendingOrederNumber(i_decimalNumber2) + isDescendingOrederNumber(i_decimalNumber3);
            Console.WriteLine("Quntity of descending order numbers: " + quantityOfDescendingOrderNumbers);
        }

        private int isPalindrome(int i_decimalNumber)
        {
            int reverseNumber = 0;
            int remainder = 0;
            int tempDecimalNumber = i_decimalNumber;
            while (tempDecimalNumber > 0)
            {
                remainder = tempDecimalNumber % 10;
                tempDecimalNumber = tempDecimalNumber / 10; 
                reverseNumber = reverseNumber * 10 + remainder;
            }
            if (i_decimalNumber == reverseNumber)
            {
                return 1;
            }
            return 0;
        }

        private void printQuantityOfPalindromeNumbers(int i_decimalNumber1, int i_decimalNumber2, int i_decimalNumber3)
        {
            int quantityOfPalindromeNumbers = isPalindrome(i_decimalNumber1) + isPalindrome(i_decimalNumber2) + isPalindrome(i_decimalNumber3);
            Console.WriteLine("Quantity of palindrome numbers: " + quantityOfPalindromeNumbers);
        }

        private void printNumberOrderByFormat(int i_BiggestNumber, int i_MiddleNumber, int i_SmallestNumber)
        {
            Console.WriteLine(i_BiggestNumber + "," + i_MiddleNumber + "," + i_SmallestNumber);
        }
        private bool validateUserInput(string i_UserInput)
        {
            int userInputLength = i_UserInput.Length;
            if (userInputLength == 8)
            {
                for (int i = 0; i < userInputLength; i++)
                {
                    if (i_UserInput[i] != '0' && i_UserInput[i] != '1')
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private string getSingleStringNumberFromUser(int i_NumberIndex)
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

        private int converBinaryToDecimal(string i_BinaryStringNumber)
        {
            double r_DecimalNumber = 0;
            int binaryNumberLength = i_BinaryStringNumber.Length;
            for (int i = 0; i < binaryNumberLength; i++)
            {
                if (i_BinaryStringNumber[i] == '1')
                {
                    r_DecimalNumber += Math.Pow(2, binaryNumberLength - i- 1);
                }
            }
            return (int)r_DecimalNumber;
        }
    }
}
