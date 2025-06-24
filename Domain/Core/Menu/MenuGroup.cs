using Application.Eceptions;

namespace Domain.Core.Menu;

public class MenuGroup : BaseEntity, IEntity
{
    public string Name { get; private set; } = string.Empty;
    private List<MenuItem> _items = new();
    public IReadOnlyCollection<MenuItem> Items => _items;
    
    public Guid? ParentId { get; set; }
    public MenuGroup? Parent { get; set; }
    
    
    public Guid MenuId { get; private set; }
    public Menu Menu { get; private set; }

    public MenuGroup(string name, Guid menuId, Guid? parentId)
    {
        Name = name;
        MenuId = menuId;
        ParentId = parentId;
    }

    public MenuGroup Rename(string name)
    {
        Name = name;
        return this;
    }

    public MenuGroup ChangeMenuId(Guid menuId)
    {
        MenuId = menuId;
        return this;
    }

    public MenuGroup ChangeParent(Guid? parentId)
    {
        ParentId = parentId;
        return this;
    }

    public MenuGroup SetItems(List<MenuItem> items)
    {
        _items = items.Count > 0 ? items : [];
        return this;
    }
    
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