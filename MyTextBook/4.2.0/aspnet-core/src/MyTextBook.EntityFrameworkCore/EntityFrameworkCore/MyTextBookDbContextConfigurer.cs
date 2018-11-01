using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyTextBook.EntityFrameworkCore
{
    public static class MyTextBookDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyTextBookDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyTextBookDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
