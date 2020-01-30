using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebPocket.Data.Entities.PocketEntities
{
    public class PocketMap
    {
        public PocketMap(EntityTypeBuilder<Pocket> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany(u => u.Pockets).HasForeignKey(p => p.UserId).IsRequired();
        }
    }
}
