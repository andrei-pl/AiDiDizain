namespace AiDiDesign.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AiDiDesign.Data.Common.Models;

    public class Order : DeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [Required]
        public Guid FurnitureId { get; set; }

        public virtual Furniture Furniture { get; set; }

        [Required]
        public int Quantity { get; set; }

        public Guid BasketId { get; set; }

        public virtual Basket Basket { get; set; }
    }
}
