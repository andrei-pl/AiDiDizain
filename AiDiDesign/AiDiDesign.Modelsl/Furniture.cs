namespace AiDiDesign.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Furniture : BaseEntry
    {
        private ICollection<Picture> picturesSource;
        private ICollection<FurnitureType> furnitureTypes;
        private ICollection<Order> orders;

        public Furniture()
        {
            this.picturesSource = new HashSet<Picture>();
            this.furnitureTypes = new HashSet<FurnitureType>();
            this.orders = new HashSet<Order>();
        }

        [Required]
        public string Name { get; set; }

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

        public string Description { get; set; }

        public int Price { get; set; }

        public virtual ICollection<Picture> PicturesSource
        {
            get { return this.picturesSource; }
            set
            {
                this.picturesSource = value;
            }
        }

        public int Quantity { get; set; }
    }
}
