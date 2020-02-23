using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebPocket.Data.Entities.AuthEntities;
using WebPocket.Data.Entities.PocketEntities;
using WebPocket.Repo.DbContexts.EntityConfigurations;
using WebPocket.Repo.Extensions;

namespace WebPocket.Repo.DbContexts
{
    public class AppDbContext : IdentityDbContext<User, Role, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        public DbSet<Pocket> Pockets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyEntitiesConfigurations(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangeOnSuccess, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            ChangeTracker.ApplyAuditInformation();

            return await base.SaveChangesAsync(acceptAllChangeOnSuccess, cancellationToken);
        }

        protected void ApplyEntitiesConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Pocket>(new PocketConfiguration());
        }
    }
}
