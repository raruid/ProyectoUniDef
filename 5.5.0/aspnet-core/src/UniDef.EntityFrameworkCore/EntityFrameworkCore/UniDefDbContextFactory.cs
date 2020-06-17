using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using UniDef.Configuration;
using UniDef.Web;

namespace UniDef.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class UniDefDbContextFactory : IDesignTimeDbContextFactory<UniDefDbContext>
    {
        public UniDefDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<UniDefDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            UniDefDbContextConfigurer.Configure(builder, configuration.GetConnectionString(UniDefConsts.ConnectionStringName));

            return new UniDefDbContext(builder.Options);
        }
    }
}
