namespace AiDiDesign.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Furniture : BaseEntity
    {
        private ICollection<Picture> picturesSource;
        private ICollection<FurnitureType> furnitureTypes;

        public Furniture()
        {
            this.picturesSource = new HashSet<Picture>();
            this.furnitureTypes = new HashSet<FurnitureType>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<FurnitureType> FurnitureTypes 
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
