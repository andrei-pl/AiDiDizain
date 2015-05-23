namespace AiDiDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AiDiDesign.Data.Common.Models;

    public class Picture : DeletableEntity
    {
        public Picture()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string PictureUrl { get; set; }

        [Required]
        public Guid FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}
