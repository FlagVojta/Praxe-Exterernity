using EntityFrameWorkDataAccess;
using EntityFrameWorkDataAccess.Models;
using EntityFrameworkLibrary.Models;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary
{
    public class CustomNavigation
    {     
        public string NavigateToContract(AuthenticationState authState,DatabaseService dbService)
        {
            tbContract contract = dbService.GetContracts().FirstOrDefault(item => item.tbUser.Login == authState.User.Identity.Name);
            //navMan.NavigateTo($"/contract/{contract.Id}");
            if (contract == null)
            {
                return "";
            }
            return $"/contract/{contract.Id}"!;
        }

        public string NavigateToApplicationForm(AuthenticationState authState,DatabaseService dbService)
        {
            Application applicationForm = dbService.GetApplications().FirstOrDefault(item => item.tbUser.Login == authState.User.Identity.Name);
            //navMan.NavigateTo($"/contract/{contract.Id}");
            if (applicationForm == null)
            {
                return "";
            }
            return $"/ApplicationForm/{applicationForm.Id}";
        }
        public string NavigateToRecordForm(AuthenticationState authState, DatabaseService dbService)
        {
            WorkRecord workRecord = dbService.GetRecords().FirstOrDefault(item => item.tbUser.Login == authState.User.Identity.Name);
            //navMan.NavigateTo($"/contract/{contract.Id}");
            if (workRecord == null)
            {
                return "";
            }
            return $"/Record/{workRecord.Id}";
        }
    }
}
