using CourseWork.Modules.Admin.Entity;
using CourseWork.Modules.User.Entity;
using Microsoft.EntityFrameworkCore;
using CourseWork.Modules.Blogs.Entity;

public class MyAppDbContext : DbContext
{
    // Adding the DbSet for each entity for Migration to work
    public DbSet<UserEntity> Users { get; set; }

    public DbSet<AdminEntity> Admin { get; set; }

    public DbSet<BlogEntity> Blogs { get; set; }

    public DbSet<BlogComment> BlogComments { get; set; }

    public MyAppDbContext(DbContextOptions<MyAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}