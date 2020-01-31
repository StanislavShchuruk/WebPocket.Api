using WebPocket.Data.Entities.PocketEntities;

namespace WebPocket.Data.ViewModels.PocketViewModels
{
    public class PocketViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PocketViewModel SetFrom(Pocket entity)
        {
            Id = entity.Id;
            Name = entity.Name;

            return this;
        }
    }
}
