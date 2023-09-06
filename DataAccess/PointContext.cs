using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PointContext : DbContext
    {
        // Representation of collection of points in a database
        public DbSet<Point> Points { get; set;}

        // Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=LAPTOP-010BK67M;Database=squareapi_db;Username=zahra;Password=adform");
        }
    }
}
