using Application.Eceptions;

namespace Domain.Core.Menu;

public class MenuGroup : BaseEntity, IEntity
{
    public string Name { get; private set; } = string.Empty;
    private readonly List<MenuItem> _items = new();
    public IReadOnlyCollection<MenuItem> Items => _items;
    
    
    public Guid MenuId { get; private set; }
    public Menu Menu { get; private set; }
    
    public void AddItem(MenuItem item)
    {
        if (_items.Any(i => i.Name == item.Name))
            throw new CustomException("Така позиція вже існує в групі.");

        _items.Add(item);
    }

    public MenuItem GetItemById(Guid itemId)
    {
        return _items.FirstOrDefault(item => item.Id == itemId);
    }
}