using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using WebPocket.Data.Entities.PocketEntities;

namespace WebPocket.Data.Entities.AuthEntities
{
    public class User : IdentityUser, IAuditModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public List<Pocket> Pockets { get; set; }
    }
}
