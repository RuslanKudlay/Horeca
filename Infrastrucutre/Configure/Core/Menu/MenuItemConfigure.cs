using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Configure.Core.Menu;

public static class MenuItemConfigure
{
    public static void ConfigureMenuItem(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().ToTable("MenuItem", schema: "menu").HasKey(u => u.Id);

        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().Property(u => u.Name).HasColumnName("Name").HasComment("Name");
        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().Property(u => u.Description).HasColumnName("Description").HasComment("Description");
        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().Property(u => u.Price).HasColumnName("Price").HasComment("Price");
        
        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().Property(u => u.DateCreated).HasColumnName("DateCreated").HasComment("Дата створення");
        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().Property(u => u.DateUpdated).HasColumnName("DateUpdated").HasComment("Дата оновлення");

        modelBuilder.Entity<Domain.Core.Menu.MenuItem>().HasOne(item => item.MenuGroup).WithMany(group => group.Items);
    }
}