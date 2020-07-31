using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Context
{
    public partial class DBContext : IdentityDbContext<UserIdentity>
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        #region Entities
        //public City City { get; set; }
        //public State State { get; set; }
        //public Country Country { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }



    }

}
