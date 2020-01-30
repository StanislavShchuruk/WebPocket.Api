using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebPocket.Data.Entities.PocketEntities;

namespace WebPocket.Repo.DbContexts.EntityConfigurations
{
    public class PocketConfiguration : BaseEntityConfiguration<Pocket>
    {
        public override void Configure(EntityTypeBuilder<Pocket> builder)
        {
            base.Configure(builder);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Pockets)
                .HasForeignKey(p => p.UserId)
                .IsRequired();
        }
    }
}
