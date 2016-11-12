namespace KMMOpenNewsBackend.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KMMOpenNewsBackend.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KMMOpenNewsBackend.Models.ApplicationDbContext";
        }

        protected override void Seed(KMMOpenNewsBackend.Models.ApplicationDbContext context)
        {

            Console.WriteLine("starting seed");
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

            //Initialize the debugger
            if (System.Diagnostics.Debugger.IsAttached == false)
            {
                System.Diagnostics.Debugger.Launch();
            }

            var userTypes = new List<UserType>
            {
                new UserType { Id = 1, Name = "Admin" },
                new UserType { Id = 2, Name = "User" },
                new UserType { Id = 3, Name = "Journalist" },
            };
            Console.WriteLine("update user types");
            userTypes.ForEach(x => context.UserTypes.AddOrUpdate(p => p.Id, x));

            //var user = context.Users.First(x => x.Email.Equals("keravica@gmail.com"));
            ApplicationUser user = null;
            try
            {
                user = context.Users.First(x => x.Email.Equals("keravica@gmail.com"));
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
            if (user == null) {
                //first approach
                //var passwordHash = new PasswordHasher();
                //string password = passwordHash.HashPassword("87Kexxar123!");
                //context.Users.AddOrUpdate(u => u.UserName, new ApplicationUser {
                //    UserName = "kexxar",
                //    PasswordHash = password,
                //    Email = "keravica@gmail.com"
                //});
                Console.WriteLine("user is null");

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var userToInsert = new ApplicationUser { UserName = "kexxar", Email = "keravica@gmail.com" };
                userToInsert.UserTypeId = 1;
                userManager.Create(userToInsert, "87kexxar123!");
                user = userToInsert;
            }

            //var post = new NewsPost {
            //    Body = "ballabladklasblsb",
            //    NewsType = "politics",
            //    Scores = "554554434325",
            //    Title = "Test title",
            //    User = user
            //};

            Console.WriteLine("create new post");
            var post = new NewsPost
            {
                Body = "nvad jashjavh  biaev ",
                Id = 1,
                NewsDate = DateTime.Now,
                NewsType = "Politics",
                Scores = new List<UserScore> { new UserScore { Score=1, User = user } },
                User = user,
                Title = "BlaBla"
            };

            context.NewsPosts.AddOrUpdate(p=>p.Id, post);
        }
    }
}
