using System;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using DB.Models;

namespace DB
{
    public partial class MyDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Int32>, Int32>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        }

        public virtual DbSet<Table1> Table1s { get; set; }
        public virtual DbSet<Table2> Table2s { get; set; }
        public virtual DbSet<Table3> Table3s { get; set; }
    }
}
