using System;

namespace WebPocket.Data.Entities
{
    public abstract class BaseClass : IAuditModel, IEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
