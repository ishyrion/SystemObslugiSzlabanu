using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemObslugiSzlabanu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }


        public DbSet<Plate> Plate { get; set; }
        public DbSet<Plate> Admin { get; }

    }
}
