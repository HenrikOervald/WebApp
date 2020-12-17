using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppBackend.Models.DBmodels;
using WebAppBackend.Models.IOmodels;

namespace WebAppBackend.Models
{
    public class IODBContext : DbContext
    {
        public IODBContext(DbContextOptions<IODBContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<User_Flower> User_Flowers { get; set; }
    }
}
