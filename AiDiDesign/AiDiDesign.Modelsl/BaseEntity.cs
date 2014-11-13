namespace AiDiDesign.Models
{
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseEntry
    {
        [Key]
        public int Id { get; set; }
    }
}
