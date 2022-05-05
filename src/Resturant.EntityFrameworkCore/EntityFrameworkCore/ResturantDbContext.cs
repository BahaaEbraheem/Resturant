using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Resturant.Authorization.Roles;
using Resturant.Authorization.Users;
using Resturant.MultiTenancy;
using Resturant.Models;

namespace Resturant.EntityFrameworkCore
{
    public class ResturantDbContext : AbpZeroDbContext<Tenant, Role, User, ResturantDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Admin> Admins { get; set; }

        public ResturantDbContext(DbContextOptions<ResturantDbContext> options)
            : base(options)
        {
        }
    }
}
