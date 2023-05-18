using EntityFrameworkLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDataAccess.Models
{
    public class tbContract : AbstractForeignModels
    {
        [Key]
        public int Id { get; set; }
        public int? tbUserId { get; set; }
        //public tbUser? tbUser { get; set; }
        public string? OrgName { get; set; }           
        public string? Registred { get; set; }              
        public string? Based { get; set; }            
        public string? ICO { get; set; }              
        public string? RepresentedBy { get; set; }              
        public string? StreetANumber { get; set; }             
        public string? City { get; set; }              
        public string? PSC { get; set; }      
        public string? RepresentedFirstName { get; set; }       
        public string? RepresentedLastName { get; set; }   
        public string? MobileNumber
        {
            get; set;
        }
        public string? WorkDescription { get; set; }
        
        
        public string? WorkStart
        {
            get; set;
        }
        
        public string? WorkEnd
        {
            get; set;
        }
        
        public string? BreakStart
        {
            get; set;
        }
       
        public string? BreakEnd
        {
            get; set;
        }
       
        public string? LastChanged
        {
            get; set;
        }

        //public string Help(string item)
        //{
        //    if (item.IsNullOrEmpty())
        //    {
        //        return "";
        //    }
        //    return item;
                          
        //}
    }   
}
