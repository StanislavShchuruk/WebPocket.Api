using System.ComponentModel.DataAnnotations;
using WebPocket.Data.Entities.PocketEntities;

namespace WebPocket.Services.ViewModels.PocketViewModels
{
    public class PocketViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public PocketViewModel SetFrom(Pocket entity)
        {
            Id = entity.Id;
            Name = entity.Name;

            return this;
        }
    }
}
