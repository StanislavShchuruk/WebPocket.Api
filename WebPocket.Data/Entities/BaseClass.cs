using System;

namespace WebPocket.Data.Entities
{
    public abstract class BaseClass : IAuditModel, IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Updated { get; set; }
    }
}
