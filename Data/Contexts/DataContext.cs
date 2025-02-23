using Data.Entities;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<CustomerEntity> Customers { get; set; } = null!;
    public DbSet<ProjectEntity> Projects { get; set; } = null!;

    public DbSet<ProductEntity> Products { get; set; } = null!;
    public DbSet<StatusTypeEntity> StatusType { get; set; } = null!;
    public DbSet<UserEntity> Users { get; set; } = null!;
}
