using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Configure.Core.Menu;

public static class MenuGroupConfigure
{
    public static void ConfigureMenuGroup(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Core.Menu.MenuGroup>().ToTable("MenuGroups", schema: "menu").HasKey(u => u.Id);

        modelBuilder.Entity<Domain.Core.Menu.MenuGroup>().Property(u => u.Name).HasColumnName("Name").HasComment("Name");
        modelBuilder.Entity<Domain.Core.Menu.MenuGroup>().Property(u => u.DateCreated).HasColumnName("DateCreated").HasComment("Дата створення");
        modelBuilder.Entity<Domain.Core.Menu.MenuGroup>().Property(u => u.DateUpdated).HasColumnName("DateUpdated").HasComment("Дата оновлення");

        modelBuilder.Entity<Domain.Core.Menu.MenuGroup>().HasMany(group => group.Items).WithOne(item => item.MenuGroup);
    }
}