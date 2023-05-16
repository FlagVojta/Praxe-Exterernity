using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkDataAccess.Models;
using EntityFrameworkLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace EntityFrameWorkDataAccess
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {

        }
        public DbSet<tbUser> tbUser { get; set; }
        public DbSet<tbContract> tbContract { get; set; }
        public DbSet<Application> applications { get; set; }
    }
}
