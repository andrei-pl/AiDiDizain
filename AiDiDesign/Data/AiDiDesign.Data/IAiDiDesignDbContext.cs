namespace AiDiDesign.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using AiDiDesign.Data.Models;

    public interface  IAiDiDesignDbContext
    {
        IDbSet<T> Set<T>() where T : class;

        IDbSet<Basket> Baskets { get; set; }

        IDbSet<Furniture> Furnitures { get; set; }

        IDbSet<FurnitureType> FurnitureTypes { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Picture> Pictures { get; set; }

        IDbSet<FirstPageText> FirstPageTexts { get; set; }

        IDbSet<User> Users { get; set; }

        DbContext DbContext { get; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
