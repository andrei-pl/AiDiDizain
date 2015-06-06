namespace AiDiDesign.Web.ViewModels
{
    using System;
   
    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.Infrastructure.Mapping;
    using System.Collections.Generic;

    public class ProductHomeViewModel : IMapFrom<Furniture>
    {
        private ICollection<PictureViewModel> picturesSource;
     
        public ProductHomeViewModel()
        {
            this.picturesSource = new HashSet<PictureViewModel>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public virtual ICollection<PictureViewModel> PicturesSource
        {
            get { return this.picturesSource; }
            set
            {
                this.picturesSource = value;
            }
        }
        
        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}