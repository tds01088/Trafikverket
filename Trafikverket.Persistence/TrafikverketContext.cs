using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;
using Trafikverket.Domain.Common;
using Trafikverket.Domain.Entities;


namespace Trafikverket_ConsoleApp.Infrastructure
{
    public class TrafikverketContext : DbContext
    {
        protected TrafikverketContext(DbContextOptions options) : base(options) { }

        public TrafikverketContext(DbContextOptions<TrafikverketContext> options) : this((DbContextOptions)options)
        {
        }

        public virtual DbSet<CameraEntity> Person { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Zana Ali";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "Zana Ali";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}