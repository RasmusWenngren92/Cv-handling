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
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Education>()
            .HasOne(e => e.User)
            .WithMany(u => u.Educations)
            .HasForeignKey(e => e.UserIdFk);
        
        modelBuilder.Entity<Work>()
            .HasOne(w => w.User)
            .WithMany(u => u.Works)
            .HasForeignKey(w => w.UserIdFk);
       
    }
}