using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class ContractModel
    {
        public int Id { get; set; }
        public string OrgName { get
            {
                return String.IsNullOrWhiteSpace(City) ? "" : City;
            }
            set { }
        }
        public string Registred { get; set; }
        public string Based { get; set; }
        public string ICO { get; set; }
        public string RepresentedBy { get; set; }
        public string StreetANumber { get; set; }
        public string City { get
            {
                return String.IsNullOrWhiteSpace(City) ? "" : City;
            }
            set{ }
        }
    
        public string PSC { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string WorkDescription { get; set; }
        public string WorkStart { get; set; }
        public string WorkEnd { get; set; }
        public string BreakStart { get; set; }
        public string BreakEnd { get; set; }
        public string LastChanged { get
            {
                return String.IsNullOrWhiteSpace(City) ? "" : City;
            }
            set { } }
    }
}
