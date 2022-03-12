using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerWPF.Domain
{
    public class AccountDetailWithEntropy
    {
        public string Username { get; set; }
        public string Appname { get; set; }
        public string Entropy { get; set; }

    }
}
