using PasswordManagerWPF.DBModels;
using PasswordManagerWPF.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManagerWPF.Components.Commands
{
    public class RegisterUserCommandHandler
    {
        public void Execute(RegisterUserCommand command)
        {
            using (var db = new DatabaseContext())
            {

                db.users.Add(new User()
                {
                    USERNAME = command.Username,
                    PASSWORD = command.Password,
                });
                db.SaveChanges();

            }
        }
    }
}
