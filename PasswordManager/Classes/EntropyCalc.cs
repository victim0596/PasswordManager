using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using PasswordManager.GVariable;

namespace PasswordManager.Classes
{
    internal class EntropyCalc
    {
        public EntropyCalc()
        {
            globalVar.lowerCase = 0;
            globalVar.upperCase = 0;
            globalVar.digits = 0;
            globalVar.simbol = 0;
        }
        public string entropy(double length)
        {
            double entropy = 0;
            int poolSize = 0;
            if (globalVar.lowerCase > 0) poolSize = poolSize + 26;
            if (globalVar.upperCase > 0) poolSize = poolSize + 26;
            if (globalVar.digits > 0) poolSize = poolSize + 10;
            if (globalVar.simbol > 0) poolSize = poolSize + 32;
            entropy = length * Math.Log2(poolSize);
            return entropy.ToString("0.00");
        }
        public string entropyByPassword(string password)
        {
            string regexDigit = @"[0-9]";
            int digitCount = Regex.Matches(password, regexDigit).Count;

            string regexlowerCase = "[a-z]";
            int lowerCaseCount = Regex.Matches(password, regexlowerCase).Count;

            string regexupperCase = "[A-Z]";
            int upperCaseCount = Regex.Matches(password, regexupperCase).Count;

            string regexSimbol = "[^0-9a-zA-Z]";
            int simbolCount = Regex.Matches(password, regexSimbol).Count;

            int poolSize = 0;
            if (lowerCaseCount > 0) poolSize = poolSize + 26;
            if (upperCaseCount > 0) poolSize = poolSize + 26;
            if (digitCount > 0) poolSize = poolSize + 10;
            if (simbolCount > 0) poolSize = poolSize + 32;
            double entropy = password.Length * Math.Log2(poolSize);
            return entropy.ToString("0.00");
        }
        public void entropyTips(string entropyValue, Label entropyLabel)
        {
            string message = "";
            double entropyBit = Double.Parse(entropyValue);
            switch (entropyBit)
            {
                case < 17:
                    {
                        message = LangString.tip1;
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Red);
                        break;
                    }
                case double n when (n >= 17 && n <= 36):
                    {
                        message = LangString.tip2;
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Orange);
                        break;
                    }
                case double n when (n > 36 && n <= 60):
                    {
                        message = LangString.tip3;
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Yellow);
                        break;
                    }
                case double n when (n > 60 && n <= 124):
                    {
                        message = LangString.tip4;
                        entropyLabel.Foreground = new SolidColorBrush(Colors.GreenYellow);
                        break;
                    }
                case > 125:
                    {
                        message = LangString.tip5;
                        entropyLabel.Foreground = new SolidColorBrush(Colors.Green);
                        break;
                    }
            }
            entropyLabel.Content = message;
        }
    }
}
