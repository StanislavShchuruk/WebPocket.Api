using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebPocket.Data.Entities.AuthEntities
{
    public class Role : IdentityRole, IAuditModel
    {
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
