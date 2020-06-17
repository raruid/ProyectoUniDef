using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace UniDef.EntityFrameworkCore
{
    public static class UniDefDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<UniDefDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<UniDefDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
