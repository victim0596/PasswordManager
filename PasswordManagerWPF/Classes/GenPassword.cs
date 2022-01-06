using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerWPF.Classes
{
    internal class GenPassword
    {
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
            return random.Next(0, 10);
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
                globalVar.upperCase++;
            }
            else
            {
                //for lowercase
                c = Convert.ToChar(rand.Next(97, 123));
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
                        break;
                    }
                case 2:
                    {
                        c = Convert.ToChar(rand.Next(58, 65));
                        break;
                    }
                case 3:
                    {
                        c = Convert.ToChar(rand.Next(91, 97));
                        break;
                    }
                case 4:
                    {
                        c = Convert.ToChar(rand.Next(123, 127));
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


    }
}
