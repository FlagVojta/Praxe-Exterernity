using EntityFrameWorkDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkLibrary.Models
{
    public class Application : AbstractForeignModels
    {
        public int Id { get; set; }
        public int? tbUserId { get; set; }
        public string? StreeAndNumber { get; set; }
        public string? City { get; set; }
        public string? PSC { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthDate { get; set; }
        //public tbUser tbUser { get; set; }
    }
}
