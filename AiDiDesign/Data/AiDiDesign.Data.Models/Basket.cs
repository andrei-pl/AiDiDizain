namespace AiDiDesign.Data.Models
{
    using System;
    using System.Collections.Generic;

    using AiDiDesign.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Basket : DeletableEntity
    {
        private ICollection<Order> orders;

        public Basket()
        {
            this.Id = Guid.NewGuid();
            this.orders = new HashSet<Order>();
        }

        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Order> Orders
        {
            get
            {
                return this.orders;
            }
            set
            {
                this.orders = value;
            }
        }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public String Address { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public String Phone { get; set; }
    }
}
