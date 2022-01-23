using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PasswordManagerWPF.Classes
{
    internal class GenPassword
    {
        public string excludedChar = "";
        public string generate(Boolean isNumeric, Boolean isAlphabetic, Boolean isSimbol, double length)
        {
            string genPsw = "";
            Random random = new Random();
            if (isNumeric && !isAlphabetic && !isSimbol)
            {
                for (int i = 0; i < length; i++)
                {
                    genPsw += genNumber().ToString();
                }
            }
            if (isAlphabetic && !isNumeric && !isSimbol)
            {
                for (int i = 0; i < length; i++)
                {
                    genPsw += genChar();
                }
            }
            if (isSimbol && !isNumeric && !isAlphabetic)
            {
                for (int i = 0; i < length; i++)
                {
                    genPsw += genSimbol();
                }
            }
            if (isNumeric && isAlphabetic && !isSimbol)
            {
                for (int i = 0; i < length; i++)
                {
                    if (random.Next(1, 3) == 1) genPsw += genNumber().ToString();
                    else genPsw += genChar();
                }
            }
            if (isNumeric && isSimbol && !isAlphabetic)
            {
                for (int i = 0; i < length; i++)
                {
                    if (random.Next(1, 3) == 1) genPsw += genNumber().ToString();
                    else genPsw += genSimbol();
                }
            }
            if (isAlphabetic && isSimbol && !isNumeric)
            {
                for (int i = 0; i < length; i++)
                {
                    if (random.Next(1, 3) == 1) genPsw += genChar();
                    else genPsw += genSimbol();
                }
            }
            if (isAlphabetic && isSimbol && isNumeric)
            {
                for (int i = 0; i < length; i++)
                {
                    switch (random.Next(1, 4))
                    {
                        case 1:
                            {
                                genPsw += genChar();
                                break;
                            }
                        case 2:
                            {
                                genPsw += genSimbol();
                                break;
                            }
                        case 3:
                            {
                                genPsw += genNumber().ToString();
                                break;
                            }
                    }
                }
            }
            return genPsw;
        }
        //generate random number
        public int genNumber()
        {
            Random random = new Random();
            globalVar.digits++;
            int geneneratedNumber = random.Next(0, 10);
            //check if the generated value is inside the excludeChar string
            while (checkContainExcluded(geneneratedNumber.ToString()))
            {
                geneneratedNumber = random.Next(0, 10);
            }
            return geneneratedNumber;
        }
        //generate random letter uppercase/lowercase
        public string genChar()
        {
            Random rand = new Random();
            char c;
            string generatedChar = "";
            int number = rand.Next(1, 3);
            if (number == 1)
            {
                //for uppercase
                c = Convert.ToChar(rand.Next(65, 91));
                //check if the generated value is inside the excludeChar string
                while (checkContainExcluded(c.ToString()))
                {
                    c = Convert.ToChar(rand.Next(65, 91));
                }
                globalVar.upperCase++;
            }
            else
            {
                //for lowercase
                c = Convert.ToChar(rand.Next(97, 123));
                //check if the generated value is inside the excludeChar string
                while (checkContainExcluded(c.ToString()))
                {
                    c = Convert.ToChar(rand.Next(97, 123));
                }
                globalVar.lowerCase++;
            }
            generatedChar = c.ToString();
            return generatedChar;
        }
        //generate random simbol
        public string genSimbol()
        {
            Random rand = new Random();
            string generatedSimbol = "";
            char c;
            int number = rand.Next(1, 5);
            switch (number)
            {
                case 1:
                    {
                        c = Convert.ToChar(rand.Next(33, 48));
                        //check if the generated value is inside the excludeChar string
                        while (checkContainExcluded(c.ToString()))
                        {
                            c = Convert.ToChar(rand.Next(33, 48));
                        }
                        break;
                    }
                case 2:
                    {
                        c = Convert.ToChar(rand.Next(58, 65));
                        //check if the generated value is inside the excludeChar string
                        while (checkContainExcluded(c.ToString()))
                        {
                            c = Convert.ToChar(rand.Next(58, 65));
                        }
                        break;
                    }
                case 3:
                    {
                        c = Convert.ToChar(rand.Next(91, 97));
                        //check if the generated value is inside the excludeChar string
                        while (checkContainExcluded(c.ToString()))
                        {
                            c = Convert.ToChar(rand.Next(91, 97));
                        }
                        break;
                    }
                case 4:
                    {
                        c = Convert.ToChar(rand.Next(123, 127));
                        //check if the generated value is inside the excludeChar string
                        while (checkContainExcluded(c.ToString()))
                        {
                            c = Convert.ToChar(rand.Next(123, 127));
                        }
                        break;
                    }
                default:
                    {
                        throw new Exception("Error to generate simbol");
                    }
            }
            generatedSimbol = c.ToString();
            globalVar.simbol++;
            return generatedSimbol;
        }
        public void checkDuplicateExcluded(string excludedChar)
        {
            char[] excludedArr = excludedChar.ToCharArray();
            if (excludedArr.Length != excludedArr.Distinct().Count())
            {
                throw new Exception("There are repeated characters");
            }
        }

        public bool checkContainExcluded(string generatedValue)
        {
            if (string.IsNullOrEmpty(this.excludedChar)) return false;
            if (countCharExcluded()) throw new Exception("You can't exclude all char");
            char[] excludedArr = this.excludedChar.ToCharArray();
            for (int i = 0; i < excludedArr.Length; i++)
            {
                if (excludedArr[i].ToString() == generatedValue)
                {
                    return true;
                }
            }
            return false;
        }

        public bool countCharExcluded()
        {
            if (string.IsNullOrEmpty(this.excludedChar)) return false;
            char[] excludedArr = this.excludedChar.ToCharArray();
            int number = 0;
            int upperCase = 0;
            int lowerCase = 0;
            int simbol = 0;
            string patternNumber = @"[0-9]";
            string patterUpperCase = @"[A-Z]";
            string patterLowerCase = @"[a-z]";
            Regex rgNumber = new Regex(patternNumber);
            Regex rgLowerCase = new Regex(patterLowerCase);
            Regex rgUppercase = new Regex(patterUpperCase);
            for (int i = 0; i < excludedArr.Length; i++)
            {
                if (rgNumber.IsMatch(excludedArr[i].ToString())) number++;
                if (rgLowerCase.IsMatch(excludedArr[i].ToString())) lowerCase++;
                if (rgUppercase.IsMatch(excludedArr[i].ToString())) upperCase++;
                else simbol++;
            }
            if (number == 10 || simbol == 32 || lowerCase == 26 || upperCase == 26) return true;
            return false;
        }

    }
}
