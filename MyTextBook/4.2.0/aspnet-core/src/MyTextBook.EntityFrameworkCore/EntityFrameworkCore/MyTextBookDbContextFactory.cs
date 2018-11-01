using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using MyTextBook.Configuration;
using MyTextBook.Web;

namespace MyTextBook.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class MyTextBookDbContextFactory : IDesignTimeDbContextFactory<MyTextBookDbContext>
    {
        public MyTextBookDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MyTextBookDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            MyTextBookDbContextConfigurer.Configure(builder, configuration.GetConnectionString(MyTextBookConsts.ConnectionStringName));

            return new MyTextBookDbContext(builder.Options);
        }
    }
}
