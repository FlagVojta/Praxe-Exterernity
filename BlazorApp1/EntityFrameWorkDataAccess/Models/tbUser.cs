using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkDataAccess.Models
{
    public class tbUser
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Id")]
        public int ContractId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [ForeignKey("Id")]
        public tbContract Contract { get; set; }
    }
}
