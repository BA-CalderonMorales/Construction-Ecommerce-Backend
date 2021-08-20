﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eCommerceStarterCode.Data;

namespace eCommerceStarterCode.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "da02b5b2-273e-4891-8c58-cf6d960455e5",
                            ConcurrencyStamp = "12c1b165-7d4c-47f4-b653-e723eaf0ca23",
                            Name = "User",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "a866bdcc-cfd8-4774-92c5-6c8e50f5ae31",
                            ConcurrencyStamp = "8c12a509-bbb8-48d7-a2ec-61ef8b8903eb",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Category", b =>
                {
                    b.Property<int?>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Roofing"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Plumbing"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Tile"
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Concrete"
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Remodeling"
                        });
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Contract", b =>
                {
                    b.Property<int?>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double?>("CustomerPriceProposal")
                        .HasColumnType("float");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Location")
                        .HasColumnType("float");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("TypeOfWork")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CustomerId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Owner", b =>
                {
                    b.Property<int?>("OwnerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OwnerId");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Project", b =>
                {
                    b.Property<int?>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DetailsOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DurationOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocationOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ReviewId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            ProjectId = 1,
                            CategoryId = 1,
                            DetailsOfProject = "Details for First Project",
                            DurationOfProject = "15 Days",
                            ImageOfProject = "insertImageForFirstProject",
                            LocationOfProject = "insertLocationForFirstProject",
                            NameOfProject = "First Project"
                        },
                        new
                        {
                            ProjectId = 2,
                            CategoryId = 2,
                            DetailsOfProject = "Details for Second Project",
                            DurationOfProject = "2 Days",
                            ImageOfProject = "insertImageForSecondProject",
                            LocationOfProject = "insertLocationForSecondProject",
                            NameOfProject = "Second Project"
                        },
                        new
                        {
                            ProjectId = 3,
                            CategoryId = 3,
                            DetailsOfProject = "Details for Third Project",
                            DurationOfProject = "2 Months",
                            ImageOfProject = "insertImageForThirdProject",
                            LocationOfProject = "insertLocationForThirdProject",
                            NameOfProject = "Third Project"
                        },
                        new
                        {
                            ProjectId = 4,
                            CategoryId = 4,
                            DetailsOfProject = "Details for Fourth Project",
                            DurationOfProject = "3 Months",
                            ImageOfProject = "insertImageForFourthProject",
                            LocationOfProject = "insertLocationForFourthProject",
                            NameOfProject = "Fourth Project"
                        });
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Review", b =>
                {
                    b.Property<int?>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ReviewContent")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Contract", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.Owner", null)
                        .WithMany("Contracts")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Customer", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany("Customers")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Owner", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.ApplicationUser", null)
                        .WithMany("Owners")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Project", b =>
                {
                    b.HasOne("eCommerceStarterCode.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("eCommerceStarterCode.Models.Owner", null)
                        .WithMany("Projects")
                        .HasForeignKey("OwnerId");

                    b.HasOne("eCommerceStarterCode.Models.Review", "Reviews")
                        .WithMany()
                        .HasForeignKey("ReviewId");

                    b.Navigation("Category");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.ApplicationUser", b =>
                {
                    b.Navigation("Customers");

                    b.Navigation("Owners");
                });

            modelBuilder.Entity("eCommerceStarterCode.Models.Owner", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
