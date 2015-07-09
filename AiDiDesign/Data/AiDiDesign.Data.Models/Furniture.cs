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
            this.Id = Guid.NewGuid();
            this.picturesSource = new HashSet<Picture>();
            this.furnitureTypes = new HashSet<FurnitureType>();
            this.orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Order> Orders
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
        
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
