namespace AiDiDesign.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AiDiDesign.Data.Models;
    using AiDiDesign.Data.Migrations;
    using AiDiDesign.Data.Common.Models;

    public class AiDiDesignDbContext : IdentityDbContext<User>, IAiDiDesignDbContext
    {
        public AiDiDesignDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AiDiDesignDbContext, Configuration>());
        }

        public static AiDiDesignDbContext Create()
        {
            return new AiDiDesignDbContext();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public IDbSet<Basket> Baskets { get; set; }

        public IDbSet<Furniture> Furnitures { get; set; }

        public IDbSet<FurnitureType> FurnitureTypes { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public IDbSet<FirstPageText> FirstPageTexts { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in this.ChangeTracker.Entries().Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }


        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
    }
}
