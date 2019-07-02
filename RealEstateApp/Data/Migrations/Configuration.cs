namespace RealEstateApp.Migrations
{
    using Data;
    using Data.Model;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<RealEstateAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "RealEstateApp.Models.RealEstateAppContext";
        }

        protected override void Seed(RealEstateAppContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(x => x.Id,

                   new User() { Id = 1, Name = "archer" },
                   new User() { Id = 2, Name = "amy" },
                   new User() { Id = 3, Name = "senthil" }
            );
        }
    }
}
