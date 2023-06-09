﻿using EntityFrameWorkDataAccess.Models;
using EntityFrameworkLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        //Contract----------------------------------------------------------------------------------
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
        //User----------------------------------------------------------------------------------------------
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
        //Application-------------------------------------------------------------------------------------
        public List<Application> GetApplications()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.applications.Include(x => x.tbUser).ToList();
            }
        }
        public Application GetApplication(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                
                return context.applications.Include(x => x.tbUser).FirstOrDefault(item => item.Id == id);
            }
        }
        public void EditApplication(Application applicationForm)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                Application app = context.applications.Find(applicationForm.Id);
                
                app.BirthDate = applicationForm.BirthDate;
                app.PSC = applicationForm.PSC;
                app.PhoneNumber = applicationForm.PhoneNumber;
                app.City = applicationForm.City;
                app.StreeAndNumber = applicationForm.StreeAndNumber;

                context.SaveChanges();
            }
        }
        //Record-------------------------------------------------------------------------------------------------------------
        public List<WorkRecord> GetRecords()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.workRecords.Include(x => x.workDays).Include(x => x.tbUser).ToList();
            }
        }
        public WorkRecord GetRecord(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.workRecords.Include(x => x.workDays).Include(x => x.tbUser).FirstOrDefault(item => item.Id == id);
            }
        }
        public void EditRecord(WorkRecord record)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                WorkRecord rcd = context.workRecords.Include(x => x.workDays).FirstOrDefault(item => item.Id == record.Id);

                rcd.ReviewOfStudent = record.ReviewOfStudent;
                rcd.ReviewOfCompany = record.ReviewOfCompany;
                rcd.workDays = rcd.workDays;
                context.SaveChanges();

            }
        }
        //Day___________________________________________________________________________________________________________________________
        public void EditDay(WorkDay day)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                WorkDay daydb = context.workDays.Find(day.Id);
                daydb.WorkTime = day.WorkTime;
                daydb.WorkDescription = day.WorkDescription;                
                context.SaveChanges();
            }
        }
    }
}
