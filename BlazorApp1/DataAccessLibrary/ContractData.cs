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

        public Task EditContract(ContractModel Contract)
        {
            string sql = "Update table dbo.tbContract set OrgName = @OrgName,Registred = @Registred, Based = @Based, ICO = @ICO, RepresentedBy = @RepresentedBy, StreetNumber = @StreetNumber, City = @City, PSC = @PSC, FirstName = @FirstName, LastName = @LastName,MobileNumber = @MobileNumber, WorkDescription = @WorkDescription, WorkStart = @WorkStart, WorkEnd = @WorkEnd, BreakStart = @BreakStart, BreakEnd = @BreakEnd  where Id = @Id";

            return _da.SaveData(sql, Contract);
        }

        public Task GetUserContract(int Id)
        {
            string sql = "select * from tbContract where Id = @Id";

            return _da.LoadData<UserModel, dynamic>(sql, new { });
        }

    }
}
