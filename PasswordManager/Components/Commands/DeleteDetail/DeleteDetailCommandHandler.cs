using PasswordManager.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Components.Commands
{
    public class DeleteDetailCommandHandler
    {
        public void Execute(DeleteDetailCommand command)
        {
            using (var db = new DatabaseContext())
            {
                var deleteRow = db.pswManagers.SingleOrDefault(x => x.ID == command.Id);
                if (deleteRow != null)
                {
                    db.pswManagers.Remove(deleteRow);
                    db.SaveChanges();
                }
                else throw new Exception("Error when deleting detail");

            }
        }
    }
}
