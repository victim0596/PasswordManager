using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordManagerWPF.Classes
{
    internal class LoginForm
    {
        public bool isValid(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) && string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username or password is not valid");
                return false;
            }
            else return true;
        }
        public void isValidPsw(string appName, string password, string username)
        {
            if (string.IsNullOrEmpty(appName)) throw new Exception("App name is empty or not valid");
            if (string.IsNullOrEmpty(password)) throw new Exception("Password is empty or not valid");
            if (string.IsNullOrEmpty(username)) throw new Exception("Username is empty or not valid");
        }
    }
}
