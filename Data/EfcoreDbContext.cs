using efcore.Entities;
using Microsoft.EntityFrameworkCore;

namespace efcore.Data;

public class EfcoreDbContext : DbContext
{
    public EfcoreDbContext(DbContextOptions<EfcoreDbContext> options) : base(options)
    {
        
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Member>().ToTable("Members");
    }

}