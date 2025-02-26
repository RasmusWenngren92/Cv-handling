using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Data;

public class CvDbContext(DbContextOptions<CvDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }
    public DbSet<EdjucationalExperience> EdjucationalExperience { get; set; }
    
    
}