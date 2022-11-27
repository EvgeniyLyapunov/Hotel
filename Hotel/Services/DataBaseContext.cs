using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Hotel.Models;

namespace Hotel.Services
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<City> Citys { get; set; }
        public DbSet<Check> Checks { get; set; }


    }
}
