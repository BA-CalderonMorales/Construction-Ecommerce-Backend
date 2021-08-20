using eCommerceStarterCode.Configuration;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

namespace eCommerceStarterCode.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Properties that will represent each table in Models folder within Database.
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Contract> Contracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            // modelBuilder.Entity<Owner>(); // All data in this table is nullable. Don't really need to populate owner.

            // modelBuilder.Entity<Customer>(); // All data in this table is nullable. Don't really want to populate customer.

            // modelBuilder.Entity<Contract>(); // All data in this table is nullable. Don't really need to populate contract.

            // modelBuilder.Entity<Review>(); // All data in this table is nullable. Don't really want to populate reviews.

            modelBuilder.Entity<Project>()
                 .HasData(
                    new Project { ProjectId = 1, NameOfProject = "First Project", DetailsOfProject = "Details for First Project", ImageOfProject = "insertImageForFirstProject", LocationOfProject = "insertLocationForFirstProject", DurationOfProject = "15 Days", ReviewId = null, CategoryId = 1},
                    new Project { ProjectId = 2, NameOfProject = "Second Project", DetailsOfProject = "Details for Second Project", ImageOfProject = "insertImageForSecondProject", LocationOfProject = "insertLocationForSecondProject", DurationOfProject = "2 Days", ReviewId = null, CategoryId = 2 },
                    new Project { ProjectId = 3, NameOfProject = "Third Project", DetailsOfProject = "Details for Third Project", ImageOfProject = "insertImageForThirdProject", LocationOfProject = "insertLocationForThirdProject", DurationOfProject = "2 Months", ReviewId = null, CategoryId = 3 },
                    new Project { ProjectId = 4, NameOfProject = "Fourth Project", DetailsOfProject = "Details for Fourth Project", ImageOfProject = "insertImageForFourthProject", LocationOfProject = "insertLocationForFourthProject", DurationOfProject = "3 Months", ReviewId = null, CategoryId = 4 }
               );

            modelBuilder.Entity<Category>()
                .HasData(
                    new Category { CategoryId = 1, CategoryName = "Roofing" },
                    new Category { CategoryId = 2, CategoryName = "Plumbing" },
                    new Category { CategoryId = 3, CategoryName = "Tile" },
                    new Category { CategoryId = 4, CategoryName = "Concrete" },
                    new Category { CategoryId = 5, CategoryName = "Remodeling" }
                );
        }

    }
}


// Placing this commented out code here for whether or not I'll need to create a junction table 
// for any of these tables.

//modelBuilder.Entity<ShoppingCart>()
//    .HasKey(sc => new { sc.UserId, sc.ProductId });
//modelBuilder.Entity<ShoppingCart>()
//    .HasOne(sc => sc.User)
//    .WithMany(sc => sc.ShoppingCarts)
//    .HasForeignKey(sc => sc.UserId);
//modelBuilder.Entity<ShoppingCart>()
//    .HasOne(sc => sc.Product)
//    .WithMany(sc => sc.ShoppingCarts)
//    .HasForeignKey(sc => sc.ProductId);