using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

        public Task<UserModel> GetUser(string Login)
        {
            string sql = $"select * from dbo.tbUser where Login = '{Login}'";

            return _da.LoadOne<UserModel,dynamic>(sql,Login);
        }

        public Task EditUser(UserModel user)
        {
            string sql = $"update dbo.tbUser set ContractId = {user.ContractId} where Id = {user.Id}";
            
            return _da.SaveData(sql, user);
        }
    }
}
