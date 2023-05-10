using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _da;
        public UserData(ISqlDataAccess da)
        {
            this._da = da;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "select * from dbo.tbUser";

            return _da.LoadData<UserModel, dynamic>(sql, new { });
        }

    }
}
