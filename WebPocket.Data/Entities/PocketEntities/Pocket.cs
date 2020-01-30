using WebPocket.Data.Entities.AuthEntities;

namespace WebPocket.Data.Entities.PocketEntities
{
    public class Pocket : BaseClass, IAuditModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
