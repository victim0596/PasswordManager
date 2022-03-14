using PasswordManagerWPF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PasswordManagerWPF.Classes
{
    static class globalVar
    {
        //for entropy calculation
        public static int lowerCase;
        public static int upperCase;
        public static int digits;
        public static int simbol;
        //for checking if user is logged
        public static bool userLogged;
        //for configurator
        public static string resolution;
        public static string language;
        public static string colorBG;
        public static string colorFG;
        public static string sizeFont;
        //for saved password 
        public static string genPsw { get; set; }
        //saved psw
        public static List<AccountDetailWithEntropy> listPsw { get; set; }
        //edit detail
        public static string appNameDetail { get; set; }
        public static string usernameDetail { get; set; }
        public static string passwordDetail { get; set; }
        public static int idRowDetail { get; set; }
    }
}
