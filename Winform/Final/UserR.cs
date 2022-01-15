using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Final
{
    public class UserR : IUserR
    {
        public async Task<bool> Insert(User user)
        {
            using (IDbConnection db = new SqlConnection(AppHelper.ConnectionString))
            {
                var result = await db.ExecuteAsync(Final.Properties.Resources.InsertUser, new { Username = user.Username, Password = user.Password, Fullname = user.Fullname, Address = user.Address, Number = user.Number});
                return result > 0;
            }
        }
    }
}
