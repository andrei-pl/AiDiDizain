namespace AiDiDesign.Web.ViewModels
{
    using System;
   
    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.Infrastructure.Mapping;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ProductHomeViewModel : IMapFrom<Furniture>
    {
        private ICollection<PictureViewModel> picturesSource;
     
        public ProductHomeViewModel()
        {
            this.picturesSource = new HashSet<PictureViewModel>();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<FurnitureType> FurnitureTypes  { get; set; }

        public virtual ICollection<Picture> PicturesSource { get; set; }
        
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}