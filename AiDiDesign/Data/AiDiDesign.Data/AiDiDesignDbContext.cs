namespace AiDiDesign.Data
{
    using System;
    using Microsoft.AspNet.Identity.EntityFramework;

    using AiDiDesign.Data.Models;

    public class AiDiDesignDbContext : IdentityDbContext<User>
    {
        public AiDiDesignDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static AiDiDesignDbContext Create()
        {
            return new AiDiDesignDbContext();
        }
    }
}
