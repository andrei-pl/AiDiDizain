namespace AiDiDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AiDiDesign.Data.Common.Models;

    public class FirstPageText : DeletableEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
