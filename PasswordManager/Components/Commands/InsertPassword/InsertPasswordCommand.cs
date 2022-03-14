using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Components.Commands
{
    public class InsertPasswordCommand
    {
        public string Appname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
