using PasswordManager.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Components.Queries
{
    public class GetAllSavedPswQueryHandler
    {
        public List<GetAllSavedPswQueryResult> Retrieve()
        {
            List<GetAllSavedPswQueryResult> result = new List<GetAllSavedPswQueryResult>();
            using (var db = new DatabaseContext())
            {
                result = (from a in db.pswManagers
                          select new GetAllSavedPswQueryResult
                          {
                              Id = a.ID,
                              Appname = a.APPNAME,
                              Username = a.USERNAME,
                              Password = a.PASSWORD,
                          }).ToList();
            }
            return result;
        }
    }
}
