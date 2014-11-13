namespace AiDiDesign.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Order : BaseEntity
    {
        private ICollection<Furniture> furnitures;

        public Order()
        {
            this.furnitures = new HashSet<Furniture>();
        }

        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string Address { get; set; }

        public string Phone { get; set; }

        [Required]
        public DateTime Date { get; set; }

        ICollection<Furniture> Furnitures
        {
            get { return this.furnitures; }
            set
            {
                this.furnitures = value;
            }
        }
    }
}
