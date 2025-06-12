using Domain.Supporting.Auth.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre.Configure.Supporting.Auth;

public static class UserConfigure
{
    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users", schema: "auth").HasKey(u => u.Id);

        modelBuilder.Entity<User>().Property(u => u.Email).HasColumnName("Email").HasComment("Email");
        modelBuilder.Entity<User>().Property(u => u.Name).HasColumnName("Name").HasComment("Ім'я користувача");
        modelBuilder.Entity<User>().Property(u => u.Password).HasColumnName("Password").HasComment("Пароль користувача");
        modelBuilder.Entity<User>().Property(u => u.Phone).HasColumnName("Phone").HasComment("Номер телефону користувача");
        modelBuilder.Entity<User>().Property(u => u.DateCreated).HasColumnName("DateCreated").HasComment("Дата створення");
        modelBuilder.Entity<User>().Property(u => u.DateUpdated).HasColumnName("DateUpdated").HasComment("Дата оновлення");
    }
}