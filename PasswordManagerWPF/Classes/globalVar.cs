﻿using System;
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
    }
}
