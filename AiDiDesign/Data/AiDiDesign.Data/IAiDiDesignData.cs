namespace AiDiDesign.Data
{
    using System.Data.Entity;
    
    using AiDiDesign.Data.Common.Repositories;
    using AiDiDesign.Data.Models;

    public interface IAiDiDesignData
    {
        IDeletableEntityRepository<User> Users { get; }

        IDeletableEntityRepository<Basket> Baskets { get; }

        IDeletableEntityRepository<Furniture> Furnitures { get; }

        IDeletableEntityRepository<FurnitureType> FurnitureTypes { get; }

        IDeletableEntityRepository<Order> Orders { get; }

        IDeletableEntityRepository<Picture> Pictures { get; }

        DbContext Context { get; }

        void SaveChanges();
    }
}
