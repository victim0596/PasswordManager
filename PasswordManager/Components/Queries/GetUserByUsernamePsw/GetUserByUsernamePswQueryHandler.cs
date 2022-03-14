using PasswordManager.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Components.Queries
{
    public class GetUserByUsernamePswQueryHandler
    {
        public List<GetUserByUsernamePswQueryResult> Retrieve(GetUserByUsernamePswQuery query)
        {
            List<GetUserByUsernamePswQueryResult> result = new List<GetUserByUsernamePswQueryResult>();
            using (var db = new DatabaseContext())
            {
                result = (from a in db.users
                          where a.USERNAME == query.Username && a.PASSWORD == query.Password
                          select new GetUserByUsernamePswQueryResult
                          {
                              Username = a.USERNAME,
                              Password = a.PASSWORD,
                          }).ToList();
            }
            return result;
        }
    }
}
