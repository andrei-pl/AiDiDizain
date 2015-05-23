namespace AiDiDesign.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
 
    //public enum FurnitureType
    //{
    //    LivingRoom,
    //    Kitchen,
    //    Design,
    //    Mattress,
    //    Bed,
    //    Classic,
    //    Lux,
    //    Art,
    //    Versace,
    //    Dining,
    //    Chairs,
    //    Children
    //}
    public class FurnitureType
    {
        public FurnitureType()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
