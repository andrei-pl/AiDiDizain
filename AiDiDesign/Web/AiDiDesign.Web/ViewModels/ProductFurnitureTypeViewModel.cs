namespace AiDiDesign.Web.ViewModels
{
    using System.Collections.Generic;

    public class ProductFurnitureTypeViewModel
    {
        // This model is to collect two models into one general and pass this to view from controller
        private ICollection<FurnitureTypeViewModel> furnitureTypeViewModels;

        public ProductHomeViewModel ProductHomeViewModel { get; set; }

        public ProductFurnitureTypeViewModel()
        {
            this.furnitureTypeViewModels = new HashSet<FurnitureTypeViewModel>(); ;
        }

        public virtual ICollection<FurnitureTypeViewModel> FurnitureTypeViewModels
        {
            get
            {
                return this.furnitureTypeViewModels;
            }
            set
            {
                this.furnitureTypeViewModels = value;
            }
        }
    }
}