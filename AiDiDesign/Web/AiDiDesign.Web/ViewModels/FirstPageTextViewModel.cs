namespace AiDiDesign.Web.ViewModels
{
    using System;

    using AiDiDesign.Data.Models;
    using AiDiDesign.Web.Infrastructure.Mapping;

    public class FirstPageTextViewModel : IMapFrom<FirstPageText>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}