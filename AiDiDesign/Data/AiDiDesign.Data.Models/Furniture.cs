namespace AiDiDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using AiDiDesign.Data.Common.Models;

    public class Furniture : AuditInfo, IDeletableEntity
    {
        private ICollection<Picture> picturesSource;
        private ICollection<FurnitureType> furnitureTypes;
        private ICollection<Order> orders;

        public Furniture()
        {
            this.Id = new Guid();
            this.picturesSource = new HashSet<Picture>();
            this.furnitureTypes = new HashSet<FurnitureType>();
            this.orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        [Required]
        public virtual ICollection<FurnitureType> FurnitureTypes 
        {
            get { return this.furnitureTypes; }
            set
            {
                this.furnitureTypes = value;
            }
        }

        public virtual ICollection<Picture> PicturesSource
        {
            get { return this.picturesSource; }
            set
            {
                this.picturesSource = value;
            }
        }
        
        public int Price { get; set; }

        public int Quantity { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
