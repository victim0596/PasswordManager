using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PasswordManagerWPF.Classes
{
    internal class EntropyCalc
    {
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
    }
}
