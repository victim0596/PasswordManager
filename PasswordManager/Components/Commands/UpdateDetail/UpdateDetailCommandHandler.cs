using PasswordManager.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Components.Commands
{
    public class UpdateDetailCommandHandler
    {
        public void Execute(UpdateDetailCommand command)
        {
            using (var db = new DatabaseContext())
            {
                var result = db.pswManagers.SingleOrDefault(x => x.ID == command.Id);
                result.APPNAME = command.Appname;
                result.USERNAME = command.Username;
                result.PASSWORD = command.Password;
                db.SaveChanges();

            }
        }
    }
}
