using Cv_handling.Models;
using Microsoft.EntityFrameworkCore;

namespace Cv_handling.Data;

public class CvDbContext(DbContextOptions<CvDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<Work> Work { get; set; }
    public DbSet<Education> Education { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany(u => u.Works)      
            .WithOne(w => w.User)      
            .HasForeignKey(w => w.UserIdFk) 
            .OnDelete(DeleteBehavior.Cascade); 
    }
}