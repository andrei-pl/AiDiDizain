namespace AiDiDesign.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Picture : BaseEntity
    {
        [Required]
        public string ResourcePath { get; set; }

        [Required]
        public int FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }
    }
}
