﻿// <auto-generated />
using DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataModels.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    partial class MoviesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataModels.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Genre");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");

                    b.HasData(
                        new { Id = 1, Genre = 4, Title = "Fast and Furious", UserId = 2, Year = 2010 },
                        new { Id = 2, Genre = 4, Title = "Fast and Furious", UserId = 1, Year = 2010 },
                        new { Id = 3, Genre = 1, Title = "Scary Movie", UserId = 2, Year = 2008 },
                        new { Id = 4, Genre = 5, Title = "Matrix", UserId = 1, Year = 2009 }
                    );
                });

            modelBuilder.Entity("DataModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1, FirstName = "Bob", LastName = "Bobsky", Password = "(?\\?-??3#>L?q", Username = "bob007" },
                        new { Id = 2, FirstName = "Milan", LastName = "Vujovic", Password = "J,?R?,?q?A??`?", Username = "mil007" }
                    );
                });

            modelBuilder.Entity("DataModels.Movie", b =>
                {
                    b.HasOne("DataModels.User", "User")
                        .WithMany("MoviesList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
