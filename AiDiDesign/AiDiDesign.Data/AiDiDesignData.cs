namespace AiDiDesign.Data
{
    using System;
    using AiDiDesign.Data.Repositories;
    using AiDiDesign.Models;
    using System.Collections.Generic;

    public class AiDiDesignData : IAiDiDesignData
    {
        private AiDiDesignDBContext context;
        private IDictionary<Type, object> repositories;

        //public AiDiDesignData()
        //    : this(new AiDiDesignDBContext())
        //{

        //}

        public AiDiDesignData(AiDiDesignDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Furniture> Furnitures
        {
            get
            {
                return this.GetRepository<Furniture>();
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IRepository<Picture> Pictures
        {
            get
            {
                return this.GetRepository<Picture>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);

            if (!this.repositories.ContainsKey(typeOfModel))
            {
                this.repositories.Add(typeOfModel, Activator.CreateInstance(typeof(Repository<T>), this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
