using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUsers();

        Task<UserModel> GetUser(string login);
    }
}