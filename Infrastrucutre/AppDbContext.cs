using Domain.Core;
using Domain.Supporting.Auth.Entities;
using Infrastrucutre.Configure.Supporting.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ConfigureUser();
        
        base.OnModelCreating(modelBuilder);
    }
}