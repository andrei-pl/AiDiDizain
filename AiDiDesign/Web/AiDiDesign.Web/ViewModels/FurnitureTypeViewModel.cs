namespace AiDiDesign.Web.ViewModels
{
    using System;

    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.Infrastructure.Mapping;

    public class FurnitureTypeViewModel : IMapFrom<FurnitureType>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}