namespace AiDiDesign.Web.ViewModels
{
    using System;
    
    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.Infrastructure.Mapping;

    public class PictureViewModel : IMapFrom<Picture>
    {
        public Guid Id { get; set; }

        public string PictureUrl { get; set; }

        public Guid FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}