using BDC.Excel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace BDC.Excel.Contexts
{
    public class BDCContext : DbContext
    {
        //public DbSet<EntryDto> ExcelEntries { get; set; }
        public DbSet<EntryDto> Entries { get; set; }

        // constructor function 
        public BDCContext(DbContextOptions<BDCContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EntryDto>().ToTable("ExcelEntries");
            base.OnModelCreating(modelBuilder);
        }
    }
}
