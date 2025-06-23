using Domain.Core;
using Domain.Core.Menu;
using Domain.Supporting.Auth.Entities;
using Infrastrucutre.Configure.Core.Menu;
using Infrastrucutre.Configure.Supporting.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Menu> Menus { get; set; }
    public DbSet<MenuGroup> MenuGroups { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<BaseEntity>();
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureMenu();
        modelBuilder.ConfigureMenuGroup();
        modelBuilder.ConfigureMenuItem();
        
        base.OnModelCreating(modelBuilder);
    }
}