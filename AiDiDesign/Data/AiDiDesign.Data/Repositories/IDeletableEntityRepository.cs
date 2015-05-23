namespace AiDiDesign.Data.Repositories
{
    using System.Linq;

    interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
