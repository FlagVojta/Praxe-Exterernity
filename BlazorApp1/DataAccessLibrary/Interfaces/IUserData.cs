using DataAccessLibrary.Models;
using System.Diagnostics.Contracts;

namespace DataAccessLibrary.Interfaces
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUsers();

        Task<UserModel> GetUser(string login);

        public Task EditUser(UserModel user);
    }
}