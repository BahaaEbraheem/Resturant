using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Resturant.EntityFrameworkCore
{
    public static class ResturantDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ResturantDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ResturantDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
