using DataAccessLibrary.Models;
using System.Diagnostics.Contracts;

namespace DataAccessLibrary.Interfaces
{
    public interface IUserData
    {
        Task<List<tbUser>> GetUsers();

        Task<tbUser> GetUser(string login);

        public Task EditUser(tbUser user);
    }
}