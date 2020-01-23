using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebPocket.Common.Configurations;
using WebPocket.Repo.DbContexts;

namespace WebPocket.Repo
{
    public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        private static string DbConnectionString = new DatabaseConfiguration().GetDbConfigurationString();

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(DbConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }

    }
}
