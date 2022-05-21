using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Resturant.Authorization.Roles;
using Resturant.Authorization.Users;
using Resturant.MultiTenancy;
using Resturant.Models;
using System;
using Resturant.Models.Address;

namespace Resturant.EntityFrameworkCore
{
    public class ResturantDbContext : AbpZeroDbContext<Tenant, Role, User, ResturantDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Country> Countries { get; set; }

        public ResturantDbContext(DbContextOptions<ResturantDbContext> options)
            : base(options)
        {
        }

        //public ResturantDbContext CreateDbContext(string[] args)
        //{
        //    var optionsBuilder = new DbContextOptionsBuilder<ResturantDbContext>();
        //    optionsBuilder.UseSqlServer(ResturantConsts.ConnectionStringName, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));

        //    return new ResturantDbContext(optionsBuilder.Options);
        //}
    }
}
