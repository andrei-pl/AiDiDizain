namespace AiDiDesign.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    using AiDiDesign.Data.Migrations;
    using AiDiDesign.Models;
    
    public class AiDiDesignDBContext : IdentityDbContext<User>
    {
        public AiDiDesignDBContext()
            : base("AiDiDesign", throwIfV1Schema: false)
        {
             Database.SetInitializer(new MigrateDatabaseToLatestVersion<AiDiDesignDBContext, Configuration>());
             
        }

        public static AiDiDesignDBContext Create()
        {
            return new AiDiDesignDBContext();
        }

        public IDbSet<Furniture> Furnitures { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Picture> Pictures { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

    }
}
