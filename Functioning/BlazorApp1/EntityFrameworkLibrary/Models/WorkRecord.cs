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
        public DateTime Date { get; set; }
        public string? WorkDescription { get; set; }
        public string? WorkTime { get; set; }
    }
}
