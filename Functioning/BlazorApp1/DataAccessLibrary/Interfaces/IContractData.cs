﻿using DataAccessLibrary.Models;

namespace DataAccessLibrary.Interfaces
{
    public interface IContractData
    {
        Task EditContract(ContractModel Contract);

        Task<List<ContractModel>> GetContracts();

        Task<ContractModel> GetUserContract(int Id);
    }
}