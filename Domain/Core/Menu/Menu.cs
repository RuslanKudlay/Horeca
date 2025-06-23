using Application.Eceptions;

namespace Domain.Core.Menu;

public class Menu : BaseEntity, IAggregateRoot
{
    public string Name { get; private set; } = string.Empty;
    
    private readonly List<MenuGroup> _groups = new();
    public IReadOnlyCollection<MenuGroup> Groups => _groups;

    public void AddGroup(MenuGroup group)
    {
        if (_groups.Any(g => g.Name == group.Name))
            throw new CustomException("Група з такою назвою вже існує.");

        _groups.Add(group);
    }
    
    public void UpdateMenuItem(Guid groupId, Guid itemId, string newName, string newDescription, decimal newPrice)
    {
        var group = _groups.FirstOrDefault(g => g.Id == groupId)
                    ?? throw new CustomException("Group not found.");

        var item = group.GetItemById(itemId);
        item.UpdateDetails(newName, newDescription, newPrice);
    }
}