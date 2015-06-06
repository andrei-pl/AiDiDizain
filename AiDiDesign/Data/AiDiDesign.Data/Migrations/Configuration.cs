namespace AiDiDesign.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using AiDiDesign.Data.Seeders;
    
    public sealed class Configuration : DbMigrationsConfiguration<AiDiDesignDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            // TODO: Remove when in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AiDiDesignDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Users.Any())
            {
                StaticDataSeeder.SeedRoles(context);
                StaticDataSeeder.SeedAdmin(context);
                StaticDataSeeder.SeedUsers(context);
            }

            if(!context.Furnitures.Any())
            {
                StaticDataSeeder.SeedProducts(context);
            }
        }
    }
}
