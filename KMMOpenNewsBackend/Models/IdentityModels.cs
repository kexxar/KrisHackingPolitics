using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace KMMOpenNewsBackend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public int? UserTypeId { get; set; }
        [ForeignKey("UserTypeId")]
        public virtual UserType UserType { get; set; }

        public virtual ICollection<NewsPost> NewsPosts { get; set; }

        public virtual ICollection<UserComment> UserComments { get; set; }

        public virtual ICollection<UserScore> GivenScores { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<UserComment> UserComments { get; set; }
        public DbSet<UserScore> UserScores { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UserComment>().HasRequired(c => c.NewsPost).WithRequiredDependent().WillCascadeOnDelete(false);
            //modelBuilder.Entity<UserComment>().HasRequired(c => c.User).WithRequiredDependent().WillCascadeOnDelete(false);
            //modelBuilder.Entity<NewsPost>().HasRequired(n => n.
            modelBuilder.Entity<UserComment>().HasRequired(c => c.User).WithMany().WillCascadeOnDelete(false);
            //modelBuilder.Entity<UserScore>().HasRequired(s => s.NewsPost).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<UserScore>().HasRequired(s => s.User).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<NewsPost>().Property(f => f.NewsDate).HasColumnType("datetime2").HasPrecision(0);
            modelBuilder.Entity<UserComment>().Property(f => f.CommentDate).HasColumnType("datetime2").HasPrecision(0);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}