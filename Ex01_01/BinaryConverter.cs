using System;
using System.Text;

namespace Ex01_01
{
    class BinaryConverter
    {
        private int m_binaryNumber1, m_binaryNumber2, m_binaryNumber3, m_avgOfZeroAppearances,m_dividedByFourQuantity, m_;
        public void RunBinary()
        {

            getNumbersFromUser();
        }

        private void getNumbersFromUser()
        {
            string binaryNumber1Str = getSingleStringNumberFromUser(1);
            string binaryNumber2Str = getSingleStringNumberFromUser(2);
            string binaryNumber3Str = getSingleStringNumberFromUser(3);

            m_binaryNumber1 = converBinaryToDecimal(binaryNumber1Str);
            m_binaryNumber2 = converBinaryToDecimal(binaryNumber2Str);
            m_binaryNumber3 = converBinaryToDecimal(binaryNumber3Str);
        }

        

        private void printDescendingOrder()
        {
            if (m_binaryNumber1 > m_binaryNumber2 && m_binaryNumber1 > m_binaryNumber3)
            {
                if (m_binaryNumber2 > m_binaryNumber3)
                {
                    Console.WriteLine(m_binaryNumber1 + "," + m_binaryNumber2 + "," + m_binaryNumber3);
                }
                else
                {
                    Console.WriteLine(m_binaryNumber1 + "," + m_binaryNumber3 + "," + m_binaryNumber2);
                }
            }
            if (m_binaryNumber2 > m_binaryNumber1 && m_binaryNumber2 > m_binaryNumber3)
            {
                if (m_binaryNumber1 > m_binaryNumber3)
                {
                    Console.WriteLine(m_binaryNumber2 + "," + m_binaryNumber1 + "," + m_binaryNumber3);
                }
                else
                {
                    Console.WriteLine(m_binaryNumber2 + "," + m_binaryNumber3 + "," + m_binaryNumber1);
                }
            }
            if (m_binaryNumber3 > m_binaryNumber1 && m_binaryNumber3 > m_binaryNumber2)
            {
                if (m_binaryNumber1 > m_binaryNumber2)
                {
                    Console.WriteLine(m_binaryNumber3 + "," + m_binaryNumber1 + "," + m_binaryNumber2);
                }
                else
                {
                    Console.WriteLine(m_binaryNumber3 + "," + m_binaryNumber2 + "," + m_binaryNumber1);
                }
            }
        }

        private bool validateUserInput(string i_UserInput)
        {
            int userInputLength = i_UserInput.Length;
            if (userInputLength == 8)
            {
                for (int i = 0; i < userInputLength; i++)
                {
                    if (i_UserInput[i] != '0' || i_UserInput[i] != '1')
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
            StringBuilder userMessageBuilder = new StringBuilder("Please enter the");
            userMessageBuilder.Append(i_NumberIndex);
            userMessageBuilder.Append("binary number:");
            Console.WriteLine(userMessageBuilder.ToString());
            string binaryNumberStr = Console.ReadLine();
            while (!validateUserInput(binaryNumberStr))
            {
                Console.WriteLine("Invalid input, please try again:");
                binaryNumberStr = Console.ReadLine();
            }
            
            //Do all calculations of statistics


            return binaryNumberStr;
        }

        private int converBinaryToDecimal(string i_BinaryStringNumber)
        {
            double r_DecimalNumber = 0;

            for (int i = 0; i < i_BinaryStringNumber.Length; i++)
            {
                if (i_BinaryStringNumber[i] == '1')
                {
                    r_DecimalNumber += Math.Pow(2, i);
                }
            }
            return (int)r_DecimalNumber;
        }
    }
}
