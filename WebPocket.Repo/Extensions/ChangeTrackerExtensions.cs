using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using WebPocket.Data.Entities;

namespace WebPocket.Repo.Extensions
{
    public static class ChangeTrackerExtensions
    {
        public static void ApplyAuditInformation(this ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                if (!(entry.Entity is IAuditModel auditModel)) continue;

                var now = DateTime.UtcNow;

                switch (entry.State)
                {
                    case EntityState.Modified:
                        auditModel.Updated = now;
                        break;
                    case EntityState.Added:
                        auditModel.Created = now;
                        break;
                }
            }
        }
    }
}
