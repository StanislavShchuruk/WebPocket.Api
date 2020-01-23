using System;

namespace WebPocket.Data.Entities
{
    public interface IAuditModel
    {
       DateTime Created { get; set; }
       DateTime Updated { get; set; }
    }
}
