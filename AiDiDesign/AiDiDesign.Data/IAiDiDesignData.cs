namespace AiDiDesign.Data
{
    using AiDiDesign.Data.Repositories;
    using AiDiDesign.Models;

    public interface IAiDiDesignData
    {
        IRepository<Furniture> Furnitures { get; }
        
        IRepository<Order> Orders { get; }
        
        IRepository<Picture> Pictures { get; }

        IRepository<User> Users { get; }

        void SaveChanges();
    }
}
