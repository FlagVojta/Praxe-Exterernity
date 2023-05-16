using EntityFrameWorkDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tbContract = EntityFrameWorkDataAccess.Models.tbContract;

namespace EntityFrameWorkDataAccess
{
    public class DatabaseService
    {
        private IDbContextFactory<DemoDbContext> _dbContextFactory;
        public DatabaseService(IDbContextFactory<DemoDbContext> dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }
        public void AddContract(tbContract contract)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.tbContract.Add(contract);
                context.SaveChanges();
            }
        }
        public List<tbContract> GetContracts()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.tbContract.Include(x => x.tbUser).ToList();
            }
        }
        public List<tbUser> GetUsers()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.tbUser.ToList();
            }
        }
        public tbUser GetUser(string UserLogin)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.tbUser.FirstOrDefault(item => item.Login == UserLogin);
            }
        }

        public tbContract GetContract(int Id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.tbContract.Include(x => x.tbUser).First(item => item.Id == Id);
            }
        }

        public void EditContract(tbContract contract)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                tbContract dbContract = context.tbContract.Find(contract.Id);
                dbContract.OrgName = contract.OrgName;
                dbContract.RepresentedBy = contract.RepresentedBy;
                dbContract.StreetANumber = contract.StreetANumber;
                dbContract.MobileNumber = contract.MobileNumber;
                dbContract.Based = contract.Based;
                dbContract.BreakEnd = contract.BreakEnd;
                dbContract.City = contract.City;
                dbContract.PSC = contract.PSC;
                dbContract.WorkDescription = contract.WorkDescription;
                dbContract.BreakStart = contract.BreakStart;
                dbContract.LastChanged = contract.LastChanged;
                dbContract.RepresentedLastName = contract.RepresentedLastName;
                dbContract.RepresentedFirstName = contract.RepresentedFirstName;
                dbContract.WorkStart = contract.WorkStart;
                dbContract.WorkEnd = contract.WorkEnd;
                dbContract.Registred = contract.Registred;
                dbContract.ICO = contract.ICO;

                context.SaveChanges();
            }
        }
    }
}
