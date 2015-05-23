namespace AiDiDesign.Data.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using AiDiDesign.Data.Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    
    public class User : IdentityUser, IAuditInfo, IDeletableEntity
    {

        private ICollection<Basket> baskets;

        public User()
        {
            // This will prevent UserManager.CreateAsync from causing exception
            this.CreatedOn = DateTime.Now;

            this.baskets = new HashSet<Basket>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserImage { get; set; }

        public ICollection<Basket> Baskets
        {
            get
            {
                return this.baskets;
            }
            set
            {
                this.baskets = value;
            }
        }

        // IAuditInfo
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsHidden { get; set; }

        // IDeletableEntity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
