using DataAccessLibrary.Interfaces;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class ContractData : IContractData
    {
        private readonly ISqlDataAccess _da;
        public ContractData(ISqlDataAccess _da)
        {
            this._da = _da;
        }

        public Task<List<ContractModel>> GetContracts()
        {
            string sql = $"select * from tbContract";

            return _da.LoadData<ContractModel, dynamic>(sql,new { });
        }
        public Task EditContract(ContractModel contract)
        {
            string sql = $"Update dbo.tbContract set OrgName = '{contract.OrgName}',Registred = '{contract.Registred}', Based = '{contract.Based}', ICO = '{contract.ICO}', RepresentedBy = '{contract.RepresentedBy}', StreetANumber = '{contract.StreetANumber}', City = '{contract.City}', PSC = '{contract.PSC}', FirstName = '{contract.FirstName}', LastName = '{contract.LastName}',MobileNumber = '{contract.MobileNumber}', WorkDescription = '{contract.WorkDescription}', WorkStart = '{contract.WorkStart}', WorkEnd = '{contract.WorkEnd}', BreakStart = '{contract.BreakStart}', BreakEnd = '{contract.BreakEnd}', LastChanged = '{contract.LastChanged}'  where Id = {contract.Id}";

            return _da.SaveData(sql, contract);
        }

        public Task<ContractModel> GetUserContract(int Id)
        {
            string sql = $"select * from tbContract where Id = {Id}";

            return _da.LoadOne<ContractModel,int>(sql, Id);
        }

    }
}
