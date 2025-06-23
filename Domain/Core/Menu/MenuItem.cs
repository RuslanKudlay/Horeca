using Application.Eceptions;

namespace Domain.Core.Menu;

public class MenuItem : BaseEntity, IEntity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public bool IsAvailable { get; private set; } = true;
    
    public Guid MenuGroupId { get; set; }
    public MenuGroup MenuGroup { get; set; }
    
    public MenuItem(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CustomException("Назва не може бути порожньою.");

        if (price <= 0)
            throw new CustomException("Ціна має бути більшою за 0.");

        Name = name;
        Description = description;
        Price = price;
    }

    public void UpdateDetails(string name, string description, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new CustomException("Назва не може бути порожньою.");

        if (price <= 0)
            throw new CustomException("Ціна має бути більшою за 0.");

        Name = name;
        Description = description;
        Price = price;
        SetUpdated();
    }

    public void SetAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
        SetUpdated();
    }
}