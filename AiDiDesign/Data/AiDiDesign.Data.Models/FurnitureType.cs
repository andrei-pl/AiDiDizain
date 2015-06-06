namespace AiDiDesign.Data.Models
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
 
    //public enum FurnitureType
    //{
    //    LivingRoom,
    //    Kitchen,
    //    Design,
    //    Mattress,
    //    Bed,
    //    Classic,
    //    Lux,
    //    Art,
    //    Versace,
    //    Dining,
    //    Chairs,
    //    Children
    //}

    // It must be this if we want to have dynamic menu.
    // For static menu use the code above

    public class FurnitureType
    {
        ICollection<Furniture> furnitures;

        public FurnitureType()
        {
            this.Id = Guid.NewGuid();
            this.furnitures = new HashSet<Furniture>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Furniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            set
            {
                this.furnitures = value;
            }
        }
    }
}
