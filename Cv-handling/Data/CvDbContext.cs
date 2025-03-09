
using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Data;

public class CvDbContext(DbContextOptions<CvDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Work> Works { get; set; }
    public DbSet<Education> Educations { get; set; }
    
}