using Domain.Supporting.Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Configure.Core.Menu;

public static class MenuConfigure
{
    public static void ConfigureMenu(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Core.Menu.Menu>().ToTable("Menus", schema: "menu").HasKey(u => u.Id);

        modelBuilder.Entity<Domain.Core.Menu.Menu>().Property(u => u.Name).HasColumnName("Name").HasComment("Name");
        modelBuilder.Entity<Domain.Core.Menu.Menu>().Property(u => u.DateCreated).HasColumnName("DateCreated").HasComment("Дата створення");
        modelBuilder.Entity<Domain.Core.Menu.Menu>().Property(u => u.DateUpdated).HasColumnName("DateUpdated").HasComment("Дата оновлення");

        modelBuilder.Entity<Domain.Core.Menu.Menu>().HasMany(menu => menu.Groups).WithOne(group => group.Menu);
    }
}