using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace RTree.Data
{
    public class ApplicationDbContext : DbContext
    {
#nullable disable
        public DbSet<BinaryAttrSet> BinaryAttrSet { get; set; }
        public DbSet<BinaryAttr> BinaryAttr { get; set; }
        
        private IHttpContextAccessor HttpContextAccessor { get; set; }
#nullable enable

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : base(dbContext) { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext, IHttpContextAccessor httpContextAccessor) : base(dbContext)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public override int SaveChanges()
        {
            AddFingerPrinting();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            AddFingerPrinting();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void AddFingerPrinting()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
            var added = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);

            foreach (EntityEntry entry in added)
            {
                if (entry.Entity is FingerPrintEntityBase fingerPrintEntry)
                {
                    fingerPrintEntry.CreatedOn = DateTime.UtcNow;
                    fingerPrintEntry.CreatedBy = HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                    fingerPrintEntry.ModifiedOn = DateTime.UtcNow;
                    fingerPrintEntry.ModifiedBy = HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                }
            }

            foreach (EntityEntry entry in modified)
            {
                if (entry.Entity is FingerPrintEntityBase fingerPrintEntry)
                {
                    ResetValue(entry, nameof(FingerPrintEntityBase.CreatedOn));
                    ResetValue(entry, nameof(FingerPrintEntityBase.CreatedBy));

                    fingerPrintEntry.ModifiedOn = DateTime.UtcNow;
                    fingerPrintEntry.ModifiedBy = HttpContextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).Value ?? string.Empty;
                }
            }
        }

        private static void ResetValue(EntityEntry entry, string propertyName)
        {
            PropertyEntry property = entry.Property(propertyName);
            property.CurrentValue = property.OriginalValue;
        }
    }
}
