using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IContractData
    {
        Task EditContract(ContractModel Contract);

        Task<ContractModel> GetUserContract(int Id);
    }
}