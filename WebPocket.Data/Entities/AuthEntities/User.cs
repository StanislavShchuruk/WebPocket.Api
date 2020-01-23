using System;
using Microsoft.AspNetCore.Identity;

namespace WebPocket.Data.Entities.AuthEntities
{
    public class User : IdentityUser, IAuditModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
