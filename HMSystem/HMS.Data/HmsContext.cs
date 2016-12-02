using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HMS.Core.Domain;
using HMS.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace HMS.Data
{
    public class HmsContext : DbContext
    {
        public HmsContext(DbContextOptions<HmsContext> options)
            : base(options)
        { }

        public DbSet<Hero> Heroes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new HeroMapping(modelBuilder.Entity<Hero>());
        }

    }
}
