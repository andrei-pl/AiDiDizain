namespace AiDiDesign.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using AiDiDesign.Data.Models;
    using AiDiDesign.Data.Common.Models;
    using AiDiDesign.Data.Common.Repositories;

    public class AiDiDesignData : IAiDiDesignData
    {
        private IAiDiDesignDbContext context;
        private IDictionary<Type, object> repositories;

        public static IAiDiDesignData Create(IAiDiDesignDbContext context)
        {
            return new AiDiDesignData(context);
        }

        public AiDiDesignData(IAiDiDesignDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IDeletableEntityRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IDeletableEntityRepository<Basket> Baskets
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public IDeletableEntityRepository<Furniture> Furnitures
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public IDeletableEntityRepository<FurnitureType> FurnitureTypes
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public IDeletableEntityRepository<Order> Orders
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public IDeletableEntityRepository<Picture> Pictures
        {
            get
            {
                // TODO: Implement this property getter
                throw new NotImplementedException();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context.DbContext;
            }
        }

        public void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (Exception)
            {

            }
        }

        private IDeletableEntityRepository<T> GetRepository<T>() where T : class, IDeletableEntity
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeof(DeletableEntityRepository<T>), this.context));
            }

            return (IDeletableEntityRepository<T>)this.repositories[typeOfModel];
        }
    }
}