
using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Data;

public class CvDbContext(DbContextOptions<CvDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<Education> Educations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasData(
            new User { UserId = 1, FirstName = "Olof", LastName = "Johansson", EmailAddress = "olof.johansson@stormaktstiden.se", PhoneNumber = "+46701234567" },
            new User { UserId = 2, FirstName = "Astrid", LastName = "Bergström", EmailAddress = "astrid.bergstrom@scifiworld.com", PhoneNumber = "+46701234568" },
            new User { UserId = 3, FirstName = "Erik", LastName = "Lindqvist", EmailAddress = "erik.lindqvist@bakeryking.com", PhoneNumber = "+46701234569" },
            new User { UserId = 4, FirstName = "Karl", LastName = "Norrström", EmailAddress = "karl.norrstrom@swedishempirehistory.com", PhoneNumber = "+46701234570" },
            new User { UserId = 5, FirstName = "Lena", LastName = "Sjöberg", EmailAddress = "lena.sjoberg@techbaker.com", PhoneNumber = "+46701234571" }
        );
        modelBuilder.Entity<Education>().HasData(
            new Education { EducationId = 1, SchoolName = "Stockholm University", Degree = "Bachelor in History of the Swedish Empire", StartYear = 2005, GraduationYear = 2008, UseridFk = 1 },
            new Education { EducationId = 2, SchoolName = "Lund University", Degree = "Master of Science in Astrophysics", StartYear = 2010, GraduationYear = 2015, UseridFk = 2 },
            new Education { EducationId = 3, SchoolName = "Royal Swedish Academy of Arts", Degree = "Diploma in Culinary Arts", StartYear = 2002, GraduationYear = 2004, UseridFk = 3 },
            new Education { EducationId = 4, SchoolName = "Uppsala University", Degree = "PhD in Early Modern Swedish History", StartYear = 2008, GraduationYear = 2013, UseridFk = 4 },
            new Education { EducationId = 5, SchoolName = "KTH Royal Institute of Technology", Degree = "Master's in Food Technology and Innovation", StartYear = 2016, GraduationYear = 2020, UseridFk = 5 }
        );
        modelBuilder.Entity<Work>().HasData(
            new Work { WorkId = 1, Title = "Historical Consultant", Company = "Swedish Empire Archives", Description = "Researching the Swedish Empire’s military strategies and key battles.", StartYear = 2010, EndYear = 2018, UserIdFk = 1 },
            new Work { WorkId = 2, Title = "Astrophysicist", Company = "Galactic Horizons", Description = "Working on deep space exploration projects in the field of star formation.", StartYear = 2016, EndYear = null, UserIdFk = 2 },
            new Work { WorkId = 3, Title = "Head Baker", Company = "Royal Swedish Bakery", Description = "Leading a team of bakers in creating Swedish pastries and traditional breads.", StartYear = 2005, EndYear = 2012, UserIdFk= 3 },
            new Work { WorkId = 4, Title = "Swedish Empire Historian", Company = "Historical Sweden", Description = "Curating exhibits and writing books about Sweden's Age of Greatness.", StartYear = 2013, EndYear = null, UserIdFk = 4 },
            new Work { WorkId = 5, Title = "Food Scientist", Company = "TechBakery Innovations", Description = "Developing new techniques for creating healthier and innovative bakery products.", StartYear = 2020, EndYear = null, UserIdFk = 5 }
        );

    }
}