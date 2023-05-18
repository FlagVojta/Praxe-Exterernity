using EntityFrameWorkDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.Models
{
    public class WorkRecord
    {
        public int Id { get; set; }
        public int tbUserId { get; set; }
        public string ReviewOfCompany { get; set; }
        public string ReviewOfStudent { get; set; }
        public List<WorkDay> workDays { get; set; }
        public tbUser tbUser { get; set; }
    }
}
