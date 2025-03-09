﻿// <auto-generated />
using Cv_handling.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cv_handling.Migrations
{
    [DbContext(typeof(CvDbContext))]
    [Migration("20250309210235_SeedInitialData")]
    partial class SeedInitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cv_handling.Models.Education", b =>
                {
                    b.Property<int>("EducationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EducationId"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("GraduationYear")
                        .HasColumnType("int");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<int>("UseridFk")
                        .HasColumnType("int");

                    b.HasKey("EducationId");

                    b.HasIndex("UseridFk");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            EducationId = 1,
                            Degree = "Bachelor in History of the Swedish Empire",
                            GraduationYear = 2008,
                            SchoolName = "Stockholm University",
                            StartYear = 2005,
                            UseridFk = 1
                        },
                        new
                        {
                            EducationId = 2,
                            Degree = "Master of Science in Astrophysics",
                            GraduationYear = 2015,
                            SchoolName = "Lund University",
                            StartYear = 2010,
                            UseridFk = 2
                        },
                        new
                        {
                            EducationId = 3,
                            Degree = "Diploma in Culinary Arts",
                            GraduationYear = 2004,
                            SchoolName = "Royal Swedish Academy of Arts",
                            StartYear = 2002,
                            UseridFk = 3
                        },
                        new
                        {
                            EducationId = 4,
                            Degree = "PhD in Early Modern Swedish History",
                            GraduationYear = 2013,
                            SchoolName = "Uppsala University",
                            StartYear = 2008,
                            UseridFk = 4
                        },
                        new
                        {
                            EducationId = 5,
                            Degree = "Master's in Food Technology and Innovation",
                            GraduationYear = 2020,
                            SchoolName = "KTH Royal Institute of Technology",
                            StartYear = 2016,
                            UseridFk = 5
                        });
                });

            modelBuilder.Entity("Cv_handling.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            EmailAddress = "olof.johansson@stormaktstiden.se",
                            FirstName = "Olof",
                            LastName = "Johansson",
                            PhoneNumber = "+46701234567"
                        },
                        new
                        {
                            UserId = 2,
                            EmailAddress = "astrid.bergstrom@scifiworld.com",
                            FirstName = "Astrid",
                            LastName = "Bergström",
                            PhoneNumber = "+46701234568"
                        },
                        new
                        {
                            UserId = 3,
                            EmailAddress = "erik.lindqvist@bakeryking.com",
                            FirstName = "Erik",
                            LastName = "Lindqvist",
                            PhoneNumber = "+46701234569"
                        },
                        new
                        {
                            UserId = 4,
                            EmailAddress = "karl.norrstrom@swedishempirehistory.com",
                            FirstName = "Karl",
                            LastName = "Norrström",
                            PhoneNumber = "+46701234570"
                        },
                        new
                        {
                            UserId = 5,
                            EmailAddress = "lena.sjoberg@techbaker.com",
                            FirstName = "Lena",
                            LastName = "Sjöberg",
                            PhoneNumber = "+46701234571"
                        });
                });

            modelBuilder.Entity("Cv_handling.Models.Work", b =>
                {
                    b.Property<int>("WorkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WorkId"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int?>("EndYear")
                        .HasColumnType("int");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("UseridFk")
                        .HasColumnType("int");

                    b.HasKey("WorkId");

                    b.HasIndex("UseridFk");

                    b.ToTable("Works");

                    b.HasData(
                        new
                        {
                            WorkId = 1,
                            Company = "Swedish Empire Archives",
                            Description = "Researching the Swedish Empire’s military strategies and key battles.",
                            EndYear = 2018,
                            StartYear = 2010,
                            Title = "Historical Consultant",
                            UseridFk = 1
                        },
                        new
                        {
                            WorkId = 2,
                            Company = "Galactic Horizons",
                            Description = "Working on deep space exploration projects in the field of star formation.",
                            StartYear = 2016,
                            Title = "Astrophysicist",
                            UseridFk = 2
                        },
                        new
                        {
                            WorkId = 3,
                            Company = "Royal Swedish Bakery",
                            Description = "Leading a team of bakers in creating Swedish pastries and traditional breads.",
                            EndYear = 2012,
                            StartYear = 2005,
                            Title = "Head Baker",
                            UseridFk = 3
                        },
                        new
                        {
                            WorkId = 4,
                            Company = "Historical Sweden",
                            Description = "Curating exhibits and writing books about Sweden's Age of Greatness.",
                            StartYear = 2013,
                            Title = "Swedish Empire Historian",
                            UseridFk = 4
                        },
                        new
                        {
                            WorkId = 5,
                            Company = "TechBakery Innovations",
                            Description = "Developing new techniques for creating healthier and innovative bakery products.",
                            StartYear = 2020,
                            Title = "Food Scientist",
                            UseridFk = 5
                        });
                });

            modelBuilder.Entity("Cv_handling.Models.Education", b =>
                {
                    b.HasOne("Cv_handling.Models.User", "User")
                        .WithMany("Educations")
                        .HasForeignKey("UseridFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cv_handling.Models.Work", b =>
                {
                    b.HasOne("Cv_handling.Models.User", "User")
                        .WithMany("Works")
                        .HasForeignKey("UseridFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Cv_handling.Models.User", b =>
                {
                    b.Navigation("Educations");

                    b.Navigation("Works");
                });
#pragma warning restore 612, 618
        }
    }
}
